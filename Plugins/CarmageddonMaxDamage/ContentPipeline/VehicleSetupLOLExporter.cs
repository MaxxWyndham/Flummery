using ToxicRagers.CarmageddonReincarnation.Formats;

using Flummery.Core.ContentPipeline;
using Flummery.Core;

namespace Flummery.Plugin.CarmageddonMaxDamage.ContentPipeline
{
    public class VehicleSetupLOLExporter : ContentExporter
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
