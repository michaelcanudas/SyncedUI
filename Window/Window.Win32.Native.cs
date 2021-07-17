// Window.Win32.Native.cs -- Bindings for various functions in the windows sdk, mostly found in WinUser.h. partially borrowed from https://github.com/dotnet/pinvoke

using System;
using System.Collections.Generic;
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
#region Constants
        
        const int CW_USEDEFAULT = unchecked((int)0x80000000);

#endregion

#region Enums

        private enum WindowMessage : uint
        {

        }

        private enum ShowWindowCommand
        {
            HIDE             = 0,
            SHOWNORMAL       = 1,
            NORMAL           = 1,
            SHOWMINIMIZED    = 2,
            SHOWMAXIMIZED    = 3,
            MAXIMIZE         = 3,
            SHOWNOACTIVATE   = 4,
            SHOW             = 5,
            MINIMIZE         = 6,
            SHOWMINNOACTIVE  = 7,
            SHOWNA           = 8,
            RESTORE          = 9,
            SHOWDEFAULT      = 10,
            FORCEMINIMIZE    = 11,
            MAX              = 11,
        }

        private enum WindowStylesEx : uint
        {
            DLGMODALFRAME = 0x00000001,
            NOPARENTNOTIFY = 0x00000004,
            TOPMOST = 0x00000008,
            ACCEPTFILES = 0x00000010,
            TRANSPARENT = 0x00000020,
            MDICHILD = 0x00000040,
            TOOLWINDOW = 0x00000080,
            WINDOWEDGE = 0x00000100,
            CLIENTEDGE = 0x00000200,
            CONTEXTHELP = 0x00000400,
            RIGHT = 0x00001000,
            LEFT = 0x00000000,
            RTLREADING = 0x00002000,
            LTRREADING = 0x00000000,
            LEFTSCROLLBAR = 0x00004000,
            RIGHTSCROLLBAR = 0x00000000,
            CONTROLPARENT = 0x00010000,
            STATICEDGE = 0x00020000,
            APPWINDOW = 0x00040000,
            OVERLAPPEDWINDOW = (WINDOWEDGE | CLIENTEDGE),
            PALETTEWINDOW = (WINDOWEDGE | TOOLWINDOW | TOPMOST),
            NOINHERITLAYOUT = 0x00100000,
            NOREDIRECTIONBITMAP = 0x00200000,
            LAYOUTRTL = 0x00400000,
            COMPOSITED = 0x02000000,
            NOACTIVATE = 0x08000000,
        }

        private enum WindowStyles : uint
        {
            Overlapped = 0x00000000,
            Popup = 0x80000000,
            Child = 0x40000000,
            Minimize = 0x20000000,
            Visible = 0x10000000,
            Disabled = 0x08000000,
            ClipSiblings = 0x04000000,
            ClipChildren = 0x02000000,
            Maximize = 0x01000000,
            Caption = (Border | DLGFrame),
            Border = 0x00800000,
            DLGFrame = 0x00400000,
            VScroll = 0x00200000,
            HScroll = 0x00100000,
            SysMenu = 0x00080000,
            ThinkFrame = 0x00040000,
            Group = 0x00020000,
            TabStop = 0x00010000,
            MinimizeBox = 0x00020000,
            MaximizeBox = 0x00010000,
            OverlappedWindow = (Overlapped | Caption | SysMenu | ThinkFrame | MinimizeBox | MaximizeBox),
            PopupWindow = (Popup | Border | SysMenu),
            ChildWindow = (Child)
        }

#endregion Enums

#region Delegates

        private delegate LRESULT WNDPROC(HWND hWnd, WindowMessage msg, WPARAM wParam, LPARAM lParam);

#endregion Delegates

#region structs

        private struct MSG
        {
            public HWND hwnd;
            public WindowMessage message;
            public WPARAM wparam;
            public LPARAM lparam;
            public uint time;
            public POINT pt;
        }

        private struct POINT
        {
            public int x;
            public int y;
        }


        private struct BOOL
        {
            int value;
            
            public static implicit operator bool(BOOL value)
            {
                return value.value == 1;
            }

            public static implicit operator BOOL(bool value)
            {
                return new BOOL { value = value ? 1 : 0 };
            }

            public static bool operator true(BOOL value)
            {
                return value.value == 1;
            }

            public static bool operator false(BOOL value)
            {
                return value.value == 0;
            }
        }

        //private struct WNDCLASSEXW
        //{
        //    public int cbSize;
        //    public uint style;
        //    public delegate* <HWND, WindowMessage, WPARAM, LPARAM, LRESULT> WndProc;
        //    public int ClsExtra;
        //    public int WndExtra;
        //    public HINSTANCE Instance;
        //    public void* Icon;
        //    public void* Cursor;
        //    public void* Brush;
        //    public char* MenuName;
        //    public char* ClassName;
        //}
        private unsafe partial struct WNDCLASSEXW
        {
            public int cbSize;

            public uint style;

            [MarshalAs(UnmanagedType.FunctionPtr)]
            //public WNDPROC lpfnWndProc;
            public delegate* unmanaged[Stdcall]<HWND, WindowMessage, WPARAM, LPARAM, nint> lpfnWndProc;

            public int cbClsExtra;

            public int cbWndExtra;
            public HINSTANCE hInstance;
            public IntPtr hIcon;
            public IntPtr hCursor;
            public IntPtr hbrBackground;

            public char* lpszMenuName;

            public char* lpszClassName;

            public IntPtr hIconSm;

            //public static WNDCLASSEXW Create()
            //{
            //    var nw = default(WNDCLASSEXW);
            //    nw.cbSize = Marshal.SizeOf(typeof(WNDCLASSEXW));
            //    return nw;
            //}
        }

