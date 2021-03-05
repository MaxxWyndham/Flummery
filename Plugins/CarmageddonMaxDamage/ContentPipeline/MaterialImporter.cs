using System.IO;

using Flummery.Core.ContentPipeline;
using Flummery.Core;

namespace Flummery.Plugin.CarmageddonMaxDamage.ContentPipeline
{
    public class MaterialImporter : ContentImporter
    {
        public override string GetExtension() { return "mt2;mtl;"; }

        public override string GetHints(string currentPath)
        {
            string hints = (currentPath != null ? currentPath + ";" : "");

            //if (Properties.Settings.Default.PathCarmageddonReincarnation != null && 
            //    currentPath.Contains(Properties.Settings.Default.PathCarmageddonReincarnation))
            //{
            //    if (Directory.Exists(Properties.Settings.Default.PathCarmageddonReincarnation + "Data_Core\\Content\\Textures\\")) { hints += Properties.Settings.Default.PathCarmageddonReincarnation + "Data_Core\\Content\\Textures\\;"; }
            //}

            return hints;
        }

        public override Asset Import(string path)
        {
            switch (Path.GetExtension(path).ToLower())
            {
                case ".mt2":
                    return SceneManager.Current.Content.Load<Material, MT2Importer>(Path.GetFileName(path), Path.GetDirectoryName(path));

                case ".mtl":
                    return SceneManager.Current.Content.Load<Material, MTLImporter>(Path.GetFileName(path), Path.GetDirectoryName(path));

                default:
                    return null;
            }
        }
    }
}