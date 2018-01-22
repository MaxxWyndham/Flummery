using System;
using System.Drawing;
using System.Windows.Forms;

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

        public event EventHandler DblClick;
        public event EventHandler SngClick;

        public MaterialItem()
        {
            InitializeComponent();

            Click += new EventHandler(MaterialItem_Click);
            DoubleClick += new EventHandler(MaterialItem_DoubleClick);

            foreach (Control c in Controls)
            {
                c.Click += new EventHandler(MaterialItem_Click);
                c.DoubleClick += new EventHandler(MaterialItem_DoubleClick);
            }
        }

        void MaterialItem_Click(object sender, EventArgs e)
        {
            Form editor;

            switch (SceneManager.Current.CurrentGame)
            {
                case ContextGame.CarmageddonReincarnation:
                    editor = new frmReincarnationMaterialEditor(this, m);
                    break;

                default:
                    editor = new frmMaterialEditor(this, m);
                    break;
            }

            editor.ShowDialog(ParentForm);

            SngClick?.Invoke(this, e);
        }

        void MaterialItem_DoubleClick(object sender, EventArgs e)
        {
            DblClick?.Invoke(this, e);
        }

        public void SetThumbnail(Bitmap b)
        {
            pbThumb.Image = b;
        }
    }
}