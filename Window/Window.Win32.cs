using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

#if WIN32

namespace SyncedUI.Window
{
    public unsafe partial class SyncedWindow
    {
        private const string WindowClassName = "DemoRendererClass";

        private HINSTANCE hInstance;
        private HWND hwnd;

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvStdcall) })]
        private static nint WindowProc(HWND hWnd, WindowMessage msg, WPARAM wparam, LPARAM lparam)
        {
            return DefWindowProcW(hWnd, msg, wparam, lparam);
        }

        private partial void Initialize()
        {
            hInstance = GetModuleHandleW(null);

            if (!hInstance)
            {
                throw new Exception("Unable to get hInstance!");
            }

            WNDCLASSEXW wndclass;
            short atom;
            fixed (char* pWindowClassName = WindowClassName)
            {
                wndclass = new WNDCLASSEXW()
                {
                    cbSize = Marshal.SizeOf<WNDCLASSEXW>(),
                    lpszClassName = pWindowClassName,
                    hInstance = this.hInstance,
                    lpfnWndProc = &WindowProc,
                };

                atom = RegisterClassExW(ref wndclass);
            }


            if (atom == 0)
            {
                throw new Exception("Unable to register window class! error: 0x" + Marshal.GetLastWin32Error().ToString("x"));
            }

            fixed (char* pWindowClassName = WindowClassName)
            {
                fixed (char* pWindowTitle = "Hello world from the window's title!")
                {
                    hwnd = CreateWindowExW(0, pWindowClassName, pWindowTitle, WindowStyles.OverlappedWindow, 100, 100, 1000, 1000, null, null, hInstance, null);
                }
            }

            if (!hwnd)
            {
                throw new Exception("Unable to create window! error: 0x" + Marshal.GetLastWin32Error().ToString("x"));
            }

            ShowWindow(hwnd, ShowWindowCommand.SHOW);
        }

        public partial Graphics CreateGraphics()
        {
            return Graphics.FromHwnd(new IntPtr(hwnd));
        }

        public partial void HandleEvents()
        {
            MSG msg = new MSG();
            if (GetMessageW(&msg, hwnd, 0, 0))
            {
                TranslateMessage(&msg);
                DispatchMessageW(&msg);
            }
        }

        public partial bool IsOpen()
        {
            return true;
        }

        public partial void Dispose()
        {
            DestroyWindow(hwnd);
            FreeLibrary(hInstance);
        }
    }
}

#endif