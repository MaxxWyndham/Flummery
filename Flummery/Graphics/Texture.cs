using System;
using System.Drawing;
using System.Drawing.Imaging;
using Flummery.ContentPipeline.Stainless;
using OpenTK.Graphics.OpenGL;

namespace Flummery
{
    public class Texture : Asset
    {
        int texture;
        string name;
        string format;
        int width;
        int height;
        byte[] data;
        object tag;

        public int ID { get { return texture; } }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public object Tag
        {
            get { return tag; }
            set { tag = value; }
        }

        public Texture()
        {
            GL.GenTextures(1, out texture);
            GL.BindTexture(TextureTarget.Texture2D, texture);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
        }

        public static Texture CreateFromMaterial(string name, string path)
        {
            return SceneManager.Scene.Content.Load<Texture, MaterialImporter>(name, path, true);
        }

        public void CreateFromBitmap(Bitmap bitmap, string name)
        {
            this.name = name;
            this.width = bitmap.Width;
            this.height = bitmap.Height;

            var bmpdata = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bmpdata.Width, bmpdata.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bmpdata.Scan0);
            bitmap.UnlockBits(bmpdata);

            this.tag = bitmap.Clone();
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

                //case "8888":
                //    //GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, width, height, 0, PixelFormat.Bgra, PixelType.UnsignedInt8888, data);
                //    GL.CompressedTexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.CompressedRgba, width, height, 0, data.Length, data);
                //    break;

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
    }
}
