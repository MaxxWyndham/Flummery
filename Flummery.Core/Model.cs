using System;
using System.Collections.Generic;
using ToxicRagers.Helpers;

namespace Flummery.Core
{
    public enum RenderStyle
    {
        Scene,      // SceneManager sets the rules
        Wireframe   // Bright green, wireframe, ignores depth
    }

    public class Model : Asset
    {
        public ModelBoneCollection Bones { get; } = new ModelBoneCollection();

        public List<ModelMesh> Meshes { get; } = new List<ModelMesh>();

        public ModelBone Root => Bones[0];

        //public override Asset Clone()
        //{
        //    Model m = new Model
        //    {
        //        Bones = new ModelBoneCollection(bones),
        //        Meshes = Meshes.ConvertAll(mesh => new ModelMesh(mesh))
        //    };

        //    foreach (KeyValuePair<string, object> kvp in supportingDocuments)
        //    {
        //        m.SupportingDocuments[kvp.Key] = kvp.Value;
        //    }

        //    return m;
        //}

        public void SetRenderStyle(RenderStyle style)
        {
            foreach (ModelMesh mesh in Meshes)
            {
                foreach (ModelMeshPart part in mesh.MeshParts)
                {
                    part.RenderStyle = style;
                }
            }
        }

        public void CopyAbsoluteBoneTransformsTo(Matrix4D[] destinationBoneTransforms)
        {
            for (int i = 0; i < Bones.Count; i++)
            {
                ModelBone bone = Bones[i];

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

        //public void CopyBoneTransformsFrom(Matrix4[] sourceBoneTransforms) { }
        //public void CopyBoneTransformsTo(Matrix4[] destinationBoneTransforms) { }

        public int AddMesh(ModelMesh mesh, int parentBoneIndex = 0)
        {
            bool addBone = true;
            ModelBone b = new ModelBone
            {
                Index = -1
            };

            if (Bones.Count > 0)
            {
                b.Parent = Bones[parentBoneIndex];
                Bones[parentBoneIndex].Children.Add(b);

                int childBoneCount = CountChildrenOf(parentBoneIndex);
                if (parentBoneIndex + childBoneCount < Bones.Count)
                {
                    int index = parentBoneIndex + childBoneCount;

                    addBone = false;
                    Bones.Insert(index, b);
                    b.Index = index;
                }
            }

            if (addBone)
            {
                Bones.Add(b);
                b.Index = Bones.Count - 1;
            }
            else
            {
                Bones.ReIndex();
            }

            if (mesh != null)
            {
                b.Type = BoneType.Mesh;
                b.Attachment = mesh;
                mesh.Parent = Bones[b.Index];
                Meshes.Add(mesh);
            }
            else
            {
                // Just a bone
            }

            return b.Index;
        }

        protected int CountChildrenOf(int parentIndex, int childCount = 0)
        {
            foreach (ModelBone child in Bones[parentIndex].Children)
            {
                childCount++;
                if (child.Index > -1) { childCount = CountChildrenOf(child.Index, childCount); }
            }

            return childCount;
        }

        public void ImportBone(ModelBone bone, int parentBoneIndex)
        {
            ModelBone cloneBone = bone.Clone();
            ModelBoneCollection boneList = cloneBone.AllChildren();

            ModelBone parent = Bones[parentBoneIndex];

            for (int i = 0; i < boneList.Count; i++)
            {
                Bones.Insert(parentBoneIndex + i + 1, boneList[i]);

                if (boneList[i].Mesh != null)
                {
                    ModelMesh mesh = boneList[i].Mesh;
                    mesh.Parent = boneList[i];
                    Meshes.Add(mesh);
                }

                if (i == 0)
                {
                    boneList[i].Parent = parent;
                    parent.Children.Add(boneList[i]);
                }
            }

            Bones.ReIndex();
        }

        public bool MoveBone(int boneIndex, int newParentBoneIndex)
        {
            int newBoneIndex;

            if (boneIndex == newParentBoneIndex) { return false; }

            Bones[boneIndex].Parent.Children.Remove(Bones[boneIndex]);
            Bones[boneIndex].Parent = Bones[newParentBoneIndex];
            Bones[newParentBoneIndex].Children.Add(Bones[boneIndex]);

            ModelBone bone = Bones[boneIndex];
            Bones.RemoveAt(boneIndex);
            newBoneIndex = newParentBoneIndex + (boneIndex < newParentBoneIndex ? 0 : 1);
            Bones.Insert(newBoneIndex, bone);

            ModelBone[] children = new ModelBone[Bones[newBoneIndex].Children.Count];
            Bones[newBoneIndex].Children.CopyTo(children);

            for (int i = 0; i < children.Length; i++) { MoveBone(children[i].Index, newBoneIndex); }

            Bones.ReIndex();

            return true;
        }

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

        public ModelMesh FindMesh(string name)
        {
            foreach (ModelMesh mesh in Meshes) { if (mesh.Name == name) { return mesh; } }

            return null;
        }

        public ModelMesh FindMesh(object tag)
        {
            foreach (ModelMesh mesh in Meshes) { if (mesh.Tag.Equals(tag)) { return mesh; } }

            return null;
        }

        public void SetTransform(Matrix4D transform, int boneIndex = 0)
        {
            Bones[boneIndex].Transform = transform;
        }

        public void SetName(string name, int boneIndex = 0)
        {
            Bones[boneIndex].Name = name;
        }

        public void SetMesh(ModelMesh mesh, int boneIndex = 0)
        {
            Bones[boneIndex].Type = BoneType.Mesh;
            Bones[boneIndex].Attachment = mesh;
            mesh.Parent = Bones[boneIndex];
            Meshes.Add(mesh);
        }

        public void ClearMesh(int boneIndex)
        {
            if (Bones[boneIndex].Mesh != null)
            {
                Bones[boneIndex].Type = BoneType.Null;
                Meshes.Remove(Bones[boneIndex].Mesh);
                Bones[boneIndex].Attachment = null;
            }
        }

        public List<Material> GetMaterials()
        {
            List<Material> l = new List<Material>();
            List<long> index = new List<long>();

            foreach (ModelMesh mesh in Meshes)
            {
                foreach (ModelMeshPart part in mesh.MeshParts)
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
            for (int i = Meshes.Count - 1; i > -1; i--)
            {
                if (Meshes[i].MeshParts.Count == 0)
                {
                    ClearMesh(Meshes[i].Parent.Index);
                }
            }
        }

        public void Draw()
        {
            Matrix4D[] transforms = new Matrix4D[Bones.Count];
            CopyAbsoluteBoneTransformsTo(transforms);
            Matrix4D m = SceneManager.Current.Transform;

            foreach (ModelMesh mesh in Meshes)
            {
                SceneManager.Current.Renderer.PushMatrix();

                SceneManager.Current.Renderer.MultMatrix(ref m);
                SceneManager.Current.Renderer.MultMatrix(ref transforms[mesh.Parent.Index]);

                mesh.Draw();

                SceneManager.Current.Renderer.PopMatrix();
            }
        }
    }
}
