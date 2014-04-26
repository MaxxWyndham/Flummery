using System;
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
        }

        public static Texture CreateFromMaterial(string name)
        {
            return SceneManager.Scene.Content.Load<Texture, MaterialImporter>(name, true);
        }

        public void SetData(string name, string format, int width, int height, byte[] data)
        {
            this.name = name;
            this.format = format;
            this.width = width;
            this.height = height;
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

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
        }
    }
}
