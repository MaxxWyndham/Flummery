using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flummery
{
    public partial class frmInterOpTest : Form
    {
        public frmInterOpTest()
        {
            InitializeComponent();
        }

        private void butSendToServer_Click(object sender, EventArgs e)
        {
            try
            {
                TcpClient client = new TcpClient("localhost", 666);

                var ns = client.GetStream();
                int numObjects = 0;
                int.TryParse(txtNumObjects.Text,out numObjects);
                string obj1Name = txtObj1Name.Text;
                string obj2Name = txtObj2Name.Text;
                int obj1NumVerts = 0;
                int.TryParse(txtObj1NumVerts.Text, out obj1NumVerts);
                int obj2NumVerts = 0;
                int.TryParse(txtObj2NumVerts.Text, out obj2NumVerts);
                int obj1NumFaces = 0;
                int.TryParse(txtObj1NumFaces.Text, out obj1NumFaces);
                int obj2NumFaces = 0;
                int.TryParse(txtObj2NumFaces.Text, out obj2NumFaces);

                using (BinaryWriter writer = new BinaryWriter(ns))
                {

                    writer.Write(numObjects);
                    if (numObjects > 0)
                    {
                        writer.Write(obj1Name.Length);
                        writer.Write(obj1Name.ToCharArray());
                        writer.Write(obj1NumVerts);
                        writer.Write(obj1NumFaces);
                    }
                    if (numObjects > 1)
                    {
                        writer.Write(obj2Name.Length);
                        writer.Write(obj2Name.ToCharArray());
                        writer.Write(obj2NumVerts);
                        writer.Write(obj2NumFaces);
                    }
                    for (int i = 2; i < numObjects; i++)
                    {
                        string name = "Object_" + i;

                        writer.Write(name.Length);
                        writer.Write(name.ToCharArray());
                        writer.Write(5346);
                        writer.Write(86487);
                    }
                }
                client.Close();
            }
            catch (Exception e2)
            {
                Console.WriteLine(e2.ToString());
            }
        }
    }
}
