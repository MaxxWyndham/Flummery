namespace Flummery
{
    partial class frmMain
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
        /// this.glcViewport = new OpenTK.GLControl();
        /// this.glcViewport = new Flummery.CustomGLControl();
        /// </summary>
        private void InitializeComponent()
        {
            this.ofdBrowse = new System.Windows.Forms.OpenFileDialog();
            this.sfdBrowse = new System.Windows.Forms.SaveFileDialog();
            this.tsslProgress = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslActionScaling = new System.Windows.Forms.ToolStripStatusLabel();
            this.ssStatus = new System.Windows.Forms.StatusStrip();
            this.fbdBrowse = new System.Windows.Forms.FolderBrowserDialog();
            this.dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFileImport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFileImportAutodeskFBXFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFileSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiFileSaveFor = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFileExport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFileExportAutodeskFBXFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFileSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiView = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiViewPreferences = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiViewSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiViewPanels = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiViewPanelsOverview = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiViewPanelsMaterialList = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiViewPanelsDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiObject = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiObjectNew = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiObjectRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiObjectSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiObjectModifyModel = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiObjectModifyModelModifyGeometry = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiObjectModifyActor = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiObjectSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiObjectRename = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiObjectSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiObjectData = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiObjectDataAddChangeType = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiObjectDataRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiObjectSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiObjectOptimise = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiObjectFlattenHierarchy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiObjectSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiObjectInvertTextureVCoordinates = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTools = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiToolsGeneral = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiToolsGeneralTDXConvertor = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiToolsGeneralProcessAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelpAboutFlummery = new System.Windows.Forms.ToolStripMenuItem();
            this.ssStatus.SuspendLayout();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsslProgress
            // 
            this.tsslProgress.Name = "tsslProgress";
            this.tsslProgress.Size = new System.Drawing.Size(1193, 19);
            this.tsslProgress.Spring = true;
            this.tsslProgress.Text = "[progress]";
            this.tsslProgress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tsslActionScaling
            // 
            this.tsslActionScaling.AutoSize = false;
            this.tsslActionScaling.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tsslActionScaling.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.tsslActionScaling.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsslActionScaling.Name = "tsslActionScaling";
            this.tsslActionScaling.Size = new System.Drawing.Size(120, 19);
            this.tsslActionScaling.Text = "Action Scaling: 10.000";
            // 
            // ssStatus
            // 
            this.ssStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslProgress,
            this.tsslActionScaling});
            this.ssStatus.Location = new System.Drawing.Point(0, 618);
            this.ssStatus.Name = "ssStatus";
            this.ssStatus.Size = new System.Drawing.Size(1328, 24);
            this.ssStatus.TabIndex = 2;
            this.ssStatus.Text = "statusStrip1";
            // 
            // fbdBrowse
            // 
            this.fbdBrowse.ShowNewFolderButton = false;
            // 
            // dockPanel
            // 
            this.dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel.Location = new System.Drawing.Point(0, 24);
            this.dockPanel.Name = "dockPanel";
            this.dockPanel.Size = new System.Drawing.Size(1328, 594);
            this.dockPanel.TabIndex = 4;
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.tsmiView,
            this.tsmiObject,
            this.tsmiTools,
            this.tsmiHelp});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1328, 24);
            this.menu.TabIndex = 7;
            this.menu.Text = "menuStrip1";
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFileNew,
            this.tsmiFileOpen,
            this.tsmiFileImport,
            this.tsmiFileSeparator1,
            this.tsmiFileSaveFor,
            this.tsmiFileSaveAs,
            this.tsmiFileExport,
            this.tsmiFileSeparator2,
            this.tsmiFileExit});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(37, 20);
            this.tsmiFile.Text = "&File";
            // 
            // tsmiFileNew
            // 
            this.tsmiFileNew.Name = "tsmiFileNew";
            this.tsmiFileNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.tsmiFileNew.Size = new System.Drawing.Size(141, 22);
            this.tsmiFileNew.Text = "&New";
            this.tsmiFileNew.Click += new System.EventHandler(this.menuClick);
            // 
            // tsmiFileOpen
            // 
            this.tsmiFileOpen.Name = "tsmiFileOpen";
            this.tsmiFileOpen.Size = new System.Drawing.Size(141, 22);
            this.tsmiFileOpen.Text = "&Open...";
            // 
            // tsmiFileImport
            // 
            this.tsmiFileImport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFileImportAutodeskFBXFile});
            this.tsmiFileImport.Name = "tsmiFileImport";
            this.tsmiFileImport.Size = new System.Drawing.Size(141, 22);
            this.tsmiFileImport.Text = "&Import";
            // 
            // tsmiFileImportAutodeskFBXFile
            // 
            this.tsmiFileImportAutodeskFBXFile.Name = "tsmiFileImportAutodeskFBXFile";
            this.tsmiFileImportAutodeskFBXFile.Size = new System.Drawing.Size(177, 22);
            this.tsmiFileImportAutodeskFBXFile.Text = "Autodesk FBX File...";
            this.tsmiFileImportAutodeskFBXFile.Click += new System.EventHandler(this.menuImportClick);
            // 
            // tsmiFileSeparator1
            // 
            this.tsmiFileSeparator1.Name = "tsmiFileSeparator1";
            this.tsmiFileSeparator1.Size = new System.Drawing.Size(138, 6);
            // 
            // tsmiFileSaveFor
            // 
            this.tsmiFileSaveFor.Name = "tsmiFileSaveFor";
            this.tsmiFileSaveFor.Size = new System.Drawing.Size(141, 22);
            this.tsmiFileSaveFor.Text = "Save For...";
            // 
            // tsmiFileSaveAs
            // 
            this.tsmiFileSaveAs.Name = "tsmiFileSaveAs";
            this.tsmiFileSaveAs.Size = new System.Drawing.Size(141, 22);
            this.tsmiFileSaveAs.Text = "Save As...";
            // 
            // tsmiFileExport
            // 
            this.tsmiFileExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFileExportAutodeskFBXFile});
            this.tsmiFileExport.Name = "tsmiFileExport";
            this.tsmiFileExport.Size = new System.Drawing.Size(141, 22);
            this.tsmiFileExport.Text = "&Export";
            // 
            // tsmiFileExportAutodeskFBXFile
            // 
            this.tsmiFileExportAutodeskFBXFile.Name = "tsmiFileExportAutodeskFBXFile";
            this.tsmiFileExportAutodeskFBXFile.Size = new System.Drawing.Size(177, 22);
            this.tsmiFileExportAutodeskFBXFile.Text = "Autodesk FBX File...";
            this.tsmiFileExportAutodeskFBXFile.Click += new System.EventHandler(this.menuExportClick);
            // 
            // tsmiFileSeparator2
            // 
            this.tsmiFileSeparator2.Name = "tsmiFileSeparator2";
            this.tsmiFileSeparator2.Size = new System.Drawing.Size(138, 6);
            // 
            // tsmiFileExit
            // 
            this.tsmiFileExit.Name = "tsmiFileExit";
            this.tsmiFileExit.Size = new System.Drawing.Size(141, 22);
            this.tsmiFileExit.Text = "E&xit";
            this.tsmiFileExit.Click += new System.EventHandler(this.menuClick);
            // 
            // tsmiView
            // 
            this.tsmiView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiViewPreferences,
            this.tsmiViewSeparator1,
            this.tsmiViewPanels});
            this.tsmiView.Name = "tsmiView";
            this.tsmiView.Size = new System.Drawing.Size(44, 20);
            this.tsmiView.Text = "&View";
            // 
            // tsmiViewPreferences
            // 
            this.tsmiViewPreferences.Name = "tsmiViewPreferences";
            this.tsmiViewPreferences.Size = new System.Drawing.Size(135, 22);
            this.tsmiViewPreferences.Text = "Preferences";
            this.tsmiViewPreferences.Click += new System.EventHandler(this.menuViewClick);
            // 
            // tsmiViewSeparator1
            // 
            this.tsmiViewSeparator1.Name = "tsmiViewSeparator1";
            this.tsmiViewSeparator1.Size = new System.Drawing.Size(132, 6);
            // 
            // tsmiViewPanels
            // 
            this.tsmiViewPanels.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiViewPanelsOverview,
            this.tsmiViewPanelsMaterialList,
            this.tsmiViewPanelsDetails});
            this.tsmiViewPanels.Name = "tsmiViewPanels";
            this.tsmiViewPanels.Size = new System.Drawing.Size(135, 22);
            this.tsmiViewPanels.Text = "Panels";
            // 
            // tsmiViewPanelsOverview
            // 
            this.tsmiViewPanelsOverview.Checked = true;
            this.tsmiViewPanelsOverview.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiViewPanelsOverview.Name = "tsmiViewPanelsOverview";
            this.tsmiViewPanelsOverview.Size = new System.Drawing.Size(138, 22);
            this.tsmiViewPanelsOverview.Text = "Overview";
            this.tsmiViewPanelsOverview.Click += new System.EventHandler(this.menuViewClick);
            // 
            // tsmiViewPanelsMaterialList
            // 
            this.tsmiViewPanelsMaterialList.Checked = true;
            this.tsmiViewPanelsMaterialList.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiViewPanelsMaterialList.Name = "tsmiViewPanelsMaterialList";
            this.tsmiViewPanelsMaterialList.Size = new System.Drawing.Size(138, 22);
            this.tsmiViewPanelsMaterialList.Text = "Material List";
            this.tsmiViewPanelsMaterialList.Click += new System.EventHandler(this.menuViewClick);
            // 
            // tsmiViewPanelsDetails
            // 
            this.tsmiViewPanelsDetails.Checked = true;
            this.tsmiViewPanelsDetails.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiViewPanelsDetails.Name = "tsmiViewPanelsDetails";
            this.tsmiViewPanelsDetails.Size = new System.Drawing.Size(138, 22);
            this.tsmiViewPanelsDetails.Text = "Details";
            this.tsmiViewPanelsDetails.Click += new System.EventHandler(this.menuViewClick);
            // 
            // tsmiObject
            // 
            this.tsmiObject.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiObjectNew,
            this.tsmiObjectRemove,
            this.tsmiObjectSeparator1,
            this.tsmiObjectModifyModel,
            this.tsmiObjectModifyActor,
            this.tsmiObjectSeparator2,
            this.tsmiObjectRename,
            this.tsmiObjectSeparator3,
            this.tsmiObjectData,
            this.tsmiObjectSeparator4,
            this.tsmiObjectOptimise,
            this.tsmiObjectFlattenHierarchy,
            this.tsmiObjectSeparator5,
            this.tsmiObjectInvertTextureVCoordinates});
            this.tsmiObject.Name = "tsmiObject";
            this.tsmiObject.Size = new System.Drawing.Size(54, 20);
            this.tsmiObject.Text = "&Object";
            // 
            // tsmiObjectNew
            // 
            this.tsmiObjectNew.Name = "tsmiObjectNew";
            this.tsmiObjectNew.Size = new System.Drawing.Size(224, 22);
            this.tsmiObjectNew.Text = "New...";
            this.tsmiObjectNew.Click += new System.EventHandler(this.menuObjectClick);
            // 
            // tsmiObjectRemove
            // 
            this.tsmiObjectRemove.Name = "tsmiObjectRemove";
            this.tsmiObjectRemove.Size = new System.Drawing.Size(224, 22);
            this.tsmiObjectRemove.Text = "Remove...";
            this.tsmiObjectRemove.Click += new System.EventHandler(this.menuObjectClick);
            // 
            // tsmiObjectSeparator1
            // 
            this.tsmiObjectSeparator1.Name = "tsmiObjectSeparator1";
            this.tsmiObjectSeparator1.Size = new System.Drawing.Size(221, 6);
            // 
            // tsmiObjectModifyModel
            // 
            this.tsmiObjectModifyModel.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiObjectModifyModelModifyGeometry});
            this.tsmiObjectModifyModel.Name = "tsmiObjectModifyModel";
            this.tsmiObjectModifyModel.Size = new System.Drawing.Size(224, 22);
            this.tsmiObjectModifyModel.Text = "Modify model...";
            // 
            // tsmiObjectModifyModelModifyGeometry
            // 
            this.tsmiObjectModifyModelModifyGeometry.Name = "tsmiObjectModifyModelModifyGeometry";
            this.tsmiObjectModifyModelModifyGeometry.Size = new System.Drawing.Size(175, 22);
            this.tsmiObjectModifyModelModifyGeometry.Text = "Modify geometry...";
            this.tsmiObjectModifyModelModifyGeometry.Click += new System.EventHandler(this.menuObjectClick);
            // 
            // tsmiObjectModifyActor
            // 
            this.tsmiObjectModifyActor.Name = "tsmiObjectModifyActor";
            this.tsmiObjectModifyActor.Size = new System.Drawing.Size(224, 22);
            this.tsmiObjectModifyActor.Text = "Modify actor...";
            this.tsmiObjectModifyActor.Click += new System.EventHandler(this.menuObjectClick);
            // 
            // tsmiObjectSeparator2
            // 
            this.tsmiObjectSeparator2.Name = "tsmiObjectSeparator2";
            this.tsmiObjectSeparator2.Size = new System.Drawing.Size(221, 6);
            // 
            // tsmiObjectRename
            // 
            this.tsmiObjectRename.Name = "tsmiObjectRename";
            this.tsmiObjectRename.Size = new System.Drawing.Size(224, 22);
            this.tsmiObjectRename.Text = "Rename";
            this.tsmiObjectRename.Click += new System.EventHandler(this.menuObjectClick);
            // 
            // tsmiObjectSeparator3
            // 
            this.tsmiObjectSeparator3.Name = "tsmiObjectSeparator3";
            this.tsmiObjectSeparator3.Size = new System.Drawing.Size(221, 6);
            // 
            // tsmiObjectData
            // 
            this.tsmiObjectData.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiObjectDataAddChangeType,
            this.tsmiObjectDataRemove});
            this.tsmiObjectData.Name = "tsmiObjectData";
            this.tsmiObjectData.Size = new System.Drawing.Size(224, 22);
            this.tsmiObjectData.Text = "Data";
            // 
            // tsmiObjectDataAddChangeType
            // 
            this.tsmiObjectDataAddChangeType.Name = "tsmiObjectDataAddChangeType";
            this.tsmiObjectDataAddChangeType.Size = new System.Drawing.Size(178, 22);
            this.tsmiObjectDataAddChangeType.Text = "Add/Change Type...";
            this.tsmiObjectDataAddChangeType.Click += new System.EventHandler(this.menuObjectClick);
            // 
            // tsmiObjectDataRemove
            // 
            this.tsmiObjectDataRemove.Name = "tsmiObjectDataRemove";
            this.tsmiObjectDataRemove.Size = new System.Drawing.Size(178, 22);
            this.tsmiObjectDataRemove.Text = "Remove";
            this.tsmiObjectDataRemove.Click += new System.EventHandler(this.menuObjectClick);
            // 
            // tsmiObjectSeparator4
            // 
            this.tsmiObjectSeparator4.Name = "tsmiObjectSeparator4";
            this.tsmiObjectSeparator4.Size = new System.Drawing.Size(221, 6);
            // 
            // tsmiObjectOptimise
            // 
            this.tsmiObjectOptimise.Name = "tsmiObjectOptimise";
            this.tsmiObjectOptimise.Size = new System.Drawing.Size(224, 22);
            this.tsmiObjectOptimise.Text = "Optimise";
            this.tsmiObjectOptimise.Click += new System.EventHandler(this.menuObjectClick);
            // 
            // tsmiObjectFlattenHierarchy
            // 
            this.tsmiObjectFlattenHierarchy.Name = "tsmiObjectFlattenHierarchy";
            this.tsmiObjectFlattenHierarchy.Size = new System.Drawing.Size(224, 22);
            this.tsmiObjectFlattenHierarchy.Text = "Flatten hierarchy...";
            this.tsmiObjectFlattenHierarchy.Click += new System.EventHandler(this.menuObjectClick);
            // 
            // tsmiObjectSeparator5
            // 
            this.tsmiObjectSeparator5.Name = "tsmiObjectSeparator5";
            this.tsmiObjectSeparator5.Size = new System.Drawing.Size(221, 6);
            // 
            // tsmiObjectInvertTextureVCoordinates
            // 
            this.tsmiObjectInvertTextureVCoordinates.Name = "tsmiObjectInvertTextureVCoordinates";
            this.tsmiObjectInvertTextureVCoordinates.Size = new System.Drawing.Size(224, 22);
            this.tsmiObjectInvertTextureVCoordinates.Text = "Invert texture \'v\' coordinates";
            this.tsmiObjectInvertTextureVCoordinates.Click += new System.EventHandler(this.menuObjectClick);
            // 
            // tsmiTools
            // 
            this.tsmiTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiToolsGeneral});
            this.tsmiTools.Name = "tsmiTools";
            this.tsmiTools.Size = new System.Drawing.Size(46, 20);
            this.tsmiTools.Text = "&Tools";
            // 
            // tsmiToolsGeneral
            // 
            this.tsmiToolsGeneral.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiToolsGeneralTDXConvertor,
            this.tsmiToolsGeneralProcessAll});
            this.tsmiToolsGeneral.Name = "tsmiToolsGeneral";
            this.tsmiToolsGeneral.Size = new System.Drawing.Size(114, 22);
            this.tsmiToolsGeneral.Text = "General";
            // 
            // tsmiToolsGeneralTDXConvertor
            // 
            this.tsmiToolsGeneralTDXConvertor.Name = "tsmiToolsGeneralTDXConvertor";
            this.tsmiToolsGeneralTDXConvertor.Size = new System.Drawing.Size(151, 22);
            this.tsmiToolsGeneralTDXConvertor.Text = "TDX Convertor";
            this.tsmiToolsGeneralTDXConvertor.Click += new System.EventHandler(this.menuToolsClick);
            // 
            // tsmiToolsGeneralProcessAll
            // 
            this.tsmiToolsGeneralProcessAll.Name = "tsmiToolsGeneralProcessAll";
            this.tsmiToolsGeneralProcessAll.Size = new System.Drawing.Size(151, 22);
            this.tsmiToolsGeneralProcessAll.Text = "Process all...";
            // 
            // tsmiHelp
            // 
            this.tsmiHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiHelpAboutFlummery});
            this.tsmiHelp.Name = "tsmiHelp";
            this.tsmiHelp.Size = new System.Drawing.Size(44, 20);
            this.tsmiHelp.Text = "&Help";
            // 
            // tsmiHelpAboutFlummery
            // 
            this.tsmiHelpAboutFlummery.Name = "tsmiHelpAboutFlummery";
            this.tsmiHelpAboutFlummery.Size = new System.Drawing.Size(164, 22);
            this.tsmiHelpAboutFlummery.Text = "About Flummery";
            this.tsmiHelpAboutFlummery.Click += new System.EventHandler(this.menuClick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1328, 642);
            this.Controls.Add(this.dockPanel);
            this.Controls.Add(this.ssStatus);
            this.Controls.Add(this.menu);
            this.Icon = global::Flummery.Properties.Resources.icon;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menu;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Flummery";
            this.Activated += new System.EventHandler(this.frmMain_Activated);
            this.Deactivate += new System.EventHandler(this.frmMain_Deactivate);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.ssStatus.ResumeLayout(false);
            this.ssStatus.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdBrowse;
        private System.Windows.Forms.SaveFileDialog sfdBrowse;
        private System.Windows.Forms.ToolStripStatusLabel tsslProgress;
        private System.Windows.Forms.ToolStripStatusLabel tsslActionScaling;
        private System.Windows.Forms.StatusStrip ssStatus;
        private System.Windows.Forms.FolderBrowserDialog fbdBrowse;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiFileNew;
        private System.Windows.Forms.ToolStripMenuItem tsmiFileOpen;
        private System.Windows.Forms.ToolStripSeparator tsmiFileSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiFileSaveFor;
        private System.Windows.Forms.ToolStripMenuItem tsmiFileSaveAs;
        private System.Windows.Forms.ToolStripMenuItem tsmiFileExport;
        private System.Windows.Forms.ToolStripMenuItem tsmiFileExportAutodeskFBXFile;
        private System.Windows.Forms.ToolStripSeparator tsmiFileSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiFileExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiView;
        private System.Windows.Forms.ToolStripMenuItem tsmiViewPreferences;
        private System.Windows.Forms.ToolStripMenuItem tsmiObject;
        private System.Windows.Forms.ToolStripMenuItem tsmiObjectNew;
        private System.Windows.Forms.ToolStripMenuItem tsmiObjectRemove;
        private System.Windows.Forms.ToolStripSeparator tsmiObjectSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiObjectModifyModel;
        private System.Windows.Forms.ToolStripMenuItem tsmiObjectModifyModelModifyGeometry;
        private System.Windows.Forms.ToolStripMenuItem tsmiObjectModifyActor;
        private System.Windows.Forms.ToolStripSeparator tsmiObjectSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiObjectRename;
        private System.Windows.Forms.ToolStripSeparator tsmiObjectSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsmiObjectFlattenHierarchy;
        private System.Windows.Forms.ToolStripSeparator tsmiObjectSeparator4;
        private System.Windows.Forms.ToolStripMenuItem tsmiObjectInvertTextureVCoordinates;
        private System.Windows.Forms.ToolStripMenuItem tsmiTools;
        private System.Windows.Forms.ToolStripMenuItem tsmiToolsGeneral;
        private System.Windows.Forms.ToolStripMenuItem tsmiToolsGeneralTDXConvertor;
        private System.Windows.Forms.ToolStripMenuItem tsmiToolsGeneralProcessAll;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelp;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelpAboutFlummery;
        private System.Windows.Forms.ToolStripMenuItem tsmiObjectOptimise;
        private System.Windows.Forms.ToolStripMenuItem tsmiObjectData;
        private System.Windows.Forms.ToolStripMenuItem tsmiObjectDataAddChangeType;
        private System.Windows.Forms.ToolStripMenuItem tsmiObjectDataRemove;
        private System.Windows.Forms.ToolStripSeparator tsmiObjectSeparator5;
        private System.Windows.Forms.ToolStripSeparator tsmiViewSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiViewPanels;
        private System.Windows.Forms.ToolStripMenuItem tsmiViewPanelsDetails;
        private System.Windows.Forms.ToolStripMenuItem tsmiViewPanelsMaterialList;
        private System.Windows.Forms.ToolStripMenuItem tsmiViewPanelsOverview;
        private System.Windows.Forms.ToolStripMenuItem tsmiFileImport;
        private System.Windows.Forms.ToolStripMenuItem tsmiFileImportAutodeskFBXFile;
    }
}

