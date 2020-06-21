using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flummery.Core
{
    public class IndexBuffer
    {
        public List<int> Data { get; } = new List<int>();

        public void Initialise()
        {
            //GL.GenBuffers(1, out ibo);

            //GL.BindBuffer(BufferTarget.ElementArrayBuffer, ibo);
            //GL.BufferData(BufferTarget.ElementArrayBuffer, (IntPtr)(indicies.Count * sizeof(int)), indicies.ToArray(), BufferUsageHint.StaticDraw);
        }

        public void SwapIndices(int a, int b)
        {
            int t = Data[a];
            Data[a] = Data[b];
            Data[b] = t;
        }
    }
}
