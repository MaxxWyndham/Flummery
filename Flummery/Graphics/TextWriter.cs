using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;

using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Flummery
{
    public enum Fonts
    {
        ViewportLabel,
        AxisLabel
    }

    public class TextWriter
    {
        List<Font> fonts = new List<Font> {
            new Font(FontFamily.GenericSansSerif, 8),
            new Font(FontFamily.GenericSansSerif, 5, FontStyle.Bold)
        };

        List<TextEntry> lines;

        private readonly Bitmap textBitmap;
        private int textureID;
        private Size clientSize;

        public void Update(int ind, string newText)
        {
            if (ind < lines.Count)
            {
                //lines[ind] = newText;
                UpdateText();
            }
        }

        public TextWriter(int viewportWidth, int viewportHeight, int width, int height)
        {
            lines = new List<TextEntry>();

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
        }

        public void AddLine(string s, PointF pos, Brush col, Fonts font = Fonts.ViewportLabel)
        {
            lines.Add(
                new TextEntry
                {
                    Text = s,
                    Position = pos,
                    Colour = col,
                    Font = font
                }
            );

            UpdateText();
        }

        public void UpdateText()
        {
            if (lines.Count > 0)
            {
                using (Graphics gfx = Graphics.FromImage(textBitmap))
                {
                    gfx.Clear(Color.Black);

                    gfx.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;

                    for (int i = 0; i < lines.Count; i++)
                    {
                        gfx.DrawString(lines[i].Text, fonts[(int)lines[i].Font], lines[i].Colour, lines[i].Position);
                    }
                }

                textBitmap.MakeTransparent(Color.Black);

                BitmapData data = textBitmap.LockBits(new Rectangle(0, 0, textBitmap.Width, textBitmap.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
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

    public class TextEntry
    {
        PointF position;
        string text;
        Brush colour;
        Fonts font;

        public PointF Position
        {
            get { return position; }
            set { position = value; }
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public Brush Colour
        {
            get { return colour; }
            set { colour = value; }
        }

        public Fonts Font
        {
            get { return font; }
            set { font = value; }
        }
    }
}
