using System;
using System.Linq;
using ToxicRagers.Helpers;
using ToxicRagers.Stainless.Formats;

namespace Flummery.ContentPipeline.Stainless
{
    class CNTExporter : ContentExporter
    {
        public override void Export(Asset asset, string Path)
        {
            var model = (asset as Model);
            var cnt = new CNT();

            TravelTree(model.Root.Children[0], ref cnt, true);

            cnt.Save(Path);
        }

        public static void TravelTree(ModelBone bone, ref CNT parent, bool root = false)
        {
            var cnt = new CNT();
            if (root) { cnt = parent; }

            cnt.Name = bone.Name;
            cnt.Transform = new Matrix3D(
                                bone.Transform.M11, bone.Transform.M12,  bone.Transform.M13,
                                bone.Transform.M21, bone.Transform.M22,  bone.Transform.M23,
                                bone.Transform.M31, bone.Transform.M32,  bone.Transform.M33,
                                bone.Transform.M41, bone.Transform.M42, -bone.Transform.M43
                            );

            if (bone.Tag != null)
            {
                cnt.Section = "MODL";
                cnt.Model = ((ModelMesh)bone.Tag).Name;
            }
            else
            {
                cnt.Section = "NULL";
            }
            

            foreach (var b in bone.Children)
            {
                TravelTree(b, ref cnt);
            }

            if (!root) { parent.Children.Add(cnt); }
        }
    }
}
