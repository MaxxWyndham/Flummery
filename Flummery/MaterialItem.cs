using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flummery
{
    public partial class MaterialItem : UserControl
    {
        public string MaterialName
        {
            get { return lblName.Text; }
            set { lblName.Text = value; }
        }

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

        public event EventHandler DblClick;
        public event EventHandler SngClick;

        void MaterialItem_Click(object sender, EventArgs e)
        {
            if (SngClick != null) { SngClick(this, e); }
        }

        void MaterialItem_DoubleClick(object sender, EventArgs e)
        {
            if (DblClick != null) { DblClick(this, e); }
        }
    }
}
