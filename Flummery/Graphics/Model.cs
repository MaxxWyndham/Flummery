using System;
using System.Collections.Generic;
using OpenTK;

namespace Flummery
{
    public class Model : Asset
    {
        List<ModelBone> bones;
        List<ModelMesh> meshes;
        ModelBone Root;
        object tag;

        public List<ModelBone> Bones { get { return bones; } }
        public List<ModelMesh> Meshes { get { return meshes; } }

        public object Tag
        {
            get { return tag; }
            set { tag = value; }
        }

        public Model()
        {
            bones = new List<ModelBone>();
            meshes = new List<ModelMesh>();
        }

        public void CopyAbsoluteBoneTransformsTo(Matrix3d[] destinationBoneTransforms) { }
        public void CopyBoneTransformsFrom(Matrix3d[] sourceBoneTransforms) { }
        public void CopyBoneTransformsTo(Matrix3d[] destinationBoneTransforms) { }

        public void AddMesh(ModelMesh mesh)
        {
            meshes.Add(mesh);
        }

        public void Draw(Matrix3d world, Matrix3d view, Matrix3d projection) 
        {
            foreach (var mesh in meshes)
            {
                mesh.Draw();
            }
        }
    }
}
