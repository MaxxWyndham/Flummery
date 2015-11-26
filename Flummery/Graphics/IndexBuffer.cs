using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Flummery
{
    public sealed class IndexBuffer
    {
        List<int> indicies;
        int ibo;
        bool Initialised = false;

        public List<int> Data { get { return indicies; } }
        public int Length { get { return indicies.Count; } }

        public IndexBuffer()
        {
            indicies = new List<int>();
        }

        public void Initialise()
        {
            GL.GenBuffers(1, out ibo);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ibo);
            GL.BufferData(BufferTarget.ElementArrayBuffer, (IntPtr)(indicies.Count * sizeof(int)), indicies.ToArray(), BufferUsageHint.StaticDraw);
        }

        public void Draw()
        {
            if (ibo == 0 && !Initialised)
            {
                Initialise();
                Initialised = true;
            }
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ibo);

        }

        public void AddIndex(int index)
        {
            indicies.Add(index);
        }

        public void SwapIndices(int a, int b)
        {
            int t = indicies[a];
            indicies[a] = indicies[b];
            indicies[b] = t;
        }

        public void AddTriangle(int[] face)
        {
            indicies.Add(face[0]);
            indicies.Add(face[1]);
            indicies.Add(face[2]);
        }
    }
}
