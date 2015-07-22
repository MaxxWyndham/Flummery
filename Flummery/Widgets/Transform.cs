using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

using OpenTK;

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

        public int DefaultWidth { get { return defaultWidth; } }

        public Transform()
        {
            InitializeComponent();

            this.Dock = DockStyle.Top;
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

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

                OpenTK.Vector3 vs = new OpenTK.Vector3();
                OpenTK.Vector3 vt = new OpenTK.Vector3();
                Quaternion qr = new Quaternion();

                if (!bone.Transform.Decompose(out vs, out qr, out vt))
                {
                    Console.WriteLine("Shit dude");
                }
                else
                {
                    Console.WriteLine("position: {0}", vt);
                    Console.WriteLine("rotation: {0}", qr);
                    Console.WriteLine("scale   : {0}", vs);
                }

                var p = bone.Transform.ExtractTranslation();
                var rq = bone.Transform.ExtractRotation();
                var s = bone.Transform.ExtractScale();

                var r = rq.ToEuler(RotationOrder.OrderXYZ);

                p.X = (float)Math.Round(p.X, 3, MidpointRounding.AwayFromZero);
                p.Y = (float)Math.Round(p.Y, 3, MidpointRounding.AwayFromZero);
                p.Z = (float)Math.Round(p.Z, 3, MidpointRounding.AwayFromZero);

                r.X = (float)Math.Round(r.X, 3, MidpointRounding.AwayFromZero);
                r.Y = (float)Math.Round(r.Y, 3, MidpointRounding.AwayFromZero);
                r.Z = (float)Math.Round(r.Z, 3, MidpointRounding.AwayFromZero);

                s.X = (float)Math.Round(s.X, 3, MidpointRounding.AwayFromZero);
                s.Y = (float)Math.Round(s.Y, 3, MidpointRounding.AwayFromZero);
                s.Z = (float)Math.Round(s.Z, 3, MidpointRounding.AwayFromZero);

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

            if (Single.TryParse(box.Text, NumberStyles.Number, FlummeryApplication.Culture, out s))
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
            var mR = Matrix4.CreateFromQuaternion(
                Quaternion.FromAxisAngle(OpenTK.Vector3.UnitX, MathHelper.DegreesToRadians(txtRotationX.Text.ToSingle())) *
                Quaternion.FromAxisAngle(OpenTK.Vector3.UnitY, MathHelper.DegreesToRadians(txtRotationY.Text.ToSingle())) *
                Quaternion.FromAxisAngle(OpenTK.Vector3.UnitZ, MathHelper.DegreesToRadians(txtRotationZ.Text.ToSingle()))
            );
            var vP = new OpenTK.Vector3(txtPositionX.Text.ToSingle(), txtPositionY.Text.ToSingle(), txtPositionZ.Text.ToSingle());

            var transform = Matrix4.Identity;
            transform *= mS;
            transform *= mR;
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
