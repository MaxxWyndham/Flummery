using System;
using System.Diagnostics;
using System.Drawing;

using ToxicRagers.CarmageddonReincarnation.Formats;
using ToxicRagers.Helpers;

using Flummery.Core.ContentPipeline;
using Flummery.Core;

namespace Flummery.Plugin.CarmageddonMaxDamage.ContentPipeline
{
    public class TDXExporter : ContentExporter
    {
        public override void Export(Asset asset, string path)
        {
            Texture texture = (asset as Texture);
            TDX tdx = (texture.SupportingDocuments["Source"] as TDX);

            Stopwatch sw = new Stopwatch();
            sw.Start();

            if (tdx == null)
            {
                SceneManager.Current.UpdateProgress($"Saving {texture.Name}");

                tdx = TDX.LoadFromBitmap(texture.SupportingDocuments["Source"] as Bitmap, texture.Name, settings.GetSetting<D3DFormat>("Format"));
                tdx.SetFlags(TDX.Flags.sRGB);
            }

            //tdx.Save(Path.Combine(path, $"{texture.Name}.tdx"));
            tdx.Save(path);

            sw.Stop();
            Console.WriteLine(sw.Elapsed);

            SceneManager.Current.UpdateProgress($"{texture.Name}.tdx saved!");
        }
    }
}