using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

using ToxicRagers.Helpers;

namespace Flummery.Controls
{
    public partial class Transform : UserControl, IWidget
    {
        public enum Relativity
        {
            Relative,
            Absolute
        }

        bool bExpanded = true;

        ModelBone bone;
        int defaultWidth = 190;
        Relativity relativity = Relativity.Absolute;
        GangedInput gang = new GangedInput();
        bool bMouseDown;
        Point dragStart;

        public int DefaultWidth => defaultWidth;
        public Transform()
        {
            InitializeComponent();

            Dock = DockStyle.Top;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;

            resetWidget();
        }

        public void RegisterEventHandlers()
        {
            SceneManager.Current.OnSelect += scene_OnSelect;
        }

        void scene_OnSelect(object sender, SelectEventArgs e)
        {
            bone = (e.Item as ModelBone);
            resetWidget();
        }

        private void resetWidget()
        {
            if (bone == null)
            {
                txtPositionX.Text = "-";
                txtPositionY.Text = "-";
                txtPositionZ.Text = "-";
                txtRotationX.Text = "-";
                txtRotationY.Text = "-";
                txtRotationZ.Text = "-";
                txtScaleX.Text = "-";
                txtScaleY.Text = "-";
                txtScaleZ.Text = "-";

                txtPositionX.Enabled = false;
                txtPositionY.Enabled = false;
                txtPositionZ.Enabled = false;
                txtRotationX.Enabled = false;
                txtRotationY.Enabled = false;
                txtRotationZ.Enabled = false;
                txtScaleX.Enabled = false;
                txtScaleY.Enabled = false;
                txtScaleZ.Enabled = false;

                return;
            }

            resetLinks();
            gang.Reset();

            txtPositionX.Enabled = true;
            txtPositionY.Enabled = true;
            txtPositionZ.Enabled = true;
            txtRotationX.Enabled = true;
            txtRotationY.Enabled = true;
            txtRotationZ.Enabled = true;
            txtScaleX.Enabled = true;
            txtScaleY.Enabled = true;
            txtScaleZ.Enabled = true;

            relativity = (rdoRelative.Checked ? Relativity.Relative : Relativity.Absolute);

            if (relativity == Relativity.Relative)
            {
                txtPositionX.Text = "0.00";
                txtPositionY.Text = "0.00";
                txtPositionZ.Text = "0.00";
                txtRotationX.Text = "0";
                txtRotationY.Text = "0";
                txtRotationZ.Text = "0";
                txtScaleX.Text = "100";
                txtScaleY.Text = "100";
                txtScaleZ.Text = "100";

                btnFreezePosition.Enabled = false;
                btnFreezeRotation.Enabled = false;
                btnFreezeScale.Enabled = false;
            }
            else
            {
                btnFreezePosition.Enabled = true;
                btnFreezeRotation.Enabled = true;
                btnFreezeScale.Enabled = true;

                OpenTK.Vector3 p = bone.GetPosition();
                OpenTK.Vector3 r = bone.GetRotation();
                OpenTK.Vector3 s = bone.GetScale();

                txtPositionX.Text = p.X.ToString(FlummeryApplication.Culture);
                txtPositionY.Text = p.Y.ToString(FlummeryApplication.Culture);
                txtPositionZ.Text = p.Z.ToString(FlummeryApplication.Culture);
                txtRotationX.Text = r.X.ToString(FlummeryApplication.Culture);
                txtRotationY.Text = r.Y.ToString(FlummeryApplication.Culture);
                txtRotationZ.Text = r.Z.ToString(FlummeryApplication.Culture);
                txtScaleX.Text = s.X.ToString(FlummeryApplication.Culture);
                txtScaleY.Text = s.Y.ToString(FlummeryApplication.Culture);
                txtScaleZ.Text = s.Z.ToString(FlummeryApplication.Culture);
            }
        }

        private void rdoRelativity_CheckedChanged(object sender, EventArgs e)
        {
            resetWidget();
        }

        private void btnFreezePosition_Click(object sender, EventArgs e)
        {
            ModelManipulator.Freeze(SceneManager.Current.Models[SceneManager.Current.SelectedModelIndex].Bones[SceneManager.Current.SelectedBoneIndex].Mesh, FreezeComponents.Position);

            txtPositionX.Text = "0.00";
            txtPositionY.Text = "0.00";
            txtPositionZ.Text = "0.00";
        }

        private void btnFreezeRotation_Click(object sender, EventArgs e)
        {
            ModelManipulator.Freeze(SceneManager.Current.Models[SceneManager.Current.SelectedModelIndex].Bones[SceneManager.Current.SelectedBoneIndex].Mesh, FreezeComponents.Rotation);

            txtRotationX.Text = "0";
            txtRotationY.Text = "0";
            txtRotationZ.Text = "0";
        }

