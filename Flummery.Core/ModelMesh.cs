using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flummery.Core
{
    public class ModelMesh
    {
        public string Name { get; set; }

        public List<ModelMeshPart> MeshParts { get; } = new List<ModelMeshPart>();
    }
}
