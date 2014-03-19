using System;
using System.Drawing;
using System.Runtime.InteropServices;
using OpenTK.Graphics.OpenGL;

namespace carmaModelViewer
{
    struct Vertex
    {
        public OpenTK.Vector3 Position;
        public OpenTK.Vector3 Normal;
        public OpenTK.Vector2 UV;

        public static readonly int Stride = Marshal.SizeOf(default(Vertex));
    }

    sealed class VertexBuffer
    {
        string Name = "";
        int vbo;
        int length;

        public VertexBuffer() { Name = ""; }
        public VertexBuffer(string name) { Name = name; }

        public void SetData(Vertex[] data)
        {
            if (data == null)
                throw new ArgumentNullException("data");

            length = data.Length;

            GL.GenBuffers(1, out vbo);

            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
            GL.BufferData(BufferTarget.ArrayBuffer, new IntPtr(data.Length * Vertex.Stride), data, BufferUsageHint.StaticDraw);
        }

        public void Render()
        {
            GL.EnableClientState(ArrayCap.VertexArray);
            GL.EnableClientState(ArrayCap.NormalArray);
            GL.EnableClientState(ArrayCap.TextureCoordArray);

            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);

            GL.VertexPointer(3, VertexPointerType.Float, Vertex.Stride, new IntPtr(0));
            GL.NormalPointer(NormalPointerType.Float, Vertex.Stride, new IntPtr(OpenTK.Vector3.SizeInBytes));
            GL.TexCoordPointer(2, TexCoordPointerType.Float, Vertex.Stride, new IntPtr(2 * OpenTK.Vector3.SizeInBytes));

            GL.Enable(EnableCap.DepthTest);

            GL.DepthFunc(DepthFunction.Lequal);
            GL.Color3(Color.White);
            GL.Enable(EnableCap.Lighting);
            GL.DrawArrays(BeginMode.Triangles, 0, length);

            //GL.Disable(EnableCap.DepthTest);

            GL.DepthFunc(DepthFunction.Lequal);
            //GL.BlendFunc(BlendingFactorSrc.DstColor, BlendingFactorDest.Zero);
            GL.Disable(EnableCap.Lighting);
            GL.Color3(Color.Red);
            GL.DrawArrays(BeginMode.Points, 0, length);
        }
    }
}
