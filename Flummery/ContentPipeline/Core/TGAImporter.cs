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

            texture.FileName = path;

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
                    var bmpdata = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
                    System.Runtime.InteropServices.Marshal.Copy(br.ReadBytes(width * height * 4), 0, bmpdata.Scan0, width * height * 4);
                    bmp.UnlockBits(bmpdata);

                    texture.CreateFromBitmap(bmp, Path.GetFileNameWithoutExtension(path));
                }
            }

            return texture;
        }
    }
}
