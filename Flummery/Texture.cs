using System;
using System.Collections.Generic;
using OpenTK.Graphics.OpenGL;

namespace Flummery
{
    public class Texture
    {
        public static Dictionary<string, int> Textures = new Dictionary<string, int>();

        public static void CreateTexture(out int texture, string name, string format, int width, int height, byte[] data)
        {
            if (Textures.ContainsKey(name))
            {
                texture = Textures[name];
                return;
            }

            Console.WriteLine("Creating texture: {0}", name);

            GL.GenTextures(1, out texture);
            GL.BindTexture(TextureTarget.Texture2D, texture);

            switch (format)
            {
                case "ATI2":
                    GL.CompressedTexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.CompressedRedRgtc1, width, height, 0, data.Length, data);
                    break;

                case "DXT1":
                    GL.CompressedTexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.CompressedRgbaS3tcDxt1Ext, width, height, 0, data.Length, data);
                    break;

                case "DXT5":
                    GL.CompressedTexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.CompressedRgbaS3tcDxt5Ext, width, height, 0, data.Length, data);
                    break;
            }

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

            Textures[name] = texture;
        }
    }
}
