using System;
using System.Windows.Forms;

using ToxicRagers.CarmageddonReincarnation.Formats;

namespace Flummery.Controls
{
    public partial class Lighting : UserControl, IWidget
    {
        bool bExpanded = true;

        ModelBone bone;
        LIGHT light;

        public Lighting()
        {
            InitializeComponent();

            this.Dock = DockStyle.Top;
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

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
            light = (bone != null && bone.Type == BoneType.Light && bone.Attachment != null ? bone.Attachment as LIGHT : new LIGHT());

            lblLightType.Text = string.Format(lblLightType.Tag.ToString(), light.Type);
            lblLightName.Text = light.Name;
            chkLightOn.Checked = true;
            nudRange.Value = (Decimal)light.Range;
            nudInner.Value = (Decimal)light.Inner;
            nudOuter.Value = (Decimal)light.Outer;

            nudRed.Value = (Decimal)(light.R * 255);
            nudGreen.Value = (Decimal)(light.G * 255);
            nudBlue.Value = (Decimal)(light.B * 255);
            nudIntensity.Value = (Decimal)light.Intensity;
            updateLightColour();

            chkCastShadows.Checked = light.Flags.HasFlag(LIGHT.LightFlags.CastShadow);
            chkParallelSplit.Checked = false; chkParallelSplit.Enabled = false;
            chkVisualiseSplits.Checked = false; chkVisualiseSplits.Enabled = false;
            chkUsePool.Checked = light.Flags.HasFlag(LIGHT.LightFlags.UsePool);

            nudSplitCount.Value = light.SplitCount;
            nudSplitDistribn.Value = (Decimal)light.SplitDistribution;
            nudShadCoverX.Value = (Decimal)light.ShadowCoverX;
            nudShadCoverY.Value = (Decimal)light.ShadowCoverY;
            nudShadResX.Value = light.ShadowResolutionX;
            nudShadResY.Value = light.ShadowResolutionY;
            nudShadIntensity.Value = (Decimal)light.ShadowIntensity;
            nudGoboScaleX.Value = (Decimal)light.GoboScaleX;
            nudGoboScaleY.Value = (Decimal)light.GoboScaleY;
            nudGoboOffsetX.Value = (Decimal)light.GoboOffsetX;
            nudGoboOffsetY.Value = (Decimal)light.GoboOffsetY;
            nudShadowBias.Value = (Decimal)light.ShadowBias;
            nudLightNearClip.Value = (Decimal)light.LightNearClip;
            nudShadowDist.Value = (Decimal)light.ShadowDistance;

            chkUseGobo.Checked = light.Flags.HasFlag(LIGHT.LightFlags.UsesGobo);
            lblGobo.Text = light.GOBO;

            chkEdgeColour.Checked = light.UseEdgeColour;
            nudEdgeRed.Value = light.EdgeColourR;
            nudEdgeGreen.Value = light.EdgeColourG;
            nudEdgeBlue.Value = light.EdgeColourB;
            updateEdgeColour();

            toggleShadowUI();
            toggleEdgeColourUI();
            setButtonText();
        }

        private void setButtonText()
        {
            chkCastShadows.Text = (chkCastShadows.Checked ? "On" : "Off");
            chkEdgeColour.Text = (chkEdgeColour.Checked ? "On" : "Off");
            chkLightOn.Text = (chkLightOn.Checked ? "On" : "Off");
            chkParallelSplit.Text = (chkParallelSplit.Checked ? "On" : "Off");
            chkUseGobo.Text = (chkUseGobo.Checked ? "On" : "Off");
            chkUsePool.Text = (chkUsePool.Checked ? "On" : "Off");
            chkVisualiseSplits.Text = (chkVisualiseSplits.Checked ? "On" : "Off");
        }

        private void toggleShadowUI()
        {
            chkUsePool.Enabled = chkCastShadows.Checked;
            nudSplitCount.Enabled = chkCastShadows.Checked;
            nudSplitDistribn.Enabled = chkCastShadows.Checked;
            nudShadResX.Enabled = chkCastShadows.Checked;
            nudShadResY.Enabled = chkCastShadows.Checked;
            nudShadIntensity.Enabled = chkCastShadows.Checked;
            nudGoboScaleX.Enabled = chkCastShadows.Checked;
            nudGoboScaleY.Enabled = chkCastShadows.Checked;
            nudGoboOffsetX.Enabled = chkCastShadows.Checked;
            nudGoboOffsetY.Enabled = chkCastShadows.Checked;
            nudShadowBias.Enabled = chkCastShadows.Checked;
            nudLightNearClip.Enabled = chkCastShadows.Checked;
            nudShadowDist.Enabled = chkCastShadows.Checked;

            setButtonText();
        }

