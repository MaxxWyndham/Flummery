using System;
using System.Drawing;
using System.IO;

using ToxicRagers.CarmageddonReincarnation.Formats;
using ToxicRagers.Helpers;

namespace Flummery.ContentPipeline.Stainless
{
    class TDXExporter : ContentExporter
    {
        public override void Export(Asset asset, string path)
        {
            var texture = (asset as Texture);
            var tdx = (texture.SupportingDocuments["Source"] as TDX);

            if (tdx == null)
            {
                tdx = new TDX();

                var b = (texture.SupportingDocuments["Source"] as Bitmap);

                SceneManager.Current.UpdateProgress(string.Format("Saving {0}", texture.Name));

                var flags = Squish.SquishFlags.kDxt1;

                tdx.Name = texture.Name;
                tdx.Format = settings.GetSetting<D3DFormat>("Format");

                switch (tdx.Format)
                {
                    case D3DFormat.DXT1:
                        flags = Squish.SquishFlags.kDxt1;
                        break;

                    case D3DFormat.DXT5:
                        flags = Squish.SquishFlags.kDxt5;
                        break;
                }

                var mip = new ToxicRagers.Generics.MipMap();
                mip.Width = b.Width;
                mip.Height = b.Height;

                byte[] data = new byte[b.Width * b.Height * 4];
                byte[] dest = new byte[Squish.Squish.GetStorageRequirements(b.Width, b.Height, flags | Squish.SquishFlags.kColourIterativeClusterFit | Squish.SquishFlags.kWeightColourByAlpha)];

                int ii = 0;
                for (int y = 0; y < b.Height; y++)
                {
                    for (int x = 0; x < b.Width; x++)
                    {
                        var p = b.GetPixel(x, y);
                        data[ii + 0] = p.R;
                        data[ii + 1] = p.G;
                        data[ii + 2] = p.B;
                        data[ii + 3] = p.A;

                        ii += 4;
                    }
                }

                SceneManager.Current.UpdateProgress(string.Format("Compressing {0} (this may take a moment)", texture.Name));
                Squish.Squish.CompressImage(data, b.Width, b.Height, ref dest, flags | Squish.SquishFlags.kColourClusterFit);
                mip.Data = dest;

                tdx.MipMaps.Add(mip);
            }

            tdx.Save(Path.GetDirectoryName(path) + "\\" + texture.Name + ".tdx");

            SceneManager.Current.UpdateProgress(string.Format("{0}.tdx saved!", texture.Name));
        }
    }
}
