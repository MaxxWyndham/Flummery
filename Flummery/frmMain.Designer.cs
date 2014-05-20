namespace Flummery
{
    partial class frmMain
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
        /// this.glcViewport = new OpenTK.GLControl();
        /// this.glcViewport = new Flummery.CustomGLControl();
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ofdBrowse = new System.Windows.Forms.OpenFileDialog();
            this.fbdBrowse = new System.Windows.Forms.FolderBrowserDialog();
            this.scViewMaterial = new System.Windows.Forms.SplitContainer();
            this.scTreeView = new System.Windows.Forms.SplitContainer();
            this.tvNodes = new System.Windows.Forms.TreeView();
            this.flpMaterials = new System.Windows.Forms.FlowLayoutPanel();
            this.ssStatus = new System.Windows.Forms.StatusStrip();
            this.tsslProgress = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslActionScaling = new System.Windows.Forms.ToolStripStatusLabel();
            this.sfdBrowse = new System.Windows.Forms.SaveFileDialog();
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
            ((System.ComponentModel.ISupportInitialize)(this.scViewMaterial)).BeginInit();
            this.scViewMaterial.Panel1.SuspendLayout();
            this.scViewMaterial.Panel2.SuspendLayout();
            this.scViewMaterial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scTreeView)).BeginInit();
            this.scTreeView.Panel1.SuspendLayout();
            this.scTreeView.SuspendLayout();
            this.ssStatus.SuspendLayout();
            this.cmsViewport.SuspendLayout();
            this.SuspendLayout();
            // 
            // fbdBrowse
            // 
            this.fbdBrowse.ShowNewFolderButton = false;
            // 
            // scViewMaterial
            // 
            this.scViewMaterial.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scViewMaterial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scViewMaterial.Location = new System.Drawing.Point(0, 0);
            this.scViewMaterial.Name = "scViewMaterial";
            this.scViewMaterial.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scViewMaterial.Panel1
            // 
            this.scViewMaterial.Panel1.Controls.Add(this.scTreeView);
            this.scViewMaterial.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // scViewMaterial.Panel2
            // 
            this.scViewMaterial.Panel2.Controls.Add(this.flpMaterials);
            this.scViewMaterial.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.scViewMaterial.Size = new System.Drawing.Size(978, 617);
            this.scViewMaterial.SplitterDistance = 506;
            this.scViewMaterial.TabIndex = 1;
            // 
            // scTreeView
            // 
            this.scTreeView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scTreeView.Location = new System.Drawing.Point(0, 0);
            this.scTreeView.Name = "scTreeView";
            // 
            // scTreeView.Panel1
            // 
            this.scTreeView.Panel1.Controls.Add(this.tvNodes);
            this.scTreeView.Size = new System.Drawing.Size(978, 506);
            this.scTreeView.SplitterDistance = 250;
            this.scTreeView.TabIndex = 0;
            // 
            // tvNodes
            // 
            this.tvNodes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvNodes.Location = new System.Drawing.Point(3, 3);
            this.tvNodes.Name = "tvNodes";
            this.tvNodes.Size = new System.Drawing.Size(242, 498);
            this.tvNodes.TabIndex = 0;
            this.tvNodes.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvNodes_NodeMouseClick);
            this.tvNodes.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvNodes_NodeMouseDoubleClick);
            // 
            // flpMaterials
            // 
            this.flpMaterials.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpMaterials.AutoScroll = true;
            this.flpMaterials.Location = new System.Drawing.Point(3, 3);
            this.flpMaterials.Name = "flpMaterials";
            this.flpMaterials.Size = new System.Drawing.Size(970, 99);
            this.flpMaterials.TabIndex = 0;
            this.flpMaterials.WrapContents = false;
            // 
            // ssStatus
            // 
            this.ssStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslProgress,
            this.tsslActionScaling});
            this.ssStatus.Location = new System.Drawing.Point(0, 618);
            this.ssStatus.Name = "ssStatus";
            this.ssStatus.Size = new System.Drawing.Size(978, 24);
            this.ssStatus.TabIndex = 2;
            this.ssStatus.Text = "statusStrip1";
            // 
            // tsslProgress
            // 
            this.tsslProgress.Name = "tsslProgress";
            this.tsslProgress.Size = new System.Drawing.Size(843, 19);
            this.tsslProgress.Spring = true;
            this.tsslProgress.Text = "[progress]";
            this.tsslProgress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tsslActionScaling
            // 
            this.tsslActionScaling.AutoSize = false;
            this.tsslActionScaling.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tsslActionScaling.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.tsslActionScaling.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsslActionScaling.Name = "tsslActionScaling";
            this.tsslActionScaling.Size = new System.Drawing.Size(120, 19);
            this.tsslActionScaling.Text = "Action Scaling: 10.000";
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
            this.cmsViewport.Size = new System.Drawing.Size(125, 264);
            // 
            // tsmiViewportMaximise
            // 
            this.tsmiViewportMaximise.Name = "tsmiViewportMaximise";
            this.tsmiViewportMaximise.Size = new System.Drawing.Size(124, 22);
            this.tsmiViewportMaximise.Text = "Maximise";
            this.tsmiViewportMaximise.Click += new System.EventHandler(this.tsmiViewportMaximise_Click);
            // 
            // tsmiViewportMinimise
            // 
            this.tsmiViewportMinimise.Enabled = false;
            this.tsmiViewportMinimise.Name = "tsmiViewportMinimise";
            this.tsmiViewportMinimise.Size = new System.Drawing.Size(124, 22);
            this.tsmiViewportMinimise.Text = "Minimise";
            this.tsmiViewportMinimise.Click += new System.EventHandler(this.tsmiViewportMinimise_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(121, 6);
            // 
            // tsmiViewport3D
            // 
            this.tsmiViewport3D.Enabled = false;
            this.tsmiViewport3D.Name = "tsmiViewport3D";
            this.tsmiViewport3D.Size = new System.Drawing.Size(124, 22);
            this.tsmiViewport3D.Text = "3D";
            this.tsmiViewport3D.Click += new System.EventHandler(this.tsmiViewportPreset_Click);
            // 
            // tsmiViewportTop
            // 
            this.tsmiViewportTop.Enabled = false;
            this.tsmiViewportTop.Name = "tsmiViewportTop";
            this.tsmiViewportTop.Size = new System.Drawing.Size(124, 22);
            this.tsmiViewportTop.Text = "Top";
            this.tsmiViewportTop.Click += new System.EventHandler(this.tsmiViewportPreset_Click);
            // 
            // tsmiViewportFront
            // 
            this.tsmiViewportFront.Enabled = false;
            this.tsmiViewportFront.Name = "tsmiViewportFront";
            this.tsmiViewportFront.Size = new System.Drawing.Size(124, 22);
            this.tsmiViewportFront.Text = "Front";
            this.tsmiViewportFront.Click += new System.EventHandler(this.tsmiViewportPreset_Click);
            // 
            // tsmiViewportRight
            // 
            this.tsmiViewportRight.Enabled = false;
            this.tsmiViewportRight.Name = "tsmiViewportRight";
            this.tsmiViewportRight.Size = new System.Drawing.Size(124, 22);
            this.tsmiViewportRight.Text = "Right";
            this.tsmiViewportRight.Click += new System.EventHandler(this.tsmiViewportPreset_Click);
            // 
            // tsmiViewportBottom
            // 
            this.tsmiViewportBottom.Enabled = false;
            this.tsmiViewportBottom.Name = "tsmiViewportBottom";
            this.tsmiViewportBottom.Size = new System.Drawing.Size(124, 22);
            this.tsmiViewportBottom.Text = "Bottom";
            this.tsmiViewportBottom.Click += new System.EventHandler(this.tsmiViewportPreset_Click);
            // 
            // tsmiViewportBack
            // 
            this.tsmiViewportBack.Enabled = false;
            this.tsmiViewportBack.Name = "tsmiViewportBack";
            this.tsmiViewportBack.Size = new System.Drawing.Size(124, 22);
            this.tsmiViewportBack.Text = "Back";
            this.tsmiViewportBack.Click += new System.EventHandler(this.tsmiViewportPreset_Click);
            // 
            // tsmiViewportLeft
            // 
            this.tsmiViewportLeft.Enabled = false;
            this.tsmiViewportLeft.Name = "tsmiViewportLeft";
            this.tsmiViewportLeft.Size = new System.Drawing.Size(124, 22);
            this.tsmiViewportLeft.Text = "Left";
            this.tsmiViewportLeft.Click += new System.EventHandler(this.tsmiViewportPreset_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(121, 6);
            // 
            // tsmiViewportSetup
            // 
            this.tsmiViewportSetup.Enabled = false;
            this.tsmiViewportSetup.Name = "tsmiViewportSetup";
            this.tsmiViewportSetup.Size = new System.Drawing.Size(124, 22);
            this.tsmiViewportSetup.Text = "Setup...";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(121, 6);
            // 
            // tsmiViewportCancel
            // 
            this.tsmiViewportCancel.Name = "tsmiViewportCancel";
            this.tsmiViewportCancel.Size = new System.Drawing.Size(124, 22);
            this.tsmiViewportCancel.Text = "Cancel";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 642);
            this.Controls.Add(this.ssStatus);
            this.Controls.Add(this.scViewMaterial);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Flummery";
            this.Activated += new System.EventHandler(this.frmMain_Activated);
            this.Deactivate += new System.EventHandler(this.frmMain_Deactivate);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.scViewMaterial.Panel1.ResumeLayout(false);
            this.scViewMaterial.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scViewMaterial)).EndInit();
            this.scViewMaterial.ResumeLayout(false);
            this.scTreeView.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scTreeView)).EndInit();
            this.scTreeView.ResumeLayout(false);
            this.ssStatus.ResumeLayout(false);
            this.ssStatus.PerformLayout();
            this.cmsViewport.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private CustomGLControl glcViewport;
        private System.Windows.Forms.OpenFileDialog ofdBrowse;
        private System.Windows.Forms.FolderBrowserDialog fbdBrowse;
        private System.Windows.Forms.SplitContainer scViewMaterial;
        private System.Windows.Forms.SplitContainer scTreeView;
        private System.Windows.Forms.TreeView tvNodes;
        private System.Windows.Forms.StatusStrip ssStatus;
        private System.Windows.Forms.ToolStripStatusLabel tsslProgress;
        private System.Windows.Forms.FlowLayoutPanel flpMaterials;
        private System.Windows.Forms.ToolStripStatusLabel tsslActionScaling;
        private System.Windows.Forms.SaveFileDialog sfdBrowse;
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

    }
}

