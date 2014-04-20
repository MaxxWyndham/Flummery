using System;
using System.Collections.Generic;

namespace Flummery
{
    public class ModelMesh
    {
        BoundingSphere BoundingSphere;
        List<ModelMeshPart> MeshParts;
        string Name;
        ModelBone Parent;
        object Tag;

        public void Draw() { }
    }
}
