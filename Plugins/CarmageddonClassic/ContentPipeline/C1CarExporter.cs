using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ToxicRagers.Carmageddon.Formats;

using Flummery.Core;
using Flummery.Core.ContentPipeline;

namespace Flummery.Plugin.CarmageddonClassic.ContentPipeline
{
    class C1CarExporter : ContentExporter
    {
        public override void Export(Asset asset, string path)
        {
            Model model = asset as Model;

            if (model.SupportingDocuments.ContainsKey("Car"))
            {
                ((Car)model.SupportingDocuments["Car"]).Save(path);
            }
            else
            {
                string name = ExportSettings.GetSetting<string>("CarName");

                Car car = new Car { Name = $"{name}.TXT" };

                car.GridImages[0] = $"G{name}.PIX";
                car.GridImages[1] = $"G{name}F.PIX";
                car.GridImages[2] = $"G{name}.PIX";

                car.PixelmapsHiRes.Add($"{name}.PIX");
                car.MaterialsHiRes.Add($"{name}.MAT");
                car.Models.Add($"{name}.DAT");
                car.Actors.Add($"{name}.ACT");
                car.ActorLODs.Add(0);
                car.Crushes.Add(new Crush());

                car.Save(path);
            }
        }
    }
}
