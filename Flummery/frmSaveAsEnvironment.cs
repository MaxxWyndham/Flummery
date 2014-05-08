using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Flummery
{
    public partial class frmSaveAsEnvironment : Form
    {
        public frmSaveAsEnvironment()
        {
            InitializeComponent();

            //var d = new DirectoryInfo(fbdBrowse.SelectedPath);

            //if (!Directory.Exists(fbdBrowse.SelectedPath + "\\levels\\Airport\\")) { Directory.CreateDirectory(fbdBrowse.SelectedPath + "\\levels\\Airport\\"); }

            //using (StreamWriter w = File.CreateText(fbdBrowse.SelectedPath + "\\environment.lol"))
            //{
            //    w.WriteLine("module((...), environment_config, package.seeall)");
            //    w.WriteLine("name = txt.fe_environment_" + d.Name.ToLower() + "_ucase");
            //}

            //using (StreamWriter w = File.CreateText(fbdBrowse.SelectedPath + "\\environment.txt"))
            //{
            //    w.WriteLine("[LUMP]");
            //    w.WriteLine("environment");
            //}

            //using (StreamWriter w = File.CreateText(fbdBrowse.SelectedPath + "\\levels\\Airport\\level.txt"))
            //{
            //    w.WriteLine("[LUMP]");
            //    w.WriteLine("level");
            //    w.WriteLine();
            //    w.WriteLine("[RACE_NAMES]");
            //    w.WriteLine("txt.fe_level_airport_race_1_ucase");
            //    w.WriteLine();
            //    w.WriteLine("[RACE_WRITEUP]");
            //    w.WriteLine("txt.fe_level_airport_race_1_writeup");
            //    w.WriteLine();
            //    w.WriteLine("[RACE_IMAGES]");
            //    w.WriteLine("race\\" + d.Name + "_Airport_race_01");
            //    w.WriteLine();
            //    w.WriteLine("[RACE_BACKGROUNDS]");
            //    w.WriteLine("background_list\\" + d.Name + "_Airport_race_01");
            //    w.WriteLine();
            //    w.WriteLine("[VERSION]");
            //    w.WriteLine("2.500000");
            //    w.WriteLine();
            //    w.WriteLine("[RACE_LAYERS]");
            //    w.WriteLine("race01");
            //    w.WriteLine();
            //    w.WriteLine("[LUA_SCRIPTS]");
            //    w.WriteLine("setup.lua");
            //    w.WriteLine();
            //}

            //var cx = new CNTExporter();
            //cx.SetExportOptions(new { Scale = new Vector3(3.0f, 3.0f, -3.0f) });
            //cx.Export(scene.Models[0], fbdBrowse.SelectedPath + "\\levels\\Airport\\level.cnt");

            //var mx = new MDLExporter();
            //mx.SetExportOptions(new { Transform = Matrix4.CreateScale(3.0f, 3.0f, -3.0f) });
            //mx.Export(scene.Models[0], fbdBrowse.SelectedPath + "\\levels\\Airport\\");

            //foreach (var material in scene.Textures)
            //{
            //    var tx = new TDXExporter();
            //    tx.SetExportOptions(new { Format = ToxicRagers.Helpers.D3DFormat.DXT5 });
            //    tx.Export(material, fbdBrowse.SelectedPath + "\\levels\\Airport\\");
            //}
        }
    }
}
