using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using Flummery.ContentPipeline.Stainless;
using OpenTK.Graphics.OpenGL;

namespace Flummery
{
    public class Texture : Asset
    {
        int texture;
        string format;
        int width;
        int height;
        byte[] data;

        public int ID { get { return texture; } }

        public Texture()
        {
            GL.GenTextures(1, out texture);
            GL.BindTexture(TextureTarget.Texture2D, texture);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

            CreateFromBitmap((Bitmap)Bitmap.FromFile(Path.GetDirectoryName(Application.ExecutablePath) + "\\data\\test.bmp"), null);
        }

        public void CreateFromBitmap(Bitmap bitmap, string name)
        {
            this.name = name;
            this.width = bitmap.Width;
            this.height = bitmap.Height;

            var bmpdata = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bmpdata.Width, bmpdata.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bmpdata.Scan0);
            bitmap.UnlockBits(bmpdata);

            this.supportingDocuments["Source"] = bitmap.Clone();
        }

        public void SetData(string name, string format, int width, int height, byte[] data)
        {
            this.name = name;
            this.format = format;
            this.width = width;
            this.height = height;

            if (data == null) { return; }

            this.data = data;

            switch (format)
            {
                //case "ATI2":
                //    GL.CompressedTexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.CompressedRedRgtc1, width, height, 0, data.Length, data);
                //    break;

                case "A8R8G8B8":
                    GL.CompressedTexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.CompressedRgba, width, height, 0, data.Length, data);
                    break;

                case "DXT1":
                    GL.CompressedTexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.CompressedRgbaS3tcDxt1Ext, width, height, 0, data.Length, data);
                    break;

                case "DXT5":
                    GL.CompressedTexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.CompressedRgbaS3tcDxt5Ext, width, height, 0, data.Length, data);
                    break;

                default:
                    throw new NotImplementedException(string.Format("Unknown texture format: {0}", format));
            }
        }

        public Bitmap GetBitmap()
        {
            var bmp = this.supportingDocuments["Source"] as Bitmap;
            if (bmp != null) { return bmp; }

            var tdx = this.supportingDocuments["Source"] as ToxicRagers.CarmageddonReincarnation.Formats.TDX;
            if (tdx != null) { return tdx.Decompress(0, true); }

            return new Bitmap(64, 64);
        }

        public Bitmap GetThumbnail(int maxWidth = 128, bool suppressAlpha = true)
        {
            var bmp = this.supportingDocuments["Source"] as Bitmap;
            if (bmp != null) { return bmp; }

            var tdx = this.supportingDocuments["Source"] as ToxicRagers.CarmageddonReincarnation.Formats.TDX;
            if (tdx != null) { return tdx.Decompress(tdx.GetMipLevelForSize(maxWidth), suppressAlpha); }

            return new Bitmap(64, 64);
        }
    }

    public class TextureList : AssetList { }
}
