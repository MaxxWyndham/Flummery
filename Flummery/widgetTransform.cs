using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

using OpenTK;
using ToxicRagers.Helpers;
using WeifenLuo.WinFormsUI.Docking;

namespace Flummery
{
    public partial class widgetTransform : DockContent
    {
        public enum Relativity
        {
            Relative,
            Absolute
        }

        ModelBone bone;
        int defaultWidth = 190;
        Relativity relativity = Relativity.Absolute;
        GangedInput gang = new GangedInput();
        bool bMouseDown;
        Point dragStart;

        public int DefaultWidth { get { return defaultWidth; } }

        public widgetTransform()
        {
            InitializeComponent();

            this.gbPosition.MouseDown += gbGroup_MouseDown;
            this.gbRotation.MouseDown += gbGroup_MouseDown;
            this.gbScale.MouseDown    += gbGroup_MouseDown;

            this.gbPosition.MouseMove += gbGroup_MouseMove;
            this.gbRotation.MouseMove += gbGroup_MouseMove;
            this.gbScale.MouseMove    += gbGroup_MouseMove;

            this.gbPosition.MouseUp += gbGroup_MouseUp;
            this.gbRotation.MouseUp += gbGroup_MouseUp;
            this.gbScale.MouseUp    += gbGroup_MouseUp;

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

                var p = bone.Transform.ExtractTranslation();
                var r = bone.Transform.ExtractRotation().ToAxisAngle();
                var s = bone.Transform.ExtractScale();

                if (Math.Abs(r.X) < 0.0001f) { r.X = 0; }
                if (Math.Abs(r.Y) < 0.0001f) { r.Y = 0; }
                if (Math.Abs(r.Z) < 0.0001f) { r.Z = 0; }

                r.X *= MathHelper.RadiansToDegrees(r.W);
                r.Y *= MathHelper.RadiansToDegrees(r.W);
                r.Z *= MathHelper.RadiansToDegrees(r.W);

                txtPositionX.Text = p.X.ToString();
                txtPositionY.Text = p.Y.ToString();
                txtPositionZ.Text = p.Z.ToString();
                txtRotationX.Text = r.X.ToString();
                txtRotationY.Text = r.Y.ToString();
                txtRotationZ.Text = r.Z.ToString();
                txtScaleX.Text = s.X.ToString();
                txtScaleY.Text = s.Y.ToString();
                txtScaleZ.Text = s.Z.ToString();
            }
        }

        private void rdoRelativity_CheckedChanged(object sender, EventArgs e)
        {
            resetWidget();
        }

        private void btnFreezePosition_Click(object sender, EventArgs e)
        {
            ModelManipulator.Freeze((ModelMesh)SceneManager.Current.Models[SceneManager.Current.SelectedModelIndex].Bones[SceneManager.Current.SelectedBoneIndex].Tag, FreezeComponents.Position);

            txtPositionX.Text = "0.00";
            txtPositionY.Text = "0.00";
            txtPositionZ.Text = "0.00";
        }

        private void btnFreezeRotation_Click(object sender, EventArgs e)
        {
            ModelManipulator.Freeze((ModelMesh)SceneManager.Current.Models[SceneManager.Current.SelectedModelIndex].Bones[SceneManager.Current.SelectedBoneIndex].Tag, FreezeComponents.Rotation);

            txtRotationX.Text = "0";
            txtRotationY.Text = "0";
            txtRotationZ.Text = "0";
        }

        private void btnFreezeScale_Click(object sender, EventArgs e)
        {
            ModelManipulator.Freeze((ModelMesh)SceneManager.Current.Models[SceneManager.Current.SelectedModelIndex].Bones[SceneManager.Current.SelectedBoneIndex].Tag, FreezeComponents.Scale);

            txtScaleX.Text = "1";
            txtScaleY.Text = "1";
            txtScaleZ.Text = "1";
        }

