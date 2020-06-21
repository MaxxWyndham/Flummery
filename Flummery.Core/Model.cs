using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flummery.Core
{
    public class Model : Asset
    {
        public ModelBoneCollection Bones { get; set; } = new ModelBoneCollection();

        public List<ModelMesh> Meshes { get; } = new List<ModelMesh>();

        public void RemoveBone(int BoneIndex)
        {
            ModelBone[] children = new ModelBone[Bones[BoneIndex].Children.Count];
            Bones[BoneIndex].Children.CopyTo(children);
            for (int i = children.Length - 1; i > -1; i--) { RemoveBone(children[i].Index); }

            for (int i = BoneIndex + 1; i < Bones.Count; i++) { Bones[i].Index--; }
            if (Bones[BoneIndex].Parent != null) { Bones[BoneIndex].Parent.Children.Remove(Bones[BoneIndex]); }
            Meshes.Remove(Bones[BoneIndex].Mesh);

            Bones.RemoveAt(BoneIndex);
        }
    }
}
