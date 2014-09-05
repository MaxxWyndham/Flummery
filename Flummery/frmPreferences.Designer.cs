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
            this.gbCameraControls = new System.Windows.Forms.GroupBox();
            this.lblPickedKeyFrame = new System.Windows.Forms.Label();
            this.txtKeyFrame = new System.Windows.Forms.TextBox();
            this.lblKeyFrame = new System.Windows.Forms.Label();
            this.lblPickedKeyRotate = new System.Windows.Forms.Label();
            this.txtKeyRotate = new System.Windows.Forms.TextBox();
            this.lblKeyRotate = new System.Windows.Forms.Label();
            this.lblPickedKeyZoom = new System.Windows.Forms.Label();
            this.txtKeyZoom = new System.Windows.Forms.TextBox();
            this.lblKeyZoom = new System.Windows.Forms.Label();
            this.lblPickedKeyPan = new System.Windows.Forms.Label();
            this.txtKeyPan = new System.Windows.Forms.TextBox();
            this.lblKeyPan = new System.Windows.Forms.Label();
            this.lblPickedKeySelect = new System.Windows.Forms.Label();
            this.txtKeySelect = new System.Windows.Forms.TextBox();
            this.lblKeySelect = new System.Windows.Forms.Label();
            this.tbMisc = new System.Windows.Forms.TabPage();
            this.chkCheckForUpdates = new System.Windows.Forms.CheckBox();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdApply = new System.Windows.Forms.Button();
            this.fbdBrowse = new System.Windows.Forms.FolderBrowserDialog();
            this.tcPreferences.SuspendLayout();
            this.tpPaths.SuspendLayout();
            this.tpShortcuts.SuspendLayout();
            this.gbCameraControls.SuspendLayout();
            this.tbMisc.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcPreferences
            // 
            this.tcPreferences.Controls.Add(this.tpPaths);
            this.tcPreferences.Controls.Add(this.tpShortcuts);
            this.tcPreferences.Controls.Add(this.tbMisc);
            this.tcPreferences.Location = new System.Drawing.Point(12, 12);
            this.tcPreferences.Name = "tcPreferences";
            this.tcPreferences.SelectedIndex = 0;
            this.tcPreferences.Size = new System.Drawing.Size(536, 291);
            this.tcPreferences.TabIndex = 3;
            // 
            // tpPaths
            // 
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
            this.tpPaths.Size = new System.Drawing.Size(528, 265);
            this.tpPaths.TabIndex = 0;
            this.tpPaths.Text = "Paths";
            this.tpPaths.UseVisualStyleBackColor = true;
            // 
            // btnC1Path
            // 
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
            this.txtC1Path.Enabled = false;
            this.txtC1Path.Location = new System.Drawing.Point(154, 8);
            this.txtC1Path.Name = "txtC1Path";
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
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(57, 145);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(403, 91);
            this.lblNotes.TabIndex = 9;
            this.lblNotes.Text = resources.GetString("lblNotes.Text");
            // 
            // btnC2Path
            // 
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
            this.txtC2Path.Enabled = false;
            this.txtC2Path.Location = new System.Drawing.Point(154, 37);
            this.txtC2Path.Name = "txtC2Path";
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
            this.txtCRPath.Enabled = false;
            this.txtCRPath.Location = new System.Drawing.Point(154, 66);
            this.txtCRPath.Name = "txtCRPath";
            this.txtCRPath.Size = new System.Drawing.Size(333, 20);
            this.txtCRPath.TabIndex = 4;
            // 
            // lblCRPath
            // 
            this.lblCRPath.AutoSize = true;
            this.lblCRPath.Location = new System.Drawing.Point(6, 69);
            this.lblCRPath.Name = "lblCRPath";
            this.lblCRPath.Size = new System.Drawing.Size(142, 13);
            this.lblCRPath.TabIndex = 3;
            this.lblCRPath.Text = "Carmageddon Reincarnation";
            // 
            // tpShortcuts
            // 
            this.tpShortcuts.Controls.Add(this.gbCameraControls);
            this.tpShortcuts.Location = new System.Drawing.Point(4, 22);
            this.tpShortcuts.Name = "tpShortcuts";
            this.tpShortcuts.Padding = new System.Windows.Forms.Padding(3);
            this.tpShortcuts.Size = new System.Drawing.Size(528, 265);
            this.tpShortcuts.TabIndex = 1;
            this.tpShortcuts.Text = "Keys";
            this.tpShortcuts.UseVisualStyleBackColor = true;
            // 
            // gbCameraControls
            // 
            this.gbCameraControls.Controls.Add(this.lblPickedKeyFrame);
            this.gbCameraControls.Controls.Add(this.txtKeyFrame);
            this.gbCameraControls.Controls.Add(this.lblKeyFrame);
            this.gbCameraControls.Controls.Add(this.lblPickedKeyRotate);
            this.gbCameraControls.Controls.Add(this.txtKeyRotate);
            this.gbCameraControls.Controls.Add(this.lblKeyRotate);
            this.gbCameraControls.Controls.Add(this.lblPickedKeyZoom);
            this.gbCameraControls.Controls.Add(this.txtKeyZoom);
            this.gbCameraControls.Controls.Add(this.lblKeyZoom);
            this.gbCameraControls.Controls.Add(this.lblPickedKeyPan);
            this.gbCameraControls.Controls.Add(this.txtKeyPan);
            this.gbCameraControls.Controls.Add(this.lblKeyPan);
            this.gbCameraControls.Controls.Add(this.lblPickedKeySelect);
            this.gbCameraControls.Controls.Add(this.txtKeySelect);
            this.gbCameraControls.Controls.Add(this.lblKeySelect);
            this.gbCameraControls.Location = new System.Drawing.Point(6, 6);
            this.gbCameraControls.Name = "gbCameraControls";
            this.gbCameraControls.Size = new System.Drawing.Size(516, 156);
            this.gbCameraControls.TabIndex = 3;
            this.gbCameraControls.TabStop = false;
            this.gbCameraControls.Text = "Camera Controls";
            // 
            // lblPickedKeyFrame
            // 
            this.lblPickedKeyFrame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPickedKeyFrame.Location = new System.Drawing.Point(256, 123);
            this.lblPickedKeyFrame.Name = "lblPickedKeyFrame";
            this.lblPickedKeyFrame.Size = new System.Drawing.Size(75, 20);
            this.lblPickedKeyFrame.TabIndex = 17;
            this.lblPickedKeyFrame.Text = "F";
            this.lblPickedKeyFrame.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtKeyFrame
            // 
            this.txtKeyFrame.Location = new System.Drawing.Point(337, 123);
            this.txtKeyFrame.Name = "txtKeyFrame";
            this.txtKeyFrame.Size = new System.Drawing.Size(27, 20);
            this.txtKeyFrame.TabIndex = 16;
            this.txtKeyFrame.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKey_KeyPress);
            // 
            // lblKeyFrame
            // 
            this.lblKeyFrame.AutoSize = true;
            this.lblKeyFrame.Location = new System.Drawing.Point(182, 126);
            this.lblKeyFrame.Name = "lblKeyFrame";
            this.lblKeyFrame.Size = new System.Drawing.Size(68, 13);
            this.lblKeyFrame.TabIndex = 15;
            this.lblKeyFrame.Text = "Frame object";
            // 
            // lblPickedKeyRotate
            // 
            this.lblPickedKeyRotate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPickedKeyRotate.Location = new System.Drawing.Point(256, 97);
            this.lblPickedKeyRotate.Name = "lblPickedKeyRotate";
            this.lblPickedKeyRotate.Size = new System.Drawing.Size(75, 20);
            this.lblPickedKeyRotate.TabIndex = 14;
            this.lblPickedKeyRotate.Text = "C";
            this.lblPickedKeyRotate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtKeyRotate
            // 
            this.txtKeyRotate.Location = new System.Drawing.Point(337, 97);
            this.txtKeyRotate.Name = "txtKeyRotate";
            this.txtKeyRotate.Size = new System.Drawing.Size(27, 20);
            this.txtKeyRotate.TabIndex = 13;
            this.txtKeyRotate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKey_KeyPress);
            // 
            // lblKeyRotate
            // 
            this.lblKeyRotate.AutoSize = true;
            this.lblKeyRotate.Location = new System.Drawing.Point(213, 101);
            this.lblKeyRotate.Name = "lblKeyRotate";
            this.lblKeyRotate.Size = new System.Drawing.Size(39, 13);
            this.lblKeyRotate.TabIndex = 12;
            this.lblKeyRotate.Text = "Rotate";
            // 
            // lblPickedKeyZoom
            // 
            this.lblPickedKeyZoom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPickedKeyZoom.Location = new System.Drawing.Point(256, 71);
            this.lblPickedKeyZoom.Name = "lblPickedKeyZoom";
            this.lblPickedKeyZoom.Size = new System.Drawing.Size(75, 20);
            this.lblPickedKeyZoom.TabIndex = 11;
            this.lblPickedKeyZoom.Text = "Z";
            this.lblPickedKeyZoom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtKeyZoom
            // 
            this.txtKeyZoom.Location = new System.Drawing.Point(337, 71);
            this.txtKeyZoom.Name = "txtKeyZoom";
            this.txtKeyZoom.Size = new System.Drawing.Size(27, 20);
            this.txtKeyZoom.TabIndex = 10;
            this.txtKeyZoom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKey_KeyPress);
            // 
            // lblKeyZoom
            // 
            this.lblKeyZoom.AutoSize = true;
            this.lblKeyZoom.Location = new System.Drawing.Point(213, 75);
            this.lblKeyZoom.Name = "lblKeyZoom";
            this.lblKeyZoom.Size = new System.Drawing.Size(34, 13);
            this.lblKeyZoom.TabIndex = 9;
            this.lblKeyZoom.Text = "Zoom";
            // 
            // lblPickedKeyPan
            // 
            this.lblPickedKeyPan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPickedKeyPan.Location = new System.Drawing.Point(256, 45);
            this.lblPickedKeyPan.Name = "lblPickedKeyPan";
            this.lblPickedKeyPan.Size = new System.Drawing.Size(75, 20);
            this.lblPickedKeyPan.TabIndex = 8;
            this.lblPickedKeyPan.Text = "X";
            this.lblPickedKeyPan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtKeyPan
            // 
            this.txtKeyPan.Location = new System.Drawing.Point(337, 45);
            this.txtKeyPan.Name = "txtKeyPan";
            this.txtKeyPan.Size = new System.Drawing.Size(27, 20);
            this.txtKeyPan.TabIndex = 7;
            this.txtKeyPan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKey_KeyPress);
            // 
            // lblKeyPan
            // 
            this.lblKeyPan.AutoSize = true;
            this.lblKeyPan.Location = new System.Drawing.Point(213, 49);
            this.lblKeyPan.Name = "lblKeyPan";
            this.lblKeyPan.Size = new System.Drawing.Size(26, 13);
            this.lblKeyPan.TabIndex = 6;
            this.lblKeyPan.Text = "Pan";
            // 
            // lblPickedKeySelect
            // 
            this.lblPickedKeySelect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPickedKeySelect.Location = new System.Drawing.Point(256, 19);
            this.lblPickedKeySelect.Name = "lblPickedKeySelect";
            this.lblPickedKeySelect.Size = new System.Drawing.Size(75, 20);
            this.lblPickedKeySelect.TabIndex = 5;
            this.lblPickedKeySelect.Text = "V";
            this.lblPickedKeySelect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtKeySelect
            // 
            this.txtKeySelect.Location = new System.Drawing.Point(337, 19);
            this.txtKeySelect.Name = "txtKeySelect";
            this.txtKeySelect.Size = new System.Drawing.Size(27, 20);
            this.txtKeySelect.TabIndex = 4;
            this.txtKeySelect.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKey_KeyPress);
            // 
            // lblKeySelect
            // 
            this.lblKeySelect.AutoSize = true;
            this.lblKeySelect.Location = new System.Drawing.Point(213, 23);
            this.lblKeySelect.Name = "lblKeySelect";
            this.lblKeySelect.Size = new System.Drawing.Size(37, 13);
            this.lblKeySelect.TabIndex = 3;
            this.lblKeySelect.Text = "Select";
            // 
            // tbMisc
            // 
            this.tbMisc.Controls.Add(this.chkCheckForUpdates);
            this.tbMisc.Location = new System.Drawing.Point(4, 22);
            this.tbMisc.Name = "tbMisc";
            this.tbMisc.Padding = new System.Windows.Forms.Padding(3);
            this.tbMisc.Size = new System.Drawing.Size(528, 265);
            this.tbMisc.TabIndex = 2;
            this.tbMisc.Text = "Misc";
            this.tbMisc.UseVisualStyleBackColor = true;
            // 
            // chkCheckForUpdates
            // 
            this.chkCheckForUpdates.AutoSize = true;
            this.chkCheckForUpdates.Location = new System.Drawing.Point(113, 122);
            this.chkCheckForUpdates.Name = "chkCheckForUpdates";
            this.chkCheckForUpdates.Size = new System.Drawing.Size(287, 17);
            this.chkCheckForUpdates.TabIndex = 0;
            this.chkCheckForUpdates.Text = "Automatically check for updates when Flummery starts?";
            this.chkCheckForUpdates.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOK.Location = new System.Drawing.Point(311, 309);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 4;
            this.cmdOK.Text = "ok";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(392, 309);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 5;
            this.cmdCancel.Text = "cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdApply
            // 
            this.cmdApply.Location = new System.Drawing.Point(473, 309);
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
            // frmPreferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 341);
            this.Controls.Add(this.cmdApply);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.tcPreferences);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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
            this.gbCameraControls.ResumeLayout(false);
            this.gbCameraControls.PerformLayout();
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
        private System.Windows.Forms.GroupBox gbCameraControls;
        private System.Windows.Forms.Label lblPickedKeySelect;
        private System.Windows.Forms.TextBox txtKeySelect;
        private System.Windows.Forms.Label lblKeySelect;
        private System.Windows.Forms.Label lblPickedKeyPan;
        private System.Windows.Forms.TextBox txtKeyPan;
        private System.Windows.Forms.Label lblKeyPan;
        private System.Windows.Forms.Label lblPickedKeyRotate;
        private System.Windows.Forms.TextBox txtKeyRotate;
        private System.Windows.Forms.Label lblKeyRotate;
        private System.Windows.Forms.Label lblPickedKeyZoom;
        private System.Windows.Forms.TextBox txtKeyZoom;
        private System.Windows.Forms.Label lblKeyZoom;
        private System.Windows.Forms.Label lblPickedKeyFrame;
        private System.Windows.Forms.TextBox txtKeyFrame;
        private System.Windows.Forms.Label lblKeyFrame;
        private System.Windows.Forms.TabPage tbMisc;
        private System.Windows.Forms.CheckBox chkCheckForUpdates;
    }
}