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
        object key;
        VertexBuffer vertexBuffer;
        Material material;
        Color colour;

        PrimitiveType primitiveType = PrimitiveType.Triangles;
        RenderStyle renderStyle = RenderStyle.Scene;

        public IndexBuffer IndexBuffer { get { return indexBuffer; } }
        public VertexBuffer VertexBuffer { get { return vertexBuffer; } }

        public RenderStyle RenderStyle
        {
            get { return renderStyle; }
            set { renderStyle = value; }
        }

        public object Key
        {
            get { return key; }
            set { key = value; }
        }

        public PrimitiveType PrimitiveType
        {
            get { return primitiveType; }
            set { primitiveType = value; }
        }

        public int VertexCount { get { return vertexBuffer.Length; } }

        public Material Material
        {
            get { return material; }
            set { material = value; }
        }

        public ModelMeshPart()
        {
            vertexBuffer = new VertexBuffer();
            indexBuffer = new IndexBuffer();

            colour = FlummeryApplication.PickRandomColour();
        }

        public int AddVertex(Vector3 position, Vector3 normal, Vector2 texcoords, bool bAddIndex = true)
        {
            return AddVertex(position, normal, texcoords, new Vector2(0, 1), Color.White, bAddIndex);
        }

        public int AddVertex(Vector3 position, Vector3 normal, Vector2 texcoords, Vector2 texcoords2, OpenTK.Graphics.Color4 colour, bool bAddIndex = true)
        {
            return AddVertex(position, normal, new Vector4(texcoords.X, texcoords.Y, texcoords2.X, texcoords2.Y), colour, bAddIndex);
        }

        public int AddVertex(Vector3 position, Vector3 normal, Vector4 texcoords, OpenTK.Graphics.Color4 colour, bool bAddIndex = true)
        {
            var v = new Vertex {
                Position = position,
                Normal = normal,
                UV = texcoords,
                Colour = colour
            };

            int index = vertexBuffer.AddVertex(v);
            if (bAddIndex) { indexBuffer.AddIndex(index); }

            return index;
        }

        public void AddFace(int v1, int v2, int v3)
        {
            indexBuffer.AddIndex(v1);
            indexBuffer.AddIndex(v2);
            indexBuffer.AddIndex(v3);
        }

        public void AddFace(Vector3[] positions, Vector3[] normals, Vector2[] texcoords)
        {
            for (int i = 0; i < 3; i++)
            {
                var v = new Vertex();
                v.Position = positions[i];
                v.Normal = normals[i];
                v.UV = new Vector4(texcoords[i].X, texcoords[i].Y, 0, 1);

                int index = vertexBuffer.Data.FindIndex(vert =>
                    vert.Position.X.GetHashCode() == v.Position.X.GetHashCode() &&
                    vert.Position.Y.GetHashCode() == v.Position.Y.GetHashCode() &&
                    vert.Position.Z.GetHashCode() == v.Position.Z.GetHashCode() &&
                    vert.Normal.X.GetHashCode() == v.Normal.X.GetHashCode() &&
                    vert.Normal.Y.GetHashCode() == v.Normal.Y.GetHashCode() &&
                    vert.Normal.Z.GetHashCode() == v.Normal.Z.GetHashCode() &&
                    vert.UV.X.GetHashCode() == v.UV.X.GetHashCode() &&
                    vert.UV.Y.GetHashCode() == v.UV.Y.GetHashCode() &&
                    vert.UV.Z.GetHashCode() == v.UV.Z.GetHashCode() &&
                    vert.UV.W.GetHashCode() == v.UV.W.GetHashCode() &&
                    vert.Colour == v.Colour
                );

                if (index == -1) { index = vertexBuffer.AddVertex(v); }

                indexBuffer.AddIndex(index);
            }
        }

        public void Optimise()
        {
            List<Vertex> vb = new List<Vertex>(vertexBuffer.Data);
            List<int> ib = new List<int>(indexBuffer.Data);

            vertexBuffer.Data.Clear();
            indexBuffer.Data.Clear();

            for (int i = 0; i < ib.Count; i++)
            {
                var v = vb[ib[i]];

                int index = vertexBuffer.Data.FindIndex(vert =>
                    vert.Position.X.GetHashCode() == v.Position.X.GetHashCode() &&
                    vert.Position.Y.GetHashCode() == v.Position.Y.GetHashCode() &&
                    vert.Position.Z.GetHashCode() == v.Position.Z.GetHashCode() &&
                    vert.Normal.X.GetHashCode() == v.Normal.X.GetHashCode() &&
                    vert.Normal.Y.GetHashCode() == v.Normal.Y.GetHashCode() &&
                    vert.Normal.Z.GetHashCode() == v.Normal.Z.GetHashCode() &&
                    vert.UV.X.GetHashCode() == v.UV.X.GetHashCode() &&
                    vert.UV.Y.GetHashCode() == v.UV.Y.GetHashCode() &&
                    vert.UV.Z.GetHashCode() == v.UV.Z.GetHashCode() &&
                    vert.UV.W.GetHashCode() == v.UV.W.GetHashCode() &&
                    vert.Colour == v.Colour
                );

                if (index == -1) { index = vertexBuffer.AddVertex(v); }

                indexBuffer.AddIndex(index);

                if (i % 2500 == 0) { SceneManager.Current.UpdateProgress(string.Format("Optimising: {0:0.00}% complete", (i * 100.0f) / ib.Count)); }
            }

            indexBuffer.Initialise();
            vertexBuffer.Initialise();

            SceneManager.Current.UpdateProgress(string.Format("Optimisation complete! {0} vert(s) removed.", vb.Count - vertexBuffer.Data.Count));
        }

        public void Finalise()
        {
            if (SceneManager.Current.CanUseVertexBuffer)
            {
                indexBuffer.Initialise();
                vertexBuffer.Initialise();
            }
        }

        public void Draw()
        {
            
            var data = indexBuffer.Data;

            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, (material != null && material.Texture != null ? material.Texture.ID : 0));

            GL.DepthFunc(DepthFunction.Lequal);
            GL.Enable(EnableCap.Lighting);
            GL.Enable(EnableCap.Light0);

            if (SceneManager.Current.CanUseVertexBuffer)
            {
                switch (renderStyle)
                {
                    case RenderStyle.Scene:
                        switch (SceneManager.Current.RenderMode)
                        {
                            case SceneManager.RenderMeshMode.Solid:
                                GL.PolygonMode(MaterialFace.Front, PolygonMode.Fill);
                                break;

                            case SceneManager.RenderMeshMode.Wireframe:
                                GL.Disable(EnableCap.Texture2D);
                                GL.Disable(EnableCap.Lighting);
                                GL.Disable(EnableCap.Light0);
                                GL.PolygonMode(MaterialFace.Front, PolygonMode.Line);
                                GL.Color4(colour);
                                break;

                            case SceneManager.RenderMeshMode.SolidWireframe:
                                GL.PolygonMode(MaterialFace.Front, PolygonMode.Fill);
                                vertexBuffer.Draw(indexBuffer, primitiveType);
                                GL.PolygonOffset(1.0f, 2);
                                GL.Disable(EnableCap.Texture2D);
                                GL.Color4(Color.White);
                                GL.PolygonMode(MaterialFace.Front, PolygonMode.Line);
                                break;

                            case SceneManager.RenderMeshMode.VertexColour:
                                GL.Disable(EnableCap.Texture2D);
                                GL.PolygonMode(MaterialFace.Front, PolygonMode.Fill);
                                vertexBuffer.Draw(indexBuffer, primitiveType);

                                GL.Disable(EnableCap.Lighting);
                                GL.Disable(EnableCap.Light0);
                                GL.PolygonOffset(1.0f, 2);
                                GL.PolygonMode(MaterialFace.Front, PolygonMode.Point);
                                break;
                        }
                        break;

                    case RenderStyle.Wireframe:
                        GL.Disable(EnableCap.DepthTest);
                        GL.Disable(EnableCap.Texture2D);
                        GL.Disable(EnableCap.Lighting);
                        GL.Disable(EnableCap.Light0);
                        GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
                        break;
                }

                vertexBuffer.Draw(indexBuffer, primitiveType);
            }
            else
            {
                GL.Begin(primitiveType);

                foreach (int i in indexBuffer.Data)
                {
                    var v = vertexBuffer.Data[i];

                    GL.TexCoord4(v.UV);
                    GL.Normal3(v.Normal);
                    GL.Vertex3(v.Position);
                }

                GL.End();
            }

            GL.Enable(EnableCap.DepthTest);
            GL.Disable(EnableCap.Blend);

            bool bViewNormals = false;

            if (bViewNormals)
            {
                GL.Disable(EnableCap.Texture2D);
                GL.Begin(PrimitiveType.Lines);

                foreach (int i in indexBuffer.Data)
                {
                    var v = vertexBuffer.Data[i];

                    GL.LineWidth(2f);
                    GL.Color3(Color.White);

                    GL.Vertex3(v.Position);
                    GL.Vertex3(v.Position + (v.Normal * 0.1f));
                }
                GL.End();
                GL.Enable(EnableCap.Texture2D);
            }

            GL.Disable(EnableCap.DepthTest);
        }
    }
}
