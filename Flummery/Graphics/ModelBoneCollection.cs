using System;
using System.Collections.Generic;

namespace Flummery
{
    public class ModelBoneCollection : List<ModelBone>
    {
        public void ReIndex()
        {
            for (int i = 0; i < this.Count; i++) { this[i].Index = i; }
        }
    }
}
