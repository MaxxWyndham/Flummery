namespace Flummery
{
    partial class frmMaterialEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMaterialEditor));
            this.gbDiffPreview = new System.Windows.Forms.GroupBox();
            this.pbDiffPreview = new System.Windows.Forms.PictureBox();
            this.btnDiffLoad = new System.Windows.Forms.Button();
            this.lblDiffPath = new System.Windows.Forms.Label();
            this.gbNormPreview = new System.Windows.Forms.GroupBox();
            this.lblNormPath = new System.Windows.Forms.Label();
            this.btnNormLoad = new System.Windows.Forms.Button();
            this.pbNormPreview = new System.Windows.Forms.PictureBox();
            this.gbSpecPreview = new System.Windows.Forms.GroupBox();
            this.lblSpecPath = new System.Windows.Forms.Label();
            this.btnSpecLoad = new System.Windows.Forms.Button();
            this.pbSpecPreview = new System.Windows.Forms.PictureBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblMaterialName = new System.Windows.Forms.Label();
            this.txtMaterialName = new System.Windows.Forms.TextBox();
            this.ofdBrowse = new System.Windows.Forms.OpenFileDialog();
            this.gbDiffPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDiffPreview)).BeginInit();
            this.gbNormPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbNormPreview)).BeginInit();
            this.gbSpecPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSpecPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // gbDiffPreview
            // 
            this.gbDiffPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDiffPreview.Controls.Add(this.lblDiffPath);
            this.gbDiffPreview.Controls.Add(this.btnDiffLoad);
            this.gbDiffPreview.Controls.Add(this.pbDiffPreview);
            this.gbDiffPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbDiffPreview.Location = new System.Drawing.Point(12, 40);
            this.gbDiffPreview.Name = "gbDiffPreview";
            this.gbDiffPreview.Size = new System.Drawing.Size(140, 184);
            this.gbDiffPreview.TabIndex = 1;
            this.gbDiffPreview.TabStop = false;
            this.gbDiffPreview.Text = "Diffuse";
            // 
            // pbDiffPreview
            // 
            this.pbDiffPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbDiffPreview.Location = new System.Drawing.Point(6, 19);
            this.pbDiffPreview.Name = "pbDiffPreview";
            this.pbDiffPreview.Size = new System.Drawing.Size(128, 128);
            this.pbDiffPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDiffPreview.TabIndex = 0;
            this.pbDiffPreview.TabStop = false;
            // 
            // btnDiffLoad
            // 
            this.btnDiffLoad.AutoSize = true;
            this.btnDiffLoad.Location = new System.Drawing.Point(107, 153);
            this.btnDiffLoad.Name = "btnDiffLoad";
            this.btnDiffLoad.Size = new System.Drawing.Size(27, 23);
            this.btnDiffLoad.TabIndex = 0;
            this.btnDiffLoad.Text = "...";
            this.btnDiffLoad.UseVisualStyleBackColor = true;
            this.btnDiffLoad.Click += new System.EventHandler(this.btnDiffLoad_Click);
            // 
            // lblDiffPath
            // 
            this.lblDiffPath.Location = new System.Drawing.Point(6, 158);
            this.lblDiffPath.Name = "lblDiffPath";
            this.lblDiffPath.Size = new System.Drawing.Size(98, 18);
            this.lblDiffPath.TabIndex = 12;
            this.lblDiffPath.Text = "[diffuse file]";
            // 
            // gbNormPreview
            // 
            this.gbNormPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbNormPreview.Controls.Add(this.lblNormPath);
            this.gbNormPreview.Controls.Add(this.btnNormLoad);
            this.gbNormPreview.Controls.Add(this.pbNormPreview);
            this.gbNormPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbNormPreview.Location = new System.Drawing.Point(158, 40);
            this.gbNormPreview.Name = "gbNormPreview";
            this.gbNormPreview.Size = new System.Drawing.Size(140, 184);
            this.gbNormPreview.TabIndex = 2;
            this.gbNormPreview.TabStop = false;
            this.gbNormPreview.Text = "Normal";
            // 
            // lblNormPath
            // 
            this.lblNormPath.Location = new System.Drawing.Point(6, 158);
            this.lblNormPath.Name = "lblNormPath";
            this.lblNormPath.Size = new System.Drawing.Size(98, 18);
            this.lblNormPath.TabIndex = 12;
            this.lblNormPath.Text = "[normal file]";
            // 
            // btnNormLoad
            // 
            this.btnNormLoad.AutoSize = true;
            this.btnNormLoad.Location = new System.Drawing.Point(107, 153);
            this.btnNormLoad.Name = "btnNormLoad";
            this.btnNormLoad.Size = new System.Drawing.Size(27, 23);
            this.btnNormLoad.TabIndex = 0;
            this.btnNormLoad.Text = "...";
            this.btnNormLoad.UseVisualStyleBackColor = true;
            this.btnNormLoad.Click += new System.EventHandler(this.btnNormLoad_Click);
            // 
            // pbNormPreview
            // 
            this.pbNormPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbNormPreview.Location = new System.Drawing.Point(6, 19);
            this.pbNormPreview.Name = "pbNormPreview";
            this.pbNormPreview.Size = new System.Drawing.Size(128, 128);
            this.pbNormPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbNormPreview.TabIndex = 0;
            this.pbNormPreview.TabStop = false;
            // 
            // gbSpecPreview
            // 
            this.gbSpecPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSpecPreview.Controls.Add(this.lblSpecPath);
            this.gbSpecPreview.Controls.Add(this.btnSpecLoad);
            this.gbSpecPreview.Controls.Add(this.pbSpecPreview);
            this.gbSpecPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbSpecPreview.Location = new System.Drawing.Point(304, 40);
            this.gbSpecPreview.Name = "gbSpecPreview";
            this.gbSpecPreview.Size = new System.Drawing.Size(140, 184);
            this.gbSpecPreview.TabIndex = 3;
            this.gbSpecPreview.TabStop = false;
            this.gbSpecPreview.Text = "Specular";
            // 
            // lblSpecPath
            // 
            this.lblSpecPath.Location = new System.Drawing.Point(6, 158);
            this.lblSpecPath.Name = "lblSpecPath";
            this.lblSpecPath.Size = new System.Drawing.Size(98, 18);
            this.lblSpecPath.TabIndex = 12;
            this.lblSpecPath.Text = "[specular file]";
            // 
            // btnSpecLoad
            // 
            this.btnSpecLoad.AutoSize = true;
            this.btnSpecLoad.Location = new System.Drawing.Point(107, 153);
            this.btnSpecLoad.Name = "btnSpecLoad";
            this.btnSpecLoad.Size = new System.Drawing.Size(27, 23);
            this.btnSpecLoad.TabIndex = 0;
            this.btnSpecLoad.Text = "...";
            this.btnSpecLoad.UseVisualStyleBackColor = true;
            this.btnSpecLoad.Click += new System.EventHandler(this.btnSpecLoad_Click);
            // 
            // pbSpecPreview
            // 
            this.pbSpecPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSpecPreview.Location = new System.Drawing.Point(6, 19);
            this.pbSpecPreview.Name = "pbSpecPreview";
            this.pbSpecPreview.Size = new System.Drawing.Size(128, 128);
            this.pbSpecPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSpecPreview.TabIndex = 0;
            this.pbSpecPreview.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(287, 234);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(368, 234);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "ok";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblMaterialName
            // 
            this.lblMaterialName.AutoSize = true;
            this.lblMaterialName.Location = new System.Drawing.Point(12, 12);
            this.lblMaterialName.Name = "lblMaterialName";
            this.lblMaterialName.Size = new System.Drawing.Size(35, 13);
            this.lblMaterialName.TabIndex = 16;
            this.lblMaterialName.Text = "Name";
            // 
            // txtMaterialName
            // 
            this.txtMaterialName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaterialName.Location = new System.Drawing.Point(53, 9);
            this.txtMaterialName.Name = "txtMaterialName";
            this.txtMaterialName.Size = new System.Drawing.Size(390, 20);
            this.txtMaterialName.TabIndex = 0;
            // 
            // frmMaterialEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 269);
            this.Controls.Add(this.txtMaterialName);
            this.Controls.Add(this.lblMaterialName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gbSpecPreview);
            this.Controls.Add(this.gbNormPreview);
            this.Controls.Add(this.gbDiffPreview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::Flummery.Properties.Resources.icon;
            this.MaximizeBox = false;
            this.Name = "frmMaterialEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Material Editor";
            this.gbDiffPreview.ResumeLayout(false);
            this.gbDiffPreview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDiffPreview)).EndInit();
            this.gbNormPreview.ResumeLayout(false);
            this.gbNormPreview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbNormPreview)).EndInit();
            this.gbSpecPreview.ResumeLayout(false);
            this.gbSpecPreview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSpecPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDiffPreview;
        private System.Windows.Forms.PictureBox pbDiffPreview;
        private System.Windows.Forms.Label lblDiffPath;
        private System.Windows.Forms.Button btnDiffLoad;
        private System.Windows.Forms.GroupBox gbNormPreview;
        private System.Windows.Forms.Label lblNormPath;
        private System.Windows.Forms.Button btnNormLoad;
        private System.Windows.Forms.PictureBox pbNormPreview;
        private System.Windows.Forms.GroupBox gbSpecPreview;
        private System.Windows.Forms.Label lblSpecPath;
        private System.Windows.Forms.Button btnSpecLoad;
        private System.Windows.Forms.PictureBox pbSpecPreview;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblMaterialName;
        private System.Windows.Forms.TextBox txtMaterialName;
        private System.Windows.Forms.OpenFileDialog ofdBrowse;
    }
}