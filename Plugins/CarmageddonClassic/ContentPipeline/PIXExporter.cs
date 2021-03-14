using System.Collections.Generic;

using ToxicRagers.Carmageddon.Formats;

using Flummery.Core.ContentPipeline;
using Flummery.Core;


namespace Flummery.Plugin.CarmageddonClassic.ContentPipeline
{
    class PIXExporter : ContentExporter
    {
        public override void Export(AssetList asset, string path)
        {
            MaterialList materials = asset as MaterialList;
            List<string> textures = new List<string>();
            PIX pix = new PIX();

            foreach (Material material in materials)
            {
                foreach (Texture texture in material.Textures)
                {
                    if (texture.FileName == null) { continue; }

                    if (!textures.Contains(texture.FileName))
                    {
                        PIXIE pixie = PIXIE.FromBitmap(PIXIE.PixelmapFormat.C1_8bit, texture.GetBitmap(false));
                        pixie.Name = texture.Name;

                        pix.Pixies.Add(pixie);

                        textures.Add(texture.FileName);
                    }
                }
            }

            pix.Save(path);
        }
    }
}
