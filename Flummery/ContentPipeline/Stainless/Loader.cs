using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using ToxicRagers.Helpers;
using ToxicRagers.Stainless.Formats;
using ToxicRagers.CarmageddonReincarnation.Formats;

namespace Flummery.Games
{
    static class Loader
    {
        //public static CNT LoadContent(string FileName, frmMain ui, ref string hints, ref List<Node> nodes, bool bReset = false)
        //{
        //    var tvOverview = (TreeView)ui.Controls.Find("tvNodes", true)[0];
        //    TreeNode ParentNode;

        //    if (bReset)
        //    {
        //        nodes.Clear();
        //        tvOverview.Nodes.Clear();
        //    }

        //    ParentNode = (tvOverview.Nodes.Count == 0 ? tvOverview.Nodes.Add("ROOT") : tvOverview.Nodes[0]);

        //    FileInfo fi = new FileInfo(FileName);
        //    hints = AddHint(fi.DirectoryName, hints);

        //    var cnt = CNT.Load(FileName);

        //    ProcessCNT(cnt, ui, ref hints, ref nodes);
            
        //    TravelTree(cnt, ref ParentNode);
        //    tvOverview.Nodes[0].Expand();
        //    tvOverview.Nodes[0].Nodes[0].Expand();

        //    return cnt;
        //}

        public static void TravelTree(CNT cnt, ref TreeNode node)
        {
            node = node.Nodes.Add(cnt.Name);

            foreach (var c in cnt.Children)
            {
                TravelTree(c, ref node);
            }

            node = node.Parent;
        }

        //static void ProcessCNT(CNT cnt, frmMain ui, ref string hints, ref List<Node> nodes)
        //{
        //    if (cnt.Model != null)
        //    {
        //        string path;
        //        var model = new MDL();
        //        var materials = new List<ToxicRagers.Helpers.Material>();

        //        if (ui.TryLoadOrFindFile(cnt.Model + ".mdl", "Stainless MDL file", ".mdl", out path, hints.Split(';')))
        //        {
        //            hints = AddHint(path.Substring(0, path.LastIndexOf("\\")), hints);
        //            model = MDL.Load(path);

        //            Console.WriteLine("Loading MDL: \"{0}\".  Faces {1}  Verts {2}", model.Name, model.FaceCount, model.VertexCount);

        //            foreach (var mesh in model.Meshes)
        //            {
        //                if (ui.TryLoadOrFindFile(mesh.Name + ".mt2;" + mesh.Name + ".mtl", "Stainless Material", "*.mt2;*.mtl", out path, hints.Split(';')))
        //                {
        //                    hints = AddHint(path.Substring(0, path.LastIndexOf("\\")), hints);

        //                    if (path.EndsWith("mtl", StringComparison.CurrentCultureIgnoreCase))
        //                    {
        //                        materials.Add(MTL.Load(path));
        //                    }
        //                    else
        //                    {
        //                        materials.Add(MT2.Load(path));
        //                    }

        //                }
        //                else
        //                {
        //                    return;
        //                }
        //            }

        //            int materialIndex = 0;

        //            foreach (var material in materials)
        //            {
        //                var mat = (material as MT2);
        //                string fileName = (mat != null ? mat.DiffuseColour : (material as MTL).Textures[0]) + ".tdx";

        //                int textureID = 0;

        //                if (fileName != ".tdx")
        //                {
        //                    if (ui.TryLoadOrFindFile(fileName, "Texture", "*.tdx", out path, hints.Split(';')))
        //                    {
        //                        var texture = TDX.Load(path);
        //                        Texture.CreateTexture(out textureID, texture.Name, texture.Format.ToString(), texture.MipMaps[0].Width, texture.MipMaps[0].Height, texture.MipMaps[0].Data);
        //                    }
        //                }

        //                //var vl = model.GetTriangleStrip(materialIndex);

        //                //Vertex[] v = new Vertex[vl.Count];

        //                //for (int i = 0; i < v.Length; i++)
        //                //{
        //                //    v[i].Position = new OpenTK.Vector3(vl[i].Position.X, vl[i].Position.Y, vl[i].Position.Z);
        //                //    v[i].Normal = new OpenTK.Vector3(vl[i].Normal.X, vl[i].Normal.Y, vl[i].Normal.Z);
        //                //    v[i].UV = new OpenTK.Vector2(vl[i].UV.X, vl[i].UV.Y);
        //                //}

        //                //VertexBuffer vbo = new VertexBuffer(model.Name);
        //                //vbo.SetData(v);

        //                //Node n = new Node(model.Name, vbo, textureID);
        //                //nodes.Add(n);

        //                materialIndex++;
        //            }
        //        }
        //    }

        //    foreach (CNT subcnt in cnt.Children)
        //    {
        //        ProcessCNT(subcnt, ui, ref hints, ref nodes);
        //    }
        //}

        static string AddHint(string hint, string hints)
        {
            var list = new List<string>(hints.Split(';'));
            int index = list.IndexOf(hint);

            if (index > -1) { list.RemoveAt(index); }
            list.Insert(0, hint);

            return string.Join(";", list.ToArray());
        }
    }
}
