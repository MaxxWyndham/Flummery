using System;
using System.Diagnostics;

using OpenTK;

namespace Flummery
{
    // These values correspond with the index of icons in ilNodeIcons
    public enum BoneType
    {
        Null = 0,
        Mesh,
        VFX,
        Light
    }

    [DebuggerDisplay("Name {name} Index {index} Children {children.Count}")]
    public class ModelBone
    {
        ModelBoneCollection children;
        int index;
        string name;
        ModelBone parent;
        Matrix4 transform;

        bool bRotationSet = false;
        bool bPositionSet = false;
        bool bScaleSet = false;
        Vector3 rotation;
        Vector3 position;
        Vector3 scale;

        BoneType boneType = BoneType.Null;
        object attachment = null;
        string attachmentFile = null;

        public int Index
        {
            get => index;
            set => index = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public ModelBone Parent
        {
            get => parent;
            set => parent = value;
        }

        public ModelBoneCollection Children
        {
            get => children;
            set => children = value;
        }

        public Matrix4 Transform
        {
            get => transform;
            set => transform = value;
        }

        public Matrix4 CombinedTransform
        {
            get
            {
                ModelBone b = this;
                Matrix4 m = transform;

                while (b.parent != null)
                {
                    b = b.parent;
                    m *= b.transform;
                }

                return m;
            }
        }

        public BoneType Type
        {
            get => boneType;
            set => boneType = value;
        }

        public object Attachment
        {
            get => attachment;
            set => attachment = value;
        }

        public string AttachmentFile
        {
            get => attachmentFile;
            set => attachmentFile = value;
        }

        public ModelMesh Mesh => attachment as ModelMesh;
        public ModelBone()
        {
            children = new ModelBoneCollection();
            Index = 0;
            Transform = Matrix4.Identity;
        }

        public ModelBone Clone()
        {
            ModelBone b = new ModelBone()
            {
                index = index,
                name = name,
                parent = parent,
                transform = transform,

                boneType = boneType,
                attachment = attachment,
                attachmentFile = attachmentFile
            };

            foreach (ModelBone child in children)
            {
                ModelBone cb = child.Clone();
                cb.parent = b;

                b.children.Add(cb);
            }

            return b;
        }

        public ModelBoneCollection AllChildren(bool bIncludeSelf = true)
        {
            ModelBoneCollection childs = new ModelBoneCollection();

            if (bIncludeSelf) { childs.Add(this); }
            GetChildren(this, ref childs);

            return childs;
        }

        protected void GetChildren(ModelBone parent, ref ModelBoneCollection list)
        {
            foreach (ModelBone child in parent.children)
            {
                list.Add(child);

                child.GetChildren(child, ref list);
            }
        }

        public static int GetModelBoneKey(int index, int boneIndex)
        {
            return (index << 20) + boneIndex;
        }

        public static int GetBoneIndexFromKey(int key)
        {
            return (key & 0xFFFFF);
        }

        public static int GetModelIndexFromKey(int key)
        {
            return key >> 20;
        }

        public Vector3 GetPosition()
        {
            if (!bPositionSet)
            {
                Vector3 p = transform.ExtractTranslation();

                p.X = (float)Math.Round(p.X, 3, MidpointRounding.AwayFromZero);
                p.Y = (float)Math.Round(p.Y, 3, MidpointRounding.AwayFromZero);
                p.Z = (float)Math.Round(p.Z, 3, MidpointRounding.AwayFromZero);

                position = p;

                bPositionSet = true;
            }

            return position;
        }

        public Vector3 GetRotation()
        {
            if (!bRotationSet)
            {
                Vector3 r = transform.ExtractRotation().ToEuler(RotationOrder.OrderXYZ);

                r.X = (float)Math.Round(r.X, 3, MidpointRounding.AwayFromZero);
                r.Y = (float)Math.Round(r.Y, 3, MidpointRounding.AwayFromZero);
                r.Z = (float)Math.Round(r.Z, 3, MidpointRounding.AwayFromZero);

                rotation = r;

                bRotationSet = true;
            }

            return rotation;
        }

        public Vector3 GetScale()
        {
            if (!bScaleSet)
            {
                Vector3 s = transform.ExtractScale();

                s.X = (float)Math.Round(s.X, 3, MidpointRounding.AwayFromZero);
                s.Y = (float)Math.Round(s.Y, 3, MidpointRounding.AwayFromZero);
                s.Z = (float)Math.Round(s.Z, 3, MidpointRounding.AwayFromZero);

                scale = s;

                bScaleSet = true;
            }

            return scale;
        }

        public void SetPosition(float x, float y, float z, bool bAbsolute = true)
        {
            position = new Vector3(x, y, z);

            updateMatrix(position, rotation, scale, bAbsolute);
        }

        public void SetRotation(float x, float y, float z, bool bAbsolute = true)
        {
            rotation = new Vector3(x, y, z);

            updateMatrix(position, rotation, scale, bAbsolute);
        }

        public void SetScale(float x, float y, float z, bool bAbsolute = true)
        {
            scale = new Vector3(x, y, z);

            updateMatrix(position, rotation, scale, bAbsolute);
        }

        private void updateMatrix(Vector3 position, Vector3 rotation, Vector3 scale, bool bAbsolute)
        {
            Matrix4 mS = Matrix4.CreateScale(scale);
            Matrix4 mR = Matrix4.CreateFromQuaternion(
                Quaternion.FromAxisAngle(Vector3.UnitX, MathHelper.DegreesToRadians(rotation.X)) *
                Quaternion.FromAxisAngle(Vector3.UnitY, MathHelper.DegreesToRadians(rotation.Y)) *
                Quaternion.FromAxisAngle(Vector3.UnitZ, MathHelper.DegreesToRadians(rotation.Z))
            );

            Matrix4 t = Matrix4.Identity;
            t *= mS;
            t *= mR;
            t.M41 = position.X;
            t.M42 = position.Y;
            t.M43 = position.Z;

            if (bAbsolute)
            {
                transform = t;
            }
            else
            {
                transform *= t;
            }

            SceneManager.Current.Models[0].SetTransform(transform, SceneManager.Current.SelectedBoneIndex);
        }
    }
}