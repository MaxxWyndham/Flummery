using System.Collections.Generic;

namespace Flummery.Core
{
    public class ModelBoneCollection : List<ModelBone>
    {
        public ModelBoneCollection() { }

        public ModelBoneCollection(ModelBoneCollection bones)
        {
            foreach (ModelBone bone in bones)
            {
                Add(bone.Clone());
            }
        }

        public void ReIndex()
        {
            for (int i = 0; i < Count; i++) { this[i].Index = i; }
        }
    }
}
