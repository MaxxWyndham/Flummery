using System.Collections.Generic;

namespace Flummery.Plugin
{
    public interface IPlugin
    {
        string Name { get; }

        List<string> Contexts { get; }

        List<MenuItem> FileOpenItems { get; }

        List<MenuItem> FileImportItems { get; }

        List<MenuItem> FileSaveForItems { get; }

        List<MenuItem> FileSaveAsItems { get; }

        List<MenuItem> FileExportItems { get; }

        List<MenuItem> Tools { get; }

        List<MenuItem> ProcessAllItems { get; }

        void RegisterEvents();
    }
}
