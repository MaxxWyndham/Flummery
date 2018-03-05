using System.IO;

using Flummery.ContentPipeline.Core;

using ToxicRagers.Carmageddon2.Formats;

namespace Flummery.ContentPipeline.CarmaClassic
{
    class MATImporter : ContentImporter
    {
        public override string GetExtension() { return "mat"; }

        public override string GetHints(string currentPath)
        {
            string hints = (currentPath != null ? currentPath + ";" : "");

            if (Properties.Settings.Default.PathCarmageddon1 != null &&
                currentPath.Contains(Properties.Settings.Default.PathCarmageddon1))
            {
                string matPath = Path.Combine(Properties.Settings.Default.PathCarmageddon1, "DATA", "MATERIAL");

                if (Directory.Exists(matPath)) { hints += $"{matPath};"; }
            }

            return hints;
        }

        public override AssetList ImportMany(string path)
        {
            MaterialList materials = new MaterialList();
            MAT mat = MAT.Load(path);

            foreach (MATMaterial material in mat.Materials)
            {
                if (material.Texture == Path.GetFileNameWithoutExtension(material.Texture))
                {
                    materials.Entries.Add(
                        new Material
                        {
                            Name = material.Name,
                            Texture = SceneManager.Current.Content.Load<Texture, TIFImporter>(material.Texture, Path.GetDirectoryName(path))
                        }
                    );

                    materials.Entries[materials.Entries.Count - 1].SupportingDocuments["Source"] = material;
                }
                else
                {
                    materials.Entries.Add(
                        new Material
                        {
                            Name = material.Name,
                            Texture = SceneManager.Current.Content.Load<Texture, PIXImporter>(material.Texture, Path.GetDirectoryName(path))
                        }
                    );
                }
            }

            return materials;
        }
    }
}