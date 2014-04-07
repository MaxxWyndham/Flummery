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
            this.tvOverview = new System.Windows.Forms.TreeView();
            this.txtDebug = new System.Windows.Forms.TextBox();
            this.fbdBrowse = new System.Windows.Forms.FolderBrowserDialog();
            this.txtM11 = new System.Windows.Forms.TextBox();
            this.txtM12 = new System.Windows.Forms.TextBox();
            this.txtM13 = new System.Windows.Forms.TextBox();
            this.txtM21 = new System.Windows.Forms.TextBox();
            this.txtM22 = new System.Windows.Forms.TextBox();
            this.txtM23 = new System.Windows.Forms.TextBox();
            this.txtM31 = new System.Windows.Forms.TextBox();
            this.txtM32 = new System.Windows.Forms.TextBox();
            this.txtM33 = new System.Windows.Forms.TextBox();
            this.txtM41 = new System.Windows.Forms.TextBox();
            this.txtM42 = new System.Windows.Forms.TextBox();
            this.txtM43 = new System.Windows.Forms.TextBox();
            this.cmdAccept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // glcViewport
            // 
            this.glcViewport.BackColor = System.Drawing.Color.Black;
            this.glcViewport.Location = new System.Drawing.Point(301, 12);
            this.glcViewport.Name = "glcViewport";
            this.glcViewport.Size = new System.Drawing.Size(881, 535);
            this.glcViewport.TabIndex = 0;
            this.glcViewport.VSync = false;
            this.glcViewport.Load += new System.EventHandler(this.glcViewport_Load);
            this.glcViewport.Paint += new System.Windows.Forms.PaintEventHandler(this.glcViewport_Paint);
            // 
            // tvOverview
            // 
            this.tvOverview.Location = new System.Drawing.Point(12, 12);
            this.tvOverview.Name = "tvOverview";
            this.tvOverview.Size = new System.Drawing.Size(283, 668);
            this.tvOverview.TabIndex = 2;
            this.tvOverview.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvOverview_OnDoubleClick);
            // 
            // txtDebug
            // 
            this.txtDebug.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDebug.Location = new System.Drawing.Point(541, 553);
            this.txtDebug.Multiline = true;
            this.txtDebug.Name = "txtDebug";
            this.txtDebug.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDebug.Size = new System.Drawing.Size(641, 127);
            this.txtDebug.TabIndex = 3;
            // 
            // fbdBrowse
            // 
            this.fbdBrowse.ShowNewFolderButton = false;
            // 
            // txtM11
            // 
            this.txtM11.Location = new System.Drawing.Point(301, 553);
            this.txtM11.Name = "txtM11";
            this.txtM11.Size = new System.Drawing.Size(74, 20);
            this.txtM11.TabIndex = 4;
            // 
            // txtM12
            // 
            this.txtM12.Location = new System.Drawing.Point(381, 553);
            this.txtM12.Name = "txtM12";
            this.txtM12.Size = new System.Drawing.Size(74, 20);
            this.txtM12.TabIndex = 5;
            // 
            // txtM13
            // 
            this.txtM13.Location = new System.Drawing.Point(461, 553);
            this.txtM13.Name = "txtM13";
            this.txtM13.Size = new System.Drawing.Size(74, 20);
            this.txtM13.TabIndex = 6;
            // 
            // txtM21
            // 
            this.txtM21.Location = new System.Drawing.Point(301, 579);
            this.txtM21.Name = "txtM21";
            this.txtM21.Size = new System.Drawing.Size(74, 20);
            this.txtM21.TabIndex = 9;
            // 
            // txtM22
            // 
            this.txtM22.Location = new System.Drawing.Point(381, 579);
            this.txtM22.Name = "txtM22";
            this.txtM22.Size = new System.Drawing.Size(74, 20);
            this.txtM22.TabIndex = 8;
            // 
            // txtM23
            // 
            this.txtM23.Location = new System.Drawing.Point(461, 579);
            this.txtM23.Name = "txtM23";
            this.txtM23.Size = new System.Drawing.Size(74, 20);
            this.txtM23.TabIndex = 7;
            // 
            // txtM31
            // 
            this.txtM31.Location = new System.Drawing.Point(301, 605);
            this.txtM31.Name = "txtM31";
            this.txtM31.Size = new System.Drawing.Size(74, 20);
            this.txtM31.TabIndex = 12;
            // 
            // txtM32
            // 
            this.txtM32.Location = new System.Drawing.Point(381, 605);
            this.txtM32.Name = "txtM32";
            this.txtM32.Size = new System.Drawing.Size(74, 20);
            this.txtM32.TabIndex = 11;
            // 
            // txtM33
            // 
            this.txtM33.Location = new System.Drawing.Point(461, 605);
            this.txtM33.Name = "txtM33";
            this.txtM33.Size = new System.Drawing.Size(74, 20);
            this.txtM33.TabIndex = 10;
            // 
            // txtM41
            // 
            this.txtM41.Location = new System.Drawing.Point(301, 631);
            this.txtM41.Name = "txtM41";
            this.txtM41.Size = new System.Drawing.Size(74, 20);
            this.txtM41.TabIndex = 15;
            // 
            // txtM42
            // 
            this.txtM42.Location = new System.Drawing.Point(381, 631);
            this.txtM42.Name = "txtM42";
            this.txtM42.Size = new System.Drawing.Size(74, 20);
            this.txtM42.TabIndex = 14;
            // 
            // txtM43
            // 
            this.txtM43.Location = new System.Drawing.Point(461, 631);
            this.txtM43.Name = "txtM43";
            this.txtM43.Size = new System.Drawing.Size(74, 20);
            this.txtM43.TabIndex = 13;
            // 
            // cmdAccept
            // 
            this.cmdAccept.Location = new System.Drawing.Point(301, 657);
            this.cmdAccept.Name = "cmdAccept";
            this.cmdAccept.Size = new System.Drawing.Size(235, 23);
            this.cmdAccept.TabIndex = 16;
            this.cmdAccept.Text = "accept and reload";
            this.cmdAccept.UseVisualStyleBackColor = true;
            this.cmdAccept.Click += new System.EventHandler(this.cmdAccept_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 721);
            this.Controls.Add(this.cmdAccept);
            this.Controls.Add(this.txtM41);
            this.Controls.Add(this.txtM42);
            this.Controls.Add(this.txtM43);
            this.Controls.Add(this.txtM31);
            this.Controls.Add(this.txtM32);
            this.Controls.Add(this.txtM33);
            this.Controls.Add(this.txtM21);
            this.Controls.Add(this.txtM22);
            this.Controls.Add(this.txtM23);
            this.Controls.Add(this.txtM13);
            this.Controls.Add(this.txtM12);
            this.Controls.Add(this.txtM11);
            this.Controls.Add(this.txtDebug);
            this.Controls.Add(this.tvOverview);
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
        private System.Windows.Forms.TreeView tvOverview;
        private System.Windows.Forms.TextBox txtDebug;
        private System.Windows.Forms.FolderBrowserDialog fbdBrowse;
        private System.Windows.Forms.TextBox txtM11;
        private System.Windows.Forms.TextBox txtM12;
        private System.Windows.Forms.TextBox txtM13;
        private System.Windows.Forms.TextBox txtM21;
        private System.Windows.Forms.TextBox txtM22;
        private System.Windows.Forms.TextBox txtM23;
        private System.Windows.Forms.TextBox txtM31;
        private System.Windows.Forms.TextBox txtM32;
        private System.Windows.Forms.TextBox txtM33;
        private System.Windows.Forms.TextBox txtM41;
        private System.Windows.Forms.TextBox txtM42;
        private System.Windows.Forms.TextBox txtM43;
        private System.Windows.Forms.Button cmdAccept;

    }
}

