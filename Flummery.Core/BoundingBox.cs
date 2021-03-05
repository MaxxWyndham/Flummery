using System;

using ToxicRagers.Helpers;

namespace Flummery.Core
{
    public class BoundingBox
    {
        public Vector3 Min { get; private set; }

        public Vector3 Max { get; private set; }

        public ModelMesh Mesh { get; private set; }

        public Vector3 Centre => new Vector3(
                    (Min.X + Max.X) / 2.0f,
                    (Min.Y + Max.Y) / 2.0f,
                    (Min.Z + Max.Z) / 2.0f
                );

        public BoundingBox(ModelMesh mesh)
        {
            Mesh = mesh;

            Calculate(mesh);
        }

        public void Calculate(ModelMesh mesh)
        {
            Min = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
            Max = new Vector3(float.MinValue, float.MinValue, float.MinValue);

            foreach (var part in mesh.MeshParts)
            {
                foreach (var vertex in part.VertexBuffer.Data)
                {
                    Min.X = Math.Min(Min.X, vertex.Position.X);
                    Min.Y = Math.Min(Min.Y, vertex.Position.Y);
                    Min.Z = Math.Min(Min.Z, vertex.Position.Z);

                    Max.X = Math.Max(Max.X, vertex.Position.X);
                    Max.Y = Math.Max(Max.Y, vertex.Position.Y);
                    Max.Z = Math.Max(Max.Z, vertex.Position.Z);
                }
            }
        }

        public void Draw()
        {
            Matrix4D mS = SceneManager.Current.Transform;
            Matrix4D mP = Mesh.Parent.CombinedTransform;

            SceneManager.Current.Renderer.PushMatrix();
            SceneManager.Current.Renderer.MultMatrix(ref mS);
            SceneManager.Current.Renderer.MultMatrix(ref mP);

            SceneManager.Current.Renderer.Begin(PrimitiveType.Quads);
            SceneManager.Current.Renderer.Color4(0f, 1.0f, 0f, 1.0f);

            SceneManager.Current.Renderer.Vertex3(Min.X, Min.Y, Min.Z);
            SceneManager.Current.Renderer.Vertex3(Min.X, Min.Y, Max.Z);
            SceneManager.Current.Renderer.Vertex3(Min.X, Max.Y, Max.Z);
            SceneManager.Current.Renderer.Vertex3(Min.X, Max.Y, Min.Z);

            SceneManager.Current.Renderer.Vertex3(Max.X, Min.Y, Min.Z);
            SceneManager.Current.Renderer.Vertex3(Max.X, Min.Y, Max.Z);
            SceneManager.Current.Renderer.Vertex3(Max.X, Max.Y, Max.Z);
            SceneManager.Current.Renderer.Vertex3(Max.X, Max.Y, Min.Z);

            SceneManager.Current.Renderer.Vertex3(Min.X, Min.Y, Min.Z);
            SceneManager.Current.Renderer.Vertex3(Max.X, Min.Y, Min.Z);
            SceneManager.Current.Renderer.Vertex3(Max.X, Max.Y, Min.Z);
            SceneManager.Current.Renderer.Vertex3(Min.X, Max.Y, Min.Z);

            SceneManager.Current.Renderer.Vertex3(Min.X, Min.Y, Max.Z);
            SceneManager.Current.Renderer.Vertex3(Max.X, Min.Y, Max.Z);
            SceneManager.Current.Renderer.Vertex3(Max.X, Max.Y, Max.Z);
            SceneManager.Current.Renderer.Vertex3(Min.X, Max.Y, Max.Z);

            SceneManager.Current.Renderer.End();

            SceneManager.Current.Renderer.PopMatrix();
        }
    }
}
