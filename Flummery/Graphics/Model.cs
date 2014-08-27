using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Flummery
{
    public class Model : Asset
    {
        ModelBoneCollection bones;
        List<ModelMesh> meshes;

        public ModelBoneCollection Bones { get { return bones; } }
        public List<ModelMesh> Meshes { get { return meshes; } }
        public ModelBone Root { get { return bones[0]; } }

        public Model()
        {
            bones = new ModelBoneCollection();
            meshes = new List<ModelMesh>();
        }

        public override Asset Clone()
        {
            var m = new Model();

            //m.bones = new ModelBoneCollection(this.bones);
            m.meshes = this.meshes.ConvertAll(mesh => new ModelMesh(mesh));
            m.tag = this.tag;

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
            bool bAddBone = true;
            ModelBone b = new ModelBone();
            b.Index = -1;

            if (bones.Count > 0)
            {
                b.Parent = bones[ParentBoneIndex];
                bones[ParentBoneIndex].Children.Add(b);

                int childBoneCount = countChildrenOf(ParentBoneIndex);
                if (ParentBoneIndex + childBoneCount < bones.Count)
                {
                    int index = ParentBoneIndex + childBoneCount;

                    bAddBone = false;
                    bones.Insert(index, b);
                    b.Index = index;
                }
            }

            if (bAddBone)
            {
                bones.Add(b);
                b.Index = bones.Count - 1;
            }
            else
            {
                bones.ReIndex();
            }

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

        protected int countChildrenOf(int parentIndex, int childCount = 0)
        {
            foreach (var child in bones[parentIndex].Children)
            {
                childCount++;
                if (child.Index > -1) { childCount = countChildrenOf(child.Index, childCount); }
            }

            return childCount;
        }

        public void ImportBone(ModelBone bone, int parentBoneIndex)
        {
            var cloneBone = bone.Clone();
            var boneList = cloneBone.AllChildren();

            var parent = bones[parentBoneIndex];

            for (int i = 0; i < boneList.Count; i++)
            {
                bones.Insert(parentBoneIndex + i + 1, boneList[i]);
                if (boneList[i].Tag != null)
                { 
                    var mesh = boneList[i].Tag as ModelMesh;
                    mesh.Parent = boneList[i];
                    meshes.Add(mesh); 
                }

                if (i == 0)
                {
                    boneList[i].Parent = parent;
                    parent.Children.Add(boneList[i]);
                }
            }

            bones.ReIndex();
        }

        public bool MoveBone(int BoneIndex, int NewParentBoneIndex)
        {
            int newBoneIndex;

            if (BoneIndex == NewParentBoneIndex) { return false; }

            bones[BoneIndex].Parent.Children.Remove(bones[BoneIndex]);
            bones[BoneIndex].Parent = bones[NewParentBoneIndex];
            bones[NewParentBoneIndex].Children.Add(bones[BoneIndex]);

            var bone = bones[BoneIndex];
            bones.RemoveAt(BoneIndex);
            newBoneIndex = NewParentBoneIndex + (BoneIndex < NewParentBoneIndex ? 0 : 1);
            bones.Insert(newBoneIndex, bone);

            ModelBone[] children = new ModelBone[bones[newBoneIndex].Children.Count];
            bones[newBoneIndex].Children.CopyTo(children);

            for (int i = 0; i < children.Length; i++) { MoveBone(children[i].Index, newBoneIndex); }

            bones.ReIndex();

            return true;
        }

        public void RemoveBone(int BoneIndex)
        {
            Console.WriteLine("Going to remove bone {0}", BoneIndex);
            ModelBone[] children = new ModelBone[bones[BoneIndex].Children.Count];
            bones[BoneIndex].Children.CopyTo(children);
            for (int i = children.Length - 1; i > -1; i--) { RemoveBone(children[i].Index); }

            for (int i = BoneIndex + 1; i < bones.Count; i++) { bones[i].Index--; }
            if (bones[BoneIndex].Parent != null) { bones[BoneIndex].Parent.Children.Remove(bones[BoneIndex]); }
            meshes.Remove((ModelMesh)bones[BoneIndex].Tag);

            bones.RemoveAt(BoneIndex);
            Console.WriteLine("Removing bone at {0}, bones.Count = {1}", BoneIndex, bones.Count);
        }

        public ModelMesh FindMesh(string name)
        {
            foreach (var mesh in meshes) { if (mesh.Name == name) { return mesh; } }
            return null;
        }

        public ModelMesh FindMesh(object tag)
        {
            foreach (var mesh in meshes) { if (mesh.Tag.Equals(tag)) { return mesh; } }
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

        public List<Material> GetMaterials()
        {
            var l = new List<Material>();
            var index = new List<long>();

            foreach (var mesh in meshes)
            {
                foreach (var part in mesh.MeshParts)
                {
                    if (part.Material != null && !index.Contains(part.Material.Key))
                    {
                        l.Add(part.Material);
                        index.Add(part.Material.Key);
                    }
                }
            }

            return l;
        }

        public void Santise()
        {
            for (int i = meshes.Count - 1; i > -1; i--)
            {
                if (meshes[i].MeshParts.Count == 0)
                {
                    ClearMesh(meshes[i].Parent.Index);
                }
            }
        }

        public void Draw() 
        {
            Matrix4[] transforms = new Matrix4[bones.Count];
            CopyAbsoluteBoneTransformsTo(transforms);
            Matrix4 m = SceneManager.Current.Transform;

            foreach (var mesh in meshes)
            {
                GL.PushMatrix();

                GL.MultMatrix(ref m);
                GL.MultMatrix(ref transforms[mesh.Parent.Index]);

                mesh.Draw();

                GL.PopMatrix();
            }
        }
    }
}
