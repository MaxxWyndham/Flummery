using System;
using System.ComponentModel.Composition;

namespace Flummery.Plugin
{
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class PluginAttribute : ExportAttribute, IPluginAttribute
    {
        public PluginAttribute(string attributeName)
            : base(typeof(IPlugin))
        {
            Name = attributeName;
        }

        public string Name { get; private set; }
    }
}
