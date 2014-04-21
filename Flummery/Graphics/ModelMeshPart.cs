using System;
using System.Collections.Generic;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Flummery
{
    public class ModelMeshPart
    {
        IndexBuffer indexBuffer;
        int PrimitiveCount;
        int StartIndex;
        object Tag;
        VertexBuffer vertexBuffer;
        int VertexOffset;

        List<Vector3> verts;
        int[] face = new int[3];
        int point = 0;

        public int VertexCount { get { return vertexBuffer.Length; } }

        public ModelMeshPart()
        {
            vertexBuffer = new VertexBuffer();
            indexBuffer = new IndexBuffer();

            verts = new List<Vector3>();
        }

        public int CreatePosition(Single x, Single y, Single z)
        {
            var v = new Vector3(x, y, z);

            var i = verts.IndexOf(v);

            if (i == -1)
            {
                verts.Add(v);
                return verts.Count - 1;
            }
            else
            {
                return i;
            }
        }

        public void AddTriangleVertex(int index)
        {
            face[point] = index;

            if (++point == 3)
            {
                indexBuffer.AddTriangle(face);
                point = 0;
            }
        }

        public void Finalise()
        {
            // turn indexBuffer and verts into proper buffer objects
            // See commented code in VertexBuffer and http://www.opentk.com/node/2302#comment-11602
        }

        public void Draw()
        {
            var data = indexBuffer.Data;

            GL.Enable(EnableCap.DepthTest);

            //GL.BindTexture(TextureTarget.Texture2D, TextureID);

            GL.DepthFunc(DepthFunction.Lequal);
            GL.Color3(Color.White);
            GL.Enable(EnableCap.Lighting);

            // Reversed for testing
            if (!SceneManager.Scene.UseVertexBuffer)
            {

            }
            else
            {
                GL.Begin(PrimitiveType.Triangles);
                for (int i = 0; i < data.Length; i += 3)
                {
                    GL.Vertex3(verts[data[i + 0]]);
                    GL.Vertex3(verts[data[i + 1]]);
                    GL.Vertex3(verts[data[i + 2]]);
                }
                GL.End();
            }
        }
    }
}
