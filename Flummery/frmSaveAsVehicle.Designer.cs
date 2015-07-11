namespace Flummery
{
    partial class frmSaveAsVehicle
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
            this.btnPath = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.fbdBrowse = new System.Windows.Forms.FolderBrowserDialog();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkMaterials = new System.Windows.Forms.CheckBox();
            this.txtCarName = new System.Windows.Forms.TextBox();
            this.lblCarName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnPath
            // 
            this.btnPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPath.Location = new System.Drawing.Point(491, 4);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(29, 23);
            this.btnPath.TabIndex = 11;
            this.btnPath.Text = "...";
            this.btnPath.UseVisualStyleBackColor = true;
            this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.Enabled = false;
            this.txtPath.Location = new System.Drawing.Point(152, 6);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(333, 20);
            this.txtPath.TabIndex = 10;
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(12, 9);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(117, 13);
            this.lblPath.TabIndex = 9;
            this.lblPath.Text = "Output Folder / Vehicle";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(445, 62);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 25;
            this.btnOK.Text = "ok";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(364, 62);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkMaterials
            // 
            this.chkMaterials.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkMaterials.AutoSize = true;
            this.chkMaterials.Location = new System.Drawing.Point(152, 66);
            this.chkMaterials.Name = "chkMaterials";
            this.chkMaterials.Size = new System.Drawing.Size(107, 17);
            this.chkMaterials.TabIndex = 23;
            this.chkMaterials.Text = "process materials";
            this.chkMaterials.UseVisualStyleBackColor = true;
            // 
            // txtCarName
            // 
            this.txtCarName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCarName.Location = new System.Drawing.Point(152, 32);
            this.txtCarName.Name = "txtCarName";
            this.txtCarName.ReadOnly = true;
            this.txtCarName.Size = new System.Drawing.Size(333, 20);
            this.txtCarName.TabIndex = 27;
            // 
            // lblCarName
            // 
            this.lblCarName.AutoSize = true;
            this.lblCarName.Location = new System.Drawing.Point(12, 35);
            this.lblCarName.Name = "lblCarName";
            this.lblCarName.Size = new System.Drawing.Size(54, 13);
            this.lblCarName.TabIndex = 26;
            this.lblCarName.Text = "Car Name";
            // 
            // frmSaveAsVehicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 97);
            this.Controls.Add(this.txtCarName);
            this.Controls.Add(this.lblCarName);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.chkMaterials);
            this.Controls.Add(this.btnPath);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.lblPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSaveAsVehicle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Save As... Vehicle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPath;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.FolderBrowserDialog fbdBrowse;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkMaterials;
        private System.Windows.Forms.TextBox txtCarName;
        private System.Windows.Forms.Label lblCarName;
    }
}