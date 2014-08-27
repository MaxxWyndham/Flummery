using System;
using System.Collections.Generic;

using OpenTK;
using OpenTK.Input;
using OpenTK.Graphics.OpenGL;

namespace Flummery
{
    public enum ChangeType
    {
        Add,
        Delete,
        Rename,
        Move,
        Transform,
        Munge
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
        List<Material> materials = new List<Material>();

        Matrix4 sceneTransform = Matrix4.Identity;
        CoordinateSystem coords = CoordinateSystem.LeftHanded;
        FrontFaceDirection frontFace = FrontFaceDirection.Ccw;

        Entity node;

        bool bVertexBuffer;
        ContentManager content;
        KeyboardState lastState;

        float dt;

        public bool CanUseVertexBuffer { get { return bVertexBuffer; } }
        public ContentManager Content { get { return content; } }
        public RenderMeshMode RenderMode { get { return renderMode; } }

        public List<Entity> Entities { get { return entities; } }
        public List<Model> Models { get { return models; } }
        public List<Material> Materials { get { return materials; } }

        public Matrix4 Transform { get { return sceneTransform; } }

        public int SelectedModelIndex { get { return selectedModelIndex; } }
        public int SelectedBoneIndex { get { return selectedBoneIndex; } }
        public float DeltaTime { get { return dt; } }

        public delegate void ResetHandler(object sender, ResetEventArgs e);
        public delegate void AddHandler(object sender, AddEventArgs e);
        public delegate void SelectHandler(object sender, SelectEventArgs e);
        public delegate void ChangeHandler(object sender, ChangeEventArgs e);
        public delegate void ProgressHandler(object sender, ProgressEventArgs e);
        public delegate void ErrorHandler(object sender, ErrorEventArgs e);

        public event ResetHandler OnReset;
        public event AddHandler OnAdd;
        public event SelectHandler OnSelect;
        public event ChangeHandler OnChange;
        public event ProgressHandler OnProgress;
        public event ErrorHandler OnError;

        public SceneManager(bool bUseVertexBuffer = true)
        {
            content = new ContentManager();

            bVertexBuffer = bUseVertexBuffer;
            Current = this;

            node = new Entity
            {
                Name = "node",
                EntityType = EntityType.Bone,
                AssetType = AssetType.Model,
                Asset = new Model()
            };

            ((Model)node.Asset).AddMesh(new Sphere(0.125f, 7, 7));
        }

        public Asset Add(Asset asset)
        {
            int index = -1;
            var m = (asset as Model);

            if (m != null)
            {
                index = models.Count;
                models.Add(m);
            }
            else
            {
                index = materials.Count;
                materials.Add(asset as Material);
            }

            if (OnAdd != null) { OnAdd(this, new AddEventArgs(asset, index)); }

            return asset;
        }

        public void Change(ChangeType type, int index, object additionalInfo = null) 
        { 
            if (OnChange != null) { OnChange(this, new ChangeEventArgs(type, index, additionalInfo)); } 
        }

        public void SetBoundingBox(BoundingBox bb)
        {
            this.node.LinkWith(null);
            this.bb = bb;
        }

        public void SetNodePosition(ModelBone bone)
        {
            this.node.LinkWith(bone, LinkType.Position | LinkType.Rotation);
            this.bb = null;
        }

        public void SetCoordinateSystem(CoordinateSystem c)
        {
            this.coords = c;

            if (c == CoordinateSystem.RightHanded)
            {
                this.sceneTransform = Matrix4.Identity;
                this.frontFace = FrontFaceDirection.Ccw;
            }
            else
            {
                this.sceneTransform = Matrix4.CreateScale(1, 1, -1);
                this.frontFace = FrontFaceDirection.Cw;
            }
        }

        public void Reset()
        {
            content.Reset();
            entities.Clear();
            models.Clear();
            materials.Clear();
            bb = null;

            entities.Add(node);

            if (OnReset != null) { OnReset(this, new ResetEventArgs()); }
        }

        public bool HandleInput(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            var state = Keyboard.GetState();
            var bHandled = false;

            if (state[Key.W] && !lastState[Key.W])
            {
                renderMode = (RenderMeshMode)((int)renderMode + 1);
                if (renderMode == RenderMeshMode.Count) { renderMode = RenderMeshMode.Solid; }

                bHandled = true;
            }

            if (state[Key.P] && !lastState[Key.P])
            {
                if (coords == CoordinateSystem.LeftHanded)
                {
                    SetCoordinateSystem(CoordinateSystem.RightHanded);
                }
                else
                {
                    SetCoordinateSystem(CoordinateSystem.LeftHanded);
                }

                bHandled = true;
            }

            return bHandled;
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
            Matrix4 lookat = camera.viewMatrix;
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
            GL.Vertex3( 0,    0, -1.0f);
            GL.Vertex3( 0,    0,  0);
            GL.Vertex3(-1.0f, 0,  0);

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
            if (OnProgress != null) { OnProgress(this, new ProgressEventArgs(message)); }
        }

        public void RaiseError(string message)
        {
            if (OnError != null) { OnError(this, new ErrorEventArgs(message)); }
        }

        public void SetSelectedBone(int modelIndex, int boneIndex)
        {
            if (modelIndex == -1) { return; }

            selectedModelIndex = modelIndex;
            selectedBoneIndex = boneIndex;

            if (OnSelect != null) { OnSelect(this, new SelectEventArgs(models[modelIndex].Bones[boneIndex])); }
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
            this.Item = item;
            this.Index = index;
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
            this.Change = type;
            this.Index = index;
            this.AdditionalInformation = additionalInfo;
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
}
