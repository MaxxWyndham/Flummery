using System;
using ToxicRagers.Helpers;
using ToxicRagers.Carmageddon2.Formats;
using OpenTK;

namespace Flummery.ContentPipeline.Stainless
{
    class ACTImporter : ContentImporter
    {
        public override string GetExtension() { return "act"; }

        public override Asset Import(string path)
        {
            ACT act = ACT.Load(path);
            Model model = new Model();
            int boneIndex = 0;

            string fileName = path.Substring(path.LastIndexOf("\\") + 1);
            path = path.Replace(fileName, "");

            Model dat = SceneManager.Current.Content.Load<Model, DATImporter>(fileName.Replace(".act", ".dat", StringComparison.OrdinalIgnoreCase), path);

            foreach (var section in act.Sections)
            {
                switch (section.Section)
                {
                    case Section.Name:
                        boneIndex = model.AddMesh(null, boneIndex);
                        model.SetName(section.Identifier, boneIndex);
                        break;

                    case Section.Model:
                        model.SetMesh(new ModelMesh(dat.FindMesh((section.Model.Contains(".") ? section.Model.Substring(0, section.Model.IndexOf(".")) : section.Model))), boneIndex);
                        break;

                    case Section.Matrix:
                        model.SetTransform(
                            new Matrix4(
                                section.Transform.M11, section.Transform.M12, section.Transform.M13, 0,
                                section.Transform.M21, section.Transform.M22, section.Transform.M23, 0,
                                section.Transform.M31, section.Transform.M32, section.Transform.M33, 0,
                                section.Transform.M41, section.Transform.M42, section.Transform.M43, 1
                            ), boneIndex
                        );
                        break;

                    case Section.SubLevelBegin:
                        break;

                    case Section.SubLevelEnd:
                        boneIndex = model.Bones[boneIndex].Parent.Index;
                        break;
                }
            }

            SceneManager.Current.UpdateProgress(string.Format("Loaded {0}", fileName));

            return model;
        }
    }
}
