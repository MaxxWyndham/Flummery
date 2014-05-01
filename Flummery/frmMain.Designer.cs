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
            this.ofdBrowse = new System.Windows.Forms.OpenFileDialog();
            this.fbdBrowse = new System.Windows.Forms.FolderBrowserDialog();
            this.scViewMaterial = new System.Windows.Forms.SplitContainer();
            this.scTreeView = new System.Windows.Forms.SplitContainer();
            this.tvNodes = new System.Windows.Forms.TreeView();
            this.flpMaterials = new System.Windows.Forms.FlowLayoutPanel();
            this.ssStatus = new System.Windows.Forms.StatusStrip();
            this.tsslProgress = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.scViewMaterial)).BeginInit();
            this.scViewMaterial.Panel1.SuspendLayout();
            this.scViewMaterial.Panel2.SuspendLayout();
            this.scViewMaterial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scTreeView)).BeginInit();
            this.scTreeView.Panel1.SuspendLayout();
            this.scTreeView.SuspendLayout();
            this.ssStatus.SuspendLayout();
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
            this.tsslProgress});
            this.ssStatus.Location = new System.Drawing.Point(0, 620);
            this.ssStatus.Name = "ssStatus";
            this.ssStatus.Size = new System.Drawing.Size(978, 22);
            this.ssStatus.SizingGrip = false;
            this.ssStatus.TabIndex = 2;
            this.ssStatus.Text = "statusStrip1";
            // 
            // tsslProgress
            // 
            this.tsslProgress.Name = "tsslProgress";
            this.tsslProgress.Size = new System.Drawing.Size(60, 17);
            this.tsslProgress.Text = "[progress]";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 642);
            this.Controls.Add(this.ssStatus);
            this.Controls.Add(this.scViewMaterial);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Flummery";
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

    }
}

