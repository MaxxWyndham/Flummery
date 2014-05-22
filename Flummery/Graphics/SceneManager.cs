using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Input;
using OpenTK.Graphics.OpenGL;

namespace Flummery
{
    public class SceneManager
    {
        public enum RenderMeshMode
        {
            Solid,
            SolidWireframe,
            Wireframe,
            Count
        }

        public static SceneManager Current;

        BoundingBox bb = null;

        RenderMeshMode renderMode = RenderMeshMode.Solid;
        List<Entity> entities = new List<Entity>();
        List<Model> models = new List<Model>();
        List<Material> materials = new List<Material>();

        bool bVertexBuffer;
        ContentManager content;
        KeyboardState lastState;

        public bool CanUseVertexBuffer { get { return bVertexBuffer; } }
        public ContentManager Content { get { return content; } }
        public RenderMeshMode RenderMode { get { return renderMode; } }

        public List<Entity> Entities { get { return entities; } }
        public List<Model> Models { get { return models; } }
        public List<Material> Materials { get { return materials; } }

        public delegate void ResetHandler(object sender, ResetEventArgs e);
        public delegate void AddHandler(object sender, AddEventArgs e);
        public delegate void ProgressHandler(object sender, ProgressEventArgs e);

        public event ResetHandler OnReset;
        public event AddHandler OnAdd;
        public event ProgressHandler OnProgress;

        public SceneManager(bool bUseVertexBuffer = true)
        {
            content = new ContentManager();

            bVertexBuffer = bUseVertexBuffer;
            Current = this;
        }

        public Asset Add(Asset asset)
        {
            var m = (asset as Model);

            if (m != null)
            {
                models.Add(m);
            }
            else
            {
                materials.Add(asset as Material);
            }

            if (OnAdd != null) { OnAdd(this, new AddEventArgs(asset)); }

            return asset;
        }

        public void SetBoundingBox(BoundingBox bb)
        {
            this.bb = bb;
        }

        public void Reset()
        {
            content.Reset();
            entities.Clear();
            models.Clear();
            materials.Clear();

            if (OnReset != null) { OnReset(this, new ResetEventArgs()); }
        }

        private void HandleInput(float dt)
        {
            var state = Keyboard.GetState();

            if (state[Key.W] && !lastState[Key.W])
            {
                renderMode = (RenderMeshMode)((int)renderMode + 1);
                if (renderMode == RenderMeshMode.Count) { renderMode = RenderMeshMode.Solid; }
            }

            lastState = state;
        }

        public void Update(float dt)
        {
            HandleInput(dt);
        }

        public void Lights()
        {
            GL.Enable(EnableCap.Lighting);
            GL.Enable(EnableCap.Light0);
            GL.Light(LightName.Light0, LightParameter.Position, new float[] { 0.0f, 2.0f, 0.0f });
            GL.Light(LightName.Light0, LightParameter.Ambient, new float[] { 0.6f, 0.6f, 0.6f, 1.0f });
            GL.Light(LightName.Light0, LightParameter.Diffuse, new float[] { 1.0f, 1.0f, 1.0f, 1.0f });
            GL.Light(LightName.Light0, LightParameter.Specular, new float[] { 1.0f, 1.0f, 1.0f, 1.0f });
            GL.Light(LightName.Light0, LightParameter.SpotExponent, new float[] { 1.0f, 1.0f, 1.0f, 1.0f });
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

            if (bb != null)
            {
                GL.Begin(PrimitiveType.Quads);
                GL.Color4(0f, 1.0f, 0f, 1.0f);

                GL.Vertex3(bb.Min.X, bb.Min.Y, bb.Min.Z);
                GL.Vertex3(bb.Min.X, bb.Min.Y, bb.Max.Z);
                GL.Vertex3(bb.Min.X, bb.Max.Y, bb.Max.Z);
                GL.Vertex3(bb.Min.X, bb.Max.Y, bb.Min.Z);

                GL.Vertex3(bb.Max.X, bb.Min.Y, bb.Min.Z);
                GL.Vertex3(bb.Max.X, bb.Min.Y, bb.Max.Z);
                GL.Vertex3(bb.Max.X, bb.Max.Y, bb.Max.Z);
                GL.Vertex3(bb.Max.X, bb.Max.Y, bb.Min.Z);

                GL.Vertex3(bb.Min.X, bb.Min.Y, bb.Min.Z);
                GL.Vertex3(bb.Max.X, bb.Min.Y, bb.Min.Z);
                GL.Vertex3(bb.Max.X, bb.Max.Y, bb.Min.Z);
                GL.Vertex3(bb.Min.X, bb.Max.Y, bb.Min.Z);

                GL.Vertex3(bb.Min.X, bb.Min.Y, bb.Max.Z);
                GL.Vertex3(bb.Max.X, bb.Min.Y, bb.Max.Z);
                GL.Vertex3(bb.Max.X, bb.Max.Y, bb.Max.Z);
                GL.Vertex3(bb.Min.X, bb.Max.Y, bb.Max.Z);

                GL.End();
            }

            GL.Enable(EnableCap.CullFace);
            GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.Lighting);
            GL.Enable(EnableCap.Light0);

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

        public AddEventArgs(Asset item)
        {
            Item = item;
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
}
