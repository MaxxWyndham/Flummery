using System;
using System.IO;

using ToxicRagers.Carmageddon2.Formats;

using OpenTK;

namespace Flummery.ContentPipeline.CarmaClassic
{
    class ACTImporter : ContentImporter
    {
        public override string GetExtension() { return "act"; }

        public override string GetHints(string currentPath)
        {
            string hints = (currentPath != null ? currentPath + ";" : "");

            if (Properties.Settings.Default.PathCarmageddon1 != null && currentPath.Contains(Properties.Settings.Default.PathCarmageddon1))
            {
                if (Directory.Exists(Properties.Settings.Default.PathCarmageddon1 + "DATA\\ACTORS\\")) { hints += Properties.Settings.Default.PathCarmageddon1 + "DATA\\ACTORS\\;"; }
            }

            return hints;
        }

        public override Asset Import(string path)
        {
            ACT act = ACT.Load(path);
            Model model = new Model();
            int boneIndex = 0;

            string fileName = Path.GetFileName(path);
            path = Path.GetDirectoryName(path);

            Model dat = SceneManager.Current.Content.Load<Model, DATImporter>($"{Path.GetFileNameWithoutExtension(fileName)}.dat", path);
            Material material = null;

            foreach (ACTNode section in act.Sections)
            {
                switch (section.Section)
                {
                    case Section.Name:
                        boneIndex = model.AddMesh(null, boneIndex);
                        model.SetName(section.Identifier, boneIndex);
                        material = null;
                        break;

                    case Section.Material:
                        material = (Material)SceneManager.Current.Materials.Entries.Find(m => m.Name == section.Material);
                        if (material == null)
                        {
                            material = new Material() { Name = section.Material };
                            SceneManager.Current.Add(material);
                        }
                        break;

                    case Section.Model:
                        model.SetMesh(new ModelMesh(dat.FindMesh((section.Model.Contains(".") ? section.Model.Substring(0, section.Model.IndexOf(".")) : section.Model))), boneIndex);
                        if (material != null)
                        {
                            foreach (ModelMesh modelmesh in model.Meshes)
                            {
                                foreach (ModelMeshPart meshpart in modelmesh.MeshParts)
                                {
                                    if (meshpart.Material == null) { meshpart.Material = material; }
                                }
                            }
                        }
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