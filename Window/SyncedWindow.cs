// Window.cs - Declares api for Window class using partial methods to ensure consistency between platforms

using System;
using System.Collections.Generic;
using System.Drawing;

namespace SyncedUI.Window
{
    public partial class SyncedWindow : IDisposable
    {
        private static SyncedWindow instance;

        private static List<SyncedComponent> children = new();

        public SyncedWindow()
        {
            if (instance != null)
                throw new Exception();

            instance = this;

            Initialize();
        }

        public void Render(Graphics graphics)
        {
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

        private partial void Initialize();

        public partial Graphics CreateGraphics();

        public partial void HandleEvents();

        public partial bool IsOpen();

        public partial void Dispose();
    }
}
