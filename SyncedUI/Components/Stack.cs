using System;
using System.Drawing;

namespace SyncedUI
{
    public class Stack : SyncedParentComponent
    {
        public override void Render(Graphics graphics)
        {
            if (children != null && children.Length > 0)
            {
                foreach (SyncedComponent child in children)
                {
                    child.Render(graphics);

                    switch (true)
                    {
                        case true when direction == SyncedUI.Direction.Vertical:
                            graphics.TranslateTransform(0, child.height.GetValueOrDefault());
                            break;
                        case true when direction == SyncedUI.Direction.Horizontal:
                            graphics.TranslateTransform(child.width.GetValueOrDefault(), 0);
                            break;
                        case true when direction == SyncedUI.Direction.Forward:
                            break;
                        default:
                            throw new Exception("Invalid direction");
                    }
                }
            }
        }
    }
}
