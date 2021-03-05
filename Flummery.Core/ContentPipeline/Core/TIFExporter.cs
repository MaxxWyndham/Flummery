using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Flummery.Core.ContentPipeline
{
    public class TIFExporter : ContentExporter
    {
        public override void Export(Asset asset, string path)
        {
            Texture texture = (asset as Texture);
            Bitmap b = texture.GetBitmap();

            SceneManager.Current.UpdateProgress($"Saving {texture.Name}");

            b.Save(path, ImageFormat.Tiff);

            SceneManager.Current.UpdateProgress($"{Path.GetFileName(path)} saved!");
        }
    }
}
