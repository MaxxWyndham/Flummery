using System;
using System.Diagnostics;
using ToxicRagers.Helpers;

namespace Flummery.Core
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
        bool rotationSet = false;
        bool positionSet = false;
        bool scaleSet = false;
        Vector3 rotation;
        Vector3 position;
        Vector3 scale;

        public int Index { get; set; } = 0;

        public string Name { get; set; }

        public ModelBone Parent { get; set; }

        public ModelBoneCollection Children { get; set; } = new ModelBoneCollection();

        public Matrix4D Transform { get; set; } = Matrix4D.Identity;

        public Matrix4D CombinedTransform
        {
            get
            {
                ModelBone b = this;
                Matrix4D m = Transform;

                while (b.Parent != null)
                {
                    b = b.Parent;
                    m *= b.Transform;
                }

                return m;
            }
        }

        public BoneType Type { get; set; }

        public object Attachment { get; set; }

        public string AttachmentFile { get; set; }

        public ModelMesh Mesh => Attachment as ModelMesh;

        public ModelBone Clone()
        {
            ModelBone b = new ModelBone()
            {
                Index = Index,
                Name = Name,
                Parent = Parent,
                Transform = Transform,

                Type = Type,
                Attachment = Attachment,
                AttachmentFile = AttachmentFile
            };

            foreach (ModelBone child in Children)
            {
                ModelBone cb = child.Clone();
                cb.Parent = b;

                b.Children.Add(cb);
            }

            return b;
        }

        public ModelBoneCollection AllChildren(bool includeSelf = true)
        {
            ModelBoneCollection childs = new ModelBoneCollection();

            if (includeSelf) { childs.Add(this); }
            GetChildren(this, ref childs);

            return childs;
        }

        protected void GetChildren(ModelBone parent, ref ModelBoneCollection list)
        {
            foreach (ModelBone child in parent.Children)
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
            if (!positionSet)
            {
                Vector3 p = Transform.ExtractTranslation();

                p.X = (float)Math.Round(p.X, 3, MidpointRounding.AwayFromZero);
                p.Y = (float)Math.Round(p.Y, 3, MidpointRounding.AwayFromZero);
                p.Z = (float)Math.Round(p.Z, 3, MidpointRounding.AwayFromZero);

                position = p;

                positionSet = true;
            }

            return position;
        }

        public Vector3 GetRotation()
        {
            if (!rotationSet)
            {
                Vector3 r = Transform.ExtractRotation().ToEuler(Quaternion.RotationOrder.OrderXYZ);

                r.X = (float)Math.Round(r.X, 3, MidpointRounding.AwayFromZero);
                r.Y = (float)Math.Round(r.Y, 3, MidpointRounding.AwayFromZero);
                r.Z = (float)Math.Round(r.Z, 3, MidpointRounding.AwayFromZero);

                rotation = r;

                rotationSet = true;
            }

            return rotation;
        }

        public Vector3 GetScale()
        {
            if (!scaleSet)
            {
                Vector3 s = Transform.ExtractScale();

                s.X = (float)Math.Round(s.X, 3, MidpointRounding.AwayFromZero);
                s.Y = (float)Math.Round(s.Y, 3, MidpointRounding.AwayFromZero);
                s.Z = (float)Math.Round(s.Z, 3, MidpointRounding.AwayFromZero);

                scale = s;

                scaleSet = true;
            }

            return scale;
        }

        public void SetPosition(float x, float y, float z, bool absolute = true)
        {
            position = new Vector3(x, y, z);

            updateMatrix(position, rotation, scale, absolute);
        }

        public void SetRotation(float x, float y, float z, bool absolute = true)
        {
            rotation = new Vector3(x, y, z);

            updateMatrix(position, rotation, scale, absolute);
        }

        public void SetScale(float x, float y, float z, bool absolute = true)
        {
            scale = new Vector3(x, y, z);

            updateMatrix(position, rotation, scale, absolute);
        }

        private void updateMatrix(Vector3 position, Vector3 rotation, Vector3 scale, bool absolute)
        {
            Matrix4D mS = Matrix4D.CreateScale(scale);
            Matrix4D mR = Matrix4D.CreateFromQuaternion(
                Quaternion.FromAxisAngle(Vector3.UnitX, Maths.DegreesToRadians(rotation.X)) *
                Quaternion.FromAxisAngle(Vector3.UnitY, Maths.DegreesToRadians(rotation.Y)) *
                Quaternion.FromAxisAngle(Vector3.UnitZ, Maths.DegreesToRadians(rotation.Z))
            );

            Matrix4D t = Matrix4D.Identity;
            t *= mS;
            t *= mR;
            t.M41 = position.X;
            t.M42 = position.Y;
            t.M43 = position.Z;

            if (absolute)
            {
                Transform = t;
            }
            else
            {
                Transform *= t;
            }

            SceneManager.Current.Models[0].SetTransform(Transform, SceneManager.Current.SelectedBoneIndex);
        }
    }
}