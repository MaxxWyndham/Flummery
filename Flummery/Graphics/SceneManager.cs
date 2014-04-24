using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Flummery
{
    public class SceneManager
    {
        public static SceneManager Scene;
        List<Model> models = new List<Model>();
        ToolStripStatusLabel progress;
        bool bVertexBuffer;
        Camera camera;

        public bool CanUseVertexBuffer { get { return bVertexBuffer; } }
        public Camera Camera { get { return camera; } }

        public SceneManager(ToolStripStatusLabel progressbar, bool bUseVertexBuffer = true)
        {
            camera = new Camera();

            this.progress = progressbar;
            bVertexBuffer = bUseVertexBuffer;
            Scene = this;
        }

        public void Add(Model asset)
        {
            models.Add(asset);
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
            progress.Text = message;
            progress.Owner.Refresh();
        }
    }
}
