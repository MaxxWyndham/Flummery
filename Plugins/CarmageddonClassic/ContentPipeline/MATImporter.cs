using ToxicRagers.Brender.Formats;

using Flummery.Core.ContentPipeline;
using Flummery.Core;

namespace Flummery.Plugin.CarmageddonClassic.ContentPipeline
{
    class MATImporter : ContentImporter
    {
        public override string GetExtension() { return "mat"; }

        public override string GetHints(string currentPath)
        {
            string hints = string.Empty;

            if (currentPath != null && Directory.Exists(currentPath))
            {
                hints = $"{currentPath};";

                if (Directory.Exists(Path.Combine(Directory.GetParent(currentPath).FullName, "MATERIAL")))
                {
                    hints += $"{Path.Combine(Directory.GetParent(currentPath).FullName, "MATERIAL")};";
                }
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

                    //materials.Entries[materials.Entries.Count - 1].SupportingDocuments["Source"] = material;
                }
                else
                {
                    materials.Entries.Add(
                        new Material
                        {
                            Name = material.Name,
                            Texture = SceneManager.Current.Content.Load<Texture, PIXImporter>(material.Texture, Path.GetDirectoryName(path), true)
                        }
                    );
                }
            }

            return materials;
        }
    }
}