using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using ToxicRagers.Helpers;

namespace Flummery.InterOp
{
    public class InterOpServer
    {
        public StringBuilder log = new StringBuilder();
        protected int Port;
        private TcpListener listener;
        bool ServerRunning = false;
        Thread ServerThread;

        public InterOpServer(int port)
        {
            Port = port;
        }

        public bool IsThreadRunning()
        {
            return ServerThread != null && ServerThread.IsAlive;
        }
        public void StartServer()
        {
            log.AppendLine("Starting connection on port " + Port);
            ServerRunning = true;
            ServerThread = new Thread(this.Listen);
            ServerThread.Start();

        }
        public void StopServer()
        {
            log.AppendLine("Stopping server...");
            ServerRunning = false;
            if (listener != null) listener.Stop();
        }
        public void Listen(object data)
        {

            listener = new TcpListener(IPAddress.Any, Port);
            listener.Start();

            

            while(ServerRunning)
            {
                log.AppendLine("Waiting for connection...");
                try
                {
                    TcpClient client = listener.AcceptTcpClient();

                    log.AppendLine("Connection accepted!");
                    NetworkStream ns = client.GetStream();

                    try
                    {
                        using (BinaryReader reader = new BinaryReader(ns))
                        {
                            //var bytes = reader.ReadBytes(100);
                            //reader.BaseStream.Seek(0, SeekOrigin.Begin);
                            int numObjects = reader.ReadInt32();
                            Model model = new Model();
                            log.AppendLine("Num Objects = " + numObjects);
                            for (int i = 0; i < numObjects; i++)
                            {
                                int nameLength = reader.ReadInt32();
                                byte[] nameBytes = reader.ReadBytes(nameLength);
                                Vector3 pos = new Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
                                string name = Encoding.ASCII.GetString(nameBytes);
                                int numVerts = reader.ReadInt32();
                                List<Vector3> verts = new List<Vector3>();

                                model.Name = name;
                                ModelMesh mdlMesh = new ModelMesh();
                                mdlMesh.Name = name;
                                ModelMeshPart part = new ModelMeshPart();
                                part.Material = new Material() { Name = name+"_Mat", Texture = new Texture() };
                                
                                
                                for (int v = 0; v < numVerts; v++)
                                {
                                    part.AddVertex(new OpenTK.Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle()),
                                                   new OpenTK.Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle()),
                                                   new OpenTK.Vector2(0.0f, 0.0f),false);
                                }
                                int numFaces = reader.ReadInt32();
                                List<int> faces = new List<int>();
                                for(int f =0; f < numFaces; f++)
                                {
                                    int numFaceVerts = reader.ReadInt32();
                                    
                                    int firstVert = -1;
                                    int secondVert = -1;
                                    for(int fv = 0; fv < numFaceVerts; fv++)
                                    {
                                        int vertIndex = reader.ReadInt32();
                                        if (firstVert == -1) firstVert = vertIndex;
                                        else if (secondVert == -1) secondVert = vertIndex;
                                        else
                                        {
                                            faces.Add(firstVert);
                                            faces.Add(secondVert);
                                            faces.Add(vertIndex);
                                            part.AddFace(firstVert, secondVert, vertIndex);
                                            //firstVert = secondVert;
                                            secondVert = vertIndex;
                                        }
                                        
                                    }
                                    
                                }
                                mdlMesh.AddModelMeshPart(part);
                                int boneIndex = model.AddMesh(mdlMesh);
                                model.SetTransform(OpenTK.Matrix4.CreateTranslation(pos.X, pos.Y, pos.Z), boneIndex);
                                model.SetName(name, boneIndex);
                                log.AppendLine("Object \"" + name + "\" (" + i + ") has " + numVerts + " verts and " + numFaces + " faces");
                            }
                             SceneManager.Current.Add(model);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                    finally
                    {
                        if(ns != null) ns.Close();
                        if(client!=null) client.Close();
                    }
                }
                catch(SocketException e)
                {
                    if(e.SocketErrorCode == SocketError.Interrupted)
                    {
                        log.AppendLine("Connection aborted");
                    }
                }
            }
            listener.Stop();
        }
    }
}
