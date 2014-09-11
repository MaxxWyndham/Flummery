using System;
using System.Drawing;
using System.IO;

namespace Flummery.ContentPipeline.Core
{
    class BMPImporter : ContentImporter
    {
        public override string GetExtension() { return "bmp"; }

        public override Asset Import(string path)
        {
            Texture texture = new Texture();

            texture.FileName = path;

            using (var bitmap = new Bitmap(path)) { texture.CreateFromBitmap(bitmap, Path.GetFileNameWithoutExtension(path)); }

            return texture;
        }
    }
}
