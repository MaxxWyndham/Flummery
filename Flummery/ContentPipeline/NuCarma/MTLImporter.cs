using System.IO;

using ToxicRagers.CarmageddonReincarnation.Formats;
using ToxicRagers.Stainless.Formats;

namespace Flummery.ContentPipeline.NuCarma
{
    class MTLImporter : ContentImporter
    {
        public override string GetExtension() { return "mtl"; }

        public override string GetHints(string currentPath)
        {
            string hints = (currentPath != null ? currentPath + ";" : "");

            if (Properties.Settings.Default.PathCarmageddonReincarnation != null &&
                currentPath.Contains(Properties.Settings.Default.PathCarmageddonReincarnation))
            {
                if (Directory.Exists(Properties.Settings.Default.PathCarmageddonReincarnation + "Data_Core\\Content\\Textures\\")) { hints += Properties.Settings.Default.PathCarmageddonReincarnation + "Data_Core\\Content\\Textures\\;"; }
            }

            return hints;
        }

        public override Asset Import(string path)
        {
            Material material;

            string name = Path.GetFileNameWithoutExtension(path);
            MTL mat = MTL.Load(path);
            string fileName = mat.Textures[0];

            if (fileName == null || fileName == "")
            {
                material = new Material { Name = name, Texture = new Texture() { Name = fileName } };
            }
            else
            {
                material = new Material
                {
                    Name = name,
                    Texture = SceneManager.Current.Content.Load<Texture, TDXImporter>(fileName, Path.GetDirectoryName(path))
                };
            }

            material.SupportingDocuments["Source"] = mat;

            return material;
        }
    }
}