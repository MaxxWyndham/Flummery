using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using Flummery.Core;
using Flummery.Core.ContentPipeline;
using Flummery.Plugin;
using Flummery.Util;

using OpenTK;
using OpenTK.Graphics.OpenGL;

using ToxicRagers.Helpers;

using WeifenLuo.WinFormsUI.Docking;

namespace Flummery
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        public DockPanel DockPanel => dockPanel;
        public PluginHandler pluginHandler = new PluginHandler();

        private void frmMain_Load(object sender, EventArgs e)
        {
            FlummeryApplication.Settings.Load("flummery.config");

            CultureInfo.DefaultThreadCurrentCulture = FlummeryApplication.Culture;
            CultureInfo.DefaultThreadCurrentUICulture = FlummeryApplication.Culture;

            Toolkit.Init();

            Text += $" v{FlummeryApplication.Version}";

            InputManager inputManager = new InputManager();
            SceneManager.Create(new Renderer.OpenTKRenderer());

            PnlViewport viewport = new PnlViewport();
            PnlMaterialList materials = new PnlMaterialList();
            PnlOverview overview = new PnlOverview();
            PnlDetails details = new PnlDetails();

            materials.FormClosed += materials_FormClosed;
            overview.FormClosed += overview_FormClosed;
            details.FormClosed += details_FormClosed;

            pluginHandler.InitialiseModules();

            viewport.Show(dockPanel, DockState.Document);
            materials.Show(dockPanel, DockState.DockBottom);
            overview.Show(dockPanel, DockState.DockLeft);
            details.Show(dockPanel, DockState.DockRight);

            SceneManager.Current.CanUseVertexBuffer = GL.GetString(StringName.Extensions).Split(' ').Contains("GL_ARB_vertex_buffer_object");

            dockPanel.DockLeftPortion = 300;
            dockPanel.DockRightPortion = 315;
            dockPanel.DockBottomPortion = 105;

            viewport.RegisterEventHandlers();
            overview.RegisterEventHandlers();
            materials.RegisterEventHandlers();
            details.RegisterEventHandlers();

            Logger.ResetLog();

            SetActionScalingText("Action Scaling: 1.000");

            KeyPreview = true;
            KeyPress += new KeyPressEventHandler(frmMain_KeyPress);

            SceneManager.Current.OnProgress += scene_OnProgress;
            SceneManager.Current.OnError += scene_OnError;
            SceneManager.Current.SetCoordinateSystem(CoordinateSystem.LeftHanded);

            //SceneManager.Current.SetContext(ContextGame.CarmageddonReincarnation, ContextMode.Car);

            pluginHandler.RegisterFileOpens(tsmiFileOpen, ofdBrowse);
            pluginHandler.RegisterFileImports(tsmiFileImport, ofdBrowse);
            pluginHandler.RegisterFileSaveFors(tsmiFileSaveFor, sfdBrowse);
            pluginHandler.RegisterFileSaveAs(tsmiFileSaveAs);
            pluginHandler.RegisterFileExports(tsmiFileExport, sfdBrowse);
            pluginHandler.RegisterTools(tsmiTools);
            pluginHandler.RegisterProcessAlls(tsmiToolsGeneralProcessAll, fbdBrowse);

            FlummeryApplication.UI = this;

            //ToxicRagers.UltimateRacePro.Formats.BankFile.Load(@"C:\Users\errol\Downloads\BNK\TRCK002.BD4");

            //var mshs = ToxicRagers.TDR2000.Formats.MSHS.Load(@"D:\Carmageddon Installations\SCi\Carmageddon TDR2000\ASSETS\Powerups\POWERUPS\newIcons_Fist0.msh");
            //mshs.Save(@"D:\Carmageddon Installations\SCi\Carmageddon TDR2000\ASSETS\Powerups\POWERUPS\newIcons_Fist0_Flummery.msh");

            //var mshs = ToxicRagers.TDR2000.Formats.MSHS.Load(@"D:\Carmageddon Installations\SCi\Carmageddon TDR2000\ASSETS\Cars\Eagle4\eagle_mk4_v8ConvSoft_eagle_mk4\Eagle_mk4_v8ConvSoft_eagle_mk4.mshs");
            //mshs.Save(@"D:\Carmageddon Installations\SCi\Carmageddon TDR2000\ASSETS\Cars\Eagle4\eagle_mk4_v8ConvSoft_eagle_mk4\Eagle_mk4_v8ConvSoft_eagle_mk4_Flummery.mshs");

            //var mshs = ToxicRagers.TDR2000.Formats.MSHS.Load(@"D:\Carmageddon Installations\SCi\Carmageddon TDR2000\ASSETS\Tracks\Arena\Level Convsoft\ArenaMesh\ArenaMesh.mshs");
            //mshs.Save(@"D:\Carmageddon Installations\SCi\Carmageddon TDR2000\ASSETS\Tracks\Arena\Level Convsoft\ArenaMesh\ArenaMesh_Flummery.mshs");

            //Application.Exit();
        }

        private void materials_FormClosed(object sender, FormClosedEventArgs e)
        {
            tsmiViewPanelsMaterialList.Checked = false;
        }

        private void details_FormClosed(object sender, FormClosedEventArgs e)
        {
            tsmiViewPanelsDetails.Checked = false;
        }

        private void overview_FormClosed(object sender, FormClosedEventArgs e)
        {
            tsmiViewPanelsOverview.Checked = false;
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            if (FlummeryApplication.Settings.CheckForUpdates)
            {
                void finishRequest(bool result, Updater.Update[] updates)
                {
                    if (result == true && updates.Count() > 0)
                    {
                        frmUpdater updateForm = new frmUpdater { Updates = updates };

                        updateForm.ShowDialog();
                    }
                }

                new Updater().Check(FlummeryApplication.Version, finishRequest);
            }
        }

        void scene_OnProgress(object sender, ProgressEventArgs e)
        {
            tsslProgress.Text = e.Status;
            tsslProgress.Owner.Refresh();
            Application.DoEvents();
        }

        void scene_OnError(object sender, Core.ErrorEventArgs e)
        {
            MessageBox.Show(e.Message);
        }

        void frmMain_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            //e.Handled = InputManager.Current.HandleInput(sender, e);
        }

        private void menuClick(object sender, EventArgs e)
        {
            ToolStripMenuItem mi = (ToolStripMenuItem)sender;

            switch (mi.Text)
            {
                case " & New":
                    SceneManager.Current.Reset();
                    break;

                case "E&xit":
                    Application.Exit();
                    break;

                case "About Flummery":
                    new frmAbout().ShowDialog();
                    break;
            }
        }

        private void menuImportClick(object sender, EventArgs e)
        {
            ToolStripMenuItem mi = (ToolStripMenuItem)sender;

            switch (mi.Text)
            {
                case "Autodesk FBX File...":
                    ofdBrowse.Filter = "Autodesk FBX files (*.fbx)|*.fbx";

                    if (ofdBrowse.ShowDialog() == DialogResult.OK && File.Exists(ofdBrowse.FileName))
                    {
                        SceneManager.Current.SetCoordinateSystem(CoordinateSystem.LeftHanded);
                        Model _ = SceneManager.Current.Content.Load<Model, FBXImporter>(Path.GetFileNameWithoutExtension(ofdBrowse.FileName), Path.GetDirectoryName(ofdBrowse.FileName), true);

                        SceneManager.Current.UpdateProgress($"Imported {Path.GetFileName(ofdBrowse.FileName)}");
                    }
                    break;
            }
        }

        private void menuExportClick(object sender, EventArgs e)
        {
            ToolStripMenuItem mi = (ToolStripMenuItem)sender;

            switch (mi.Text)
            {
                case "Autodesk FBX File...":
                    sfdBrowse.Filter = "Autodesk FBX files (*.fbx)|*.fbx";
                    if (sfdBrowse.ShowDialog() == DialogResult.OK)
                    {
                        FBXExporter fx = new FBXExporter();
                        fx.ExportSettings.AddSetting("NeedsFlipping", SceneManager.Current.CoordinateSystem == CoordinateSystem.LeftHanded);
                        fx.ExportSettings.AddSetting("Version", FlummeryApplication.Version);
                        fx.Export(SceneManager.Current.Models[0], sfdBrowse.FileName);

                        SceneManager.Current.UpdateProgress($"Saved {Path.GetFileName(sfdBrowse.FileName)}");
                    }
                    break;
            }
        }

        private void menuViewClick(object sender, EventArgs e)
        {
            ToolStripMenuItem mi = (ToolStripMenuItem)sender;
            DockContent panel;

            switch (mi.Text)
            {
                case "Preferences":
                    if (new frmPreferences().ShowDialog(this) == DialogResult.OK)
                    {
                        InputManager.Current.ReloadBindings();
                    }
                    break;

                case "Details":
                    panel = (DockContent)dockPanel.Contents.FirstOrDefault(p => (p as DockContent).Text == mi.Text);

                    if (panel == null)
                    {
                        mi.Checked = true;

                        PnlDetails details = new PnlDetails();
                        details.Show(dockPanel, DockState.DockRight);
                        details.RegisterEventHandlers();
                        details.FormClosed += details_FormClosed;
                    }
                    else
                    {
                        panel.Close();
                    }
                    break;

                case "Material List":
                    panel = (DockContent)dockPanel.Contents.FirstOrDefault(p => (p as DockContent).Text == mi.Text);

                    if (panel == null)
                    {
                        mi.Checked = true;

                        PnlMaterialList materials = new PnlMaterialList();
                        materials.Show(dockPanel, DockState.DockBottom);
                        materials.RegisterEventHandlers();
                        materials.FormClosed += materials_FormClosed;
                    }
                    else
                    {
                        panel.Close();
                    }
                    break;

                case "Overview":
                    panel = (DockContent)dockPanel.Contents.FirstOrDefault(p => (p as DockContent).Text == mi.Text);

                    if (panel == null)
                    {
                        mi.Checked = true;

                        PnlOverview overview = new PnlOverview();
                        overview.Show(dockPanel, DockState.DockLeft);
                        overview.RegisterEventHandlers();
                        overview.FormClosed += overview_FormClosed;
                    }
                    else
                    {
                        panel.Close();
                    }
                    break;
            }
        }

        private void menuObjectClick(object sender, EventArgs e)
        {
            ToolStripMenuItem mi = (ToolStripMenuItem)sender;

            int boneIndex = SceneManager.Current.SelectedBoneIndex;
            int modelIndex = SceneManager.Current.SelectedModelIndex;
            int modelBoneKey = ModelBone.GetModelBoneKey(modelIndex, boneIndex);

            switch (mi.Text)
            {
                case "New...":
                    frmNewObject addNew = new frmNewObject();
                    addNew.SetParentNode(modelIndex, boneIndex);

                    if (addNew.ShowDialog(this) == DialogResult.OK)
                    {
                        SceneManager.Current.Change(ChangeType.Add, ChangeContext.Model, addNew.NewBoneKey, modelBoneKey);
                    }
                    break;

                case "Remove...":
                    frmRemoveObject removeObject = new frmRemoveObject();
                    removeObject.SetParentNode(modelIndex, boneIndex);

                    if (removeObject.ShowDialog(this) == DialogResult.OK)
                    {
                        SceneManager.Current.Change(ChangeType.Delete, ChangeContext.Model, modelBoneKey, removeObject.RemovedBone);
                    }
                    break;

                case "Modify geometry...":
                    frmModifyModel geometry = new frmModifyModel();
                    geometry.SetParentNode(modelIndex, boneIndex);

                    if (geometry.ShowDialog(this) == DialogResult.OK)
                    {
                        SceneManager.Current.Change(ChangeType.Transform, ChangeContext.Model, modelBoneKey);
                    }
                    break;

                case "Modify actor...":
                    frmModifyActor transform = new frmModifyActor();
                    transform.SetParentNode(modelIndex, boneIndex);

                    if (transform.ShowDialog(this) == DialogResult.OK)
                    {
                        SceneManager.Current.Change(ChangeType.Transform, ChangeContext.Model, modelBoneKey);
                    }
                    break;

                case "Rename":
                    frmRename rename = new frmRename();
                    rename.SetParentNode(modelIndex, boneIndex);

                    if (rename.ShowDialog(this) == DialogResult.OK)
                    {
                        SceneManager.Current.Change(ChangeType.Rename, ChangeContext.Model, modelBoneKey, rename.NewName);
                    }
                    break;

                case "Add/Change Type...":
                    frmChangeNodeType changeType = new frmChangeNodeType();
                    changeType.SetParentNode(modelIndex, boneIndex);

                    if (changeType.ShowDialog(this) == DialogResult.OK)
                    {
                        SceneManager.Current.Change(ChangeType.ChangeType, ChangeContext.Model, modelBoneKey);
                    }
                    break;

                case "Remove":
                    break;

                case "Optimise":
                    foreach (ModelMesh mesh in SceneManager.Current.SelectedModel.Meshes)
                    {
                        foreach (ModelMeshPart part in mesh.MeshParts)
                        {
                            part.Optimise();
                        }
                    }
                    break;

                case "Flatten hierarchy...":
                    SceneManager.Current.UpdateProgress("TODO: Code \"Flatten hierarchy...\"");
                    break;

                case "Invert texture 'v' coordinates":
                    ModelManipulator.FlipUVs(SceneManager.Current.SelectedModel.Bones[SceneManager.Current.SelectedBoneIndex].Mesh);
                    break;
            }
        }

        private void menuToolsClick(object sender, EventArgs e)
        {
            ToolStripMenuItem mi = (ToolStripMenuItem)sender;

            switch (mi.Text)
            {
                case "TDX Convertor":
                    frmTDXConvert tdx = new frmTDXConvert();
                    tdx.Show(this);
                    break;
            }
        }

        public void SetActionScalingText(string scale)
        {
            tsslActionScaling.Text = scale;
        }

        private void frmMain_Activated(object sender, EventArgs e)
        {
            FlummeryApplication.Active = true;
        }

        private void frmMain_Deactivate(object sender, EventArgs e)
        {
            FlummeryApplication.Active = false;
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            FlummeryApplication.Active = (WindowState != FormWindowState.Minimized);
        }
    }
}