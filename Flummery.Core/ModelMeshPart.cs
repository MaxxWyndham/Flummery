using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flummery.Core
{
    public class ModelMeshPart
    {
        public VertexBuffer VertexBuffer { get; } = new VertexBuffer();

        public IndexBuffer IndexBuffer { get; } = new IndexBuffer();

        public int VertexCount => VertexBuffer.Length;
    }
}
