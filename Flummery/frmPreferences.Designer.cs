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
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdApply = new System.Windows.Forms.Button();
            this.fbdBrowse = new System.Windows.Forms.FolderBrowserDialog();
            this.tcPreferences.SuspendLayout();
            this.tpPaths.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcPreferences
            // 
            this.tcPreferences.Controls.Add(this.tpPaths);
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
            // cmdOK
            // 
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
    }
}