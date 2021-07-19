using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

#if WIN32

namespace SyncedUI.Platforms
{
    /// <summary>
    /// Contains all Interop delcarations 
    /// </summary>
    internal unsafe static class WindowsInterop
    {
        #region Constants

        internal const int CW_USEDEFAULT = unchecked((int)0x80000000);
        internal const int WHEEL_DELTA = 120;


        #endregion

        #region Enums

        internal enum MessageBoxFlags : uint
        {
            OK = 0x00000000,
            OKCANCEL = 0x00000001,
            ABORTRETRYIGNORE = 0x00000002,
            YESNOCANCEL = 0x00000003,
            YESNO = 0x00000004,
            RETRYCANCEL = 0x00000005,
            ICONHAND = 0x00000010,
            ICONQUESTION = 0x00000020,
            ICONEXCLAMATION = 0x00000030,
            ICONASTERISK = 0x00000040,
            USERICON = 0x00000080,
            ICONWARNING = ICONEXCLAMATION,
            ICONERROR = ICONHAND,
            ICONINFORMATION = ICONASTERISK,
            ICONSTOP = ICONHAND,
        }

        internal enum WindowMessage : uint
        {
            NULL = 0x0000,
            CREATE = 0x0001,
            DESTROY = 0x0002,
            MOVE = 0x0003,
            SIZE = 0x0005,
            ACTIVATE = 0x0006,
            SETFOCUS = 0x0007,
            KILLFOCUS = 0x0008,
            ENABLE = 0x000A,
            SETREDRAW = 0x000B,
            SETTEXT = 0x000C,
            GETTEXT = 0x000D,
            GETTEXTLENGTH = 0x000E,
            PAINT = 0x000F,
            CLOSE = 0x0010,
            QUERYENDSESSION = 0x0011,
            QUERYOPEN = 0x0013,
            ENDSESSION = 0x0016,
            QUIT = 0x0012,
            ERASEBKGND = 0x0014,
            SYSCOLORCHANGE = 0x0015,
            SHOWWINDOW = 0x0018,
            WININICHANGE = 0x001A,
            SETTINGCHANGE = WININICHANGE,
            DEVMODECHANGE = 0x001B,
            ACTIVATEAPP = 0x001C,
            FONTCHANGE = 0x001D,
            TIMECHANGE = 0x001E,
            CANCELMODE = 0x001F,
            SETCURSOR = 0x0020,
            MOUSEACTIVATE = 0x0021,
            CHILDACTIVATE = 0x0022,
            QUEUESYNC = 0x0023,
            GETMINMAXINFO = 0x0024,
            PAINTICON = 0x0026,
            ICONERASEBKGND = 0x0027,
            NEXTDLGCTL = 0x0028,
            SPOOLERSTATUS = 0x002A,
            DRAWITEM = 0x002B,
            MEASUREITEM = 0x002C,
            DELETEITEM = 0x002D,
            VKEYTOITEM = 0x002E,
            CHARTOITEM = 0x002F,
            SETFONT = 0x0030,
            GETFONT = 0x0031,
            SETHOTKEY = 0x0032,
            GETHOTKEY = 0x0033,
            QUERYDRAGICON = 0x0037,
            COMPAREITEM = 0x0039,
            GETOBJECT = 0x003D,
            COMPACTING = 0x0041,
            COMMNOTIFY = 0x0044,  /* no longer suported */
            WINDOWPOSCHANGING = 0x0046,
            WINDOWPOSCHANGED = 0x0047,
            POWER = 0x0048,
            COPYDATA = 0x004A,
            CANCELJOURNAL = 0x004B,
            NOTIFY = 0x004E,
            INPUTLANGCHANGEREQUEST = 0x0050,
            INPUTLANGCHANGE = 0x0051,
            TCARD = 0x0052,
            HELP = 0x0053,
            USERCHANGED = 0x0054,
            NOTIFYFORMAT = 0x0055,
            _ANSI = 1,
            _UNICODE = 2,
            QUERY = 3,
            REQUERY = 4,
            CONTEXTMENU = 0x007B,
            STYLECHANGING = 0x007C,
            STYLECHANGED = 0x007D,
            DISPLAYCHANGE = 0x007E,
            GETICON = 0x007F,
            SETICON = 0x0080,
            NCCREATE = 0x0081,
            NCDESTROY = 0x0082,
            NCCALCSIZE = 0x0083,
            NCHITTEST = 0x0084,
            NCPAINT = 0x0085,
            NCACTIVATE = 0x0086,
            GETDLGCODE = 0x0087,
            SYNCPAINT = 0x0088,
            NCMOUSEMOVE = 0x00A0,
            NCLBUTTONDOWN = 0x00A1,
            NCLBUTTONUP = 0x00A2,
            NCLBUTTONDBLCLK = 0x00A3,
            NCRBUTTONDOWN = 0x00A4,
            NCRBUTTONUP = 0x00A5,
            NCRBUTTONDBLCLK = 0x00A6,
            NCMBUTTONDOWN = 0x00A7,
            NCMBUTTONUP = 0x00A8,
            NCMBUTTONDBLCLK = 0x00A9,
            NCXBUTTONDOWN = 0x00AB,
            NCXBUTTONUP = 0x00AC,
            NCXBUTTONDBLCLK = 0x00AD,
            INPUT_DEVICE_CHANGE = 0x00FE,
            INPUT = 0x00FF,
            KEYFIRST = 0x0100,
            KEYDOWN = 0x0100,
            KEYUP = 0x0101,
            CHAR = 0x0102,
            DEADCHAR = 0x0103,
            SYSKEYDOWN = 0x0104,
            SYSKEYUP = 0x0105,
            SYSCHAR = 0x0106,
            SYSDEADCHAR = 0x0107,
            UNICHAR = 0x0109,
            KEYLAST = 0x0109,
            IME_STARTCOMPOSITION = 0x010D,
            IME_ENDCOMPOSITION = 0x010E,
            IME_COMPOSITION = 0x010F,
            IME_KEYLAST = 0x010F,
            INITDIALOG = 0x0110,
            COMMAND = 0x0111,
            SYSCOMMAND = 0x0112,
            TIMER = 0x0113,
            HSCROLL = 0x0114,
            VSCROLL = 0x0115,
            INITMENU = 0x0116,
            INITMENUPOPUP = 0x0117,
            GESTURE = 0x0119,
            GESTURENOTIFY = 0x011A,
            MENUSELECT = 0x011F,
            MENUCHAR = 0x0120,
            ENTERIDLE = 0x0121,
            MENURBUTTONUP = 0x0122,
            MENUDRAG = 0x0123,
            MENUGETOBJECT = 0x0124,
            UNINITMENUPOPUP = 0x0125,
            MENUCOMMAND = 0x0126,
            CHANGEUISTATE = 0x0127,
            UPDATEUISTATE = 0x0128,
            QUERYUISTATE = 0x0129,
            CTLCOLORMSGBOX = 0x0132,
            CTLCOLOREDIT = 0x0133,
            CTLCOLORLISTBOX = 0x0134,
            CTLCOLORBTN = 0x0135,
            CTLCOLORDLG = 0x0136,
            CTLCOLORSCROLLBAR = 0x0137,
            CTLCOLORSTATIC = 0x0138,
            MOUSEFIRST = 0x0200,
            MOUSEMOVE = 0x0200,
            LBUTTONDOWN = 0x0201,
            LBUTTONUP = 0x0202,
            LBUTTONDBLCLK = 0x0203,
            RBUTTONDOWN = 0x0204,
            RBUTTONUP = 0x0205,
            RBUTTONDBLCLK = 0x0206,
            MBUTTONDOWN = 0x0207,
            MBUTTONUP = 0x0208,
            MBUTTONDBLCLK = 0x0209,
            MOUSEWHEEL = 0x020A,
            XBUTTONDOWN = 0x020B,
            XBUTTONUP = 0x020C,
            XBUTTONDBLCLK = 0x020D,
            MOUSEHWHEEL = 0x020E,
            MOUSELAST = 0x020E,
            PARENTNOTIFY = 0x0210,
            ENTERMENULOOP = 0x0211,
            EXITMENULOOP = 0x0212,
            NEXTMENU = 0x0213,
            SIZING = 0x0214,
            CAPTURECHANGED = 0x0215,
            MOVING = 0x0216,
            POWERBROADCAST = 0x0218,
            DEVICECHANGE = 0x0219,
            MDICREATE = 0x0220,
            MDIDESTROY = 0x0221,
            MDIACTIVATE = 0x0222,
            MDIRESTORE = 0x0223,
            MDINEXT = 0x0224,
            MDIMAXIMIZE = 0x0225,
            MDITILE = 0x0226,
            MDICASCADE = 0x0227,
            MDIICONARRANGE = 0x0228,
            MDIGETACTIVE = 0x0229,
            MDISETMENU = 0x0230,
            ENTERSIZEMOVE = 0x0231,
            EXITSIZEMOVE = 0x0232,
            DROPFILES = 0x0233,
            MDIREFRESHMENU = 0x0234,
            POINTERDEVICECHANGE = 0x238,
            POINTERDEVICEINRANGE = 0x239,
            POINTERDEVICEOUTOFRANGE = 0x23A,
            TOUCH = 0x0240,
            NCPOINTERUPDATE = 0x0241,
            NCPOINTERDOWN = 0x0242,
            NCPOINTERUP = 0x0243,
            POINTERUPDATE = 0x0245,
            POINTERDOWN = 0x0246,
            POINTERUP = 0x0247,
            POINTERENTER = 0x0249,
            POINTERLEAVE = 0x024A,
            POINTERACTIVATE = 0x024B,
            POINTERCAPTURECHANGED = 0x024C,
            TOUCHHITTESTING = 0x024D,
            POINTERWHEEL = 0x024E,
            POINTERHWHEEL = 0x024F,
            POINTERHITTEST = 0x0250,
            POINTERROUTEDTO = 0x0251,
            POINTERROUTEDAWAY = 0x0252,
            POINTERROUTEDRELEASED = 0x0253,
            IME_SETCONTEXT = 0x0281,
            IME_NOTIFY = 0x0282,
            IME_CONTROL = 0x0283,
            IME_COMPOSITIONFULL = 0x0284,
            IME_SELECT = 0x0285,
            IME_CHAR = 0x0286,
            IME_REQUEST = 0x0288,
            IME_KEYDOWN = 0x0290,
            IME_KEYUP = 0x0291,
            MOUSEHOVER = 0x02A1,
            MOUSELEAVE = 0x02A3,
            NCMOUSEHOVER = 0x02A0,
            NCMOUSELEAVE = 0x02A2,
            WTSSESSION_CHANGE = 0x02B1,
            TABLET_FIRST = 0x02c0,
            TABLET_LAST = 0x02df,
            DPICHANGED = 0x02E0,
            DPICHANGED_BEFOREPARENT = 0x02E2,
            DPICHANGED_AFTERPARENT = 0x02E3,
            GETDPISCALEDSIZE = 0x02E4,
            CUT = 0x0300,
            COPY = 0x0301,
            PASTE = 0x0302,
            CLEAR = 0x0303,
            UNDO = 0x0304,
            RENDERFORMAT = 0x0305,
            RENDERALLFORMATS = 0x0306,
            DESTROYCLIPBOARD = 0x0307,
            DRAWCLIPBOARD = 0x0308,
            PAINTCLIPBOARD = 0x0309,
            VSCROLLCLIPBOARD = 0x030A,
            SIZECLIPBOARD = 0x030B,
            ASKCBFORMATNAME = 0x030C,
            CHANGECBCHAIN = 0x030D,
            HSCROLLCLIPBOARD = 0x030E,
            QUERYNEWPALETTE = 0x030F,
            PALETTEISCHANGING = 0x0310,
            PALETTECHANGED = 0x0311,
            HOTKEY = 0x0312,
            PRINT = 0x0317,
            PRINTCLIENT = 0x0318,
            APPCOMMAND = 0x0319,
            THEMECHANGED = 0x031A,
            CLIPBOARDUPDATE = 0x031D,
            DWMCOMPOSITIONCHANGED = 0x031E,
            DWMNCRENDERINGCHANGED = 0x031F,
            DWMCOLORIZATIONCOLORCHANGED = 0x0320,
            DWMWINDOWMAXIMIZEDCHANGE = 0x0321,
            DWMSENDICONICTHUMBNAIL = 0x0323,
            DWMSENDICONICLIVEPREVIEWBITMAP = 0x0326,
            GETTITLEBARINFOEX = 0x033F,
            HANDHELDFIRST = 0x0358,
            HANDHELDLAST = 0x035F,
            AFXFIRST = 0x0360,
            AFXLAST = 0x037F,
            PENWINFIRST = 0x0380,
            PENWINLAST = 0x038F,
            APP = 0x8000,
            USER = 0x0400,
        }

