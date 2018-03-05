using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ToxicRagers.CarmageddonReincarnation.Formats;
using ToxicRagers.CarmageddonReincarnation.Helpers;

namespace Flummery
{
    public partial class frmNuCarmaSetupLOL : Form
    {
        public frmNuCarmaSetupLOL()
        {
            InitializeComponent();
            ResetUI();
        }

        public void ResetUI()
        {
            Setup setup = new Setup(SetupContext.Vehicle);

            int offset = 0;

            foreach (LUACodeBlockMethod setting in setup.Settings.Methods)
            {
                if (setting.Parameters.Count > 1) { continue; }

                Panel row = new Panel
                {
                    Width = pnlSettings.Width - SystemInformation.VerticalScrollBarWidth - 2,
                    Tag = setting,
                    Height = 26,
                    Top = offset
                };

                Label label = new Label
                {
                    Text = setting.Name,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Dock = DockStyle.Left,
                    Width = 200
                };

                Control control = null;

                switch (setting.Parameters[0].Type)
                {
                    case LUACodeBlockMethodParameterType.Int:
                    case LUACodeBlockMethodParameterType.Float:
                        control = new TextBox
                        {
                            BorderStyle = BorderStyle.FixedSingle,
                            Anchor = AnchorStyles.Right,
                            Top = 3,
                            Left = pnlSettings.Width - SystemInformation.VerticalScrollBarWidth - 100 - 1 - 4,
                            Text = $"{setting.Parameters[0].Value}"
                        };
                        break;

                    case LUACodeBlockMethodParameterType.Boolean:
                        control = new CheckBox
                        {
                            Anchor = AnchorStyles.Right,
                            Top = 1,
                            Left = pnlSettings.Width - SystemInformation.VerticalScrollBarWidth - 100 - 1 - 4
                        };
                        break;
                }

                if (control != null)
                {
                    control.MouseEnter += onSettingEnter;
                    control.MouseLeave += onSettingLeave;

                    row.Controls.Add(control);
                }

                row.Click += onSettingEnter;
                row.MouseEnter += onSettingEnter;
                row.MouseLeave += onSettingLeave;
                label.MouseEnter += onSettingEnter;
                label.MouseLeave += onSettingLeave;

                row.Controls.Add(label);

                pnlSettings.Controls.Add(row);

                offset += row.Height;
            }
        }

        void onSettingEnter(object sender, EventArgs e)
        {
            Control focus = (sender as Control);
            if (focus.Tag == null) { focus = focus.Parent; }

            LUACodeBlockMethod setting = (focus.Tag as LUACodeBlockMethod);

            focus.BackColor = SystemColors.ActiveCaption;

            lblProperty.Text = setting.Name;
            lblDescription.Text = setting.Description;
        }

        void onSettingLeave(object sender, EventArgs e)
        {
            Control focus = (sender as Control);
            if (focus.Tag == null) { focus = focus.Parent; }

            focus.BackColor = Color.Transparent;
        }
    }
}
