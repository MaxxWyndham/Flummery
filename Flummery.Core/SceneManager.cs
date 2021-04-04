using System;
using System.Collections.Generic;
using System.Linq;

using Flummery.Core.Collision;
using Flummery.Core.Entities;

using ToxicRagers.Helpers;

namespace Flummery.Core
{
    public enum ChangeType
    {
        Add,
        Delete,
        Rename,
        Move,
        Transform,
        Munge,
        ChangeType
    }

    public enum ChangeContext
    {
        Model,
        Material
    }

    // These values correspond with the index of icons in ilNodeIcons
    public enum ContextMode
    {
        Generic = 0,
        Accessory = 4,
        Car = 5,
        Level = 6,
        Ped = 7
    }

    public enum PrimitiveType
    {
        Lines,
        LineStrip,
        Triangles,
        Quads
    }

    public enum CoordinateSystem
    {
        LeftHanded,
        RightHanded
    }

    public class SceneManager
    {
        public static SceneManager Current;

        public IRenderer Renderer { get; private set; }

        List<IRenderMode> renderModes = new List<IRenderMode>();
        int currentRenderMode = 0;

        public bool CanUseVertexBuffer { get; set; }

        public ContentManager Content { get; } = new ContentManager();

        public IRenderMode RenderMode => renderModes[currentRenderMode];

        public List<IEntity> Entities { get; } = new List<IEntity>();

        public List<Model> Models { get; } = new List<Model>();

        public MaterialList Materials { get; } = new MaterialList();

        public Matrix4D Transform { get; private set; } = Matrix4D.Identity;

        public string FrontFace { get; private set; } = "Ccw";

        public CoordinateSystem CoordinateSystem { get; private set; } = CoordinateSystem.LeftHanded;

        public Random Random { get; } = new Random();

        public Model SelectedModel
        {
            get
            {
                if (Models.Count == 0 || Models.Count < SelectedModelIndex) { return null; }
                if (Models[SelectedModelIndex].Bones.Count < SelectedBoneIndex) { return null; }
                return Models[SelectedModelIndex];
            }
        }

        public Material SelectedMaterial => (Material)Materials.Entries.FirstOrDefault(m => m.Key == SelectedMaterialKey);

        public List<string> Games { get; } = new List<string> { "None" };

        public string Game { get; private set; }

        public ContextMode Mode { get; private set; }

        public int SelectedModelIndex { get; private set; } = 0;

        public int SelectedBoneIndex { get; private set; } = 0;

        public long SelectedMaterialKey { get; private set; } = 0;

        public float DeltaTime { get; private set; }

        public delegate void ResetHandler(object sender, ResetEventArgs e);
        public delegate void AddHandler(object sender, AddEventArgs e);
        public delegate void SelectHandler(object sender, SelectEventArgs e);
        public delegate void SelectRootHandler(object sender, SelectRootEventArgs e);
        public delegate void ChangeHandler(object sender, ChangeEventArgs e);
        public delegate void ProgressHandler(object sender, ProgressEventArgs e);
        public delegate void ErrorHandler(object sender, ErrorEventArgs e);
        public delegate void ContextChangeHandler(object sender, ContextChangeEventArgs e);
        public delegate void SelectMaterialHandler(object sender, SelectMaterialEventArgs e);

        public event ResetHandler OnReset;
        public event AddHandler OnAdd;
        public event SelectHandler OnSelect;
        public event SelectRootHandler OnSelectRoot;
        public event ChangeHandler OnChange;
        public event ProgressHandler OnProgress;
        public event ErrorHandler OnError;
        public event ContextChangeHandler OnContextChange;
        public event SelectMaterialHandler OnSelectMaterial;

        public static void Create(IRenderer renderer)
        {
            new SceneManager(renderer);
        }

