﻿using System.IO;

using ToxicRagers.Helpers;
using ToxicRagers.TDR2000.Formats;

using Flummery.Core.ContentPipeline;
using Flummery.Core;

namespace Flummery.Plugin.TDR2000.ContentPipeline
{
    public class HIEExporter : ContentExporter
    {
        static string rootPath;

        public override void Export(Asset asset, string path)
        {
            rootPath = Path.GetDirectoryName(path);

            Model model = asset as Model;
            HIE hie = new HIE();

            TravelTree(model.Root, hie, true);

            hie.Save(path);
        }

        public static void TravelTree(ModelBone bone, HIE hie, bool root = false)
        {
            //hie.Name = bone.Name;
            //hie.Transform = new Matrix3D(
            //                    bone.Transform.M11, bone.Transform.M12, bone.Transform.M13,
            //                    bone.Transform.M21, bone.Transform.M22, bone.Transform.M23,
            //                    bone.Transform.M31, bone.Transform.M32, bone.Transform.M33,
            //                    bone.Transform.M41, bone.Transform.M42, bone.Transform.M43
            //                );

            //switch (bone.Type)
            //{
            //    case BoneType.Mesh:
            //        cnt.Section = CNT.NodeType.MODL;
            //        cnt.Model = bone.Mesh.Name;
            //        break;

            //    case BoneType.Light:
            //        cnt.Section = CNT.NodeType.LITg;

            //        cnt.EmbeddedLight = (bone.AttachmentFile == null);

            //        if (cnt.EmbeddedLight)
            //        {
            //            cnt.Light = (LIGHT)bone.Attachment;
            //        }
            //        else
            //        {
            //            cnt.LightName = bone.AttachmentFile;

            //            if (bone.Attachment is LIGHT light)
            //            {
            //                light.Save(Path.Combine(rootPath, cnt.LightName + ".light"));
            //            }
            //        }
            //        break;

            //    case BoneType.VFX:
            //        cnt.Section = CNT.NodeType.VFXI;
            //        cnt.VFXFile = bone.AttachmentFile;
            //        break;

            //    default:
            //        cnt.Section = CNT.NodeType.NULL;
            //        break;
            //}

            foreach (ModelBone b in bone.Children) { TravelTree(b, hie); }

            //if (!root) { parent.Children.Add(hie); }
        }
    }
}
