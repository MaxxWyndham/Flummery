using System;
using System.Collections.Generic;
using System.IO;

using ToxicRagers.Helpers;
using ToxicRagers.Stainless.Formats;

using OpenTK;

namespace Flummery.ContentPipeline.Stainless
{
    class IMGImporter : ContentImporter
    {
        public override string GetExtension() { return "img"; }

        public override Asset Import(string path)
        {
            var img = IMG.Load(path);
            Texture texture = new Texture();

            texture.CreateFromBitmap(img.ExportToBitmap(), Path.GetFileNameWithoutExtension(path));
            texture.FileName = path;

            return texture;
        }
    }
}
