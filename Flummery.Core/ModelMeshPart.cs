using System;
using System.Collections.Generic;

using ToxicRagers.Helpers;

namespace Flummery.Core
{
    public class ModelMeshPart
    {
        public IndexBuffer IndexBuffer { get; } = new IndexBuffer();

        public VertexBuffer VertexBuffer { get; } = new VertexBuffer();

        public RenderStyle RenderStyle { get; set; } = RenderStyle.Scene;

        public object Key { get; set; }

        public PrimitiveType PrimitiveType { get; set; } = PrimitiveType.Triangles;

        public int VertexCount => VertexBuffer.Length;

        public Material Material { get; set; }

        public Colour Colour { get; set; }

        public ModelMeshPart()
        {
            Colour = Colour.Random();
        }

        public ModelMeshPart Clone()
        {
            ModelMeshPart part = new ModelMeshPart
            {
                Material = Material,
                Colour = Colour
            };

            part.IndexBuffer.Data.AddRange(IndexBuffer.Data);
            part.VertexBuffer.Data.AddRange(VertexBuffer.Data);
            part.Finalise();

            return part;
        }

        public int AddVertex(Vector3 position, Vector3 normal, Vector2 texcoords, bool addIndex = true)
        {
            return AddVertex(position, normal, texcoords, new Vector2(0, 1), Colour.White, addIndex);
        }

        public int AddVertex(Vector3 position, Vector3 normal, Vector2 texcoords, Vector2 texcoords2, Colour colour, bool addIndex = true)
        {
            return AddVertex(position, normal, new Vector4(texcoords.X, texcoords.Y, texcoords2.X, texcoords2.Y), colour, addIndex);
        }

        public int AddVertex(Vector3 position, Vector3 normal, Vector4 texcoords, Colour colour, bool addIndex = true)
        {
            Vertex v = new Vertex
            {
                Position = position,
                Normal = normal,
                UV = texcoords,
                Colour = colour
            };

            int index = VertexBuffer.AddVertex(v);
            if (addIndex) { IndexBuffer.AddIndex(index); }

            return index;
        }

        public void AddFace(int v1, int v2, int v3)
        {
            IndexBuffer.AddIndex(v1);
            IndexBuffer.AddIndex(v2);
            IndexBuffer.AddIndex(v3);
        }

        public void AddFace(Vector3[] positions, Vector3[] normals, Vector2[] texcoords)
        {
            for (int i = 0; i < 3; i++)
            {
                Vertex v = new Vertex
                {
                    Position = positions[i],
                    Normal = normals[i],
                    UV = new Vector4(texcoords[i].X, texcoords[i].Y, 0, 1)
                };

                int index = VertexBuffer.Data.FindIndex(vert =>
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

                if (index == -1) { index = VertexBuffer.AddVertex(v); }

                IndexBuffer.AddIndex(index);
            }
        }

        public void Optimise()
        {
            List<Vertex> vb = new List<Vertex>(VertexBuffer.Data);
            List<int> ib = new List<int>(IndexBuffer.Data);

            VertexBuffer.Data.Clear();
            IndexBuffer.Data.Clear();

            for (int i = 0; i < ib.Count; i++)
            {
                Vertex v = vb[ib[i]];

                int index = VertexBuffer.Data.FindIndex(vert =>
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

                if (index == -1) { index = VertexBuffer.AddVertex(v); }

                IndexBuffer.AddIndex(index);

                if (i % 2500 == 0) { SceneManager.Current.UpdateProgress($"Optimising: {i * 100.0f / ib.Count:0.00}% complete"); }
            }

            IndexBuffer.Initialise();
            VertexBuffer.Initialise();

            SceneManager.Current.UpdateProgress($"Optimisation complete! {vb.Count - VertexBuffer.Data.Count} vert(s) removed.");
        }

        public void Finalise()
        {
            if (SceneManager.Current.CanUseVertexBuffer)
            {
                IndexBuffer.Initialise();
                VertexBuffer.Initialise();
            }
        }

        public void Draw()
        {
            List<int> data = IndexBuffer.Data;

            SceneManager.Current.Renderer.Enable("DepthTest");
            SceneManager.Current.Renderer.Enable("Texture2D");

            int materialID = Material != null && Material.Texture != null ? Material.Texture.ID : 0;

            SceneManager.Current.Renderer.BindTexture("Texture2D", materialID);

            SceneManager.Current.Renderer.DepthFunc("Lequal");
            SceneManager.Current.Renderer.Enable("Lighting");
            SceneManager.Current.Renderer.Enable("Light0");

            switch (RenderStyle)
            {
                case RenderStyle.Scene:
                    SceneManager.Current.RenderMode.Draw(this);
                    break;

                case RenderStyle.Wireframe:
                    SceneManager.Current.Renderer.Disable("DepthTest");
                    SceneManager.Current.Renderer.Disable("Texture2D");
                    SceneManager.Current.Renderer.Disable("Lighting");
                    SceneManager.Current.Renderer.Disable("Light0");
                    SceneManager.Current.Renderer.PolygonMode("FrontAndBack", "Line");
                    SceneManager.Current.Renderer.Color4(Colour);
                    break;
            }

            if (SceneManager.Current.CanUseVertexBuffer)
            {
                VertexBuffer.Draw(IndexBuffer, PrimitiveType);
            }
            else
            {
                SceneManager.Current.Renderer.Begin(PrimitiveType);

                foreach (int i in IndexBuffer.Data)
                {
                    Vertex v = VertexBuffer.Data[i];

                    SceneManager.Current.Renderer.TexCoord4(v.UV);
                    SceneManager.Current.Renderer.Normal3(v.Normal);
                    SceneManager.Current.Renderer.Vertex3(v.Position);
                }

                SceneManager.Current.Renderer.End();
            }

            SceneManager.Current.Renderer.Enable("DepthTest");
            SceneManager.Current.Renderer.Disable("Blend");

            bool viewNormals = false;

            if (viewNormals)
            {
                SceneManager.Current.Renderer.Disable("Texture2D");
                SceneManager.Current.Renderer.Begin(PrimitiveType.Lines);

                foreach (int i in IndexBuffer.Data)
                {
                    Vertex v = VertexBuffer.Data[i];

                    SceneManager.Current.Renderer.LineWidth(2f);
                    SceneManager.Current.Renderer.Color3(System.Drawing.Color.White);

                    SceneManager.Current.Renderer.Vertex3(v.Position);
                    SceneManager.Current.Renderer.Vertex3(v.Position + (v.Normal * 0.1f));
                }

                SceneManager.Current.Renderer.End();
                SceneManager.Current.Renderer.Enable("Texture2D");
            }

            SceneManager.Current.Renderer.Disable("DepthTest");
        }
    }
}
