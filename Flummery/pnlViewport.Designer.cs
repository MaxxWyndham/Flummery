namespace Flummery
{
    partial class PnlViewport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cmsViewport = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiViewportMaximise = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiViewportMinimise = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiViewport3D = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiViewportTop = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiViewportFront = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiViewportRight = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiViewportBottom = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiViewportBack = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiViewportLeft = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiViewportSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiViewportCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.tscViewport = new System.Windows.Forms.ToolStripContainer();
            this.paneViewport = new System.Windows.Forms.Panel();
            this.tsStatic = new System.Windows.Forms.ToolStrip();
            this.tsbSelect = new System.Windows.Forms.ToolStripButton();
            this.tsbPan = new System.Windows.Forms.ToolStripButton();
            this.tsbZoom = new System.Windows.Forms.ToolStripButton();
            this.tsbRotate = new System.Windows.Forms.ToolStripButton();
            this.tssBar1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbFrame = new System.Windows.Forms.ToolStripButton();
            this.tslContext = new System.Windows.Forms.ToolStripLabel();
            this.cmsViewport.SuspendLayout();
            this.tscViewport.ContentPanel.SuspendLayout();
            this.tscViewport.TopToolStripPanel.SuspendLayout();
            this.tscViewport.SuspendLayout();
            this.tsStatic.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsViewport
            // 
            this.cmsViewport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiViewportMaximise,
            this.tsmiViewportMinimise,
            this.toolStripSeparator1,
            this.tsmiViewport3D,
            this.tsmiViewportTop,
            this.tsmiViewportFront,
            this.tsmiViewportRight,
            this.tsmiViewportBottom,
            this.tsmiViewportBack,
            this.tsmiViewportLeft,
            this.toolStripSeparator2,
            this.tsmiViewportSetup,
            this.toolStripSeparator3,
            this.tsmiViewportCancel});
            this.cmsViewport.Name = "cmsViewport";
            this.cmsViewport.Size = new System.Drawing.Size(126, 264);
            // 
            // tsmiViewportMaximise
            // 
            this.tsmiViewportMaximise.Name = "tsmiViewportMaximise";
            this.tsmiViewportMaximise.Size = new System.Drawing.Size(125, 22);
            this.tsmiViewportMaximise.Text = "Maximise";
            this.tsmiViewportMaximise.Click += new System.EventHandler(this.tsmiViewportMaximise_Click);
            // 
            // tsmiViewportMinimise
            // 
            this.tsmiViewportMinimise.Enabled = false;
            this.tsmiViewportMinimise.Name = "tsmiViewportMinimise";
            this.tsmiViewportMinimise.Size = new System.Drawing.Size(125, 22);
            this.tsmiViewportMinimise.Text = "Minimise";
            this.tsmiViewportMinimise.Click += new System.EventHandler(this.tsmiViewportMinimise_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(122, 6);
            // 
            // tsmiViewport3D
            // 
            this.tsmiViewport3D.Enabled = false;
            this.tsmiViewport3D.Name = "tsmiViewport3D";
            this.tsmiViewport3D.Size = new System.Drawing.Size(125, 22);
            this.tsmiViewport3D.Text = "3D";
            this.tsmiViewport3D.Click += new System.EventHandler(this.tsmiViewportPreset_Click);
            // 
            // tsmiViewportTop
            // 
            this.tsmiViewportTop.Enabled = false;
            this.tsmiViewportTop.Name = "tsmiViewportTop";
            this.tsmiViewportTop.Size = new System.Drawing.Size(125, 22);
            this.tsmiViewportTop.Text = "Top";
            this.tsmiViewportTop.Click += new System.EventHandler(this.tsmiViewportPreset_Click);
            // 
            // tsmiViewportFront
            // 
            this.tsmiViewportFront.Enabled = false;
            this.tsmiViewportFront.Name = "tsmiViewportFront";
            this.tsmiViewportFront.Size = new System.Drawing.Size(125, 22);
            this.tsmiViewportFront.Text = "Front";
            this.tsmiViewportFront.Click += new System.EventHandler(this.tsmiViewportPreset_Click);
            // 
            // tsmiViewportRight
            // 
            this.tsmiViewportRight.Enabled = false;
            this.tsmiViewportRight.Name = "tsmiViewportRight";
            this.tsmiViewportRight.Size = new System.Drawing.Size(125, 22);
            this.tsmiViewportRight.Text = "Right";
            this.tsmiViewportRight.Click += new System.EventHandler(this.tsmiViewportPreset_Click);
            // 
            // tsmiViewportBottom
            // 
            this.tsmiViewportBottom.Enabled = false;
            this.tsmiViewportBottom.Name = "tsmiViewportBottom";
            this.tsmiViewportBottom.Size = new System.Drawing.Size(125, 22);
            this.tsmiViewportBottom.Text = "Bottom";
            this.tsmiViewportBottom.Click += new System.EventHandler(this.tsmiViewportPreset_Click);
            // 
            // tsmiViewportBack
            // 
            this.tsmiViewportBack.Enabled = false;
            this.tsmiViewportBack.Name = "tsmiViewportBack";
            this.tsmiViewportBack.Size = new System.Drawing.Size(125, 22);
            this.tsmiViewportBack.Text = "Back";
            this.tsmiViewportBack.Click += new System.EventHandler(this.tsmiViewportPreset_Click);
            // 
            // tsmiViewportLeft
            // 
            this.tsmiViewportLeft.Enabled = false;
            this.tsmiViewportLeft.Name = "tsmiViewportLeft";
            this.tsmiViewportLeft.Size = new System.Drawing.Size(125, 22);
            this.tsmiViewportLeft.Text = "Left";
            this.tsmiViewportLeft.Click += new System.EventHandler(this.tsmiViewportPreset_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(122, 6);
            // 
            // tsmiViewportSetup
            // 
            this.tsmiViewportSetup.Enabled = false;
            this.tsmiViewportSetup.Name = "tsmiViewportSetup";
            this.tsmiViewportSetup.Size = new System.Drawing.Size(125, 22);
            this.tsmiViewportSetup.Text = "Setup...";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(122, 6);
            // 
            // tsmiViewportCancel
            // 
            this.tsmiViewportCancel.Name = "tsmiViewportCancel";
            this.tsmiViewportCancel.Size = new System.Drawing.Size(125, 22);
            this.tsmiViewportCancel.Text = "Cancel";
            // 
            // tscViewport
            // 
            // 
            // tscViewport.ContentPanel
            // 
            this.tscViewport.ContentPanel.Controls.Add(this.paneViewport);
            this.tscViewport.ContentPanel.Size = new System.Drawing.Size(547, 417);
            this.tscViewport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tscViewport.Location = new System.Drawing.Point(0, 0);
            this.tscViewport.Name = "tscViewport";
            this.tscViewport.Size = new System.Drawing.Size(547, 442);
            this.tscViewport.TabIndex = 12;
            this.tscViewport.Text = "toolStripContainer1";
            // 
            // tscViewport.TopToolStripPanel
            // 
            this.tscViewport.TopToolStripPanel.Controls.Add(this.tsStatic);
            // 
            // paneViewport
            // 
            this.paneViewport.BackColor = System.Drawing.SystemColors.Control;
            this.paneViewport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paneViewport.Location = new System.Drawing.Point(0, 0);
            this.paneViewport.Name = "paneViewport";
            this.paneViewport.Size = new System.Drawing.Size(547, 417);
            this.paneViewport.TabIndex = 2;
            // 
            // tsStatic
            // 
            this.tsStatic.AutoSize = false;
            this.tsStatic.Dock = System.Windows.Forms.DockStyle.None;
            this.tsStatic.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsStatic.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSelect,
            this.tsbPan,
            this.tsbZoom,
            this.tsbRotate,
            this.tssBar1,
            this.tsbFrame,
            this.tslContext});
            this.tsStatic.Location = new System.Drawing.Point(0, 0);
            this.tsStatic.Name = "tsStatic";
            this.tsStatic.Size = new System.Drawing.Size(547, 25);
            this.tsStatic.Stretch = true;
            this.tsStatic.TabIndex = 0;
            // 
            // tsbSelect
            // 
            this.tsbSelect.Checked = true;
            this.tsbSelect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsbSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSelect.Image = global::Flummery.Properties.Resources.interface_select_borderless_16x16;
            this.tsbSelect.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSelect.Name = "tsbSelect";
            this.tsbSelect.Size = new System.Drawing.Size(23, 22);
            this.tsbSelect.Text = "Select";
            this.tsbSelect.ToolTipText = "Select (V)";
            this.tsbSelect.Click += new System.EventHandler(this.tsbSelect_Click);
            // 
            // tsbPan
            // 
            this.tsbPan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPan.Image = global::Flummery.Properties.Resources.interface_pan_borderless_16x16;
            this.tsbPan.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbPan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPan.Name = "tsbPan";
            this.tsbPan.Size = new System.Drawing.Size(23, 22);
            this.tsbPan.Text = "Pan";
            this.tsbPan.ToolTipText = "Pan (X)";
            this.tsbPan.Click += new System.EventHandler(this.tsbPan_Click);
            // 
            // tsbZoom
            // 
            this.tsbZoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbZoom.Image = global::Flummery.Properties.Resources.interface_zoom_borderless_16x16;
            this.tsbZoom.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbZoom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbZoom.Name = "tsbZoom";
            this.tsbZoom.Size = new System.Drawing.Size(23, 22);
            this.tsbZoom.Text = "Zoom";
            this.tsbZoom.ToolTipText = "Zoom (Z)";
            this.tsbZoom.Click += new System.EventHandler(this.tsbZoom_Click);
            // 
            // tsbRotate
            // 
            this.tsbRotate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRotate.Image = global::Flummery.Properties.Resources.interface_rotate_borderless_16x16;
            this.tsbRotate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbRotate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRotate.Name = "tsbRotate";
            this.tsbRotate.Size = new System.Drawing.Size(23, 22);
            this.tsbRotate.Text = "Rotate";
            this.tsbRotate.ToolTipText = "Rotate (C)";
            this.tsbRotate.Click += new System.EventHandler(this.tsbRotate_Click);
            // 
            // tssBar1
            // 
            this.tssBar1.Name = "tssBar1";
            this.tssBar1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbFrame
            // 
            this.tsbFrame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFrame.Image = global::Flummery.Properties.Resources.interface_frame_borderless_16x16;
            this.tsbFrame.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbFrame.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFrame.Name = "tsbFrame";
            this.tsbFrame.Size = new System.Drawing.Size(23, 22);
            this.tsbFrame.Text = "Frame";
            this.tsbFrame.ToolTipText = "Frame (F)";
            this.tsbFrame.Click += new System.EventHandler(this.tsbFrame_Click);
            // 
            // tslContext
            // 
            this.tslContext.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tslContext.Name = "tslContext";
            this.tslContext.Size = new System.Drawing.Size(0, 22);
            this.tslContext.Click += new System.EventHandler(this.tslContext_Click);
            // 
            // PnlViewport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 442);
            this.Controls.Add(this.tscViewport);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "PnlViewport";
            this.Text = "Viewport";
            this.Load += new System.EventHandler(this.pnlViewport_Load);
            this.cmsViewport.ResumeLayout(false);
            this.tscViewport.ContentPanel.ResumeLayout(false);
            this.tscViewport.TopToolStripPanel.ResumeLayout(false);
            this.tscViewport.ResumeLayout(false);
            this.tscViewport.PerformLayout();
            this.tsStatic.ResumeLayout(false);
            this.tsStatic.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmsViewport;
        private System.Windows.Forms.ToolStripMenuItem tsmiViewportMaximise;
        private System.Windows.Forms.ToolStripMenuItem tsmiViewportMinimise;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiViewport3D;
        private System.Windows.Forms.ToolStripMenuItem tsmiViewportTop;
        private System.Windows.Forms.ToolStripMenuItem tsmiViewportFront;
        private System.Windows.Forms.ToolStripMenuItem tsmiViewportRight;
        private System.Windows.Forms.ToolStripMenuItem tsmiViewportBottom;
        private System.Windows.Forms.ToolStripMenuItem tsmiViewportBack;
        private System.Windows.Forms.ToolStripMenuItem tsmiViewportLeft;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiViewportSetup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsmiViewportCancel;
        private System.Windows.Forms.ToolStripContainer tscViewport;
        private System.Windows.Forms.Panel paneViewport;
        private System.Windows.Forms.ToolStrip tsStatic;
        private System.Windows.Forms.ToolStripButton tsbSelect;
        private System.Windows.Forms.ToolStripButton tsbPan;
        private System.Windows.Forms.ToolStripButton tsbZoom;
        private System.Windows.Forms.ToolStripButton tsbRotate;
        private System.Windows.Forms.ToolStripSeparator tssBar1;
        private System.Windows.Forms.ToolStripButton tsbFrame;
        private System.Windows.Forms.ToolStripLabel tslContext;
    }
}