        internal enum ShowWindowCommand
        {
            HIDE = 0,
            SHOWNORMAL = 1,
            NORMAL = 1,
            SHOWMINIMIZED = 2,
            SHOWMAXIMIZED = 3,
            MAXIMIZE = 3,
            SHOWNOACTIVATE = 4,
            SHOW = 5,
            MINIMIZE = 6,
            SHOWMINNOACTIVE = 7,
            SHOWNA = 8,
            RESTORE = 9,
            SHOWDEFAULT = 10,
            FORCEMINIMIZE = 11,
            MAX = 11,
        }

        internal enum WindowStylesEx : uint
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

        internal enum WindowStyles : uint
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

        internal delegate LRESULT WNDPROC(HWND hWnd, WindowMessage msg, WPARAM wParam, LPARAM lParam);

        #endregion Delegates

        #region structs

        internal struct MSG
        {
            public HWND hwnd;
            public WindowMessage message;
            public WPARAM wparam;
            public LPARAM lparam;
            public uint time;
            public POINT pt;
        }

        internal struct POINT
        {
            public int x;
            public int y;
        }


        internal struct BOOL
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

        //internal struct WNDCLASSEXW
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
        internal unsafe partial struct WNDCLASSEXW
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

        internal struct HWND
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

        internal struct HINSTANCE
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

