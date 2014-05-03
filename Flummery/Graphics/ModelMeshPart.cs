using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
        Texture texture;

        public IndexBuffer IndexBuffer { get { return indexBuffer; } }
        public VertexBuffer VertexBuffer { get { return vertexBuffer; } }

        public int VertexCount { get { return vertexBuffer.Length; } }

        public Texture Texture
        {
            get { return texture; }
            set { texture = value; }
        }

        public ModelMeshPart()
        {
            vertexBuffer = new VertexBuffer();
            indexBuffer = new IndexBuffer();
        }

        static int GetIndex(IList<Vertex> list, Vertex value)
        {
            for (int index = 0; index < list.Count; index++)
            {
                if (list[index].Position == value.Position && list[index].Normal == value.Normal && list[index].UV == value.UV)
                {
                    return index;
                }
            }
            return -1;
        }

        public void AddFace(Vector3[] positions, Vector3[] normals, Vector2[] texcoords)
        {
            for (int i = 0; i < 3; i++)
            {
                var v = new Vertex();
                v.Position = positions[i];
                v.Normal = normals[i];
                v.UV = texcoords[i];

                //int index = vertexBuffer.Data.FindIndex(vert => vert.Position == v.Position);

                //if (index == -1)
                //{
                vertexBuffer.AddVertex(v);
                indexBuffer.AddIndex(vertexBuffer.Length - 1);
                //}
                //else
                //{
                //    indexBuffer.AddIndex(index);
                //}
            }
        }

        public void Finalise()
        {
            if (SceneManager.Scene.CanUseVertexBuffer)
            {
                indexBuffer.Initialise();
                vertexBuffer.Initialise();
            }
        }

        public void Draw()
        {
            var data = indexBuffer.Data;

            GL.Enable(EnableCap.DepthTest);

            GL.BindTexture(TextureTarget.Texture2D, (texture != null ? texture.ID : 0));

            GL.Disable(EnableCap.Blend);

            GL.DepthFunc(DepthFunction.Lequal);
            GL.Color3(Color.White);
            GL.Enable(EnableCap.Lighting);

            if (SceneManager.Scene.CanUseVertexBuffer)
            {
                indexBuffer.Draw();
                vertexBuffer.Draw(indexBuffer.Length);
            }
            else
            {
                GL.Begin(PrimitiveType.Triangles);

                foreach (int i in indexBuffer.Data)
                {
                    var v = vertexBuffer.Data[i];

                    GL.TexCoord2(v.UV);
                    GL.Normal3(v.Normal);
                    GL.Vertex3(v.Position);
                }

                GL.End();
            }
        }
    }
}
