namespace Flummery
{
    partial class frmMaterialEditor
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
            this.gbPreview = new System.Windows.Forms.GroupBox();
            this.pbPreview = new System.Windows.Forms.PictureBox();
            this.gbGeneral = new System.Windows.Forms.GroupBox();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.lblTexture = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtTexture = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.gbPropColour = new System.Windows.Forms.GroupBox();
            this.gbIndexedColour = new System.Windows.Forms.GroupBox();
            this.btnBlendTable = new System.Windows.Forms.Button();
            this.txtBlendTable = new System.Windows.Forms.TextBox();
            this.lblBlendTable = new System.Windows.Forms.Label();
            this.btnShadeTable = new System.Windows.Forms.Button();
            this.txtShadeTable = new System.Windows.Forms.TextBox();
            this.lblShadeTable = new System.Windows.Forms.Label();
            this.lblLine = new System.Windows.Forms.Label();
            this.lblIndexedColour = new System.Windows.Forms.Label();
            this.btnSelectIndexedColour = new System.Windows.Forms.Button();
            this.gbTrueColour = new System.Windows.Forms.GroupBox();
            this.lblTrueColour = new System.Windows.Forms.Label();
            this.btnSelectTrueColour = new System.Windows.Forms.Button();
            this.rdoColour = new System.Windows.Forms.RadioButton();
            this.rdoLighting = new System.Windows.Forms.RadioButton();
            this.rdoFlags = new System.Windows.Forms.RadioButton();
            this.rdoData = new System.Windows.Forms.RadioButton();
            this.gbPropLighting = new System.Windows.Forms.GroupBox();
            this.gbPropFlags = new System.Windows.Forms.GroupBox();
            this.chk16384 = new System.Windows.Forms.CheckBox();
            this.chk2 = new System.Windows.Forms.CheckBox();
            this.chk1024 = new System.Windows.Forms.CheckBox();
            this.chk512 = new System.Windows.Forms.CheckBox();
            this.chk256 = new System.Windows.Forms.CheckBox();
            this.chk128 = new System.Windows.Forms.CheckBox();
            this.chk2097152 = new System.Windows.Forms.CheckBox();
            this.chk524288 = new System.Windows.Forms.CheckBox();
            this.chk262144 = new System.Windows.Forms.CheckBox();
            this.chk65536 = new System.Windows.Forms.CheckBox();
            this.chk131072 = new System.Windows.Forms.CheckBox();
            this.chk1048576 = new System.Windows.Forms.CheckBox();
            this.chk8192 = new System.Windows.Forms.CheckBox();
            this.chk4096 = new System.Windows.Forms.CheckBox();
            this.chk2048 = new System.Windows.Forms.CheckBox();
            this.chk64 = new System.Windows.Forms.CheckBox();
            this.chk32 = new System.Windows.Forms.CheckBox();
            this.chk16 = new System.Windows.Forms.CheckBox();
            this.chk8 = new System.Windows.Forms.CheckBox();
            this.chk4 = new System.Windows.Forms.CheckBox();
            this.chk1 = new System.Windows.Forms.CheckBox();
            this.gbPropData = new System.Windows.Forms.GroupBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ofdBrowse = new System.Windows.Forms.OpenFileDialog();
            this.gbPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
            this.gbGeneral.SuspendLayout();
            this.gbPropColour.SuspendLayout();
            this.gbIndexedColour.SuspendLayout();
            this.gbTrueColour.SuspendLayout();
            this.gbPropFlags.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbPreview
            // 
            this.gbPreview.Controls.Add(this.pbPreview);
            this.gbPreview.Location = new System.Drawing.Point(12, 12);
            this.gbPreview.Name = "gbPreview";
            this.gbPreview.Size = new System.Drawing.Size(128, 129);
            this.gbPreview.TabIndex = 0;
            this.gbPreview.TabStop = false;
            this.gbPreview.Text = "Preview";
            // 
            // pbPreview
            // 
            this.pbPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPreview.Location = new System.Drawing.Point(12, 19);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(104, 104);
            this.pbPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPreview.TabIndex = 0;
            this.pbPreview.TabStop = false;
            this.pbPreview.Click += new System.EventHandler(this.pbPreview_Click);
            // 
            // gbGeneral
            // 
            this.gbGeneral.Controls.Add(this.btnReload);
            this.gbGeneral.Controls.Add(this.btnLoad);
            this.gbGeneral.Controls.Add(this.lblTexture);
            this.gbGeneral.Controls.Add(this.lblName);
            this.gbGeneral.Controls.Add(this.txtTexture);
            this.gbGeneral.Controls.Add(this.txtName);
            this.gbGeneral.Location = new System.Drawing.Point(146, 12);
            this.gbGeneral.Name = "gbGeneral";
            this.gbGeneral.Size = new System.Drawing.Size(272, 100);
            this.gbGeneral.TabIndex = 0;
            this.gbGeneral.TabStop = false;
            this.gbGeneral.Text = "General";
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(6, 71);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(75, 23);
            this.btnReload.TabIndex = 11;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(191, 71);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 10;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // lblTexture
            // 
            this.lblTexture.AutoSize = true;
            this.lblTexture.Location = new System.Drawing.Point(10, 48);
            this.lblTexture.Name = "lblTexture";
            this.lblTexture.Size = new System.Drawing.Size(43, 13);
            this.lblTexture.TabIndex = 9;
            this.lblTexture.Text = "Texture";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(6, 22);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(47, 13);
            this.lblName.TabIndex = 8;
            this.lblName.Text = "Identifier";
            // 
            // txtTexture
            // 
            this.txtTexture.BackColor = System.Drawing.SystemColors.Control;
            this.txtTexture.Enabled = false;
            this.txtTexture.Location = new System.Drawing.Point(59, 45);
            this.txtTexture.Name = "txtTexture";
            this.txtTexture.Size = new System.Drawing.Size(207, 20);
            this.txtTexture.TabIndex = 7;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(59, 19);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(207, 20);
            this.txtName.TabIndex = 6;
            // 
            // gbPropColour
            // 
            this.gbPropColour.Controls.Add(this.gbIndexedColour);
            this.gbPropColour.Controls.Add(this.gbTrueColour);
            this.gbPropColour.Location = new System.Drawing.Point(12, 147);
            this.gbPropColour.Name = "gbPropColour";
            this.gbPropColour.Size = new System.Drawing.Size(406, 125);
            this.gbPropColour.TabIndex = 0;
            this.gbPropColour.TabStop = false;
            this.gbPropColour.Text = "Properties";
            // 
            // gbIndexedColour
            // 
            this.gbIndexedColour.Controls.Add(this.btnBlendTable);
            this.gbIndexedColour.Controls.Add(this.txtBlendTable);
            this.gbIndexedColour.Controls.Add(this.lblBlendTable);
            this.gbIndexedColour.Controls.Add(this.btnShadeTable);
            this.gbIndexedColour.Controls.Add(this.txtShadeTable);
            this.gbIndexedColour.Controls.Add(this.lblShadeTable);
            this.gbIndexedColour.Controls.Add(this.lblLine);
            this.gbIndexedColour.Controls.Add(this.lblIndexedColour);
            this.gbIndexedColour.Controls.Add(this.btnSelectIndexedColour);
            this.gbIndexedColour.Location = new System.Drawing.Point(94, 19);
            this.gbIndexedColour.Name = "gbIndexedColour";
            this.gbIndexedColour.Size = new System.Drawing.Size(306, 100);
            this.gbIndexedColour.TabIndex = 2;
            this.gbIndexedColour.TabStop = false;
            this.gbIndexedColour.Text = "Indexed colour";
            // 
            // btnBlendTable
            // 
            this.btnBlendTable.Location = new System.Drawing.Point(225, 69);
            this.btnBlendTable.Name = "btnBlendTable";
            this.btnBlendTable.Size = new System.Drawing.Size(75, 23);
            this.btnBlendTable.TabIndex = 13;
            this.btnBlendTable.Text = "Browse...";
            this.btnBlendTable.UseVisualStyleBackColor = true;
            // 
            // txtBlendTable
            // 
            this.txtBlendTable.BackColor = System.Drawing.SystemColors.Control;
            this.txtBlendTable.Enabled = false;
            this.txtBlendTable.Location = new System.Drawing.Point(90, 71);
            this.txtBlendTable.Name = "txtBlendTable";
            this.txtBlendTable.Size = new System.Drawing.Size(129, 20);
            this.txtBlendTable.TabIndex = 12;
            // 
            // lblBlendTable
            // 
            this.lblBlendTable.AutoSize = true;
            this.lblBlendTable.Location = new System.Drawing.Point(90, 55);
            this.lblBlendTable.Name = "lblBlendTable";
            this.lblBlendTable.Size = new System.Drawing.Size(60, 13);
            this.lblBlendTable.TabIndex = 11;
            this.lblBlendTable.Text = "Blend table";
            // 
            // btnShadeTable
            // 
            this.btnShadeTable.Location = new System.Drawing.Point(225, 30);
            this.btnShadeTable.Name = "btnShadeTable";
            this.btnShadeTable.Size = new System.Drawing.Size(75, 23);
            this.btnShadeTable.TabIndex = 10;
            this.btnShadeTable.Text = "Browse...";
            this.btnShadeTable.UseVisualStyleBackColor = true;
            // 
            // txtShadeTable
            // 
            this.txtShadeTable.BackColor = System.Drawing.SystemColors.Control;
            this.txtShadeTable.Enabled = false;
            this.txtShadeTable.Location = new System.Drawing.Point(90, 32);
            this.txtShadeTable.Name = "txtShadeTable";
            this.txtShadeTable.Size = new System.Drawing.Size(129, 20);
            this.txtShadeTable.TabIndex = 8;
            // 
            // lblShadeTable
            // 
            this.lblShadeTable.AutoSize = true;
            this.lblShadeTable.Location = new System.Drawing.Point(90, 16);
            this.lblShadeTable.Name = "lblShadeTable";
            this.lblShadeTable.Size = new System.Drawing.Size(64, 13);
            this.lblShadeTable.TabIndex = 3;
            this.lblShadeTable.Text = "Shade table";
            // 
            // lblLine
            // 
            this.lblLine.BackColor = System.Drawing.Color.Black;
            this.lblLine.Location = new System.Drawing.Point(82, 16);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(2, 72);
            this.lblLine.TabIndex = 2;
            // 
            // lblIndexedColour
            // 
            this.lblIndexedColour.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblIndexedColour.Location = new System.Drawing.Point(6, 16);
            this.lblIndexedColour.Name = "lblIndexedColour";
            this.lblIndexedColour.Size = new System.Drawing.Size(70, 50);
            this.lblIndexedColour.TabIndex = 1;
            // 
            // btnSelectIndexedColour
            // 
            this.btnSelectIndexedColour.Location = new System.Drawing.Point(6, 69);
            this.btnSelectIndexedColour.Name = "btnSelectIndexedColour";
            this.btnSelectIndexedColour.Size = new System.Drawing.Size(70, 23);
            this.btnSelectIndexedColour.TabIndex = 0;
            this.btnSelectIndexedColour.Text = "Select...";
            this.btnSelectIndexedColour.UseVisualStyleBackColor = true;
            // 
            // gbTrueColour
            // 
            this.gbTrueColour.Controls.Add(this.lblTrueColour);
            this.gbTrueColour.Controls.Add(this.btnSelectTrueColour);
            this.gbTrueColour.Location = new System.Drawing.Point(6, 19);
            this.gbTrueColour.Name = "gbTrueColour";
            this.gbTrueColour.Size = new System.Drawing.Size(82, 100);
            this.gbTrueColour.TabIndex = 0;
            this.gbTrueColour.TabStop = false;
            this.gbTrueColour.Text = "True colour";
            // 
            // lblTrueColour
            // 
            this.lblTrueColour.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTrueColour.Location = new System.Drawing.Point(6, 16);
            this.lblTrueColour.Name = "lblTrueColour";
            this.lblTrueColour.Size = new System.Drawing.Size(70, 50);
            this.lblTrueColour.TabIndex = 1;
            // 
            // btnSelectTrueColour
            // 
            this.btnSelectTrueColour.Location = new System.Drawing.Point(6, 69);
            this.btnSelectTrueColour.Name = "btnSelectTrueColour";
            this.btnSelectTrueColour.Size = new System.Drawing.Size(70, 23);
            this.btnSelectTrueColour.TabIndex = 0;
            this.btnSelectTrueColour.Text = "Select...";
            this.btnSelectTrueColour.UseVisualStyleBackColor = true;
            // 
            // rdoColour
            // 
            this.rdoColour.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoColour.Checked = true;
            this.rdoColour.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rdoColour.Location = new System.Drawing.Point(152, 118);
            this.rdoColour.Name = "rdoColour";
            this.rdoColour.Size = new System.Drawing.Size(62, 23);
            this.rdoColour.TabIndex = 1;
            this.rdoColour.TabStop = true;
            this.rdoColour.Text = "Colour";
            this.rdoColour.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoColour.UseVisualStyleBackColor = true;
            this.rdoColour.CheckedChanged += new System.EventHandler(this.rdoProperties_CheckedChanged);
            // 
            // rdoLighting
            // 
            this.rdoLighting.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoLighting.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rdoLighting.Location = new System.Drawing.Point(220, 118);
            this.rdoLighting.Name = "rdoLighting";
            this.rdoLighting.Size = new System.Drawing.Size(62, 23);
            this.rdoLighting.TabIndex = 2;
            this.rdoLighting.Text = "Lighting";
            this.rdoLighting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoLighting.UseVisualStyleBackColor = true;
            this.rdoLighting.CheckedChanged += new System.EventHandler(this.rdoProperties_CheckedChanged);
            // 
            // rdoFlags
            // 
            this.rdoFlags.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoFlags.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rdoFlags.Location = new System.Drawing.Point(288, 118);
            this.rdoFlags.Name = "rdoFlags";
            this.rdoFlags.Size = new System.Drawing.Size(62, 23);
            this.rdoFlags.TabIndex = 3;
            this.rdoFlags.Text = "Flags";
            this.rdoFlags.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoFlags.UseVisualStyleBackColor = true;
            this.rdoFlags.CheckedChanged += new System.EventHandler(this.rdoProperties_CheckedChanged);
            // 
            // rdoData
            // 
            this.rdoData.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoData.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rdoData.Location = new System.Drawing.Point(356, 118);
            this.rdoData.Name = "rdoData";
            this.rdoData.Size = new System.Drawing.Size(62, 23);
            this.rdoData.TabIndex = 4;
            this.rdoData.Text = "Data";
            this.rdoData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoData.UseVisualStyleBackColor = true;
            this.rdoData.CheckedChanged += new System.EventHandler(this.rdoProperties_CheckedChanged);
            // 
            // gbPropLighting
            // 
            this.gbPropLighting.Location = new System.Drawing.Point(424, 147);
            this.gbPropLighting.Name = "gbPropLighting";
            this.gbPropLighting.Size = new System.Drawing.Size(406, 125);
            this.gbPropLighting.TabIndex = 1;
            this.gbPropLighting.TabStop = false;
            this.gbPropLighting.Text = "Properties";
            this.gbPropLighting.Visible = false;
            // 
            // gbPropFlags
            // 
            this.gbPropFlags.Controls.Add(this.chk16384);
            this.gbPropFlags.Controls.Add(this.chk2);
            this.gbPropFlags.Controls.Add(this.chk1024);
            this.gbPropFlags.Controls.Add(this.chk512);
            this.gbPropFlags.Controls.Add(this.chk256);
            this.gbPropFlags.Controls.Add(this.chk128);
            this.gbPropFlags.Controls.Add(this.chk2097152);
            this.gbPropFlags.Controls.Add(this.chk524288);
            this.gbPropFlags.Controls.Add(this.chk262144);
            this.gbPropFlags.Controls.Add(this.chk65536);
            this.gbPropFlags.Controls.Add(this.chk131072);
            this.gbPropFlags.Controls.Add(this.chk1048576);
            this.gbPropFlags.Controls.Add(this.chk8192);
            this.gbPropFlags.Controls.Add(this.chk4096);
            this.gbPropFlags.Controls.Add(this.chk2048);
            this.gbPropFlags.Controls.Add(this.chk64);
            this.gbPropFlags.Controls.Add(this.chk32);
            this.gbPropFlags.Controls.Add(this.chk16);
            this.gbPropFlags.Controls.Add(this.chk8);
            this.gbPropFlags.Controls.Add(this.chk4);
            this.gbPropFlags.Controls.Add(this.chk1);
            this.gbPropFlags.Location = new System.Drawing.Point(836, 147);
            this.gbPropFlags.Name = "gbPropFlags";
            this.gbPropFlags.Size = new System.Drawing.Size(406, 125);
            this.gbPropFlags.TabIndex = 2;
            this.gbPropFlags.TabStop = false;
            this.gbPropFlags.Text = "Properties";
            this.gbPropFlags.Visible = false;
            // 
            // chk16384
            // 
            this.chk16384.AutoSize = true;
            this.chk16384.Location = new System.Drawing.Point(70, 38);
            this.chk16384.Name = "chk16384";
            this.chk16384.Size = new System.Drawing.Size(54, 17);
            this.chk16384.TabIndex = 21;
            this.chk16384.Text = "Dither";
            this.chk16384.UseVisualStyleBackColor = true;
            this.chk16384.CheckedChanged += new System.EventHandler(this.chkFlags_CheckedChanged);
            // 
            // chk2
            // 
            this.chk2.AutoSize = true;
            this.chk2.Location = new System.Drawing.Point(70, 19);
            this.chk2.Name = "chk2";
            this.chk2.Size = new System.Drawing.Size(52, 17);
            this.chk2.TabIndex = 20;
            this.chk2.Text = "Pre-lit";
            this.chk2.UseVisualStyleBackColor = true;
            this.chk2.CheckedChanged += new System.EventHandler(this.chkFlags_CheckedChanged);
            // 
            // chk1024
            // 
            this.chk1024.AutoSize = true;
            this.chk1024.Location = new System.Drawing.Point(331, 76);
            this.chk1024.Name = "chk1024";
            this.chk1024.Size = new System.Drawing.Size(62, 17);
            this.chk1024.TabIndex = 19;
            this.chk1024.Text = "V from I";
            this.chk1024.UseVisualStyleBackColor = true;
            this.chk1024.CheckedChanged += new System.EventHandler(this.chkFlags_CheckedChanged);
            // 
            // chk512
            // 
            this.chk512.AutoSize = true;
            this.chk512.Location = new System.Drawing.Point(331, 57);
            this.chk512.Name = "chk512";
            this.chk512.Size = new System.Drawing.Size(63, 17);
            this.chk512.TabIndex = 18;
            this.chk512.Text = "U from I";
            this.chk512.UseVisualStyleBackColor = true;
            this.chk512.CheckedChanged += new System.EventHandler(this.chkFlags_CheckedChanged);
            // 
            // chk256
            // 
            this.chk256.AutoSize = true;
            this.chk256.Location = new System.Drawing.Point(331, 38);
            this.chk256.Name = "chk256";
            this.chk256.Size = new System.Drawing.Size(62, 17);
            this.chk256.TabIndex = 17;
            this.chk256.Text = "I from V";
            this.chk256.UseVisualStyleBackColor = true;
            this.chk256.CheckedChanged += new System.EventHandler(this.chkFlags_CheckedChanged);
            // 
            // chk128
            // 
            this.chk128.AutoSize = true;
            this.chk128.Location = new System.Drawing.Point(331, 19);
            this.chk128.Name = "chk128";
            this.chk128.Size = new System.Drawing.Size(63, 17);
            this.chk128.TabIndex = 16;
            this.chk128.Text = "I from U";
            this.chk128.UseVisualStyleBackColor = true;
            this.chk128.CheckedChanged += new System.EventHandler(this.chkFlags_CheckedChanged);
            // 
            // chk2097152
            // 
            this.chk2097152.AutoSize = true;
            this.chk2097152.Location = new System.Drawing.Point(224, 95);
            this.chk2097152.Name = "chk2097152";
            this.chk2097152.Size = new System.Drawing.Size(97, 17);
            this.chk2097152.TabIndex = 15;
            this.chk2097152.Text = "Z transparency";
            this.chk2097152.UseVisualStyleBackColor = true;
            this.chk2097152.CheckedChanged += new System.EventHandler(this.chkFlags_CheckedChanged);
            // 
            // chk524288
            // 
            this.chk524288.AutoSize = true;
            this.chk524288.Location = new System.Drawing.Point(224, 76);
            this.chk524288.Name = "chk524288";
            this.chk524288.Size = new System.Drawing.Size(69, 17);
            this.chk524288.TabIndex = 14;
            this.chk524288.Text = "Fog local";
            this.chk524288.UseVisualStyleBackColor = true;
            this.chk524288.CheckedChanged += new System.EventHandler(this.chkFlags_CheckedChanged);
            // 
            // chk262144
            // 
            this.chk262144.AutoSize = true;
            this.chk262144.Location = new System.Drawing.Point(224, 57);
            this.chk262144.Name = "chk262144";
            this.chk262144.Size = new System.Drawing.Size(103, 17);
            this.chk262144.TabIndex = 13;
            this.chk262144.Text = "Mip interpolation";
            this.chk262144.UseVisualStyleBackColor = true;
            this.chk262144.CheckedChanged += new System.EventHandler(this.chkFlags_CheckedChanged);
            // 
            // chk65536
            // 
            this.chk65536.AutoSize = true;
            this.chk65536.Location = new System.Drawing.Point(224, 38);
            this.chk65536.Name = "chk65536";
            this.chk65536.Size = new System.Drawing.Size(102, 17);
            this.chk65536.TabIndex = 12;
            this.chk65536.Text = "Map antialiasing";
            this.chk65536.UseVisualStyleBackColor = true;
            this.chk65536.CheckedChanged += new System.EventHandler(this.chkFlags_CheckedChanged);
            // 
            // chk131072
            // 
            this.chk131072.AutoSize = true;
            this.chk131072.Location = new System.Drawing.Point(224, 19);
            this.chk131072.Name = "chk131072";
            this.chk131072.Size = new System.Drawing.Size(107, 17);
            this.chk131072.TabIndex = 11;
            this.chk131072.Text = "Map interpolation";
            this.chk131072.UseVisualStyleBackColor = true;
            this.chk131072.CheckedChanged += new System.EventHandler(this.chkFlags_CheckedChanged);
            // 
            // chk1048576
            // 
            this.chk1048576.AutoSize = true;
            this.chk1048576.Location = new System.Drawing.Point(134, 95);
            this.chk1048576.Name = "chk1048576";
            this.chk1048576.Size = new System.Drawing.Size(73, 17);
            this.chk1048576.TabIndex = 10;
            this.chk1048576.Text = "Subdivide";
            this.chk1048576.UseVisualStyleBackColor = true;
            this.chk1048576.CheckedChanged += new System.EventHandler(this.chkFlags_CheckedChanged);
            // 
            // chk8192
            // 
            this.chk8192.AutoSize = true;
            this.chk8192.Location = new System.Drawing.Point(134, 76);
            this.chk8192.Name = "chk8192";
            this.chk8192.Size = new System.Drawing.Size(77, 17);
            this.chk8192.TabIndex = 9;
            this.chk8192.Text = "Force front";
            this.chk8192.UseVisualStyleBackColor = true;
            this.chk8192.CheckedChanged += new System.EventHandler(this.chkFlags_CheckedChanged);
            // 
            // chk4096
            // 
            this.chk4096.AutoSize = true;
            this.chk4096.Location = new System.Drawing.Point(134, 57);
            this.chk4096.Name = "chk4096";
            this.chk4096.Size = new System.Drawing.Size(75, 17);
            this.chk4096.TabIndex = 8;
            this.chk4096.Text = "Two-sided";
            this.chk4096.UseVisualStyleBackColor = true;
            this.chk4096.CheckedChanged += new System.EventHandler(this.chkFlags_CheckedChanged);
            // 
            // chk2048
            // 
            this.chk2048.AutoSize = true;
            this.chk2048.Location = new System.Drawing.Point(134, 38);
            this.chk2048.Name = "chk2048";
            this.chk2048.Size = new System.Drawing.Size(91, 17);
            this.chk2048.TabIndex = 7;
            this.chk2048.Text = "Always visible";
            this.chk2048.UseVisualStyleBackColor = true;
            this.chk2048.CheckedChanged += new System.EventHandler(this.chkFlags_CheckedChanged);
            // 
            // chk64
            // 
            this.chk64.AutoSize = true;
            this.chk64.Location = new System.Drawing.Point(134, 19);
            this.chk64.Name = "chk64";
            this.chk64.Size = new System.Drawing.Size(54, 17);
            this.chk64.TabIndex = 6;
            this.chk64.Text = "Decal";
            this.chk64.UseVisualStyleBackColor = true;
            this.chk64.CheckedChanged += new System.EventHandler(this.chkFlags_CheckedChanged);
            // 
            // chk32
            // 
            this.chk32.AutoSize = true;
            this.chk32.Location = new System.Drawing.Point(6, 95);
            this.chk32.Name = "chk32";
            this.chk32.Size = new System.Drawing.Size(118, 17);
            this.chk32.TabIndex = 5;
            this.chk32.Text = "Correct perspective";
            this.chk32.UseVisualStyleBackColor = true;
            this.chk32.CheckedChanged += new System.EventHandler(this.chkFlags_CheckedChanged);
            // 
            // chk16
            // 
            this.chk16.AutoSize = true;
            this.chk16.Location = new System.Drawing.Point(6, 76);
            this.chk16.Name = "chk16";
            this.chk16.Size = new System.Drawing.Size(109, 17);
            this.chk16.TabIndex = 4;
            this.chk16.Text = "Env mapped (loc)";
            this.chk16.UseVisualStyleBackColor = true;
            this.chk16.CheckedChanged += new System.EventHandler(this.chkFlags_CheckedChanged);
            // 
            // chk8
            // 
            this.chk8.AutoSize = true;
            this.chk8.Location = new System.Drawing.Point(6, 57);
            this.chk8.Name = "chk8";
            this.chk8.Size = new System.Drawing.Size(106, 17);
            this.chk8.TabIndex = 3;
            this.chk8.Text = "Env mapped (inf)";
            this.chk8.UseVisualStyleBackColor = true;
            this.chk8.CheckedChanged += new System.EventHandler(this.chkFlags_CheckedChanged);
            // 
            // chk4
            // 
            this.chk4.AutoSize = true;
            this.chk4.Location = new System.Drawing.Point(6, 38);
            this.chk4.Name = "chk4";
            this.chk4.Size = new System.Drawing.Size(62, 17);
            this.chk4.TabIndex = 2;
            this.chk4.Text = "Smooth";
            this.chk4.UseVisualStyleBackColor = true;
            this.chk4.CheckedChanged += new System.EventHandler(this.chkFlags_CheckedChanged);
            // 
            // chk1
            // 
            this.chk1.AutoSize = true;
            this.chk1.Location = new System.Drawing.Point(6, 19);
            this.chk1.Name = "chk1";
            this.chk1.Size = new System.Drawing.Size(37, 17);
            this.chk1.TabIndex = 1;
            this.chk1.Text = "Lit";
            this.chk1.UseVisualStyleBackColor = true;
            this.chk1.CheckedChanged += new System.EventHandler(this.chkFlags_CheckedChanged);
            // 
            // gbPropData
            // 
            this.gbPropData.Location = new System.Drawing.Point(1248, 147);
            this.gbPropData.Name = "gbPropData";
            this.gbPropData.Size = new System.Drawing.Size(406, 125);
            this.gbPropData.TabIndex = 5;
            this.gbPropData.TabStop = false;
            this.gbPropData.Text = "Properties";
            this.gbPropData.Visible = false;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(343, 278);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(262, 278);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 7;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(181, 278);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmMaterialEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1661, 307);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gbPropData);
            this.Controls.Add(this.gbPropFlags);
            this.Controls.Add(this.gbPropLighting);
            this.Controls.Add(this.rdoData);
            this.Controls.Add(this.rdoFlags);
            this.Controls.Add(this.rdoLighting);
            this.Controls.Add(this.rdoColour);
            this.Controls.Add(this.gbGeneral);
            this.Controls.Add(this.gbPropColour);
            this.Controls.Add(this.gbPreview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMaterialEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Material Editor...";
            this.gbPreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
            this.gbGeneral.ResumeLayout(false);
            this.gbGeneral.PerformLayout();
            this.gbPropColour.ResumeLayout(false);
            this.gbIndexedColour.ResumeLayout(false);
            this.gbIndexedColour.PerformLayout();
            this.gbTrueColour.ResumeLayout(false);
            this.gbPropFlags.ResumeLayout(false);
            this.gbPropFlags.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.GroupBox gbPreview;
        private System.Windows.Forms.GroupBox gbGeneral;
        private System.Windows.Forms.GroupBox gbPropColour;
        private System.Windows.Forms.RadioButton rdoColour;
        private System.Windows.Forms.RadioButton rdoLighting;
        private System.Windows.Forms.RadioButton rdoFlags;
        private System.Windows.Forms.RadioButton rdoData;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtTexture;
        private System.Windows.Forms.Label lblTexture;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.GroupBox gbTrueColour;
        private System.Windows.Forms.GroupBox gbPropLighting;
        private System.Windows.Forms.GroupBox gbPropFlags;
        private System.Windows.Forms.GroupBox gbPropData;
        private System.Windows.Forms.GroupBox gbIndexedColour;
        private System.Windows.Forms.Label lblIndexedColour;
        private System.Windows.Forms.Button btnSelectIndexedColour;
        private System.Windows.Forms.Label lblTrueColour;
        private System.Windows.Forms.Button btnSelectTrueColour;
        private System.Windows.Forms.Button btnBlendTable;
        private System.Windows.Forms.TextBox txtBlendTable;
        private System.Windows.Forms.Label lblBlendTable;
        private System.Windows.Forms.Button btnShadeTable;
        private System.Windows.Forms.TextBox txtShadeTable;
        private System.Windows.Forms.Label lblShadeTable;
        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.CheckBox chk32;
        private System.Windows.Forms.CheckBox chk16;
        private System.Windows.Forms.CheckBox chk8;
        private System.Windows.Forms.CheckBox chk4;
        private System.Windows.Forms.CheckBox chk1;
        private System.Windows.Forms.CheckBox chk1024;
        private System.Windows.Forms.CheckBox chk512;
        private System.Windows.Forms.CheckBox chk256;
        private System.Windows.Forms.CheckBox chk128;
        private System.Windows.Forms.CheckBox chk2097152;
        private System.Windows.Forms.CheckBox chk524288;
        private System.Windows.Forms.CheckBox chk262144;
        private System.Windows.Forms.CheckBox chk65536;
        private System.Windows.Forms.CheckBox chk131072;
        private System.Windows.Forms.CheckBox chk1048576;
        private System.Windows.Forms.CheckBox chk8192;
        private System.Windows.Forms.CheckBox chk4096;
        private System.Windows.Forms.CheckBox chk2048;
        private System.Windows.Forms.CheckBox chk64;
        private System.Windows.Forms.CheckBox chk16384;
        private System.Windows.Forms.CheckBox chk2;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox pbPreview;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.OpenFileDialog ofdBrowse;
        private System.Windows.Forms.Button btnReload;
    }
}