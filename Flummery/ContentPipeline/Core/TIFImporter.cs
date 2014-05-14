using System;
using System.Drawing;
using System.IO;

namespace Flummery.ContentPipeline.Core
{
    class TIFImporter : ContentImporter
    {
        public override string GetExtension() { return "tif"; }

        public override string GetHints(string currentPath) 
        {
            string hints = "";

            if (currentPath != null) 
            {
                if (currentPath.EndsWith("\\")) { currentPath = currentPath.Substring(0, currentPath.Length - 1); }
                hints += currentPath + "\\tiffrgb\\";
                if (currentPath.Contains("\\data\\races\\")) { hints += ";" + currentPath.Substring(0, currentPath.LastIndexOf("\\") + 5) + "\\tiffrgb\\"; }

                return hints;
            }

            return null;
        }

        public override Asset Import(string path)
        {
            Texture texture = new Texture();

            var fi = new FileInfo(path);
            using (var bitmap = new Bitmap(path)) { texture.CreateFromBitmap(bitmap, fi.Name.Replace(fi.Extension, "")); }

            return texture;
        }
    }
}
