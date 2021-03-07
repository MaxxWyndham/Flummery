using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;

using Flummery.Core.ContentPipeline;

using ToxicRagers.CarmageddonReincarnation.Formats;

namespace Flummery.Core
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

        private int texture;

        public int ID => texture;

        public int Width { get; private set; }

        public int Height { get; private set; }

        public string Format { get; private set; }

        public byte[] Data { get; private set; }

        public TextureType Type { get; set; } = TextureType.Diffuse;

        public Texture()
        {
            SceneManager.Current.Renderer.GenTextures(1, out texture);
            SceneManager.Current.Renderer.BindTexture("Texture2D", texture);

            SceneManager.Current.Renderer.TexParameter("Texture2D", "TextureMinFilter", 0x2601);
            SceneManager.Current.Renderer.TexParameter("Texture2D", "TextureMagFilter", 0x2601);

            //CreateFromBitmap((Bitmap)Image.FromFile(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "data", "test.bmp")), null);
        }

        public void CreateFromBitmap(Bitmap bitmap, string name)
        {
            Name = name;
            Width = bitmap.Width;
            Height = bitmap.Height;

            BitmapData bmpdata = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            SceneManager.Current.Renderer.TexImage2D("Texture2D", 0, "Rgba", bmpdata.Width, bmpdata.Height, 0, "Bgra", "UnsignedByte", bmpdata.Scan0);
            bitmap.UnlockBits(bmpdata);

            SupportingDocuments["Source"] = bitmap.Clone();
        }

        public void SetData(string name, string format, int width, int height, byte[] data)
        {
            Name = name;
            Format = format;
            Width = width;
            Height = height;

            if (data == null) { return; }

            Data = data;

            switch (format)
            {
                case "ATI2":
                    SceneManager.Current.Renderer.CompressedTexImage2D("Texture2D", 0, "CompressedRedRgtc1", width, height, 0, data.Length, data);
                    break;

                case "A8R8G8B8":
                    SceneManager.Current.Renderer.CompressedTexImage2D("Texture2D", 0, "CompressedRgba", width, height, 0, data.Length, data);
                    break;

                case "DXT1":
                    SceneManager.Current.Renderer.CompressedTexImage2D("Texture2D", 0, "CompressedRgbaS3tcDxt1Ext", width, height, 0, data.Length, data);
                    break;

                case "DXT5":
                    SceneManager.Current.Renderer.CompressedTexImage2D("Texture2D", 0, "CompressedRgbaS3tcDxt5Ext", width, height, 0, data.Length, data);
                    break;

                default:
                    throw new NotImplementedException($"Unknown texture format: {format}");
            }
        }

        public Bitmap GetBitmap(bool suppressAlpha = true)
        {
            if (SupportingDocuments["Source"] is Bitmap bmp) { return bmp; }

            if (SupportingDocuments["Source"] is TDX tdx) { return tdx.Decompress(0, suppressAlpha); }

            return new Bitmap(64, 64);
        }

        public Bitmap GetThumbnail(int maxWidth = 128, bool suppressAlpha = true)
        {
            if (SupportingDocuments["Source"] is Bitmap bmp) { return bmp; }

            if (SupportingDocuments["Source"] is TDX tdx) { return tdx.Decompress(tdx.GetMipLevelForSize(maxWidth), suppressAlpha); }

            return new Bitmap(64, 64);
        }
    }

    public class TextureList : AssetList { }

    public partial class ContentManager
    {
        public Texture Load(string assetName, string assetPath = null)
        {
            string extension = Path.GetExtension(assetName).ToLower().Substring(1);
            Type type = typeof(ContentImporter);
            Type importer = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && !p.IsAbstract)
                .Where(p => ((ContentImporter)Activator.CreateInstance(p)).GetExtension() == extension)
                .FirstOrDefault();

            if (importer != null)
            {
                MethodInfo method = typeof(ContentManager).GetMethods()
                    .FirstOrDefault(m => m.Name == nameof(ContentManager.Load) && m.IsGenericMethod);
                MethodInfo generic = method.MakeGenericMethod(typeof(Texture), importer);

                return (Texture)generic.Invoke(SceneManager.Current.Content, new object[] { assetName, assetPath, false });
            }

            return null;
        }
    }
}