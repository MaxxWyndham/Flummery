using System.Collections.Generic;

using Flummery.Controls;
using Flummery.Core;

using WeifenLuo.WinFormsUI.Docking;

namespace Flummery
{
    public partial class pnlMaterialList : DockContent
    {
        private List<Material> materials = new List<Material>();

        public pnlMaterialList()
        {
            InitializeComponent();

            TabText = "Material List";

            if (SceneManager.Current != null)
            {
                foreach (Material m in SceneManager.Current.Materials)
                {
                    materials.Add(m);
                }
            }

            redraw();
        }

        public void RegisterEventHandlers()
        {
            SceneManager.Current.OnAdd += scene_OnAdd;
            SceneManager.Current.OnChange += scene_OnChange;
            SceneManager.Current.OnReset += scene_OnReset;
        }

        private void scene_OnChange(object sender, ChangeEventArgs e)
        {
            if (e.Context != ChangeContext.Material) { return; }


        }

        void scene_OnAdd(object sender, AddEventArgs e)
        {
            if (e.Item is Material m)
            {
                materials.Add(m);
                addMaterial(m);
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
            materials.Clear();
            redraw();
        }

        private void redraw()
        {
            flpMaterials.Controls.Clear();

            foreach (Material m in materials)
            {
                addMaterial(m);
            }
        }
    }
}
