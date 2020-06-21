using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ToxicRagers.Helpers;

namespace Flummery.Core
{
    public class Vertex
    {
        public Vector3 Position { get; set; }
    }

    public class VertexBuffer
    {
        public List<Vertex> Data { get; private set; } = new List<Vertex>();

        public int Length => Data.Count;

        public void ModifyVertexPosition(int index, Vector3 position)
        {
            Vertex v = Data[index];
            v.Position = position;
            Data[index] = v;
        }

        public void Initialise(List<Vertex> data = null)
        {
            if (data != null) { Data = data; }

            //GL.GenBuffers(1, out vbo);

            //GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
            //GL.BufferData(BufferTarget.ArrayBuffer, new IntPtr(this.data.Count * Vertex.Stride), this.data.ToArray(), BufferUsageHint.DynamicDraw);
        }
    }
}
