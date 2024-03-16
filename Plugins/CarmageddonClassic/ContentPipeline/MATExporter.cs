using ToxicRagers.Brender.Formats;

using Flummery.Core.ContentPipeline;
using Flummery.Core;

namespace Flummery.Plugin.CarmageddonClassic.ContentPipeline
{
    class MATExporter : ContentExporter
    {
        public override void Export(AssetList asset, string path)
        {
            MaterialList materials = (asset as MaterialList);
            MAT mat = new MAT();

            foreach (Material material in materials.Entries) 
            {
                if (material == null) { continue; }
                if (material.Texture == null) { continue; }

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
