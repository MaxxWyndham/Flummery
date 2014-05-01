using System;
using System.Collections.Generic;
using OpenTK;

namespace Flummery
{
    public class Model : Asset
    {
        public enum CoordinateSystem
        {
            LeftHanded,
            RightHanded
        }

        List<ModelBone> bones;
        List<ModelMesh> meshes;
        object tag;
        CoordinateSystem coords = CoordinateSystem.LeftHanded;

        public List<ModelBone> Bones { get { return bones; } }
        public List<ModelMesh> Meshes { get { return meshes; } }
        public ModelBone Root { get { return bones[0]; } }

        public object Tag
        {
            get { return tag; }
            set { tag = value; }
        }

        public CoordinateSystem Handedness
        {
            get { return coords; }
            set { coords = value; }
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
                b.Tag = mesh;
                mesh.Parent = bones[b.Index];
                meshes.Add(mesh);
            }
            else
            {
                // Just a bone
            }

            return b.Index;
        }

        public ModelMesh FindMesh(string name)
        {
            foreach (var mesh in meshes)
            {
                if (mesh.Name == name) { return mesh; }
            }

            return null;
        }

        public void SetTransform(Matrix4 transform, int BoneIndex = 0)
        {
            bones[BoneIndex].Transform = transform;
        }

        public void SetName(string name, int BoneIndex = 0)
        {
            bones[BoneIndex].Name = name;
        }

        public void SetMesh(ModelMesh mesh, int BoneIndex = 0)
        {
            bones[BoneIndex].Tag = mesh;
            mesh.Parent = bones[BoneIndex];
            meshes.Add(mesh);
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