        void resetLinks()
        {
            lblPositionXUnits.BackColor = SystemColors.ActiveBorder;
            lblPositionYUnits.BackColor = SystemColors.ActiveBorder;
            lblPositionZUnits.BackColor = SystemColors.ActiveBorder;
            lblRotationXUnits.BackColor = SystemColors.ActiveBorder;
            lblRotationYUnits.BackColor = SystemColors.ActiveBorder;
            lblRotationZUnits.BackColor = SystemColors.ActiveBorder;
            lblScaleXUnits.BackColor = SystemColors.ActiveBorder;
            lblScaleYUnits.BackColor = SystemColors.ActiveBorder;
            lblScaleZUnits.BackColor = SystemColors.ActiveBorder;
        }

        void gbGroup_MouseDown(object sender, MouseEventArgs e)
        {
            bMouseDown = true;

            var gb = (GroupBox)sender;

            dragStart = PointToClient(MousePosition);
            dragStart.X -= gb.Location.X;
            dragStart.Y -= gb.Location.Y;
        }

        void gbGroup_MouseMove(object sender, MouseEventArgs e)
        {
            if (!bMouseDown) { return; }

            var gb = (GroupBox)sender;

            var p = PointToClient(MousePosition);
            p.X -= ((Control)sender).Location.X;
            p.Y -= ((Control)sender).Location.Y;
            var min = new Point(Math.Min(dragStart.X, p.X), Math.Min(dragStart.Y, p.Y));
            var max = new Point(Math.Max(dragStart.X, p.X), Math.Max(dragStart.Y, p.Y));

            var r = new Rectangle(min.X, min.Y, max.X - min.X, max.Y - min.Y);

            foreach (var box in gb.Controls.OfType<TextBox>())
            {
                gb.Controls.Find(box.Name.Replace("txt", "lbl") + "Units", false)[0].BackColor = (box.Enabled && r.IntersectsWith(box.Bounds) ? SystemColors.Highlight : SystemColors.ActiveBorder);
            }
        }

        void gbGroup_MouseUp(object sender, MouseEventArgs e)
        {
            var gb = (GroupBox)sender;

            bMouseDown = false;

            foreach (var label in gb.Controls.OfType<Label>())
            {
                if (label.BackColor == SystemColors.Highlight)
                {
                    gang.AddBox((TextBox)gb.Controls.Find(label.Name.Replace("lbl", "txt").Replace("Units", ""), false)[0]);
                }
            }
        }

        private void txtBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var box = (TextBox)sender;
            Single s = 0;

            if (Single.TryParse(box.Text, NumberStyles.Number, Flummery.Culture, out s))
            {
                box.Text = s.ToString();
                box.Tag = s;
            }
            else
            {
                box.Text = box.Tag.ToString();
            }
           
            Single divisor = (rdoAbsolute.Checked ? 1.0f : 100.0f);

            var mS = Matrix4.CreateScale(txtScaleX.Text.ToSingle() / divisor, txtScaleY.Text.ToSingle() / divisor, txtScaleZ.Text.ToSingle() / divisor);
            var mRx = Matrix4.CreateRotationX(MathHelper.DegreesToRadians(txtRotationX.Text.ToSingle()));
            var mRy = Matrix4.CreateRotationY(MathHelper.DegreesToRadians(txtRotationY.Text.ToSingle()));
            var mRz = Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(txtRotationZ.Text.ToSingle()));
            var vP = new OpenTK.Vector3(txtPositionX.Text.ToSingle(), txtPositionY.Text.ToSingle(), txtPositionZ.Text.ToSingle());

            var transform = mS * mRx * mRy * mRz;
            transform.M41 = vP.X;
            transform.M42 = vP.Y;
            transform.M43 = vP.Z;

            if (rdoAbsolute.Checked)
            {
                bone.Transform = transform;
            }
            else
            {
                bone.Transform *= transform;
            }

            SceneManager.Current.Models[0].SetTransform(bone.Transform, SceneManager.Current.SelectedBoneIndex);
            SceneManager.Current.Change(ChangeType.Transform, SceneManager.Current.SelectedBoneIndex);

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
                this.Validate();
                e.Handled = true;
            }
            else
            {
                gang.UpdateBoxes();
            }
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
