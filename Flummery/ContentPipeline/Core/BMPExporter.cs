using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Flummery.ContentPipeline.Core
{
    class BMPExporter : ContentExporter
    {
        public override void Export(Asset asset, string path)
        {
            var texture = (asset as Texture);
            var b = texture.GetBitmap();

            SceneManager.Current.UpdateProgress(string.Format("Saving {0}", texture.Name));

            b.Save(path, ImageFormat.Bmp);

            SceneManager.Current.UpdateProgress(string.Format("{0} saved!", Path.GetFileName(path)));
        }
    }
}
