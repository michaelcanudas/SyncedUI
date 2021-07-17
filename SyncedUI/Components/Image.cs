using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SyncedUI.Components
{
    public class Image : SyncedComponent
    {
        string content;
        public Image(string content)
        {
            this.content = content;
        }

        public override void Render(Graphics graphics)
        {
            System.Drawing.Image image = System.Drawing.Image.FromFile(content);

            graphics.DrawImage(image, new RectangleF(0, 0, width.GetValueOrDefault(), height.GetValueOrDefault()));
        }
    }
}