        private void btnFreezeScale_Click(object sender, EventArgs e)
        {
            ModelManipulator.Freeze(SceneManager.Current.Models[SceneManager.Current.SelectedModelIndex].Bones[SceneManager.Current.SelectedBoneIndex].Mesh, FreezeComponents.Scale);

            txtScaleX.Text = "1";
            txtScaleY.Text = "1";
            txtScaleZ.Text = "1";
        }

        void resetLinks()
        {
            //lblPositionX.BackColor = SystemColors.ActiveBorder;
            //lblPositionY.BackColor = SystemColors.ActiveBorder;
            //lblPositionZ.BackColor = SystemColors.ActiveBorder;
        }

        void gbGroup_MouseDown(object sender, MouseEventArgs e)
        {
            bMouseDown = true;

            GroupBox gb = (GroupBox)sender;

            dragStart = PointToClient(MousePosition);
            dragStart.X -= gb.Location.X;
            dragStart.Y -= gb.Location.Y;
        }

        void gbGroup_MouseMove(object sender, MouseEventArgs e)
        {
            if (!bMouseDown) { return; }

            GroupBox gb = (GroupBox)sender;

            Point p = PointToClient(MousePosition);
            p.X -= ((Control)sender).Location.X;
            p.Y -= ((Control)sender).Location.Y;
            Point min = new Point(Math.Min(dragStart.X, p.X), Math.Min(dragStart.Y, p.Y));
            Point max = new Point(Math.Max(dragStart.X, p.X), Math.Max(dragStart.Y, p.Y));

            Rectangle r = new Rectangle(min.X, min.Y, max.X - min.X, max.Y - min.Y);

            foreach (TextBox box in gb.Controls.OfType<TextBox>())
            {
                gb.Controls.Find(box.Name.Replace("txt", "lbl") + "Units", false)[0].BackColor = (box.Enabled && r.IntersectsWith(box.Bounds) ? SystemColors.Highlight : SystemColors.ActiveBorder);
            }
        }

        void gbGroup_MouseUp(object sender, MouseEventArgs e)
        {
            GroupBox gb = (GroupBox)sender;

            bMouseDown = false;

            foreach (Label label in gb.Controls.OfType<Label>())
            {
                if (label.BackColor == SystemColors.Highlight)
                {
                    gang.AddBox((TextBox)gb.Controls.Find(label.Name.Replace("lbl", "txt").Replace("Units", ""), false)[0]);
                }
            }
        }

        private void txtBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBox box = (TextBox)sender;

            if (float.TryParse(box.Text, NumberStyles.Number, FlummeryApplication.Culture, out float s))
            {
                box.Text = s.ToString();
                box.Tag = s;
            }
            else
            {
                box.Text = box.Tag.ToString();
            }

            switch (box.Name.Substring(0, box.Name.Length - 1).Replace("txt", ""))
            {
                case "Position":
                    bone.SetPosition(txtPositionX.Text.ToSingle(), txtPositionY.Text.ToSingle(), txtPositionZ.Text.ToSingle(), rdoAbsolute.Checked);
                    break;

                case "Rotation":
                    bone.SetRotation(txtRotationX.Text.ToSingle(), txtRotationY.Text.ToSingle(), txtRotationZ.Text.ToSingle(), rdoAbsolute.Checked);
                    break;

                case "Scale":
                    float divisor = (rdoAbsolute.Checked ? 1.0f : 100.0f);
                    bone.SetScale(txtScaleX.Text.ToSingle() / divisor, txtScaleY.Text.ToSingle() / divisor, txtScaleZ.Text.ToSingle() / divisor, rdoAbsolute.Checked);
                    break;
            }

            SceneManager.Current.Change(ChangeType.Transform, ChangeContext.Model, SceneManager.Current.SelectedBoneIndex);

            resetWidget();
        }

        private void txtBox_Click(object sender, EventArgs e)
        {
            gang.SetPrimary((TextBox)sender);
        }

        private void txtBox_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                e.Handled = true;
            }
            else
            {
                gang.UpdateBoxes();
            }
        }

        private void btnPanelTitle_Click(object sender, EventArgs e)
        {
            if (bExpanded)
            {
                pnlPanel.Tag = pnlPanel.Height;
                pnlPanel.Height = 0;
            }
            else
            {
                pnlPanel.Height = (int)pnlPanel.Tag;
            }

            bExpanded = !bExpanded;

            pnlPanel.Visible = bExpanded;
        }
    }

    public class GangedInput
    {
        List<TextBox> boxes = new List<TextBox>();

        public void SetPrimary(TextBox box)
        {
            if (boxes.Contains(box))
            {
                boxes.Remove(box);
                boxes.Insert(0, box);
            }
        }

        public void AddBox(TextBox box)
        {
            boxes.Add(box);
        }

        public void Reset()
        {
            boxes.Clear();
        }

        public void UpdateBoxes()
        {
            for (int i = 1; i < boxes.Count; i++)
            {
                boxes[i].Text = boxes[0].Text;
            }
        }
    }
}