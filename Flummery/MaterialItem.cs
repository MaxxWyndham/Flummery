using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flummery.Controls
{
    public partial class MaterialItem : UserControl
    {
        Material m;

        public string MaterialName
        {
            get { return lblName.Text; }
            set
            {
                ttInfo.SetToolTip(pbThumb, value);
                ttInfo.SetToolTip(lblName, value);
                lblName.Text = value;
            }
        }

        public Material Material
        {
            get { return m; }
            set { m = value; }
        }

        public event EventHandler DblClick;
        public event EventHandler SngClick;

        public MaterialItem()
        {
            InitializeComponent();

            this.Click += new EventHandler(MaterialItem_Click);
            this.DoubleClick += new EventHandler(MaterialItem_DoubleClick);

            foreach (Control c in this.Controls)
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
                case ContextGame.Carmageddon_Reincarnation:
                    editor = new frmReincarnationMaterialEditor(this, m);
                    break;

                default:
                    editor = new frmMaterialEditor(this, m);
                    break;
            }

            editor.ShowDialog(this.ParentForm);

            if (SngClick != null) { SngClick(this, e); }
        }

        void MaterialItem_DoubleClick(object sender, EventArgs e)
        {
            if (DblClick != null) { DblClick(this, e); }
        }

        public void SetThumbnail(Bitmap b)
        {
            pbThumb.Image = b;
        }
    }
}
