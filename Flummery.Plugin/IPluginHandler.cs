using System;
using System.Collections.Generic;

namespace Flummery.Plugin
{
    public interface IPluginHandler
    {
        IEnumerable<Lazy<IPlugin, IPluginAttribute>> Plugins { get; set; }

        void InitialiseModules();
    }
}
