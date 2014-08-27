using System;
using System.Collections.Generic;
using System.Diagnostics;
using OpenTK;

namespace Flummery
{
    [DebuggerDisplay("Name {name} Index {index} Children {children.Count}")]
    public class ModelBone
    {
        ModelBoneCollection children;
        int index;
        string name;
        ModelBone parent;
        Matrix4 transform;
        object tag;

        public int Index
        {
            get { return index; }
            set { index = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public ModelBone Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        public ModelBoneCollection Children
        {
            get { return children; }
            set { children = value; }
        }

        public Matrix4 Transform
        {
            get { return transform; }
            set { transform = value; }
        }

        public Matrix4 CombinedTransform
        {
            get
            {
                var b = this;
                var m = transform;

                while (b.parent != null)
                {
                    b = b.parent;
                    m *= b.transform;
                }

                return m;
            }
        }

        public object Tag
        {
            get { return tag; }
            set { tag = value; }
        }

        public ModelBone()
        {
            children = new ModelBoneCollection();
            Index = 0;
            Transform = Matrix4.Identity;
        }

        public ModelBone Clone()
        {
            var b = new ModelBone();

            b.index = this.index;
            b.name = this.name;
            b.parent = this.parent;
            b.transform = this.transform;
            b.tag = this.tag;

            foreach (var child in this.children)
            {
                var cb = child.Clone();
                cb.parent = b;

                b.children.Add(cb); 
            }

            return b;
        }

        public ModelBoneCollection AllChildren(bool bIncludeSelf = true)
        {
            var childs = new ModelBoneCollection();

            if (bIncludeSelf) { childs.Add(this); }
            getChildren(this, ref childs);

            return childs;
        }

        protected void getChildren(ModelBone parent, ref ModelBoneCollection list)
        {
            foreach (var child in parent.children)
            {
                list.Add(child);

                child.getChildren(child, ref list);
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
    }
}
