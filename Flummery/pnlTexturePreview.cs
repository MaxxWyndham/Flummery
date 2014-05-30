using System;
using System.Drawing;
using WeifenLuo.WinFormsUI.Docking;

namespace Flummery
{
    public partial class pnlTexturePreview : DockContent
    {
        public pnlTexturePreview()
        {
            InitializeComponent();
        }

        private void pnlTexturePreview_Load(object sender, EventArgs e)
        {
        }

        public void SetImage(Bitmap bmp)
        {
            pbPreview.Image = bmp;
        }
    }
}
