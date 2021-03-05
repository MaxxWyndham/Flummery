using ToxicRagers.CarmageddonReincarnation.Formats;

using Flummery.Core.ContentPipeline;
using Flummery.Core;

namespace Flummery.Plugin.CarmageddonMaxDamage.ContentPipeline
{
    public class VehicleSetupCFGExporter : ContentExporter
    {
        public override void Export(Asset asset, string path)
        {
            Model model = (asset as Model);

            if (model.SupportingDocuments.ContainsKey("VehicleSetupConfig"))
            {
                ((VehicleSetupConfig)model.SupportingDocuments["VehicleSetupConfig"]).Save(path);
            }
            else
            {
                VehicleSetupConfig vehicleSetup = new VehicleSetupConfig();

                vehicleSetup.Attachments.Add(
                    new VehicleAttachment
                    {
                        Type = VehicleAttachment.AttachmentType.DynamicsWheels
                    }
                );

                vehicleSetup.WheelModules.Add(
                    new VehicleWheelModule
                    {
                        Type = VehicleWheelModule.WheelModuleType.SkidMarks,
                        SkidMarkImage = "skidmark"
                    }
                );

                vehicleSetup.WheelModules.Add(
                    new VehicleWheelModule
                    {
                        Type = VehicleWheelModule.WheelModuleType.TyreParticles,
                        TyreParticleVFX = "effects.drift"
                    }
                );

                vehicleSetup.WheelModules.Add(
                    new VehicleWheelModule
                    {
                        Type = VehicleWheelModule.WheelModuleType.SkidNoise,
                        SkidNoiseSound = "sounds\\tyre\\skid1,sounds\\tyre\\skid2"
                    }
                );

                vehicleSetup.Attachments.Add(
                    new VehicleAttachment
                    {
                        Type = VehicleAttachment.AttachmentType.Horn,
                        Horn = "generic02_horn"
                    }
                );

                vehicleSetup.WheelMaps.Add(
                    new VehicleWheelMap
                    {
                        Name = "default",
                        Localisation = $"FE_CAR_{ExportSettings.GetSetting<string>("VehicleName")}_RIM_DEFAULT",
                        Wheels = new VehicleAttachmentComplicatedWheels
                        {
                            FLWheel = "default_eagle_R",
                            FRWheel = "default_eagle_R",
                            RLWheel = "default_eagle_R",
                            RRWheel = "default_eagle_R"
                        }
                    }
                );

                vehicleSetup.Stats.TopSpeed = 160;
                vehicleSetup.Stats.Time = 3.00f;
                vehicleSetup.Stats.Weight = 1.3f;
                vehicleSetup.Stats.Toughness = 1.4f;
                vehicleSetup.Stats.UnlockLevel = 0;

                vehicleSetup.Save(path);
            }
        }
    }
}