namespace Flummery.Controls
{
    partial class Transform
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
            this.btnPanelTitle = new System.Windows.Forms.Button();
            this.pnlPanel = new System.Windows.Forms.Panel();
            this.lblScale = new System.Windows.Forms.Label();
            this.lblScaleZ = new System.Windows.Forms.Label();
            this.lblScaleY = new System.Windows.Forms.Label();
            this.lblScaleX = new System.Windows.Forms.Label();
            this.txtScaleZ = new System.Windows.Forms.TextBox();
            this.txtScaleY = new System.Windows.Forms.TextBox();
            this.txtScaleX = new System.Windows.Forms.TextBox();
            this.lblRotation = new System.Windows.Forms.Label();
            this.lblRotationZ = new System.Windows.Forms.Label();
            this.lblRotationY = new System.Windows.Forms.Label();
            this.lblRotationX = new System.Windows.Forms.Label();
            this.txtRotationZ = new System.Windows.Forms.TextBox();
            this.txtRotationY = new System.Windows.Forms.TextBox();
            this.txtRotationX = new System.Windows.Forms.TextBox();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblPositionZ = new System.Windows.Forms.Label();
            this.lblPositionY = new System.Windows.Forms.Label();
            this.lblPositionX = new System.Windows.Forms.Label();
            this.txtPositionZ = new System.Windows.Forms.TextBox();
            this.txtPositionY = new System.Windows.Forms.TextBox();
            this.txtPositionX = new System.Windows.Forms.TextBox();
            this.rdoRelative = new System.Windows.Forms.RadioButton();
            this.rdoAbsolute = new System.Windows.Forms.RadioButton();
            this.btnFreezeScale = new System.Windows.Forms.Button();
            this.btnFreezeRotation = new System.Windows.Forms.Button();
            this.btnFreezePosition = new System.Windows.Forms.Button();
            this.pnlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPanelTitle
            // 
            this.btnPanelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPanelTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPanelTitle.Location = new System.Drawing.Point(5, 5);
            this.btnPanelTitle.Name = "btnPanelTitle";
            this.btnPanelTitle.Size = new System.Drawing.Size(300, 23);
            this.btnPanelTitle.TabIndex = 47;
            this.btnPanelTitle.Text = "Transform";
            this.btnPanelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPanelTitle.UseVisualStyleBackColor = true;
            this.btnPanelTitle.Click += new System.EventHandler(this.btnPanelTitle_Click);
            // 
            // pnlPanel
            // 
            this.pnlPanel.AutoSize = true;
            this.pnlPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPanel.Controls.Add(this.lblScale);
            this.pnlPanel.Controls.Add(this.btnFreezeScale);
            this.pnlPanel.Controls.Add(this.lblScaleZ);
            this.pnlPanel.Controls.Add(this.lblScaleY);
            this.pnlPanel.Controls.Add(this.lblScaleX);
            this.pnlPanel.Controls.Add(this.txtScaleZ);
            this.pnlPanel.Controls.Add(this.txtScaleY);
            this.pnlPanel.Controls.Add(this.txtScaleX);
            this.pnlPanel.Controls.Add(this.lblRotation);
            this.pnlPanel.Controls.Add(this.btnFreezeRotation);
            this.pnlPanel.Controls.Add(this.lblRotationZ);
            this.pnlPanel.Controls.Add(this.lblRotationY);
            this.pnlPanel.Controls.Add(this.lblRotationX);
            this.pnlPanel.Controls.Add(this.txtRotationZ);
            this.pnlPanel.Controls.Add(this.txtRotationY);
            this.pnlPanel.Controls.Add(this.txtRotationX);
            this.pnlPanel.Controls.Add(this.lblPosition);
            this.pnlPanel.Controls.Add(this.btnFreezePosition);
            this.pnlPanel.Controls.Add(this.lblPositionZ);
            this.pnlPanel.Controls.Add(this.lblPositionY);
            this.pnlPanel.Controls.Add(this.lblPositionX);
            this.pnlPanel.Controls.Add(this.txtPositionZ);
            this.pnlPanel.Controls.Add(this.txtPositionY);
            this.pnlPanel.Controls.Add(this.txtPositionX);
            this.pnlPanel.Controls.Add(this.rdoRelative);
            this.pnlPanel.Controls.Add(this.rdoAbsolute);
            this.pnlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPanel.Location = new System.Drawing.Point(5, 28);
            this.pnlPanel.Name = "pnlPanel";
            this.pnlPanel.Size = new System.Drawing.Size(300, 130);
            this.pnlPanel.TabIndex = 48;
            // 
            // lblScale
            // 
            this.lblScale.AutoSize = true;
            this.lblScale.Location = new System.Drawing.Point(3, 105);
            this.lblScale.Name = "lblScale";
            this.lblScale.Size = new System.Drawing.Size(34, 13);
            this.lblScale.TabIndex = 64;
            this.lblScale.Text = "Scale";
            // 
            // lblScaleZ
            // 
            this.lblScaleZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScaleZ.BackColor = System.Drawing.Color.Red;
            this.lblScaleZ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblScaleZ.ForeColor = System.Drawing.Color.White;
            this.lblScaleZ.Location = new System.Drawing.Point(199, 102);
            this.lblScaleZ.Name = "lblScaleZ";
            this.lblScaleZ.Size = new System.Drawing.Size(16, 20);
            this.lblScaleZ.TabIndex = 70;
            this.lblScaleZ.Text = "Z";
            this.lblScaleZ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblScaleY
            // 
            this.lblScaleY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScaleY.BackColor = System.Drawing.Color.Green;
            this.lblScaleY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblScaleY.ForeColor = System.Drawing.Color.White;
            this.lblScaleY.Location = new System.Drawing.Point(127, 102);
            this.lblScaleY.Name = "lblScaleY";
            this.lblScaleY.Size = new System.Drawing.Size(16, 20);
            this.lblScaleY.TabIndex = 69;
            this.lblScaleY.Text = "Y";
            this.lblScaleY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblScaleX
            // 
            this.lblScaleX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScaleX.BackColor = System.Drawing.Color.Blue;
            this.lblScaleX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblScaleX.ForeColor = System.Drawing.Color.White;
            this.lblScaleX.Location = new System.Drawing.Point(56, 102);
            this.lblScaleX.Name = "lblScaleX";
            this.lblScaleX.Size = new System.Drawing.Size(16, 20);
            this.lblScaleX.TabIndex = 68;
            this.lblScaleX.Text = "X";
            this.lblScaleX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtScaleZ
            // 
            this.txtScaleZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtScaleZ.Location = new System.Drawing.Point(214, 102);
            this.txtScaleZ.Name = "txtScaleZ";
            this.txtScaleZ.Size = new System.Drawing.Size(50, 20);
            this.txtScaleZ.TabIndex = 67;
            this.txtScaleZ.Tag = "0.00";
            this.txtScaleZ.Text = "0.00";
            this.txtScaleZ.Validating += new System.ComponentModel.CancelEventHandler(this.txtBox_Validating);
            // 
            // txtScaleY
            // 
            this.txtScaleY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtScaleY.Location = new System.Drawing.Point(143, 102);
            this.txtScaleY.Name = "txtScaleY";
            this.txtScaleY.Size = new System.Drawing.Size(50, 20);
            this.txtScaleY.TabIndex = 66;
            this.txtScaleY.Tag = "0.00";
            this.txtScaleY.Text = "0.00";
            this.txtScaleY.Validating += new System.ComponentModel.CancelEventHandler(this.txtBox_Validating);
            // 
            // txtScaleX
            // 
            this.txtScaleX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtScaleX.Location = new System.Drawing.Point(71, 102);
            this.txtScaleX.Name = "txtScaleX";
            this.txtScaleX.Size = new System.Drawing.Size(50, 20);
            this.txtScaleX.TabIndex = 65;
            this.txtScaleX.Tag = "0.00";
            this.txtScaleX.Text = "0.00";
            this.txtScaleX.Validating += new System.ComponentModel.CancelEventHandler(this.txtBox_Validating);
            // 
            // lblRotation
            // 
            this.lblRotation.AutoSize = true;
            this.lblRotation.Location = new System.Drawing.Point(3, 72);
            this.lblRotation.Name = "lblRotation";
            this.lblRotation.Size = new System.Drawing.Size(47, 13);
            this.lblRotation.TabIndex = 56;
            this.lblRotation.Text = "Rotation";
            // 
            // lblRotationZ
            // 
            this.lblRotationZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRotationZ.BackColor = System.Drawing.Color.Red;
            this.lblRotationZ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRotationZ.ForeColor = System.Drawing.Color.White;
            this.lblRotationZ.Location = new System.Drawing.Point(199, 69);
            this.lblRotationZ.Name = "lblRotationZ";
            this.lblRotationZ.Size = new System.Drawing.Size(16, 20);
            this.lblRotationZ.TabIndex = 62;
            this.lblRotationZ.Text = "Z";
            this.lblRotationZ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRotationY
            // 
            this.lblRotationY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRotationY.BackColor = System.Drawing.Color.Green;
            this.lblRotationY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRotationY.ForeColor = System.Drawing.Color.White;
            this.lblRotationY.Location = new System.Drawing.Point(127, 69);
            this.lblRotationY.Name = "lblRotationY";
            this.lblRotationY.Size = new System.Drawing.Size(16, 20);
            this.lblRotationY.TabIndex = 61;
            this.lblRotationY.Text = "Y";
            this.lblRotationY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRotationX
            // 
            this.lblRotationX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRotationX.BackColor = System.Drawing.Color.Blue;
            this.lblRotationX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRotationX.ForeColor = System.Drawing.Color.White;
            this.lblRotationX.Location = new System.Drawing.Point(56, 69);
            this.lblRotationX.Name = "lblRotationX";
            this.lblRotationX.Size = new System.Drawing.Size(16, 20);
            this.lblRotationX.TabIndex = 60;
            this.lblRotationX.Text = "X";
            this.lblRotationX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRotationZ
            // 
            this.txtRotationZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRotationZ.Location = new System.Drawing.Point(214, 69);
            this.txtRotationZ.Name = "txtRotationZ";
            this.txtRotationZ.Size = new System.Drawing.Size(50, 20);
            this.txtRotationZ.TabIndex = 59;
            this.txtRotationZ.Tag = "0.00";
            this.txtRotationZ.Text = "0.00";
            this.txtRotationZ.Validating += new System.ComponentModel.CancelEventHandler(this.txtBox_Validating);
            // 
            // txtRotationY
            // 
            this.txtRotationY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRotationY.Location = new System.Drawing.Point(143, 69);
            this.txtRotationY.Name = "txtRotationY";
            this.txtRotationY.Size = new System.Drawing.Size(50, 20);
            this.txtRotationY.TabIndex = 58;
            this.txtRotationY.Tag = "0.00";
            this.txtRotationY.Text = "0.00";
            this.txtRotationY.Validating += new System.ComponentModel.CancelEventHandler(this.txtBox_Validating);
            // 
            // txtRotationX
            // 
            this.txtRotationX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRotationX.Location = new System.Drawing.Point(71, 69);
            this.txtRotationX.Name = "txtRotationX";
            this.txtRotationX.Size = new System.Drawing.Size(50, 20);
            this.txtRotationX.TabIndex = 57;
            this.txtRotationX.Tag = "0.00";
            this.txtRotationX.Text = "0.00";
            this.txtRotationX.Validating += new System.ComponentModel.CancelEventHandler(this.txtBox_Validating);
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(3, 39);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(44, 13);
            this.lblPosition.TabIndex = 49;
            this.lblPosition.Text = "Position";
            // 
            // lblPositionZ
            // 
            this.lblPositionZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPositionZ.BackColor = System.Drawing.Color.Red;
            this.lblPositionZ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPositionZ.ForeColor = System.Drawing.Color.White;
            this.lblPositionZ.Location = new System.Drawing.Point(199, 36);
            this.lblPositionZ.Name = "lblPositionZ";
            this.lblPositionZ.Size = new System.Drawing.Size(16, 20);
            this.lblPositionZ.TabIndex = 54;
            this.lblPositionZ.Text = "Z";
            this.lblPositionZ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPositionY
            // 
            this.lblPositionY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPositionY.BackColor = System.Drawing.Color.Green;
            this.lblPositionY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPositionY.ForeColor = System.Drawing.Color.White;
            this.lblPositionY.Location = new System.Drawing.Point(127, 36);
            this.lblPositionY.Name = "lblPositionY";
            this.lblPositionY.Size = new System.Drawing.Size(16, 20);
            this.lblPositionY.TabIndex = 53;
            this.lblPositionY.Text = "Y";
            this.lblPositionY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPositionX
            // 
            this.lblPositionX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPositionX.BackColor = System.Drawing.Color.Blue;
            this.lblPositionX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPositionX.ForeColor = System.Drawing.Color.White;
            this.lblPositionX.Location = new System.Drawing.Point(56, 36);
            this.lblPositionX.Name = "lblPositionX";
            this.lblPositionX.Size = new System.Drawing.Size(16, 20);
            this.lblPositionX.TabIndex = 52;
            this.lblPositionX.Text = "X";
            this.lblPositionX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPositionZ
            // 
            this.txtPositionZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPositionZ.Location = new System.Drawing.Point(214, 36);
            this.txtPositionZ.Name = "txtPositionZ";
            this.txtPositionZ.Size = new System.Drawing.Size(50, 20);
            this.txtPositionZ.TabIndex = 51;
            this.txtPositionZ.Tag = "0.00";
            this.txtPositionZ.Text = "0.00";
            this.txtPositionZ.Validating += new System.ComponentModel.CancelEventHandler(this.txtBox_Validating);
            // 
            // txtPositionY
            // 
            this.txtPositionY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPositionY.Location = new System.Drawing.Point(143, 36);
            this.txtPositionY.Name = "txtPositionY";
            this.txtPositionY.Size = new System.Drawing.Size(50, 20);
            this.txtPositionY.TabIndex = 50;
            this.txtPositionY.Tag = "0.00";
            this.txtPositionY.Text = "0.00";
            this.txtPositionY.Validating += new System.ComponentModel.CancelEventHandler(this.txtBox_Validating);
            // 
            // txtPositionX
            // 
            this.txtPositionX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPositionX.Location = new System.Drawing.Point(71, 36);
            this.txtPositionX.Name = "txtPositionX";
            this.txtPositionX.Size = new System.Drawing.Size(50, 20);
            this.txtPositionX.TabIndex = 49;
            this.txtPositionX.Tag = "0.00";
            this.txtPositionX.Text = "0.00";
            this.txtPositionX.Validating += new System.ComponentModel.CancelEventHandler(this.txtBox_Validating);
            // 
            // rdoRelative
            // 
            this.rdoRelative.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdoRelative.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoRelative.Location = new System.Drawing.Point(218, 3);
            this.rdoRelative.Name = "rdoRelative";
            this.rdoRelative.Size = new System.Drawing.Size(77, 23);
            this.rdoRelative.TabIndex = 48;
            this.rdoRelative.Text = "relative";
            this.rdoRelative.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoRelative.UseVisualStyleBackColor = true;
            this.rdoRelative.CheckedChanged += new System.EventHandler(this.rdoRelativity_CheckedChanged);
            // 
            // rdoAbsolute
            // 
            this.rdoAbsolute.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoAbsolute.Checked = true;
            this.rdoAbsolute.Location = new System.Drawing.Point(3, 3);
            this.rdoAbsolute.Name = "rdoAbsolute";
            this.rdoAbsolute.Size = new System.Drawing.Size(77, 23);
            this.rdoAbsolute.TabIndex = 47;
            this.rdoAbsolute.TabStop = true;
            this.rdoAbsolute.Text = "absolute";
            this.rdoAbsolute.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoAbsolute.UseVisualStyleBackColor = true;
            this.rdoAbsolute.CheckedChanged += new System.EventHandler(this.rdoRelativity_CheckedChanged);
            // 
            // btnFreezeScale
            // 
            this.btnFreezeScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFreezeScale.Enabled = false;
            this.btnFreezeScale.Image = global::Flummery.Properties.Resources.interface_freeze_16x16;
            this.btnFreezeScale.Location = new System.Drawing.Point(270, 98);
            this.btnFreezeScale.Name = "btnFreezeScale";
            this.btnFreezeScale.Size = new System.Drawing.Size(25, 27);
            this.btnFreezeScale.TabIndex = 71;
            this.btnFreezeScale.UseVisualStyleBackColor = true;
            // 
            // btnFreezeRotation
            // 
            this.btnFreezeRotation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFreezeRotation.Enabled = false;
            this.btnFreezeRotation.Image = global::Flummery.Properties.Resources.interface_freeze_16x16;
            this.btnFreezeRotation.Location = new System.Drawing.Point(270, 65);
            this.btnFreezeRotation.Name = "btnFreezeRotation";
            this.btnFreezeRotation.Size = new System.Drawing.Size(25, 27);
            this.btnFreezeRotation.TabIndex = 63;
            this.btnFreezeRotation.UseVisualStyleBackColor = true;
            // 
            // btnFreezePosition
            // 
            this.btnFreezePosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFreezePosition.Enabled = false;
            this.btnFreezePosition.Image = global::Flummery.Properties.Resources.interface_freeze_16x16;
            this.btnFreezePosition.Location = new System.Drawing.Point(270, 32);
            this.btnFreezePosition.Name = "btnFreezePosition";
            this.btnFreezePosition.Size = new System.Drawing.Size(25, 27);
            this.btnFreezePosition.TabIndex = 55;
            this.btnFreezePosition.UseVisualStyleBackColor = true;
            // 
            // Transform
            // 
            this.AutoScroll = true;
            this.Controls.Add(this.pnlPanel);
            this.Controls.Add(this.btnPanelTitle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(304, 0);
            this.Name = "Transform";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(310, 163);
            this.pnlPanel.ResumeLayout(false);
            this.pnlPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPanelTitle;
        private System.Windows.Forms.Panel pnlPanel;
        private System.Windows.Forms.RadioButton rdoRelative;
        private System.Windows.Forms.RadioButton rdoAbsolute;
        private System.Windows.Forms.Label lblScale;
        private System.Windows.Forms.Button btnFreezeScale;
        private System.Windows.Forms.Label lblScaleZ;
        private System.Windows.Forms.Label lblScaleY;
        private System.Windows.Forms.Label lblScaleX;
        private System.Windows.Forms.TextBox txtScaleZ;
        private System.Windows.Forms.TextBox txtScaleY;
        private System.Windows.Forms.TextBox txtScaleX;
        private System.Windows.Forms.Label lblRotation;
        private System.Windows.Forms.Button btnFreezeRotation;
        private System.Windows.Forms.Label lblRotationZ;
        private System.Windows.Forms.Label lblRotationY;
        private System.Windows.Forms.Label lblRotationX;
        private System.Windows.Forms.TextBox txtRotationZ;
        private System.Windows.Forms.TextBox txtRotationY;
        private System.Windows.Forms.TextBox txtRotationX;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Button btnFreezePosition;
        private System.Windows.Forms.Label lblPositionZ;
        private System.Windows.Forms.Label lblPositionY;
        private System.Windows.Forms.Label lblPositionX;
        private System.Windows.Forms.TextBox txtPositionZ;
        private System.Windows.Forms.TextBox txtPositionY;
        private System.Windows.Forms.TextBox txtPositionX;
    }
}
