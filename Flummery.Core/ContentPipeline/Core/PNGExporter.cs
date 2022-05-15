using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Flummery.Core.ContentPipeline
{
    public class PNGExporter : ContentExporter
    {
        public override void Export(Asset asset, string path)
        {
            Texture texture = (asset as Texture);
            Bitmap b = texture.GetBitmap(false);

            SceneManager.Current.UpdateProgress($"Saving {texture.Name}");

            //using (Bitmap butts = new Bitmap(b.Width, b.Height, PixelFormat.Format24bppRgb))
            //using (Graphics g = Graphics.FromImage(butts))
            //{
            //    g.DrawImageUnscaledAndClipped(b, new Rectangle(Point.Empty, b.Size));
            //    butts.Save(path, ImageFormat.Png);
            //}

            b.Save(path, ImageFormat.Png);

            SceneManager.Current.UpdateProgress($"{Path.GetFileName(path)} saved!");
        }
    }
}