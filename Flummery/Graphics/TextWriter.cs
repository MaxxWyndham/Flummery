using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Flummery
{
    public class TextWriter
    {
        private readonly Font textFont = new Font(FontFamily.GenericSansSerif, 8);
        private readonly Bitmap textBitmap;
        private List<PointF> positions;
        private List<string> lines;
        private List<Brush> colours;
        private int textureID;
        private Size clientSize;

        public void Update(int ind, string newText)
        {
            if (ind < lines.Count)
            {
                lines[ind] = newText;
                UpdateText();
            }
        }

        public TextWriter(int viewportWidth, int viewportHeight, int width, int height)
        {
            positions = new List<PointF>();
            lines = new List<string>();
            colours = new List<Brush>();

            textBitmap = new Bitmap(width, height);
            this.clientSize = new Size(viewportWidth, viewportHeight);
            textureID = CreateTexture();
        }

        private int CreateTexture()
        {
            int textureID;

            Bitmap bitmap = textBitmap;
            GL.GenTextures(1, out textureID);
            GL.BindTexture(TextureTarget.Texture2D, textureID);

            BitmapData data = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
            //    GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)All.Nearest);
            //GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)All.Nearest);
            GL.Finish();
            bitmap.UnlockBits(data);

            return textureID;
        }

        public void Dispose()
        {
            if (textureID > 0)
                GL.DeleteTexture(textureID);
        }

        public void Clear()
        {
            lines.Clear();
            positions.Clear();
            colours.Clear();
        }

        public void AddLine(string s, PointF pos, Brush col)
        {
            lines.Add(s);
            positions.Add(pos);
            colours.Add(col);
            UpdateText();
        }

        public void UpdateText()
        {
            if (lines.Count > 0)
            {
                using (Graphics gfx = Graphics.FromImage(textBitmap))
                {
                    gfx.Clear(Color.Black);
                    gfx.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
                    for (int i = 0; i < lines.Count; i++)
                        gfx.DrawString(lines[i], textFont, colours[i], positions[i]);
                }

                textBitmap.MakeTransparent(Color.Black);

                System.Drawing.Imaging.BitmapData data = textBitmap.LockBits(new Rectangle(0, 0, textBitmap.Width, textBitmap.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                GL.TexSubImage2D(TextureTarget.Texture2D, 0, 0, 0, textBitmap.Width, textBitmap.Height, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
                textBitmap.UnlockBits(data);
            }
        }

        public void Draw()
        {
            GL.Enable(EnableCap.Blend);
            GL.Color4(255,255,255,0);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, textureID);

            GL.FrontFace(FrontFaceDirection.Ccw);
            GL.PolygonMode(MaterialFace.Front, PolygonMode.Fill);
            GL.TexEnv(TextureEnvTarget.TextureEnv, TextureEnvParameter.TextureEnvMode, (float)TextureEnvMode.Replace);

            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0, 1); GL.Vertex2(0, 0);
            GL.TexCoord2(1, 1); GL.Vertex2(textBitmap.Width, 0);
            GL.TexCoord2(1, 0); GL.Vertex2(textBitmap.Width, textBitmap.Height);
            GL.TexCoord2(0, 0); GL.Vertex2(0, textBitmap.Height);
            GL.End();

            GL.TexEnv(TextureEnvTarget.TextureEnv, TextureEnvParameter.TextureEnvMode, (float)TextureEnvMode.Modulate);

            GL.Disable(EnableCap.Blend);
            GL.Disable(EnableCap.Texture2D);
        }
    }
}
