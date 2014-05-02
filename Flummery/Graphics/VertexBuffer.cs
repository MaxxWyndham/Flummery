using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Flummery
{
    public struct Vertex
    {
        public Vector3 Position;
        public Vector3 Normal;
        public Vector2 UV;

        public static readonly int Stride = Marshal.SizeOf(default(Vertex));
    }

    public sealed class VertexBuffer
    {
        List<Vertex> data = new List<Vertex>();
        int vbo;

        public int Length { get { return (data != null ? data.Count : 0); } }
        public List<Vertex> Data { get { return data; } }

        public void AddVertex(Vertex vert)
        {
            data.Add(vert);
        }

        public void Initialise(List<Vertex> data = null)
        {
            if (data != null) { this.data = data; }

            GL.GenBuffers(1, out vbo);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
            GL.BufferData(BufferTarget.ArrayBuffer, new IntPtr(this.data.Count * Vertex.Stride), this.data.ToArray(), BufferUsageHint.DynamicDraw);
        }

        public void Draw(int count)
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);

            GL.EnableClientState(ArrayCap.VertexArray);
            GL.EnableClientState(ArrayCap.NormalArray);
            GL.EnableClientState(ArrayCap.TextureCoordArray);

            GL.VertexPointer(3, VertexPointerType.Float, Vertex.Stride, new IntPtr(0));
            GL.NormalPointer(NormalPointerType.Float, Vertex.Stride, new IntPtr(Vector3.SizeInBytes));
            GL.TexCoordPointer(2, TexCoordPointerType.Float, Vertex.Stride, new IntPtr(2 * Vector3.SizeInBytes));

            GL.DrawElements(PrimitiveType.Triangles, count, DrawElementsType.UnsignedInt, IntPtr.Zero);
        }
    }
}
