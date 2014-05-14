using System;
using System.IO;
using ToxicRagers.TDR2000.Formats;
using Flummery.ContentPipeline.Core;

namespace Flummery.ContentPipeline.TDR2000
{
    class TXImporter : ContentImporter
    {
        public override string GetExtension() { return "tx"; }

        public override Asset Import(string path)
        {
            string name = Path.GetFileNameWithoutExtension(path);
            var m = TX.Load(path);

            return new Material() { Name = name, Texture = SceneManager.Current.Content.Load<Texture, TGAImporter>(m.FileName, Path.GetDirectoryName(path)) };
        }
    }
}
