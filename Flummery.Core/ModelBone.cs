using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ToxicRagers.Helpers;

namespace Flummery.Core
{
    public enum BoneType
    {
        Null = 0,
        Mesh,
        VFX,
        Light
    }

    public class ModelBone
    {
        public string Name { get; set; }

        public int Index { get; set; }

        public ModelBone Parent { get; set; }

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

        public ModelBoneCollection Children { get; set; } = new ModelBoneCollection();

        public BoneType Type { get; set; }

        public object Attachment { get; set; }

        public ModelMesh Mesh => Attachment as ModelMesh;

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
    }
}
