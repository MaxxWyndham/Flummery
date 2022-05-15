using System;
using System.Collections.Generic;

using ToxicRagers.Helpers;

namespace Flummery.Core
{
    public sealed class VertexBuffer
    {
        private int vbo;

        public List<Vertex> Data { get; private set; } = new List<Vertex>();

        public int Length => Data.Count;

        public int AddVertex(Vertex v)
        {
            Data.Add(v);

            return Data.Count - 1;
        }

        public void ModifyVertexPosition(int index, Vector3 position)
        {
            Vertex v = Data[index];
            v.Position = position;
            Data[index] = v;
        }

        public void ModifyVertexNormal(int index, Vector3 normal)
        {
            Vertex v = Data[index];
            v.Normal = normal;
            Data[index] = v;
        }

        public void ModifyVertexUVs(int index, Vector4 uv)
        {
            Vertex v = Data[index];
            v.UV = uv;
            Data[index] = v;
        }

        public void ModifyVertexColour(int index, Colour colour)
        {
            Vertex v = Data[index];
            v.Colour = colour;
            Data[index] = v;
        }

        public void Initialise(List<Vertex> data = null)
        {
            if (data != null) { Data = data; }

            SceneManager.Current.Renderer.GenBuffers(1, out vbo);

            SceneManager.Current.Renderer.BindBuffer("ArrayBuffer", vbo);
            SceneManager.Current.Renderer.BufferData("ArrayBuffer", new IntPtr(Data.Count * 56), Data.ToFloatArray(), "DynamicDraw");
        }

        public void Draw(IndexBuffer ibo, PrimitiveType primitiveType)
        {
            ibo.Draw();

            //bool bWireframe = (SceneManager.Current.RenderMode == SceneManager.RenderMeshMode.Wireframe);
            bool bWireframe = true;
            int vec3Size = 12;
            int vec4Size = 16;

            SceneManager.Current.Renderer.BindBuffer("ArrayBuffer", vbo);

            SceneManager.Current.Renderer.EnableClientState("VertexArray");
            SceneManager.Current.Renderer.EnableClientState("NormalArray");
            SceneManager.Current.Renderer.EnableClientState("TextureCoordArray");
            if (!bWireframe) { SceneManager.Current.Renderer.EnableClientState("ColorArray"); }

            SceneManager.Current.Renderer.VertexPointer(3, "Float", 56, new IntPtr(0));
            SceneManager.Current.Renderer.NormalPointer("Float", 56, new IntPtr(vec3Size));
            SceneManager.Current.Renderer.TexCoordPointer(2, "Float", 56, new IntPtr(2 * vec3Size));
            if (!bWireframe) { SceneManager.Current.Renderer.ColorPointer(4, "Float", 56, new IntPtr((2 * vec3Size) + vec4Size)); }

            SceneManager.Current.Renderer.DrawElements(primitiveType, ibo.Length, "UnsignedInt", IntPtr.Zero);

            SceneManager.Current.Renderer.DisableClientState("VertexArray");
            SceneManager.Current.Renderer.DisableClientState("NormalArray");
            SceneManager.Current.Renderer.DisableClientState("TextureCoordArray");
            if (!bWireframe) { SceneManager.Current.Renderer.DisableClientState("ColorArray"); }

            SceneManager.Current.Renderer.BindBuffer("ArrayBuffer", 0);
        }
    }

    public static class VertexBufferHelpers
    {
        public static float[] ToFloatArray(this List<Vertex> vertices)
        {
            int stride = 14;
            int offset = 0;
            float[] floats = new float[vertices.Count * stride];

            foreach (Vertex v in vertices)
            {
                floats[offset + 0] = v.Position.X;
                floats[offset + 1] = v.Position.Y;
                floats[offset + 2] = v.Position.Z;

                floats[offset + 3] = v.Normal.X;
                floats[offset + 4] = v.Normal.Y;
                floats[offset + 5] = v.Normal.Z;

                floats[offset + 6] = v.UV.X;
                floats[offset + 7] = v.UV.Y;
                floats[offset + 8] = v.UV.Z;
                floats[offset + 9] = v.UV.W;

                floats[offset + 10] = v.Colour.A;
                floats[offset + 11] = v.Colour.R;
                floats[offset + 12] = v.Colour.G;
                floats[offset + 13] = v.Colour.B;

                offset += stride;
            }

            return floats;
        }
    }
}
