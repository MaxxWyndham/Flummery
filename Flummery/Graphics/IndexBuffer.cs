using System;
using System.Collections.Generic;
using OpenTK;

namespace Flummery
{
    public sealed class IndexBuffer
    {
        List<int> indicies;

        public int[] Data { get { return indicies.ToArray(); } }
        public int Length { get { return indicies.Count; } }

        public IndexBuffer()
        {
            indicies = new List<int>();
        }

        public void AddTriangle(int[] face)
        {
            indicies.Add(face[0]);
            indicies.Add(face[1]);
            indicies.Add(face[2]);
        }
    }
}
