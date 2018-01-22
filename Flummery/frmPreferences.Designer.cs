namespace Flummery
{
    partial class frmPreferences
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPreferences));
            this.tcPreferences = new System.Windows.Forms.TabControl();
            this.tpPaths = new System.Windows.Forms.TabPage();
            this.rdoWorkingDirTemp = new System.Windows.Forms.RadioButton();
            this.rdoWorkingDirFlummery = new System.Windows.Forms.RadioButton();
            this.lblWorking = new System.Windows.Forms.Label();
            this.btnC1Path = new System.Windows.Forms.Button();
            this.txtC1Path = new System.Windows.Forms.TextBox();
            this.lblC1Path = new System.Windows.Forms.Label();
            this.lblNotes = new System.Windows.Forms.Label();
            this.btnC2Path = new System.Windows.Forms.Button();
            this.txtC2Path = new System.Windows.Forms.TextBox();
            this.lblC2Path = new System.Windows.Forms.Label();
            this.btnCRPath = new System.Windows.Forms.Button();
            this.txtCRPath = new System.Windows.Forms.TextBox();
            this.lblCRPath = new System.Windows.Forms.Label();
            this.tpShortcuts = new System.Windows.Forms.TabPage();
            this.pgShortcuts = new System.Windows.Forms.PropertyGrid();
            this.tbMisc = new System.Windows.Forms.TabPage();
            this.lblHeadMisc = new System.Windows.Forms.Label();
            this.txtWebsite = new System.Windows.Forms.TextBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.lblWebsite = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblHeadPersonalDetails = new System.Windows.Forms.Label();
            this.chkCheckForUpdates = new System.Windows.Forms.CheckBox();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdApply = new System.Windows.Forms.Button();
            this.fbdBrowse = new System.Windows.Forms.FolderBrowserDialog();
            this.btnCMDPath = new System.Windows.Forms.Button();
            this.txtCMDPath = new System.Windows.Forms.TextBox();
            this.lblCMDPath = new System.Windows.Forms.Label();
            this.tcPreferences.SuspendLayout();
            this.tpPaths.SuspendLayout();
            this.tpShortcuts.SuspendLayout();
            this.tbMisc.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcPreferences
            // 
            this.tcPreferences.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcPreferences.Controls.Add(this.tpPaths);
            this.tcPreferences.Controls.Add(this.tpShortcuts);
            this.tcPreferences.Controls.Add(this.tbMisc);
            this.tcPreferences.Location = new System.Drawing.Point(12, 12);
            this.tcPreferences.Name = "tcPreferences";
            this.tcPreferences.SelectedIndex = 0;
            this.tcPreferences.Size = new System.Drawing.Size(536, 324);
            this.tcPreferences.TabIndex = 3;
            // 
            // tpPaths
            // 
            this.tpPaths.Controls.Add(this.btnCMDPath);
            this.tpPaths.Controls.Add(this.txtCMDPath);
            this.tpPaths.Controls.Add(this.lblCMDPath);
            this.tpPaths.Controls.Add(this.rdoWorkingDirTemp);
            this.tpPaths.Controls.Add(this.rdoWorkingDirFlummery);
            this.tpPaths.Controls.Add(this.lblWorking);
            this.tpPaths.Controls.Add(this.btnC1Path);
            this.tpPaths.Controls.Add(this.txtC1Path);
            this.tpPaths.Controls.Add(this.lblC1Path);
            this.tpPaths.Controls.Add(this.lblNotes);
            this.tpPaths.Controls.Add(this.btnC2Path);
            this.tpPaths.Controls.Add(this.txtC2Path);
            this.tpPaths.Controls.Add(this.lblC2Path);
            this.tpPaths.Controls.Add(this.btnCRPath);
            this.tpPaths.Controls.Add(this.txtCRPath);
            this.tpPaths.Controls.Add(this.lblCRPath);
            this.tpPaths.Location = new System.Drawing.Point(4, 22);
            this.tpPaths.Name = "tpPaths";
            this.tpPaths.Padding = new System.Windows.Forms.Padding(3);
            this.tpPaths.Size = new System.Drawing.Size(528, 298);
            this.tpPaths.TabIndex = 0;
            this.tpPaths.Text = "Paths";
            this.tpPaths.UseVisualStyleBackColor = true;
            // 
            // rdoWorkingDirTemp
            // 
            this.rdoWorkingDirTemp.AutoSize = true;
            this.rdoWorkingDirTemp.Location = new System.Drawing.Point(154, 147);
            this.rdoWorkingDirTemp.Name = "rdoWorkingDirTemp";
            this.rdoWorkingDirTemp.Size = new System.Drawing.Size(206, 17);
            this.rdoWorkingDirTemp.TabIndex = 15;
            this.rdoWorkingDirTemp.TabStop = true;
            this.rdoWorkingDirTemp.Text = "Working directory in users Temp folder";
            this.rdoWorkingDirTemp.UseVisualStyleBackColor = true;
            // 
            // rdoWorkingDirFlummery
            // 
            this.rdoWorkingDirFlummery.AutoSize = true;
            this.rdoWorkingDirFlummery.Location = new System.Drawing.Point(154, 124);
            this.rdoWorkingDirFlummery.Name = "rdoWorkingDirFlummery";
            this.rdoWorkingDirFlummery.Size = new System.Drawing.Size(195, 17);
            this.rdoWorkingDirFlummery.TabIndex = 14;
            this.rdoWorkingDirFlummery.TabStop = true;
            this.rdoWorkingDirFlummery.Text = "Working directory in Flummery folder";
            this.rdoWorkingDirFlummery.UseVisualStyleBackColor = true;
            // 
            // lblWorking
            // 
            this.lblWorking.AutoSize = true;
            this.lblWorking.Location = new System.Drawing.Point(6, 126);
            this.lblWorking.Name = "lblWorking";
            this.lblWorking.Size = new System.Drawing.Size(90, 13);
            this.lblWorking.TabIndex = 13;
            this.lblWorking.Text = "Working directory";
            // 
            // btnC1Path
            // 
            this.btnC1Path.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnC1Path.Location = new System.Drawing.Point(493, 6);
            this.btnC1Path.Name = "btnC1Path";
            this.btnC1Path.Size = new System.Drawing.Size(29, 23);
            this.btnC1Path.TabIndex = 12;
            this.btnC1Path.Text = "...";
            this.btnC1Path.UseVisualStyleBackColor = true;
            this.btnC1Path.Click += new System.EventHandler(this.btnC1Path_Click);
            // 
            // txtC1Path
            // 
            this.txtC1Path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtC1Path.Enabled = false;
            this.txtC1Path.Location = new System.Drawing.Point(154, 8);
            this.txtC1Path.Name = "txtC1Path";
            this.txtC1Path.ReadOnly = true;
            this.txtC1Path.Size = new System.Drawing.Size(333, 20);
            this.txtC1Path.TabIndex = 11;
            // 
            // lblC1Path
            // 
            this.lblC1Path.AutoSize = true;
            this.lblC1Path.Location = new System.Drawing.Point(6, 11);
            this.lblC1Path.Name = "lblC1Path";
            this.lblC1Path.Size = new System.Drawing.Size(73, 13);
            this.lblC1Path.TabIndex = 10;
            this.lblC1Path.Text = "Carmageddon";
            // 
            // lblNotes
            // 
            this.lblNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(6, 182);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(403, 91);
            this.lblNotes.TabIndex = 9;
            this.lblNotes.Text = resources.GetString("lblNotes.Text");
            // 
            // btnC2Path
            // 
            this.btnC2Path.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnC2Path.Location = new System.Drawing.Point(493, 35);
            this.btnC2Path.Name = "btnC2Path";
            this.btnC2Path.Size = new System.Drawing.Size(29, 23);
            this.btnC2Path.TabIndex = 8;
            this.btnC2Path.Text = "...";
            this.btnC2Path.UseVisualStyleBackColor = true;
            this.btnC2Path.Click += new System.EventHandler(this.btnC2Path_Click);
            // 
            // txtC2Path
            // 
            this.txtC2Path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtC2Path.Enabled = false;
            this.txtC2Path.Location = new System.Drawing.Point(154, 37);
            this.txtC2Path.Name = "txtC2Path";
            this.txtC2Path.ReadOnly = true;
            this.txtC2Path.Size = new System.Drawing.Size(333, 20);
            this.txtC2Path.TabIndex = 7;
            // 
            // lblC2Path
            // 
            this.lblC2Path.AutoSize = true;
            this.lblC2Path.Location = new System.Drawing.Point(6, 40);
            this.lblC2Path.Name = "lblC2Path";
            this.lblC2Path.Size = new System.Drawing.Size(82, 13);
            this.lblC2Path.TabIndex = 6;
            this.lblC2Path.Text = "Carmageddon 2";
            // 
            // btnCRPath
            // 
            this.btnCRPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCRPath.Location = new System.Drawing.Point(493, 64);
            this.btnCRPath.Name = "btnCRPath";
            this.btnCRPath.Size = new System.Drawing.Size(29, 23);
            this.btnCRPath.TabIndex = 5;
            this.btnCRPath.Text = "...";
            this.btnCRPath.UseVisualStyleBackColor = true;
            this.btnCRPath.Click += new System.EventHandler(this.btnCRPath_Click);
            // 
            // txtCRPath
            // 
            this.txtCRPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCRPath.Enabled = false;
            this.txtCRPath.Location = new System.Drawing.Point(154, 66);
            this.txtCRPath.Name = "txtCRPath";
            this.txtCRPath.ReadOnly = true;
            this.txtCRPath.Size = new System.Drawing.Size(333, 20);
            this.txtCRPath.TabIndex = 4;
            // 
            // lblCRPath
            // 
            this.lblCRPath.AutoSize = true;
            this.lblCRPath.Location = new System.Drawing.Point(6, 69);
            this.lblCRPath.Name = "lblCRPath";
            this.lblCRPath.Size = new System.Drawing.Size(145, 13);
            this.lblCRPath.TabIndex = 3;
            this.lblCRPath.Text = "Carmageddon: Reincarnation";
            // 
            // tpShortcuts
            // 
            this.tpShortcuts.Controls.Add(this.pgShortcuts);
            this.tpShortcuts.Location = new System.Drawing.Point(4, 22);
            this.tpShortcuts.Name = "tpShortcuts";
            this.tpShortcuts.Padding = new System.Windows.Forms.Padding(3);
            this.tpShortcuts.Size = new System.Drawing.Size(528, 265);
            this.tpShortcuts.TabIndex = 1;
            this.tpShortcuts.Text = "Keys";
            this.tpShortcuts.UseVisualStyleBackColor = true;
            // 
            // pgShortcuts
            // 
            this.pgShortcuts.Location = new System.Drawing.Point(6, 6);
            this.pgShortcuts.Name = "pgShortcuts";
            this.pgShortcuts.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.pgShortcuts.Size = new System.Drawing.Size(516, 253);
            this.pgShortcuts.TabIndex = 0;
            this.pgShortcuts.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.pgShortcuts_PropertyValueChanged);
            // 
            // tbMisc
            // 
            this.tbMisc.Controls.Add(this.lblHeadMisc);
            this.tbMisc.Controls.Add(this.txtWebsite);
            this.tbMisc.Controls.Add(this.txtAuthor);
            this.tbMisc.Controls.Add(this.lblWebsite);
            this.tbMisc.Controls.Add(this.lblAuthor);
            this.tbMisc.Controls.Add(this.lblHeadPersonalDetails);
            this.tbMisc.Controls.Add(this.chkCheckForUpdates);
            this.tbMisc.Location = new System.Drawing.Point(4, 22);
            this.tbMisc.Name = "tbMisc";
            this.tbMisc.Padding = new System.Windows.Forms.Padding(3);
            this.tbMisc.Size = new System.Drawing.Size(528, 265);
            this.tbMisc.TabIndex = 2;
            this.tbMisc.Text = "Misc";
            this.tbMisc.UseVisualStyleBackColor = true;
            // 
            // lblHeadMisc
            // 
            this.lblHeadMisc.AutoSize = true;
            this.lblHeadMisc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeadMisc.Location = new System.Drawing.Point(6, 92);
            this.lblHeadMisc.Name = "lblHeadMisc";
            this.lblHeadMisc.Size = new System.Drawing.Size(36, 13);
            this.lblHeadMisc.TabIndex = 6;
            this.lblHeadMisc.Text = "other";
            // 
            // txtWebsite
            // 
            this.txtWebsite.Location = new System.Drawing.Point(55, 58);
            this.txtWebsite.Name = "txtWebsite";
            this.txtWebsite.Size = new System.Drawing.Size(164, 20);
            this.txtWebsite.TabIndex = 5;
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(55, 32);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(164, 20);
            this.txtAuthor.TabIndex = 4;
            // 
            // lblWebsite
            // 
            this.lblWebsite.AutoSize = true;
            this.lblWebsite.Location = new System.Drawing.Point(6, 61);
            this.lblWebsite.Name = "lblWebsite";
            this.lblWebsite.Size = new System.Drawing.Size(43, 13);
            this.lblWebsite.TabIndex = 3;
            this.lblWebsite.Text = "website";
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(6, 35);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(37, 13);
            this.lblAuthor.TabIndex = 2;
            this.lblAuthor.Text = "author";
            // 
            // lblHeadPersonalDetails
            // 
            this.lblHeadPersonalDetails.AutoSize = true;
            this.lblHeadPersonalDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeadPersonalDetails.Location = new System.Drawing.Point(6, 9);
            this.lblHeadPersonalDetails.Name = "lblHeadPersonalDetails";
            this.lblHeadPersonalDetails.Size = new System.Drawing.Size(213, 13);
            this.lblHeadPersonalDetails.TabIndex = 1;
            this.lblHeadPersonalDetails.Text = "personal details (used in minge files)";
            // 
            // chkCheckForUpdates
            // 
            this.chkCheckForUpdates.AutoSize = true;
            this.chkCheckForUpdates.Location = new System.Drawing.Point(6, 114);
            this.chkCheckForUpdates.Name = "chkCheckForUpdates";
            this.chkCheckForUpdates.Size = new System.Drawing.Size(287, 17);
            this.chkCheckForUpdates.TabIndex = 0;
            this.chkCheckForUpdates.Text = "Automatically check for updates when Flummery starts?";
            this.chkCheckForUpdates.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOK.Location = new System.Drawing.Point(473, 342);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 4;
            this.cmdOK.Text = "ok";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(311, 342);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 5;
            this.cmdCancel.Text = "cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdApply
            // 
            this.cmdApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdApply.Location = new System.Drawing.Point(392, 342);
            this.cmdApply.Name = "cmdApply";
            this.cmdApply.Size = new System.Drawing.Size(75, 23);
            this.cmdApply.TabIndex = 6;
            this.cmdApply.Text = "apply";
            this.cmdApply.UseVisualStyleBackColor = true;
            this.cmdApply.Click += new System.EventHandler(this.cmdApply_Click);
            // 
            // fbdBrowse
            // 
            this.fbdBrowse.ShowNewFolderButton = false;
            // 
            // btnCMDPath
            // 
            this.btnCMDPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCMDPath.Location = new System.Drawing.Point(493, 93);
            this.btnCMDPath.Name = "btnCMDPath";
            this.btnCMDPath.Size = new System.Drawing.Size(29, 23);
            this.btnCMDPath.TabIndex = 18;
            this.btnCMDPath.Text = "...";
            this.btnCMDPath.UseVisualStyleBackColor = true;
            this.btnCMDPath.Click += new System.EventHandler(this.btnCMDPath_Click);
            // 
            // txtCMDPath
            // 
            this.txtCMDPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCMDPath.Enabled = false;
            this.txtCMDPath.Location = new System.Drawing.Point(154, 95);
            this.txtCMDPath.Name = "txtCMDPath";
            this.txtCMDPath.ReadOnly = true;
            this.txtCMDPath.Size = new System.Drawing.Size(333, 20);
            this.txtCMDPath.TabIndex = 17;
            // 
            // lblCMDPath
            // 
            this.lblCMDPath.AutoSize = true;
            this.lblCMDPath.Location = new System.Drawing.Point(6, 98);
            this.lblCMDPath.Name = "lblCMDPath";
            this.lblCMDPath.Size = new System.Drawing.Size(142, 13);
            this.lblCMDPath.TabIndex = 16;
            this.lblCMDPath.Text = "Carmageddon: Max Damage";
            // 
            // frmPreferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 377);
            this.Controls.Add(this.cmdApply);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.tcPreferences);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPreferences";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Preferences";
            this.TopMost = true;
            this.tcPreferences.ResumeLayout(false);
            this.tpPaths.ResumeLayout(false);
            this.tpPaths.PerformLayout();
            this.tpShortcuts.ResumeLayout(false);
            this.tbMisc.ResumeLayout(false);
            this.tbMisc.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcPreferences;
        private System.Windows.Forms.TabPage tpPaths;
        private System.Windows.Forms.Button btnCRPath;
        private System.Windows.Forms.TextBox txtCRPath;
        private System.Windows.Forms.Label lblCRPath;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdApply;
        private System.Windows.Forms.Button btnC2Path;
        private System.Windows.Forms.TextBox txtC2Path;
        private System.Windows.Forms.Label lblC2Path;
        private System.Windows.Forms.FolderBrowserDialog fbdBrowse;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.Button btnC1Path;
        private System.Windows.Forms.TextBox txtC1Path;
        private System.Windows.Forms.Label lblC1Path;
        private System.Windows.Forms.TabPage tpShortcuts;
        private System.Windows.Forms.TabPage tbMisc;
        private System.Windows.Forms.CheckBox chkCheckForUpdates;
        private System.Windows.Forms.PropertyGrid pgShortcuts;
        private System.Windows.Forms.Label lblHeadMisc;
        private System.Windows.Forms.TextBox txtWebsite;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.Label lblWebsite;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label lblHeadPersonalDetails;
        private System.Windows.Forms.Label lblWorking;
        private System.Windows.Forms.RadioButton rdoWorkingDirTemp;
        private System.Windows.Forms.RadioButton rdoWorkingDirFlummery;
        private System.Windows.Forms.Button btnCMDPath;
        private System.Windows.Forms.TextBox txtCMDPath;
        private System.Windows.Forms.Label lblCMDPath;
    }
}