#region Handles
        // unfortunately there isn't a good way to avoid this code dupication here.
        // All the handles have the same code, But using one type or even just a 'void*' would
        // make the windows api even more confusing to use.

        private struct HWND
        {
            void* Value;

            public static implicit operator HWND(void* value)
            {
                return new HWND { Value = value };
            }

            public static implicit operator void*(HWND hInstance)
            {
                return hInstance.Value;
            }
            public static bool operator true(HWND value)
            {
                return value.Value != null;
            }

            public static bool operator false(HWND value)
            {
                return value.Value == null;
            }

            public static bool operator !(HWND value)
            {
                return value.Value == null;
            }
        }

        private struct HINSTANCE
        {
            void* Value;

            public static implicit operator HINSTANCE(void* value)
            {
                return new HINSTANCE { Value = value };
            }

            public static implicit operator void*(HINSTANCE hInstance)
            {
                return hInstance.Value;
            }

            public static bool operator true(HINSTANCE value)
            {
                return value.Value != null;
            }

            public static bool operator false(HINSTANCE value)
            {
                return value.Value == null;
            }
            public static bool operator !(HINSTANCE value)
            {
                return value.Value == null;
            }
        }

#endregion Handles

#region WNDPROC
        // this region contains structs used in the wndproc function ptr on WNDCLASSEXW and the DefWindowProc function
        // it has the same code duplication issue as the Handles region.

        private struct LRESULT
        {
            nint Value;

            public static implicit operator LRESULT(nint value)
            {
                return new LRESULT { Value = value };
            }

            public static implicit operator nint(LRESULT hInstance)
            {
                return hInstance.Value;
            }
        }

        private struct LPARAM
        {
            nint Value;

            public static implicit operator LPARAM(nint value)
            {
                return new LPARAM { Value = value };
            }

            public static implicit operator nint(LPARAM hInstance)
            {
                return hInstance.Value;
            }
        }

        private struct WPARAM
        {
            nuint Value;

            public static implicit operator WPARAM(nuint value)
            {
                return new WPARAM { Value = value };
            }

            public static implicit operator nuint(WPARAM hInstance)
            {
                return hInstance.Value;
            }
        }

#endregion

#endregion

#region Macros
        // macros implemented as static methods with the MethodImplOptions.AggressiveInlining

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        private static ushort LOWORD(LPARAM value)
        {
            return unchecked((ushort)((nint)value & 0xffff));
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        private static ushort HIWORD(LPARAM value)
        {
            return unchecked((ushort)(((nint)value >> 16) & 0xffff));
        }

#endregion

#region Methods

#region User32

        [DllImport("user32", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode, SetLastError = false)]
        // registers a new window class
        private static extern short RegisterClassExW(ref WNDCLASSEXW wndclass);

        [DllImport("user32", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode, SetLastError = false)]
        // Creates a new window
        private static extern HWND CreateWindowExW(WindowStylesEx wExStyle, char* lpClassName, char* lpWindowName, WindowStyles wStyle, int x, int y, int nWidth, int nHeight, void* hWndParent, void* hMenu, HINSTANCE hInstance, void* param);

        [DllImport("user32", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode, SetLastError = false)]
        // default window process
        private static extern LRESULT DefWindowProcW(HWND hWnd, WindowMessage Msg, WPARAM wParam, LPARAM lParam);

        [DllImport("user32", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode, SetLastError = false)]
        // frees a handle to a module (aka a .dll file).
        private static extern bool DestroyWindow(HWND hWnd);

        [DllImport("user32", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode, SetLastError = false)]
        private static extern bool ShowWindow(HWND hWnd, ShowWindowCommand command);

        [DllImport("user32", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode, SetLastError = false)]
        private static extern bool GetMessageW(MSG* lpMsg, HWND hWnd, uint wMsgFilterMin, uint wMsgFilterMax);
        
        [DllImport("user32", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode, SetLastError = false)]
        private static extern bool TranslateMessage(MSG* lpMsg);

        [DllImport("user32", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode, SetLastError = false)]
        private static extern LRESULT DispatchMessageW(MSG* lpMsg);

#endregion

#region Kernel32

        [DllImport("kernel32", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode, SetLastError = false)]
        // gets a handle to a module (aka a .dll file). passing null returns the calling module.
        private static extern HINSTANCE GetModuleHandleW(char* moduleName);

        [DllImport("kernel32", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode, SetLastError = false)]
        // frees a handle to a module (aka a .dll file).
        private static extern bool FreeLibrary(HINSTANCE module);

#endregion

#endregion Methods
    }
}

#endif