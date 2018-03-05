using System;
using System.Collections.Generic;

using ToxicRagers.Carmageddon.Formats;

namespace Flummery.ContentPipeline.CarmaClassic
{
    class C1CarImporter : ContentImporter
    {
        public override string GetExtension() { return "txt"; }

        public override Asset Import(string path)
        {
            Car car = Car.Load(path);
            Model model = new Model();

            foreach (string pixelmap in car.Pixelmaps[2])
            {
                Console.WriteLine($"Loading {pixelmap}");
                SceneManager.Current.Content.LoadMany<TextureList, PIXImporter>(pixelmap, path);
            }

            foreach (string material in car.Materials[2])
            {
                Console.WriteLine($"Loading {material}");
                SceneManager.Current.Content.LoadMany<MaterialList, MATImporter>(material, path, true);
            }

            List<Model> actors = new List<Model>();
            for (int i = 0; i < car.Actors.Count; i++)
            {
                actors.Add(SceneManager.Current.Content.Load<Model, ACTImporter>(car.Actors[i], path));

                if (car.ActorLODs[i] == 0) { model = actors[i]; }
            }

            SceneManager.Current.UpdateProgress($"Loaded {car.Name}");

            model.SupportingDocuments.Add("Car", car);

            return model;
        }
    }
}