using System;
using ToxicRagers.Carmageddon2.Formats;
using ToxicRagers.Helpers;

namespace Flummery.ContentPipeline.Stainless
{
    class ACTExporter : ContentExporter
    {
        public override void Export(Asset asset, string path)
        {
            var model = (asset as Model);
            var act = new ACT();

            TravelTree(model.Root, ref act, true);

            act.Save(path);
        }

        public static void TravelTree(ModelBone bone, ref ACT act, bool root = false)
        {
            act.AddActor(
                bone.Name, 
                (bone.Tag != null ? ((ModelMesh)bone.Tag).Name : null),
                new Matrix3D(
                    bone.Transform.M11, bone.Transform.M21, bone.Transform.M31,
                    bone.Transform.M12, bone.Transform.M22, bone.Transform.M32,
                    bone.Transform.M13, bone.Transform.M23, bone.Transform.M33,
                    bone.Transform.M41, bone.Transform.M42, bone.Transform.M43
                ),
                true
            );

            foreach (var b in bone.Children)
            {
                TravelTree(b, ref act);
                act.AddSubLevelEnd();
            }
        }
    }
}
