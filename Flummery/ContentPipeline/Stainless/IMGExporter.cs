using System;
using System.Drawing;
using System.IO;

using ToxicRagers.Stainless.Formats;
using ToxicRagers.Helpers;

namespace Flummery.ContentPipeline.Stainless
{
    class IMGExporter : ContentExporter
    {
        public override void Export(Asset asset, string path)
        {
            var texture = (asset as Texture);
            var img = new IMG();
            var b = (texture.SupportingDocuments["Source"] as Bitmap);

            SceneManager.Current.UpdateProgress(string.Format("Saving {0}", texture.Name));

            img.Name = texture.Name;
            img.ImportFromBitmap(b);

            SceneManager.Current.UpdateProgress(string.Format("Compressing {0} (this may take a moment)", texture.Name));
            img.Save(Path.GetDirectoryName(path) + "\\" + texture.Name + ".img");

            SceneManager.Current.UpdateProgress(string.Format("{0}.img saved!", texture.Name));
        }
    }
}
