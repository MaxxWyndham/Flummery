using System;
using System.Windows.Forms;

namespace Flummery.Plugin
{
    public class MenuItem
    {
        public string Name { get; set; }

        public string Filter { get; set; }

        public Action<string> FileOpenAction { get; set; }

        public Action ToolsAction { get; set; }

        public Func<string, object> ProcessAction { get; set; }

        public string Mask { get; set; }
    }
}
