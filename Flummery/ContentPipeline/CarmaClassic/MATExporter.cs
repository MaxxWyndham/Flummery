using ToxicRagers.Carmageddon2.Formats;

namespace Flummery.ContentPipeline.CarmaClassic
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
