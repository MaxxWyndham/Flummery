using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Flummery
{
    
    public struct Vertex
    {
        public Vector3 Position;
        public Vector3 Normal;
        public Vector4 UV;
        public Color4 Colour;

        public static readonly int Stride = Marshal.SizeOf(default(Vertex));
    }

    public sealed class VertexBuffer
    {
        List<Vertex> data = new List<Vertex>();
        int vbo;

        public int Length { get { return (data != null ? data.Count : 0); } }
        public List<Vertex> Data { get { return data; } }

        public int AddVertex(Vertex v)
        {
            data.Add(v);
            return data.Count - 1;
        }

        public void ModifyVertexPosition(int index, Vector3 position)
        {
            var v = data[index];
            v.Position = position;
            data[index] = v;
        }

        public void ModifyVertexNormal(int index, Vector3 normal)
        {
            var v = data[index];
            v.Normal = normal;
            data[index] = v;
        }

        public void Initialise(List<Vertex> data = null)
        {
            if (data != null) { this.data = data; }

            GL.GenBuffers(1, out vbo);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
            GL.BufferData(BufferTarget.ArrayBuffer, new IntPtr(this.data.Count * Vertex.Stride), this.data.ToArray(), BufferUsageHint.DynamicDraw);
        }

        public void Draw(IndexBuffer ibo, PrimitiveType primitiveType)
        {
            ibo.Draw();

            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);

            GL.EnableClientState(ArrayCap.VertexArray);
            GL.EnableClientState(ArrayCap.NormalArray);
            GL.EnableClientState(ArrayCap.TextureCoordArray);
            GL.EnableClientState(ArrayCap.ColorArray);

            GL.VertexPointer(3, VertexPointerType.Float, Vertex.Stride, new IntPtr(0));
            GL.NormalPointer(NormalPointerType.Float, Vertex.Stride, new IntPtr(Vector3.SizeInBytes));
            GL.TexCoordPointer(2, TexCoordPointerType.Float, Vertex.Stride, new IntPtr(2 * Vector3.SizeInBytes));
            GL.ColorPointer(4, ColorPointerType.Float, Vertex.Stride, new IntPtr((2 * Vector3.SizeInBytes) + Vector4.SizeInBytes));

            GL.DrawElements(primitiveType, ibo.Length, DrawElementsType.UnsignedInt, IntPtr.Zero);

            GL.DisableClientState(ArrayCap.VertexArray);
            GL.DisableClientState(ArrayCap.NormalArray);
            GL.DisableClientState(ArrayCap.TextureCoordArray);
            GL.DisableClientState(ArrayCap.ColorArray);

            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }
    }
}