        public SceneManager(IRenderer renderer)
        {
            Current = this;

            Console.WriteLine("Initialising...");

            Renderer = renderer;

            renderModes.Add(new Solid());
            renderModes.Add(new Wireframe());
            renderModes.Add(new SolidWireframe());
            renderModes.Add(new VertexColour());

            //        // these will be registered by the plugins eventuallly
            //        renderModes.Add(new CrushData());

            //InputManager.Current.RegisterInputAction(ClearBoundingBox, "ClearBoundingBox", "Deselects the currently selected mesh", "Scene");
            InputManager.Current.RegisterInputAction(CycleRenderMode, "CycleRenderMode", "Cycles through the available render modes", "Scene");
            InputManager.Current.RegisterInputAction(ToggleCoordinateSystem, "ToggleCoordinateSystem", "Swaps between Left-handed and Right-handed co-ordinate systems", "Scene");

            createCoreEntities();
        }

        private void createCoreEntities()
        {
            Entities.Add(new Grid());
        }

        public Asset Add(Asset asset)
        {
            Model m = (asset as Model);
            int index;

            if (m != null)
            {
                index = Models.Count;
                Models.Add(m);

                foreach (ModelBone bone in m.Bones)
                {
                    switch (bone.Type)
                    {
                        case BoneType.Light:
                            Light light = new Light();
                            light.LinkWith(bone);
                            Entities.Add(light);
                            break;

                        case BoneType.VFX:
                            VFX vfx = new VFX();
                            vfx.LinkWith(bone);
                            Entities.Add(vfx);
                            break;
                    }
                }

                OnAdd?.Invoke(this, new AddEventArgs(asset, index));
            }
            else
            {
                index = Materials.Entries.IndexOf(asset as Material);

                if (index == -1)
                {
                    index = Materials.Entries.Count;
                    Materials.Entries.Add(asset as Material);

                    OnAdd?.Invoke(this, new AddEventArgs(asset, index));
                }
            }

            return asset;
        }

        public void Change(ChangeType type, ChangeContext context, int index, object additionalInfo = null)
        {
            OnChange?.Invoke(this, new ChangeEventArgs(type, context, index, additionalInfo));
        }

        public void SetContext(string game)
        {
            SetContext(game, Mode);
        }

        public void SetContext(ContextMode mode)
        {
            SetContext(Game, mode);
        }

        public void SetContext(string game, ContextMode mode)
        {
            Game = game;
            Mode = mode;

            OnContextChange?.Invoke(this, new ContextChangeEventArgs(game, mode));
        }

        public void SetActiveMaterial(long key)
        {
            SelectedMaterialKey = key;

            OnSelectMaterial?.Invoke(this, new SelectMaterialEventArgs(key));
        }

        public void SetCoordinateSystem(CoordinateSystem c)
        {
            CoordinateSystem = c;

            if (c == CoordinateSystem.RightHanded)
            {
                Transform = Matrix4D.Identity;
                FrontFace = "Ccw";
            }
            else
            {
                Transform = Matrix4D.CreateScale(1, 1, -1);
                FrontFace = "Cw";
            }
        }

        public void ToggleCoordinateSystem()
        {
            if (CoordinateSystem == CoordinateSystem.LeftHanded)
            {
                SetCoordinateSystem(CoordinateSystem.RightHanded);
            }
            else
            {
                SetCoordinateSystem(CoordinateSystem.LeftHanded);
            }
        }

        public void CycleRenderMode()
        {
            //        do
            //        {
            //            currentRenderMode++;
            //            if (currentRenderMode == renderModes.Count) { currentRenderMode = 0; }
            //        }
            //        while (!renderModes[currentRenderMode].IsValid());
        }

        public void Reset()
        {
            Content.Reset();
            Entities.Clear();
            Models.Clear();
            Materials.Entries.Clear();

            createCoreEntities();

            OnReset?.Invoke(this, new ResetEventArgs());
        }

        public void Update(float dt)
        {
            DeltaTime = dt;
        }

        public void Lights()
        {
            Renderer.Enable("PolygonSmooth");
            Renderer.Enable("Lighting");
            Renderer.Enable("Light0");

            Renderer.Light("Light0", "Position", new float[] { 0.0f, 1.0f, 0.0f });
            Renderer.Light("Light0", "Ambient", new float[] { 0.5f, 0.5f, 0.5f, 1.0f });
            Renderer.Light("Light0", "Diffuse", new float[] { 1.0f, 1.0f, 1.0f, 1.0f });
            Renderer.Light("Light0", "Specular", new float[] { 1.0f, 1.0f, 1.0f, 1.0f });

            Renderer.LightModel("LightModelAmbient", new float[] { 0.7f, 0.7f, 0.7f, 1.0f });
            Renderer.LightModel("LightModelTwoSide", 0);
            Renderer.LightModel("LightModelLocalViewer", 1);
        }

