using System;
using System.Collections.Generic;
using ToxicRagers.Stainless.Formats;
using OpenTK;

namespace Flummery.ContentPipeline.Stainless
{
    class CNTImporter : ContentImporter
    {
        static string rootPath;

        public override string GetExtension() { return "cnt"; }

        public override Asset Import(string path)
        {
            CNT cnt = CNT.Load(path);
            Model model = new Model();

            rootPath = path.Substring(0, path.LastIndexOf('\\') + 1);

            ProcessCNT(cnt, model);

            SceneManager.Current.UpdateProgress(string.Format("Loaded {0}", cnt.Name));

            return model;
        }

        static void ProcessCNT(CNT cnt, Model model, int ParentBoneIndex = 0)
        {
            int boneIndex;

            SceneManager.Current.UpdateProgress(string.Format("Processing {0}", cnt.Name));

            if (cnt.Model != null)
            {
                var m = SceneManager.Current.Content.Load<Model, MDLImporter>(cnt.Model, rootPath);
                boneIndex = model.AddMesh(m.Meshes[0], ParentBoneIndex);
            }
            else
            {
                boneIndex = model.AddMesh(null, ParentBoneIndex);
            }

            model.SetName(cnt.Name, boneIndex);
            model.SetTransform(
                new Matrix4 (
                    cnt.Transform.M11, cnt.Transform.M12,  cnt.Transform.M13, 0,
                    cnt.Transform.M21, cnt.Transform.M22,  cnt.Transform.M23, 0,
                    cnt.Transform.M31, cnt.Transform.M32,  cnt.Transform.M33, 0,
                    cnt.Transform.M41, cnt.Transform.M42, -cnt.Transform.M43, 1
                ), boneIndex);

            foreach (CNT subcnt in cnt.Children)
            {
                ProcessCNT(subcnt, model, boneIndex);
            }
        }
    }
}