        private void toggleEdgeColourUI()
        {
            nudEdgeRed.Enabled = chkEdgeColour.Checked;
            nudEdgeGreen.Enabled = chkEdgeColour.Checked;
            nudEdgeBlue.Enabled = chkEdgeColour.Checked;
            lblEdgePreview.Enabled = chkEdgeColour.Checked;

            setButtonText();
        }

        private void toggleGoboUI()
        {
            lblGobo.Enabled = chkUseGobo.Checked;

            setButtonText();
        }

        private void updateLightColour()
        {
            light.R = (float)nudRed.Value / 255.0f;
            light.G = (float)nudGreen.Value / 255.0f;
            light.B = (float)nudBlue.Value / 255.0f;

            lblPreview.BackColor = System.Drawing.Color.FromArgb(255, (int)nudRed.Value, (int)nudGreen.Value, (int)nudBlue.Value);
        }

        private void updateEdgeColour()
        {
            light.EdgeColourR = (byte)nudEdgeRed.Value;
            light.EdgeColourG = (byte)nudEdgeBlue.Value;
            light.EdgeColourB = (byte)nudEdgeBlue.Value;

            lblEdgePreview.BackColor = System.Drawing.Color.FromArgb(255, (int)nudEdgeRed.Value, (int)nudEdgeGreen.Value, (int)nudEdgeBlue.Value);
        }

        private void lblPreview_Click(object sender, EventArgs e)
        {
            cdPicker.Color = lblPreview.BackColor;

            if (cdPicker.ShowDialog() == DialogResult.OK)
            {
                nudRed.Value = cdPicker.Color.R;
                nudGreen.Value = cdPicker.Color.G;
                nudBlue.Value = cdPicker.Color.B;

                updateLightColour();
            }
        }

        private void lblEdgePreview_Click(object sender, EventArgs e)
        {
            cdPicker.Color = lblEdgePreview.BackColor;

            if (cdPicker.ShowDialog() == DialogResult.OK)
            {
                nudEdgeRed.Value = cdPicker.Color.R;
                nudEdgeGreen.Value = cdPicker.Color.G;
                nudEdgeBlue.Value = cdPicker.Color.B;

                updateEdgeColour();
            }
        }

        private void chkEdgeColour_CheckedChanged(object sender, EventArgs e)
        {
            toggleEdgeColourUI();

            light.UseEdgeColour = chkEdgeColour.Checked;
        }

        private void chkCastShadows_CheckedChanged(object sender, EventArgs e)
        {
            toggleShadowUI();

            if (light.Flags.HasFlag(LIGHT.LightFlags.CastShadow))
            {
                light.Flags &= ~LIGHT.LightFlags.CastShadow;
            }
            else
            {
                light.Flags |= LIGHT.LightFlags.CastShadow;
            }
        }

        private void btnPanelTitle_Click(object sender, EventArgs e)
        {
            bExpanded = !bExpanded;

            pnlPanel.Visible = bExpanded;
        }

        private void chkLightOn_CheckedChanged(object sender, EventArgs e)
        {
            if (SceneManager.Current != null) { SceneManager.Current.UpdateProgress("This doesn't do anything!"); }
        }

        private void nudRange_ValueChanged(object sender, EventArgs e)
        {
            light.Range = (float)nudRange.Value;
        }

        private void nudInner_ValueChanged(object sender, EventArgs e)
        {
            light.Inner = (float)nudInner.Value;
        }

        private void nudOuter_ValueChanged(object sender, EventArgs e)
        {
            light.Outer = (float)nudOuter.Value;
        }

        private void nudRed_ValueChanged(object sender, EventArgs e)
        {
            updateLightColour();
        }

        private void nudGreen_ValueChanged(object sender, EventArgs e)
        {
            updateLightColour();
        }

