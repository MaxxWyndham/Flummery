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
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdApply = new System.Windows.Forms.Button();
            this.fbdBrowse = new System.Windows.Forms.FolderBrowserDialog();
            this.tpShortcuts = new System.Windows.Forms.TabPage();
            this.pgShortcuts = new System.Windows.Forms.PropertyGrid();
            this.tpFlummery = new System.Windows.Forms.TabPage();
            this.lblWorking = new System.Windows.Forms.Label();
            this.rdoWorkingDirFlummery = new System.Windows.Forms.RadioButton();
            this.rdoWorkingDirTemp = new System.Windows.Forms.RadioButton();
            this.chkCheckForUpdates = new System.Windows.Forms.CheckBox();
            this.lblHeadPersonalDetails = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblWebsite = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.txtWebsite = new System.Windows.Forms.TextBox();
            this.lblHeadMisc = new System.Windows.Forms.Label();
            this.tcPreferences = new System.Windows.Forms.TabControl();
            this.tpShortcuts.SuspendLayout();
            this.tpFlummery.SuspendLayout();
            this.tcPreferences.SuspendLayout();
            this.SuspendLayout();
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
            // tpShortcuts
            // 
            this.tpShortcuts.Controls.Add(this.pgShortcuts);
            this.tpShortcuts.Location = new System.Drawing.Point(4, 22);
            this.tpShortcuts.Name = "tpShortcuts";
            this.tpShortcuts.Padding = new System.Windows.Forms.Padding(3);
            this.tpShortcuts.Size = new System.Drawing.Size(528, 298);
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
            // tpFlummery
            // 
            this.tpFlummery.Controls.Add(this.lblHeadMisc);
            this.tpFlummery.Controls.Add(this.txtWebsite);
            this.tpFlummery.Controls.Add(this.txtAuthor);
            this.tpFlummery.Controls.Add(this.lblWebsite);
            this.tpFlummery.Controls.Add(this.lblAuthor);
            this.tpFlummery.Controls.Add(this.lblHeadPersonalDetails);
            this.tpFlummery.Controls.Add(this.chkCheckForUpdates);
            this.tpFlummery.Controls.Add(this.rdoWorkingDirTemp);
            this.tpFlummery.Controls.Add(this.rdoWorkingDirFlummery);
            this.tpFlummery.Controls.Add(this.lblWorking);
            this.tpFlummery.Location = new System.Drawing.Point(4, 22);
            this.tpFlummery.Name = "tpFlummery";
            this.tpFlummery.Padding = new System.Windows.Forms.Padding(3);
            this.tpFlummery.Size = new System.Drawing.Size(528, 298);
            this.tpFlummery.TabIndex = 0;
            this.tpFlummery.Text = "Flummery";
            this.tpFlummery.UseVisualStyleBackColor = true;
            // 
            // lblWorking
            // 
            this.lblWorking.AutoSize = true;
            this.lblWorking.Location = new System.Drawing.Point(6, 119);
            this.lblWorking.Name = "lblWorking";
            this.lblWorking.Size = new System.Drawing.Size(87, 13);
            this.lblWorking.TabIndex = 13;
            this.lblWorking.Text = "working directory";
            // 
            // rdoWorkingDirFlummery
            // 
            this.rdoWorkingDirFlummery.AutoSize = true;
            this.rdoWorkingDirFlummery.Checked = true;
            this.rdoWorkingDirFlummery.Location = new System.Drawing.Point(154, 117);
            this.rdoWorkingDirFlummery.Name = "rdoWorkingDirFlummery";
            this.rdoWorkingDirFlummery.Size = new System.Drawing.Size(192, 17);
            this.rdoWorkingDirFlummery.TabIndex = 14;
            this.rdoWorkingDirFlummery.TabStop = true;
            this.rdoWorkingDirFlummery.Text = "working directory in Flummery folder";
            this.rdoWorkingDirFlummery.UseVisualStyleBackColor = true;
            // 
            // rdoWorkingDirTemp
            // 
            this.rdoWorkingDirTemp.AutoSize = true;
            this.rdoWorkingDirTemp.Location = new System.Drawing.Point(154, 140);
            this.rdoWorkingDirTemp.Name = "rdoWorkingDirTemp";
            this.rdoWorkingDirTemp.Size = new System.Drawing.Size(203, 17);
            this.rdoWorkingDirTemp.TabIndex = 15;
            this.rdoWorkingDirTemp.Text = "working directory in users Temp folder";
            this.rdoWorkingDirTemp.UseVisualStyleBackColor = true;
            // 
            // chkCheckForUpdates
            // 
            this.chkCheckForUpdates.AutoSize = true;
            this.chkCheckForUpdates.Location = new System.Drawing.Point(9, 175);
            this.chkCheckForUpdates.Name = "chkCheckForUpdates";
            this.chkCheckForUpdates.Size = new System.Drawing.Size(286, 17);
            this.chkCheckForUpdates.TabIndex = 16;
            this.chkCheckForUpdates.Text = "automatically check for updates when Flummery starts?";
            this.chkCheckForUpdates.UseVisualStyleBackColor = true;
            // 
            // lblHeadPersonalDetails
            // 
            this.lblHeadPersonalDetails.AutoSize = true;
            this.lblHeadPersonalDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeadPersonalDetails.Location = new System.Drawing.Point(6, 3);
            this.lblHeadPersonalDetails.Name = "lblHeadPersonalDetails";
            this.lblHeadPersonalDetails.Size = new System.Drawing.Size(221, 13);
            this.lblHeadPersonalDetails.TabIndex = 17;
            this.lblHeadPersonalDetails.Text = "personal details (used in various files)";
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(6, 29);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(37, 13);
            this.lblAuthor.TabIndex = 18;
            this.lblAuthor.Text = "author";
            // 
            // lblWebsite
            // 
            this.lblWebsite.AutoSize = true;
            this.lblWebsite.Location = new System.Drawing.Point(6, 55);
            this.lblWebsite.Name = "lblWebsite";
            this.lblWebsite.Size = new System.Drawing.Size(43, 13);
            this.lblWebsite.TabIndex = 19;
            this.lblWebsite.Text = "website";
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(55, 26);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(164, 20);
            this.txtAuthor.TabIndex = 20;
            // 
            // txtWebsite
            // 
            this.txtWebsite.Location = new System.Drawing.Point(55, 52);
            this.txtWebsite.Name = "txtWebsite";
            this.txtWebsite.Size = new System.Drawing.Size(164, 20);
            this.txtWebsite.TabIndex = 21;
            // 
            // lblHeadMisc
            // 
            this.lblHeadMisc.AutoSize = true;
            this.lblHeadMisc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeadMisc.Location = new System.Drawing.Point(6, 97);
            this.lblHeadMisc.Name = "lblHeadMisc";
            this.lblHeadMisc.Size = new System.Drawing.Size(36, 13);
            this.lblHeadMisc.TabIndex = 22;
            this.lblHeadMisc.Text = "other";
            // 
            // tcPreferences
            // 
            this.tcPreferences.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcPreferences.Controls.Add(this.tpFlummery);
            this.tcPreferences.Controls.Add(this.tpShortcuts);
            this.tcPreferences.Location = new System.Drawing.Point(12, 12);
            this.tcPreferences.Name = "tcPreferences";
            this.tcPreferences.SelectedIndex = 0;
            this.tcPreferences.Size = new System.Drawing.Size(536, 324);
            this.tcPreferences.TabIndex = 3;
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
            this.tpShortcuts.ResumeLayout(false);
            this.tpFlummery.ResumeLayout(false);
            this.tpFlummery.PerformLayout();
            this.tcPreferences.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdApply;
        private System.Windows.Forms.FolderBrowserDialog fbdBrowse;
        private System.Windows.Forms.TabPage tpShortcuts;
        private System.Windows.Forms.PropertyGrid pgShortcuts;
        private System.Windows.Forms.TabPage tpFlummery;
        private System.Windows.Forms.Label lblHeadMisc;
        private System.Windows.Forms.TextBox txtWebsite;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.Label lblWebsite;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label lblHeadPersonalDetails;
        private System.Windows.Forms.CheckBox chkCheckForUpdates;
        private System.Windows.Forms.RadioButton rdoWorkingDirTemp;
        private System.Windows.Forms.RadioButton rdoWorkingDirFlummery;
        private System.Windows.Forms.Label lblWorking;
        private System.Windows.Forms.TabControl tcPreferences;
    }
}