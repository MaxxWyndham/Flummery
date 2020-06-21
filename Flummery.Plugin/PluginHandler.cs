using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;

namespace Flummery.Plugin
{
    [Export(typeof(IPluginHandler))]
    public class PluginHandler : IPluginHandler
    {
        [ImportMany(typeof(IPlugin), AllowRecomposition = true)]
        public IEnumerable<Lazy<IPlugin, IPluginAttribute>> Plugins { get; set; }

        [ImportMany(typeof(IMenu), AllowRecomposition = true)]
        public IEnumerable<Lazy<IMenu, IPluginAttribute>> Menus;

        AggregateCatalog catalog = new AggregateCatalog();

        public void InitialiseModules()
        {
            Plugins = new List<Lazy<IPlugin, IPluginAttribute>>();
            Menus = new List<Lazy<IMenu, IPluginAttribute>>();

            string pluginsFolder = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "plugins");

            if (!Directory.Exists(pluginsFolder)) { Directory.CreateDirectory(pluginsFolder); }

            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetCallingAssembly()));
            catalog.Catalogs.Add(new DirectoryCatalog(pluginsFolder, "*.dll"));

            CompositionContainer cc = new CompositionContainer(catalog);
            cc.ComposeParts(this);
        }

        public bool ContainsModule(string pluginName)
        {
            bool ret = false;

            foreach (var l in Plugins)
            {
                if (l.Metadata.Name == pluginName)
                {
                    ret = true;
                    break;
                }
            }

            return ret;
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

        public void Dispose()
        {
            catalog.Dispose();
            catalog = null;
            Plugins = null;
        }
    }
}