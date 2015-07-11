using System;
using System.IO;

using ToxicRagers.CarmageddonReincarnation.Formats;

namespace Flummery.ContentPipeline.Stainless
{
    class VehicleSetupCFGExporter : ContentExporter
    {
        public override void Export(Asset asset, string path)
        {
            var model = (asset as Model);

            if (model.SupportingDocuments.ContainsKey("VehicleSetupConfig"))
            {
                ((VehicleSetupConfig)model.SupportingDocuments["VehicleSetupConfig"]).Save(path);
            }
            else
            {
                var vehicleSetup = new VehicleSetupConfig();

                vehicleSetup.Attachments.Add(
                    new VehicleAttachment { 
                        Type = VehicleAttachment.AttachmentType.DynamicsWheels 
                    }
                );

                vehicleSetup.WheelModules.Add(
                    new VehicleWheelModule { 
                        Type = VehicleWheelModule.WheelModuleType.SkidMarks, 
                        SkidMarkImage = "skidmark" 
                    }
                );

                vehicleSetup.WheelModules.Add(
                    new VehicleWheelModule { 
                        Type = VehicleWheelModule.WheelModuleType.TyreParticles, 
                        TyreParticleVFX = "effects.drift" 
                    }
                );

                vehicleSetup.WheelModules.Add(
                    new VehicleWheelModule { 
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
                        Localisation = string.Format("FE_CAR_{0}_RIM_DEFAULT", this.ExportSettings.GetSetting<string>("VehicleName")),
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
