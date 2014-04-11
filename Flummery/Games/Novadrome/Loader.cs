using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using ToxicRagers.Stainless.Formats;
using ToxicRagers.Novadrome.Formats;
using ToxicRagers.CarmageddonReincarnation.Helpers;

namespace Flummery.Games.Novadrome
{
    static class Loader
    {
        public static CNT LoadContent(string FileName, frmMain ui, ref string hints, ref List<Node> nodes)
        {
            //var tvOverview = (TreeView)ui.Controls["tvOverview"];
            //tvOverview.Nodes.Clear();

            FileInfo fi = new FileInfo(FileName);
            hints = AddHint(fi.DirectoryName, hints);

            var cnt = CNT.Load(FileName);

            ProcessCNT(cnt, ui, ref hints, ref nodes);

            //TreeNode ParentNode = tvOverview.Nodes.Add("ROOT");
            //TravelTree(cnt, ref ParentNode);
            //tvOverview.Nodes[0].Expand();
            //tvOverview.Nodes[0].Nodes[0].Expand();

            return cnt;
        }

        public static void TravelTree(CNT cnt, ref TreeNode node)
        {
            node = node.Nodes.Add(cnt.Name);

            foreach (var c in cnt.Children)
            {
                TravelTree(c, ref node);
            }

            node = node.Parent;
        }

        static void ProcessCNT(CNT cnt, frmMain ui, ref string hints, ref List<Node> nodes)
        {
            if (cnt.Model != null)
            {
                string path;
                var model = new MDL();
                var materials = new List<MTL>();
                var textures = new List<XT2>();

                if (ui.TryLoadOrFindFile(cnt.Model + ".mdl", "Novadrome MDL file", ".mdl", out path, hints.Split(';')))
                {
                    hints = AddHint(path.Substring(0, path.LastIndexOf("\\")), hints);
                    model = MDL.Load(path);

                    Console.WriteLine("Loading MDL: \"{0}\".  Faces {1}  Verts {2}", model.Name, model.FaceCount, model.VertexCount);

                    foreach (var material in model.Materials)
                    {
                        if (ui.TryLoadOrFindFile(material.Name + ".mtl", "Novadrome Material", "*.mtl", out path, hints.Split(';')))
                        {
                            hints = AddHint(path.Substring(0, path.LastIndexOf("\\")), hints);
                            materials.Add(MTL.Load(path));
                        }
                        else
                        {
                            return;
                        }
                    }

                    int materialIndex = 0;

                    foreach (var material in materials)
                    {
                        string fileName = material.Textures[material.Textures.Count - 1] + ".xt2";

                        if (fileName != ".xt2")
                        {
                            if (ui.TryLoadOrFindFile(fileName, "Novadrome Texture", "*.xt2", out path, hints.Split(';')))
                            {
                                textures.Add(XT2.Load(path));
                            }
                            else
                            {
                                return;
                            }

                            var texture = textures[textures.Count - 1];

                            int textureID = 0;
                            Texture.CreateTexture(out textureID, texture.Name, texture.Format, texture.mipMaps[0].Width, texture.mipMaps[0].Height, texture.mipMaps[0].Data);

                            var vl = model.GetTriangleStrip(materialIndex);

                            Vertex[] v = new Vertex[vl.Count];

                            for (int i = 0; i < v.Length; i++)
                            {
                                //v[i].Position = new OpenTK.Vector3(vl[i].Position.X, vl[i].Position.Y, vl[i].Position.Z);
                                v[i].Normal = new OpenTK.Vector3(vl[i].Normal.X, vl[i].Normal.Y, vl[i].Normal.Z);
                                v[i].UV = new OpenTK.Vector2(vl[i].UV.X, vl[i].UV.Y);

                                var x = vl[i].Position * cnt.CombinedTransform;
                                v[i].Position = new OpenTK.Vector3(x.X, x.Y, x.Z);
                            }

                            VertexBuffer vbo = new VertexBuffer(model.Name);
                            vbo.SetData(v, (model.GetMaterialMode(materialIndex) == "trianglestrip" ? OpenTK.Graphics.OpenGL.PrimitiveType.TriangleStrip : OpenTK.Graphics.OpenGL.PrimitiveType.Triangles));

                            Node n = new Node(model.Name, vbo, textureID);
                            nodes.Add(n);
                        }

                        materialIndex++;
                    }
                }
            }

            foreach (CNT subcnt in cnt.Children)
            {
                ProcessCNT(subcnt, ui, ref hints, ref nodes);
            }
        }

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
