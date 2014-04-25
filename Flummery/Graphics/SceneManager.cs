using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Flummery
{
    public class SceneManager
    {
        public static SceneManager Scene;
        List<Model> models = new List<Model>();
        bool bVertexBuffer;
        Camera camera;

        public bool CanUseVertexBuffer { get { return bVertexBuffer; } }
        public Camera Camera { get { return camera; } }

        public delegate void AddHandler(object sender, AddEventArgs e);
        public delegate void ProgressHandler(object sender, ProgressEventArgs e);
        public event AddHandler OnAdd;
        public event ProgressHandler OnProgress;

        public SceneManager(bool bUseVertexBuffer = true)
        {
            camera = new Camera();

            bVertexBuffer = bUseVertexBuffer;
            Scene = this;
        }

        public void Add(Model asset)
        {
            models.Add(asset);

            if (OnAdd != null) { OnAdd(this, new AddEventArgs(asset)); }
        }

        public void Update(float dt)
        {
            camera.Update(dt);
        }

        public void Draw()
        {
            Matrix4 lookat = camera.viewMatrix;
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);

            GL.Scale(1.0f, 1.0f, -1.0f);

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
