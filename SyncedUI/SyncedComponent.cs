using SyncedUI.Components;
using System.Drawing;

namespace SyncedUI
{
    public abstract class SyncedComponent
    {
        internal float? width;
        public SyncedComponent Width(float width) { this.width = width; return this; }

        internal float? height;
        public SyncedComponent Height(float height) { this.height = height; return this; }

        internal string font;
        public SyncedComponent Font(string font) { this.font = font; return this; }

        internal bool? customFont;
        public SyncedComponent CustomFont(bool customFont) { this.customFont = customFont; return this; }

        internal float? fontSize;
        public SyncedComponent FontSize(float fontSize) { this.fontSize = fontSize; return this; }

        internal FontStyle fontStyle;
        public SyncedComponent FontStyle(FontStyle fontStyle) { this.fontStyle = fontStyle; return this; }

        internal Direction direction;
        public SyncedComponent Direction(Direction direction) { this.direction = direction; return this; }

        internal Color? color;
        public SyncedComponent Color(Color color) { this.color = color; return this; }

        internal SyncedComponent[] children;
        public SyncedComponent Children(params SyncedComponent[] children) { this.children = children; return this; }

        public abstract void Render(Graphics graphics);
    }

    public abstract class SyncedParentComponent : SyncedComponent
    {
        public override void Render(Graphics graphics)
        {
            if (children != null && children.Length > 0)
            {
                foreach (SyncedComponent child in children)
                {
                    child.Render(graphics);
                }
            }
        }
    }

    public enum Direction
    {
        Vertical,
        Horizontal,
        Forward
    }
}
