using ToxicRagers.Carmageddon2.Formats;
using ToxicRagers.Helpers;

using Flummery.Core;
using Flummery.Core.ContentPipeline;

namespace Flummery.Plugin.CarmageddonClassic.ContentPipeline
{
    class ACTExporter : ContentExporter
    {
        public override void Export(Asset asset, string path)
        {
            Model model = asset as Model;
            ACT act = new ACT();

            TravelTree(model.Root, ref act);

            act.Save(path);
        }

        public static void TravelTree(ModelBone bone, ref ACT act)
        {
            act.AddActor(
                bone.Name,
                bone.Type == BoneType.Mesh && bone.Mesh != null ? bone.Mesh.Name : null,
                new Matrix3D(
                    bone.Transform.M11, bone.Transform.M21, bone.Transform.M31,
                    bone.Transform.M12, bone.Transform.M22, bone.Transform.M32,
                    bone.Transform.M13, bone.Transform.M23, bone.Transform.M33,
                    bone.Transform.M41, bone.Transform.M42, bone.Transform.M43
                ),
                true
            );

            foreach (ModelBone b in bone.Children)
            {
                TravelTree(b, ref act);
                act.AddSubLevelEnd();
            }
        }
    }
}
