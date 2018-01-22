namespace Flummery
{
    partial class frmReincarnationMaterialEditor
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
            this.gbFlags = new System.Windows.Forms.GroupBox();
            this.chkUnpickable = new System.Windows.Forms.CheckBox();
            this.chkPanickable = new System.Windows.Forms.CheckBox();
            this.chkSitable = new System.Windows.Forms.CheckBox();
            this.chkWalkable = new System.Windows.Forms.CheckBox();
            this.chkReceivesShadows = new System.Windows.Forms.CheckBox();
            this.chkCastsShadows = new System.Windows.Forms.CheckBox();
            this.chkTranslucent = new System.Windows.Forms.CheckBox();
            this.chkFogEnabled = new System.Windows.Forms.CheckBox();
            this.chkDoubleSided = new System.Windows.Forms.CheckBox();
            this.gbNeeds = new System.Windows.Forms.GroupBox();
            this.chkNeedsSeperateObjectColour = new System.Windows.Forms.CheckBox();
            this.chkNeedsLocalCubeMap = new System.Windows.Forms.CheckBox();
            this.chkNeedsVertexColour = new System.Windows.Forms.CheckBox();
            this.chkNeedsLightingSpaceVertexNormal = new System.Windows.Forms.CheckBox();
            this.chkNeedsWorldVertexPos = new System.Windows.Forms.CheckBox();
            this.chkNeedsWorldEyePos = new System.Windows.Forms.CheckBox();
            this.chkNeedsWorldSpaceVertexNormal = new System.Windows.Forms.CheckBox();
            this.chkNeedsWorldLightDir = new System.Windows.Forms.CheckBox();
            this.gbGlobalSettings = new System.Windows.Forms.GroupBox();
            this.lblAlphaCutoff = new System.Windows.Forms.Label();
            this.nudAlphaCutoff = new System.Windows.Forms.NumericUpDown();
            this.nudEmissiveLightZ = new System.Windows.Forms.NumericUpDown();
            this.nudEmissiveLightY = new System.Windows.Forms.NumericUpDown();
            this.lblEmissiveLight = new System.Windows.Forms.Label();
            this.nudEmissiveLightX = new System.Windows.Forms.NumericUpDown();
            this.nudMultiplierZ = new System.Windows.Forms.NumericUpDown();
            this.nudMultiplierY = new System.Windows.Forms.NumericUpDown();
            this.lblMultiplier = new System.Windows.Forms.Label();
            this.nudMultiplierX = new System.Windows.Forms.NumericUpDown();
            this.lblEmissiveFactor = new System.Windows.Forms.Label();
            this.nudEmissiveFactor = new System.Windows.Forms.NumericUpDown();
            this.nudReflectionMultiplierZ = new System.Windows.Forms.NumericUpDown();
            this.nudReflectionMultiplierY = new System.Windows.Forms.NumericUpDown();
            this.lblReflectionMultiplier = new System.Windows.Forms.Label();
            this.nudReflectionMultiplierX = new System.Windows.Forms.NumericUpDown();
            this.lblFresnelR0 = new System.Windows.Forms.Label();
            this.nudFresnel_R0 = new System.Windows.Forms.NumericUpDown();
            this.lblReflectionBlurriness = new System.Windows.Forms.Label();
            this.nudReflectionBluryness = new System.Windows.Forms.NumericUpDown();
            this.pnlButtonBox = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.gbMaterial = new System.Windows.Forms.GroupBox();
            this.flpMaterialOptions = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlDiffuse1 = new System.Windows.Forms.Panel();
            this.btnDiffuse1 = new System.Windows.Forms.Button();
            this.txtDiffuseColour = new System.Windows.Forms.TextBox();
            this.pnlNormal1 = new System.Windows.Forms.Panel();
            this.btnNormal1 = new System.Windows.Forms.Button();
            this.txtNormal1 = new System.Windows.Forms.TextBox();
            this.pnlSpecular1 = new System.Windows.Forms.Panel();
            this.btnSpecular1 = new System.Windows.Forms.Button();
            this.txtSpecular1 = new System.Windows.Forms.TextBox();
            this.pnlDiffuse2 = new System.Windows.Forms.Panel();
            this.btnDiffuse2 = new System.Windows.Forms.Button();
            this.txtDiffuse2 = new System.Windows.Forms.TextBox();
            this.pnlNormal2 = new System.Windows.Forms.Panel();
            this.btnNormal2 = new System.Windows.Forms.Button();
            this.txtNormal2 = new System.Windows.Forms.TextBox();
            this.pnlSpecular2 = new System.Windows.Forms.Panel();
            this.btnSpecular2 = new System.Windows.Forms.Button();
            this.txtSpecular2 = new System.Windows.Forms.TextBox();
            this.pnlDiffuse3 = new System.Windows.Forms.Panel();
            this.btnDiffuse3 = new System.Windows.Forms.Button();
            this.txtDiffuse3 = new System.Windows.Forms.TextBox();
            this.pnlNormal3 = new System.Windows.Forms.Panel();
            this.btnNormal3 = new System.Windows.Forms.Button();
            this.txtNormal3 = new System.Windows.Forms.TextBox();
            this.pnlSpecular3 = new System.Windows.Forms.Panel();
            this.btnSpecular3 = new System.Windows.Forms.Button();
            this.txtSpecular3 = new System.Windows.Forms.TextBox();
            this.pnlBlendMap = new System.Windows.Forms.Panel();
            this.btnBlendMap = new System.Windows.Forms.Button();
            this.txtBlendMap = new System.Windows.Forms.TextBox();
            this.pnlBlendFactor = new System.Windows.Forms.Panel();
            this.lblBlendFactor = new System.Windows.Forms.Label();
            this.nudBlendFactor = new System.Windows.Forms.NumericUpDown();
            this.pnlFalloff = new System.Windows.Forms.Panel();
            this.lblFalloff = new System.Windows.Forms.Label();
            this.nudFalloff = new System.Windows.Forms.NumericUpDown();
            this.pnlBlendUVSlot = new System.Windows.Forms.Panel();
            this.lblBlendUVSlot = new System.Windows.Forms.Label();
            this.nudBlendUVSlot = new System.Windows.Forms.NumericUpDown();
            this.pnlLayer1UVSlot = new System.Windows.Forms.Panel();
            this.lblLayer1UVSlot = new System.Windows.Forms.Label();
            this.nudLayer1UVSlot = new System.Windows.Forms.NumericUpDown();
            this.pnlLayer2UVSlot = new System.Windows.Forms.Panel();
            this.lblLayer2UVSlot = new System.Windows.Forms.Label();
            this.nudLayer2UVSlot = new System.Windows.Forms.NumericUpDown();
            this.pnlSpecColourB = new System.Windows.Forms.Panel();
            this.lblSpecColourB = new System.Windows.Forms.Label();
            this.nudSpecColourB = new System.Windows.Forms.NumericUpDown();
            this.pnlNoSortAlpha = new System.Windows.Forms.Panel();
            this.chkNoSortAlpha = new System.Windows.Forms.CheckBox();
            this.pnlAmbientLightR = new System.Windows.Forms.Panel();
            this.lblAmbientLightR = new System.Windows.Forms.Label();
            this.nudAmbientLightR = new System.Windows.Forms.NumericUpDown();
            this.pnlAmbientLightG = new System.Windows.Forms.Panel();
            this.lblAmbientLightG = new System.Windows.Forms.Label();
            this.nudAmbientLightG = new System.Windows.Forms.NumericUpDown();
            this.pnlAmbientLightB = new System.Windows.Forms.Panel();
            this.lblAmbientLightB = new System.Windows.Forms.Label();
            this.nudAmbientLightB = new System.Windows.Forms.NumericUpDown();
            this.ofdBrowse = new System.Windows.Forms.OpenFileDialog();
            this.gbSubstance = new System.Windows.Forms.GroupBox();
            this.lblSubstance2 = new System.Windows.Forms.Label();
            this.txtSubstance2 = new System.Windows.Forms.TextBox();
            this.lblSubstance = new System.Windows.Forms.Label();
            this.txtSubstance = new System.Windows.Forms.TextBox();
            this.gbGeneral = new System.Windows.Forms.GroupBox();
            this.lblBase = new System.Windows.Forms.Label();
            this.cboBaseMaterial = new System.Windows.Forms.ComboBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtMaterialName = new System.Windows.Forms.TextBox();
            this.gbSamplers = new System.Windows.Forms.GroupBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.lstSamplersAndTexCoordSources = new System.Windows.Forms.ListBox();
            this.gbPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
            this.gbFlags.SuspendLayout();
            this.gbNeeds.SuspendLayout();
            this.gbGlobalSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlphaCutoff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEmissiveLightZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEmissiveLightY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEmissiveLightX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMultiplierZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMultiplierY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMultiplierX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEmissiveFactor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudReflectionMultiplierZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudReflectionMultiplierY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudReflectionMultiplierX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFresnel_R0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudReflectionBluryness)).BeginInit();
            this.pnlButtonBox.SuspendLayout();
            this.gbMaterial.SuspendLayout();
            this.flpMaterialOptions.SuspendLayout();
            this.pnlDiffuse1.SuspendLayout();
            this.pnlNormal1.SuspendLayout();
            this.pnlSpecular1.SuspendLayout();
            this.pnlDiffuse2.SuspendLayout();
            this.pnlNormal2.SuspendLayout();
            this.pnlSpecular2.SuspendLayout();
            this.pnlDiffuse3.SuspendLayout();
            this.pnlNormal3.SuspendLayout();
            this.pnlSpecular3.SuspendLayout();
            this.pnlBlendMap.SuspendLayout();
            this.pnlBlendFactor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlendFactor)).BeginInit();
            this.pnlFalloff.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFalloff)).BeginInit();
            this.pnlBlendUVSlot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlendUVSlot)).BeginInit();
            this.pnlLayer1UVSlot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLayer1UVSlot)).BeginInit();
            this.pnlLayer2UVSlot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLayer2UVSlot)).BeginInit();
            this.pnlSpecColourB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpecColourB)).BeginInit();
            this.pnlNoSortAlpha.SuspendLayout();
            this.pnlAmbientLightR.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmbientLightR)).BeginInit();
            this.pnlAmbientLightG.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmbientLightG)).BeginInit();
            this.pnlAmbientLightB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmbientLightB)).BeginInit();
            this.gbSubstance.SuspendLayout();
            this.gbGeneral.SuspendLayout();
            this.gbSamplers.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbPreview
            // 
            this.gbPreview.Controls.Add(this.pbPreview);
            this.gbPreview.Location = new System.Drawing.Point(12, 12);
            this.gbPreview.Name = "gbPreview";
            this.gbPreview.Size = new System.Drawing.Size(265, 265);
            this.gbPreview.TabIndex = 1;
            this.gbPreview.TabStop = false;
            this.gbPreview.Text = "Preview";
            // 
            // pbPreview
            // 
            this.pbPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPreview.Location = new System.Drawing.Point(12, 19);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(241, 233);
            this.pbPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPreview.TabIndex = 0;
            this.pbPreview.TabStop = false;
            // 
            // gbFlags
            // 
            this.gbFlags.Controls.Add(this.chkUnpickable);
            this.gbFlags.Controls.Add(this.chkPanickable);
            this.gbFlags.Controls.Add(this.chkSitable);
            this.gbFlags.Controls.Add(this.chkWalkable);
            this.gbFlags.Controls.Add(this.chkReceivesShadows);
            this.gbFlags.Controls.Add(this.chkCastsShadows);
            this.gbFlags.Controls.Add(this.chkTranslucent);
            this.gbFlags.Controls.Add(this.chkFogEnabled);
            this.gbFlags.Controls.Add(this.chkDoubleSided);
            this.gbFlags.Location = new System.Drawing.Point(504, 306);
            this.gbFlags.Name = "gbFlags";
            this.gbFlags.Size = new System.Drawing.Size(334, 131);
            this.gbFlags.TabIndex = 2;
            this.gbFlags.TabStop = false;
            this.gbFlags.Text = "Flags";
            // 
            // chkUnpickable
            // 
            this.chkUnpickable.AutoSize = true;
            this.chkUnpickable.Location = new System.Drawing.Point(175, 111);
            this.chkUnpickable.Name = "chkUnpickable";
            this.chkUnpickable.Size = new System.Drawing.Size(80, 17);
            this.chkUnpickable.TabIndex = 13;
            this.chkUnpickable.Text = "Unpickable";
            this.chkUnpickable.UseVisualStyleBackColor = true;
            // 
            // chkPanickable
            // 
            this.chkPanickable.AutoSize = true;
            this.chkPanickable.Location = new System.Drawing.Point(175, 65);
            this.chkPanickable.Name = "chkPanickable";
            this.chkPanickable.Size = new System.Drawing.Size(79, 17);
            this.chkPanickable.TabIndex = 11;
            this.chkPanickable.Text = "Panickable";
            this.chkPanickable.UseVisualStyleBackColor = true;
            // 
            // chkSitable
            // 
            this.chkSitable.AutoSize = true;
            this.chkSitable.Location = new System.Drawing.Point(175, 42);
            this.chkSitable.Name = "chkSitable";
            this.chkSitable.Size = new System.Drawing.Size(58, 17);
            this.chkSitable.TabIndex = 10;
            this.chkSitable.Text = "Sitable";
            this.chkSitable.UseVisualStyleBackColor = true;
            // 
            // chkWalkable
            // 
            this.chkWalkable.AutoSize = true;
            this.chkWalkable.Location = new System.Drawing.Point(175, 19);
            this.chkWalkable.Name = "chkWalkable";
            this.chkWalkable.Size = new System.Drawing.Size(71, 17);
            this.chkWalkable.TabIndex = 9;
            this.chkWalkable.Text = "Walkable";
            this.chkWalkable.UseVisualStyleBackColor = true;
            // 
            // chkReceivesShadows
            // 
            this.chkReceivesShadows.AutoSize = true;
            this.chkReceivesShadows.Location = new System.Drawing.Point(6, 111);
            this.chkReceivesShadows.Name = "chkReceivesShadows";
            this.chkReceivesShadows.Size = new System.Drawing.Size(118, 17);
            this.chkReceivesShadows.TabIndex = 8;
            this.chkReceivesShadows.Text = "Receives Shadows";
            this.chkReceivesShadows.UseVisualStyleBackColor = true;
            // 
            // chkCastsShadows
            // 
            this.chkCastsShadows.AutoSize = true;
            this.chkCastsShadows.Location = new System.Drawing.Point(6, 88);
            this.chkCastsShadows.Name = "chkCastsShadows";
            this.chkCastsShadows.Size = new System.Drawing.Size(99, 17);
            this.chkCastsShadows.TabIndex = 7;
            this.chkCastsShadows.Text = "Casts Shadows";
            this.chkCastsShadows.UseVisualStyleBackColor = true;
            // 
            // chkTranslucent
            // 
            this.chkTranslucent.AutoSize = true;
            this.chkTranslucent.Location = new System.Drawing.Point(6, 65);
            this.chkTranslucent.Name = "chkTranslucent";
            this.chkTranslucent.Size = new System.Drawing.Size(82, 17);
            this.chkTranslucent.TabIndex = 6;
            this.chkTranslucent.Text = "Translucent";
            this.chkTranslucent.UseVisualStyleBackColor = true;
            // 
            // chkFogEnabled
            // 
            this.chkFogEnabled.AutoSize = true;
            this.chkFogEnabled.Location = new System.Drawing.Point(6, 42);
            this.chkFogEnabled.Name = "chkFogEnabled";
            this.chkFogEnabled.Size = new System.Drawing.Size(86, 17);
            this.chkFogEnabled.TabIndex = 5;
            this.chkFogEnabled.Text = "Fog Enabled";
            this.chkFogEnabled.UseVisualStyleBackColor = true;
            // 
            // chkDoubleSided
            // 
            this.chkDoubleSided.AutoSize = true;
            this.chkDoubleSided.Location = new System.Drawing.Point(6, 19);
            this.chkDoubleSided.Name = "chkDoubleSided";
            this.chkDoubleSided.Size = new System.Drawing.Size(90, 17);
            this.chkDoubleSided.TabIndex = 4;
            this.chkDoubleSided.Text = "Double-Sided";
            this.chkDoubleSided.UseVisualStyleBackColor = true;
            // 
            // gbNeeds
            // 
            this.gbNeeds.Controls.Add(this.chkNeedsSeperateObjectColour);
            this.gbNeeds.Controls.Add(this.chkNeedsLocalCubeMap);
            this.gbNeeds.Controls.Add(this.chkNeedsVertexColour);
            this.gbNeeds.Controls.Add(this.chkNeedsLightingSpaceVertexNormal);
            this.gbNeeds.Controls.Add(this.chkNeedsWorldVertexPos);
            this.gbNeeds.Controls.Add(this.chkNeedsWorldEyePos);
            this.gbNeeds.Controls.Add(this.chkNeedsWorldSpaceVertexNormal);
            this.gbNeeds.Controls.Add(this.chkNeedsWorldLightDir);
            this.gbNeeds.Location = new System.Drawing.Point(504, 443);
            this.gbNeeds.Name = "gbNeeds";
            this.gbNeeds.Size = new System.Drawing.Size(334, 132);
            this.gbNeeds.TabIndex = 14;
            this.gbNeeds.TabStop = false;
            this.gbNeeds.Text = "Needs...";
            // 
            // chkNeedsSeperateObjectColour
            // 
            this.chkNeedsSeperateObjectColour.AutoSize = true;
            this.chkNeedsSeperateObjectColour.Location = new System.Drawing.Point(175, 65);
            this.chkNeedsSeperateObjectColour.Name = "chkNeedsSeperateObjectColour";
            this.chkNeedsSeperateObjectColour.Size = new System.Drawing.Size(136, 17);
            this.chkNeedsSeperateObjectColour.TabIndex = 11;
            this.chkNeedsSeperateObjectColour.Text = "Seperate Object Colour";
            this.chkNeedsSeperateObjectColour.UseVisualStyleBackColor = true;
            // 
            // chkNeedsLocalCubeMap
            // 
            this.chkNeedsLocalCubeMap.AutoSize = true;
            this.chkNeedsLocalCubeMap.Location = new System.Drawing.Point(175, 42);
            this.chkNeedsLocalCubeMap.Name = "chkNeedsLocalCubeMap";
            this.chkNeedsLocalCubeMap.Size = new System.Drawing.Size(101, 17);
            this.chkNeedsLocalCubeMap.TabIndex = 10;
            this.chkNeedsLocalCubeMap.Text = "Local CubeMap";
            this.chkNeedsLocalCubeMap.UseVisualStyleBackColor = true;
            // 
            // chkNeedsVertexColour
            // 
            this.chkNeedsVertexColour.AutoSize = true;
            this.chkNeedsVertexColour.Location = new System.Drawing.Point(175, 19);
            this.chkNeedsVertexColour.Name = "chkNeedsVertexColour";
            this.chkNeedsVertexColour.Size = new System.Drawing.Size(89, 17);
            this.chkNeedsVertexColour.TabIndex = 9;
            this.chkNeedsVertexColour.Text = "Vertex Colour";
            this.chkNeedsVertexColour.UseVisualStyleBackColor = true;
            // 
            // chkNeedsLightingSpaceVertexNormal
            // 
            this.chkNeedsLightingSpaceVertexNormal.AutoSize = true;
            this.chkNeedsLightingSpaceVertexNormal.Location = new System.Drawing.Point(6, 111);
            this.chkNeedsLightingSpaceVertexNormal.Name = "chkNeedsLightingSpaceVertexNormal";
            this.chkNeedsLightingSpaceVertexNormal.Size = new System.Drawing.Size(163, 17);
            this.chkNeedsLightingSpaceVertexNormal.TabIndex = 8;
            this.chkNeedsLightingSpaceVertexNormal.Text = "LightingSpace Vertex Normal";
            this.chkNeedsLightingSpaceVertexNormal.UseVisualStyleBackColor = true;
            // 
            // chkNeedsWorldVertexPos
            // 
            this.chkNeedsWorldVertexPos.AutoSize = true;
            this.chkNeedsWorldVertexPos.Location = new System.Drawing.Point(6, 88);
            this.chkNeedsWorldVertexPos.Name = "chkNeedsWorldVertexPos";
            this.chkNeedsWorldVertexPos.Size = new System.Drawing.Size(108, 17);
            this.chkNeedsWorldVertexPos.TabIndex = 7;
            this.chkNeedsWorldVertexPos.Text = "World Vertex Pos";
            this.chkNeedsWorldVertexPos.UseVisualStyleBackColor = true;
            // 
            // chkNeedsWorldEyePos
            // 
            this.chkNeedsWorldEyePos.AutoSize = true;
            this.chkNeedsWorldEyePos.Location = new System.Drawing.Point(6, 65);
            this.chkNeedsWorldEyePos.Name = "chkNeedsWorldEyePos";
            this.chkNeedsWorldEyePos.Size = new System.Drawing.Size(96, 17);
            this.chkNeedsWorldEyePos.TabIndex = 6;
            this.chkNeedsWorldEyePos.Text = "World Eye Pos";
            this.chkNeedsWorldEyePos.UseVisualStyleBackColor = true;
            // 
            // chkNeedsWorldSpaceVertexNormal
            // 
            this.chkNeedsWorldSpaceVertexNormal.AutoSize = true;
            this.chkNeedsWorldSpaceVertexNormal.Location = new System.Drawing.Point(6, 42);
            this.chkNeedsWorldSpaceVertexNormal.Name = "chkNeedsWorldSpaceVertexNormal";
            this.chkNeedsWorldSpaceVertexNormal.Size = new System.Drawing.Size(154, 17);
            this.chkNeedsWorldSpaceVertexNormal.TabIndex = 5;
            this.chkNeedsWorldSpaceVertexNormal.Text = "WorldSpace Vertex Normal";
            this.chkNeedsWorldSpaceVertexNormal.UseVisualStyleBackColor = true;
            // 
            // chkNeedsWorldLightDir
            // 
            this.chkNeedsWorldLightDir.AutoSize = true;
            this.chkNeedsWorldLightDir.Location = new System.Drawing.Point(6, 19);
            this.chkNeedsWorldLightDir.Name = "chkNeedsWorldLightDir";
            this.chkNeedsWorldLightDir.Size = new System.Drawing.Size(96, 17);
            this.chkNeedsWorldLightDir.TabIndex = 4;
            this.chkNeedsWorldLightDir.Text = "World Light Dir";
            this.chkNeedsWorldLightDir.UseVisualStyleBackColor = true;
            // 
            // gbGlobalSettings
            // 
            this.gbGlobalSettings.Controls.Add(this.lblAlphaCutoff);
            this.gbGlobalSettings.Controls.Add(this.nudAlphaCutoff);
            this.gbGlobalSettings.Controls.Add(this.nudEmissiveLightZ);
            this.gbGlobalSettings.Controls.Add(this.nudEmissiveLightY);
            this.gbGlobalSettings.Controls.Add(this.lblEmissiveLight);
            this.gbGlobalSettings.Controls.Add(this.nudEmissiveLightX);
            this.gbGlobalSettings.Controls.Add(this.nudMultiplierZ);
            this.gbGlobalSettings.Controls.Add(this.nudMultiplierY);
            this.gbGlobalSettings.Controls.Add(this.lblMultiplier);
            this.gbGlobalSettings.Controls.Add(this.nudMultiplierX);
            this.gbGlobalSettings.Controls.Add(this.lblEmissiveFactor);
            this.gbGlobalSettings.Controls.Add(this.nudEmissiveFactor);
            this.gbGlobalSettings.Controls.Add(this.nudReflectionMultiplierZ);
            this.gbGlobalSettings.Controls.Add(this.nudReflectionMultiplierY);
            this.gbGlobalSettings.Controls.Add(this.lblReflectionMultiplier);
            this.gbGlobalSettings.Controls.Add(this.nudReflectionMultiplierX);
            this.gbGlobalSettings.Controls.Add(this.lblFresnelR0);
            this.gbGlobalSettings.Controls.Add(this.nudFresnel_R0);
            this.gbGlobalSettings.Controls.Add(this.lblReflectionBlurriness);
            this.gbGlobalSettings.Controls.Add(this.nudReflectionBluryness);
            this.gbGlobalSettings.Location = new System.Drawing.Point(504, 12);
            this.gbGlobalSettings.Name = "gbGlobalSettings";
            this.gbGlobalSettings.Size = new System.Drawing.Size(334, 201);
            this.gbGlobalSettings.TabIndex = 20;
            this.gbGlobalSettings.TabStop = false;
            this.gbGlobalSettings.Text = "Settings";
            // 
            // lblAlphaCutoff
            // 
            this.lblAlphaCutoff.AutoSize = true;
            this.lblAlphaCutoff.Location = new System.Drawing.Point(6, 176);
            this.lblAlphaCutoff.Name = "lblAlphaCutoff";
            this.lblAlphaCutoff.Size = new System.Drawing.Size(68, 13);
            this.lblAlphaCutoff.TabIndex = 39;
            this.lblAlphaCutoff.Text = "Alpha Cut-off";
            // 
            // nudAlphaCutoff
            // 
            this.nudAlphaCutoff.Location = new System.Drawing.Point(131, 174);
            this.nudAlphaCutoff.Name = "nudAlphaCutoff";
            this.nudAlphaCutoff.Size = new System.Drawing.Size(61, 20);
            this.nudAlphaCutoff.TabIndex = 38;
            // 
            // nudEmissiveLightZ
            // 
            this.nudEmissiveLightZ.Location = new System.Drawing.Point(265, 96);
            this.nudEmissiveLightZ.Name = "nudEmissiveLightZ";
            this.nudEmissiveLightZ.Size = new System.Drawing.Size(61, 20);
            this.nudEmissiveLightZ.TabIndex = 37;
            // 
            // nudEmissiveLightY
            // 
            this.nudEmissiveLightY.Location = new System.Drawing.Point(198, 96);
            this.nudEmissiveLightY.Name = "nudEmissiveLightY";
            this.nudEmissiveLightY.Size = new System.Drawing.Size(61, 20);
            this.nudEmissiveLightY.TabIndex = 36;
            // 
            // lblEmissiveLight
            // 
            this.lblEmissiveLight.AutoSize = true;
            this.lblEmissiveLight.Location = new System.Drawing.Point(6, 98);
            this.lblEmissiveLight.Name = "lblEmissiveLight";
            this.lblEmissiveLight.Size = new System.Drawing.Size(74, 13);
            this.lblEmissiveLight.TabIndex = 35;
            this.lblEmissiveLight.Text = "Emissive Light";
            // 
            // nudEmissiveLightX
            // 
            this.nudEmissiveLightX.Location = new System.Drawing.Point(131, 96);
            this.nudEmissiveLightX.Name = "nudEmissiveLightX";
            this.nudEmissiveLightX.Size = new System.Drawing.Size(61, 20);
            this.nudEmissiveLightX.TabIndex = 34;
            // 
            // nudMultiplierZ
            // 
            this.nudMultiplierZ.Location = new System.Drawing.Point(265, 17);
            this.nudMultiplierZ.Name = "nudMultiplierZ";
            this.nudMultiplierZ.Size = new System.Drawing.Size(61, 20);
            this.nudMultiplierZ.TabIndex = 33;
            // 
            // nudMultiplierY
            // 
            this.nudMultiplierY.Location = new System.Drawing.Point(198, 17);
            this.nudMultiplierY.Name = "nudMultiplierY";
            this.nudMultiplierY.Size = new System.Drawing.Size(61, 20);
            this.nudMultiplierY.TabIndex = 32;
            // 
            // lblMultiplier
            // 
            this.lblMultiplier.AutoSize = true;
            this.lblMultiplier.Location = new System.Drawing.Point(6, 19);
            this.lblMultiplier.Name = "lblMultiplier";
            this.lblMultiplier.Size = new System.Drawing.Size(48, 13);
            this.lblMultiplier.TabIndex = 31;
            this.lblMultiplier.Text = "Multiplier";
            // 
            // nudMultiplierX
            // 
            this.nudMultiplierX.Location = new System.Drawing.Point(131, 17);
            this.nudMultiplierX.Name = "nudMultiplierX";
            this.nudMultiplierX.Size = new System.Drawing.Size(61, 20);
            this.nudMultiplierX.TabIndex = 30;
            // 
            // lblEmissiveFactor
            // 
            this.lblEmissiveFactor.AutoSize = true;
            this.lblEmissiveFactor.Location = new System.Drawing.Point(6, 124);
            this.lblEmissiveFactor.Name = "lblEmissiveFactor";
            this.lblEmissiveFactor.Size = new System.Drawing.Size(81, 13);
            this.lblEmissiveFactor.TabIndex = 29;
            this.lblEmissiveFactor.Text = "Emissive Factor";
            // 
            // nudEmissiveFactor
            // 
            this.nudEmissiveFactor.Location = new System.Drawing.Point(131, 122);
            this.nudEmissiveFactor.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudEmissiveFactor.Name = "nudEmissiveFactor";
            this.nudEmissiveFactor.Size = new System.Drawing.Size(61, 20);
            this.nudEmissiveFactor.TabIndex = 28;
            // 
            // nudReflectionMultiplierZ
            // 
            this.nudReflectionMultiplierZ.Location = new System.Drawing.Point(265, 70);
            this.nudReflectionMultiplierZ.Name = "nudReflectionMultiplierZ";
            this.nudReflectionMultiplierZ.Size = new System.Drawing.Size(61, 20);
            this.nudReflectionMultiplierZ.TabIndex = 27;
            // 
            // nudReflectionMultiplierY
            // 
            this.nudReflectionMultiplierY.Location = new System.Drawing.Point(198, 70);
            this.nudReflectionMultiplierY.Name = "nudReflectionMultiplierY";
            this.nudReflectionMultiplierY.Size = new System.Drawing.Size(61, 20);
            this.nudReflectionMultiplierY.TabIndex = 26;
            // 
            // lblReflectionMultiplier
            // 
            this.lblReflectionMultiplier.AutoSize = true;
            this.lblReflectionMultiplier.Location = new System.Drawing.Point(6, 72);
            this.lblReflectionMultiplier.Name = "lblReflectionMultiplier";
            this.lblReflectionMultiplier.Size = new System.Drawing.Size(99, 13);
            this.lblReflectionMultiplier.TabIndex = 25;
            this.lblReflectionMultiplier.Text = "Reflection Multiplier";
            // 
            // nudReflectionMultiplierX
            // 
            this.nudReflectionMultiplierX.Location = new System.Drawing.Point(131, 70);
            this.nudReflectionMultiplierX.Name = "nudReflectionMultiplierX";
            this.nudReflectionMultiplierX.Size = new System.Drawing.Size(61, 20);
            this.nudReflectionMultiplierX.TabIndex = 24;
            // 
            // lblFresnelR0
            // 
            this.lblFresnelR0.AutoSize = true;
            this.lblFresnelR0.Location = new System.Drawing.Point(6, 150);
            this.lblFresnelR0.Name = "lblFresnelR0";
            this.lblFresnelR0.Size = new System.Drawing.Size(58, 13);
            this.lblFresnelR0.TabIndex = 23;
            this.lblFresnelR0.Text = "Fresnel R0";
            // 
            // nudFresnel_R0
            // 
            this.nudFresnel_R0.Location = new System.Drawing.Point(131, 148);
            this.nudFresnel_R0.Name = "nudFresnel_R0";
            this.nudFresnel_R0.Size = new System.Drawing.Size(61, 20);
            this.nudFresnel_R0.TabIndex = 22;
            // 
            // lblReflectionBlurriness
            // 
            this.lblReflectionBlurriness.AutoSize = true;
            this.lblReflectionBlurriness.Location = new System.Drawing.Point(6, 46);
            this.lblReflectionBlurriness.Name = "lblReflectionBlurriness";
            this.lblReflectionBlurriness.Size = new System.Drawing.Size(103, 13);
            this.lblReflectionBlurriness.TabIndex = 21;
            this.lblReflectionBlurriness.Text = "Reflection Bluryness";
            // 
            // nudReflectionBluryness
            // 
            this.nudReflectionBluryness.Location = new System.Drawing.Point(131, 44);
            this.nudReflectionBluryness.Name = "nudReflectionBluryness";
            this.nudReflectionBluryness.Size = new System.Drawing.Size(61, 20);
            this.nudReflectionBluryness.TabIndex = 20;
            // 
            // pnlButtonBox
            // 
            this.pnlButtonBox.Controls.Add(this.btnCancel);
            this.pnlButtonBox.Controls.Add(this.btnApply);
            this.pnlButtonBox.Controls.Add(this.btnOK);
            this.pnlButtonBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtonBox.Location = new System.Drawing.Point(0, 581);
            this.pnlButtonBox.Name = "pnlButtonBox";
            this.pnlButtonBox.Size = new System.Drawing.Size(848, 30);
            this.pnlButtonBox.TabIndex = 36;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(608, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Location = new System.Drawing.Point(689, 4);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 10;
            this.btnApply.Text = "apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(770, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "ok";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // gbMaterial
            // 
            this.gbMaterial.Controls.Add(this.flpMaterialOptions);
            this.gbMaterial.Location = new System.Drawing.Point(283, 12);
            this.gbMaterial.Name = "gbMaterial";
            this.gbMaterial.Size = new System.Drawing.Size(215, 563);
            this.gbMaterial.TabIndex = 37;
            this.gbMaterial.TabStop = false;
            this.gbMaterial.Text = "Base Settings";
            // 
            // flpMaterialOptions
            // 
            this.flpMaterialOptions.AutoSize = true;
            this.flpMaterialOptions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpMaterialOptions.BackColor = System.Drawing.SystemColors.Control;
            this.flpMaterialOptions.Controls.Add(this.pnlDiffuse1);
            this.flpMaterialOptions.Controls.Add(this.pnlNormal1);
            this.flpMaterialOptions.Controls.Add(this.pnlSpecular1);
            this.flpMaterialOptions.Controls.Add(this.pnlDiffuse2);
            this.flpMaterialOptions.Controls.Add(this.pnlNormal2);
            this.flpMaterialOptions.Controls.Add(this.pnlSpecular2);
            this.flpMaterialOptions.Controls.Add(this.pnlDiffuse3);
            this.flpMaterialOptions.Controls.Add(this.pnlNormal3);
            this.flpMaterialOptions.Controls.Add(this.pnlSpecular3);
            this.flpMaterialOptions.Controls.Add(this.pnlBlendMap);
            this.flpMaterialOptions.Controls.Add(this.pnlBlendFactor);
            this.flpMaterialOptions.Controls.Add(this.pnlFalloff);
            this.flpMaterialOptions.Controls.Add(this.pnlBlendUVSlot);
            this.flpMaterialOptions.Controls.Add(this.pnlLayer1UVSlot);
            this.flpMaterialOptions.Controls.Add(this.pnlLayer2UVSlot);
            this.flpMaterialOptions.Controls.Add(this.pnlSpecColourB);
            this.flpMaterialOptions.Controls.Add(this.pnlNoSortAlpha);
            this.flpMaterialOptions.Controls.Add(this.pnlAmbientLightR);
            this.flpMaterialOptions.Controls.Add(this.pnlAmbientLightG);
            this.flpMaterialOptions.Controls.Add(this.pnlAmbientLightB);
            this.flpMaterialOptions.ForeColor = System.Drawing.SystemColors.ControlText;
            this.flpMaterialOptions.Location = new System.Drawing.Point(6, 19);
            this.flpMaterialOptions.MaximumSize = new System.Drawing.Size(205, 9000);
            this.flpMaterialOptions.Name = "flpMaterialOptions";
            this.flpMaterialOptions.Size = new System.Drawing.Size(203, 668);
            this.flpMaterialOptions.TabIndex = 36;
            // 
            // pnlDiffuse1
            // 
            this.pnlDiffuse1.AutoSize = true;
            this.pnlDiffuse1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlDiffuse1.BackColor = System.Drawing.SystemColors.Control;
            this.pnlDiffuse1.Controls.Add(this.btnDiffuse1);
            this.pnlDiffuse1.Controls.Add(this.txtDiffuseColour);
            this.pnlDiffuse1.Location = new System.Drawing.Point(3, 3);
            this.pnlDiffuse1.Name = "pnlDiffuse1";
            this.pnlDiffuse1.Size = new System.Drawing.Size(197, 29);
            this.pnlDiffuse1.TabIndex = 37;
            // 
            // btnDiffuse1
            // 
            this.btnDiffuse1.Location = new System.Drawing.Point(169, 3);
            this.btnDiffuse1.Name = "btnDiffuse1";
            this.btnDiffuse1.Size = new System.Drawing.Size(25, 23);
            this.btnDiffuse1.TabIndex = 3;
            this.btnDiffuse1.Text = "...";
            this.btnDiffuse1.UseVisualStyleBackColor = true;
            this.btnDiffuse1.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtDiffuseColour
            // 
            this.txtDiffuseColour.Location = new System.Drawing.Point(3, 5);
            this.txtDiffuseColour.Name = "txtDiffuseColour";
            this.txtDiffuseColour.ReadOnly = true;
            this.txtDiffuseColour.Size = new System.Drawing.Size(160, 20);
            this.txtDiffuseColour.TabIndex = 2;
            this.txtDiffuseColour.Tag = "side 1 diffuse colour 2";
            this.txtDiffuseColour.Text = "side 1 diffuse colour 2";
            // 
            // pnlNormal1
            // 
            this.pnlNormal1.AutoSize = true;
            this.pnlNormal1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlNormal1.BackColor = System.Drawing.SystemColors.Control;
            this.pnlNormal1.Controls.Add(this.btnNormal1);
            this.pnlNormal1.Controls.Add(this.txtNormal1);
            this.pnlNormal1.Location = new System.Drawing.Point(3, 38);
            this.pnlNormal1.Name = "pnlNormal1";
            this.pnlNormal1.Size = new System.Drawing.Size(197, 29);
            this.pnlNormal1.TabIndex = 38;
            // 
            // btnNormal1
            // 
            this.btnNormal1.Location = new System.Drawing.Point(169, 3);
            this.btnNormal1.Name = "btnNormal1";
            this.btnNormal1.Size = new System.Drawing.Size(25, 23);
            this.btnNormal1.TabIndex = 3;
            this.btnNormal1.Text = "...";
            this.btnNormal1.UseVisualStyleBackColor = true;
            this.btnNormal1.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtNormal1
            // 
            this.txtNormal1.Location = new System.Drawing.Point(3, 5);
            this.txtNormal1.Name = "txtNormal1";
            this.txtNormal1.ReadOnly = true;
            this.txtNormal1.Size = new System.Drawing.Size(160, 20);
            this.txtNormal1.TabIndex = 2;
            this.txtNormal1.Tag = "side 1 normal map 2";
            this.txtNormal1.Text = "side 1 normal map 2";
            // 
            // pnlSpecular1
            // 
            this.pnlSpecular1.AutoSize = true;
            this.pnlSpecular1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlSpecular1.BackColor = System.Drawing.SystemColors.Control;
            this.pnlSpecular1.Controls.Add(this.btnSpecular1);
            this.pnlSpecular1.Controls.Add(this.txtSpecular1);
            this.pnlSpecular1.Location = new System.Drawing.Point(3, 73);
            this.pnlSpecular1.Name = "pnlSpecular1";
            this.pnlSpecular1.Size = new System.Drawing.Size(197, 29);
            this.pnlSpecular1.TabIndex = 39;
            // 
            // btnSpecular1
            // 
            this.btnSpecular1.Location = new System.Drawing.Point(169, 3);
            this.btnSpecular1.Name = "btnSpecular1";
            this.btnSpecular1.Size = new System.Drawing.Size(25, 23);
            this.btnSpecular1.TabIndex = 3;
            this.btnSpecular1.Text = "...";
            this.btnSpecular1.UseVisualStyleBackColor = true;
            this.btnSpecular1.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtSpecular1
            // 
            this.txtSpecular1.Location = new System.Drawing.Point(3, 5);
            this.txtSpecular1.Name = "txtSpecular1";
            this.txtSpecular1.ReadOnly = true;
            this.txtSpecular1.Size = new System.Drawing.Size(160, 20);
            this.txtSpecular1.TabIndex = 2;
            this.txtSpecular1.Tag = "side 1 spec map 2";
            this.txtSpecular1.Text = "side 1 spec map 2";
            // 
            // pnlDiffuse2
            // 
            this.pnlDiffuse2.AutoSize = true;
            this.pnlDiffuse2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlDiffuse2.BackColor = System.Drawing.SystemColors.Control;
            this.pnlDiffuse2.Controls.Add(this.btnDiffuse2);
            this.pnlDiffuse2.Controls.Add(this.txtDiffuse2);
            this.pnlDiffuse2.Location = new System.Drawing.Point(3, 108);
            this.pnlDiffuse2.Name = "pnlDiffuse2";
            this.pnlDiffuse2.Size = new System.Drawing.Size(197, 29);
            this.pnlDiffuse2.TabIndex = 40;
            // 
            // btnDiffuse2
            // 
            this.btnDiffuse2.Location = new System.Drawing.Point(169, 3);
            this.btnDiffuse2.Name = "btnDiffuse2";
            this.btnDiffuse2.Size = new System.Drawing.Size(25, 23);
            this.btnDiffuse2.TabIndex = 3;
            this.btnDiffuse2.Text = "...";
            this.btnDiffuse2.UseVisualStyleBackColor = true;
            this.btnDiffuse2.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtDiffuse2
            // 
            this.txtDiffuse2.Location = new System.Drawing.Point(3, 5);
            this.txtDiffuse2.Name = "txtDiffuse2";
            this.txtDiffuse2.ReadOnly = true;
            this.txtDiffuse2.Size = new System.Drawing.Size(160, 20);
            this.txtDiffuse2.TabIndex = 2;
            this.txtDiffuse2.Tag = "side 1 diffuse colour 1";
            this.txtDiffuse2.Text = "side 1 diffuse colour 1";
            // 
            // pnlNormal2
            // 
            this.pnlNormal2.AutoSize = true;
            this.pnlNormal2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlNormal2.BackColor = System.Drawing.SystemColors.Control;
            this.pnlNormal2.Controls.Add(this.btnNormal2);
            this.pnlNormal2.Controls.Add(this.txtNormal2);
            this.pnlNormal2.Location = new System.Drawing.Point(3, 143);
            this.pnlNormal2.Name = "pnlNormal2";
            this.pnlNormal2.Size = new System.Drawing.Size(197, 29);
            this.pnlNormal2.TabIndex = 41;
            // 
            // btnNormal2
            // 
            this.btnNormal2.Location = new System.Drawing.Point(169, 3);
            this.btnNormal2.Name = "btnNormal2";
            this.btnNormal2.Size = new System.Drawing.Size(25, 23);
            this.btnNormal2.TabIndex = 3;
            this.btnNormal2.Text = "...";
            this.btnNormal2.UseVisualStyleBackColor = true;
            this.btnNormal2.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtNormal2
            // 
            this.txtNormal2.Location = new System.Drawing.Point(3, 5);
            this.txtNormal2.Name = "txtNormal2";
            this.txtNormal2.ReadOnly = true;
            this.txtNormal2.Size = new System.Drawing.Size(160, 20);
            this.txtNormal2.TabIndex = 2;
            this.txtNormal2.Tag = "side 1 normal map 1";
            this.txtNormal2.Text = "side 1 normal map 1";
            // 
            // pnlSpecular2
            // 
            this.pnlSpecular2.AutoSize = true;
            this.pnlSpecular2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlSpecular2.BackColor = System.Drawing.SystemColors.Control;
            this.pnlSpecular2.Controls.Add(this.btnSpecular2);
            this.pnlSpecular2.Controls.Add(this.txtSpecular2);
            this.pnlSpecular2.Location = new System.Drawing.Point(3, 178);
            this.pnlSpecular2.Name = "pnlSpecular2";
            this.pnlSpecular2.Size = new System.Drawing.Size(197, 29);
            this.pnlSpecular2.TabIndex = 42;
            // 
            // btnSpecular2
            // 
            this.btnSpecular2.Location = new System.Drawing.Point(169, 3);
            this.btnSpecular2.Name = "btnSpecular2";
            this.btnSpecular2.Size = new System.Drawing.Size(25, 23);
            this.btnSpecular2.TabIndex = 3;
            this.btnSpecular2.Text = "...";
            this.btnSpecular2.UseVisualStyleBackColor = true;
            this.btnSpecular2.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtSpecular2
            // 
            this.txtSpecular2.Location = new System.Drawing.Point(3, 5);
            this.txtSpecular2.Name = "txtSpecular2";
            this.txtSpecular2.ReadOnly = true;
            this.txtSpecular2.Size = new System.Drawing.Size(160, 20);
            this.txtSpecular2.TabIndex = 2;
            this.txtSpecular2.Tag = "side 1 spec map 1";
            this.txtSpecular2.Text = "side 1 spec map 1";
            // 
            // pnlDiffuse3
            // 
            this.pnlDiffuse3.AutoSize = true;
            this.pnlDiffuse3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlDiffuse3.BackColor = System.Drawing.SystemColors.Control;
            this.pnlDiffuse3.Controls.Add(this.btnDiffuse3);
            this.pnlDiffuse3.Controls.Add(this.txtDiffuse3);
            this.pnlDiffuse3.Location = new System.Drawing.Point(3, 213);
            this.pnlDiffuse3.Name = "pnlDiffuse3";
            this.pnlDiffuse3.Size = new System.Drawing.Size(197, 29);
            this.pnlDiffuse3.TabIndex = 43;
            // 
            // btnDiffuse3
            // 
            this.btnDiffuse3.Location = new System.Drawing.Point(169, 3);
            this.btnDiffuse3.Name = "btnDiffuse3";
            this.btnDiffuse3.Size = new System.Drawing.Size(25, 23);
            this.btnDiffuse3.TabIndex = 3;
            this.btnDiffuse3.Text = "...";
            this.btnDiffuse3.UseVisualStyleBackColor = true;
            this.btnDiffuse3.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtDiffuse3
            // 
            this.txtDiffuse3.Location = new System.Drawing.Point(3, 5);
            this.txtDiffuse3.Name = "txtDiffuse3";
            this.txtDiffuse3.ReadOnly = true;
            this.txtDiffuse3.Size = new System.Drawing.Size(160, 20);
            this.txtDiffuse3.TabIndex = 2;
            this.txtDiffuse3.Tag = "side 2 diffuse colour";
            this.txtDiffuse3.Text = "side 2 diffuse colour";
            // 
            // pnlNormal3
            // 
            this.pnlNormal3.AutoSize = true;
            this.pnlNormal3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlNormal3.BackColor = System.Drawing.SystemColors.Control;
            this.pnlNormal3.Controls.Add(this.btnNormal3);
            this.pnlNormal3.Controls.Add(this.txtNormal3);
            this.pnlNormal3.Location = new System.Drawing.Point(3, 248);
            this.pnlNormal3.Name = "pnlNormal3";
            this.pnlNormal3.Size = new System.Drawing.Size(197, 29);
            this.pnlNormal3.TabIndex = 44;
            // 
            // btnNormal3
            // 
            this.btnNormal3.Location = new System.Drawing.Point(169, 3);
            this.btnNormal3.Name = "btnNormal3";
            this.btnNormal3.Size = new System.Drawing.Size(25, 23);
            this.btnNormal3.TabIndex = 3;
            this.btnNormal3.Text = "...";
            this.btnNormal3.UseVisualStyleBackColor = true;
            this.btnNormal3.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtNormal3
            // 
            this.txtNormal3.Location = new System.Drawing.Point(3, 5);
            this.txtNormal3.Name = "txtNormal3";
            this.txtNormal3.ReadOnly = true;
            this.txtNormal3.Size = new System.Drawing.Size(160, 20);
            this.txtNormal3.TabIndex = 2;
            this.txtNormal3.Tag = "side 2 normal map";
            this.txtNormal3.Text = "side 2 normal map";
            // 
            // pnlSpecular3
            // 
            this.pnlSpecular3.AutoSize = true;
            this.pnlSpecular3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlSpecular3.BackColor = System.Drawing.SystemColors.Control;
            this.pnlSpecular3.Controls.Add(this.btnSpecular3);
            this.pnlSpecular3.Controls.Add(this.txtSpecular3);
            this.pnlSpecular3.Location = new System.Drawing.Point(3, 283);
            this.pnlSpecular3.Name = "pnlSpecular3";
            this.pnlSpecular3.Size = new System.Drawing.Size(197, 29);
            this.pnlSpecular3.TabIndex = 45;
            // 
            // btnSpecular3
            // 
            this.btnSpecular3.Location = new System.Drawing.Point(169, 3);
            this.btnSpecular3.Name = "btnSpecular3";
            this.btnSpecular3.Size = new System.Drawing.Size(25, 23);
            this.btnSpecular3.TabIndex = 3;
            this.btnSpecular3.Text = "...";
            this.btnSpecular3.UseVisualStyleBackColor = true;
            this.btnSpecular3.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtSpecular3
            // 
            this.txtSpecular3.Location = new System.Drawing.Point(3, 5);
            this.txtSpecular3.Name = "txtSpecular3";
            this.txtSpecular3.ReadOnly = true;
            this.txtSpecular3.Size = new System.Drawing.Size(160, 20);
            this.txtSpecular3.TabIndex = 2;
            this.txtSpecular3.Tag = "side 2 spec map";
            this.txtSpecular3.Text = "side 2 spec map";
            // 
            // pnlBlendMap
            // 
            this.pnlBlendMap.AutoSize = true;
            this.pnlBlendMap.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlBlendMap.BackColor = System.Drawing.SystemColors.Control;
            this.pnlBlendMap.Controls.Add(this.btnBlendMap);
            this.pnlBlendMap.Controls.Add(this.txtBlendMap);
            this.pnlBlendMap.Location = new System.Drawing.Point(3, 318);
            this.pnlBlendMap.Name = "pnlBlendMap";
            this.pnlBlendMap.Size = new System.Drawing.Size(197, 29);
            this.pnlBlendMap.TabIndex = 46;
            // 
            // btnBlendMap
            // 
            this.btnBlendMap.Location = new System.Drawing.Point(169, 3);
            this.btnBlendMap.Name = "btnBlendMap";
            this.btnBlendMap.Size = new System.Drawing.Size(25, 23);
            this.btnBlendMap.TabIndex = 3;
            this.btnBlendMap.Text = "...";
            this.btnBlendMap.UseVisualStyleBackColor = true;
            this.btnBlendMap.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtBlendMap
            // 
            this.txtBlendMap.Location = new System.Drawing.Point(3, 5);
            this.txtBlendMap.Name = "txtBlendMap";
            this.txtBlendMap.ReadOnly = true;
            this.txtBlendMap.Size = new System.Drawing.Size(160, 20);
            this.txtBlendMap.TabIndex = 2;
            this.txtBlendMap.Tag = "blend map";
            this.txtBlendMap.Text = "blend map";
            // 
            // pnlBlendFactor
            // 
            this.pnlBlendFactor.AutoSize = true;
            this.pnlBlendFactor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlBlendFactor.BackColor = System.Drawing.SystemColors.Control;
            this.pnlBlendFactor.Controls.Add(this.lblBlendFactor);
            this.pnlBlendFactor.Controls.Add(this.nudBlendFactor);
            this.pnlBlendFactor.Location = new System.Drawing.Point(3, 353);
            this.pnlBlendFactor.Name = "pnlBlendFactor";
            this.pnlBlendFactor.Size = new System.Drawing.Size(197, 26);
            this.pnlBlendFactor.TabIndex = 40;
            // 
            // lblBlendFactor
            // 
            this.lblBlendFactor.AutoSize = true;
            this.lblBlendFactor.Location = new System.Drawing.Point(3, 7);
            this.lblBlendFactor.Name = "lblBlendFactor";
            this.lblBlendFactor.Size = new System.Drawing.Size(67, 13);
            this.lblBlendFactor.TabIndex = 27;
            this.lblBlendFactor.Text = "Blend Factor";
            // 
            // nudBlendFactor
            // 
            this.nudBlendFactor.Location = new System.Drawing.Point(133, 3);
            this.nudBlendFactor.Name = "nudBlendFactor";
            this.nudBlendFactor.Size = new System.Drawing.Size(61, 20);
            this.nudBlendFactor.TabIndex = 26;
            // 
            // pnlFalloff
            // 
            this.pnlFalloff.AutoSize = true;
            this.pnlFalloff.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlFalloff.BackColor = System.Drawing.SystemColors.Control;
            this.pnlFalloff.Controls.Add(this.lblFalloff);
            this.pnlFalloff.Controls.Add(this.nudFalloff);
            this.pnlFalloff.Location = new System.Drawing.Point(3, 385);
            this.pnlFalloff.Name = "pnlFalloff";
            this.pnlFalloff.Size = new System.Drawing.Size(197, 26);
            this.pnlFalloff.TabIndex = 49;
            // 
            // lblFalloff
            // 
            this.lblFalloff.AutoSize = true;
            this.lblFalloff.Location = new System.Drawing.Point(3, 7);
            this.lblFalloff.Name = "lblFalloff";
            this.lblFalloff.Size = new System.Drawing.Size(35, 13);
            this.lblFalloff.TabIndex = 27;
            this.lblFalloff.Text = "Falloff";
            // 
            // nudFalloff
            // 
            this.nudFalloff.Location = new System.Drawing.Point(133, 3);
            this.nudFalloff.Name = "nudFalloff";
            this.nudFalloff.Size = new System.Drawing.Size(61, 20);
            this.nudFalloff.TabIndex = 26;
            // 
            // pnlBlendUVSlot
            // 
            this.pnlBlendUVSlot.AutoSize = true;
            this.pnlBlendUVSlot.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlBlendUVSlot.BackColor = System.Drawing.SystemColors.Control;
            this.pnlBlendUVSlot.Controls.Add(this.lblBlendUVSlot);
            this.pnlBlendUVSlot.Controls.Add(this.nudBlendUVSlot);
            this.pnlBlendUVSlot.Location = new System.Drawing.Point(3, 417);
            this.pnlBlendUVSlot.Name = "pnlBlendUVSlot";
            this.pnlBlendUVSlot.Size = new System.Drawing.Size(197, 26);
            this.pnlBlendUVSlot.TabIndex = 50;
            // 
            // lblBlendUVSlot
            // 
            this.lblBlendUVSlot.AutoSize = true;
            this.lblBlendUVSlot.Location = new System.Drawing.Point(3, 7);
            this.lblBlendUVSlot.Name = "lblBlendUVSlot";
            this.lblBlendUVSlot.Size = new System.Drawing.Size(73, 13);
            this.lblBlendUVSlot.TabIndex = 27;
            this.lblBlendUVSlot.Text = "Blend UV Slot";
            // 
            // nudBlendUVSlot
            // 
            this.nudBlendUVSlot.Location = new System.Drawing.Point(133, 3);
            this.nudBlendUVSlot.Name = "nudBlendUVSlot";
            this.nudBlendUVSlot.Size = new System.Drawing.Size(61, 20);
            this.nudBlendUVSlot.TabIndex = 26;
            // 
            // pnlLayer1UVSlot
            // 
            this.pnlLayer1UVSlot.AutoSize = true;
            this.pnlLayer1UVSlot.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlLayer1UVSlot.BackColor = System.Drawing.SystemColors.Control;
            this.pnlLayer1UVSlot.Controls.Add(this.lblLayer1UVSlot);
            this.pnlLayer1UVSlot.Controls.Add(this.nudLayer1UVSlot);
            this.pnlLayer1UVSlot.Location = new System.Drawing.Point(3, 449);
            this.pnlLayer1UVSlot.Name = "pnlLayer1UVSlot";
            this.pnlLayer1UVSlot.Size = new System.Drawing.Size(197, 26);
            this.pnlLayer1UVSlot.TabIndex = 51;
            // 
            // lblLayer1UVSlot
            // 
            this.lblLayer1UVSlot.AutoSize = true;
            this.lblLayer1UVSlot.Location = new System.Drawing.Point(3, 7);
            this.lblLayer1UVSlot.Name = "lblLayer1UVSlot";
            this.lblLayer1UVSlot.Size = new System.Drawing.Size(81, 13);
            this.lblLayer1UVSlot.TabIndex = 27;
            this.lblLayer1UVSlot.Text = "Layer 1 UV Slot";
            // 
            // nudLayer1UVSlot
            // 
            this.nudLayer1UVSlot.Location = new System.Drawing.Point(133, 3);
            this.nudLayer1UVSlot.Name = "nudLayer1UVSlot";
            this.nudLayer1UVSlot.Size = new System.Drawing.Size(61, 20);
            this.nudLayer1UVSlot.TabIndex = 26;
            // 
            // pnlLayer2UVSlot
            // 
            this.pnlLayer2UVSlot.AutoSize = true;
            this.pnlLayer2UVSlot.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlLayer2UVSlot.BackColor = System.Drawing.SystemColors.Control;
            this.pnlLayer2UVSlot.Controls.Add(this.lblLayer2UVSlot);
            this.pnlLayer2UVSlot.Controls.Add(this.nudLayer2UVSlot);
            this.pnlLayer2UVSlot.Location = new System.Drawing.Point(3, 481);
            this.pnlLayer2UVSlot.Name = "pnlLayer2UVSlot";
            this.pnlLayer2UVSlot.Size = new System.Drawing.Size(197, 26);
            this.pnlLayer2UVSlot.TabIndex = 52;
            // 
            // lblLayer2UVSlot
            // 
            this.lblLayer2UVSlot.AutoSize = true;
            this.lblLayer2UVSlot.Location = new System.Drawing.Point(3, 7);
            this.lblLayer2UVSlot.Name = "lblLayer2UVSlot";
            this.lblLayer2UVSlot.Size = new System.Drawing.Size(81, 13);
            this.lblLayer2UVSlot.TabIndex = 27;
            this.lblLayer2UVSlot.Text = "Layer 2 UV Slot";
            // 
            // nudLayer2UVSlot
            // 
            this.nudLayer2UVSlot.Location = new System.Drawing.Point(133, 3);
            this.nudLayer2UVSlot.Name = "nudLayer2UVSlot";
            this.nudLayer2UVSlot.Size = new System.Drawing.Size(61, 20);
            this.nudLayer2UVSlot.TabIndex = 26;
            // 
            // pnlSpecColourB
            // 
            this.pnlSpecColourB.AutoSize = true;
            this.pnlSpecColourB.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlSpecColourB.BackColor = System.Drawing.SystemColors.Control;
            this.pnlSpecColourB.Controls.Add(this.lblSpecColourB);
            this.pnlSpecColourB.Controls.Add(this.nudSpecColourB);
            this.pnlSpecColourB.Location = new System.Drawing.Point(3, 513);
            this.pnlSpecColourB.Name = "pnlSpecColourB";
            this.pnlSpecColourB.Size = new System.Drawing.Size(197, 26);
            this.pnlSpecColourB.TabIndex = 53;
            // 
            // lblSpecColourB
            // 
            this.lblSpecColourB.AutoSize = true;
            this.lblSpecColourB.Location = new System.Drawing.Point(3, 7);
            this.lblSpecColourB.Name = "lblSpecColourB";
            this.lblSpecColourB.Size = new System.Drawing.Size(92, 13);
            this.lblSpecColourB.TabIndex = 27;
            this.lblSpecColourB.Text = "Specular Colour B";
            // 
            // nudSpecColourB
            // 
            this.nudSpecColourB.Location = new System.Drawing.Point(133, 3);
            this.nudSpecColourB.Name = "nudSpecColourB";
            this.nudSpecColourB.Size = new System.Drawing.Size(61, 20);
            this.nudSpecColourB.TabIndex = 26;
            // 
            // pnlNoSortAlpha
            // 
            this.pnlNoSortAlpha.AutoSize = true;
            this.pnlNoSortAlpha.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlNoSortAlpha.BackColor = System.Drawing.SystemColors.Control;
            this.pnlNoSortAlpha.Controls.Add(this.chkNoSortAlpha);
            this.pnlNoSortAlpha.Location = new System.Drawing.Point(3, 545);
            this.pnlNoSortAlpha.Name = "pnlNoSortAlpha";
            this.pnlNoSortAlpha.Size = new System.Drawing.Size(148, 24);
            this.pnlNoSortAlpha.TabIndex = 57;
            // 
            // chkNoSortAlpha
            // 
            this.chkNoSortAlpha.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkNoSortAlpha.Location = new System.Drawing.Point(6, 4);
            this.chkNoSortAlpha.Name = "chkNoSortAlpha";
            this.chkNoSortAlpha.Size = new System.Drawing.Size(139, 17);
            this.chkNoSortAlpha.TabIndex = 28;
            this.chkNoSortAlpha.Text = "No Sort Alpha";
            this.chkNoSortAlpha.UseVisualStyleBackColor = true;
            // 
            // pnlAmbientLightR
            // 
            this.pnlAmbientLightR.AutoSize = true;
            this.pnlAmbientLightR.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlAmbientLightR.BackColor = System.Drawing.SystemColors.Control;
            this.pnlAmbientLightR.Controls.Add(this.lblAmbientLightR);
            this.pnlAmbientLightR.Controls.Add(this.nudAmbientLightR);
            this.pnlAmbientLightR.Location = new System.Drawing.Point(3, 575);
            this.pnlAmbientLightR.Name = "pnlAmbientLightR";
            this.pnlAmbientLightR.Size = new System.Drawing.Size(197, 26);
            this.pnlAmbientLightR.TabIndex = 54;
            // 
            // lblAmbientLightR
            // 
            this.lblAmbientLightR.AutoSize = true;
            this.lblAmbientLightR.Location = new System.Drawing.Point(3, 7);
            this.lblAmbientLightR.Name = "lblAmbientLightR";
            this.lblAmbientLightR.Size = new System.Drawing.Size(82, 13);
            this.lblAmbientLightR.TabIndex = 27;
            this.lblAmbientLightR.Text = "Ambient Light R";
            // 
            // nudAmbientLightR
            // 
            this.nudAmbientLightR.Location = new System.Drawing.Point(133, 3);
            this.nudAmbientLightR.Name = "nudAmbientLightR";
            this.nudAmbientLightR.Size = new System.Drawing.Size(61, 20);
            this.nudAmbientLightR.TabIndex = 26;
            // 
            // pnlAmbientLightG
            // 
            this.pnlAmbientLightG.AutoSize = true;
            this.pnlAmbientLightG.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlAmbientLightG.BackColor = System.Drawing.SystemColors.Control;
            this.pnlAmbientLightG.Controls.Add(this.lblAmbientLightG);
            this.pnlAmbientLightG.Controls.Add(this.nudAmbientLightG);
            this.pnlAmbientLightG.Location = new System.Drawing.Point(3, 607);
            this.pnlAmbientLightG.Name = "pnlAmbientLightG";
            this.pnlAmbientLightG.Size = new System.Drawing.Size(197, 26);
            this.pnlAmbientLightG.TabIndex = 55;
            // 
            // lblAmbientLightG
            // 
            this.lblAmbientLightG.AutoSize = true;
            this.lblAmbientLightG.Location = new System.Drawing.Point(3, 7);
            this.lblAmbientLightG.Name = "lblAmbientLightG";
            this.lblAmbientLightG.Size = new System.Drawing.Size(82, 13);
            this.lblAmbientLightG.TabIndex = 27;
            this.lblAmbientLightG.Text = "Ambient Light G";
            // 
            // nudAmbientLightG
            // 
            this.nudAmbientLightG.Location = new System.Drawing.Point(133, 3);
            this.nudAmbientLightG.Name = "nudAmbientLightG";
            this.nudAmbientLightG.Size = new System.Drawing.Size(61, 20);
            this.nudAmbientLightG.TabIndex = 26;
            // 
            // pnlAmbientLightB
            // 
            this.pnlAmbientLightB.AutoSize = true;
            this.pnlAmbientLightB.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlAmbientLightB.BackColor = System.Drawing.SystemColors.Control;
            this.pnlAmbientLightB.Controls.Add(this.lblAmbientLightB);
            this.pnlAmbientLightB.Controls.Add(this.nudAmbientLightB);
            this.pnlAmbientLightB.Location = new System.Drawing.Point(3, 639);
            this.pnlAmbientLightB.Name = "pnlAmbientLightB";
            this.pnlAmbientLightB.Size = new System.Drawing.Size(197, 26);
            this.pnlAmbientLightB.TabIndex = 56;
            // 
            // lblAmbientLightB
            // 
            this.lblAmbientLightB.AutoSize = true;
            this.lblAmbientLightB.Location = new System.Drawing.Point(3, 7);
            this.lblAmbientLightB.Name = "lblAmbientLightB";
            this.lblAmbientLightB.Size = new System.Drawing.Size(81, 13);
            this.lblAmbientLightB.TabIndex = 27;
            this.lblAmbientLightB.Text = "Ambient Light B";
            // 
            // nudAmbientLightB
            // 
            this.nudAmbientLightB.Location = new System.Drawing.Point(133, 3);
            this.nudAmbientLightB.Name = "nudAmbientLightB";
            this.nudAmbientLightB.Size = new System.Drawing.Size(61, 20);
            this.nudAmbientLightB.TabIndex = 26;
            // 
            // gbSubstance
            // 
            this.gbSubstance.Controls.Add(this.lblSubstance2);
            this.gbSubstance.Controls.Add(this.txtSubstance2);
            this.gbSubstance.Controls.Add(this.lblSubstance);
            this.gbSubstance.Controls.Add(this.txtSubstance);
            this.gbSubstance.Location = new System.Drawing.Point(504, 219);
            this.gbSubstance.Name = "gbSubstance";
            this.gbSubstance.Size = new System.Drawing.Size(334, 81);
            this.gbSubstance.TabIndex = 48;
            this.gbSubstance.TabStop = false;
            this.gbSubstance.Text = "Substance";
            // 
            // lblSubstance2
            // 
            this.lblSubstance2.AutoSize = true;
            this.lblSubstance2.Enabled = false;
            this.lblSubstance2.Location = new System.Drawing.Point(8, 55);
            this.lblSubstance2.Name = "lblSubstance2";
            this.lblSubstance2.Size = new System.Drawing.Size(67, 13);
            this.lblSubstance2.TabIndex = 51;
            this.lblSubstance2.Text = "Substance 2";
            // 
            // txtSubstance2
            // 
            this.txtSubstance2.Enabled = false;
            this.txtSubstance2.Location = new System.Drawing.Point(133, 52);
            this.txtSubstance2.Name = "txtSubstance2";
            this.txtSubstance2.Size = new System.Drawing.Size(195, 20);
            this.txtSubstance2.TabIndex = 50;
            // 
            // lblSubstance
            // 
            this.lblSubstance.AutoSize = true;
            this.lblSubstance.Location = new System.Drawing.Point(8, 29);
            this.lblSubstance.Name = "lblSubstance";
            this.lblSubstance.Size = new System.Drawing.Size(58, 13);
            this.lblSubstance.TabIndex = 49;
            this.lblSubstance.Text = "Substance";
            // 
            // txtSubstance
            // 
            this.txtSubstance.Location = new System.Drawing.Point(133, 26);
            this.txtSubstance.Name = "txtSubstance";
            this.txtSubstance.Size = new System.Drawing.Size(195, 20);
            this.txtSubstance.TabIndex = 48;
            // 
            // gbGeneral
            // 
            this.gbGeneral.Controls.Add(this.lblBase);
            this.gbGeneral.Controls.Add(this.cboBaseMaterial);
            this.gbGeneral.Controls.Add(this.lblName);
            this.gbGeneral.Controls.Add(this.txtMaterialName);
            this.gbGeneral.Location = new System.Drawing.Point(12, 283);
            this.gbGeneral.Name = "gbGeneral";
            this.gbGeneral.Size = new System.Drawing.Size(265, 74);
            this.gbGeneral.TabIndex = 49;
            this.gbGeneral.TabStop = false;
            this.gbGeneral.Text = "General";
            // 
            // lblBase
            // 
            this.lblBase.AutoSize = true;
            this.lblBase.Location = new System.Drawing.Point(6, 48);
            this.lblBase.Name = "lblBase";
            this.lblBase.Size = new System.Drawing.Size(31, 13);
            this.lblBase.TabIndex = 53;
            this.lblBase.Text = "Base";
            // 
            // cboBaseMaterial
            // 
            this.cboBaseMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBaseMaterial.FormattingEnabled = true;
            this.cboBaseMaterial.Items.AddRange(new object[] {
            "car_shader_base",
            "car_shader_base2",
            "car_shader_double_sided_base",
            "car_shader_no_normals_base",
            "decal_base",
            "effects_fluid",
            "fog",
            "glass_base",
            "glow_in_the_dark_paint",
            "glow_simple_norm_spec_env_base",
            "glow_simple_norm_spec_env_base_A",
            "ped_base",
            "repulse_base",
            "simple_1bit_base",
            "simple_additive_base",
            "simple_base",
            "simple_norm_base",
            "simple_norm_detail_base",
            "simple_norm_spec_1bit_env_base",
            "simple_norm_spec_env_base",
            "simple_norm_spec_env_base_A",
            "simple_norm_spec_env_blend_base",
            "simple_norm_spec_env_unlit_base",
            "simple_spec_base",
            "skybox_base",
            "test_blood_particle_base",
            "unlit_1bit_base",
            "unlit_base",
            "vertex_norm_spec_env_base",
            "water_base"});
            this.cboBaseMaterial.Location = new System.Drawing.Point(64, 45);
            this.cboBaseMaterial.Name = "cboBaseMaterial";
            this.cboBaseMaterial.Size = new System.Drawing.Size(195, 21);
            this.cboBaseMaterial.TabIndex = 52;
            this.cboBaseMaterial.SelectedIndexChanged += new System.EventHandler(this.cboBaseMaterial_SelectedIndexChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(6, 22);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 51;
            this.lblName.Text = "Name";
            // 
            // txtMaterialName
            // 
            this.txtMaterialName.Location = new System.Drawing.Point(64, 19);
            this.txtMaterialName.Name = "txtMaterialName";
            this.txtMaterialName.Size = new System.Drawing.Size(195, 20);
            this.txtMaterialName.TabIndex = 50;
            // 
            // gbSamplers
            // 
            this.gbSamplers.Controls.Add(this.lblNote);
            this.gbSamplers.Controls.Add(this.lstSamplersAndTexCoordSources);
            this.gbSamplers.Location = new System.Drawing.Point(12, 363);
            this.gbSamplers.Name = "gbSamplers";
            this.gbSamplers.Size = new System.Drawing.Size(265, 212);
            this.gbSamplers.TabIndex = 50;
            this.gbSamplers.TabStop = false;
            this.gbSamplers.Text = "Samplers and TexCoordSources";
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Location = new System.Drawing.Point(61, 191);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(146, 13);
            this.lblNote.TabIndex = 1;
            this.lblNote.Text = "click an entry in the list to edit";
            // 
            // lstSamplersAndTexCoordSources
            // 
            this.lstSamplersAndTexCoordSources.FormattingEnabled = true;
            this.lstSamplersAndTexCoordSources.IntegralHeight = false;
            this.lstSamplersAndTexCoordSources.Location = new System.Drawing.Point(6, 19);
            this.lstSamplersAndTexCoordSources.Name = "lstSamplersAndTexCoordSources";
            this.lstSamplersAndTexCoordSources.Size = new System.Drawing.Size(253, 166);
            this.lstSamplersAndTexCoordSources.TabIndex = 0;
            // 
            // frmReincarnationMaterialEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 611);
            this.Controls.Add(this.gbSamplers);
            this.Controls.Add(this.gbGeneral);
            this.Controls.Add(this.gbSubstance);
            this.Controls.Add(this.gbMaterial);
            this.Controls.Add(this.pnlButtonBox);
            this.Controls.Add(this.gbGlobalSettings);
            this.Controls.Add(this.gbNeeds);
            this.Controls.Add(this.gbFlags);
            this.Controls.Add(this.gbPreview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::Flummery.Properties.Resources.icon;
            this.MaximizeBox = false;
            this.Name = "frmReincarnationMaterialEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Carmageddon: Reincarnation Material Editor";
            this.gbPreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
            this.gbFlags.ResumeLayout(false);
            this.gbFlags.PerformLayout();
            this.gbNeeds.ResumeLayout(false);
            this.gbNeeds.PerformLayout();
            this.gbGlobalSettings.ResumeLayout(false);
            this.gbGlobalSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlphaCutoff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEmissiveLightZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEmissiveLightY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEmissiveLightX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMultiplierZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMultiplierY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMultiplierX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEmissiveFactor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudReflectionMultiplierZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudReflectionMultiplierY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudReflectionMultiplierX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFresnel_R0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudReflectionBluryness)).EndInit();
            this.pnlButtonBox.ResumeLayout(false);
            this.gbMaterial.ResumeLayout(false);
            this.gbMaterial.PerformLayout();
            this.flpMaterialOptions.ResumeLayout(false);
            this.flpMaterialOptions.PerformLayout();
            this.pnlDiffuse1.ResumeLayout(false);
            this.pnlDiffuse1.PerformLayout();
            this.pnlNormal1.ResumeLayout(false);
            this.pnlNormal1.PerformLayout();
            this.pnlSpecular1.ResumeLayout(false);
            this.pnlSpecular1.PerformLayout();
            this.pnlDiffuse2.ResumeLayout(false);
            this.pnlDiffuse2.PerformLayout();
            this.pnlNormal2.ResumeLayout(false);
            this.pnlNormal2.PerformLayout();
            this.pnlSpecular2.ResumeLayout(false);
            this.pnlSpecular2.PerformLayout();
            this.pnlDiffuse3.ResumeLayout(false);
            this.pnlDiffuse3.PerformLayout();
            this.pnlNormal3.ResumeLayout(false);
            this.pnlNormal3.PerformLayout();
            this.pnlSpecular3.ResumeLayout(false);
            this.pnlSpecular3.PerformLayout();
            this.pnlBlendMap.ResumeLayout(false);
            this.pnlBlendMap.PerformLayout();
            this.pnlBlendFactor.ResumeLayout(false);
            this.pnlBlendFactor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlendFactor)).EndInit();
            this.pnlFalloff.ResumeLayout(false);
            this.pnlFalloff.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFalloff)).EndInit();
            this.pnlBlendUVSlot.ResumeLayout(false);
            this.pnlBlendUVSlot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlendUVSlot)).EndInit();
            this.pnlLayer1UVSlot.ResumeLayout(false);
            this.pnlLayer1UVSlot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLayer1UVSlot)).EndInit();
            this.pnlLayer2UVSlot.ResumeLayout(false);
            this.pnlLayer2UVSlot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLayer2UVSlot)).EndInit();
            this.pnlSpecColourB.ResumeLayout(false);
            this.pnlSpecColourB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpecColourB)).EndInit();
            this.pnlNoSortAlpha.ResumeLayout(false);
            this.pnlAmbientLightR.ResumeLayout(false);
            this.pnlAmbientLightR.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmbientLightR)).EndInit();
            this.pnlAmbientLightG.ResumeLayout(false);
            this.pnlAmbientLightG.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmbientLightG)).EndInit();
            this.pnlAmbientLightB.ResumeLayout(false);
            this.pnlAmbientLightB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmbientLightB)).EndInit();
            this.gbSubstance.ResumeLayout(false);
            this.gbSubstance.PerformLayout();
            this.gbGeneral.ResumeLayout(false);
            this.gbGeneral.PerformLayout();
            this.gbSamplers.ResumeLayout(false);
            this.gbSamplers.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPreview;
        private System.Windows.Forms.GroupBox gbPreview;
        private System.Windows.Forms.GroupBox gbFlags;
        private System.Windows.Forms.CheckBox chkReceivesShadows;
        private System.Windows.Forms.CheckBox chkCastsShadows;
        private System.Windows.Forms.CheckBox chkTranslucent;
        private System.Windows.Forms.CheckBox chkFogEnabled;
        private System.Windows.Forms.CheckBox chkDoubleSided;
        private System.Windows.Forms.CheckBox chkUnpickable;
        private System.Windows.Forms.CheckBox chkPanickable;
        private System.Windows.Forms.CheckBox chkSitable;
        private System.Windows.Forms.CheckBox chkWalkable;
        private System.Windows.Forms.GroupBox gbNeeds;
        private System.Windows.Forms.CheckBox chkNeedsSeperateObjectColour;
        private System.Windows.Forms.CheckBox chkNeedsLocalCubeMap;
        private System.Windows.Forms.CheckBox chkNeedsVertexColour;
        private System.Windows.Forms.CheckBox chkNeedsLightingSpaceVertexNormal;
        private System.Windows.Forms.CheckBox chkNeedsWorldVertexPos;
        private System.Windows.Forms.CheckBox chkNeedsWorldEyePos;
        private System.Windows.Forms.CheckBox chkNeedsWorldSpaceVertexNormal;
        private System.Windows.Forms.CheckBox chkNeedsWorldLightDir;
        private System.Windows.Forms.GroupBox gbGlobalSettings;
        private System.Windows.Forms.Label lblFresnelR0;
        private System.Windows.Forms.NumericUpDown nudFresnel_R0;
        private System.Windows.Forms.Label lblReflectionBlurriness;
        private System.Windows.Forms.NumericUpDown nudReflectionBluryness;
        private System.Windows.Forms.NumericUpDown nudReflectionMultiplierZ;
        private System.Windows.Forms.NumericUpDown nudReflectionMultiplierY;
        private System.Windows.Forms.Label lblReflectionMultiplier;
        private System.Windows.Forms.NumericUpDown nudReflectionMultiplierX;
        private System.Windows.Forms.Label lblEmissiveFactor;
        private System.Windows.Forms.NumericUpDown nudEmissiveFactor;
        private System.Windows.Forms.Panel pnlButtonBox;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.NumericUpDown nudMultiplierZ;
        private System.Windows.Forms.NumericUpDown nudMultiplierY;
        private System.Windows.Forms.Label lblMultiplier;
        private System.Windows.Forms.NumericUpDown nudMultiplierX;
        private System.Windows.Forms.NumericUpDown nudEmissiveLightZ;
        private System.Windows.Forms.NumericUpDown nudEmissiveLightY;
        private System.Windows.Forms.Label lblEmissiveLight;
        private System.Windows.Forms.NumericUpDown nudEmissiveLightX;
        private System.Windows.Forms.Label lblAlphaCutoff;
        private System.Windows.Forms.NumericUpDown nudAlphaCutoff;
        private System.Windows.Forms.GroupBox gbMaterial;
        private System.Windows.Forms.FlowLayoutPanel flpMaterialOptions;
        private System.Windows.Forms.Panel pnlDiffuse1;
        private System.Windows.Forms.Button btnDiffuse1;
        private System.Windows.Forms.TextBox txtDiffuseColour;
        private System.Windows.Forms.Panel pnlNormal1;
        private System.Windows.Forms.Button btnNormal1;
        private System.Windows.Forms.TextBox txtNormal1;
        private System.Windows.Forms.Panel pnlSpecular1;
        private System.Windows.Forms.Button btnSpecular1;
        private System.Windows.Forms.TextBox txtSpecular1;
        private System.Windows.Forms.Panel pnlDiffuse2;
        private System.Windows.Forms.Button btnDiffuse2;
        private System.Windows.Forms.TextBox txtDiffuse2;
        private System.Windows.Forms.Panel pnlNormal2;
        private System.Windows.Forms.Button btnNormal2;
        private System.Windows.Forms.TextBox txtNormal2;
        private System.Windows.Forms.Panel pnlSpecular2;
        private System.Windows.Forms.Button btnSpecular2;
        private System.Windows.Forms.TextBox txtSpecular2;
        private System.Windows.Forms.Panel pnlDiffuse3;
        private System.Windows.Forms.Button btnDiffuse3;
        private System.Windows.Forms.TextBox txtDiffuse3;
        private System.Windows.Forms.Panel pnlNormal3;
        private System.Windows.Forms.Button btnNormal3;
        private System.Windows.Forms.TextBox txtNormal3;
        private System.Windows.Forms.Panel pnlSpecular3;
        private System.Windows.Forms.Button btnSpecular3;
        private System.Windows.Forms.TextBox txtSpecular3;
        private System.Windows.Forms.Panel pnlBlendMap;
        private System.Windows.Forms.Button btnBlendMap;
        private System.Windows.Forms.TextBox txtBlendMap;
        private System.Windows.Forms.Panel pnlBlendFactor;
        private System.Windows.Forms.Label lblBlendFactor;
        private System.Windows.Forms.NumericUpDown nudBlendFactor;
        private System.Windows.Forms.Panel pnlFalloff;
        private System.Windows.Forms.Label lblFalloff;
        private System.Windows.Forms.NumericUpDown nudFalloff;
        private System.Windows.Forms.Panel pnlBlendUVSlot;
        private System.Windows.Forms.Label lblBlendUVSlot;
        private System.Windows.Forms.NumericUpDown nudBlendUVSlot;
        private System.Windows.Forms.Panel pnlLayer1UVSlot;
        private System.Windows.Forms.Label lblLayer1UVSlot;
        private System.Windows.Forms.NumericUpDown nudLayer1UVSlot;
        private System.Windows.Forms.Panel pnlLayer2UVSlot;
        private System.Windows.Forms.Label lblLayer2UVSlot;
        private System.Windows.Forms.NumericUpDown nudLayer2UVSlot;
        private System.Windows.Forms.Panel pnlSpecColourB;
        private System.Windows.Forms.Label lblSpecColourB;
        private System.Windows.Forms.NumericUpDown nudSpecColourB;
        private System.Windows.Forms.Panel pnlNoSortAlpha;
        private System.Windows.Forms.CheckBox chkNoSortAlpha;
        private System.Windows.Forms.Panel pnlAmbientLightR;
        private System.Windows.Forms.Label lblAmbientLightR;
        private System.Windows.Forms.NumericUpDown nudAmbientLightR;
        private System.Windows.Forms.Panel pnlAmbientLightG;
        private System.Windows.Forms.Label lblAmbientLightG;
        private System.Windows.Forms.NumericUpDown nudAmbientLightG;
        private System.Windows.Forms.Panel pnlAmbientLightB;
        private System.Windows.Forms.Label lblAmbientLightB;
        private System.Windows.Forms.NumericUpDown nudAmbientLightB;
        private System.Windows.Forms.OpenFileDialog ofdBrowse;
        private System.Windows.Forms.GroupBox gbSubstance;
        private System.Windows.Forms.Label lblSubstance2;
        private System.Windows.Forms.TextBox txtSubstance2;
        private System.Windows.Forms.Label lblSubstance;
        private System.Windows.Forms.TextBox txtSubstance;
        private System.Windows.Forms.GroupBox gbGeneral;
        private System.Windows.Forms.Label lblBase;
        private System.Windows.Forms.ComboBox cboBaseMaterial;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtMaterialName;
        private System.Windows.Forms.GroupBox gbSamplers;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.ListBox lstSamplersAndTexCoordSources;
    }
}