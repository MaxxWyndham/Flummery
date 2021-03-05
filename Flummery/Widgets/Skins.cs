using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using ToxicRagers.CarmageddonReincarnation.Formats;

using Flummery.Core;

namespace Flummery.Controls
{
    public partial class Skins : UserControl, IWidget
    {
        bool bExpanded = true;
        VehicleSetupConfig config = null;
        Material paint = null;
        List<ModelMeshPart> parts = new List<ModelMeshPart>();

        public Skins()
        {
            InitializeComponent();

            Dock = DockStyle.Top;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;

            resetWidget();

        }

        public void RegisterEventHandlers()
        {
            SceneManager.Current.OnSelectRoot += scene_OnSelectRoot;
        }

        void scene_OnSelectRoot(object sender, SelectRootEventArgs e)
        {
            config = (
                e.Mode == ContextMode.Car && 
                e.Game == ContextGame.CarmageddonMaxDamage &&
                SceneManager.Current.SelectedModel.SupportingDocuments.ContainsKey("VehicleSetupConfig") ? 
                SceneManager.Current.SelectedModel.GetSupportingDocument<VehicleSetupConfig>("VehicleSetupConfig") : 
                null
            );

            resetWidget();
        }

        private void resetWidget()
        {
            pnlPanel.Controls.Clear();

            if (config != null)
            {
                paint = (Material)SceneManager.Current.Materials.Entries.Where(m => m.Name.ToLower() == "paint").First();

                foreach (ModelMesh mesh in SceneManager.Current.SelectedModel.Meshes)
                {
                    foreach (ModelMeshPart part in mesh.MeshParts)
                    {
                        if (part.Material == paint)
                        {
                            parts.Add(part);
                        }
                    }
                }

                for (int i = 0; i < config.MaterialMaps.Count; i++)
                {
                    VehicleMaterialMap map = config.MaterialMaps[i];

                    pnlPanel.Controls.Add(
                        new Label
                        {
                            Text = map.Localisation,
                            AutoSize = true,
                            Location = new Point(5, 12 + (i * 27)),
                        }
                    );

                    Button eye = new Button
                    {
                        Image = (i == 0 ? Properties.Resources.interface_eye_16x16 : Properties.Resources.interface_eye_blind_16x16),
                        Size = new Size(25, 25),
                        Location = new Point(pnlPanel.Width - 30, 5 + (i * 27)),
                        Anchor = AnchorStyles.Top | AnchorStyles.Right,
                        Tag = i
                    };

                    eye.Click += eye_Click;

                    pnlPanel.Controls.Add(eye);
                }
            }
        }

        private void eye_Click(object sender, EventArgs e)
        {
            foreach (Control control in pnlPanel.Controls)
            {
                if (control is Button button)
                {
                    button.Image = Properties.Resources.interface_eye_blind_16x16;
                }
            }

            Button eye = (Button)sender;

            eye.Image = Properties.Resources.interface_eye_16x16;

            VehicleMaterialMap map = config.MaterialMaps[(int)eye.Tag];
            Material altPaint = (Material)SceneManager.Current.Materials.Entries.Where(m => string.Compare(m.Name, map.Substitutions.FirstOrDefault().Value ?? "paint", true) == 0).First();

            foreach (ModelMeshPart part in parts) { part.Material = altPaint; }
        }

        private void btnPanelTitle_Click(object sender, EventArgs e)
        {
            bExpanded = !bExpanded;

            pnlPanel.Visible = bExpanded;
        }
    }
}
