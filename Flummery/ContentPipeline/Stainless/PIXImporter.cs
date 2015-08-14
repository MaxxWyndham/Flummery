using System;
using System.IO;

using ToxicRagers.Carmageddon.Formats;

namespace Flummery.ContentPipeline.Stainless
{
    class PIXImporter : ContentImporter
    {
        public override string GetExtension() { return "pix;p08;p16"; }

        public override string GetHints(string currentPath)
        {
            string hints = (currentPath != null ? currentPath + ";" : "");

            if (Properties.Settings.Default.PathCarmageddon1 != null && currentPath.Contains(Properties.Settings.Default.PathCarmageddon1))
            {
                if (Directory.Exists(Properties.Settings.Default.PathCarmageddon1 + "DATA\\PIXELMAP\\")) { hints += Properties.Settings.Default.PathCarmageddon1 + "DATA\\PIXELMAP\\;"; }
            }

            return hints;
        }

        public override Asset Import(string path)
        {
            Texture texture = new Texture();
            texture.FileName = path;

            PIX pix = PIX.Load(path);
            texture.CreateFromBitmap(pix.Pixies[0].GetBitmap(), pix.Pixies[0].Name);

            return texture;
        }

        public override AssetList ImportMany(string path)
        {
            TextureList textures = new TextureList();

            var pix = PIX.Load(path);

            foreach (var pixelmap in pix.Pixies)
            {
                Texture texture = new Texture();

                texture.CreateFromBitmap(pixelmap.GetBitmap(), pixelmap.Name);

                textures.Entries.Add(texture);
            }
            

            //texture.SetData(tdx.Name, tdx.Format.ToString(), tdx.MipMaps[0].Width, tdx.MipMaps[0].Height, tdx.MipMaps[0].Data);
            //texture.SupportingDocuments["Source"] = tdx;
            //texture.FileName = path;

            return textures;
        }
    }
}
