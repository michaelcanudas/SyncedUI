using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

#if WIN32
using static SyncedUI.Platforms.WindowsInterop;

namespace SyncedUI.Platforms
{
    internal sealed unsafe partial class SyncedWindowHost
    {
        private const string WindowClassName = "DemoRendererClass";

        private static Dictionary<HWND, SyncedWindowHost> hosts = new();

        private HINSTANCE hInstance;
        private HWND hwnd;

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvStdcall) })]
        private static nint WindowProc(HWND hWnd, WindowMessage msg, WPARAM wparam, LPARAM lparam)
        {
            if (hosts.ContainsKey(hWnd))
            {
                var host = hosts[hWnd];

                if (host.graphics == null)
                {
                    host.graphics = host.CreateGraphics();
                }

                switch (msg)
                {
                    case WindowMessage.SIZE:
                    case WindowMessage.PAINT:
                        return 0;
                }

                Console.WriteLine(msg.ToString());
            }
            return DefWindowProcW(hWnd, msg, wparam, lparam);
        }

        private partial void Initialize()
        {
            hInstance = GetModuleHandleW(null);

            if (!hInstance)
            {
                throw new Exception("Unable to get hInstance!");
            }

            // register window class
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

            // create window
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

            hosts.Add(hwnd, this);

            ShowWindow(hwnd, ShowWindowCommand.SHOW);
        }

        private partial Graphics CreateGraphics()
        {
            return Graphics.FromHwnd(new IntPtr(hwnd));
        }

        private partial void HandleWindowEvents()
        {
            MSG msg = new();
            if (GetMessageW(&msg, hwnd, 0, 0))
            {
                TranslateMessage(&msg);
                DispatchMessageW(&msg);
            }
        }

        private partial bool WindowIsOpen()
        {
            return true;
        }

        private partial void DisposeUnmanaged()
        {
            hosts.Remove(this.hwnd);
            DestroyWindow(hwnd);
            FreeLibrary(hInstance);
        }
    }
}

#endif