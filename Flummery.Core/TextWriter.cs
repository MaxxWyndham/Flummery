using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;

namespace Flummery.Core
{
    public enum FontStyles
    {
        ViewportLabel,
        AxisLabel
    }

    public class TextWriter
    {
        public List<Font> Fonts { get; } = new List<Font> {
            new Font(FontFamily.GenericSansSerif, 8),
            new Font(FontFamily.GenericSansSerif, 5, FontStyle.Bold)
        };

        public List<TextEntry> Lines { get; } = new List<TextEntry>();

        public Bitmap TextBitmap { get; private set; }

        private int textureID = -1;

        public TextWriter(int width, int height)
        {
            SetWidthHeight(width, height);
        }

        private void createTexture()
        {
            if (textureID == -1) { SceneManager.Current.Renderer.GenTextures(1, out textureID); }
            SceneManager.Current.Renderer.BindTexture("Texture2D", textureID);

            BitmapData data = TextBitmap.LockBits(new Rectangle(0, 0, TextBitmap.Width, TextBitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            SceneManager.Current.Renderer.TexImage2D("Texture2D", 0, "Rgba", data.Width, data.Height, 0, "Bgra", "UnsignedByte", data.Scan0);
            SceneManager.Current.Renderer.TexParameter("Texture2D", "TextureMinFilter", 0x2601);
            SceneManager.Current.Renderer.TexParameter("Texture2D", "TextureMagFilter", 0x2601);
            SceneManager.Current.Renderer.Finish();
            TextBitmap.UnlockBits(data);
        }

        public void SetWidthHeight(int width, int height)
        {
            TextBitmap = new Bitmap(width, height);
            createTexture();
        }

        public void Dispose()
        {
            if (textureID != -1) { SceneManager.Current.Renderer.DeleteTexture(textureID); }
        }

        public void Clear()
        {
            Lines.Clear();
        }

        public void AddLine(string s, PointF pos, Brush col, FontStyles font = FontStyles.ViewportLabel)
        {
            Lines.Add(
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
            if (Lines.Count > 0)
            {
                using (Graphics gfx = Graphics.FromImage(TextBitmap))
                {
                    gfx.Clear(Color.Black);

                    gfx.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;

                    for (int i = 0; i < Lines.Count; i++)
                    {
                        gfx.DrawString(Lines[i].Text, Fonts[(int)Lines[i].Font], Lines[i].Colour, Lines[i].Position);
                    }
                }

                TextBitmap.MakeTransparent(Color.Black);

                BitmapData data = TextBitmap.LockBits(new Rectangle(0, 0, TextBitmap.Width, TextBitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                SceneManager.Current.Renderer.TexSubImage2D("Texture2D", 0, 0, 0, TextBitmap.Width, TextBitmap.Height, "Bgra", "UnsignedByte", data.Scan0);
                TextBitmap.UnlockBits(data);
            }
        }

        public void Draw()
        {
            SceneManager.Current.Renderer.Enable("Blend");
            SceneManager.Current.Renderer.Color4(255, 255, 255, 0);
            SceneManager.Current.Renderer.BlendFunc("SrcAlpha", "OneMinusSrcAlpha");
            SceneManager.Current.Renderer.Enable("Texture2D");
            SceneManager.Current.Renderer.BindTexture("Texture2D", textureID);

            SceneManager.Current.Renderer.FrontFace("Ccw");
            SceneManager.Current.Renderer.PolygonMode("Front", "Fill");
            SceneManager.Current.Renderer.TexEnv("TextureEnv", "TextureEnvMode", 0x1E01);

            SceneManager.Current.Renderer.Begin(PrimitiveType.Quads);
            SceneManager.Current.Renderer.TexCoord2(0, 1); SceneManager.Current.Renderer.Vertex2(0, 0);
            SceneManager.Current.Renderer.TexCoord2(1, 1); SceneManager.Current.Renderer.Vertex2(TextBitmap.Width, 0);
            SceneManager.Current.Renderer.TexCoord2(1, 0); SceneManager.Current.Renderer.Vertex2(TextBitmap.Width, TextBitmap.Height);
            SceneManager.Current.Renderer.TexCoord2(0, 0); SceneManager.Current.Renderer.Vertex2(0, TextBitmap.Height);
            SceneManager.Current.Renderer.End();

            SceneManager.Current.Renderer.TexEnv("TextureEnv", "TextureEnvMode", 0x2100);

            SceneManager.Current.Renderer.Disable("Blend");
            SceneManager.Current.Renderer.Disable("Texture2D");
        }
    }

    public class TextEntry
    {
        public PointF Position { get; set; }

        public string Text { get; set; }

        public Brush Colour { get; set; }

        public FontStyles Font { get; set; }
    }
}
