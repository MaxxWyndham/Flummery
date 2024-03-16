using Flummery.Core;

namespace Flummery.Controls
{
    public partial class MaterialItem : UserControl
    {
        Material m;

        public long? Key => m?.Key;

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
            SceneManager.Current.SetActiveMaterial(m.Key);
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