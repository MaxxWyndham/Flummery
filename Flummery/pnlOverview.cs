using System;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Flummery
{
    public partial class pnlOverview : DockContent
    {
        public pnlOverview()
        {
            InitializeComponent();

            this.TabText = "Overview";
        }

        public void RegisterEventHandlers()
        {
            SceneManager.Current.OnAdd += scene_OnAdd;
            SceneManager.Current.OnChange += scene_OnChange;
            SceneManager.Current.OnReset += scene_OnReset;
        }

        public void ProcessTree(Model m, bool bReset = false)
        {
            if (bReset) { tvNodes.Nodes.Clear(); }

            TreeNode ParentNode = (tvNodes.Nodes.Count == 0 ? tvNodes.Nodes.Add("ROOT") : tvNodes.Nodes[0]);

            foreach (var child in m.Root.Children)
            {
                TravelTree(child, ref ParentNode);
            }

            tvNodes.Nodes[0].Expand();
            if (tvNodes.Nodes[0].Nodes.Count > 0) { tvNodes.Nodes[0].Nodes[0].Expand(); }
        }

        public static void TravelTree(ModelBone bone, ref TreeNode node)
        {
            node = node.Nodes.Add(bone.Name);
            node.Tag = bone.Index;

            foreach (var b in bone.Children)
            {
                TravelTree(b, ref node);
            }

            node = node.Parent;
        }

        void scene_OnAdd(object sender, AddEventArgs e)
        {
            var m = (e.Item as Model);

            if (m != null) { ProcessTree(m); }
        }

        void scene_OnChange(object sender, EventArgs e)
        {
            ProcessTree(SceneManager.Current.Models[0], true);
        }

        void scene_OnReset(object sender, ResetEventArgs e)
        {
            ProcessTree(new Model(), true);
        }

        private void tvNodes_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag != null && SceneManager.Current.Models.Count > 0)
            {
                SceneManager.Current.SetSelectedBone((int)e.Node.Tag);

                var mesh = (SceneManager.Current.Models[0].Bones[(int)e.Node.Tag].Tag as ModelMesh);
                if (mesh != null) { SceneManager.Current.SetBoundingBox(mesh.BoundingBox); }
            }
        }

        private void tvNodes_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                //scene.Camera.ResetCamera();
                //scene.Camera.SetPosition(scene.Models[0].Bones[(int)e.Node.Tag].CombinedTransform.Position());
            }
        }
    }
}
