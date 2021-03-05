using System;
using System.Collections.Generic;
using System.IO;

using ToxicRagers.Carmageddon.Formats;

using Flummery.Core.ContentPipeline;
using Flummery.Core;

namespace Flummery.Plugin.CarmageddonClassic.ContentPipeline
{
    class C1CarImporter : ContentImporter
    {
        public override string GetExtension() { return "txt"; }

        public override Asset Import(string path)
        {
            Car car = Car.Load(path);
            Model model = new Model();

            foreach (string pixelmap in car.PixelmapsHiRes)
            {
                Console.WriteLine($"Loading {pixelmap}");
                SceneManager.Current.Content.LoadMany<TextureList, PIXImporter>(pixelmap, Path.GetDirectoryName(path));
            }

            foreach (string material in car.MaterialsHiRes)
            {
                Console.WriteLine($"Loading {material}");
                SceneManager.Current.Content.LoadMany<MaterialList, MATImporter>(material, Path.GetDirectoryName(path), true);
            }

            List<Model> actors = new List<Model>();
            for (int i = 0; i < car.Actors.Count; i++)
            {
                actors.Add(SceneManager.Current.Content.Load<Model, ACTImporter>(car.Actors[i], Path.GetDirectoryName(path)));

                if (car.ActorLODs[i] == 0) { model = actors[i]; }
            }

            SceneManager.Current.UpdateProgress($"Loaded {car.Name}");

            model.SupportingDocuments.Add("Car", car);

            return model;
        }
    }
}