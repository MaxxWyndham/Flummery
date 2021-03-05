using System.Drawing;
using System.IO;

namespace Flummery.Core.ContentPipeline
{
    public class TIFImporter : ContentImporter
    {
        public override string GetExtension() { return "tif"; }

        public override string GetHints(string currentPath) 
        {
            string hints = "";

            if (currentPath != null) 
            {
                if (currentPath.EndsWith(@"\")) { currentPath = Path.GetDirectoryName(currentPath); }

                hints += $"{Path.Combine(currentPath, "tiffrgb")};";
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

            using (Bitmap bitmap = new Bitmap(path)) { texture.CreateFromBitmap(bitmap, Path.GetFileNameWithoutExtension(path)); }

            return texture;
        }
    }
}
