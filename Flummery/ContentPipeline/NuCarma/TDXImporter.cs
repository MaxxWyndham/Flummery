using System.IO;

using Flummery.ContentPipeline.Stainless;

using ToxicRagers.CarmageddonReincarnation.Formats;

namespace Flummery.ContentPipeline.NuCarma
{
    class TDXImporter : ContentImporter
    {
        public override string GetExtension() { return "tdx;img"; }

        public override string GetHints(string currentPath)
        {
            string hints = (currentPath != null ? currentPath + ";" : "");

            if (Properties.Settings.Default.PathCarmageddonReincarnation != null)
            {
                if (Directory.Exists(Properties.Settings.Default.PathCarmageddonReincarnation + "Data_Core\\Content\\Textures\\")) { hints = Properties.Settings.Default.PathCarmageddonReincarnation + "Data_Core\\Content\\Textures\\"; }

                return hints;
            }

            return null;
        }

        public override Asset Import(string path)
        {
            Texture texture = new Texture
            {
                FileName = path
            };

            if (string.Compare(Path.GetExtension(path), ".tdx", true) == 0)
            {
                TDX tdx = TDX.Load(path);
                texture.SetData(tdx.Name, tdx.Format.ToString(), tdx.MipMaps[0].Width, tdx.MipMaps[0].Height, tdx.MipMaps[0].Data);
                texture.SupportingDocuments["Source"] = tdx;
            }
            else
            {
                texture = (Texture)(new IMGImporter()).Import(path);
            }

            return texture;
        }
    }
}
