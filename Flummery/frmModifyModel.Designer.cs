namespace Flummery
{
    partial class frmModifyModel
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.rdoMunging = new System.Windows.Forms.RadioButton();
            this.rdoRotation = new System.Windows.Forms.RadioButton();
            this.rdoScaling = new System.Windows.Forms.RadioButton();
            this.rdoTranslation = new System.Windows.Forms.RadioButton();
            this.gbMunging = new System.Windows.Forms.GroupBox();
            this.lblInvertAxis = new System.Windows.Forms.Label();
            this.cboInvertAxis = new System.Windows.Forms.ComboBox();
            this.rdoInvert = new System.Windows.Forms.RadioButton();
            this.chkHierarchy = new System.Windows.Forms.CheckBox();
            this.gbMunging.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(260, 233);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 28;
            this.btnOK.Text = "ok";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(179, 233);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 27;
            this.btnCancel.Text = "cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // rdoMunging
            // 
            this.rdoMunging.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoMunging.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rdoMunging.Location = new System.Drawing.Point(258, 12);
            this.rdoMunging.Name = "rdoMunging";
            this.rdoMunging.Size = new System.Drawing.Size(76, 23);
            this.rdoMunging.TabIndex = 32;
            this.rdoMunging.Text = "Axis munging";
            this.rdoMunging.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoMunging.UseVisualStyleBackColor = true;
            this.rdoMunging.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
            // 
            // rdoRotation
            // 
            this.rdoRotation.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoRotation.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rdoRotation.Location = new System.Drawing.Point(176, 12);
            this.rdoRotation.Name = "rdoRotation";
            this.rdoRotation.Size = new System.Drawing.Size(76, 23);
            this.rdoRotation.TabIndex = 31;
            this.rdoRotation.Text = "Rotation";
            this.rdoRotation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoRotation.UseVisualStyleBackColor = true;
            this.rdoRotation.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
            // 
            // rdoScaling
            // 
            this.rdoScaling.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoScaling.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rdoScaling.Location = new System.Drawing.Point(94, 12);
            this.rdoScaling.Name = "rdoScaling";
            this.rdoScaling.Size = new System.Drawing.Size(76, 23);
            this.rdoScaling.TabIndex = 30;
            this.rdoScaling.Text = "Scaling";
            this.rdoScaling.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoScaling.UseVisualStyleBackColor = true;
            this.rdoScaling.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
            // 
            // rdoTranslation
            // 
            this.rdoTranslation.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoTranslation.Checked = true;
            this.rdoTranslation.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rdoTranslation.Location = new System.Drawing.Point(12, 12);
            this.rdoTranslation.Name = "rdoTranslation";
            this.rdoTranslation.Size = new System.Drawing.Size(76, 23);
            this.rdoTranslation.TabIndex = 29;
            this.rdoTranslation.TabStop = true;
            this.rdoTranslation.Text = "Translation";
            this.rdoTranslation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoTranslation.UseVisualStyleBackColor = true;
            this.rdoTranslation.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
            // 
            // gbMunging
            // 
            this.gbMunging.Controls.Add(this.lblInvertAxis);
            this.gbMunging.Controls.Add(this.cboInvertAxis);
            this.gbMunging.Controls.Add(this.rdoInvert);
            this.gbMunging.Location = new System.Drawing.Point(12, 41);
            this.gbMunging.Name = "gbMunging";
            this.gbMunging.Size = new System.Drawing.Size(322, 179);
            this.gbMunging.TabIndex = 33;
            this.gbMunging.TabStop = false;
            this.gbMunging.Visible = false;
            // 
            // lblInvertAxis
            // 
            this.lblInvertAxis.AutoSize = true;
            this.lblInvertAxis.Location = new System.Drawing.Point(134, 21);
            this.lblInvertAxis.Name = "lblInvertAxis";
            this.lblInvertAxis.Size = new System.Drawing.Size(25, 13);
            this.lblInvertAxis.TabIndex = 2;
            this.lblInvertAxis.Text = "axis";
            // 
            // cboInvertAxis
            // 
            this.cboInvertAxis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInvertAxis.FormattingEnabled = true;
            this.cboInvertAxis.Items.AddRange(new object[] {
            "X",
            "Y",
            "Z"});
            this.cboInvertAxis.Location = new System.Drawing.Point(93, 18);
            this.cboInvertAxis.Name = "cboInvertAxis";
            this.cboInvertAxis.Size = new System.Drawing.Size(35, 21);
            this.cboInvertAxis.TabIndex = 1;
            // 
            // rdoInvert
            // 
            this.rdoInvert.AutoSize = true;
            this.rdoInvert.Location = new System.Drawing.Point(6, 19);
            this.rdoInvert.Name = "rdoInvert";
            this.rdoInvert.Size = new System.Drawing.Size(81, 17);
            this.rdoInvert.TabIndex = 0;
            this.rdoInvert.TabStop = true;
            this.rdoInvert.Text = "Invert along";
            this.rdoInvert.UseVisualStyleBackColor = true;
            // 
            // chkHierarchy
            // 
            this.chkHierarchy.AutoSize = true;
            this.chkHierarchy.Location = new System.Drawing.Point(12, 237);
            this.chkHierarchy.Name = "chkHierarchy";
            this.chkHierarchy.Size = new System.Drawing.Size(109, 17);
            this.chkHierarchy.TabIndex = 34;
            this.chkHierarchy.Text = "apply to hierarchy";
            this.chkHierarchy.UseVisualStyleBackColor = true;
            // 
            // frmModifyModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 268);
            this.Controls.Add(this.chkHierarchy);
            this.Controls.Add(this.gbMunging);
            this.Controls.Add(this.rdoMunging);
            this.Controls.Add(this.rdoRotation);
            this.Controls.Add(this.rdoScaling);
            this.Controls.Add(this.rdoTranslation);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmModifyModel";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Model Operations...";
            this.Load += new System.EventHandler(this.frmModifyModel_Load);
            this.gbMunging.ResumeLayout(false);
            this.gbMunging.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.RadioButton rdoMunging;
        private System.Windows.Forms.RadioButton rdoRotation;
        private System.Windows.Forms.RadioButton rdoScaling;
        private System.Windows.Forms.RadioButton rdoTranslation;
        private System.Windows.Forms.GroupBox gbMunging;
        private System.Windows.Forms.Label lblInvertAxis;
        private System.Windows.Forms.ComboBox cboInvertAxis;
        private System.Windows.Forms.RadioButton rdoInvert;
        private System.Windows.Forms.CheckBox chkHierarchy;
    }
}