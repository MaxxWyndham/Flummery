using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics.OpenGL;

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
        CoordinateSystem coords = CoordinateSystem.LeftHanded;

        public List<ModelBone> Bones { get { return bones; } }
        public List<ModelMesh> Meshes { get { return meshes; } }
        public ModelBone Root { get { return bones[0]; } }

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

        public override Asset Clone()
        {
            var m = new Model();

            m.bones = new List<ModelBone>(this.bones);
            m.meshes = this.meshes.ConvertAll(mesh => new ModelMesh(mesh));
            m.tag = this.tag;
            m.coords = this.coords;

            return m;
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

        public void RemoveBone(int BoneIndex)
        {
            for (int i = BoneIndex + 1; i < bones.Count; i++) { bones[i].Index--; }
            bones[BoneIndex].Parent.Children.Remove(bones[BoneIndex]);
            meshes.Remove((ModelMesh)bones[BoneIndex].Tag);
            bones.RemoveAt(BoneIndex);
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

        public void ClearMesh(int BoneIndex)
        {
            meshes.Remove((ModelMesh)bones[BoneIndex].Tag);
            bones[BoneIndex].Tag = null;
        }

        public void Draw() 
        {
            Matrix4[] transforms = new Matrix4[bones.Count];
            CopyAbsoluteBoneTransformsTo(transforms);

            foreach (var mesh in meshes)
            {
                GL.PushMatrix();

                GL.MultMatrix(ref transforms[mesh.Parent.Index]);

                mesh.Draw();

                GL.PopMatrix();
            }
        }
    }
}
