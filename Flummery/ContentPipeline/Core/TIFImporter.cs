using System;
using System.Drawing;
using System.IO;

using Flummery.ContentPipeline.Stainless;

namespace Flummery.ContentPipeline.Core
{
    class TIFImporter : ContentImporter
    {
        public override string GetExtension() { return "tif;pix"; }

        public override string GetHints(string currentPath) 
        {
            string hints = "";

            if (currentPath != null) 
            {
                if (currentPath.EndsWith("\\")) { currentPath = currentPath.Substring(0, currentPath.Length - 1); }
                hints += currentPath + "\\tiffrgb\\;";
                hints += currentPath + "\\pix16\\";
                if (currentPath.Contains("\\data\\races\\")) { hints += ";" + currentPath.Substring(0, currentPath.LastIndexOf("\\") + 5) + "\\tiffrgb\\"; }

                return hints;
            }

            return null;
        }

        public override Asset Import(string path)
        {
            Texture texture = new Texture();
            texture.FileName = path;

            if (string.Compare(Path.GetExtension(path), ".tif", true) == 0)
            {
                using (var bitmap = new Bitmap(path)) { texture.CreateFromBitmap(bitmap, Path.GetFileNameWithoutExtension(path)); }
            }
            else
            {
                texture = (Texture)(new PIXImporter()).Import(path);
            }

            return texture;
        }
    }
}
