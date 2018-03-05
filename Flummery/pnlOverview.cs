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

            TabText = "Overview";

            Reset();

            if (SceneManager.Current != null && SceneManager.Current.Models.Count > 0) { ProcessTree(SceneManager.Current.Models[0], 0, false); }
        }

        public void RegisterEventHandlers()
        {
            SceneManager.Current.OnAdd += scene_OnAdd;
            SceneManager.Current.OnChange += scene_OnChange;
            SceneManager.Current.OnReset += scene_OnReset;
            SceneManager.Current.OnContextChange += scene_OnContextChange;
            ViewportManager.Current.OnMouseMove += viewport_OnMouseMove;
            
        }

        public void Reset()
        {
            TreeNode n;

            tvNodes.Nodes.Clear();
            n = tvNodes.Nodes.Add("Scene");

            tvNodes.Nodes[0].Expand();

            llblShoutOut.Visible = true;
            llblShoutOut.LinkVisited = false;

            FlummeryContributor contributor = FlummeryApplication.PickRandomContributor();
            llblShoutOut.Text = contributor.Name;
            llblShoutOut.Tag = contributor.Website;
            ttOverview.SetToolTip(llblShoutOut, contributor.Website);
        }

        public void ProcessTree(Model m, int index, bool bReset = false)
        {
            TreeNode ParentNode;

            if (bReset || tvNodes.Nodes.Count == 0) { Reset(); }

            ParentNode = tvNodes.Nodes[0];

            for (int i = 0; i < m.Bones.Count; i++)
            {
                ModelBone bone = m.Bones[i];
                int key = ModelBone.GetModelBoneKey(index, i);

                while (ParentNode != null && ParentNode.Tag != null && (int)ParentNode.Tag != ModelBone.GetModelBoneKey(index, bone.Parent.Index)) { ParentNode = ParentNode.Parent; }
                ParentNode = ParentNode.Nodes[ParentNode.Nodes.Add(CreateNode(bone, key))];
            }

            tvNodes.Nodes[0].Expand();
            if (tvNodes.Nodes[0].Nodes.Count > 0) { tvNodes.Nodes[0].Nodes[0].Expand(); }
        }

        void scene_OnAdd(object sender, AddEventArgs e)
        {
            Model m = (e.Item as Model);

            if (m != null) { ProcessTree(m, e.Index); }
        }

        private void scene_OnContextChange(object sender, ContextChangeEventArgs e)
        {
            tvNodes.Nodes[0].ImageIndex = (int)e.ModeContext;
            tvNodes.Nodes[0].SelectedImageIndex = (int)e.ModeContext;
        }

        void scene_OnChange(object sender, ChangeEventArgs e)
        {
            if (e.Index == -1) { ProcessTree(SceneManager.Current.Models[0], 0, true); }

            TreeNode node;

            //if (node == null) { throw new IndexOutOfRangeException(string.Format("Can't find node with index {0}", e.Index)); }

            switch (e.Change)
            {
                case ChangeType.Add:
                    FindNode((int)e.AdditionalInformation, tvNodes.Nodes[0], out node);
                    node.Nodes.Add(CreateNode(SceneManager.Current.Models[0].Bones[e.Index], e.Index));
                    ReindexTree();
                    node.Expand();
                    break;

                case ChangeType.Delete:
                    FindNode(e.Index, tvNodes.Nodes[0], out node);
                    if ((bool)e.AdditionalInformation)
                    {
                        node.Remove();
                        ReindexTree();
                    }
                    else
                    {
                        node.ImageIndex = 0;
                        node.SelectedImageIndex = node.ImageIndex;
                    }
                    break;

                case ChangeType.Move:
                    TreeNode dest;
                    FindNode(e.Index, tvNodes.Nodes[0], out node);
                    FindNode((int)e.AdditionalInformation, tvNodes.Nodes[0], out dest);

                    node.Remove();
                    dest.Nodes.Add(node);
                    ReindexTree();
                    break;

                case ChangeType.Rename:
                    FindNode(e.Index, tvNodes.Nodes[0], out node);
                    node.Text = getNodeText(SceneManager.Current.Models[0].Bones[e.Index]);
                    break;

                case ChangeType.ChangeType:
                    FindNode(e.Index, tvNodes.Nodes[0], out node);
                    ModelBone bone = SceneManager.Current.Models[0].Bones[e.Index];

                    node.Text = getNodeText(bone);
                    node.ImageIndex = (int)bone.Type;
                    node.SelectedImageIndex = node.ImageIndex;
                    break;
            }
        }

        protected void FindNode(int index, TreeNode root, out TreeNode node)
        {
            if ((index == 0 && root.Text == "Scene" && root.Nodes.Count == 0) || (root.Tag != null && (int)root.Tag == index))
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

        protected void ReindexTree()
        {
            for (int i = 0; i < tvNodes.Nodes[0].Nodes.Count; i++)
            {
                ReindexHierarchy(i, 0, tvNodes.Nodes[0].Nodes[i]);
            }
        }

        protected int ReindexHierarchy(int modelIndex, int boneIndex, TreeNode root)
        {
            root.Tag = ModelBone.GetModelBoneKey(modelIndex, boneIndex++);

            foreach (TreeNode child in root.Nodes)
            {
                boneIndex = ReindexHierarchy(modelIndex, boneIndex, child);
            }

            return boneIndex;
        }

        protected TreeNode CreateNode(ModelBone bone, int index)
        {
            TreeNode node = new TreeNode(getNodeText(bone))
            {
                Tag = index,
                ImageIndex = (int)bone.Type
            };

            node.SelectedImageIndex = node.ImageIndex;

            return node;
        }

        private string getNodeText(ModelBone bone)
        {
            string name = bone.Name;

            switch (bone.Type)
            {
                case BoneType.Mesh:
                    if (bone.Mesh != null) { name += " - " + bone.Mesh.Name; }
                    break;

                case BoneType.Light:
                    name += " - " + (bone.Attachment != null ? (bone.Attachment as ToxicRagers.CarmageddonReincarnation.Formats.LIGHT).Name : "");
                    break;

                case BoneType.VFX:
                    name += " - " + bone.AttachmentFile;
                    break;
            }

            return name;
        }

        void scene_OnReset(object sender, ResetEventArgs e)
        {
            ProcessTree(new Model(), 0, true);
        }

        private void tvNodes_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (SceneManager.Current.Models.Count > 0)
            {
                if (e.Node.Parent == null)
                {
                    SceneManager.Current.SetSelectedBone(-1, -1);
                }
                else if (e.Node.Tag != null)
                {
                    int mI = ModelBone.GetModelIndexFromKey((int)e.Node.Tag);
                    int bI = ModelBone.GetBoneIndexFromKey((int)e.Node.Tag);

                    SceneManager.Current.SetSelectedBone(mI, bI);

                    ModelBone bone = SceneManager.Current.Models[mI].Bones[bI];

                    if (bone.Type == BoneType.Mesh)
                    {
                        SceneManager.Current.SetBoundingBox(bone.Mesh.BoundingBox);
                    }
                    else
                    {
                        SceneManager.Current.SetNodePosition(bone);
                    }
                }
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

                int srcModel = ModelBone.GetModelIndexFromKey((int)NewNode.Tag);
                int srcBone = ModelBone.GetBoneIndexFromKey((int)NewNode.Tag);
                int dstModel = ModelBone.GetModelIndexFromKey((int)DestinationNode.Tag);
                int dstBone = ModelBone.GetBoneIndexFromKey((int)DestinationNode.Tag);

                DestinationNode.Nodes.Add((TreeNode)NewNode.Clone());
                DestinationNode.Expand();
                NewNode.Remove();

                if (srcModel == dstModel)
                {
                    if (SceneManager.Current.Models[srcModel].MoveBone(srcBone, dstBone)) { SceneManager.Current.Change(ChangeType.Move, ChangeContext.Model, srcBone, dstBone); }
                }
                else
                {
                    SceneManager.Current.Models[dstModel].ImportBone(SceneManager.Current.Models[srcModel].Bones[srcBone], dstBone);
                    SceneManager.Current.Models[srcModel].RemoveBone(srcBone);
                    
                    ReindexTree();
                }
            }
        }

        private void viewport_OnMouseMove(object sender, ViewportMouseMoveEventArgs e)
        {
            llblShoutOut.Visible = false;
            lblCoords.Text = string.Format("{0:0.000}, {1:0.000}, {2:0.000}", e.Position.X, e.Position.Y, e.Position.Z);
        }

        private void lblCoords_Click(object sender, EventArgs e)
        {
            if (lblCoords.Text != null)
            {
                Clipboard.SetText(lblCoords.Text);
            }
        }

        private void llblShoutOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            llblShoutOut.LinkVisited = true;
            System.Diagnostics.Process.Start("http://" + ((LinkLabel)sender).Tag.ToString());
        }
    }
}
