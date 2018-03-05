using ToxicRagers.CarmageddonReincarnation.Formats;

namespace Flummery.ContentPipeline.NuCarma
{
    class VehicleSetupLOLExporter : ContentExporter
    {
        public override void Export(Asset asset, string path)
        {
            Model model = (asset as Model);

            if (model.SupportingDocuments.ContainsKey("VehicleSetup"))
            {
                ((VehicleSetup)model.SupportingDocuments["VehicleSetup"]).Save(path);
            }
            else
            {
            }
        }
    }
}
