using System;
using System.Linq;
using ToxicRagers.Helpers;
using ToxicRagers.Stainless.Formats;
using OpenTK;

namespace Flummery.ContentPipeline.Stainless
{
    class CNTExporter : ContentExporter
    {
        static OpenTK.Vector3 exportScale;

        public override void Export(Asset asset, string Path)
        {
            exportScale = (settings.Scale != null ? (OpenTK.Vector3)settings.Scale : OpenTK.Vector3.One);

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
                                bone.Transform.M11, bone.Transform.M21, bone.Transform.M31,
                                bone.Transform.M12, bone.Transform.M22, bone.Transform.M32,
                                bone.Transform.M13, bone.Transform.M23, bone.Transform.M33,
                                bone.Transform.M41 * exportScale.X, 
                                bone.Transform.M42 * exportScale.Y, 
                                bone.Transform.M43 * exportScale.Z
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
