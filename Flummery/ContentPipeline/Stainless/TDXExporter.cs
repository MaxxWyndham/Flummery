using System;
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
            var texture = (asset as Texture);
            var tdx = new TDX();
            var b = (texture.Tag as Bitmap);

            tdx.Name = texture.Name;
            tdx.Format = D3DFormat.DXT5;

            var mip = new MipMap();
            mip.Width = b.Width;
            mip.Height = b.Height;

            byte[] data = new byte[b.Width * b.Height * 4];
            byte[] dest = new byte[Squish.Squish.GetStorageRequirements(b.Width, b.Height, Squish.SquishFlags.kDxt5 | Squish.SquishFlags.kColourIterativeClusterFit | Squish.SquishFlags.kWeightColourByAlpha)];

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

            Squish.Squish.CompressImage(data, b.Width, b.Height, ref dest, Squish.SquishFlags.kDxt3 | Squish.SquishFlags.kColourIterativeClusterFit | Squish.SquishFlags.kWeightColourByAlpha);
            mip.Data = dest;

            tdx.MipMaps.Add(mip);
            tdx.Save(Path + "\\" + texture.Name + ".tdx");

            using (StreamWriter w = File.CreateText(Path + "\\" + texture.Name + ".mt2"))
            {
                w.WriteLine("<?xml version=\"1.0\"?>");
                w.WriteLine("<Material>");
                w.WriteLine("<BasedOffOf Name=\"simple_base\"/>");
                w.WriteLine("<Pass Number=\"0\">");
                w.WriteLine("<Texture Alias=\"DiffuseColour\" FileName=\"" + texture.Name + "\"/>");
                w.WriteLine("</Pass>");
                w.WriteLine("</Material>");
            }
        }
    }
}
