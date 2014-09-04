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
            this.rdoMeshBoneSwap = new System.Windows.Forms.RadioButton();
            this.lblInvertAxis = new System.Windows.Forms.Label();
            this.cboInvertAxis = new System.Windows.Forms.ComboBox();
            this.rdoInvert = new System.Windows.Forms.RadioButton();
            this.gbRotation = new System.Windows.Forms.GroupBox();
            this.gbTranslation = new System.Windows.Forms.GroupBox();
            this.chkHierarchy = new System.Windows.Forms.CheckBox();
            this.gbScaling = new System.Windows.Forms.GroupBox();
            this.txtScaleRadius = new System.Windows.Forms.TextBox();
            this.rdoScaleRadius = new System.Windows.Forms.RadioButton();
            this.txtScaleAxisZ = new System.Windows.Forms.TextBox();
            this.lblScaleAxisZ = new System.Windows.Forms.Label();
            this.txtScaleAxisY = new System.Windows.Forms.TextBox();
            this.lblScaleAxisY = new System.Windows.Forms.Label();
            this.txtScaleAxisX = new System.Windows.Forms.TextBox();
            this.rdoScaleByAxis = new System.Windows.Forms.RadioButton();
            this.txtScaleWholeModel = new System.Windows.Forms.TextBox();
            this.lblScaleAxisX = new System.Windows.Forms.Label();
            this.rdoScaleWholeModel = new System.Windows.Forms.RadioButton();
            this.rdoFlipWindingOrder = new System.Windows.Forms.RadioButton();
            this.gbMunging.SuspendLayout();
            this.gbScaling.SuspendLayout();
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
            this.rdoMunging.Text = "Munging";
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
            this.gbMunging.Controls.Add(this.rdoFlipWindingOrder);
            this.gbMunging.Controls.Add(this.rdoMeshBoneSwap);
            this.gbMunging.Controls.Add(this.lblInvertAxis);
            this.gbMunging.Controls.Add(this.cboInvertAxis);
            this.gbMunging.Controls.Add(this.rdoInvert);
            this.gbMunging.Location = new System.Drawing.Point(13, 41);
            this.gbMunging.Name = "gbMunging";
            this.gbMunging.Size = new System.Drawing.Size(322, 179);
            this.gbMunging.TabIndex = 33;
            this.gbMunging.TabStop = false;
            this.gbMunging.Visible = false;
            // 
            // rdoMeshBoneSwap
            // 
            this.rdoMeshBoneSwap.AutoSize = true;
            this.rdoMeshBoneSwap.Location = new System.Drawing.Point(6, 46);
            this.rdoMeshBoneSwap.Name = "rdoMeshBoneSwap";
            this.rdoMeshBoneSwap.Size = new System.Drawing.Size(135, 17);
            this.rdoMeshBoneSwap.TabIndex = 3;
            this.rdoMeshBoneSwap.TabStop = true;
            this.rdoMeshBoneSwap.Text = "Munge mesh with bone";
            this.rdoMeshBoneSwap.UseVisualStyleBackColor = true;
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
            // gbRotation
            // 
            this.gbRotation.Location = new System.Drawing.Point(13, 41);
            this.gbRotation.Name = "gbRotation";
            this.gbRotation.Size = new System.Drawing.Size(322, 179);
            this.gbRotation.TabIndex = 33;
            this.gbRotation.TabStop = false;
            this.gbRotation.Visible = false;
            // 
            // gbTranslation
            // 
            this.gbTranslation.Location = new System.Drawing.Point(13, 41);
            this.gbTranslation.Name = "gbTranslation";
            this.gbTranslation.Size = new System.Drawing.Size(322, 179);
            this.gbTranslation.TabIndex = 33;
            this.gbTranslation.TabStop = false;
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
            // gbScaling
            // 
            this.gbScaling.Controls.Add(this.txtScaleRadius);
            this.gbScaling.Controls.Add(this.rdoScaleRadius);
            this.gbScaling.Controls.Add(this.txtScaleAxisZ);
            this.gbScaling.Controls.Add(this.lblScaleAxisZ);
            this.gbScaling.Controls.Add(this.txtScaleAxisY);
            this.gbScaling.Controls.Add(this.lblScaleAxisY);
            this.gbScaling.Controls.Add(this.txtScaleAxisX);
            this.gbScaling.Controls.Add(this.rdoScaleByAxis);
            this.gbScaling.Controls.Add(this.txtScaleWholeModel);
            this.gbScaling.Controls.Add(this.lblScaleAxisX);
            this.gbScaling.Controls.Add(this.rdoScaleWholeModel);
            this.gbScaling.Location = new System.Drawing.Point(13, 41);
            this.gbScaling.Name = "gbScaling";
            this.gbScaling.Size = new System.Drawing.Size(322, 179);
            this.gbScaling.TabIndex = 35;
            this.gbScaling.TabStop = false;
            this.gbScaling.Visible = false;
            // 
            // txtScaleRadius
            // 
            this.txtScaleRadius.Enabled = false;
            this.txtScaleRadius.Location = new System.Drawing.Point(93, 70);
            this.txtScaleRadius.Name = "txtScaleRadius";
            this.txtScaleRadius.Size = new System.Drawing.Size(100, 20);
            this.txtScaleRadius.TabIndex = 11;
            this.txtScaleRadius.Text = "1";
            // 
            // rdoScaleRadius
            // 
            this.rdoScaleRadius.AutoSize = true;
            this.rdoScaleRadius.Enabled = false;
            this.rdoScaleRadius.Location = new System.Drawing.Point(6, 71);
            this.rdoScaleRadius.Name = "rdoScaleRadius";
            this.rdoScaleRadius.Size = new System.Drawing.Size(83, 17);
            this.rdoScaleRadius.TabIndex = 10;
            this.rdoScaleRadius.Text = "To fit radius:";
            this.rdoScaleRadius.UseVisualStyleBackColor = true;
            this.rdoScaleRadius.CheckedChanged += new System.EventHandler(this.rdoScale_CheckedChanged);
            // 
            // txtScaleAxisZ
            // 
            this.txtScaleAxisZ.Location = new System.Drawing.Point(256, 44);
            this.txtScaleAxisZ.Name = "txtScaleAxisZ";
            this.txtScaleAxisZ.Size = new System.Drawing.Size(50, 20);
            this.txtScaleAxisZ.TabIndex = 9;
            this.txtScaleAxisZ.Text = "1";
            // 
            // lblScaleAxisZ
            // 
            this.lblScaleAxisZ.AutoSize = true;
            this.lblScaleAxisZ.Location = new System.Drawing.Point(238, 47);
            this.lblScaleAxisZ.Name = "lblScaleAxisZ";
            this.lblScaleAxisZ.Size = new System.Drawing.Size(12, 13);
            this.lblScaleAxisZ.TabIndex = 8;
            this.lblScaleAxisZ.Text = "z";
            // 
            // txtScaleAxisY
            // 
            this.txtScaleAxisY.Location = new System.Drawing.Point(182, 44);
            this.txtScaleAxisY.Name = "txtScaleAxisY";
            this.txtScaleAxisY.Size = new System.Drawing.Size(50, 20);
            this.txtScaleAxisY.TabIndex = 7;
            this.txtScaleAxisY.Text = "1";
            // 
            // lblScaleAxisY
            // 
            this.lblScaleAxisY.AutoSize = true;
            this.lblScaleAxisY.Location = new System.Drawing.Point(164, 47);
            this.lblScaleAxisY.Name = "lblScaleAxisY";
            this.lblScaleAxisY.Size = new System.Drawing.Size(12, 13);
            this.lblScaleAxisY.TabIndex = 6;
            this.lblScaleAxisY.Text = "y";
            // 
            // txtScaleAxisX
            // 
            this.txtScaleAxisX.Location = new System.Drawing.Point(108, 44);
            this.txtScaleAxisX.Name = "txtScaleAxisX";
            this.txtScaleAxisX.Size = new System.Drawing.Size(50, 20);
            this.txtScaleAxisX.TabIndex = 5;
            this.txtScaleAxisX.Text = "1";
            // 
            // rdoScaleByAxis
            // 
            this.rdoScaleByAxis.AutoSize = true;
            this.rdoScaleByAxis.Checked = true;
            this.rdoScaleByAxis.Location = new System.Drawing.Point(6, 45);
            this.rdoScaleByAxis.Name = "rdoScaleByAxis";
            this.rdoScaleByAxis.Size = new System.Drawing.Size(61, 17);
            this.rdoScaleByAxis.TabIndex = 4;
            this.rdoScaleByAxis.TabStop = true;
            this.rdoScaleByAxis.Text = "By axis:";
            this.rdoScaleByAxis.UseVisualStyleBackColor = true;
            this.rdoScaleByAxis.CheckedChanged += new System.EventHandler(this.rdoScale_CheckedChanged);
            // 
            // txtScaleWholeModel
            // 
            this.txtScaleWholeModel.Enabled = false;
            this.txtScaleWholeModel.Location = new System.Drawing.Point(93, 18);
            this.txtScaleWholeModel.Name = "txtScaleWholeModel";
            this.txtScaleWholeModel.Size = new System.Drawing.Size(100, 20);
            this.txtScaleWholeModel.TabIndex = 3;
            this.txtScaleWholeModel.Text = "1";
            // 
            // lblScaleAxisX
            // 
            this.lblScaleAxisX.AutoSize = true;
            this.lblScaleAxisX.Location = new System.Drawing.Point(90, 47);
            this.lblScaleAxisX.Name = "lblScaleAxisX";
            this.lblScaleAxisX.Size = new System.Drawing.Size(12, 13);
            this.lblScaleAxisX.TabIndex = 2;
            this.lblScaleAxisX.Text = "x";
            // 
            // rdoScaleWholeModel
            // 
            this.rdoScaleWholeModel.AutoSize = true;
            this.rdoScaleWholeModel.Location = new System.Drawing.Point(6, 19);
            this.rdoScaleWholeModel.Name = "rdoScaleWholeModel";
            this.rdoScaleWholeModel.Size = new System.Drawing.Size(90, 17);
            this.rdoScaleWholeModel.TabIndex = 0;
            this.rdoScaleWholeModel.Text = "Whole model:";
            this.rdoScaleWholeModel.UseVisualStyleBackColor = true;
            this.rdoScaleWholeModel.CheckedChanged += new System.EventHandler(this.rdoScale_CheckedChanged);
            // 
            // rdoFlipWindingOrder
            // 
            this.rdoFlipWindingOrder.AutoSize = true;
            this.rdoFlipWindingOrder.Location = new System.Drawing.Point(6, 68);
            this.rdoFlipWindingOrder.Name = "rdoFlipWindingOrder";
            this.rdoFlipWindingOrder.Size = new System.Drawing.Size(107, 17);
            this.rdoFlipWindingOrder.TabIndex = 4;
            this.rdoFlipWindingOrder.TabStop = true;
            this.rdoFlipWindingOrder.Text = "Flip winding order";
            this.rdoFlipWindingOrder.UseVisualStyleBackColor = true;
            // 
            // frmModifyModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 268);
            this.Controls.Add(this.gbMunging);
            this.Controls.Add(this.gbScaling);
            this.Controls.Add(this.gbRotation);
            this.Controls.Add(this.chkHierarchy);
            this.Controls.Add(this.gbTranslation);
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
            this.gbScaling.ResumeLayout(false);
            this.gbScaling.PerformLayout();
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
        private System.Windows.Forms.GroupBox gbRotation;
        private System.Windows.Forms.GroupBox gbTranslation;
        private System.Windows.Forms.Label lblInvertAxis;
        private System.Windows.Forms.ComboBox cboInvertAxis;
        private System.Windows.Forms.RadioButton rdoInvert;
        private System.Windows.Forms.CheckBox chkHierarchy;
        private System.Windows.Forms.GroupBox gbScaling;
        private System.Windows.Forms.Label lblScaleAxisX;
        private System.Windows.Forms.RadioButton rdoScaleWholeModel;
        private System.Windows.Forms.TextBox txtScaleAxisX;
        private System.Windows.Forms.RadioButton rdoScaleByAxis;
        private System.Windows.Forms.TextBox txtScaleWholeModel;
        private System.Windows.Forms.TextBox txtScaleAxisZ;
        private System.Windows.Forms.Label lblScaleAxisZ;
        private System.Windows.Forms.TextBox txtScaleAxisY;
        private System.Windows.Forms.Label lblScaleAxisY;
        private System.Windows.Forms.TextBox txtScaleRadius;
        private System.Windows.Forms.RadioButton rdoScaleRadius;
        private System.Windows.Forms.RadioButton rdoMeshBoneSwap;
        private System.Windows.Forms.RadioButton rdoFlipWindingOrder;
    }
}