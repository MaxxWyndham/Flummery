namespace Flummery.Plugin.CarmageddonClassic
{
    partial class MaterialEditor
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
            gbPreview = new GroupBox();
            pbPreview = new PictureBox();
            gbGeneral = new GroupBox();
            btnReload = new Button();
            btnLoad = new Button();
            lblTexture = new Label();
            lblName = new Label();
            txtTexture = new TextBox();
            txtName = new TextBox();
            gbPropColour = new GroupBox();
            gbIndexedColour = new GroupBox();
            btnBlendTable = new Button();
            txtBlendTable = new TextBox();
            lblBlendTable = new Label();
            btnShadeTable = new Button();
            txtShadeTable = new TextBox();
            lblShadeTable = new Label();
            lblLine = new Label();
            lblIndexedColour = new Label();
            btnSelectIndexedColour = new Button();
            gbTrueColour = new GroupBox();
            lblTrueColour = new Label();
            btnSelectTrueColour = new Button();
            rdoColour = new RadioButton();
            rdoLighting = new RadioButton();
            rdoFlags = new RadioButton();
            rdoData = new RadioButton();
            gbPropLighting = new GroupBox();
            gbPropFlags = new GroupBox();
            chk16384 = new CheckBox();
            chk2 = new CheckBox();
            chk1024 = new CheckBox();
            chk512 = new CheckBox();
            chk256 = new CheckBox();
            chk128 = new CheckBox();
            chk2097152 = new CheckBox();
            chk524288 = new CheckBox();
            chk262144 = new CheckBox();
            chk65536 = new CheckBox();
            chk131072 = new CheckBox();
            chk1048576 = new CheckBox();
            chk8192 = new CheckBox();
            chk4096 = new CheckBox();
            chk2048 = new CheckBox();
            chk64 = new CheckBox();
            chk32 = new CheckBox();
            chk16 = new CheckBox();
            chk8 = new CheckBox();
            chk4 = new CheckBox();
            chk1 = new CheckBox();
            gbPropData = new GroupBox();
            btnOK = new Button();
            btnApply = new Button();
            btnCancel = new Button();
            ofdBrowse = new OpenFileDialog();
            gbPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbPreview).BeginInit();
            gbGeneral.SuspendLayout();
            gbPropColour.SuspendLayout();
            gbIndexedColour.SuspendLayout();
            gbTrueColour.SuspendLayout();
            gbPropFlags.SuspendLayout();
            SuspendLayout();
            // 
            // gbPreview
            // 
            gbPreview.Controls.Add(pbPreview);
            gbPreview.Location = new Point(14, 14);
            gbPreview.Margin = new Padding(4, 3, 4, 3);
            gbPreview.Name = "gbPreview";
            gbPreview.Padding = new Padding(4, 3, 4, 3);
            gbPreview.Size = new Size(149, 149);
            gbPreview.TabIndex = 0;
            gbPreview.TabStop = false;
            gbPreview.Text = "Preview";
            // 
            // pbPreview
            // 
            pbPreview.BorderStyle = BorderStyle.FixedSingle;
            pbPreview.Location = new Point(14, 22);
            pbPreview.Margin = new Padding(4, 3, 4, 3);
            pbPreview.Name = "pbPreview";
            pbPreview.Size = new Size(121, 120);
            pbPreview.SizeMode = PictureBoxSizeMode.StretchImage;
            pbPreview.TabIndex = 0;
            pbPreview.TabStop = false;
            // 
            // gbGeneral
            // 
            gbGeneral.Controls.Add(btnReload);
            gbGeneral.Controls.Add(btnLoad);
            gbGeneral.Controls.Add(lblTexture);
            gbGeneral.Controls.Add(lblName);
            gbGeneral.Controls.Add(txtTexture);
            gbGeneral.Controls.Add(txtName);
            gbGeneral.Location = new Point(170, 14);
            gbGeneral.Margin = new Padding(4, 3, 4, 3);
            gbGeneral.Name = "gbGeneral";
            gbGeneral.Padding = new Padding(4, 3, 4, 3);
            gbGeneral.Size = new Size(317, 115);
            gbGeneral.TabIndex = 0;
            gbGeneral.TabStop = false;
            gbGeneral.Text = "General";
            // 
            // btnReload
            // 
            btnReload.Location = new Point(7, 82);
            btnReload.Margin = new Padding(4, 3, 4, 3);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(88, 27);
            btnReload.TabIndex = 11;
            btnReload.Text = "Reload";
            btnReload.UseVisualStyleBackColor = true;
            btnReload.Click += btnReload_Click;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(223, 82);
            btnLoad.Margin = new Padding(4, 3, 4, 3);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(88, 27);
            btnLoad.TabIndex = 10;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // lblTexture
            // 
            lblTexture.AutoSize = true;
            lblTexture.Location = new Point(12, 55);
            lblTexture.Margin = new Padding(4, 0, 4, 0);
            lblTexture.Name = "lblTexture";
            lblTexture.Size = new Size(45, 15);
            lblTexture.TabIndex = 9;
            lblTexture.Text = "Texture";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(7, 25);
            lblName.Margin = new Padding(4, 0, 4, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(54, 15);
            lblName.TabIndex = 8;
            lblName.Text = "Identifier";
            // 
            // txtTexture
            // 
            txtTexture.BackColor = SystemColors.Control;
            txtTexture.Enabled = false;
            txtTexture.Location = new Point(69, 52);
            txtTexture.Margin = new Padding(4, 3, 4, 3);
            txtTexture.Name = "txtTexture";
            txtTexture.Size = new Size(241, 23);
            txtTexture.TabIndex = 7;
            // 
            // txtName
            // 
            txtName.Location = new Point(69, 22);
            txtName.Margin = new Padding(4, 3, 4, 3);
            txtName.Name = "txtName";
            txtName.Size = new Size(241, 23);
            txtName.TabIndex = 6;
            // 
            // gbPropColour
            // 
            gbPropColour.Controls.Add(gbIndexedColour);
            gbPropColour.Controls.Add(gbTrueColour);
            gbPropColour.Location = new Point(14, 170);
            gbPropColour.Margin = new Padding(4, 3, 4, 3);
            gbPropColour.Name = "gbPropColour";
            gbPropColour.Padding = new Padding(4, 3, 4, 3);
            gbPropColour.Size = new Size(474, 144);
            gbPropColour.TabIndex = 0;
            gbPropColour.TabStop = false;
            gbPropColour.Text = "Properties";
            // 
            // gbIndexedColour
            // 
            gbIndexedColour.Controls.Add(btnBlendTable);
            gbIndexedColour.Controls.Add(txtBlendTable);
            gbIndexedColour.Controls.Add(lblBlendTable);
            gbIndexedColour.Controls.Add(btnShadeTable);
            gbIndexedColour.Controls.Add(txtShadeTable);
            gbIndexedColour.Controls.Add(lblShadeTable);
            gbIndexedColour.Controls.Add(lblLine);
            gbIndexedColour.Controls.Add(lblIndexedColour);
            gbIndexedColour.Controls.Add(btnSelectIndexedColour);
            gbIndexedColour.Location = new Point(110, 22);
            gbIndexedColour.Margin = new Padding(4, 3, 4, 3);
            gbIndexedColour.Name = "gbIndexedColour";
            gbIndexedColour.Padding = new Padding(4, 3, 4, 3);
            gbIndexedColour.Size = new Size(357, 115);
            gbIndexedColour.TabIndex = 2;
            gbIndexedColour.TabStop = false;
            gbIndexedColour.Text = "Indexed colour";
            // 
            // btnBlendTable
            // 
            btnBlendTable.Location = new Point(262, 80);
            btnBlendTable.Margin = new Padding(4, 3, 4, 3);
            btnBlendTable.Name = "btnBlendTable";
            btnBlendTable.Size = new Size(88, 27);
            btnBlendTable.TabIndex = 13;
            btnBlendTable.Text = "Browse...";
            btnBlendTable.UseVisualStyleBackColor = true;
            // 
            // txtBlendTable
            // 
            txtBlendTable.BackColor = SystemColors.Control;
            txtBlendTable.Enabled = false;
            txtBlendTable.Location = new Point(105, 82);
            txtBlendTable.Margin = new Padding(4, 3, 4, 3);
            txtBlendTable.Name = "txtBlendTable";
            txtBlendTable.Size = new Size(150, 23);
            txtBlendTable.TabIndex = 12;
            // 
            // lblBlendTable
            // 
            lblBlendTable.AutoSize = true;
            lblBlendTable.Location = new Point(105, 63);
            lblBlendTable.Margin = new Padding(4, 0, 4, 0);
            lblBlendTable.Name = "lblBlendTable";
            lblBlendTable.Size = new Size(66, 15);
            lblBlendTable.TabIndex = 11;
            lblBlendTable.Text = "Blend table";
            // 
            // btnShadeTable
            // 
            btnShadeTable.Location = new Point(262, 35);
            btnShadeTable.Margin = new Padding(4, 3, 4, 3);
            btnShadeTable.Name = "btnShadeTable";
            btnShadeTable.Size = new Size(88, 27);
            btnShadeTable.TabIndex = 10;
            btnShadeTable.Text = "Browse...";
            btnShadeTable.UseVisualStyleBackColor = true;
            // 
            // txtShadeTable
            // 
            txtShadeTable.BackColor = SystemColors.Control;
            txtShadeTable.Enabled = false;
            txtShadeTable.Location = new Point(105, 37);
            txtShadeTable.Margin = new Padding(4, 3, 4, 3);
            txtShadeTable.Name = "txtShadeTable";
            txtShadeTable.Size = new Size(150, 23);
            txtShadeTable.TabIndex = 8;
            // 
            // lblShadeTable
            // 
            lblShadeTable.AutoSize = true;
            lblShadeTable.Location = new Point(105, 18);
            lblShadeTable.Margin = new Padding(4, 0, 4, 0);
            lblShadeTable.Name = "lblShadeTable";
            lblShadeTable.Size = new Size(68, 15);
            lblShadeTable.TabIndex = 3;
            lblShadeTable.Text = "Shade table";
            // 
            // lblLine
            // 
            lblLine.BackColor = Color.Black;
            lblLine.Location = new Point(96, 18);
            lblLine.Margin = new Padding(4, 0, 4, 0);
            lblLine.Name = "lblLine";
            lblLine.Size = new Size(2, 83);
            lblLine.TabIndex = 2;
            // 
            // lblIndexedColour
            // 
            lblIndexedColour.BorderStyle = BorderStyle.Fixed3D;
            lblIndexedColour.Location = new Point(7, 18);
            lblIndexedColour.Margin = new Padding(4, 0, 4, 0);
            lblIndexedColour.Name = "lblIndexedColour";
            lblIndexedColour.Size = new Size(82, 58);
            lblIndexedColour.TabIndex = 1;
            // 
            // btnSelectIndexedColour
            // 
            btnSelectIndexedColour.Location = new Point(7, 80);
            btnSelectIndexedColour.Margin = new Padding(4, 3, 4, 3);
            btnSelectIndexedColour.Name = "btnSelectIndexedColour";
            btnSelectIndexedColour.Size = new Size(82, 27);
            btnSelectIndexedColour.TabIndex = 0;
            btnSelectIndexedColour.Text = "Select...";
            btnSelectIndexedColour.UseVisualStyleBackColor = true;
            // 
            // gbTrueColour
            // 
            gbTrueColour.Controls.Add(lblTrueColour);
            gbTrueColour.Controls.Add(btnSelectTrueColour);
            gbTrueColour.Location = new Point(7, 22);
            gbTrueColour.Margin = new Padding(4, 3, 4, 3);
            gbTrueColour.Name = "gbTrueColour";
            gbTrueColour.Padding = new Padding(4, 3, 4, 3);
            gbTrueColour.Size = new Size(96, 115);
            gbTrueColour.TabIndex = 0;
            gbTrueColour.TabStop = false;
            gbTrueColour.Text = "True colour";
            // 
            // lblTrueColour
            // 
            lblTrueColour.BorderStyle = BorderStyle.Fixed3D;
            lblTrueColour.Location = new Point(7, 18);
            lblTrueColour.Margin = new Padding(4, 0, 4, 0);
            lblTrueColour.Name = "lblTrueColour";
            lblTrueColour.Size = new Size(82, 58);
            lblTrueColour.TabIndex = 1;
            // 
            // btnSelectTrueColour
            // 
            btnSelectTrueColour.Location = new Point(7, 80);
            btnSelectTrueColour.Margin = new Padding(4, 3, 4, 3);
            btnSelectTrueColour.Name = "btnSelectTrueColour";
            btnSelectTrueColour.Size = new Size(82, 27);
            btnSelectTrueColour.TabIndex = 0;
            btnSelectTrueColour.Text = "Select...";
            btnSelectTrueColour.UseVisualStyleBackColor = true;
            // 
            // rdoColour
            // 
            rdoColour.Appearance = Appearance.Button;
            rdoColour.Checked = true;
            rdoColour.FlatStyle = FlatStyle.System;
            rdoColour.Location = new Point(177, 136);
            rdoColour.Margin = new Padding(4, 3, 4, 3);
            rdoColour.Name = "rdoColour";
            rdoColour.Size = new Size(72, 27);
            rdoColour.TabIndex = 1;
            rdoColour.TabStop = true;
            rdoColour.Text = "Colour";
            rdoColour.TextAlign = ContentAlignment.MiddleCenter;
            rdoColour.UseVisualStyleBackColor = true;
            rdoColour.CheckedChanged += rdoProperties_CheckedChanged;
            // 
            // rdoLighting
            // 
            rdoLighting.Appearance = Appearance.Button;
            rdoLighting.FlatStyle = FlatStyle.System;
            rdoLighting.Location = new Point(257, 136);
            rdoLighting.Margin = new Padding(4, 3, 4, 3);
            rdoLighting.Name = "rdoLighting";
            rdoLighting.Size = new Size(72, 27);
            rdoLighting.TabIndex = 2;
            rdoLighting.Text = "Lighting";
            rdoLighting.TextAlign = ContentAlignment.MiddleCenter;
            rdoLighting.UseVisualStyleBackColor = true;
            rdoLighting.CheckedChanged += rdoProperties_CheckedChanged;
            // 
            // rdoFlags
            // 
            rdoFlags.Appearance = Appearance.Button;
            rdoFlags.FlatStyle = FlatStyle.System;
            rdoFlags.Location = new Point(336, 136);
            rdoFlags.Margin = new Padding(4, 3, 4, 3);
            rdoFlags.Name = "rdoFlags";
            rdoFlags.Size = new Size(72, 27);
            rdoFlags.TabIndex = 3;
            rdoFlags.Text = "Flags";
            rdoFlags.TextAlign = ContentAlignment.MiddleCenter;
            rdoFlags.UseVisualStyleBackColor = true;
            rdoFlags.CheckedChanged += rdoProperties_CheckedChanged;
            // 
            // rdoData
            // 
            rdoData.Appearance = Appearance.Button;
            rdoData.FlatStyle = FlatStyle.System;
            rdoData.Location = new Point(415, 136);
            rdoData.Margin = new Padding(4, 3, 4, 3);
            rdoData.Name = "rdoData";
            rdoData.Size = new Size(72, 27);
            rdoData.TabIndex = 4;
            rdoData.Text = "Data";
            rdoData.TextAlign = ContentAlignment.MiddleCenter;
            rdoData.UseVisualStyleBackColor = true;
            rdoData.CheckedChanged += rdoProperties_CheckedChanged;
            // 
            // gbPropLighting
            // 
            gbPropLighting.Location = new Point(495, 170);
            gbPropLighting.Margin = new Padding(4, 3, 4, 3);
            gbPropLighting.Name = "gbPropLighting";
            gbPropLighting.Padding = new Padding(4, 3, 4, 3);
            gbPropLighting.Size = new Size(474, 144);
            gbPropLighting.TabIndex = 1;
            gbPropLighting.TabStop = false;
            gbPropLighting.Text = "Properties";
            gbPropLighting.Visible = false;
            // 
            // gbPropFlags
            // 
            gbPropFlags.Controls.Add(chk16384);
            gbPropFlags.Controls.Add(chk2);
            gbPropFlags.Controls.Add(chk1024);
            gbPropFlags.Controls.Add(chk512);
            gbPropFlags.Controls.Add(chk256);
            gbPropFlags.Controls.Add(chk128);
            gbPropFlags.Controls.Add(chk2097152);
            gbPropFlags.Controls.Add(chk524288);
            gbPropFlags.Controls.Add(chk262144);
            gbPropFlags.Controls.Add(chk65536);
            gbPropFlags.Controls.Add(chk131072);
            gbPropFlags.Controls.Add(chk1048576);
            gbPropFlags.Controls.Add(chk8192);
            gbPropFlags.Controls.Add(chk4096);
            gbPropFlags.Controls.Add(chk2048);
            gbPropFlags.Controls.Add(chk64);
            gbPropFlags.Controls.Add(chk32);
            gbPropFlags.Controls.Add(chk16);
            gbPropFlags.Controls.Add(chk8);
            gbPropFlags.Controls.Add(chk4);
            gbPropFlags.Controls.Add(chk1);
            gbPropFlags.Location = new Point(975, 170);
            gbPropFlags.Margin = new Padding(4, 3, 4, 3);
            gbPropFlags.Name = "gbPropFlags";
            gbPropFlags.Padding = new Padding(4, 3, 4, 3);
            gbPropFlags.Size = new Size(474, 144);
            gbPropFlags.TabIndex = 2;
            gbPropFlags.TabStop = false;
            gbPropFlags.Text = "Properties";
            gbPropFlags.Visible = false;
            // 
            // chk16384
            // 
            chk16384.AutoSize = true;
            chk16384.Location = new Point(82, 44);
            chk16384.Margin = new Padding(4, 3, 4, 3);
            chk16384.Name = "chk16384";
            chk16384.Size = new Size(58, 19);
            chk16384.TabIndex = 21;
            chk16384.Text = "Dither";
            chk16384.UseVisualStyleBackColor = true;
            chk16384.CheckedChanged += chkFlags_CheckedChanged;
            // 
            // chk2
            // 
            chk2.AutoSize = true;
            chk2.Location = new Point(82, 22);
            chk2.Margin = new Padding(4, 3, 4, 3);
            chk2.Name = "chk2";
            chk2.Size = new Size(58, 19);
            chk2.TabIndex = 20;
            chk2.Text = "Pre-lit";
            chk2.UseVisualStyleBackColor = true;
            chk2.CheckedChanged += chkFlags_CheckedChanged;
            // 
            // chk1024
            // 
            chk1024.AutoSize = true;
            chk1024.Location = new Point(386, 88);
            chk1024.Margin = new Padding(4, 3, 4, 3);
            chk1024.Name = "chk1024";
            chk1024.Size = new Size(68, 19);
            chk1024.TabIndex = 19;
            chk1024.Text = "V from I";
            chk1024.UseVisualStyleBackColor = true;
            chk1024.CheckedChanged += chkFlags_CheckedChanged;
            // 
            // chk512
            // 
            chk512.AutoSize = true;
            chk512.Location = new Point(386, 66);
            chk512.Margin = new Padding(4, 3, 4, 3);
            chk512.Name = "chk512";
            chk512.Size = new Size(69, 19);
            chk512.TabIndex = 18;
            chk512.Text = "U from I";
            chk512.UseVisualStyleBackColor = true;
            chk512.CheckedChanged += chkFlags_CheckedChanged;
            // 
            // chk256
            // 
            chk256.AutoSize = true;
            chk256.Location = new Point(386, 44);
            chk256.Margin = new Padding(4, 3, 4, 3);
            chk256.Name = "chk256";
            chk256.Size = new Size(68, 19);
            chk256.TabIndex = 17;
            chk256.Text = "I from V";
            chk256.UseVisualStyleBackColor = true;
            chk256.CheckedChanged += chkFlags_CheckedChanged;
            // 
            // chk128
            // 
            chk128.AutoSize = true;
            chk128.Location = new Point(386, 22);
            chk128.Margin = new Padding(4, 3, 4, 3);
            chk128.Name = "chk128";
            chk128.Size = new Size(69, 19);
            chk128.TabIndex = 16;
            chk128.Text = "I from U";
            chk128.UseVisualStyleBackColor = true;
            chk128.CheckedChanged += chkFlags_CheckedChanged;
            // 
            // chk2097152
            // 
            chk2097152.AutoSize = true;
            chk2097152.Location = new Point(261, 110);
            chk2097152.Margin = new Padding(4, 3, 4, 3);
            chk2097152.Name = "chk2097152";
            chk2097152.Size = new Size(104, 19);
            chk2097152.TabIndex = 15;
            chk2097152.Text = "Z transparency";
            chk2097152.UseVisualStyleBackColor = true;
            chk2097152.CheckedChanged += chkFlags_CheckedChanged;
            // 
            // chk524288
            // 
            chk524288.AutoSize = true;
            chk524288.Location = new Point(261, 88);
            chk524288.Margin = new Padding(4, 3, 4, 3);
            chk524288.Name = "chk524288";
            chk524288.Size = new Size(74, 19);
            chk524288.TabIndex = 14;
            chk524288.Text = "Fog local";
            chk524288.UseVisualStyleBackColor = true;
            chk524288.CheckedChanged += chkFlags_CheckedChanged;
            // 
            // chk262144
            // 
            chk262144.AutoSize = true;
            chk262144.Location = new Point(261, 66);
            chk262144.Margin = new Padding(4, 3, 4, 3);
            chk262144.Name = "chk262144";
            chk262144.Size = new Size(118, 19);
            chk262144.TabIndex = 13;
            chk262144.Text = "Mip interpolation";
            chk262144.UseVisualStyleBackColor = true;
            chk262144.CheckedChanged += chkFlags_CheckedChanged;
            // 
            // chk65536
            // 
            chk65536.AutoSize = true;
            chk65536.Location = new Point(261, 44);
            chk65536.Margin = new Padding(4, 3, 4, 3);
            chk65536.Name = "chk65536";
            chk65536.Size = new Size(113, 19);
            chk65536.TabIndex = 12;
            chk65536.Text = "Map antialiasing";
            chk65536.UseVisualStyleBackColor = true;
            chk65536.CheckedChanged += chkFlags_CheckedChanged;
            // 
            // chk131072
            // 
            chk131072.AutoSize = true;
            chk131072.Location = new Point(261, 22);
            chk131072.Margin = new Padding(4, 3, 4, 3);
            chk131072.Name = "chk131072";
            chk131072.Size = new Size(121, 19);
            chk131072.TabIndex = 11;
            chk131072.Text = "Map interpolation";
            chk131072.UseVisualStyleBackColor = true;
            chk131072.CheckedChanged += chkFlags_CheckedChanged;
            // 
            // chk1048576
            // 
            chk1048576.AutoSize = true;
            chk1048576.Location = new Point(156, 110);
            chk1048576.Margin = new Padding(4, 3, 4, 3);
            chk1048576.Name = "chk1048576";
            chk1048576.Size = new Size(78, 19);
            chk1048576.TabIndex = 10;
            chk1048576.Text = "Subdivide";
            chk1048576.UseVisualStyleBackColor = true;
            chk1048576.CheckedChanged += chkFlags_CheckedChanged;
            // 
            // chk8192
            // 
            chk8192.AutoSize = true;
            chk8192.Location = new Point(156, 88);
            chk8192.Margin = new Padding(4, 3, 4, 3);
            chk8192.Name = "chk8192";
            chk8192.Size = new Size(84, 19);
            chk8192.TabIndex = 9;
            chk8192.Text = "Force front";
            chk8192.UseVisualStyleBackColor = true;
            chk8192.CheckedChanged += chkFlags_CheckedChanged;
            // 
            // chk4096
            // 
            chk4096.AutoSize = true;
            chk4096.Location = new Point(156, 66);
            chk4096.Margin = new Padding(4, 3, 4, 3);
            chk4096.Name = "chk4096";
            chk4096.Size = new Size(80, 19);
            chk4096.TabIndex = 8;
            chk4096.Text = "Two-sided";
            chk4096.UseVisualStyleBackColor = true;
            chk4096.CheckedChanged += chkFlags_CheckedChanged;
            // 
            // chk2048
            // 
            chk2048.AutoSize = true;
            chk2048.Location = new Point(156, 44);
            chk2048.Margin = new Padding(4, 3, 4, 3);
            chk2048.Name = "chk2048";
            chk2048.Size = new Size(99, 19);
            chk2048.TabIndex = 7;
            chk2048.Text = "Always visible";
            chk2048.UseVisualStyleBackColor = true;
            chk2048.CheckedChanged += chkFlags_CheckedChanged;
            // 
            // chk64
            // 
            chk64.AutoSize = true;
            chk64.Location = new Point(156, 22);
            chk64.Margin = new Padding(4, 3, 4, 3);
            chk64.Name = "chk64";
            chk64.Size = new Size(55, 19);
            chk64.TabIndex = 6;
            chk64.Text = "Decal";
            chk64.UseVisualStyleBackColor = true;
            chk64.CheckedChanged += chkFlags_CheckedChanged;
            // 
            // chk32
            // 
            chk32.AutoSize = true;
            chk32.Location = new Point(7, 110);
            chk32.Margin = new Padding(4, 3, 4, 3);
            chk32.Name = "chk32";
            chk32.Size = new Size(128, 19);
            chk32.TabIndex = 5;
            chk32.Text = "Correct perspective";
            chk32.UseVisualStyleBackColor = true;
            chk32.CheckedChanged += chkFlags_CheckedChanged;
            // 
            // chk16
            // 
            chk16.AutoSize = true;
            chk16.Location = new Point(7, 88);
            chk16.Margin = new Padding(4, 3, 4, 3);
            chk16.Name = "chk16";
            chk16.Size = new Size(119, 19);
            chk16.TabIndex = 4;
            chk16.Text = "Env mapped (loc)";
            chk16.UseVisualStyleBackColor = true;
            chk16.CheckedChanged += chkFlags_CheckedChanged;
            // 
            // chk8
            // 
            chk8.AutoSize = true;
            chk8.Location = new Point(7, 66);
            chk8.Margin = new Padding(4, 3, 4, 3);
            chk8.Name = "chk8";
            chk8.Size = new Size(117, 19);
            chk8.TabIndex = 3;
            chk8.Text = "Env mapped (inf)";
            chk8.UseVisualStyleBackColor = true;
            chk8.CheckedChanged += chkFlags_CheckedChanged;
            // 
            // chk4
            // 
            chk4.AutoSize = true;
            chk4.Location = new Point(7, 44);
            chk4.Margin = new Padding(4, 3, 4, 3);
            chk4.Name = "chk4";
            chk4.Size = new Size(68, 19);
            chk4.TabIndex = 2;
            chk4.Text = "Smooth";
            chk4.UseVisualStyleBackColor = true;
            chk4.CheckedChanged += chkFlags_CheckedChanged;
            // 
            // chk1
            // 
            chk1.AutoSize = true;
            chk1.Location = new Point(7, 22);
            chk1.Margin = new Padding(4, 3, 4, 3);
            chk1.Name = "chk1";
            chk1.Size = new Size(39, 19);
            chk1.TabIndex = 1;
            chk1.Text = "Lit";
            chk1.UseVisualStyleBackColor = true;
            chk1.CheckedChanged += chkFlags_CheckedChanged;
            // 
            // gbPropData
            // 
            gbPropData.Location = new Point(1456, 170);
            gbPropData.Margin = new Padding(4, 3, 4, 3);
            gbPropData.Name = "gbPropData";
            gbPropData.Padding = new Padding(4, 3, 4, 3);
            gbPropData.Size = new Size(474, 144);
            gbPropData.TabIndex = 5;
            gbPropData.TabStop = false;
            gbPropData.Text = "Properties";
            gbPropData.Visible = false;
            // 
            // btnOK
            // 
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(400, 321);
            btnOK.Margin = new Padding(4, 3, 4, 3);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(88, 27);
            btnOK.TabIndex = 1;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnApply
            // 
            btnApply.Location = new Point(306, 321);
            btnApply.Margin = new Padding(4, 3, 4, 3);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(88, 27);
            btnApply.TabIndex = 7;
            btnApply.Text = "Apply";
            btnApply.UseVisualStyleBackColor = true;
            btnApply.Click += btnApply_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(211, 321);
            btnCancel.Margin = new Padding(4, 3, 4, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(88, 27);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // MaterialEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1942, 354);
            Controls.Add(btnCancel);
            Controls.Add(btnApply);
            Controls.Add(btnOK);
            Controls.Add(gbPropData);
            Controls.Add(gbPropFlags);
            Controls.Add(gbPropLighting);
            Controls.Add(rdoData);
            Controls.Add(rdoFlags);
            Controls.Add(rdoLighting);
            Controls.Add(rdoColour);
            Controls.Add(gbGeneral);
            Controls.Add(gbPropColour);
            Controls.Add(gbPreview);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "MaterialEditor";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Material Editor...";
            gbPreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbPreview).EndInit();
            gbGeneral.ResumeLayout(false);
            gbGeneral.PerformLayout();
            gbPropColour.ResumeLayout(false);
            gbIndexedColour.ResumeLayout(false);
            gbIndexedColour.PerformLayout();
            gbTrueColour.ResumeLayout(false);
            gbPropFlags.ResumeLayout(false);
            gbPropFlags.PerformLayout();
            ResumeLayout(false);
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