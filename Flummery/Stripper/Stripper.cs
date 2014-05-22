using System;
using System.Collections.Generic;

namespace Flummery.Stripper
{
    public class Stripper
    {
        Adjacency adjacency;
        bool oneSided;
        bool connectAll;
        int faces;
        int[] data;
        bool[] tags;

        List<List<int>> strips;

        public List<List<int>> Strips { get { return strips; } }
        public bool OneSided { get { return oneSided; } set { oneSided = value; } }
        public bool ConnectAllStrips { get { return connectAll; } set { connectAll = value; } }

        public Stripper(int Faces, int[] Data)
        {
            strips = new List<List<int>>();

            faces = Faces;
            data = Data;

            adjacency = new Adjacency(faces, data);
            adjacency.CreateDatabase();
        }

        public void ShakeItBaby()
        {
            tags = new bool[faces];
            int[] connectivity = new int[faces];

            for (int i = 0; i < faces; i++) { connectivity[i] = i; }

            int nStrips = 0;
            int totalFaces = 0;
            int index = 0;

            while (totalFaces != faces)
            {
                while (tags[index]) { index++; }
                int firstFace = connectivity[index];

                totalFaces += ComputeBestStrip(firstFace);

                nStrips++;
            }

            if (connectAll) { MergeStrips(); }
        }

        public int ComputeBestStrip(int face)
        {
            List<int>[] strip = new List<int>[3];
            List<int>[] faces = new List<int>[3];
            int[] length = new int[3];

            int[] firstLength = new int[3];
            int[] refs0 = new int[3];
            int[] refs1 = new int[3];
            refs0[0] = adjacency.Faces[face].Ref[0];
            refs1[0] = adjacency.Faces[face].Ref[1];

            refs0[1] = adjacency.Faces[face].Ref[2];
            refs1[1] = adjacency.Faces[face].Ref[0];

            refs0[2] = adjacency.Faces[face].Ref[1];
            refs1[2] = adjacency.Faces[face].Ref[2];

            for (int j = 0; j < 3; j++)
            {
                strip[j] = new List<int>();
                faces[j] = new List<int>();

                bool[] ltags = new bool[tags.Length];
                Array.Copy(tags, ltags, tags.Length);

                length[j] = TrackStrip(face, refs0[j], refs1[j], ref strip[j], ref faces[j], ltags);
                firstLength[j] = length[j];

                for (int i = 0; i < length[j] / 2; i++)
                {
                    int t = strip[j][i];
                    strip[j][i] = strip[j][length[j] - i - 1];
                    strip[j][length[j] - i - 1] = t;
                }

                for (int i = 0; i < (length[j] - 2) / 2; i++)
                {
                    int t = faces[j][i];
                    faces[j][i] = faces[j][length[j] - i - 3];
                    faces[j][length[j] - i - 3] = t;
                }

                int newRef0 = strip[j][length[j] - 3];
                int newRef1 = strip[j][length[j] - 2];
                int extraLength = TrackStrip(face, newRef0, newRef1, ref strip[j], ref faces[j], ltags, length[j] - 3);
                length[j] += extraLength - 3;
            }

            int bestLength = length[0];
            int best = 0;
            if (bestLength < length[1]) { bestLength = length[1]; best = 1; }
            if (bestLength < length[2]) { bestLength = length[2]; best = 2; }

            int nFaces = bestLength - 2;

            for (int j = 0; j < bestLength - 2; j++) { tags[faces[best][j]] = true; }

            if (oneSided && (firstLength[best] & 1) == 1)
            {
                if (bestLength == 3 || bestLength == 4)
                {
                    strip[best][1] ^= strip[best][2];
                    strip[best][2] ^= strip[best][1];
                    strip[best][1] ^= strip[best][2];
                }
                else
                {
                    for (int i = 0; i < bestLength / 2; i++)
                    {
                        int t = strip[best][i];
                        strip[best][i] = strip[best][bestLength - i - 1];
                        strip[best][length[best] - i - 1] = t;
                    }

                    if (((bestLength - firstLength[best]) & 1) == 1)
                    {
                        strip[best].Insert(0, strip[best][0]);
                        bestLength++;
                    }
                }
            }

            strips.Add(new List<int>(strip[best]));

            return nFaces;
        }

        public int TrackStrip(int face, int oldest, int middle, ref List<int> strip, ref List<int> faces, bool[] tags, int offset = 0)
        {
            int length = 2;
            int faceCount = 0;
            if (0 + offset < strip.Count) { strip[0 + offset] = oldest; } else { strip.Add(oldest); }
            if (1 + offset < strip.Count) { strip[1 + offset] = middle; } else { strip.Add(middle); }

            bool bDoTheStrip = true;

            while (bDoTheStrip)
            {
                int newest = adjacency.Faces[face].OppositeVertex(oldest, middle);
                if (length + offset < strip.Count) { strip[length + offset] = newest; } else { strip.Add(newest); }
                length++;

                if (faceCount + offset < faces.Count) { faces[faceCount + offset] = face; } else { faces.Add(face); }
                faceCount++;
                
                tags[face] = true;

                byte curEdge = adjacency.Faces[face].FindEdge(middle, newest);
                int link = adjacency.Faces[face].Tri[curEdge];

                if (link == -1)
                {
                    bDoTheStrip = false;
                }
                else
                {
                    face = link;
                    if (tags[face]) { bDoTheStrip = false; }
                }

                oldest = middle;
                middle = newest;
            }

            return length;
        }

        public void MergeStrips()
        {
            bool bFirst = true;
            int previousStrip = 0;
            List<int> mergedStrip = new List<int>();
            List<bool> removeOldStrip = new List<bool>();

            for (int k = 0; k < strips.Count; k++)
            {
                if (strips[k].Count == 3)
                {
                    // We don't want to add single triangles into our tristrips
                    removeOldStrip.Add(false);
                    continue;
                }

                if (!bFirst)
                {
                    int lastRef = strips[previousStrip][strips[previousStrip].Count - 1];
                    int firstRef = strips[k][0];

                    mergedStrip.Add(lastRef);
                    mergedStrip.Add(firstRef);

                    if (oneSided)
                    {
                        if ((mergedStrip.Count & 1) == 1)
                        {
                            int secondRef = strips[k][1];

                            if (firstRef != secondRef)
                            {
                                mergedStrip.Add(firstRef);
                            }
                            else
                            {
                                strips[k].RemoveAt(0);
                            }
                        }
                    }
                }

                mergedStrip.AddRange(strips[k]);

                bFirst = false;
                previousStrip = k;
                removeOldStrip.Add(true);
            }

            for (int i = strips.Count - 1; i >= 0; i--)
            {
                if (removeOldStrip[i]) { strips.RemoveAt(i); }
            }

            strips.Insert(0, mergedStrip);
        }
    }
}
