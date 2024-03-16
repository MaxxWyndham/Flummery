using Flummery.Core;
using Flummery.Plugin.TDR2000.ContentPipeline;

using ToxicRagers.TDR2000.Formats;

namespace Flummery.Plugin.TDR2000
{
    [Plugin("TDR2000")]
    public class TDR2000Plugin : IPlugin
    {
        public string Name { get; } = "TDR2000";

        public List<string> Contexts { get; } = new List<string> { "TDR2000" };

        public List<MenuItem> FileOpenItems { get; } = new List<MenuItem>
        {
            new MenuItem
            {
                Name = "Hierarchy",
                Filter = "TDR2000 Hierarchy (*.hie)|*.hie",
                FileOpenAction = TDR2000.OpenHierarchy
            }
        };

        public List<MenuItem> FileImportItems { get; } = new List<MenuItem>
        {
            new MenuItem
            {
                Name = "Torus MSHS File",
                Filter = "Torus MSHS files (*.msh;*.mshs)|*.msh;*.mshs",
                FileOpenAction = TDR2000.ImportMSHS
            }
        };

        public List<MenuItem> FileSaveForItems { get; } = new List<MenuItem>
        {
            new MenuItem
            {
                Name = "TDR2000",
                Filter = "Torus HIE files (*.hie)|*.hie",
                FileOpenAction = TDR2000.SaveForTDR2000
            }
        };

        public List<MenuItem> FileSaveAsItems { get; } = null;

        public List<MenuItem> FileExportItems { get; } = new List<MenuItem>
        {
            new MenuItem
            {
                Name = "Torus HIE File",
                Filter = "TDR2000 Hierarchy (*.hie)|*.hie",
                FileOpenAction = TDR2000.ExportHIE
            },
            new MenuItem
            {
                Name = "Torus MSHS File",
                Filter = "Torus MSHS files (*.msh;*.mshs)|*.msh;*.mshs",
                FileOpenAction = TDR2000.ExportMSHS
            }
        };

        public List<MenuItem> Tools { get; } = new List<MenuItem>
        {
            new MenuItem
            {
                Name = "Remove LOD from Vehicle",
                ToolsAction = TDR2000.RemoveLODFromVehicle
            }
        };

        public List<MenuItem> ProcessAllItems { get; } = new List<MenuItem>
        {
            new MenuItem
            {
                Name = "DCOL files",
                Mask = "*.dcol",
                ProcessAction = DCOL.Load
            },
            new MenuItem
            {
                Name = "MSH files",
                Mask = "*.msh?",
                ProcessAction = MSHS.Load
            },
            new MenuItem
            {
                Name = "HIE files",
                Mask = "*.hie",
                ProcessAction = HIE.Load
            }
        };

        public void RegisterEvents()
        {
        }
    }

    public static class TDR2000
    {
        public static void OpenHierarchy(string path)
        {
            SceneManager.Current.Reset();
            SceneManager.Current.Content.Load<Model, HIEImporter>(Path.GetFileNameWithoutExtension(path), Path.GetDirectoryName(path), true);

            SceneManager.Current.SetContext("TDR2000", ContextMode.Generic);
        }

        public static void ImportMSHS(string path)
        {
            SceneManager.Current.Content.Load<Model, MSHSImporter>(Path.GetFileNameWithoutExtension(path), Path.GetDirectoryName(path), true);

            SceneManager.Current.UpdateProgress($"Imported {Path.GetFileName(path)}");
        }

        public static void SaveForTDR2000(string path)
        {
            HIEExporter hx = new HIEExporter();
            hx.Export(SceneManager.Current.Models[0], path);

            MSHSExporter mx = new MSHSExporter();
            mx.Export(SceneManager.Current.Models[0], Path.GetDirectoryName(path));

            SceneManager.Current.UpdateProgress($"{Path.GetFileName(path)} saved successfully");
        }

        public static void ExportHIE(string path)
        {
            HIEExporter hx = new HIEExporter();
            hx.Export(SceneManager.Current.Models[0], path);

            SceneManager.Current.UpdateProgress($"Exported {Path.GetFileName(path)}");
        }

        public static void ExportMSHS(string path)
        {
            MSHSExporter mx = new MSHSExporter();
            mx.Export(SceneManager.Current.Models[0], path);

            SceneManager.Current.UpdateProgress($"Exported {Path.GetFileName(path)}");
        }

        public static void RemoveLODFromVehicle()
        {
            if (SceneManager.Current.Models.Count == 0) { return; }

            for (int i = SceneManager.Current.Models[0].Bones.Count - 1; i >= 0; i--)
            {
                ModelBone bone = SceneManager.Current.Models[0].Bones[i];

                if (bone.Name.Contains("LOD"))
                {
                    string name = bone.Name.Replace("_", "");

                    if (name.Substring(name.IndexOf("LOD") + 3, 1) != "1")
                    {
                        SceneManager.Current.Models[0].RemoveBone(bone.Index);
                    }
                }
            }

            SceneManager.Current.Change(ChangeType.Munge, ChangeContext.Model, -1);
        }
    }
}
