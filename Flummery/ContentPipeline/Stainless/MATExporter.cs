using System;

using thatGameEngine;
using thatGameEngine.ContentPipeline;
using ToxicRagers.Carmageddon2.Formats;

namespace Flummery.ContentPipeline.Stainless
{
    class MATExporter : ContentExporter
    {
        public override void Export(AssetList asset, string path)
        {
            var materials = (asset as MaterialList);
            var mat = new MAT();

            foreach (Material material in materials.Entries) 
            {
                mat.Materials.Add(
                    new MATMaterial(
                        material.Name,
                        material.Texture.Name
                    )
                );
            }

            mat.Save(path);
        }
    }
}
