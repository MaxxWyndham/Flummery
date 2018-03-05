namespace Flummery
{
    partial class frmTDXConvert
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTDXConvert));
            this.pbPreview = new System.Windows.Forms.PictureBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblWidth = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.lblFileSize = new System.Windows.Forms.Label();
            this.cmdClose = new System.Windows.Forms.Button();
            this.ofdBrowse = new System.Windows.Forms.OpenFileDialog();
            this.sfdSave = new System.Windows.Forms.SaveFileDialog();
            this.lblFile = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // pbPreview
            // 
            this.pbPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPreview.Location = new System.Drawing.Point(12, 12);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(512, 512);
            this.pbPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPreview.TabIndex = 2;
            this.pbPreview.TabStop = false;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(530, 12);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(186, 23);
            this.btnOpen.TabIndex = 3;
            this.btnOpen.Text = "open image...";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(530, 93);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(186, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "save as...";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(530, 51);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(68, 13);
            this.lblWidth.TabIndex = 5;
            this.lblWidth.Tag = "Width: {0}";
            this.lblWidth.Text = "[placeholder]";
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(530, 64);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(68, 13);
            this.lblHeight.TabIndex = 6;
            this.lblHeight.Tag = "Height: {0}";
            this.lblHeight.Text = "[placeholder]";
            // 
            // lblFileSize
            // 
            this.lblFileSize.AutoSize = true;
            this.lblFileSize.Location = new System.Drawing.Point(530, 77);
            this.lblFileSize.Name = "lblFileSize";
            this.lblFileSize.Size = new System.Drawing.Size(68, 13);
            this.lblFileSize.TabIndex = 7;
            this.lblFileSize.Tag = "Filesize: {0}";
            this.lblFileSize.Text = "[placeholder]";
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(530, 501);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(186, 23);
            this.cmdClose.TabIndex = 8;
            this.cmdClose.Text = "close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(530, 38);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(68, 13);
            this.lblFile.TabIndex = 9;
            this.lblFile.Tag = "{0}";
            this.lblFile.Text = "[placeholder]";
            // 
            // frmTDXConvert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 536);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.lblFileSize);
            this.Controls.Add(this.lblHeight);
            this.Controls.Add(this.lblWidth);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.pbPreview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::Flummery.Properties.Resources.icon;
            this.MaximizeBox = false;
            this.Name = "frmTDXConvert";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TDX Convertor";
            this.Load += new System.EventHandler(this.frmTDXConvert_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPreview;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Label lblFileSize;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.OpenFileDialog ofdBrowse;
        private System.Windows.Forms.SaveFileDialog sfdSave;
        private System.Windows.Forms.Label lblFile;
    }
}