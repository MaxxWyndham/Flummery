using System;
using System.Collections.Generic;
using OpenTK;

namespace Flummery
{
    public class ModelBone
    {
        List<ModelBone> children;
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

        public List<ModelBone> Children
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
            children = new List<ModelBone>();
            Index = 0;
            Transform = Matrix4.Identity;
        }

        public List<ModelBone> AllChildren(bool bIncludeSelf = true)
        {
            var childs = new List<ModelBone>();

            if (bIncludeSelf) { childs.Add(this); }
            getChildren(this, ref childs);

            return childs;
        }

        protected void getChildren(ModelBone parent, ref List<ModelBone> list)
        {
            foreach (var child in parent.children)
            {
                list.Add(child);

                child.getChildren(child, ref list);
            }
        }
    }
}
