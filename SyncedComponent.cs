using System.Drawing;

namespace SyncedUI
{
    public abstract class SyncedComponent
    {
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
}
