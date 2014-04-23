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

        bool bRequiresFinalise = false;

        List<Vector3> verts;
        List<Vector3> norms;
        List<Vector2> uvs;

        int[] face = new int[3];
        int point = 0;

        public int VertexCount { get { return vertexBuffer.Length; } }

        public ModelMeshPart()
        {
            vertexBuffer = new VertexBuffer();
            indexBuffer = new IndexBuffer();

            verts = new List<Vector3>();
            norms = new List<Vector3>();
            uvs = new List<Vector2>();
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

        public int CreateNormal(Single x, Single y, Single z)
        {
            var v = new Vector3(x, y, z);

            var i = norms.IndexOf(v);

            if (i == -1)
            {
                norms.Add(v);
                return norms.Count - 1;
            }
            else
            {
                return i;
            }
        }

        public int CreateUV(Single u, Single v)
        {
            var uv = new Vector2(u, v);

            var i = uvs.IndexOf(uv);

            if (i == -1)
            {
                uvs.Add(uv);
                return uvs.Count - 1;
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

        public void AddVertexNormal(Vector3 normal)
        {
            norms.Add(normal);
        }

        public void AddVertexUV(Vector2 uv)
        {
            uvs.Add(uv);
        }

        List<string> faces = new List<string>();

        public void AddFace(int[] positions, int[] normals, int[] uvs)
        {
            for (int i = 0; i < 3; i++)
            {
                string key = string.Format("{0}.{1}.{2}", positions[i], normals[i], uvs[i]);
                int index = faces.IndexOf(key);

                if (index == -1)
                {
                    faces.Add(key);

                    var v = new Vertex();
                    v.Position = verts[positions[i]];
                    v.Normal = norms[normals[i]];
                    v.UV = this.uvs[uvs[i]];

                    vertexBuffer.AddVertex(v);
                    indexBuffer.AddIndex(faces.Count - 1);
                }
                else
                {
                    indexBuffer.AddIndex(index);
                }
            }
        }

        public void Finalise()
        {
            if (SceneManager.Scene.CanUseVertexBuffer)
            {
                //// prepare Vertex array
                //List<Vertex> vl = new List<Vertex>();

                //for (int i = 0; i < indexBuffer.Data.Length; i++)
                //{
                //    var v = new Vertex();
                //    v.Position = verts[indexBuffer.Data[i]];
                //    v.Normal = norms[i];
                //    v.UV = uvs[i];

                //    //vl.Add(v);

                //    //if (!vl.Contains(v))
                //    //{
                        
                //    //}
                //}

                //if (norms.Count == 0)
                //{
                //    for (int i = 0; i < vl.Count; i += 3)
                //    {
                //        Vertex v0 = vl[i + 0];
                //        Vertex v1 = vl[i + 1];
                //        Vertex v2 = vl[i + 2];

                //        Vector3 normal = Vector3.Normalize(Vector3.Cross(v2.Position - v0.Position, v1.Position - v0.Position));

                //        v0.Normal += normal;
                //        v1.Normal += normal;
                //        v2.Normal += normal;

                //        vl[i + 0] = v0;
                //        vl[i + 1] = v1;
                //        vl[i + 2] = v2;
                //    }

                //    for (int i = 0; i < vl.Count; i++)
                //    {
                //        var v = vl[i];
                //        v.Normal = Vector3.Normalize(v.Normal);
                //        vl[i] = v;
                //    }
                //}

                indexBuffer.Initialise();
                vertexBuffer.Initialise();
            }
        }

        public void Draw()
        {
            var data = indexBuffer.Data;

            GL.Enable(EnableCap.DepthTest);

            //GL.BindTexture(TextureTarget.Texture2D, TextureID);

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
