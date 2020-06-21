using System;
using System.Collections.Generic;

using OpenTK;
using OpenTK.Graphics.OpenGL;

using ToxicRagers.Helpers;

namespace Flummery
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
        CarmageddonReincarnation
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

    public class SceneManager
    {
        public enum CoordinateSystem
        {
            LeftHanded,
            RightHanded
        }

        public static SceneManager Current;

        int selectedBoneIndex = 0;
        int selectedModelIndex = 0;
        BoundingBox bb = null;

        List<IRenderMode> renderModes = new List<IRenderMode>();
        int currentRenderMode = 0;
        List<Model> models = new List<Model>();
        MaterialList materials = new MaterialList();

        Matrix4 sceneTransform = Matrix4.Identity;
        CoordinateSystem coords = CoordinateSystem.LeftHanded;
        FrontFaceDirection frontFace = FrontFaceDirection.Ccw;

        Entity node;

        bool bVertexBuffer;
        ContentManager content;

        ContextGame currentGame;
        ContextMode currentMode;

        float dt;

        public bool CanUseVertexBuffer => bVertexBuffer;
        public ContentManager Content => content;
        public IRenderMode RenderMode => renderModes[currentRenderMode];

        public List<Entity> Entities { get; } = new List<Entity>();
        public List<Model> Models => models;
        public MaterialList Materials => materials;

        public Matrix4 Transform => sceneTransform;
        public CoordinateSystem CoordSystem => coords;

        public Model SelectedModel
        {
            get
            {
                if (models.Count == 0 || models.Count < selectedModelIndex) { return null; }
                if (models[selectedModelIndex].Bones.Count < selectedBoneIndex) { return null; }
                return models[selectedModelIndex];
            }
        }

        public ContextGame Game => currentGame;
        public ContextMode Mode => currentMode;

        public int SelectedModelIndex => selectedModelIndex;
        public int SelectedBoneIndex => selectedBoneIndex;
        public float DeltaTime => dt;

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

        public static void Create(bool bUseVertexBuffer = true)
        {
            new SceneManager(bUseVertexBuffer);
        }

        public SceneManager(bool bUseVertexBuffer = true)
        {
            Current = this;

            content = new ContentManager();

            bVertexBuffer = bUseVertexBuffer;

            node = new Entity
            {
                Name = "node",
                EntityType = EntityType.Bone,
                AssetType = AssetType.Model,
                Asset = new Model()
            };

            Sphere sphere = new Sphere(0.125f, 7, 7);
            ModelManipulator.SetVertexColour(sphere, 0, 255, 0, 255);
            ((Model)node.Asset).AddMesh(sphere);
            ((Model)node.Asset).SetRenderStyle(RenderStyle.Wireframe);
            Entities.Add(node);

            renderModes.Add(new Solid());
            renderModes.Add(new Wireframe());
            renderModes.Add(new SolidWireframe());
            renderModes.Add(new VertexColour());

            // these will be registered by the plugins eventuallly
            renderModes.Add(new CrushData());

            InputManager.Current.RegisterBinding('d', KeyBinding.KeysClearSelection, ClearBoundingBox);
            InputManager.Current.RegisterBinding('w', KeyBinding.KeysRenderMode, CycleRenderMode);
            InputManager.Current.RegisterBinding('p', KeyBinding.KeysCoordinateSystem, ToggleCoordinateSystem);
        }

        public Asset Add(Asset asset)
        {
            int index = -1;
            Model m = (asset as Model);

            if (m != null)
            {
                index = models.Count;
                models.Add(m);

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
                index = materials.Entries.IndexOf(asset as Material);

                if (index == -1)
                {
                    index = materials.Entries.Count;
                    materials.Entries.Add(asset as Material);

                    OnAdd?.Invoke(this, new AddEventArgs(asset, index));
                }
            }
            return asset;
        }

        public void Change(ChangeType type, ChangeContext context, int index, object additionalInfo = null)
        {
            OnChange?.Invoke(this, new ChangeEventArgs(type, context, index, additionalInfo));
        }

        public void SetContext(ContextGame game)
        {
            SetContext(game, currentMode);
        }

        public void SetContext(ContextMode mode)
        {
            SetContext(currentGame, mode);
        }

        public void SetContext(ContextGame game, ContextMode mode)
        {
            currentGame = game;
            currentMode = mode;

            OnContextChange?.Invoke(this, new ContextChangeEventArgs(game, mode));
        }

        public void ClearBoundingBox()
        {
            SetBoundingBox(null);
        }

        public void SetBoundingBox(BoundingBox bb)
        {
            node.LinkWith(null);
            this.bb = bb;
        }

        public void SetNodePosition(ModelBone bone)
        {
            node.LinkWith(bone, LinkType.Position | LinkType.Rotation);
            bb = null;
        }

        public void SetCoordinateSystem(CoordinateSystem c)
        {
            coords = c;

            if (c == CoordinateSystem.RightHanded)
            {
                sceneTransform = Matrix4.Identity;
                frontFace = FrontFaceDirection.Ccw;
            }
            else
            {
                sceneTransform = Matrix4.CreateScale(1, 1, -1);
                frontFace = FrontFaceDirection.Cw;
            }
        }

        public void ToggleCoordinateSystem()
        {
            if (coords == CoordinateSystem.LeftHanded)
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
            do
            {
                currentRenderMode++;
                if (currentRenderMode == renderModes.Count) { currentRenderMode = 0; }
            }
            while (!renderModes[currentRenderMode].IsValid());
        }

        public void Reset()
        {
            content.Reset();
            Entities.Clear();
            models.Clear();
            materials.Entries.Clear();
            bb = null;

            Entities.Add(node);

            OnReset?.Invoke(this, new ResetEventArgs());
        }

        public void Update(float dt)
        {
            this.dt = dt;
        }

        public void Lights()
        {
            GL.Enable(EnableCap.PolygonSmooth);
            GL.Enable(EnableCap.Lighting);
            GL.Enable(EnableCap.Light0);
            GL.Light(LightName.Light0, LightParameter.Position, new float[] { 0.0f, 1.0f, 0.0f });
            GL.Light(LightName.Light0, LightParameter.Ambient, new float[] { 0.5f, 0.5f, 0.5f, 1.0f });
            GL.Light(LightName.Light0, LightParameter.Diffuse, new float[] { 1.0f, 1.0f, 1.0f, 1.0f });
            GL.Light(LightName.Light0, LightParameter.Specular, new float[] { 1.0f, 1.0f, 1.0f, 1.0f });
            //GL.Light(LightName.Light0, LightParameter.SpotExponent, new float[] { 1.0f, 1.0f, 1.0f, 1.0f });
            GL.LightModel(LightModelParameter.LightModelAmbient, new float[] { 0.7f, 0.7f, 0.7f, 1.0f });
            GL.LightModel(LightModelParameter.LightModelTwoSide, 0);
            GL.LightModel(LightModelParameter.LightModelLocalViewer, 1);
        }

        public void Draw(Camera camera)
        {
            Matrix4 lookat = camera.View;
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);

            GL.Disable(EnableCap.CullFace);
            GL.Disable(EnableCap.Texture2D);
            GL.Disable(EnableCap.Lighting);
            GL.Disable(EnableCap.Light0);

            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);

            GL.Begin(PrimitiveType.Quads);
            GL.Color4(0f, 1.0f, 0f, 1.0f);

            GL.Vertex3(-1.0f, 0, -1.0f);
            GL.Vertex3(0, 0, -1.0f);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(-1.0f, 0, 0);

            GL.Vertex3(0, 0, -1.0f);
            GL.Vertex3(1.0f, 0, -1.0f);
            GL.Vertex3(1.0f, 0, 0);
            GL.Vertex3(0, 0, 0);

            GL.Vertex3(-1.0f, 0, 0);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 0, 1.0f);
            GL.Vertex3(-1.0f, 0, 1.0f);

            GL.Vertex3(0, 0, 0);
            GL.Vertex3(1.0f, 0, 0);
            GL.Vertex3(1.0f, 0, 1.0f);
            GL.Vertex3(0, 0, 1.0f);
            GL.End();

            if (bb != null) { bb.Draw(); }

            GL.Enable(EnableCap.CullFace);
            GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.Lighting);
            GL.Enable(EnableCap.Light0);
            GL.FrontFace(frontFace);

            Lights();

            foreach (Model model in models)
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

            selectedModelIndex = modelIndex;
            selectedBoneIndex = boneIndex;

            OnSelect?.Invoke(this, new SelectEventArgs(models[modelIndex].Bones[boneIndex]));
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