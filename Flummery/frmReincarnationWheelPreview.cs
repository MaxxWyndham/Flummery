using System;
using System.IO;
using System.Windows.Forms;
using Flummery.ContentPipeline.Stainless;

namespace Flummery
{
    public partial class frmReincarnationWheelPreview : Form
    {
        Model wheel = new Model();
        string wheelsFolder;

        public Model Wheel { get { return wheel; } }

        public frmReincarnationWheelPreview()
        {
            InitializeComponent();
        }

        private void frmReincarnationWheelPreview_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.PathCarmageddonReincarnation != null && Directory.Exists(Properties.Settings.Default.PathCarmageddonReincarnation))
            {
                wheelsFolder = Properties.Settings.Default.PathCarmageddonReincarnation + @"Data_Core\Content\Vehicles\Wheels\";
                var wheels = Directory.GetDirectories(wheelsFolder);

                for (int i = 0; i < wheels.Length; i++)
                {
                    lstWheels.Items.Add(wheels[i].Replace(wheelsFolder, ""));
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lstWheels.SelectedItem != null)
            {
                wheel = new Model();

                var cntImporter = new CNTImporter();

                var rim = (Model)cntImporter.Import(wheelsFolder + lstWheels.SelectedItem + "\\rim.cnt");
                var tyre = (Model)cntImporter.Import(wheelsFolder + lstWheels.SelectedItem + "\\tyre.cnt");

                foreach (var mesh in rim.Meshes) { wheel.SetName(mesh.Name, wheel.AddMesh(mesh, 0)); }
                foreach (var mesh in tyre.Meshes) { wheel.SetName(mesh.Name, wheel.AddMesh(mesh, 0)); }
            }

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            wheel = null;
            this.Close();
        }
    }
}
