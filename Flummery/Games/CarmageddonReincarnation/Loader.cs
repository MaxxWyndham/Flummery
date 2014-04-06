using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using ToxicRagers.CarmageddonReincarnation.Formats;
using ToxicRagers.CarmageddonReincarnation.Helpers;

namespace Flummery.Games.CarmageddonReincarnation
{
    static class Loader
    {
        public static void LoadContent(string FileName, frmMain ui, ref string hints, ref List<Node> nodes)
        {
            nodes.Clear();

            FileInfo fi = new FileInfo(FileName);
            hints = AddHint(fi.DirectoryName, hints);

            var accessory = CNT.Load(FileName);

            ProcessCNT(accessory, ui, ref hints, ref nodes);
        }

        static void ProcessCNT(CNT cnt, frmMain ui, ref string hints, ref List<Node> nodes)
        {
            if (cnt.Model != null)
            {
                string path;
                var model = new MDL();
                var materials = new List<Material>();
                var textures = new List<TDX>();

                if (ui.TryLoadOrFindFile(cnt.Model + ".mdl", "Carmageddon ReinCARnation MDL file", ".mdl", out path, hints.Split(';')))
                {
                    hints = AddHint(path.Substring(0, path.LastIndexOf("\\")), hints);
                    model = MDL.Load(path);

                    Console.WriteLine("Loading MDL: \"{0}\".  Faces {1}  Verts {2}", model.Name, model.FaceCount, model.VertexCount);

                    foreach (var material in model.Materials)
                    {
                        if (ui.TryLoadOrFindFile(material.Name + ".mt2;" + material.Name + ".mtl", "Carmageddon ReinCARnation Material", "*.mt2;*.mtl", out path, hints.Split(';')))
                        {
                            hints = AddHint(path.Substring(0, path.LastIndexOf("\\")), hints);

                            if (path.EndsWith("mtl", StringComparison.CurrentCultureIgnoreCase))
                            {
                                materials.Add(MTL.Load(path));
                            }
                            else
                            {
                                materials.Add(MT2.Load(path));
                            }

                        }
                        else
                        {
                            return;
                        }
                    }

                    int materialIndex = 0;

                    foreach (var material in materials)
                    {
                        var mat = (material as MT2);
                        string fileName = (mat != null ? mat.DiffuseColour : (material as MTL).Texture) + ".tdx";

                        if (fileName != ".tdx")
                        {
                            if (ui.TryLoadOrFindFile(fileName, "Carmageddon ReinCARnation Texture", "*.tdx", out path, hints.Split(';')))
                            {
                                textures.Add(TDX.Load(path));
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
