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

        public bool CanUseVertexBuffer { get { return bVertexBuffer; } }

        public SceneManager(ToolStripStatusLabel progressbar, bool bUseVertexBuffer = true)
        {
            this.progress = progressbar;
            bVertexBuffer = bUseVertexBuffer;
            Scene = this;
        }

        public void Add(Model asset)
        {
            models.Add(asset);
        }

        public void Draw(float rotation = 0)
        {
            Matrix4 lookat = Matrix4.LookAt(0, 2.5f, 8.0f, 0, 0.5f, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);

            GL.Scale(1.0f, 1.0f, -1.0f);
            GL.Rotate(-rotation, OpenTK.Vector3.UnitY);

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
