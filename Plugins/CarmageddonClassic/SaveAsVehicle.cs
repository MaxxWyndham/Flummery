using Flummery.Core;
using Flummery.Plugin.CarmageddonClassic.ContentPipeline;

using ToxicRagers.Brender.Formats;
using ToxicRagers.Helpers;

namespace Flummery.Plugin.CarmageddonClassic
{
    public partial class SaveAsVehicle : Form
    {
        FlumpFile flump;
        string car;

        Label lblInfo = null;
        Label lblProgress = null;
        readonly System.Timers.Timer timer = new System.Timers.Timer(200);
        readonly string[] frames = new string[] { "◐", "◓", "◑", "◒" };
        int progressMax = 0;

        public SaveAsVehicle()
        {
            InitializeComponent();

            timer.AutoReset = true;
            timer.SynchronizingObject = this;
            timer.Elapsed += timer_Elapsed;

            //txtPath.Text = Properties.Settings.Default.SaveAsVehiclePath;
            setCar();
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            fbdBrowse.SelectedPath = txtPath.Text;

            if (fbdBrowse.ShowDialog() == DialogResult.OK)
            {
                if (!Directory.Exists(fbdBrowse.SelectedPath)) { Directory.CreateDirectory(fbdBrowse.SelectedPath); }

                txtPath.Text = fbdBrowse.SelectedPath;

                setCar();

                //Properties.Settings.Default.SaveAsVehiclePath = txtPath.Text;
                //Properties.Settings.Default.Save();
            }
        }

        private void txtCarName_TextChanged(object sender, EventArgs e)
        {
            setCar();
        }

        private void setCar()
        {
            if (txtPath.Text.Length == 0 || txtCarName.Text.Length == 0)
            {
                btnOK.Enabled = false;

                return;
            }

            btnOK.Enabled = true;

            car = txtCarName.Text;

            flump = FlumpFile.Load(Path.Combine(txtPath.Text, $"{car}.flump"));
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            List<string> folders = new List<string> { "ACTORS", "CARS", "MATERIAL", "MODELS", "PIXELMAP" };

            SceneManager.Current.OnProgress += scene_OnProgress;

            btnOK.Visible = false;
            btnCancel.Visible = false;

            gbProgress.Visible = true;
            pbProgress.Visible = true;

            Application.DoEvents();
            timer.Start();

            if (!Directory.Exists(txtPath.Text)) { Directory.CreateDirectory(txtPath.Text); }

            foreach (string folder in folders)
            {
                if (!Directory.Exists(Path.Combine(txtPath.Text, folder))) { Directory.CreateDirectory(Path.Combine(txtPath.Text, folder)); }
            }

            flump.Settings["car"] = car;

            lblInfo = lblInfoMeshes;
            lblProgress = lblProgressMeshes;
            lblProgress.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
            progressMax = 25;

            string bon = $"{car.Substring(0, Math.Min(car.Length, 5))}BON";
            string lod = $"{car.Substring(0, Math.Min(car.Length, 7))}X";

            ACT act = new ACT();

            act.AddActor(
                SceneManager.Current.Models[0].Root.Name,
                SceneManager.Current.Models[0].Root.Mesh.Name,
                (Matrix3D)SceneManager.Current.Models[0].Root.Transform,
                true);

            act.Save(Path.Combine(txtPath.Text, "ACTORS", $"{bon}.ACT"));
            new ACTExporter().Export(SceneManager.Current.Models[0], Path.Combine(txtPath.Text, "ACTORS", $"{car}.ACT"));
            act.Save(Path.Combine(txtPath.Text, "ACTORS", $"{lod}.ACT"));

            new DATExporter().Export(SceneManager.Current.Models[0], Path.Combine(txtPath.Text, "MODELS", $"{car}.DAT"));

            lblProgress.Text = "✓";
            lblProgress.ForeColor = Color.Green;
            lblInfo.Text = "Meshes";
            pbProgress.Value = progressMax;

            Application.DoEvents();

            lblInfo = lblInfoTextures;
            lblProgress = lblProgressTextures;
            lblProgress.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
            progressMax = 50;

            new PIXExporter().Export(SceneManager.Current.Materials, Path.Combine(txtPath.Text, "PIXELMAP", $"{car}.PIX"));

            lblProgress.Text = "✓";
            lblProgress.ForeColor = Color.Green;
            lblInfo.Text = "Textures";
            pbProgress.Value = progressMax;

            Application.DoEvents();

            lblInfo = lblInfoMaterials;
            lblProgress = lblProgressMaterials;
            lblProgress.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
            progressMax = 75;

            new MATExporter().Export(SceneManager.Current.Materials, Path.Combine(txtPath.Text, "MATERIAL", $"{car}.MAT"));

            lblProgress.Text = "✓";
            lblProgress.ForeColor = Color.Green;
            lblInfo.Text = "Materials";
            pbProgress.Value = progressMax;

            Application.DoEvents();

            lblInfo = lblInfoPaperwork;
            lblProgress = lblProgressPaperwork;
            lblProgress.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
            progressMax = 100;

            C1CarExporter cx = new C1CarExporter();
            cx.ExportSettings.AddSetting("CarName", car);
            cx.Export(SceneManager.Current.Models[0], Path.Combine(txtPath.Text, "CARS", $"{car}.TXT"));

            lblProgress.Text = "✓";
            lblProgress.ForeColor = Color.Green;
            lblInfo.Text = "Paperwork";
            pbProgress.Value = progressMax;

            flump.Save(Path.Combine(txtPath.Text, $"{car}.flump"));

            timer.Stop();
            SceneManager.Current.OnProgress -= scene_OnProgress;

            btnClose.Visible = true;

            Application.DoEvents();

            SceneManager.Current.UpdateProgress($"Vehicle '{car}' saved successfully!");
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (lblProgress != null && lblProgress.Text != "✓")
            {
                int frame = lblProgress.Tag == null ? 0 : int.Parse(lblProgress.Tag.ToString());

                lblProgress.Text = frames[frame++];

                if (frame == 4) { frame = 0; }

                lblProgress.Tag = frame;
            }

            if (pbProgress.Value < progressMax) { pbProgress.Value += Math.Max(1, (int)((progressMax - pbProgress.Value) * 0.01f)); }

            Application.DoEvents();
        }

        void scene_OnProgress(object sender, ProgressEventArgs e)
        {
            if (lblInfo != null) { lblInfo.Text = e.Status; }
        }
    }
}