using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;

using Flummery.Core.ContentPipeline;

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

        public int ID { get; private set; }

        public int Width { get; private set; }

        public int Height { get; private set; }

        public TextureType Type { get; set; } = TextureType.Diffuse;

        private Bitmap Thumb { get; set; }

        public Texture()
        {
            SceneManager.Current.Renderer.GenTextures(1, out int texture);

            ID = texture;

            SceneManager.Current.Renderer.BindTexture("Texture2D", ID);
            SceneManager.Current.Renderer.TexParameter("Texture2D", "TextureMinFilter", 0x2601);
            SceneManager.Current.Renderer.TexParameter("Texture2D", "TextureMagFilter", 0x2601);

            CreateFromBitmap((Bitmap)Image.FromFile(Path.Combine(SceneManager.Current.Content.RootPath, "data", "test.bmp")), null);
        }

        public void CreateFromBitmap(Bitmap bitmap, string name)
        {
            Name = name;
            Width = bitmap.Width;
            Height = bitmap.Height;

            BitmapData bmpdata = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            SceneManager.Current.Renderer.TexImage2D("Texture2D", 0, "Rgba", bmpdata.Width, bmpdata.Height, 0, "Bgra", "UnsignedByte", bmpdata.Scan0);
            bitmap.UnlockBits(bmpdata);

            Thumb = bitmap.Resize(512, 512);
        }

        public Bitmap GetBitmap(bool suppressAlpha = true)
        {
            //if (SupportingDocuments["Source"] is Bitmap bmp) { return bmp; }

            //if (SupportingDocuments["Source"] is TDX tdx) { return tdx.Decompress(0, suppressAlpha); }

            return new Bitmap(64, 64);
        }

        public Bitmap GetThumbnail(int maxWidth = 128, bool suppressAlpha = true)
        {
            return Thumb.Resize(maxWidth, maxWidth);
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