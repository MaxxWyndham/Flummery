using System;
using System.IO;

using ToxicRagers.CarmageddonReincarnation.Formats;

namespace Flummery.ContentPipeline.Stainless
{
    class SetupLOLExporter : ContentExporter
    {
        public override void Export(Asset asset, string path)
        {
            var model = (asset as Model);

            if (model.SupportingDocuments.ContainsKey("Setup"))
            {
                ((Setup)model.SupportingDocuments["Setup"]).Save(path);
            }
            else
            {
                var setup = new Setup();

                switch (ExportSettings.GetSetting<SetupContext>("Context"))
                {
                    case SetupContext.Vehicle:
                        setup.Settings = new VehicleSetupCode();
                        break;
                }

                setup.Save(path);
            }
        }
    }
}
