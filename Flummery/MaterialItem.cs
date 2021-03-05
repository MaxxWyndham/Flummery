using System;
using System.Drawing;
using System.Windows.Forms;

using Flummery.Core;

namespace Flummery.Controls
{
    public partial class MaterialItem : UserControl
    {
        Material m;

        public string MaterialName
        {
            get => lblName.Text;
            set
            {
                ttInfo.SetToolTip(pbThumb, value);
                ttInfo.SetToolTip(lblName, value);
                lblName.Text = value;
            }
        }

        public Material Material
        {
            get => m;
            set => m = value;
        }

        public MaterialItem()
        {
            InitializeComponent();

            Click += new EventHandler(materialItem_Click);
            DoubleClick += new EventHandler(materialItem_DoubleClick);

            foreach (Control c in Controls)
            {
                c.Click += new EventHandler(materialItem_Click);
                c.DoubleClick += new EventHandler(materialItem_DoubleClick);
            }
        }

        void materialItem_Click(object sender, EventArgs e)
        {
            Form editor;

            switch (SceneManager.Current.Game)
            {
                case ContextGame.CarmageddonMaxDamage:
                    editor = new frmNuCarmaMaterialEditor(this, m);
                    break;

                case ContextGame.Carmageddon1:
                case ContextGame.Carmageddon2:
                    editor = new frmClassicMaterialEditor(this, m);
                    break;

                default:
                    editor = new frmMaterialEditor(this, m);
                    break;
            }

            if (editor.ShowDialog(ParentForm) == DialogResult.OK)
            {
                SceneManager.Current.Change(ChangeType.Munge, ChangeContext.Material, -1, m);
            }
        }

        void materialItem_DoubleClick(object sender, EventArgs e)
        {
        }

        public void SetThumbnail(Bitmap b)
        {
            pbThumb.Image = b;
        }
    }
}