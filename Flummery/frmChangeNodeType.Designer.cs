namespace Flummery
{
    partial class frmChangeNodeType
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
            this.gbPane = new System.Windows.Forms.GroupBox();
            this.lblOr = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbNodeType = new System.Windows.Forms.GroupBox();
            this.rdoTypeMODEL = new System.Windows.Forms.RadioButton();
            this.rdoTypeNULL = new System.Windows.Forms.RadioButton();
            this.rdoTypeLIGHT = new System.Windows.Forms.RadioButton();
            this.rdoTypeVFX = new System.Windows.Forms.RadioButton();
            this.ofdBrowse = new System.Windows.Forms.OpenFileDialog();
            this.lblWarning = new System.Windows.Forms.Label();
            this.chkNewLight = new System.Windows.Forms.CheckBox();
            this.gbPane.SuspendLayout();
            this.gbNodeType.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbPane
            // 
            this.gbPane.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPane.Controls.Add(this.chkNewLight);
            this.gbPane.Controls.Add(this.lblOr);
            this.gbPane.Controls.Add(this.txtPath);
            this.gbPane.Controls.Add(this.btnBrowse);
            this.gbPane.Location = new System.Drawing.Point(132, 12);
            this.gbPane.Name = "gbPane";
            this.gbPane.Size = new System.Drawing.Size(324, 113);
            this.gbPane.TabIndex = 0;
            this.gbPane.TabStop = false;
            this.gbPane.Text = "Settings";
            // 
            // lblOr
            // 
            this.lblOr.AutoSize = true;
            this.lblOr.Location = new System.Drawing.Point(6, 46);
            this.lblOr.Name = "lblOr";
            this.lblOr.Size = new System.Drawing.Size(16, 13);
            this.lblOr.TabIndex = 9;
            this.lblOr.Text = "or";
            this.lblOr.Visible = false;
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.Location = new System.Drawing.Point(9, 21);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(228, 20);
            this.txtPath.TabIndex = 9;
            this.txtPath.Visible = false;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(243, 19);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Visible = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(381, 138);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(300, 138);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // gbNodeType
            // 
            this.gbNodeType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbNodeType.Controls.Add(this.rdoTypeMODEL);
            this.gbNodeType.Controls.Add(this.rdoTypeNULL);
            this.gbNodeType.Controls.Add(this.rdoTypeLIGHT);
            this.gbNodeType.Controls.Add(this.rdoTypeVFX);
            this.gbNodeType.Location = new System.Drawing.Point(12, 12);
            this.gbNodeType.Name = "gbNodeType";
            this.gbNodeType.Size = new System.Drawing.Size(114, 113);
            this.gbNodeType.TabIndex = 8;
            this.gbNodeType.TabStop = false;
            this.gbNodeType.Text = "Type";
            // 
            // rdoTypeMODEL
            // 
            this.rdoTypeMODEL.AutoSize = true;
            this.rdoTypeMODEL.Location = new System.Drawing.Point(6, 42);
            this.rdoTypeMODEL.Name = "rdoTypeMODEL";
            this.rdoTypeMODEL.Size = new System.Drawing.Size(90, 17);
            this.rdoTypeMODEL.TabIndex = 10;
            this.rdoTypeMODEL.Tag = "mesh";
            this.rdoTypeMODEL.Text = "MODEL node";
            this.rdoTypeMODEL.UseVisualStyleBackColor = true;
            this.rdoTypeMODEL.CheckedChanged += new System.EventHandler(this.rdoType_CheckedChanged);
            // 
            // rdoTypeNULL
            // 
            this.rdoTypeNULL.AutoSize = true;
            this.rdoTypeNULL.Checked = true;
            this.rdoTypeNULL.Location = new System.Drawing.Point(6, 19);
            this.rdoTypeNULL.Name = "rdoTypeNULL";
            this.rdoTypeNULL.Size = new System.Drawing.Size(80, 17);
            this.rdoTypeNULL.TabIndex = 7;
            this.rdoTypeNULL.TabStop = true;
            this.rdoTypeNULL.Tag = "null";
            this.rdoTypeNULL.Text = "NULL node";
            this.rdoTypeNULL.UseVisualStyleBackColor = true;
            this.rdoTypeNULL.CheckedChanged += new System.EventHandler(this.rdoType_CheckedChanged);
            // 
            // rdoTypeLIGHT
            // 
            this.rdoTypeLIGHT.AutoSize = true;
            this.rdoTypeLIGHT.Location = new System.Drawing.Point(6, 65);
            this.rdoTypeLIGHT.Name = "rdoTypeLIGHT";
            this.rdoTypeLIGHT.Size = new System.Drawing.Size(84, 17);
            this.rdoTypeLIGHT.TabIndex = 8;
            this.rdoTypeLIGHT.Tag = "light";
            this.rdoTypeLIGHT.Text = "LIGHT node";
            this.rdoTypeLIGHT.UseVisualStyleBackColor = true;
            this.rdoTypeLIGHT.CheckedChanged += new System.EventHandler(this.rdoType_CheckedChanged);
            // 
            // rdoTypeVFX
            // 
            this.rdoTypeVFX.AutoSize = true;
            this.rdoTypeVFX.Location = new System.Drawing.Point(6, 88);
            this.rdoTypeVFX.Name = "rdoTypeVFX";
            this.rdoTypeVFX.Size = new System.Drawing.Size(72, 17);
            this.rdoTypeVFX.TabIndex = 9;
            this.rdoTypeVFX.Tag = "vfx";
            this.rdoTypeVFX.Text = "VFX node";
            this.rdoTypeVFX.UseVisualStyleBackColor = true;
            this.rdoTypeVFX.CheckedChanged += new System.EventHandler(this.rdoType_CheckedChanged);
            // 
            // lblWarning
            // 
            this.lblWarning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblWarning.AutoSize = true;
            this.lblWarning.Location = new System.Drawing.Point(12, 143);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(232, 13);
            this.lblWarning.TabIndex = 9;
            this.lblWarning.Text = "doing this may cause things to go horribly wrong";
            // 
            // chkNewLight
            // 
            this.chkNewLight.AutoSize = true;
            this.chkNewLight.Location = new System.Drawing.Point(9, 66);
            this.chkNewLight.Name = "chkNewLight";
            this.chkNewLight.Size = new System.Drawing.Size(109, 17);
            this.chkNewLight.TabIndex = 10;
            this.chkNewLight.Text = "create a new one";
            this.chkNewLight.UseVisualStyleBackColor = true;
            // 
            // frmChangeNodeType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 173);
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.gbNodeType);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.gbPane);
            this.Name = "frmChangeNodeType";
            this.Text = "Change Node Type...";
            this.Load += new System.EventHandler(this.frmChangeNodeType_Load);
            this.gbPane.ResumeLayout(false);
            this.gbPane.PerformLayout();
            this.gbNodeType.ResumeLayout(false);
            this.gbNodeType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPane;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox gbNodeType;
        private System.Windows.Forms.RadioButton rdoTypeMODEL;
        private System.Windows.Forms.RadioButton rdoTypeNULL;
        private System.Windows.Forms.RadioButton rdoTypeLIGHT;
        private System.Windows.Forms.RadioButton rdoTypeVFX;
        private System.Windows.Forms.Label lblOr;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.OpenFileDialog ofdBrowse;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.CheckBox chkNewLight;
    }
}