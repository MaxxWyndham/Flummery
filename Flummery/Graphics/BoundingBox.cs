using System;

using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Flummery
{
    public class BoundingBox
    {
        Vector3 min;
        Vector3 max;
        ModelMesh mesh;

        public Vector3 Min { get { return min; } }
        public Vector3 Max { get { return max; } }

        public Vector3 Centre 
        { 
            get 
            {
                return new Vector3(
                    (min.X + max.X) / 2.0f,
                    (min.Y + max.Y) / 2.0f,
                    (min.Z + max.Z) / 2.0f
                );
            } 
        }

        public BoundingBox(ModelMesh mesh)
        {
            this.mesh = mesh;

            Calculate(mesh);
        }

        public void Calculate(ModelMesh mesh)
        {
            min = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
            max = new Vector3(float.MinValue, float.MinValue, float.MinValue);

            foreach (var part in mesh.MeshParts)
            {
                foreach (var vertex in part.VertexBuffer.Data)
                {
                    min.X = Math.Min(min.X, vertex.Position.X);
                    min.Y = Math.Min(min.Y, vertex.Position.Y);
                    min.Z = Math.Min(min.Z, vertex.Position.Z);

                    max.X = Math.Max(max.X, vertex.Position.X);
                    max.Y = Math.Max(max.Y, vertex.Position.Y);
                    max.Z = Math.Max(max.Z, vertex.Position.Z);
                }
            }
        }

        public void Draw()
        {
            var m = mesh.Parent.CombinedTransform * SceneManager.Current.Transform;

            GL.PushMatrix();
            GL.MultMatrix(ref m);

            GL.Begin(PrimitiveType.Quads);
            GL.Color4(0f, 1.0f, 0f, 1.0f);

            GL.Vertex3(min.X, min.Y, min.Z);
            GL.Vertex3(min.X, min.Y, max.Z);
            GL.Vertex3(min.X, max.Y, max.Z);
            GL.Vertex3(min.X, max.Y, min.Z);

            GL.Vertex3(max.X, min.Y, min.Z);
            GL.Vertex3(max.X, min.Y, max.Z);
            GL.Vertex3(max.X, max.Y, max.Z);
            GL.Vertex3(max.X, max.Y, min.Z);

            GL.Vertex3(min.X, min.Y, min.Z);
            GL.Vertex3(max.X, min.Y, min.Z);
            GL.Vertex3(max.X, max.Y, min.Z);
            GL.Vertex3(min.X, max.Y, min.Z);

            GL.Vertex3(min.X, min.Y, max.Z);
            GL.Vertex3(max.X, min.Y, max.Z);
            GL.Vertex3(max.X, max.Y, max.Z);
            GL.Vertex3(min.X, max.Y, max.Z);

            GL.End();

            GL.PopMatrix();
        }
    }
}
