using System;
using System.Collections.Generic;
using OpenTK;

namespace Flummery
{
    public class Model : Asset
    {
        List<ModelBone> bones;
        List<ModelMesh> meshes;
        object tag;

        public List<ModelBone> Bones { get { return bones; } }
        public List<ModelMesh> Meshes { get { return meshes; } }
        public ModelBone Root { get { return bones[0]; } }

        public object Tag
        {
            get { return tag; }
            set { tag = value; }
        }

        public Model()
        {
            bones = new List<ModelBone>();
            meshes = new List<ModelMesh>();

            bones.Add(new ModelBone() { Name = "ROOT" });
        }

        public void CopyAbsoluteBoneTransformsTo(Matrix4[] destinationBoneTransforms) 
        {
            for (int i = 0; i < bones.Count; i++)
            {
                ModelBone bone = bones[i];
                if (bone.Parent == null)
                {
                    destinationBoneTransforms[i] = bone.Transform;
                }
                else
                {
                    destinationBoneTransforms[i] = bone.Transform * destinationBoneTransforms[bone.Parent.Index];
                }
            }
        }

        public void CopyBoneTransformsFrom(Matrix4[] sourceBoneTransforms) { }
        public void CopyBoneTransformsTo(Matrix4[] destinationBoneTransforms) { }

        public int AddMesh(ModelMesh mesh, int ParentBoneIndex = 0)
        {
            ModelBone b = new ModelBone();
            b.Parent = bones[ParentBoneIndex];
            bones[ParentBoneIndex].Children.Add(b);
            bones.Add(b);
            b.Index = bones.Count - 1;

            if (mesh != null)
            {
                mesh.Parent = bones[ParentBoneIndex];
                meshes.Add(mesh);
            }
            else
            {
                // Just a bone
            }

            return b.Index;
        }

        public void SetTransform(Matrix4 transform, int BoneIndex = 0)
        {
            bones[BoneIndex].Transform = transform;
        }

        public void SetName(string name, int BoneIndex = 0)
        {
            bones[BoneIndex].Name = name;
        }

        public void Draw(Matrix4 world, Matrix4 view, Matrix4 projection) 
        {
            foreach (var mesh in meshes)
            {
                mesh.Draw();
            }
        }
    }
}
