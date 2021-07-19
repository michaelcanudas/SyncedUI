using System;
using System.Drawing;
using System.Drawing.Text;

namespace SyncedUI
{
    public class Text : SyncedComponent
    {
        string content;
        public Text(string content)
        {
            this.content = content;
        }

        public override void Render(Graphics graphics)
        {
            Font genFont;
            if (customFont.GetValueOrDefault())
            {
                PrivateFontCollection pfc = new PrivateFontCollection();
                pfc.AddFontFile(font);
                genFont = new Font(pfc.Families[0], fontSize.GetValueOrDefault());
            }
            else
            {
                genFont = new Font(font, fontSize.GetValueOrDefault());
            }

            SolidBrush brush = new SolidBrush(color.GetValueOrDefault());
            genFont = new Font(genFont, fontStyle);

            if (width == null)
            {
                Width(graphics.MeasureString(content, genFont).Width);

                if (height == null)
                {
                    Height(graphics.MeasureString(content, genFont).Height);
                }
            }
            else
            {
                if (height == null)
                {
                    SizeF size = graphics.MeasureString(content, genFont, new SizeF(width.GetValueOrDefault(), long.MaxValue));
                    Height(size.Height);
                }
            }

            graphics.DrawString(content, genFont, brush, new RectangleF(0, 0, width.GetValueOrDefault(), height.GetValueOrDefault()));
        }
    }
}
