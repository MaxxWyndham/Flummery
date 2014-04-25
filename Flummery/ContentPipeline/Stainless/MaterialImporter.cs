using System;
using System.Collections.Generic;
using System.IO;
using ToxicRagers.CarmageddonReincarnation.Formats;
using ToxicRagers.Helpers;
using ToxicRagers.Stainless.Formats;
using OpenTK;

namespace Flummery.ContentPipeline.Stainless
{
    class MaterialImporter : ContentImporter
    {
        public override string GetExtension() { return "mt2;mtl"; }

        public override Asset Import(string path)
        {
            Material material;

            if (path.EndsWith("mt2", StringComparison.OrdinalIgnoreCase))
            {
                material = MT2.Load(path);
            }
            else
            {
                material = MTL.Load(path);
            }

            var mat = (material as MT2);
            string fileName = (mat != null ? mat.DiffuseColour : (material as MTL).Textures[0]);

            if (fileName == "")
            {
                return new Texture() { Name = fileName };
            }
            else
            {
                return SceneManager.Scene.Content.Load<Texture, TDXImporter>(fileName);
            }
        }
    }
}
