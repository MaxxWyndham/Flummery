using System;
using System.Collections.Generic;
using System.IO;
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

            rootPath = Path.GetDirectoryName(path);

            processCNT(cnt, model);

            SceneManager.Current.UpdateProgress(string.Format("Loaded {0}", cnt.Name));

            return model;
        }

        static void processCNT(CNT cnt, Model model, int ParentBoneIndex = 0)
        {
            int boneIndex;

            SceneManager.Current.UpdateProgress(string.Format("Processing {0}", cnt.Name));

            if (cnt.Section == CNT.NodeType.MODL || cnt.Section == CNT.NodeType.SKIN)
            {
                Model m = SceneManager.Current.Content.Load<Model, MDLImporter>(cnt.Model, rootPath);
                boneIndex = model.AddMesh(m.Meshes[0], ParentBoneIndex);
            }
            else
            {
                boneIndex = model.AddMesh(null, ParentBoneIndex);

                switch (cnt.Section)
                {
                    case CNT.NodeType.LITg:
                        model.Bones[boneIndex].Type = BoneType.Light;
                        if (cnt.EmbeddedLight)
                        {
                            model.Bones[boneIndex].Attachment = cnt.Light;
                        }
                        else
                        {
                            Model light = SceneManager.Current.Content.Load<Model, LIGHTImporter>(cnt.LightName, rootPath);

                            if (light.Bones.Count > 0)
                            {
                                model.Bones[boneIndex].Attachment = light.Bones[0].Attachment;
                            }
                            else
                            {
                                //SceneManager.Current.RaiseError(cnt.LightName + ".light not found!");
                            }

                            model.Bones[boneIndex].AttachmentFile = cnt.LightName;
                        }
                        break;

                    case CNT.NodeType.VFXI:
                        model.Bones[boneIndex].Type = BoneType.VFX;
                        model.Bones[boneIndex].AttachmentFile = cnt.VFXFile;
                        break;
                }
            }

            model.SetName(cnt.Name, boneIndex);
            model.SetTransform(
                new Matrix4 (
                    cnt.Transform.M11, cnt.Transform.M12, cnt.Transform.M13, 0,
                    cnt.Transform.M21, cnt.Transform.M22, cnt.Transform.M23, 0,
                    cnt.Transform.M31, cnt.Transform.M32, cnt.Transform.M33, 0,
                    cnt.Transform.M41, cnt.Transform.M42, cnt.Transform.M43, 1
                ), boneIndex);

            foreach (CNT subcnt in cnt.Children)
            {
                processCNT(subcnt, model, boneIndex);
            }
        }
    }
}
