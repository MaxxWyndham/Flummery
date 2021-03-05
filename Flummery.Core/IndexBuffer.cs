using System;
using System.Collections.Generic;

namespace Flummery.Core
{
    public sealed class IndexBuffer
    {
        private int ibo;

        public List<int> Data { get; } = new List<int>();

        public int Length => Data.Count;

        public void Initialise()
        {
            SceneManager.Current.Renderer.GenBuffers(1, out ibo);

            SceneManager.Current.Renderer.BindBuffer("ElementArrayBuffer", ibo);
            SceneManager.Current.Renderer.BufferData("ElementArrayBuffer", (IntPtr)(Data.Count * sizeof(int)), Data.ToArray(), "StaticDraw");
        }

        public void Draw()
        {
            SceneManager.Current.Renderer.BindBuffer("ElementArrayBuffer", ibo);
        }

        public void AddIndex(int index)
        {
            Data.Add(index);
        }

        public void SwapIndices(int a, int b)
        {
            int t = Data[a];
            Data[a] = Data[b];
            Data[b] = t;
        }

        //public void AddTriangle(int[] face)
        //{
        //    indicies.Add(face[0]);
        //    indicies.Add(face[1]);
        //    indicies.Add(face[2]);
        //}
    }
}
