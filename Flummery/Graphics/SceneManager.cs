using System;
using System.Collections.Generic;
using OpenTK;

namespace Flummery
{
    public class SceneManager
    {
        public static SceneManager Scene;
        List<Model> models = new List<Model>();
        bool bVertexBuffer;

        public bool UseVertexBuffer { get { return bVertexBuffer; } }

        public SceneManager(bool bUseVertexBuffer = true)
        {
            bVertexBuffer = bUseVertexBuffer;
            Scene = this;
        }

        public void Add(Model asset)
        {
            models.Add(asset);
        }

        public void Draw()
        {
            foreach (var model in models)
            {
                Matrix3d[] transforms = new Matrix3d[model.Bones.Count];
                model.CopyAbsoluteBoneTransformsTo(transforms);

                foreach (var mesh in model.Meshes)
                {
                    mesh.Draw();
                }
            }
        }
    }
}
