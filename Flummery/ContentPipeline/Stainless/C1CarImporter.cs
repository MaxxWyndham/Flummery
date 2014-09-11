using System;
using System.Collections.Generic;

using ToxicRagers.Carmageddon.Formats;

namespace Flummery.ContentPipeline.Stainless
{
    class C1CarImporter : ContentImporter
    {
        public override string GetExtension() { return "txt"; }

        public override Asset Import(string path)
        {
            Car car = Car.Load(path);
            Model model = new Model();

            foreach (var pixelmap in car.Pixelmaps[2])
            {
                SceneManager.Current.Content.LoadMany<TextureList, PIXImporter>(pixelmap, path);
            }

            var actors = new List<Model>();
            for (int i = 0; i < car.Actors.Count; i++)
            {
                actors.Add(SceneManager.Current.Content.Load<Model, ACTImporter>(car.Actors[i], path));

                if (car.ActorLODs[i] == 0) { model = actors[i]; }
            }

            SceneManager.Current.UpdateProgress(string.Format("Loaded {0}", car.Name));

            return model;
        }
    }
}
