using Flummery.Controls;
using Flummery.Core;

using WeifenLuo.WinFormsUI.Docking;

namespace Flummery
{
    public partial class PnlMaterialList : DockContent
    {
        private readonly Dictionary<long, Material> materials = new();

        public PnlMaterialList()
        {
            InitializeComponent();

            TabText = "Material List";

            if (SceneManager.Current != null)
            {
                foreach (Material m in SceneManager.Current.Materials)
                {
                    materials.Add(m.Key, m);
                }
            }

            Redraw();
        }

        public void RegisterEventHandlers()
        {
            SceneManager.Current.OnAdd += Scene_OnAdd;
            SceneManager.Current.OnChange += Scene_OnChange;
            SceneManager.Current.OnReset += Scene_OnReset;
        }

        void Scene_OnAdd(object sender, AddEventArgs e)
        {
            if (e.Item is Material m)
            {
                materials.Add(m.Key, m);
                AddMaterial(m);
            }
        }

        private void Scene_OnChange(object sender, ChangeEventArgs e)
        {
            if (e.Context != ChangeContext.Material) { return; }

            foreach (MaterialItem mi in flpMaterials.Controls)
            {
                if (e.AdditionalInformation is Material m && m.Key == mi.Key)
                {
                    if (m.Texture != null) { mi.SetThumbnail(m.Texture.GetThumbnail()); }
                    break;
                }
            }
        }

        void Scene_OnReset(object sender, ResetEventArgs e)
        {
            materials.Clear();
            Redraw();
        }

        private void AddMaterial(Material m)
        {
            MaterialItem mi = new()
            {
                MaterialName = m.Name,
                Material = m
            };

            if (m.Texture != null) { mi.SetThumbnail(m.Texture.GetThumbnail()); }

            flpMaterials.Controls.Add(mi);
        }

        private void Redraw()
        {
            flpMaterials.Controls.Clear();

            foreach (var m in materials)
            {
                AddMaterial(m.Value);
            }
        }
    }
}
