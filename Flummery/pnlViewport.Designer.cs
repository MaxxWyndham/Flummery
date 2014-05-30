namespace Flummery
{
    partial class pnlViewport
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
            this.paneViewport = new System.Windows.Forms.Panel();
            this.cmsViewport.SuspendLayout();
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
            // paneViewport
            // 
            this.paneViewport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paneViewport.Location = new System.Drawing.Point(0, 0);
            this.paneViewport.Name = "paneViewport";
            this.paneViewport.Size = new System.Drawing.Size(284, 261);
            this.paneViewport.TabIndex = 1;
            // 
            // pnlViewport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.paneViewport);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "pnlViewport";
            this.Text = "pnlViewport";
            this.Load += new System.EventHandler(this.pnlViewport_Load);
            this.cmsViewport.ResumeLayout(false);
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
        private System.Windows.Forms.Panel paneViewport;
    }
}