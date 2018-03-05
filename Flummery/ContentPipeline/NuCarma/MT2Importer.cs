using System.IO;

using ToxicRagers.CarmageddonReincarnation.Formats;

namespace Flummery.ContentPipeline.NuCarma
{
    class MT2Importer : ContentImporter
    {
        public override string GetExtension() { return "mt2"; }

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
            string name = Path.GetFileNameWithoutExtension(path);
            Material material = new Material { Name = name };

            MT2 mat = MT2.Load(path);

            foreach (string file in mat.FileNames)
            {
                material.Texture = SceneManager.Current.Content.Load<Texture, TDXImporter>(file, Path.GetDirectoryName(path));
            }

            material.SupportingDocuments["Source"] = mat;

            return material;
        }
    }
}