using System;
using System.IO;

using ToxicRagers.CarmageddonReincarnation.Formats;

using Flummery.Core.ContentPipeline;
using Flummery.Core;

namespace Flummery.Plugin.CarmageddonMaxDamage.ContentPipeline
{
    public class LIGHTImporter : ContentImporter
    {
        public override string GetExtension() { return "light"; }

        public override Asset Import(string path)
        {
            LIGHT light = LIGHT.Load(path);
            Model model = new Model();

            SceneManager.Current.UpdateProgress(string.Format("Processing {0}", Path.GetFileName(path)));

            int boneIndex = model.AddMesh(null, 0);
            model.SetName(Path.GetFileNameWithoutExtension(path), boneIndex);
            model.Bones[boneIndex].Type = BoneType.Light;
            model.Bones[boneIndex].Attachment = light;

            SceneManager.Current.UpdateProgress(string.Format("Loaded {0}", Path.GetFileName(path)));

            return model;
        }
    }
}