        internal struct LRESULT
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

        internal struct LPARAM
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

        internal struct WPARAM
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
        internal static ushort LOWORD(LPARAM value)
        {
            return unchecked((ushort)((nint)value & 0xffff));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        internal static ushort HIWORD(LPARAM value)
        {
            return unchecked((ushort)(((nint)value >> 16) & 0xffff));
        }

        #endregion

        #region Methods

        #region User32

        [DllImport("user32", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode, SetLastError = false)]
        // registers a new window class
        internal static extern short RegisterClassExW(ref WNDCLASSEXW wndclass);

        [DllImport("user32", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode, SetLastError = false)]
        // Creates a new window
        internal static extern HWND CreateWindowExW(WindowStylesEx wExStyle, char* lpClassName, char* lpWindowName, WindowStyles wStyle, int x, int y, int nWidth, int nHeight, void* hWndParent, void* hMenu, HINSTANCE hInstance, void* param);

        [DllImport("user32", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode, SetLastError = false)]
        // default window process
        internal static extern LRESULT DefWindowProcW(HWND hWnd, WindowMessage Msg, WPARAM wParam, LPARAM lParam);

        [DllImport("user32", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode, SetLastError = false)]
        // frees a handle to a module (aka a .dll file).
        internal static extern bool DestroyWindow(HWND hWnd);

        [DllImport("user32", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode, SetLastError = false)]
        internal static extern bool ShowWindow(HWND hWnd, ShowWindowCommand command);

        [DllImport("user32", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode, SetLastError = false)]
        internal static extern bool GetMessageW(MSG* lpMsg, HWND hWnd, uint wMsgFilterMin, uint wMsgFilterMax);

        [DllImport("user32", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode, SetLastError = false)]
        internal static extern bool TranslateMessage(MSG* lpMsg);

        [DllImport("user32", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode, SetLastError = false)]
        internal static extern LRESULT DispatchMessageW(MSG* lpMsg);

        [DllImport("user32", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode, SetLastError = false)]
        public static extern int MessageBox(HWND hwnd, string description, string title, MessageBoxFlags type);

        #endregion

        #region Kernel32

        [DllImport("kernel32", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode, SetLastError = false)]
        // gets a handle to a module (aka a .dll file). passing null returns the calling module.
        internal static extern HINSTANCE GetModuleHandleW(char* moduleName);

        [DllImport("kernel32", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode, SetLastError = false)]
        // frees a handle to a module (aka a .dll file).
        internal static extern bool FreeLibrary(HINSTANCE module);

        #endregion

        #endregion Methods
    }
}

#endif