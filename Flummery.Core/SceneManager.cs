using System;
using System.Collections.Generic;

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

    public enum ContextGame
    {
        None,
        Carmageddon1,
        Carmageddon2,
        CarmageddonTDR2000,
        CarmageddonMaxDamage
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

        public BoundingBox BoundingBox { get; private set; } = null;

        List<IRenderMode> renderModes = new List<IRenderMode>();
        int currentRenderMode = 0;

        public Entity Node;

        public bool CanUseVertexBuffer { get; set; }

        public ContentManager Content { get; } = new ContentManager();

        public IRenderMode RenderMode => renderModes[currentRenderMode];

        public List<Entity> Entities { get; } = new List<Entity>();

        public List<Model> Models { get; } = new List<Model>();

        public MaterialList Materials { get; } = new MaterialList();

        public Matrix4D Transform { get; private set; } = Matrix4D.Identity;

        public string FrontFace { get; private set; } = "Ccw";

        public CoordinateSystem CoordinateSystem { get; private set; } = CoordinateSystem.LeftHanded;

        public Model SelectedModel
        {
            get
            {
                if (Models.Count == 0 || Models.Count < SelectedModelIndex) { return null; }
                if (Models[SelectedModelIndex].Bones.Count < SelectedBoneIndex) { return null; }
                return Models[SelectedModelIndex];
            }
        }

        public ContextGame Game { get; private set; }

        public ContextMode Mode { get; private set; }

        public int SelectedModelIndex { get; private set; } = 0;

        public int SelectedBoneIndex { get; private set; } = 0;

        public float DeltaTime { get; private set; }

        public delegate void ResetHandler(object sender, ResetEventArgs e);
        public delegate void AddHandler(object sender, AddEventArgs e);
        public delegate void SelectHandler(object sender, SelectEventArgs e);
        public delegate void SelectRootHandler(object sender, SelectRootEventArgs e);
        public delegate void ChangeHandler(object sender, ChangeEventArgs e);
        public delegate void ProgressHandler(object sender, ProgressEventArgs e);
        public delegate void ErrorHandler(object sender, ErrorEventArgs e);
        public delegate void ContextChangeHandler(object sender, ContextChangeEventArgs e);

        public event ResetHandler OnReset;
        public event AddHandler OnAdd;
        public event SelectHandler OnSelect;
        public event SelectRootHandler OnSelectRoot;
        public event ChangeHandler OnChange;
        public event ProgressHandler OnProgress;
        public event ErrorHandler OnError;
        public event ContextChangeHandler OnContextChange;

        public static void Create(IRenderer renderer)
        {
            new SceneManager(renderer);
        }

        public SceneManager(IRenderer renderer)
        {
            Current = this;

            Console.WriteLine("Initialising...");

            Renderer = renderer;

            Node = new Entity
            {
                Name = "node",
                EntityType = EntityType.Bone,
                AssetType = AssetType.Model,
                Asset = new Model()
            };

            //Sphere sphere = new Sphere(0.125f, 7, 7);
            //ModelManipulator.SetVertexColour(sphere, 0, 255, 0, 255);
            //((Model)Node.Asset).AddMesh(sphere);
            //((Model)Node.Asset).SetRenderStyle(RenderStyle.Wireframe);
            //Entities.Add(Node);

            renderModes.Add(new Solid());
            renderModes.Add(new Wireframe());
            renderModes.Add(new SolidWireframe());
            renderModes.Add(new VertexColour());

            //        // these will be registered by the plugins eventuallly
            //        renderModes.Add(new CrushData());

            InputManager.Current.RegisterInputAction(ClearBoundingBox, "ClearBoundingBox", "Deselects the currently selected mesh", "Scene");
            InputManager.Current.RegisterInputAction(CycleRenderMode, "CycleRenderMode", "Cycles through the available render modes", "Scene");
            InputManager.Current.RegisterInputAction(ToggleCoordinateSystem, "ToggleCoordinateSystem", "Swaps between Left-handed and Right-handed co-ordinate systems", "Scene");
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
                        case BoneType.VFX:
                            Entity entity = new Entity
                            {
                                Name = bone.Name,
                                EntityType = bone.Type.ToString().ToEnum<EntityType>(),
                                AssetType = AssetType.Sprite
                            };
                            entity.LinkWith(bone);

                            Entities.Add(entity);
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

        //    public void SetContext(ContextGame game)
        //    {
        //        SetContext(game, Mode);
        //    }

        //    public void SetContext(ContextMode mode)
        //    {
        //        SetContext(Game, mode);
        //    }

        public void SetContext(ContextGame game, ContextMode mode)
        {
            Game = game;
            Mode = mode;

            OnContextChange?.Invoke(this, new ContextChangeEventArgs(game, mode));
        }

        public void ClearBoundingBox()
        {
            SetBoundingBox(null);
        }

        public void SetBoundingBox(BoundingBox bb)
        {
            Node.LinkWith(null);
            BoundingBox = bb;
        }

        public void SetNodePosition(ModelBone bone)
        {
            Node.LinkWith(bone, LinkType.Position | LinkType.Rotation);
            BoundingBox = null;
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
            BoundingBox = null;

            Entities.Add(Node);

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

            Renderer.Disable("CullFace");
            Renderer.Disable("Texture2D");
            Renderer.Disable("Lighting");
            Renderer.Disable("Light0");

            Renderer.PolygonMode("FrontAndBack", "Line");

            Renderer.Begin(PrimitiveType.Quads);
            Renderer.Color4(0f, 1.0f, 0f, 1.0f);

            Renderer.Vertex3(-1.0f, 0, -1.0f);
            Renderer.Vertex3(0, 0, -1.0f);
            Renderer.Vertex3(0, 0, 0);
            Renderer.Vertex3(-1.0f, 0, 0);

            Renderer.Vertex3(0, 0, -1.0f);
            Renderer.Vertex3(1.0f, 0, -1.0f);
            Renderer.Vertex3(1.0f, 0, 0);
            Renderer.Vertex3(0, 0, 0);

            Renderer.Vertex3(-1.0f, 0, 0);
            Renderer.Vertex3(0, 0, 0);
            Renderer.Vertex3(0, 0, 1.0f);
            Renderer.Vertex3(-1.0f, 0, 1.0f);

            Renderer.Vertex3(0, 0, 0);
            Renderer.Vertex3(1.0f, 0, 0);
            Renderer.Vertex3(1.0f, 0, 1.0f);
            Renderer.Vertex3(0, 0, 1.0f);
            Renderer.End();

            if (BoundingBox != null) { BoundingBox.Draw(); }

            Renderer.Enable("CullFace");
            Renderer.Enable("Texture2D");
            Renderer.Enable("Lighting");
            Renderer.Enable("Light0");
            Renderer.FrontFace(FrontFace);

            Lights();

            foreach (Model model in Models)
            {
                model.Draw();
            }

            foreach (Entity entity in Entities)
            {
                entity.Draw();
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

        public ContextGame Game => SceneManager.Current.Game;
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
        public ContextGame GameContext { get; private set; }

        public ContextMode ModeContext { get; private set; }

        public ContextChangeEventArgs(ContextGame game, ContextMode mode)
        {
            GameContext = game;
            ModeContext = mode;
        }
    }
}