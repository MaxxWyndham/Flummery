using System;
using System.Collections.Generic;
using ToxicRagers.Helpers;

namespace Flummery
{
    public class Model
    {
        List<ModelBone> Bones;
        List<ModelMesh> Meshes;
        ModelBone Root;
        object Tag;

        public void CopyAbsoluteBoneTransformsTo(Matrix3D[] destinationBoneTransforms) { }
        public void CopyBoneTransformsFrom(Matrix3D[] sourceBoneTransforms) { }
        public void CopyBoneTransformsTo(Matrix3D[] destinationBoneTransforms) { }
        public void Draw(Matrix3D world, Matrix3D view, Matrix3D projection) { }
    }
}
