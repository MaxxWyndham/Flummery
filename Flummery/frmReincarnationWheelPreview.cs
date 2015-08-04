using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using Flummery.ContentPipeline.Stainless;

namespace Flummery
{
    public partial class frmReincarnationWheelPreview : Form
    {
        List<WheelPreview> wheels;
        Model wheel = new Model();

        public Model Wheel { get { return wheel; } }

        public frmReincarnationWheelPreview()
        {
            InitializeComponent();
        }

        private void frmReincarnationWheelPreview_Load(object sender, EventArgs e)
        {
            string zadPath = Path.Combine(Properties.Settings.Default.PathCarmageddonReincarnation, "ZAD");
            wheels = new List<WheelPreview>();

            if (Properties.Settings.Default.PathCarmageddonReincarnation != null && 
                Directory.Exists(Properties.Settings.Default.PathCarmageddonReincarnation) &&
                Directory.Exists(zadPath)
                )
            {
                foreach (string wheelZAD in Directory.GetFiles(zadPath, "Wheels_*"))
                {
                    var zad = ToxicRagers.Stainless.Formats.ZAD.Load(wheelZAD);

                    foreach (var entry in zad.Contents)
                    {
                        if (entry.Name.IndexOf("tyre.cnt", StringComparison.InvariantCultureIgnoreCase) < 0) { continue; }

                        wheels.Add(new WheelPreview
                        {
                            Archive = wheelZAD,
                            Path = Path.GetDirectoryName(entry.Name),
                            WheelName = Path.GetFileName(Path.GetDirectoryName(entry.Name))
                        });
                    }
                }

                lstWheels.Items.AddRange(wheels.Select(wp => wp.WheelName).ToArray<string>());
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lstWheels.SelectedItem != null)
            {
                wheel = new Model();

                WheelPreview wp = wheels[lstWheels.SelectedIndex];
                CNTImporter cntImporter = new CNTImporter();

                var rim = (Model)cntImporter.Import(Path.Combine(wp.Archive, wp.Path, "rim.cnt"));
                //var tyre = (Model)cntImporter.Import(wheelsFolder + lstWheels.SelectedItem + "\\tyre.cnt");

                foreach (var mesh in rim.Meshes) { wheel.SetName(mesh.Name, wheel.AddMesh(mesh, 0)); }
                //foreach (var mesh in tyre.Meshes) { wheel.SetName(mesh.Name, wheel.AddMesh(mesh, 0)); }
            }

            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            wheel = null;
            this.Close();
        }
    }

    public class WheelPreview
    {
        string archive;
        string path;
        string wheelName;

        public string Archive
        {
            get { return archive; }
            set { archive = value; }
        }

        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        public string WheelName
        {
            get { return wheelName; }
            set { wheelName = value; }
        }
    }
}
