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
            this.glcViewport = new OpenTK.GLControl();
            this.ofdBrowse = new System.Windows.Forms.OpenFileDialog();
            this.pgSettings = new System.Windows.Forms.PropertyGrid();
            this.tvOverview = new System.Windows.Forms.TreeView();
            this.txtDebug = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // glcViewport
            // 
            this.glcViewport.BackColor = System.Drawing.Color.Black;
            this.glcViewport.Location = new System.Drawing.Point(187, 12);
            this.glcViewport.Name = "glcViewport";
            this.glcViewport.Size = new System.Drawing.Size(800, 535);
            this.glcViewport.TabIndex = 0;
            this.glcViewport.VSync = false;
            this.glcViewport.Load += new System.EventHandler(this.glcViewport_Load);
            this.glcViewport.Paint += new System.Windows.Forms.PaintEventHandler(this.glcViewport_Paint);
            // 
            // pgSettings
            // 
            this.pgSettings.Location = new System.Drawing.Point(993, 12);
            this.pgSettings.Name = "pgSettings";
            this.pgSettings.Size = new System.Drawing.Size(189, 623);
            this.pgSettings.TabIndex = 1;
            // 
            // tvOverview
            // 
            this.tvOverview.Location = new System.Drawing.Point(12, 12);
            this.tvOverview.Name = "tvOverview";
            this.tvOverview.Size = new System.Drawing.Size(169, 623);
            this.tvOverview.TabIndex = 2;
            // 
            // txtDebug
            // 
            this.txtDebug.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDebug.Location = new System.Drawing.Point(187, 553);
            this.txtDebug.Multiline = true;
            this.txtDebug.Name = "txtDebug";
            this.txtDebug.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDebug.Size = new System.Drawing.Size(800, 82);
            this.txtDebug.TabIndex = 3;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 675);
            this.Controls.Add(this.txtDebug);
            this.Controls.Add(this.tvOverview);
            this.Controls.Add(this.pgSettings);
            this.Controls.Add(this.glcViewport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "Flummery";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl glcViewport;
        //private CustomGLControl glcViewport;
        private System.Windows.Forms.OpenFileDialog ofdBrowse;
        private System.Windows.Forms.PropertyGrid pgSettings;
        private System.Windows.Forms.TreeView tvOverview;
        private System.Windows.Forms.TextBox txtDebug;

    }
}

