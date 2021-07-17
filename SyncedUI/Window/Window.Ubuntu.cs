using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using TerraFX.Interop;

#if UBUNTU

namespace SyncedUI.Window
{
    public unsafe partial class Window
    {
        IntPtr display;
        nuint window;

        public Window()
        {
            //display = Xlib.XOpenDisplay(null);

            //window = Xlib.XCreateWindow()
        }

        public static partial Window Create()
        {
            throw new NotImplementedException();
        }

        public partial Graphics CreateGraphics()
        {
            throw new NotImplementedException();
        }

        public partial void Dispose()
        {
            Xlib.XDestroyWindow(display, window);

            Xlib.XCloseDisplay(display);
        }

        public partial void HandleEvents()
        {
            throw new NotImplementedException();
        }

        public partial bool IsOpen()
        {
            throw new NotImplementedException();
        }
    }
}
#endif