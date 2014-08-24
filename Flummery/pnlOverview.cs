using System;
using System.Drawing;
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
            ViewportManager.Current.OnMouseMove += viewport_OnMouseMove;
        }

        public void ProcessTree(Model m, bool bReset = false)
        {
            TreeNode ParentNode;

            if (bReset || tvNodes.Nodes.Count == 0) 
            { 
                tvNodes.Nodes.Clear();
                ParentNode = tvNodes.Nodes.Add("ROOT");
            } 
            else 
            {
                ParentNode = tvNodes.Nodes[0];
            }

            for (int i = 0; i < m.Bones.Count; i++)
            {
                var bone = m.Bones[i];

                if (bone.Parent == null)
                {
                    ParentNode.Text = bone.Name;
                    ParentNode.Tag = i;
                    ParentNode.ImageIndex = (bone.Tag == null ? 0 : 1);
                }
                else
                {
                    while (ParentNode != null && (int)ParentNode.Tag != bone.Parent.Index) { ParentNode = ParentNode.Parent; }
                    ParentNode = ParentNode.Nodes.Add(bone.Name);
                    ParentNode.Tag = i;
                    ParentNode.ImageIndex = (bone.Tag == null ? 0 : 1);
                }
            }

            //TreeNode ParentNode = (tvNodes.Nodes.Count == 0 ? tvNodes.Nodes.Add("ROOT") : tvNodes.Nodes[0]);

            //foreach (var child in m.Root.Children)
            //{
            //    TravelTree(child, ref ParentNode);
            //}

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

        void scene_OnChange(object sender, ChangeEventArgs e)
        {
            if (e.Index == -1) { ProcessTree(SceneManager.Current.Models[0], true); }

            TreeNode node;

            //if (node == null) { throw new IndexOutOfRangeException(string.Format("Can't find node with index {0}", e.Index)); }

            switch (e.Change)
            {
                case ChangeType.Add:
                    FindNode((int)e.AdditionalInformation, tvNodes.Nodes[0], out node);
                    node.Nodes.Add(CreateNode(SceneManager.Current.Models[0].Bones[e.Index].Name, e.Index, (SceneManager.Current.Models[0].Bones[e.Index].Tag == null ? 0 : 1)));
                    ReindexTree(0, tvNodes.Nodes[0]);
                    node.Expand();
                    break;

                case ChangeType.Delete:
                    FindNode(e.Index, tvNodes.Nodes[0], out node);
                    if ((bool)e.AdditionalInformation)
                    {
                        node.Remove();
                        ReindexTree(0, tvNodes.Nodes[0]);
                    }
                    else
                    {
                        node.ImageIndex = 0;
                    }
                    break;

                case ChangeType.Move:
                    TreeNode dest;
                    FindNode(e.Index, tvNodes.Nodes[0], out node);
                    FindNode((int)e.AdditionalInformation, tvNodes.Nodes[0], out dest);

                    node.Remove();
                    dest.Nodes.Add(node);
                    ReindexTree(0, tvNodes.Nodes[0]);
                    break;

                case ChangeType.Rename:
                    FindNode(e.Index, tvNodes.Nodes[0], out node);
                    node.Text = e.AdditionalInformation.ToString();
                    break;
            }
        }

        protected void FindNode(int index, TreeNode root, out TreeNode node)
        {
            if ((int)root.Tag == index)
            {
                node = root;
            }
            else
            {
                node = null;

                foreach (TreeNode child in root.Nodes)
                {
                    FindNode(index, child, out node);

                    if (node != null) { break; }
                }
            }
        }

        protected int ReindexTree(int index, TreeNode root)
        {
            root.Tag = index++;

            foreach (TreeNode child in root.Nodes)
            {
                index = ReindexTree(index, child);
            }

            return index;
        }

        protected TreeNode CreateNode(string name, int index, int image)
        {
            var node = new TreeNode(name);
            node.Tag = index;
            node.ImageIndex = image;
            return node;
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

        private void tvNodes_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void tvNodes_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void tvNodes_DragDrop(object sender, DragEventArgs e)
        {
            TreeNode NewNode;

            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                Point pt = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                TreeNode DestinationNode = ((TreeView)sender).GetNodeAt(pt);
                NewNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");

                int srcBone = (int)NewNode.Tag;
                int dstBone = (int)DestinationNode.Tag;

                DestinationNode.Nodes.Add((TreeNode)NewNode.Clone());
                DestinationNode.Expand();
                NewNode.Remove();

                SceneManager.Current.Models[0].MoveBone(srcBone, dstBone);
                SceneManager.Current.Change(ChangeType.Move, srcBone, dstBone);
            }
        }

        private void viewport_OnMouseMove(object sender, ViewportMouseMoveEventArgs e)
        {
            lblCoords.Text = string.Format("{0:0.000}, {1:0.000}, {2:0.000}", e.Position.X, e.Position.Y, e.Position.Z);
        }

        private void lblCoords_Click(object sender, EventArgs e)
        {
            if (lblCoords.Text != null)
            {
                Clipboard.SetText(lblCoords.Text);
            }
        }
    }
}
