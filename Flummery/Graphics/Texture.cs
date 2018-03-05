using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

using Flummery.ContentPipeline.Core;
using Flummery.ContentPipeline.NuCarma;

using OpenTK.Graphics.OpenGL;

using ToxicRagers.CarmageddonReincarnation.Formats;

namespace Flummery
{
    public class Texture : Asset
    {
        public enum TextureType
        {
            Diffuse,
            Normal,
            Specular,
            Other
        }

        int texture;
        string format;
        int width;
        int height;
        byte[] data;
        TextureType textureType = TextureType.Diffuse;

        public int ID => texture;

        public TextureType Type
        {
            get => textureType;
            set => textureType = value;
        }

        public Texture()
        {
            GL.GenTextures(1, out texture);
            GL.BindTexture(TextureTarget.Texture2D, texture);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

            CreateFromBitmap((Bitmap)Image.FromFile(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "data", "test.bmp")), null);
        }

        public void CreateFromBitmap(Bitmap bitmap, string name)
        {
            this.name = name;
            width = bitmap.Width;
            height = bitmap.Height;

            BitmapData bmpdata = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bmpdata.Width, bmpdata.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bmpdata.Scan0);
            bitmap.UnlockBits(bmpdata);

            supportingDocuments["Source"] = bitmap.Clone();
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
                case "ATI2":
                    GL.CompressedTexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.CompressedRedRgtc1, width, height, 0, data.Length, data);
                    break;

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
                    throw new NotImplementedException($"Unknown texture format: {format}");
            }
        }

        public Bitmap GetBitmap(bool suppressAlpha = true)
        {
            if (supportingDocuments["Source"] is Bitmap bmp) { return bmp; }

            if (supportingDocuments["Source"] is TDX tdx) { return tdx.Decompress(0, suppressAlpha); }

            return new Bitmap(64, 64);
        }

        public Bitmap GetThumbnail(int maxWidth = 128, bool suppressAlpha = true)
        {
            if (supportingDocuments["Source"] is Bitmap bmp) { return bmp; }

            if (supportingDocuments["Source"] is TDX tdx) { return tdx.Decompress(tdx.GetMipLevelForSize(maxWidth), suppressAlpha); }

            return new Bitmap(64, 64);
        }
    }

    public class TextureList : AssetList { }

    public partial class ContentManager
    {
        public Texture Load(string assetName, string assetPath = null)
        {
            Texture t = null;

            switch (Path.GetExtension(assetName).ToLower())
            {
                case ".bmp":
                    t = SceneManager.Current.Content.Load<Texture, BMPImporter>(assetName, assetPath);
                    break;

                case ".jpg":
                    t = SceneManager.Current.Content.Load<Texture, JPGImporter>(assetName, assetPath);
                    break;

                case ".png":
                    t = SceneManager.Current.Content.Load<Texture, PNGImporter>(assetName, assetPath);
                    break;

                case ".tif":
                    t = SceneManager.Current.Content.Load<Texture, TIFImporter>(assetName, assetPath);
                    break;

                case ".tga":
                    t = SceneManager.Current.Content.Load<Texture, TGAImporter>(assetName, assetPath);
                    break;

                case ".tdx":
                    t = SceneManager.Current.Content.Load<Texture, TDXImporter>(assetName, assetPath);
                    break;
            }

            return t;
        }
    }
}