using System;
using System.Collections.Generic;
using System.IO;

using OpenTK;
using thatGameEngine;
using thatGameEngine.ContentPipeline;
using ToxicRagers.CarmageddonReincarnation.Formats;
using ToxicRagers.Helpers;
using ToxicRagers.Stainless.Formats;

namespace Flummery.ContentPipeline.Stainless
{
    class TDXImporter : ContentImporter
    {
        public override string GetExtension() { return "tdx"; }

        public override string GetHints(string currentPath)
        {
            string hints = (currentPath != null ? currentPath + ";" : "");

            if (Properties.Settings.Default.PathCarmageddonReincarnation != null)
            {
                if (Directory.Exists(Properties.Settings.Default.PathCarmageddonReincarnation + "Data_Core\\Content\\Textures\\")) { hints = Properties.Settings.Default.PathCarmageddonReincarnation + "Data_Core\\Content\\Textures\\"; }

                return hints;
            }

            return null;
        }

        public override Asset Import(string path)
        {
            Console.WriteLine(path);

            var tdx = TDX.Load(path);
            Texture texture = new Texture();
            
            texture.SetData(tdx.Name, tdx.Format.ToString(), tdx.MipMaps[0].Width, tdx.MipMaps[0].Height, tdx.MipMaps[0].Data);
            texture.SupportingDocuments["Source"] = tdx;
            texture.FileName = path;

            return texture;
        }
    }
}
