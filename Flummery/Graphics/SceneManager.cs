using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Flummery
{
    public class SceneManager
    {
        public static SceneManager Scene;

        List<Entity> entities = new List<Entity>();
        List<Model> models = new List<Model>();
        List<Texture> textures = new List<Texture>();

        bool bVertexBuffer;
        Camera camera;
        ContentManager content;

        public bool CanUseVertexBuffer { get { return bVertexBuffer; } }
        public Camera Camera { get { return camera; } }
        public ContentManager Content { get { return content; } }

        public List<Entity> Entities { get { return entities; } }
        public List<Model> Models { get { return models; } }
        public List<Texture> Textures { get { return textures; } }

        public delegate void AddHandler(object sender, AddEventArgs e);
        public delegate void ProgressHandler(object sender, ProgressEventArgs e);
        public event AddHandler OnAdd;
        public event ProgressHandler OnProgress;

        public SceneManager(bool bUseVertexBuffer = true)
        {
            content = new ContentManager();
            camera = new Camera();

            bVertexBuffer = bUseVertexBuffer;
            Scene = this;
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
                textures.Add(asset as Texture);
            }

            if (OnAdd != null) { OnAdd(this, new AddEventArgs(asset)); }

            return asset;
        }

        public void Update(float dt)
        {
            camera.Update(dt);
        }

        public void Lights()
        {
            GL.Light(LightName.Light0, LightParameter.Position, new float[] { 0.0f, 2.0f, 0.0f });
            GL.Light(LightName.Light0, LightParameter.Ambient, new float[] { 0.6f, 0.6f, 0.6f, 1.0f });
            GL.Light(LightName.Light0, LightParameter.Diffuse, new float[] { 1.0f, 1.0f, 1.0f, 1.0f });
            GL.Light(LightName.Light0, LightParameter.Specular, new float[] { 1.0f, 1.0f, 1.0f, 1.0f });
            GL.Light(LightName.Light0, LightParameter.SpotExponent, new float[] { 1.0f, 1.0f, 1.0f, 1.0f });
            GL.LightModel(LightModelParameter.LightModelAmbient, new float[] { 0.7f, 0.7f, 0.7f, 1.0f });
            GL.LightModel(LightModelParameter.LightModelTwoSide, 0);
            GL.LightModel(LightModelParameter.LightModelLocalViewer, 1);
            GL.Enable(EnableCap.Lighting);
            GL.Enable(EnableCap.Light0);
        }

        public void Draw()
        {
            Matrix4 lookat = camera.viewMatrix;
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);

            Lights();

            foreach (var model in models)
            {
                Matrix4[] transforms = new Matrix4[model.Bones.Count];
                model.CopyAbsoluteBoneTransformsTo(transforms);

                foreach (var mesh in model.Meshes)
                {
                    GL.PushMatrix();

                    GL.MultMatrix(ref transforms[mesh.Parent.Index]);

                    mesh.Draw();

                    GL.PopMatrix();
                }
            }
        }

        public void UpdateProgress(string message)
        {
            if (OnProgress != null) { OnProgress(this, new ProgressEventArgs(message)); }
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
