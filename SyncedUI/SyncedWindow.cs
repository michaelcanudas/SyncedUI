// Window.cs - Declares api for Window class using partial methods to ensure consistency between platforms

using System;
using System.Collections.Generic;
using System.Drawing;

namespace SyncedUI
{
    public partial class SyncedWindow
    {
        private static SyncedWindow instance;

        private static List<SyncedComponent> children = new();

        public SyncedWindow()
        {
            if (instance != null)
                throw new Exception();

            instance = this;
        }

        public void Render(Graphics graphics)
        {
            graphics.Clear(Color.White);
            graphics.Transform = new System.Drawing.Drawing2D.Matrix(1, 0, 0, 1, 0, 0);
            foreach (var child in children)
            {
                child.Render(graphics);
            }
        }

        public virtual void Layout()
        {

        }

        public static SyncedWindow Get()
        {
            return instance;
        }

        internal void AddChild(SyncedComponent comp)
        {
            children.Add(comp);
        }
    }
}
