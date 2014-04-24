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
