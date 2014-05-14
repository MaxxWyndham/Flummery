namespace Flummery
{
    partial class frmSaveAsEnvironment
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
            this.txtLevel = new System.Windows.Forms.TextBox();
            this.lblLevel = new System.Windows.Forms.Label();
            this.lblEnvironment = new System.Windows.Forms.Label();
            this.lblRace1Name = new System.Windows.Forms.Label();
            this.lblRace1Writeup = new System.Windows.Forms.Label();
            this.txtEnvironment = new System.Windows.Forms.TextBox();
            this.txtRace1Name = new System.Windows.Forms.TextBox();
            this.txtRace1Writeup = new System.Windows.Forms.TextBox();
            this.chkMaterials = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.fbdBrowse = new System.Windows.Forms.FolderBrowserDialog();
            this.txtScaleX = new System.Windows.Forms.TextBox();
            this.txtScaleY = new System.Windows.Forms.TextBox();
            this.txtScaleZ = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnPath
            // 
            this.btnPath.Location = new System.Drawing.Point(657, 4);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(29, 23);
            this.btnPath.TabIndex = 8;
            this.btnPath.Text = "...";
            this.btnPath.UseVisualStyleBackColor = true;
            this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(318, 6);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(333, 20);
            this.txtPath.TabIndex = 7;
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(12, 9);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(141, 13);
            this.lblPath.TabIndex = 6;
            this.lblPath.Text = "Output Folder / Environment";
            // 
            // txtLevel
            // 
            this.txtLevel.Location = new System.Drawing.Point(318, 32);
            this.txtLevel.Name = "txtLevel";
            this.txtLevel.Size = new System.Drawing.Size(333, 20);
            this.txtLevel.TabIndex = 10;
            this.txtLevel.TextChanged += new System.EventHandler(this.txtLevel_TextChanged);
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Location = new System.Drawing.Point(12, 35);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(33, 13);
            this.lblLevel.TabIndex = 9;
            this.lblLevel.Text = "Level";
            // 
            // lblEnvironment
            // 
            this.lblEnvironment.AutoSize = true;
            this.lblEnvironment.Location = new System.Drawing.Point(12, 61);
            this.lblEnvironment.Name = "lblEnvironment";
            this.lblEnvironment.Size = new System.Drawing.Size(211, 13);
            this.lblEnvironment.TabIndex = 11;
            this.lblEnvironment.Tag = "fe_environment_%%environment%%_ucase";
            this.lblEnvironment.Text = "fe_environment_%%environment%%_ucase";
            // 
            // lblRace1Name
            // 
            this.lblRace1Name.AutoSize = true;
            this.lblRace1Name.Location = new System.Drawing.Point(12, 87);
            this.lblRace1Name.Name = "lblRace1Name";
            this.lblRace1Name.Size = new System.Drawing.Size(178, 13);
            this.lblRace1Name.TabIndex = 12;
            this.lblRace1Name.Tag = "fe_level_%%level%%_race_1_ucase";
            this.lblRace1Name.Text = "fe_level_%%level%%_race_1_ucase";
            // 
            // lblRace1Writeup
            // 
            this.lblRace1Writeup.AutoSize = true;
            this.lblRace1Writeup.Location = new System.Drawing.Point(12, 113);
            this.lblRace1Writeup.Name = "lblRace1Writeup";
            this.lblRace1Writeup.Size = new System.Drawing.Size(183, 13);
            this.lblRace1Writeup.TabIndex = 13;
            this.lblRace1Writeup.Tag = "fe_level_%%level%%_race_1_writeup";
            this.lblRace1Writeup.Text = "fe_level_%%level%%_race_1_writeup";
            // 
            // txtEnvironment
            // 
            this.txtEnvironment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEnvironment.Location = new System.Drawing.Point(318, 58);
            this.txtEnvironment.Name = "txtEnvironment";
            this.txtEnvironment.Size = new System.Drawing.Size(333, 20);
            this.txtEnvironment.TabIndex = 14;
            // 
            // txtRace1Name
            // 
            this.txtRace1Name.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRace1Name.Location = new System.Drawing.Point(318, 84);
            this.txtRace1Name.Name = "txtRace1Name";
            this.txtRace1Name.Size = new System.Drawing.Size(333, 20);
            this.txtRace1Name.TabIndex = 15;
            // 
            // txtRace1Writeup
            // 
            this.txtRace1Writeup.Location = new System.Drawing.Point(318, 110);
            this.txtRace1Writeup.Name = "txtRace1Writeup";
            this.txtRace1Writeup.Size = new System.Drawing.Size(333, 20);
            this.txtRace1Writeup.TabIndex = 16;
            // 
            // chkMaterials
            // 
            this.chkMaterials.AutoSize = true;
            this.chkMaterials.Location = new System.Drawing.Point(318, 136);
            this.chkMaterials.Name = "chkMaterials";
            this.chkMaterials.Size = new System.Drawing.Size(107, 17);
            this.chkMaterials.TabIndex = 17;
            this.chkMaterials.Text = "process materials";
            this.chkMaterials.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(525, 157);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(606, 157);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 19;
            this.btnOK.Text = "ok";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtScaleX
            // 
            this.txtScaleX.Location = new System.Drawing.Point(318, 159);
            this.txtScaleX.Name = "txtScaleX";
            this.txtScaleX.Size = new System.Drawing.Size(43, 20);
            this.txtScaleX.TabIndex = 20;
            this.txtScaleX.Text = "6.9";
            // 
            // txtScaleY
            // 
            this.txtScaleY.Location = new System.Drawing.Point(367, 159);
            this.txtScaleY.Name = "txtScaleY";
            this.txtScaleY.Size = new System.Drawing.Size(43, 20);
            this.txtScaleY.TabIndex = 21;
            this.txtScaleY.Text = "6.9";
            // 
            // txtScaleZ
            // 
            this.txtScaleZ.Location = new System.Drawing.Point(416, 159);
            this.txtScaleZ.Name = "txtScaleZ";
            this.txtScaleZ.Size = new System.Drawing.Size(43, 20);
            this.txtScaleZ.TabIndex = 22;
            this.txtScaleZ.Text = "-6.9";
            // 
            // frmSaveAsEnvironment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 192);
            this.Controls.Add(this.txtScaleZ);
            this.Controls.Add(this.txtScaleY);
            this.Controls.Add(this.txtScaleX);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.chkMaterials);
            this.Controls.Add(this.txtRace1Writeup);
            this.Controls.Add(this.txtRace1Name);
            this.Controls.Add(this.txtEnvironment);
            this.Controls.Add(this.lblRace1Writeup);
            this.Controls.Add(this.lblRace1Name);
            this.Controls.Add(this.lblEnvironment);
            this.Controls.Add(this.txtLevel);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.btnPath);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.lblPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSaveAsEnvironment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Save As... Environment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPath;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.TextBox txtLevel;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Label lblEnvironment;
        private System.Windows.Forms.Label lblRace1Name;
        private System.Windows.Forms.Label lblRace1Writeup;
        private System.Windows.Forms.TextBox txtEnvironment;
        private System.Windows.Forms.TextBox txtRace1Name;
        private System.Windows.Forms.TextBox txtRace1Writeup;
        private System.Windows.Forms.CheckBox chkMaterials;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.FolderBrowserDialog fbdBrowse;
        private System.Windows.Forms.TextBox txtScaleX;
        private System.Windows.Forms.TextBox txtScaleY;
        private System.Windows.Forms.TextBox txtScaleZ;
    }
}