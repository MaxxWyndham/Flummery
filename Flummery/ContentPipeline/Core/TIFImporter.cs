using System.Drawing;
using System.IO;

using Flummery.ContentPipeline.CarmaClassic;

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
                if (currentPath.EndsWith(@"\")) { currentPath = Path.GetDirectoryName(currentPath); }

                hints += $"{Path.Combine(currentPath, "tiffrgb")};";
                hints += $"{Path.Combine(currentPath, "pix16")};";
                hints += $";{Path.Combine(Path.GetDirectoryName(currentPath), Path.GetFileName(currentPath).Substring(0, 4), "tiffrgb")};";

                return hints;
            }

            return null;
        }

        public override Asset Import(string path)
        {
            Texture texture = new Texture
            {
                FileName = path
            };

            if (string.Compare(Path.GetExtension(path), ".tif", true) == 0)
            {
                using (Bitmap bitmap = new Bitmap(path)) { texture.CreateFromBitmap(bitmap, Path.GetFileNameWithoutExtension(path)); }
            }
            else
            {
                texture = (Texture)(new PIXImporter()).Import(path);
            }

            return texture;
        }
    }
}
