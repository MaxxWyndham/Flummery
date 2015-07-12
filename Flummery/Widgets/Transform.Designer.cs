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
            this.gbScale = new System.Windows.Forms.GroupBox();
            this.btnFreezeScale = new System.Windows.Forms.Button();
            this.lblScaleZUnits = new System.Windows.Forms.Label();
            this.lblScaleYUnits = new System.Windows.Forms.Label();
            this.lblScaleXUnits = new System.Windows.Forms.Label();
            this.txtScaleZ = new System.Windows.Forms.TextBox();
            this.txtScaleY = new System.Windows.Forms.TextBox();
            this.txtScaleX = new System.Windows.Forms.TextBox();
            this.lblScaleZ = new System.Windows.Forms.Label();
            this.lblScaleY = new System.Windows.Forms.Label();
            this.lblScaleX = new System.Windows.Forms.Label();
            this.gbRotation = new System.Windows.Forms.GroupBox();
            this.btnFreezeRotation = new System.Windows.Forms.Button();
            this.lblRotationZUnits = new System.Windows.Forms.Label();
            this.lblRotationYUnits = new System.Windows.Forms.Label();
            this.lblRotationXUnits = new System.Windows.Forms.Label();
            this.txtRotationZ = new System.Windows.Forms.TextBox();
            this.txtRotationY = new System.Windows.Forms.TextBox();
            this.txtRotationX = new System.Windows.Forms.TextBox();
            this.lblRotationZ = new System.Windows.Forms.Label();
            this.lblRotationY = new System.Windows.Forms.Label();
            this.lblRotationX = new System.Windows.Forms.Label();
            this.gbPosition = new System.Windows.Forms.GroupBox();
            this.btnFreezePosition = new System.Windows.Forms.Button();
            this.lblPositionZUnits = new System.Windows.Forms.Label();
            this.lblPositionYUnits = new System.Windows.Forms.Label();
            this.lblPositionXUnits = new System.Windows.Forms.Label();
            this.txtPositionZ = new System.Windows.Forms.TextBox();
            this.txtPositionY = new System.Windows.Forms.TextBox();
            this.txtPositionX = new System.Windows.Forms.TextBox();
            this.lblPositionZ = new System.Windows.Forms.Label();
            this.lblPositionY = new System.Windows.Forms.Label();
            this.lblPositionX = new System.Windows.Forms.Label();
            this.btnPanelTitle = new System.Windows.Forms.Button();
            this.pnlPanel = new System.Windows.Forms.Panel();
            this.rdoRelative = new System.Windows.Forms.RadioButton();
            this.rdoAbsolute = new System.Windows.Forms.RadioButton();
            this.gbScale.SuspendLayout();
            this.gbRotation.SuspendLayout();
            this.gbPosition.SuspendLayout();
            this.pnlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbScale
            // 
            this.gbScale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbScale.Controls.Add(this.btnFreezeScale);
            this.gbScale.Controls.Add(this.lblScaleZUnits);
            this.gbScale.Controls.Add(this.lblScaleYUnits);
            this.gbScale.Controls.Add(this.lblScaleXUnits);
            this.gbScale.Controls.Add(this.txtScaleZ);
            this.gbScale.Controls.Add(this.txtScaleY);
            this.gbScale.Controls.Add(this.txtScaleX);
            this.gbScale.Controls.Add(this.lblScaleZ);
            this.gbScale.Controls.Add(this.lblScaleY);
            this.gbScale.Controls.Add(this.lblScaleX);
            this.gbScale.Location = new System.Drawing.Point(3, 252);
            this.gbScale.Name = "gbScale";
            this.gbScale.Size = new System.Drawing.Size(156, 104);
            this.gbScale.TabIndex = 38;
            this.gbScale.TabStop = false;
            this.gbScale.Text = "Scale";
            // 
            // btnFreezeScale
            // 
            this.btnFreezeScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFreezeScale.Enabled = false;
            this.btnFreezeScale.Image = global::Flummery.Properties.Resources.interface_freeze_16x16;
            this.btnFreezeScale.Location = new System.Drawing.Point(125, 45);
            this.btnFreezeScale.Name = "btnFreezeScale";
            this.btnFreezeScale.Size = new System.Drawing.Size(25, 27);
            this.btnFreezeScale.TabIndex = 38;
            this.btnFreezeScale.UseVisualStyleBackColor = true;
            this.btnFreezeScale.Click += new System.EventHandler(this.btnFreezeScale_Click);
            // 
            // lblScaleZUnits
            // 
            this.lblScaleZUnits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScaleZUnits.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblScaleZUnits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblScaleZUnits.Location = new System.Drawing.Point(104, 74);
            this.lblScaleZUnits.Name = "lblScaleZUnits";
            this.lblScaleZUnits.Size = new System.Drawing.Size(16, 20);
            this.lblScaleZUnits.TabIndex = 32;
            this.lblScaleZUnits.Text = "%";
            this.lblScaleZUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblScaleYUnits
            // 
            this.lblScaleYUnits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScaleYUnits.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblScaleYUnits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblScaleYUnits.Location = new System.Drawing.Point(104, 48);
            this.lblScaleYUnits.Name = "lblScaleYUnits";
            this.lblScaleYUnits.Size = new System.Drawing.Size(16, 20);
            this.lblScaleYUnits.TabIndex = 31;
            this.lblScaleYUnits.Text = "%";
            this.lblScaleYUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblScaleXUnits
            // 
            this.lblScaleXUnits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScaleXUnits.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblScaleXUnits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblScaleXUnits.Location = new System.Drawing.Point(104, 22);
            this.lblScaleXUnits.Name = "lblScaleXUnits";
            this.lblScaleXUnits.Size = new System.Drawing.Size(16, 20);
            this.lblScaleXUnits.TabIndex = 30;
            this.lblScaleXUnits.Text = "%";
            this.lblScaleXUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtScaleZ
            // 
            this.txtScaleZ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtScaleZ.Location = new System.Drawing.Point(27, 74);
            this.txtScaleZ.Name = "txtScaleZ";
            this.txtScaleZ.Size = new System.Drawing.Size(78, 20);
            this.txtScaleZ.TabIndex = 17;
            this.txtScaleZ.Tag = "100";
            this.txtScaleZ.Text = "100";
            this.txtScaleZ.Click += new System.EventHandler(this.txtBox_Click);
            this.txtScaleZ.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBox_KeyUp);
            this.txtScaleZ.Validating += new System.ComponentModel.CancelEventHandler(this.txtBox_Validating);
            // 
            // txtScaleY
            // 
            this.txtScaleY.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtScaleY.Location = new System.Drawing.Point(27, 48);
            this.txtScaleY.Name = "txtScaleY";
            this.txtScaleY.Size = new System.Drawing.Size(78, 20);
            this.txtScaleY.TabIndex = 16;
            this.txtScaleY.Tag = "100";
            this.txtScaleY.Text = "100";
            this.txtScaleY.Click += new System.EventHandler(this.txtBox_Click);
            this.txtScaleY.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBox_KeyUp);
            this.txtScaleY.Validating += new System.ComponentModel.CancelEventHandler(this.txtBox_Validating);
            // 
            // txtScaleX
            // 
            this.txtScaleX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtScaleX.Location = new System.Drawing.Point(27, 22);
            this.txtScaleX.Name = "txtScaleX";
            this.txtScaleX.Size = new System.Drawing.Size(78, 20);
            this.txtScaleX.TabIndex = 15;
            this.txtScaleX.Tag = "100";
            this.txtScaleX.Text = "100";
            this.txtScaleX.Click += new System.EventHandler(this.txtBox_Click);
            this.txtScaleX.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBox_KeyUp);
            this.txtScaleX.Validating += new System.ComponentModel.CancelEventHandler(this.txtBox_Validating);
            // 
            // lblScaleZ
            // 
            this.lblScaleZ.AutoSize = true;
            this.lblScaleZ.Location = new System.Drawing.Point(7, 77);
            this.lblScaleZ.Name = "lblScaleZ";
            this.lblScaleZ.Size = new System.Drawing.Size(14, 13);
            this.lblScaleZ.TabIndex = 14;
            this.lblScaleZ.Text = "Z";
            // 
            // lblScaleY
            // 
            this.lblScaleY.AutoSize = true;
            this.lblScaleY.Location = new System.Drawing.Point(7, 51);
            this.lblScaleY.Name = "lblScaleY";
            this.lblScaleY.Size = new System.Drawing.Size(14, 13);
            this.lblScaleY.TabIndex = 13;
            this.lblScaleY.Text = "Y";
            // 
            // lblScaleX
            // 
            this.lblScaleX.AutoSize = true;
            this.lblScaleX.Location = new System.Drawing.Point(7, 25);
            this.lblScaleX.Name = "lblScaleX";
            this.lblScaleX.Size = new System.Drawing.Size(14, 13);
            this.lblScaleX.TabIndex = 12;
            this.lblScaleX.Text = "X";
            // 
            // gbRotation
            // 
            this.gbRotation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbRotation.Controls.Add(this.btnFreezeRotation);
            this.gbRotation.Controls.Add(this.lblRotationZUnits);
            this.gbRotation.Controls.Add(this.lblRotationYUnits);
            this.gbRotation.Controls.Add(this.lblRotationXUnits);
            this.gbRotation.Controls.Add(this.txtRotationZ);
            this.gbRotation.Controls.Add(this.txtRotationY);
            this.gbRotation.Controls.Add(this.txtRotationX);
            this.gbRotation.Controls.Add(this.lblRotationZ);
            this.gbRotation.Controls.Add(this.lblRotationY);
            this.gbRotation.Controls.Add(this.lblRotationX);
            this.gbRotation.Location = new System.Drawing.Point(3, 142);
            this.gbRotation.Name = "gbRotation";
            this.gbRotation.Size = new System.Drawing.Size(156, 104);
            this.gbRotation.TabIndex = 37;
            this.gbRotation.TabStop = false;
            this.gbRotation.Text = "Rotation";
            // 
            // btnFreezeRotation
            // 
            this.btnFreezeRotation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFreezeRotation.Enabled = false;
            this.btnFreezeRotation.Image = global::Flummery.Properties.Resources.interface_freeze_16x16;
            this.btnFreezeRotation.Location = new System.Drawing.Point(125, 44);
            this.btnFreezeRotation.Name = "btnFreezeRotation";
            this.btnFreezeRotation.Size = new System.Drawing.Size(25, 27);
            this.btnFreezeRotation.TabIndex = 37;
            this.btnFreezeRotation.UseVisualStyleBackColor = true;
            this.btnFreezeRotation.Click += new System.EventHandler(this.btnFreezeRotation_Click);
            // 
            // lblRotationZUnits
            // 
            this.lblRotationZUnits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRotationZUnits.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblRotationZUnits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRotationZUnits.Location = new System.Drawing.Point(104, 74);
            this.lblRotationZUnits.Name = "lblRotationZUnits";
            this.lblRotationZUnits.Size = new System.Drawing.Size(16, 20);
            this.lblRotationZUnits.TabIndex = 32;
            this.lblRotationZUnits.Text = "°";
            this.lblRotationZUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRotationYUnits
            // 
            this.lblRotationYUnits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRotationYUnits.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblRotationYUnits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRotationYUnits.Location = new System.Drawing.Point(104, 48);
            this.lblRotationYUnits.Name = "lblRotationYUnits";
            this.lblRotationYUnits.Size = new System.Drawing.Size(16, 20);
            this.lblRotationYUnits.TabIndex = 31;
            this.lblRotationYUnits.Text = "°";
            this.lblRotationYUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRotationXUnits
            // 
            this.lblRotationXUnits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRotationXUnits.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblRotationXUnits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRotationXUnits.Location = new System.Drawing.Point(104, 22);
            this.lblRotationXUnits.Name = "lblRotationXUnits";
            this.lblRotationXUnits.Size = new System.Drawing.Size(16, 20);
            this.lblRotationXUnits.TabIndex = 30;
            this.lblRotationXUnits.Text = "°";
            this.lblRotationXUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRotationZ
            // 
            this.txtRotationZ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRotationZ.Location = new System.Drawing.Point(27, 74);
            this.txtRotationZ.Name = "txtRotationZ";
            this.txtRotationZ.Size = new System.Drawing.Size(78, 20);
            this.txtRotationZ.TabIndex = 17;
            this.txtRotationZ.Tag = "0";
            this.txtRotationZ.Text = "0";
            this.txtRotationZ.Click += new System.EventHandler(this.txtBox_Click);
            this.txtRotationZ.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBox_KeyUp);
            this.txtRotationZ.Validating += new System.ComponentModel.CancelEventHandler(this.txtBox_Validating);
            // 
            // txtRotationY
            // 
            this.txtRotationY.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRotationY.Location = new System.Drawing.Point(27, 48);
            this.txtRotationY.Name = "txtRotationY";
            this.txtRotationY.Size = new System.Drawing.Size(78, 20);
            this.txtRotationY.TabIndex = 16;
            this.txtRotationY.Tag = "0";
            this.txtRotationY.Text = "0";
            this.txtRotationY.Click += new System.EventHandler(this.txtBox_Click);
            this.txtRotationY.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBox_KeyUp);
            this.txtRotationY.Validating += new System.ComponentModel.CancelEventHandler(this.txtBox_Validating);
            // 
            // txtRotationX
            // 
            this.txtRotationX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRotationX.Location = new System.Drawing.Point(27, 22);
            this.txtRotationX.Name = "txtRotationX";
            this.txtRotationX.Size = new System.Drawing.Size(78, 20);
            this.txtRotationX.TabIndex = 15;
            this.txtRotationX.Tag = "0";
            this.txtRotationX.Text = "0";
            this.txtRotationX.Click += new System.EventHandler(this.txtBox_Click);
            this.txtRotationX.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBox_KeyUp);
            this.txtRotationX.Validating += new System.ComponentModel.CancelEventHandler(this.txtBox_Validating);
            // 
            // lblRotationZ
            // 
            this.lblRotationZ.AutoSize = true;
            this.lblRotationZ.Location = new System.Drawing.Point(7, 77);
            this.lblRotationZ.Name = "lblRotationZ";
            this.lblRotationZ.Size = new System.Drawing.Size(14, 13);
            this.lblRotationZ.TabIndex = 14;
            this.lblRotationZ.Text = "Z";
            // 
            // lblRotationY
            // 
            this.lblRotationY.AutoSize = true;
            this.lblRotationY.Location = new System.Drawing.Point(7, 51);
            this.lblRotationY.Name = "lblRotationY";
            this.lblRotationY.Size = new System.Drawing.Size(14, 13);
            this.lblRotationY.TabIndex = 13;
            this.lblRotationY.Text = "Y";
            // 
            // lblRotationX
            // 
            this.lblRotationX.AutoSize = true;
            this.lblRotationX.Location = new System.Drawing.Point(7, 25);
            this.lblRotationX.Name = "lblRotationX";
            this.lblRotationX.Size = new System.Drawing.Size(14, 13);
            this.lblRotationX.TabIndex = 12;
            this.lblRotationX.Text = "X";
            // 
            // gbPosition
            // 
            this.gbPosition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPosition.Controls.Add(this.btnFreezePosition);
            this.gbPosition.Controls.Add(this.lblPositionZUnits);
            this.gbPosition.Controls.Add(this.lblPositionYUnits);
            this.gbPosition.Controls.Add(this.lblPositionXUnits);
            this.gbPosition.Controls.Add(this.txtPositionZ);
            this.gbPosition.Controls.Add(this.txtPositionY);
            this.gbPosition.Controls.Add(this.txtPositionX);
            this.gbPosition.Controls.Add(this.lblPositionZ);
            this.gbPosition.Controls.Add(this.lblPositionY);
            this.gbPosition.Controls.Add(this.lblPositionX);
            this.gbPosition.Location = new System.Drawing.Point(3, 32);
            this.gbPosition.Name = "gbPosition";
            this.gbPosition.Size = new System.Drawing.Size(156, 104);
            this.gbPosition.TabIndex = 43;
            this.gbPosition.TabStop = false;
            this.gbPosition.Text = "Position";
            // 
            // btnFreezePosition
            // 
            this.btnFreezePosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFreezePosition.Enabled = false;
            this.btnFreezePosition.Image = global::Flummery.Properties.Resources.interface_freeze_16x16;
            this.btnFreezePosition.Location = new System.Drawing.Point(125, 45);
            this.btnFreezePosition.Name = "btnFreezePosition";
            this.btnFreezePosition.Size = new System.Drawing.Size(25, 27);
            this.btnFreezePosition.TabIndex = 36;
            this.btnFreezePosition.UseVisualStyleBackColor = true;
            this.btnFreezePosition.Click += new System.EventHandler(this.btnFreezePosition_Click);
            // 
            // lblPositionZUnits
            // 
            this.lblPositionZUnits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPositionZUnits.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblPositionZUnits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPositionZUnits.Location = new System.Drawing.Point(104, 74);
            this.lblPositionZUnits.Name = "lblPositionZUnits";
            this.lblPositionZUnits.Size = new System.Drawing.Size(16, 20);
            this.lblPositionZUnits.TabIndex = 32;
            this.lblPositionZUnits.Text = "m";
            this.lblPositionZUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPositionYUnits
            // 
            this.lblPositionYUnits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPositionYUnits.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblPositionYUnits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPositionYUnits.Location = new System.Drawing.Point(104, 48);
            this.lblPositionYUnits.Name = "lblPositionYUnits";
            this.lblPositionYUnits.Size = new System.Drawing.Size(16, 20);
            this.lblPositionYUnits.TabIndex = 31;
            this.lblPositionYUnits.Text = "m";
            this.lblPositionYUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPositionXUnits
            // 
            this.lblPositionXUnits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPositionXUnits.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblPositionXUnits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPositionXUnits.Location = new System.Drawing.Point(104, 22);
            this.lblPositionXUnits.Name = "lblPositionXUnits";
            this.lblPositionXUnits.Size = new System.Drawing.Size(16, 20);
            this.lblPositionXUnits.TabIndex = 30;
            this.lblPositionXUnits.Text = "m";
            this.lblPositionXUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPositionZ
            // 
            this.txtPositionZ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPositionZ.Location = new System.Drawing.Point(27, 74);
            this.txtPositionZ.Name = "txtPositionZ";
            this.txtPositionZ.Size = new System.Drawing.Size(78, 20);
            this.txtPositionZ.TabIndex = 17;
            this.txtPositionZ.Tag = "0.00";
            this.txtPositionZ.Text = "0.00";
            this.txtPositionZ.Click += new System.EventHandler(this.txtBox_Click);
            this.txtPositionZ.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBox_KeyUp);
            this.txtPositionZ.Validating += new System.ComponentModel.CancelEventHandler(this.txtBox_Validating);
            // 
            // txtPositionY
            // 
            this.txtPositionY.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPositionY.Location = new System.Drawing.Point(27, 48);
            this.txtPositionY.Name = "txtPositionY";
            this.txtPositionY.Size = new System.Drawing.Size(78, 20);
            this.txtPositionY.TabIndex = 16;
            this.txtPositionY.Tag = "0.00";
            this.txtPositionY.Text = "0.00";
            this.txtPositionY.Click += new System.EventHandler(this.txtBox_Click);
            this.txtPositionY.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBox_KeyUp);
            this.txtPositionY.Validating += new System.ComponentModel.CancelEventHandler(this.txtBox_Validating);
            // 
            // txtPositionX
            // 
            this.txtPositionX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPositionX.Location = new System.Drawing.Point(27, 22);
            this.txtPositionX.Name = "txtPositionX";
            this.txtPositionX.Size = new System.Drawing.Size(78, 20);
            this.txtPositionX.TabIndex = 15;
            this.txtPositionX.Tag = "0.00";
            this.txtPositionX.Text = "0.00";
            this.txtPositionX.Click += new System.EventHandler(this.txtBox_Click);
            this.txtPositionX.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBox_KeyUp);
            this.txtPositionX.Validating += new System.ComponentModel.CancelEventHandler(this.txtBox_Validating);
            // 
            // lblPositionZ
            // 
            this.lblPositionZ.AutoSize = true;
            this.lblPositionZ.Location = new System.Drawing.Point(7, 77);
            this.lblPositionZ.Name = "lblPositionZ";
            this.lblPositionZ.Size = new System.Drawing.Size(14, 13);
            this.lblPositionZ.TabIndex = 14;
            this.lblPositionZ.Text = "Z";
            // 
            // lblPositionY
            // 
            this.lblPositionY.AutoSize = true;
            this.lblPositionY.Location = new System.Drawing.Point(7, 51);
            this.lblPositionY.Name = "lblPositionY";
            this.lblPositionY.Size = new System.Drawing.Size(14, 13);
            this.lblPositionY.TabIndex = 13;
            this.lblPositionY.Text = "Y";
            // 
            // lblPositionX
            // 
            this.lblPositionX.AutoSize = true;
            this.lblPositionX.Location = new System.Drawing.Point(7, 25);
            this.lblPositionX.Name = "lblPositionX";
            this.lblPositionX.Size = new System.Drawing.Size(14, 13);
            this.lblPositionX.TabIndex = 12;
            this.lblPositionX.Text = "X";
            // 
            // btnPanelTitle
            // 
            this.btnPanelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPanelTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPanelTitle.Location = new System.Drawing.Point(5, 5);
            this.btnPanelTitle.Name = "btnPanelTitle";
            this.btnPanelTitle.Size = new System.Drawing.Size(164, 23);
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
            this.pnlPanel.Controls.Add(this.rdoRelative);
            this.pnlPanel.Controls.Add(this.rdoAbsolute);
            this.pnlPanel.Controls.Add(this.gbPosition);
            this.pnlPanel.Controls.Add(this.gbRotation);
            this.pnlPanel.Controls.Add(this.gbScale);
            this.pnlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPanel.Location = new System.Drawing.Point(5, 28);
            this.pnlPanel.Name = "pnlPanel";
            this.pnlPanel.Size = new System.Drawing.Size(164, 361);
            this.pnlPanel.TabIndex = 48;
            // 
            // rdoRelative
            // 
            this.rdoRelative.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdoRelative.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoRelative.Location = new System.Drawing.Point(82, 3);
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
            // Transform
            // 
            this.AutoScroll = true;
            this.Controls.Add(this.pnlPanel);
            this.Controls.Add(this.btnPanelTitle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(174, 0);
            this.Name = "Transform";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(174, 394);
            this.gbScale.ResumeLayout(false);
            this.gbScale.PerformLayout();
            this.gbRotation.ResumeLayout(false);
            this.gbRotation.PerformLayout();
            this.gbPosition.ResumeLayout(false);
            this.gbPosition.PerformLayout();
            this.pnlPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbScale;
        private System.Windows.Forms.Button btnFreezeScale;
        private System.Windows.Forms.Label lblScaleZUnits;
        private System.Windows.Forms.Label lblScaleYUnits;
        private System.Windows.Forms.Label lblScaleXUnits;
        private System.Windows.Forms.TextBox txtScaleZ;
        private System.Windows.Forms.TextBox txtScaleY;
        private System.Windows.Forms.TextBox txtScaleX;
        private System.Windows.Forms.Label lblScaleZ;
        private System.Windows.Forms.Label lblScaleY;
        private System.Windows.Forms.Label lblScaleX;
        private System.Windows.Forms.GroupBox gbRotation;
        private System.Windows.Forms.Button btnFreezeRotation;
        private System.Windows.Forms.Label lblRotationZUnits;
        private System.Windows.Forms.Label lblRotationYUnits;
        private System.Windows.Forms.Label lblRotationXUnits;
        private System.Windows.Forms.TextBox txtRotationZ;
        private System.Windows.Forms.TextBox txtRotationY;
        private System.Windows.Forms.TextBox txtRotationX;
        private System.Windows.Forms.Label lblRotationZ;
        private System.Windows.Forms.Label lblRotationY;
        private System.Windows.Forms.Label lblRotationX;
        private System.Windows.Forms.GroupBox gbPosition;
        private System.Windows.Forms.Button btnFreezePosition;
        private System.Windows.Forms.Label lblPositionZUnits;
        private System.Windows.Forms.Label lblPositionYUnits;
        private System.Windows.Forms.Label lblPositionXUnits;
        private System.Windows.Forms.TextBox txtPositionZ;
        private System.Windows.Forms.TextBox txtPositionY;
        private System.Windows.Forms.TextBox txtPositionX;
        private System.Windows.Forms.Label lblPositionZ;
        private System.Windows.Forms.Label lblPositionY;
        private System.Windows.Forms.Label lblPositionX;
        private System.Windows.Forms.Button btnPanelTitle;
        private System.Windows.Forms.Panel pnlPanel;
        private System.Windows.Forms.RadioButton rdoRelative;
        private System.Windows.Forms.RadioButton rdoAbsolute;
    }
}
