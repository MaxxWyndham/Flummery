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

        //string Name = "";
        int vbo;
        //int length;
        //PrimitiveType renderMode = PrimitiveType.TriangleStrip;
        //Vertex[] data = null;

        public int Length { get { return (data != null ? data.Count : 0); } }

        public void Initialise(List<Vertex> data)
        {
        //    if (data == null) { throw new ArgumentNullException("data"); }

        //    length = data.Length;
        //    this.renderMode = renderMode;

        //    if (Flummery.frmMain.bVertexBuffer)
        //    {
            this.data = data;
            GL.GenBuffers(1, out vbo);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
            GL.BufferData(BufferTarget.ArrayBuffer, new IntPtr(data.Count * Vertex.Stride), data.ToArray(), BufferUsageHint.StaticDraw);
        //    }
        //    else
        //    {
        //        this.data = new Vertex[data.Length];
        //        Array.Copy(data, this.data, data.Length);
        //    }
        }

        public void Draw(int TextureID = 0)
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);

            GL.EnableClientState(ArrayCap.VertexArray);
            GL.EnableClientState(ArrayCap.NormalArray);
            GL.EnableClientState(ArrayCap.TextureCoordArray);

            GL.VertexPointer(3, VertexPointerType.Float, Vertex.Stride, new IntPtr(0));
            GL.NormalPointer(NormalPointerType.Float, Vertex.Stride, new IntPtr(Vector3.SizeInBytes));
            GL.TexCoordPointer(2, TexCoordPointerType.Float, Vertex.Stride, new IntPtr(2 * Vector3.SizeInBytes));

            GL.DrawArrays(PrimitiveType.Triangles, 0, Length);
        }
    }
}
