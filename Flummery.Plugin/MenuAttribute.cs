using System;
using System.ComponentModel.Composition;

namespace Flummery.Plugin
{
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class MenuAttribute : ExportAttribute, IPluginAttribute
    {
        public MenuAttribute(string name)
            : base(typeof(MenuItem))
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}