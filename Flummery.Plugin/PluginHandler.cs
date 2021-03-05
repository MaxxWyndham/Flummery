using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

using Flummery.Core;

namespace Flummery.Plugin
{
    [Export(typeof(IPluginHandler))]
    public class PluginHandler : IPluginHandler
    {
        [ImportMany(typeof(IPlugin), AllowRecomposition = true)]
        public IEnumerable<Lazy<IPlugin, IPluginAttribute>> Plugins { get; set; }

        AggregateCatalog catalog = new AggregateCatalog();

        public void InitialiseModules()
        {
            Plugins = new List<Lazy<IPlugin, IPluginAttribute>>();

            string pluginsFolder = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "plugins");

            if (!Directory.Exists(pluginsFolder)) { Directory.CreateDirectory(pluginsFolder); }

            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetCallingAssembly()));
            catalog.Catalogs.Add(new DirectoryCatalog(pluginsFolder, "*.dll"));

            CompositionContainer cc = new CompositionContainer(catalog);
            cc.ComposeParts(this);
        }

        public IPlugin GetPluginInstance(string pluginName)
        {
            IPlugin instance = null;

            foreach (var l in Plugins)
            {
                if (l.Metadata.Name == pluginName)
                {
                    instance = l.Value;
                    break;
                }
            }

            return instance;
        }

        public void RegisterFileOpens(ToolStripMenuItem menu, OpenFileDialog openFileDialog)
        {
            foreach (Lazy<IPlugin, IPluginAttribute> plugin in Plugins)
            {
                if (plugin.Value.FileOpenItems == null) { continue; }

                ToolStripMenuItem category = new ToolStripMenuItem(plugin.Value.Name);

                foreach (MenuItem menuItem in plugin.Value.FileOpenItems)
                {
                    ToolStripMenuItem open = new ToolStripMenuItem
                    {
                        Text = menuItem.Name
                    };

                    open.Click += (sender, EventArgs) =>
                    {
                        openFileDialog.Filter = menuItem.Filter;

                        if (openFileDialog.ShowDialog() == DialogResult.OK && File.Exists(openFileDialog.FileName))
                        {
                            menuItem.FileOpenAction(openFileDialog.FileName);
                        }
                    };

                    category.DropDownItems.Add(open);
                }

                menu.DropDownItems.Add(category);
            }
        }

        public void RegisterFileImports(ToolStripMenuItem menu, OpenFileDialog openFileDialog)
        {
            foreach (Lazy<IPlugin, IPluginAttribute> plugin in Plugins)
            {
                if (plugin.Value.FileImportItems == null) { continue; }

                foreach (MenuItem menuItem in plugin.Value.FileImportItems)
                {
                    ToolStripMenuItem open = new ToolStripMenuItem
                    {
                        Text = $"{menuItem.Name}..."
                    };

                    open.Click += (sender, EventArgs) =>
                    {
                        openFileDialog.Filter = menuItem.Filter;

                        if (openFileDialog.ShowDialog() == DialogResult.OK && File.Exists(openFileDialog.FileName))
                        {
                            menuItem.FileOpenAction(openFileDialog.FileName);
                        }
                    };

                    menu.DropDownItems.Add(open);
                }
            }
        }

        public void RegisterFileExports(ToolStripMenuItem menu, SaveFileDialog saveFileDialog)
        {
            foreach (Lazy<IPlugin, IPluginAttribute> plugin in Plugins)
            {
                if (plugin.Value.FileExportItems == null) { continue; }

                foreach (MenuItem menuItem in plugin.Value.FileExportItems)
                {
                    ToolStripMenuItem open = new ToolStripMenuItem
                    {
                        Text = $"{menuItem.Name}..."
                    };

                    open.Click += (sender, EventArgs) =>
                    {
                        saveFileDialog.Filter = menuItem.Filter;

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            menuItem.FileOpenAction(saveFileDialog.FileName);
                        }
                    };

                    menu.DropDownItems.Add(open);
                }
            }
        }

        public void RegisterFileSaveFors(ToolStripMenuItem menu, SaveFileDialog saveFileDialog)
        {
            foreach (Lazy<IPlugin, IPluginAttribute> plugin in Plugins)
            {
                if (plugin.Value.FileSaveForItems == null) { continue; }

                foreach (MenuItem menuItem in plugin.Value.FileSaveForItems)
                {
                    ToolStripMenuItem open = new ToolStripMenuItem
                    {
                        Text = $"{menuItem.Name}"
                    };

                    open.Click += (sender, EventArgs) =>
                    {
                        saveFileDialog.Filter = menuItem.Filter;

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            menuItem.FileOpenAction(saveFileDialog.FileName);
                        }
                    };

                    menu.DropDownItems.Add(open);
                }
            }
        }

        public void RegisterFileSaveAs(ToolStripMenuItem saveAs)
        {
            foreach (Lazy<IPlugin, IPluginAttribute> plugin in Plugins)
            {
                if (plugin.Value.FileSaveAsItems == null) { continue; }

                ToolStripMenuItem category = new ToolStripMenuItem(plugin.Value.Name);

                foreach (MenuItem menuItem in plugin.Value.FileSaveAsItems)
                {
                    ToolStripMenuItem tool = new ToolStripMenuItem
                    {
                        Text = menuItem.Name
                    };

                    tool.Click += (sender, EventArgs) =>
                    {
                        menuItem.ToolsAction();
                    };

                    category.DropDownItems.Add(tool);
                }

                saveAs.DropDownItems.Add(category);
            }
        }

        public void RegisterTools(ToolStripMenuItem tools)
        {
            foreach (Lazy<IPlugin, IPluginAttribute> plugin in Plugins)
            {
                if (plugin.Value.Tools == null) { continue; }

                ToolStripMenuItem category = new ToolStripMenuItem(plugin.Value.Name);

                foreach (MenuItem menuItem in plugin.Value.Tools)
                {
                    ToolStripMenuItem tool = new ToolStripMenuItem
                    {
                        Text = menuItem.Name
                    };

                    tool.Click += (sender, EventArgs) =>
                    {
                        menuItem.ToolsAction();
                    };

                    category.DropDownItems.Add(tool);
                }

                tools.DropDownItems.Add(category);
            }
        }

        public void RegisterProcessAlls(ToolStripMenuItem processAll, FolderBrowserDialog folderBrowserDialog)
        {
            foreach (Lazy<IPlugin, IPluginAttribute> plugin in Plugins)
            {
                if (plugin.Value.ProcessAllItems == null) { continue; }

                foreach (MenuItem menuItem in plugin.Value.ProcessAllItems)
                {
                    ToolStripMenuItem process = new ToolStripMenuItem
                    {
                        Text = menuItem.Name
                    };

                    process.Click += (sender, EventArgs) =>
                    {
                        //folderBrowserDialog.SelectedPath = (Properties.Settings.Default.LastBrowsedFolder ?? Environment.GetFolderPath(Environment.SpecialFolder.MyComputer));

                        int success = 0;
                        int fail = 0;

                        if (folderBrowserDialog.ShowDialog() == DialogResult.OK && Directory.Exists(folderBrowserDialog.SelectedPath))
                        {
                            //Properties.Settings.Default.LastBrowsedFolder = fbdBrowse.SelectedPath;
                            //Properties.Settings.Default.Save();

                            ToxicRagers.Helpers.IO.LoopDirectoriesIn(folderBrowserDialog.SelectedPath, (d) =>
                            {
                                foreach (FileInfo fi in d.GetFiles(menuItem.Mask))
                                {
                                    object result = menuItem.ProcessAction(fi.FullName);

                                    if (result != null) { success++; } else { fail++; }

                                    SceneManager.Current.UpdateProgress($"[{success}/{fail}] {fi.FullName.Replace(folderBrowserDialog.SelectedPath, "")}");
                                }
                            }
                            );

                            SceneManager.Current.UpdateProgress($"{menuItem.Name} processing complete. {success} success {fail} fail");
                        }
                    };

                    processAll.DropDownItems.Add(process);
                }
            }
        }

        public void Dispose()
        {
            catalog.Dispose();
            catalog = null;
            Plugins = null;
        }
    }
}