        public void Draw(Camera camera)
        {
            Matrix4D lookat = camera.View;

            Renderer.MatrixMode("Modelview");
            Renderer.LoadMatrix(ref lookat);

            Renderer.FrontFace(FrontFace);

            Lights();

            foreach (Model model in Models)
            {
                model.Draw();
            }

            foreach (IEntity entity in Entities)
            {
                entity.Draw();
            }
        }

        public void Trace(Ray ray)
        {
            foreach (Model model in Models)
            {
                CollisionHelpers.RayIntersectsModel(ray, model, out bool insideBoundingSphere, out Vector3 vertex1, out Vector3 vertex2, out Vector3 vertex3, out ModelMeshPart intersectsWithPart, out ModelMesh intersectsWith);

                if (intersectsWithPart != null)
                {
                    Console.WriteLine(intersectsWith.Name);

                    Entities.Add(new Face { Points = new List<Vector3> { vertex1, vertex2, vertex3 } });
                }
            }
        }

        public void UpdateProgress(string message)
        {
            OnProgress?.Invoke(this, new ProgressEventArgs(message));
        }

        public void RaiseError(string message)
        {
            OnError?.Invoke(this, new ErrorEventArgs(message));
        }

        public void SetSelectedBone(int modelIndex, int boneIndex)
        {
            if (modelIndex == -1)
            {
                if (boneIndex == -1) { OnSelectRoot?.Invoke(this, new SelectRootEventArgs()); }
                return;
            }

            SelectedModelIndex = modelIndex;
            SelectedBoneIndex = boneIndex;

            OnSelect?.Invoke(this, new SelectEventArgs(Models[modelIndex].Bones[boneIndex]));
        }
    }

    public class ResetEventArgs : EventArgs
    {
        public ResetEventArgs()
        {
        }
    }

    public class AddEventArgs : EventArgs
    {
        public Asset Item { get; private set; }

        public int Index { get; private set; }

        public AddEventArgs(Asset item, int index)
        {
            Item = item;
            Index = index;
        }
    }

    public class SelectEventArgs : EventArgs
    {
        public ModelBone Item { get; private set; }

        public SelectEventArgs(ModelBone item)
        {
            Item = item;
        }
    }

    public class SelectRootEventArgs : EventArgs
    {
        public ContextMode Mode => SceneManager.Current.Mode;

        public string Game => SceneManager.Current.Game;
    }

    public class ChangeEventArgs : EventArgs
    {
        public ChangeType Change { get; private set; }

        public ChangeContext Context { get; private set; }

        public int Index { get; private set; }

        public object AdditionalInformation { get; private set; }

        public ChangeEventArgs(ChangeType type, ChangeContext context, int index, object additionalInfo = null)
        {
            Change = type;
            Context = context;
            Index = index;
            AdditionalInformation = additionalInfo;
        }
    }

    public class ProgressEventArgs : EventArgs
    {
        public string Status { get; private set; }

        public ProgressEventArgs(string status)
        {
            Status = status;
        }
    }

    public class ErrorEventArgs : EventArgs
    {
        public string Message { get; private set; }

        public ErrorEventArgs(string message)
        {
            Message = message;
        }
    }

    public class ContextChangeEventArgs : EventArgs
    {
        public string GameContext { get; private set; }

        public ContextMode ModeContext { get; private set; }

        public ContextChangeEventArgs(string game, ContextMode mode)
        {
            GameContext = game;
            ModeContext = mode;
        }
    }

    public class SelectMaterialEventArgs : EventArgs
    {
        public long MaterialKey { get; private set; }

        public SelectMaterialEventArgs(long key)
        {
            MaterialKey = key;
        }
    }
}