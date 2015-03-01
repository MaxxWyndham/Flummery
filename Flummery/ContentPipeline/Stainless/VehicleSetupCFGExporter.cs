using System;
using System.IO;

using thatGameEngine;
using thatGameEngine.ContentPipeline;
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
                        Type = VehicleAttachment.AttachmentType.ComplicatedWheels,
                        Wheels = new VehicleAttachmentComplicatedWheels
                        {
                            FLWheel = "default_greybox",
                            FRWheel = "default_greybox",
                            RLWheel = "default_greybox",
                            RRWheel = "default_greybox"
                        }
                    }
                );

                vehicleSetup.Attachments.Add(
                    new VehicleAttachment
                    {
                        Type = VehicleAttachment.AttachmentType.DynamicsFmodEngine,
                        FModEngine = new VehicleAttachmentFModEngine
                        {
                            Engine = "maserati",
                            RPMSmooth = 0.35f,
                            OnLoadSmooth = 0.0045f,
                            OffLoadSmooth = 0.15f
                        }
                    }
                );

                vehicleSetup.Attachments.Add(
                    new VehicleAttachment
                    {
                        Type = VehicleAttachment.AttachmentType.Horn,
                        Horn = "generic02_horn"
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
