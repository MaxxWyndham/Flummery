using System.IO;

using ToxicRagers.Carmageddon.Formats;

using Flummery.Core.ContentPipeline;
using Flummery.Core;

namespace Flummery.Plugin.CarmageddonClassic.ContentPipeline
{
    class PIXImporter : ContentImporter
    {
        public override string GetExtension() { return "pix;p08;p16"; }

        public override string GetHints(string currentPath)
        {
            string hints = string.Empty;

            if (currentPath != null && Directory.Exists(currentPath))
            {
                hints = $"{currentPath};";

                if (Directory.Exists(Path.Combine(Directory.GetParent(currentPath).FullName, "PIXELMAP")))
                {
                    hints += $"{Path.Combine(Directory.GetParent(currentPath).FullName, "PIXELMAP")};";
                }
            }

            return hints;
        }

        public override Asset Import(string path)
        {
            Texture texture = new Texture
            {
                FileName = path
            };

            PIX pix = PIX.Load(path);
            texture.CreateFromBitmap(pix.Pixies[0].GetBitmap(), pix.Pixies[0].Name);

            return texture;
        }

        public override AssetList ImportMany(string path)
        {
            TextureList textures = new TextureList();

            PIX pix = PIX.Load(path);

            foreach (PIXIE pixelmap in pix.Pixies)
            {
                Texture texture = new Texture();

                texture.CreateFromBitmap(pixelmap.GetBitmap(), pixelmap.Name);

                textures.Entries.Add(texture);
            }

            return textures;
        }
    }
}