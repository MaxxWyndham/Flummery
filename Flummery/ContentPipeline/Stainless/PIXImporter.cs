using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

using ToxicRagers.Carmageddon.Formats;
using ToxicRagers.Helpers;
using ToxicRagers.Stainless.Formats;

using OpenTK;
using System.Runtime.InteropServices;

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

        public override AssetList ImportMany(string path)
        {
            TextureList textures = new TextureList();

            var pix = PIX.Load(path);

            foreach (var pixelmap in pix.Pixies)
            {
                Texture texture = new Texture();

                using (var bmp = new Bitmap(pixelmap.Width, pixelmap.Height, PixelFormat.Format32bppArgb))
                {
                    BitmapData bmpdata = bmp.LockBits(new Rectangle(0, 0, pixelmap.Width, pixelmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

                    using (var nms = new MemoryStream())
                    {
                        for (int y = 0; y < pixelmap.Height; y++)
                        { 
                            for (int x = 0; x < pixelmap.ActualRowSize; x++)
                            {
                                var c = pixelmap.GetColourAtPixel(x, y);
                                nms.WriteByte(c.B);
                                nms.WriteByte(c.G);
                                nms.WriteByte(c.R);
                                nms.WriteByte(255);
                            } 
                        }

                        var contentBuffer = new byte[nms.Length];
                        nms.Position = 0;
                        nms.Read(contentBuffer, 0, contentBuffer.Length);

                        Marshal.Copy(contentBuffer, 0, bmpdata.Scan0, contentBuffer.Length);
                    }

                    bmp.UnlockBits(bmpdata);

                    texture.CreateFromBitmap(bmp, pixelmap.Name);
                }

                textures.Entries.Add(texture);
            }
            

            //texture.SetData(tdx.Name, tdx.Format.ToString(), tdx.MipMaps[0].Width, tdx.MipMaps[0].Height, tdx.MipMaps[0].Data);
            //texture.SupportingDocuments["Source"] = tdx;
            //texture.FileName = path;

            return textures;
        }
    }
}