        private void nudBlue_ValueChanged(object sender, EventArgs e)
        {
            updateLightColour();
        }

        private void nudIntensity_ValueChanged(object sender, EventArgs e)
        {
            light.Intensity = (float)nudIntensity.Value;
        }

        private void chkParallelSplit_CheckedChanged(object sender, EventArgs e)
        {
            if (SceneManager.Current != null) { SceneManager.Current.UpdateProgress("This doesn't do anything!"); }
        }

        private void chkVisualiseSplits_CheckedChanged(object sender, EventArgs e)
        {
            if (SceneManager.Current != null) { SceneManager.Current.UpdateProgress("This doesn't do anything!"); }
        }

        private void chkUsePool_CheckedChanged(object sender, EventArgs e)
        {
            if (light.Flags.HasFlag(LIGHT.LightFlags.UsePool))
            {
                light.Flags &= ~LIGHT.LightFlags.UsePool;
            }
            else
            {
                light.Flags |= LIGHT.LightFlags.UsePool;
            }
        }

        private void nudSplitCount_ValueChanged(object sender, EventArgs e)
        {
            light.SplitCount = (int)nudSplitCount.Value;
        }

        private void nudSplitDistribn_ValueChanged(object sender, EventArgs e)
        {
            light.SplitDistribution = (float)nudSplitDistribn.Value;
        }

        private void nudShadCoverX_ValueChanged(object sender, EventArgs e)
        {
            light.ShadowCoverX = (float)nudShadCoverX.Value;
        }

        private void nudShadCoverY_ValueChanged(object sender, EventArgs e)
        {
            light.ShadowCoverY = (float)nudShadCoverY.Value;
        }

        private void nudShadResX_ValueChanged(object sender, EventArgs e)
        {
            light.ShadowResolutionX = nudShadResX.Value;
        }

        private void nudShadResY_ValueChanged(object sender, EventArgs e)
        {
            light.ShadowResolutionY = nudShadResY.Value;
        }

        private void nudShadIntensity_ValueChanged(object sender, EventArgs e)
        {
            light.ShadowIntensity = (float)nudShadIntensity.Value;
        }

        private void nudGoboScaleX_ValueChanged(object sender, EventArgs e)
        {
            light.GoboScaleX = (float)nudGoboScaleX.Value;
        }

        private void nudGoboScaleY_ValueChanged(object sender, EventArgs e)
        {
            light.GoboScaleY = (float)nudGoboScaleY.Value;
        }

        private void nudGoboOffsetX_ValueChanged(object sender, EventArgs e)
        {
            light.GoboOffsetX = (float)nudGoboOffsetX.Value;
        }

        private void nudGoboOffsetY_ValueChanged(object sender, EventArgs e)
        {
            light.GoboOffsetY = (float)nudGoboOffsetY.Value;
        }

        private void nudShadowBias_ValueChanged(object sender, EventArgs e)
        {
            light.ShadowBias = (float)nudShadowBias.Value;
        }

        private void nudLightNearClip_ValueChanged(object sender, EventArgs e)
        {
            light.LightNearClip = (float)nudLightNearClip.Value;
        }

        private void nudShadowDist_ValueChanged(object sender, EventArgs e)
        {
            light.ShadowDistance = (float)nudShadowDist.Value;
        }

        private void chkUseGobo_CheckedChanged(object sender, EventArgs e)
        {
            toggleGoboUI();

            if (light.Flags.HasFlag(LIGHT.LightFlags.UsesGobo))
            {
                light.Flags &= ~LIGHT.LightFlags.UsesGobo;
            }
            else
            {
                light.Flags |= LIGHT.LightFlags.UsesGobo;
            }
        }

        private void lblGobo_Click(object sender, EventArgs e)
        {
            if (SceneManager.Current != null) { SceneManager.Current.UpdateProgress("TODO: FileBrowser for GOBO texture"); }
        }

        private void nudEdgeRed_ValueChanged(object sender, EventArgs e)
        {
            updateEdgeColour();
        }

        private void nudEdgeGreen_ValueChanged(object sender, EventArgs e)
        {
            updateEdgeColour();
        }

        private void nudEdgeBlue_ValueChanged(object sender, EventArgs e)
        {
            updateEdgeColour();
        }
    }
}
