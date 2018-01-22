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

    public enum ContextGame
    {
        Carmageddon1,
        Carmageddon2,
        CarmageddonTDR2000,
        CarmageddonReincarnation
    }

    public enum ContextMode
    {
        Generic,
        Accessory,
        Car,
        Level,
        Ped
    }

    public class SceneManager
    {
        public enum RenderMeshMode
        {
            Solid,
            SolidWireframe,
            Wireframe,
            VertexColour,
            Count
        }

        public enum CoordinateSystem
        {
            LeftHanded,
            RightHanded
        }

        public static SceneManager Current;

        int selectedBoneIndex = 0;
        int selectedModelIndex = 0;
        BoundingBox bb = null;

        RenderMeshMode renderMode = RenderMeshMode.Solid;
        List<Entity> entities = new List<Entity>();
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
        public RenderMeshMode RenderMode => renderMode;

        public List<Entity> Entities => entities;
        public List<Model> Models => models;
        public MaterialList Materials => materials;

        public Matrix4 Transform => sceneTransform;

        public Model SelectedModel
        {
            get
            {
                if (models.Count == 0 || models.Count < selectedModelIndex) { return null; }
                if (models[selectedModelIndex].Bones.Count < selectedBoneIndex) { return null; }
                return models[selectedModelIndex];
            }
        }

        public ContextGame CurrentGame => currentGame;

        public ContextMode CurrentMode => currentMode;

        public int SelectedModelIndex => selectedModelIndex;
        public int SelectedBoneIndex => selectedBoneIndex;
        public float DeltaTime => dt;

        public delegate void ResetHandler(object sender, ResetEventArgs e);
        public delegate void AddHandler(object sender, AddEventArgs e);
        public delegate void SelectHandler(object sender, SelectEventArgs e);
        public delegate void ChangeHandler(object sender, ChangeEventArgs e);
        public delegate void ProgressHandler(object sender, ProgressEventArgs e);
        public delegate void ErrorHandler(object sender, ErrorEventArgs e);
        public delegate void ContextChangeHandler(object sender, ContextChangeEventArgs e);

        public event ResetHandler OnReset;
        public event AddHandler OnAdd;
        public event SelectHandler OnSelect;
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

            var sphere = new Sphere(0.125f, 7, 7);
            ModelManipulator.SetVertexColour(sphere, 0, 255, 0, 255);
            ((Model)node.Asset).AddMesh(sphere);
            ((Model)node.Asset).SetRenderStyle(RenderStyle.Wireframe);
            entities.Add(node);

            InputManager.Current.RegisterBinding('d', KeyBinding.KeysClearSelection, ClearBoundingBox);
            InputManager.Current.RegisterBinding('w', KeyBinding.KeysRenderMode, CycleRenderMode);
            InputManager.Current.RegisterBinding('p', KeyBinding.KeysCoordinateSystem, ToggleCoordinateSystem);
        }

        public Asset Add(Asset asset)
        {
            int index = -1;
            var m = (asset as Model);

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
                            var entity = new Entity
                            {
                                Name = bone.Name,
                                EntityType = bone.Type.ToString().ToEnum<EntityType>(),
                                AssetType = AssetType.Sprite
                            };
                            entity.LinkWith(bone);

                            entities.Add(entity);
                            break;
                    }
                }
            }
            else
            {
                index = materials.Entries.Count;
                materials.Entries.Add(asset as Material);
            }

            OnAdd?.Invoke(this, new AddEventArgs(asset, index));
            return asset;
        }

        public void Change(ChangeType type, int index, object additionalInfo = null)
        {
            OnChange?.Invoke(this, new ChangeEventArgs(type, index, additionalInfo));
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
            renderMode = (RenderMeshMode)((int)renderMode + 1);
            if (renderMode == RenderMeshMode.Count) { renderMode = RenderMeshMode.Solid; }
        }

        public void Reset()
        {
            content.Reset();
            entities.Clear();
            models.Clear();
            materials.Entries.Clear();
            bb = null;

            entities.Add(node);

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

            foreach (var model in models)
            {
                model.Draw();
            }

            foreach (var entity in entities)
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
            if (modelIndex == -1) { return; }

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

    public class ChangeEventArgs : EventArgs
    {
        public ChangeType Change { get; private set; }
        public int Index { get; private set; }
        public object AdditionalInformation { get; private set; }

        public ChangeEventArgs(ChangeType type, int index, object additionalInfo = null)
        {
            Change = type;
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