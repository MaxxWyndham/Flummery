using System;
using WeifenLuo.WinFormsUI.Docking;

namespace Flummery
{
    public partial class pnlMaterialList : DockContent
    {
        public pnlMaterialList()
        {
            InitializeComponent();

            this.TabText = "Material List";
        }

        public void RegisterEventHandlers()
        {
            SceneManager.Current.OnAdd += scene_OnAdd;
            SceneManager.Current.OnReset += scene_OnReset;
        }

        void scene_OnAdd(object sender, AddEventArgs e)
        {
            var t = (e.Item as Material);

            if (t != null)
            {
                var mi = new MaterialItem();

                mi.MaterialName = t.Name;
                mi.Material = t;
                if (t.Texture != null) { mi.SetThumbnail(t.Texture.GetThumbnail()); }

                //var matList = (flpMaterials.Tag as SortedList<string, string>);
                //matList[t.Name] = t.Name;

                flpMaterials.Controls.Add(mi);
                //flpMaterials.Controls.SetChildIndex(mi, matList.IndexOfKey(t.Name));

                //flpMaterials.Tag = matList;
            }
        }

        void scene_OnReset(object sender, ResetEventArgs e)
        {
            flpMaterials.Controls.Clear();
        }
    }
}
