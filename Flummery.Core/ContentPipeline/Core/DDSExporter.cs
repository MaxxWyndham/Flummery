using System.Drawing;
using System.IO;

using ToxicRagers.Core.Formats;

namespace Flummery.Core.ContentPipeline
{
    public class DDSExporter : ContentExporter
    {
        public override void Export(Asset asset, string path)
        {
            Texture texture = asset as Texture;
            Bitmap b = texture.GetBitmap(false);

            SceneManager.Current.UpdateProgress($"Saving {texture.Name}");

            new DDS(ToxicRagers.Helpers.D3DFormat.DXT5, b).Save(path);

            SceneManager.Current.UpdateProgress($"{Path.GetFileName(path)} saved!");
        }
    }
}