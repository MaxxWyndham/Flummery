using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Flummery.ContentPipeline.Core
{
    class BMPExporter : ContentExporter
    {
        public override void Export(Asset asset, string Path)
        {
            var texture = (asset as Texture);
            var b = texture.GetBitmap();

            SceneManager.Current.UpdateProgress(string.Format("Saving {0}", texture.Name));

            b.Save(Path, ImageFormat.Bmp);
        }
    }
}
