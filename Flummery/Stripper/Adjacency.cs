using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Flummery.Stripper
{
    public class Adjacency
    {
        int currentFace = 0;
        int facecount;
        int edgecount = 0;
        AdjTriangle[] faces;
        AdjEdge[] edges;

        public AdjTriangle[] Faces
        {
            get { return faces; }
        }

        public Adjacency(int faceCount, int[] indexBuffer)
        {
            facecount = faceCount;
            faces = new AdjTriangle[faceCount];
            edges = new AdjEdge[faceCount * 3];

            for (int i = 0; i < faceCount; i++)
            {
                AddTriangle(
                    indexBuffer[i * 3 + 0], 
                    indexBuffer[i * 3 + 2], // + 1
                    indexBuffer[i * 3 + 1]  // + 2 to reverse winding order of strips
                );
            }
        }

        public void AddTriangle(int a, int b, int c)
        {
            faces[currentFace] = new AdjTriangle();
            faces[currentFace].Ref[0] = a;
            faces[currentFace].Ref[1] = b;
            faces[currentFace].Ref[2] = c;

            faces[currentFace].Tri[0] = -1;
            faces[currentFace].Tri[1] = -1;
            faces[currentFace].Tri[2] = -1;

            if (a < b) { AddEdge(a, b, currentFace); }
            else {       AddEdge(b, a, currentFace); }

            if (a < c) { AddEdge(a, c, currentFace); }
            else {       AddEdge(c, a, currentFace); }

            if (b < c) { AddEdge(b, c, currentFace); }
            else {       AddEdge(c, b, currentFace); }

            currentFace++;
        }

        public void AddEdge(int a, int b, int face)
        {
            edges[edgecount] = new AdjEdge();
            edges[edgecount].Ref0 = a;
            edges[edgecount].Ref1 = b;
            edges[edgecount].Face = face;
            edgecount++;
        }

        public void CreateDatabase()
        {
            var sorted = edges.OrderBy(e => e.Ref1).ThenBy(e => e.Ref0).ThenBy(e => e.Face).ToArray();

            int lastRef0 = sorted[0].Ref0;
            int lastRef1 = sorted[0].Ref1;
            int count = 0;
            int[] tmp = new int[3];

            for (int i = 0; i < edgecount; i++)
            {
                int face = sorted[i].Face;
                int ref0 = sorted[i].Ref0;
                int ref1 = sorted[i].Ref1;

                if (ref0 == lastRef0 && ref1 == lastRef1)
                {
                    tmp[count++] = face;
                    if (count == 3)
                    {
                        return;
                        //throw new NotImplementedException("Gah");
                    }
                }
                else
                {
                    if (count == 2)
                    {
                        if (!UpdateLink(tmp[0], tmp[1], lastRef0, lastRef1))
                        {
                            throw new NotImplementedException("Urk");
                        }
                    }

                    count = 0;
                    tmp[count++] = face;
                    lastRef0 = ref0;
                    lastRef1 = ref1;
                }
            }

            if (count == 2) { UpdateLink(tmp[0], tmp[1], lastRef0, lastRef1); }
        }

        public bool UpdateLink(int tri1, int tri2, int ref0, int ref1)
        {
            var t1 = faces[tri1];
            var t2 = faces[tri2];

            var edge0 = t1.FindEdge(ref0, ref1); if (edge0 == 255) { return false; }
            var edge1 = t2.FindEdge(ref0, ref1); if (edge1 == 255) { return false; }

            t1.Tri[edge0] = tri2;// | ((int)edge1 << 30);
            t2.Tri[edge1] = tri1;// | ((int)edge0 << 30);

            return true;
        }
    }

    [DebuggerDisplay("VRef={Ref[0]} {Ref[1]} {Ref[2]} ATri={Tri[0]} {Tri[1]} {Tri[2]}")]
    public class AdjTriangle
    {
        int[] vRef = new int[3];
        int[] tRef = new int[3];

        public int[] Ref { get { return vRef; } }
        public int[] Tri { get { return tRef; } }

        public byte FindEdge(int ref0, int ref1)
        {
            byte edge = 255;

                 if (vRef[0] == ref0 && vRef[1] == ref1) { edge = 0; }
            else if (vRef[0] == ref1 && vRef[1] == ref0) { edge = 0; }
            else if (vRef[0] == ref0 && vRef[2] == ref1) { edge = 1; }
            else if (vRef[0] == ref1 && vRef[2] == ref0) { edge = 1; }
            else if (vRef[1] == ref0 && vRef[2] == ref1) { edge = 2; }
            else if (vRef[1] == ref1 && vRef[2] == ref0) { edge = 2; }

            return edge;
        }

        public int OppositeVertex(int ref0, int ref1)
        {
            int vref = -1;

                 if (vRef[0] == ref0 && vRef[1] == ref1) { vref = vRef[2]; }
            else if (vRef[0] == ref1 && vRef[1] == ref0) { vref = vRef[2]; }
            else if (vRef[0] == ref0 && vRef[2] == ref1) { vref = vRef[1]; }
            else if (vRef[0] == ref1 && vRef[2] == ref0) { vref = vRef[1]; }
            else if (vRef[1] == ref0 && vRef[2] == ref1) { vref = vRef[0]; }
            else if (vRef[1] == ref1 && vRef[2] == ref0) { vref = vRef[0]; }

            return vref;
        }
    }

    [DebuggerDisplay("Ref0={Ref0} Ref1={Ref1} FaceNb={Face}")]
    public class AdjEdge
    {
        int refa, refb, face;

        public int Ref0
        {
            get { return refa; }
            set { refa = value; }
        }

        public int Ref1
        {
            get { return refb; }
            set { refb = value; }
        }

        public int Face
        {
            get { return face; }
            set { face = value; }
        }
    }
}
