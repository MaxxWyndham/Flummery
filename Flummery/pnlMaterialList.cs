using System;

using Flummery.Controls;

using WeifenLuo.WinFormsUI.Docking;

namespace Flummery
{
    public partial class pnlMaterialList : DockContent
    {
        public pnlMaterialList()
        {
            InitializeComponent();

            TabText = "Material List";

            if (SceneManager.Current != null)
            {
                foreach (Material m in SceneManager.Current.Materials)
                {
                    addMaterial(m);
                }
            }
        }

        public void RegisterEventHandlers()
        {
            SceneManager.Current.OnAdd += scene_OnAdd;
            SceneManager.Current.OnReset += scene_OnReset;
        }

        void scene_OnAdd(object sender, AddEventArgs e)
        {
            Material t = (e.Item as Material);

            if (t != null)
            {
                addMaterial(t);
            }
        }

        private void addMaterial(Material m)
        {
            MaterialItem mi = new MaterialItem()
            {
                MaterialName = m.Name,
                Material = m
            };

            if (m.Texture != null) { mi.SetThumbnail(m.Texture.GetThumbnail()); }

            flpMaterials.Controls.Add(mi);
        }

        void scene_OnReset(object sender, ResetEventArgs e)
        {
            flpMaterials.Controls.Clear();
        }
    }
}
