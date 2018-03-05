using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

using ToxicRagers.CarmageddonReincarnation.Formats;
using ToxicRagers.Helpers;
using ToxicRagers.Generics;

namespace Flummery.ContentPipeline.NuCarma
{
    class TDXExporter : ContentExporter
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