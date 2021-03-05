using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using Flummery.Core;
using Flummery.Plugin.CarmageddonMaxDamage.ContentPipeline;

using ToxicRagers.Stainless.Formats;

namespace Flummery.Plugin.CarmageddonMaxDamage
{
    public partial class WheelPreview : Form
    {
        List<Wheel> wheels;

        public Model Wheel { get; private set; } = new Model();

        public WheelPreview()
        {
            InitializeComponent();
        }

        private void wheelPreview_Load(object sender, EventArgs e)
        {
            //string zadPath = Path.Combine(Properties.Settings.Default.PathCarmageddonReincarnation, "ZAD");
            //wheels = new List<Wheel>();

            //if (Properties.Settings.Default.PathCarmageddonReincarnation != null &&
            //    Directory.Exists(Properties.Settings.Default.PathCarmageddonReincarnation) &&
            //    Directory.Exists(zadPath)
            //    )
            //{
            //    foreach (string zadFile in Directory.GetFiles(zadPath, "*.zad"))
            //    {
            //        ZAD zad = ZAD.Load(zadFile);

            //        if (!zad.Contains("Vehicles/Wheels/")) { continue; }

            //        foreach (ZADEntry entry in zad.Contents)
            //        {
            //            if (entry.Name.IndexOf("tyre.cnt", StringComparison.InvariantCultureIgnoreCase) < 0) { continue; }

            //            wheels.Add(new Wheel
            //            {
            //                Archive = zadFile,
            //                Path = Path.GetDirectoryName(entry.Name),
            //                WheelName = Path.GetFileName(Path.GetDirectoryName(entry.Name))
            //            });
            //        }
            //    }

            //    lstWheels.Items.AddRange(wheels.Select(wp => wp.WheelName).ToArray<string>());
            //}
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lstWheels.SelectedItem != null)
            {
                Wheel = new Model();

                Wheel wp = wheels[lstWheels.SelectedIndex];
                CNTImporter cntImporter = new CNTImporter();

                Model rim = (Model)cntImporter.Import(Path.Combine(wp.Archive, wp.Path, "rim.cnt"));

                foreach (ModelMesh mesh in rim.Meshes) { Wheel.SetName(mesh.Name, Wheel.AddMesh(mesh, 0)); }
            }

            Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Wheel = null;
            Close();
        }
    }

    public class Wheel
    {
        public string Archive { get; set; }

        public string Path { get; set; }

        public string WheelName { get; set; }
    }
}