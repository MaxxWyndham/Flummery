using System.IO;

using ToxicRagers.Core.Formats;

namespace Flummery.Core.ContentPipeline
{
    public class DDSImporter : ContentImporter
    {
        public override string GetExtension() { return "dds"; }

        public override Asset Import(string path)
        {
            Texture texture = new Texture
            {
                FileName = path
            };

            texture.CreateFromBitmap(DDS.Load(path).Decompress(), Path.GetFileNameWithoutExtension(path));

            return texture;
        }
    }
}
