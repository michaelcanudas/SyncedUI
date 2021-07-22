using SyncedUI.Platforms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SyncedUI
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
            var image = ResourceCache.Images.Load(content);

            graphics.DrawImage(image, new RectangleF(0, 0, width.GetValueOrDefault(), height.GetValueOrDefault()));
        }
    }
}
