namespace Flummery
{
    partial class frmSaveAsLevel
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
            this.lblRaceName = new System.Windows.Forms.Label();
            this.lblRace1Name = new System.Windows.Forms.Label();
            this.txtRaceName = new System.Windows.Forms.TextBox();
            this.txtPrettyLevelName = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.fbdBrowse = new System.Windows.Forms.FolderBrowserDialog();
            this.gbProgress = new System.Windows.Forms.GroupBox();
            this.lblProgressMeshes = new System.Windows.Forms.Label();
            this.lblInfoMeshes = new System.Windows.Forms.Label();
            this.lblProgressZAD = new System.Windows.Forms.Label();
            this.lblInfoZAD = new System.Windows.Forms.Label();
            this.lblProgressPaperwork = new System.Windows.Forms.Label();
            this.lblInfoPaperwork = new System.Windows.Forms.Label();
            this.lblProgressMaterials = new System.Windows.Forms.Label();
            this.lblInfoMaterials = new System.Windows.Forms.Label();
            this.lblProgressTextures = new System.Windows.Forms.Label();
            this.lblInfoTextures = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.gbProgress.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPath
            // 
            this.btnPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPath.Location = new System.Drawing.Point(487, 4);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(29, 23);
            this.btnPath.TabIndex = 1;
            this.btnPath.Text = "...";
            this.btnPath.UseVisualStyleBackColor = true;
            this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.Enabled = false;
            this.txtPath.Location = new System.Drawing.Point(177, 6);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(304, 20);
            this.txtPath.TabIndex = 7;
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(12, 9);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(108, 13);
            this.lblPath.TabIndex = 6;
            this.lblPath.Text = "Output Folder / Level";
            // 
            // txtLevel
            // 
            this.txtLevel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLevel.Location = new System.Drawing.Point(177, 32);
            this.txtLevel.Name = "txtLevel";
            this.txtLevel.ReadOnly = true;
            this.txtLevel.Size = new System.Drawing.Size(304, 20);
            this.txtLevel.TabIndex = 10;
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Location = new System.Drawing.Point(12, 35);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(64, 13);
            this.lblLevel.TabIndex = 9;
            this.lblLevel.Text = "Level Name";
            // 
            // lblRaceName
            // 
            this.lblRaceName.AutoSize = true;
            this.lblRaceName.Location = new System.Drawing.Point(12, 87);
            this.lblRaceName.Name = "lblRaceName";
            this.lblRaceName.Size = new System.Drawing.Size(64, 13);
            this.lblRaceName.TabIndex = 11;
            this.lblRaceName.Tag = "";
            this.lblRaceName.Text = "Race Name";
            // 
            // lblRace1Name
            // 
            this.lblRace1Name.AutoSize = true;
            this.lblRace1Name.Location = new System.Drawing.Point(12, 61);
            this.lblRace1Name.Name = "lblRace1Name";
            this.lblRace1Name.Size = new System.Drawing.Size(94, 13);
            this.lblRace1Name.TabIndex = 12;
            this.lblRace1Name.Tag = "";
            this.lblRace1Name.Text = "Pretty Level Name";
            // 
            // txtRaceName
            // 
            this.txtRaceName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRaceName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRaceName.Location = new System.Drawing.Point(177, 84);
            this.txtRaceName.Name = "txtRaceName";
            this.txtRaceName.Size = new System.Drawing.Size(304, 20);
            this.txtRaceName.TabIndex = 3;
            // 
            // txtPrettyLevelName
            // 
            this.txtPrettyLevelName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrettyLevelName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPrettyLevelName.Location = new System.Drawing.Point(177, 58);
            this.txtPrettyLevelName.Name = "txtPrettyLevelName";
            this.txtPrettyLevelName.Size = new System.Drawing.Size(304, 20);
            this.txtPrettyLevelName.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(360, 110);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(441, 110);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "ok";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // gbProgress
            // 
            this.gbProgress.Controls.Add(this.lblProgressMeshes);
            this.gbProgress.Controls.Add(this.lblInfoMeshes);
            this.gbProgress.Controls.Add(this.lblProgressZAD);
            this.gbProgress.Controls.Add(this.lblInfoZAD);
            this.gbProgress.Controls.Add(this.lblProgressPaperwork);
            this.gbProgress.Controls.Add(this.lblInfoPaperwork);
            this.gbProgress.Controls.Add(this.lblProgressMaterials);
            this.gbProgress.Controls.Add(this.lblInfoMaterials);
            this.gbProgress.Controls.Add(this.lblProgressTextures);
            this.gbProgress.Controls.Add(this.lblInfoTextures);
            this.gbProgress.Location = new System.Drawing.Point(15, 139);
            this.gbProgress.Name = "gbProgress";
            this.gbProgress.Size = new System.Drawing.Size(501, 88);
            this.gbProgress.TabIndex = 32;
            this.gbProgress.TabStop = false;
            this.gbProgress.Text = "progress...";
            this.gbProgress.Visible = false;
            // 
            // lblProgressMeshes
            // 
            this.lblProgressMeshes.AutoSize = true;
            this.lblProgressMeshes.ForeColor = System.Drawing.Color.Red;
            this.lblProgressMeshes.Location = new System.Drawing.Point(6, 16);
            this.lblProgressMeshes.Name = "lblProgressMeshes";
            this.lblProgressMeshes.Size = new System.Drawing.Size(14, 13);
            this.lblProgressMeshes.TabIndex = 9;
            this.lblProgressMeshes.Text = "X";
            // 
            // lblInfoMeshes
            // 
            this.lblInfoMeshes.AutoSize = true;
            this.lblInfoMeshes.Location = new System.Drawing.Point(26, 16);
            this.lblInfoMeshes.Name = "lblInfoMeshes";
            this.lblInfoMeshes.Size = new System.Drawing.Size(44, 13);
            this.lblInfoMeshes.TabIndex = 8;
            this.lblInfoMeshes.Text = "Meshes";
            // 
            // lblProgressZAD
            // 
            this.lblProgressZAD.AutoSize = true;
            this.lblProgressZAD.ForeColor = System.Drawing.Color.Red;
            this.lblProgressZAD.Location = new System.Drawing.Point(6, 68);
            this.lblProgressZAD.Name = "lblProgressZAD";
            this.lblProgressZAD.Size = new System.Drawing.Size(14, 13);
            this.lblProgressZAD.TabIndex = 7;
            this.lblProgressZAD.Text = "X";
            // 
            // lblInfoZAD
            // 
            this.lblInfoZAD.AutoSize = true;
            this.lblInfoZAD.Location = new System.Drawing.Point(26, 68);
            this.lblInfoZAD.Name = "lblInfoZAD";
            this.lblInfoZAD.Size = new System.Drawing.Size(125, 13);
            this.lblInfoZAD.TabIndex = 6;
            this.lblInfoZAD.Text = "CarMODgeddon ZAD file";
            // 
            // lblProgressPaperwork
            // 
            this.lblProgressPaperwork.AutoSize = true;
            this.lblProgressPaperwork.ForeColor = System.Drawing.Color.Red;
            this.lblProgressPaperwork.Location = new System.Drawing.Point(6, 55);
            this.lblProgressPaperwork.Name = "lblProgressPaperwork";
            this.lblProgressPaperwork.Size = new System.Drawing.Size(14, 13);
            this.lblProgressPaperwork.TabIndex = 5;
            this.lblProgressPaperwork.Text = "X";
            // 
            // lblInfoPaperwork
            // 
            this.lblInfoPaperwork.AutoSize = true;
            this.lblInfoPaperwork.Location = new System.Drawing.Point(26, 55);
            this.lblInfoPaperwork.Name = "lblInfoPaperwork";
            this.lblInfoPaperwork.Size = new System.Drawing.Size(58, 13);
            this.lblInfoPaperwork.TabIndex = 4;
            this.lblInfoPaperwork.Text = "Paperwork";
            // 
            // lblProgressMaterials
            // 
            this.lblProgressMaterials.AutoSize = true;
            this.lblProgressMaterials.ForeColor = System.Drawing.Color.Red;
            this.lblProgressMaterials.Location = new System.Drawing.Point(6, 42);
            this.lblProgressMaterials.Name = "lblProgressMaterials";
            this.lblProgressMaterials.Size = new System.Drawing.Size(14, 13);
            this.lblProgressMaterials.TabIndex = 3;
            this.lblProgressMaterials.Text = "X";
            // 
            // lblInfoMaterials
            // 
            this.lblInfoMaterials.AutoSize = true;
            this.lblInfoMaterials.Location = new System.Drawing.Point(26, 42);
            this.lblInfoMaterials.Name = "lblInfoMaterials";
            this.lblInfoMaterials.Size = new System.Drawing.Size(49, 13);
            this.lblInfoMaterials.TabIndex = 2;
            this.lblInfoMaterials.Text = "Materials";
            // 
            // lblProgressTextures
            // 
            this.lblProgressTextures.AutoSize = true;
            this.lblProgressTextures.ForeColor = System.Drawing.Color.Red;
            this.lblProgressTextures.Location = new System.Drawing.Point(6, 29);
            this.lblProgressTextures.Name = "lblProgressTextures";
            this.lblProgressTextures.Size = new System.Drawing.Size(14, 13);
            this.lblProgressTextures.TabIndex = 1;
            this.lblProgressTextures.Text = "X";
            // 
            // lblInfoTextures
            // 
            this.lblInfoTextures.AutoSize = true;
            this.lblInfoTextures.Location = new System.Drawing.Point(26, 29);
            this.lblInfoTextures.Name = "lblInfoTextures";
            this.lblInfoTextures.Size = new System.Drawing.Size(48, 13);
            this.lblInfoTextures.TabIndex = 0;
            this.lblInfoTextures.Text = "Textures";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Location = new System.Drawing.Point(441, 233);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Visible = false;
            // 
            // pbProgress
            // 
            this.pbProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbProgress.Location = new System.Drawing.Point(15, 110);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(501, 23);
            this.pbProgress.TabIndex = 33;
            this.pbProgress.Visible = false;
            // 
            // frmSaveAsLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(528, 263);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtPrettyLevelName);
            this.Controls.Add(this.txtRaceName);
            this.Controls.Add(this.lblRace1Name);
            this.Controls.Add(this.lblRaceName);
            this.Controls.Add(this.txtLevel);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.btnPath);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.gbProgress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(0, 181);
            this.Name = "frmSaveAsLevel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Save As... Level";
            this.gbProgress.ResumeLayout(false);
            this.gbProgress.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPath;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.TextBox txtLevel;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Label lblRaceName;
        private System.Windows.Forms.Label lblRace1Name;
        private System.Windows.Forms.TextBox txtRaceName;
        private System.Windows.Forms.TextBox txtPrettyLevelName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.FolderBrowserDialog fbdBrowse;
        private System.Windows.Forms.GroupBox gbProgress;
        private System.Windows.Forms.Label lblProgressMeshes;
        private System.Windows.Forms.Label lblInfoMeshes;
        private System.Windows.Forms.Label lblProgressZAD;
        private System.Windows.Forms.Label lblInfoZAD;
        private System.Windows.Forms.Label lblProgressPaperwork;
        private System.Windows.Forms.Label lblInfoPaperwork;
        private System.Windows.Forms.Label lblProgressMaterials;
        private System.Windows.Forms.Label lblInfoMaterials;
        private System.Windows.Forms.Label lblProgressTextures;
        private System.Windows.Forms.Label lblInfoTextures;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ProgressBar pbProgress;
    }
}