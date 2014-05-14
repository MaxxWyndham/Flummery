using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Flummery.ContentPipeline.Core
{
    class TGAImporter : ContentImporter
    {
        public override string GetExtension() { return "tga"; }

        public override Asset Import(string path)
        {
            Texture texture = new Texture();

            var fi = new FileInfo(path);

            using (var br = new BinaryReader(fi.OpenRead()))
            {
                byte idLength = br.ReadByte();
                byte colourMapType = br.ReadByte();
                byte imageType = br.ReadByte();

                if (idLength > 0) { throw new NotImplementedException("No support for TGA files with ID sections!"); }
                if (colourMapType == 0) { br.ReadBytes(5); } else { throw new NotImplementedException("No support for TGA files with ColourMaps!"); }

                int xOrigin = br.ReadInt16();
                int yOrigin = br.ReadInt16();
                int width = br.ReadInt16();
                int height = br.ReadInt16();
                byte pixelDepth = br.ReadByte();
                byte imageDescriptor = br.ReadByte();

                using (var bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb))
                {
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            byte b = br.ReadByte();
                            byte g = br.ReadByte();
                            byte r = br.ReadByte();
                            byte a = br.ReadByte();

                            bmp.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                        }
                    }

                    texture.CreateFromBitmap(bmp, Path.GetFileNameWithoutExtension(path));
                }
            }

            return texture;
        }
    }
}
