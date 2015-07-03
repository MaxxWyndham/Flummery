using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using ToxicRagers.CarmageddonReincarnation.Formats;
using ToxicRagers.Helpers;

namespace Flummery.ContentPipeline.Stainless
{
    class TDXExporter : ContentExporter
    {
        public override void Export(Asset asset, string Path)
        {
            Stopwatch sw = new Stopwatch();
            var texture = (asset as Texture);
            var tdx = new TDX();
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

            sw.Start();
            Console.WriteLine("{0}", texture.Name);

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

            Console.WriteLine("{0}", sw.Elapsed.Duration().ToString());

            Squish.Squish.CompressImage(data, b.Width, b.Height, ref dest, flags | Squish.SquishFlags.kColourClusterFit);
            mip.Data = dest;

            Console.WriteLine("{0}", sw.Elapsed.Duration().ToString());

            tdx.MipMaps.Add(mip);
            tdx.Save(Path + "\\" + texture.Name + ".tdx");

            Console.WriteLine("{0}", sw.Elapsed.Duration().ToString());
        }
    }
}
