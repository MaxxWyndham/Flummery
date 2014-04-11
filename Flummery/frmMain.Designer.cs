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
            this.glcViewport = new OpenTK.GLControl();
            this.SuspendLayout();
            // 
            // fbdBrowse
            // 
            this.fbdBrowse.ShowNewFolderButton = false;
            // 
            // glcViewport
            // 
            this.glcViewport.BackColor = System.Drawing.Color.Black;
            this.glcViewport.Location = new System.Drawing.Point(12, 12);
            this.glcViewport.Name = "glcViewport";
            this.glcViewport.Size = new System.Drawing.Size(1177, 775);
            this.glcViewport.TabIndex = 0;
            this.glcViewport.VSync = false;
            this.glcViewport.Load += new System.EventHandler(this.glcViewport_Load);
            this.glcViewport.Paint += new System.Windows.Forms.PaintEventHandler(this.glcViewport_Paint);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1201, 817);
            this.Controls.Add(this.glcViewport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Flummery";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        //private CustomGLControl glcViewport;
        private System.Windows.Forms.OpenFileDialog ofdBrowse;
        private System.Windows.Forms.FolderBrowserDialog fbdBrowse;
        private OpenTK.GLControl glcViewport;

    }
}

