using System.IO;

using ToxicRagers.TDR2000.Formats;

using Flummery.Core.ContentPipeline;
using Flummery.Core;

namespace Flummery.Plugin.TDR2000.ContentPipeline
{
    public class TXImporter : ContentImporter
    {
        public override string GetExtension() { return "tx"; }

        public override Asset Import(string path)
        {
            string name = Path.GetFileNameWithoutExtension(path);
            TX m = TX.Load(path);

            return new Material
            {
                Name = name,
                Texture = SceneManager.Current.Content.Load<Texture, TGAImporter>(m.FileName, Path.GetDirectoryName(path))
            };
        }
    }
}
