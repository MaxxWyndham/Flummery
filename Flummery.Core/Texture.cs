using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flummery.Core
{
    public class Texture : Asset
    {
        public int Width { get; private set; }

        public int Height { get; private set; }

        public void CreateFromBitmap(Bitmap bitmap, string name)
        {
            Name = name;
            Width = bitmap.Width;
            Height = bitmap.Height;

            BitmapData bmpdata = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            //GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bmpdata.Width, bmpdata.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bmpdata.Scan0);
            bitmap.UnlockBits(bmpdata);

            SupportingDocuments["Source"] = bitmap.Clone();
        }
    }
}
