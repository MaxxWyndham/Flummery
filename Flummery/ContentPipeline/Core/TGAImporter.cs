using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace Flummery.ContentPipeline.Core
{
    class TGAImporter : ContentImporter
    {
        public override string GetExtension() { return "tga"; }

        public override Asset Import(string path)
        {
            Texture texture = new Texture();

            texture.FileName = path;

            var fi = new FileInfo(path);

            using (var br = new BinaryReader(fi.OpenRead()))
            {
                byte idLength = br.ReadByte();
                byte colourMapType = br.ReadByte();
                byte imageType = br.ReadByte();

                if (idLength > 0) { throw new NotImplementedException("No support for TGA files with ID sections!"); }
                if (colourMapType == 0) { br.ReadBytes(5); } else { throw new NotImplementedException("No support for TGA files with ColourMaps!"); }

                int xOrigin = br.ReadInt16();
                int yOrigin = br.ReadInt16();
                int width = br.ReadInt16();
                int height = br.ReadInt16();
                byte pixelDepth = br.ReadByte();
                byte imageDescriptor = br.ReadByte();

                using (var bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb))
                {
                    BitmapData bmpdata;
                    PixelFormat format = PixelFormat.Format32bppArgb;
                    byte size = (byte)(pixelDepth / 8);

                    if (size == 3) { format = PixelFormat.Format24bppRgb; }

                    bmpdata = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, format);

                    if (imageType == 10)
                    {
                        const int iRAWSection = 127;
                        uint j = 0;
                        int iStep = 0;
                        int bpCount = 0;
                        int currentPixel = 0;
                        int pixelCount = width * height;
                        var colorBuffer = new byte[size];
                        byte chunkHeader = 0;
                        byte[] buffer = br.ReadBytes((int)br.BaseStream.Length - 13);

                        using (var nms = new MemoryStream())
                        {
                            while (currentPixel < pixelCount)
                            {
                                chunkHeader = buffer[iStep];
                                iStep++;

                                if (chunkHeader <= iRAWSection)
                                {
                                    chunkHeader++;
                                    bpCount = size * chunkHeader;
                                    nms.Write(buffer, iStep, bpCount);
                                    iStep += bpCount;

                                    currentPixel += chunkHeader;
                                }
                                else
                                {
                                    chunkHeader -= iRAWSection;
                                    Array.Copy(buffer, iStep, colorBuffer, 0, size);
                                    iStep += size;
                                    for (j = 0; j < chunkHeader; j++) { nms.Write(colorBuffer, 0, size); }
                                    currentPixel += chunkHeader;
                                }
                            }

                            var contentBuffer = new byte[nms.Length];
                            nms.Position = 0;
                            nms.Read(contentBuffer, 0, contentBuffer.Length);

                            Marshal.Copy(contentBuffer, 0, bmpdata.Scan0, contentBuffer.Length);
                        }
                    }
                    else
                    {
                        Marshal.Copy(br.ReadBytes(width * height * size), 0, bmpdata.Scan0, width * height * size);
                    }

                    bmp.UnlockBits(bmpdata);

                    texture.CreateFromBitmap(bmp, Path.GetFileNameWithoutExtension(path));
                }
            }

            return texture;
        }
    }
}
