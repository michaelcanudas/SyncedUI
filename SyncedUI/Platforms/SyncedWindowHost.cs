using SyncedUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncedUI.Platforms
{
    /// <summary>
    /// Manages the render loop and other important functions that allow a window to function.
    /// </summary>
    // NOTE: SyncedWindow is the what the user inherits to create an application. SyncedWindowHost provides platform specific functionality to that window.
    internal sealed partial class SyncedWindowHost : IDisposable
    {
        private SyncedWindow window;

        public SyncedWindowHost(SyncedWindow window)
        {
            this.window = window;
            
            Initialize();

        }

        public void Dispose()
        {
            DisposeUnmanaged();
        }

        public void RunAppLoop()
        {
            window.Layout();
            //graphics.Clear(ColorTranslator.FromHtml("#fff"));
            //graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            //window.Render(graphics);

            while (WindowIsOpen())
            {
                HandleWindowEvents();
            }
        }

        public Graphics GetWindowGraphics()
        {
            return null;// graphics;
        }

        private void Invalidate(Graphics graphics)
        {
            window.ClearChildren();
            window.Layout();
            window.Render(graphics);
        }

        // platform-specific method declarations
        private partial void Initialize();
        private partial Graphics CreateGraphics();
        private partial void HandleWindowEvents();
        private partial bool WindowIsOpen();
        private partial void DisposeUnmanaged();
        private partial IntPtr GetNativeWindowHandle();
    }
}
