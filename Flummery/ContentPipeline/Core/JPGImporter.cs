using System;
using System.Drawing;
using System.IO;

namespace Flummery.ContentPipeline.Core
{
    class JPGImporter : ContentImporter
    {
        public override string GetExtension() { return "jpg"; }

        public override Asset Import(string path)
        {
            Texture texture = new Texture();

            texture.FileName = path;

            var fi = new FileInfo(path);
            using (var bitmap = new Bitmap(path)) { texture.CreateFromBitmap(bitmap, fi.Name.Replace(fi.Extension, "")); }

            return texture;
        }
    }
}
