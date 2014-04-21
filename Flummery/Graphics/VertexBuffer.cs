using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Flummery
{
    struct Vertex
    {
        public Vector3 Position;
        public Vector3 Normal;
        public Vector2 UV;

        //public static readonly int Stride = Marshal.SizeOf(default(Vertex));
    }

    public sealed class VertexBuffer
    {
        List<Vertex> data = new List<Vertex>();

        //string Name = "";
        //int vbo;
        //int length;
        //PrimitiveType renderMode = PrimitiveType.TriangleStrip;
        //Vertex[] data = null;

        public int Length { get { return (data != null ? data.Count : 0); } }

        //public VertexBuffer() { Name = ""; }
        //public VertexBuffer(string name) { Name = name; }

        //public void SetData(Vertex[] data, PrimitiveType renderMode = PrimitiveType.TriangleStrip)
        //{
        //    if (data == null) { throw new ArgumentNullException("data"); }

        //    length = data.Length;
        //    this.renderMode = renderMode;

        //    if (Flummery.frmMain.bVertexBuffer)
        //    {
        //        GL.GenBuffers(1, out vbo);

        //        GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
        //        GL.BufferData(BufferTarget.ArrayBuffer, new IntPtr(data.Length * Vertex.Stride), data, BufferUsageHint.StaticDraw);
        //    }
        //    else
        //    {
        //        this.data = new Vertex[data.Length];
        //        Array.Copy(data, this.data, data.Length);
        //    }
        //}

        //public void Render(int TextureID = 0)
        //{
        //    if (Flummery.frmMain.bVertexBuffer)
        //    {
        //        GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);

        //        GL.EnableClientState(ArrayCap.VertexArray);
        //        GL.EnableClientState(ArrayCap.NormalArray);
        //        GL.EnableClientState(ArrayCap.TextureCoordArray);

        //        GL.VertexPointer(3, VertexPointerType.Float, Vertex.Stride, new IntPtr(0));
        //        GL.NormalPointer(NormalPointerType.Float, Vertex.Stride, new IntPtr(Vector3.SizeInBytes));
        //        GL.TexCoordPointer(2, TexCoordPointerType.Float, Vertex.Stride, new IntPtr(2 * Vector3.SizeInBytes));

        //        GL.DrawArrays(renderMode, 0, length);
        //    }
        //    else
        //    {
        //        GL.Begin(PrimitiveType.TriangleStrip);
        //        for (int i = 0; i < data.Length; i++)
        //        {
        //            GL.Vertex3(data[i].Position);
        //            GL.Normal3(data[i].Normal);
        //            GL.TexCoord2(data[i].UV);
        //        }
        //        GL.End();
        //    }
        //}
    }
}
