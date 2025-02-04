Imports System
Imports System.Runtime.InteropServices



Namespace Helper
#Region "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ 0"
    Public Enum HeWindowStyle As UInteger
        WS_OVERLAPPED = 0UI
        WS_POPUP = 2147483648UI
        WS_CHILD = 1073741824UI
        WS_MINIMIZE = 536870912UI
        WS_VISIBLE = 268435456UI
        WS_DISABLED = 134217728UI
        WS_CLIPSIBLINGS = 67108864UI
        WS_CLIPCHILDREN = 33554432UI
        WS_MAXIMIZE = 16777216UI
        WS_CAPTION = 12582912UI
        WS_BORDER = 8388608UI
        WS_DLGFRAME = 4194304UI
        WS_VSCROLL = 2097152UI
        WS_HSCROLL = 1048576UI
        WS_SYSMENU = 524288UI
        WS_THICKFRAME = 262144UI
        WS_GROUP = 131072UI
        WS_TABSTOP = 65536UI
        WS_MINIMIZEBOX = 131072UI
        WS_MAXIMIZEBOX = 65536UI
        WS_TILED = 0UI
        WS_ICONIC = 536870912UI
        WS_SIZEBOX = 262144UI
        WS_TILEDWINDOW = 13565952UI
        WS_OVERLAPPEDWINDOW = 13565952UI
        WS_POPUPWINDOW = 2156396544UI
        WS_CHILDWINDOW = 1073741824UI
    End Enum



    Public Enum HeWindowExStyle As UInteger
        WS_EX_DLGMODALFRAME = 1UI
        WS_EX_NOPARENTNOTIFY = 4UI
        WS_EX_TOPMOST = 8UI
        WS_EX_ACCEPTFILES = 16UI
        WS_EX_TRANSPARENT = 32UI
        WS_EX_MDICHILD = 64UI
        WS_EX_TOOLWINDOW = 128UI
        WS_EX_WINDOWEDGE = 256UI
        WS_EX_CLIENTEDGE = 512UI
        WS_EX_CONTEXTHELP = 1024UI
        WS_EX_RIGHT = 4096UI
        WS_EX_LEFT = 0UI
        WS_EX_RTLREADING = 8192UI
        WS_EX_LTRREADING = 0UI
        WS_EX_LEFTSCROLLBAR = 16384UI
        WS_EX_RIGHTSCROLLBAR = 0UI
        WS_EX_CONTROLPARENT = 65536UI
        WS_EX_STATICEDGE = 131072UI
        WS_EX_APPWINDOW = 262144UI
        WS_EX_OVERLAPPEDWINDOW = 768UI
        WS_EX_PALETTEWINDOW = 392UI
        WS_EX_LAYERED = 524288UI
        WS_EX_NOINHERITLAYOUT = 1048576UI
        WS_EX_NOREDIRECTIONBITMAP = 2097152UI
        WS_EX_LAYOUTRTL = 4194304UI
        WS_EX_COMPOSITED = 33554432UI
        WS_EX_NOACTIVATE = 134217728UI
    End Enum
#End Region




#Region "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ 1"
    <StructLayout(LayoutKind.Sequential)>
    Public Structure HsPOINT
        Public Sub New(tx As Integer, ty As Integer)
            X = tx
            Y = ty
        End Sub

        Public X As Integer
        Public Y As Integer


        Public Overrides Function ToString() As String
            Dim txt As String = $"X: {X}, Y: {Y}"
            Return txt
        End Function
    End Structure



    <StructLayout(LayoutKind.Sequential)>
    Public Structure HsRECT
        Public Sub New(tl As Integer, tt As Integer, tr As Integer, tb As Integer)
            Left = tl
            Top = tt
            Right = tr
            Bottom = tb
        End Sub

        Public Left As Integer
        Public Top As Integer
        Public Right As Integer
        Public Bottom As Integer
        Public Arr() As Char

        Public ReadOnly Property Width As Integer
            Get
                Return Right - Left
            End Get
        End Property


        Public ReadOnly Property Height As Integer
            Get
                Return Bottom - Top
            End Get
        End Property


        Public Overrides Function ToString() As String
            Dim txt As String =
                $"Left: {Left}, Top: {Top}, Width: {Width}, Height: {Height}"
            Return txt
        End Function
    End Structure



    <StructLayout(LayoutKind.Sequential)>
    Public Structure HsWNDINFO
        Public hInstance As IntPtr
        Public hWnd As IntPtr
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=256)>
        Public lpszClassName As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=256)>
        Public lpszProcessName As String
        Public dwStyle As UInteger
        Public dwExStyle As UInteger
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=512)>
        Public lpszCaption As String
        Public uOpacity As Byte
        Public nLeft As Integer
        Public nTop As Integer
        Public nWidth As Integer
        Public nHeight As Integer
        Public bMinimizeBox As Boolean
        Public bMaximizeBox As Boolean
        Public bResizable As Boolean
        Public bTopMost As Boolean
    End Structure
#End Region


    Public NotInheritable Class HcWin32Helper
        Private Sub New()
        End Sub



        Private Const _dfpCommon As String = ".\Win32Common.dll"


        <DllImport(_dfpCommon, EntryPoint:="fn_MessageBox", CharSet:=CharSet.Ansi, SetLastError:=True)>
        Public Shared Function fn_MessageBox(
            hWnd As IntPtr, lpText As String, lpCaption As String, uType As UInteger) As Integer
        End Function


        <DllImport(_dfpCommon, EntryPoint:="fn_WorkRoll", CharSet:=CharSet.Ansi, SetLastError:=True)>
        Public Shared Function fn_WorkRoll(nx As Integer, ny As Integer, ByRef pWndInfo As HsWNDINFO) As Boolean
        End Function


        <DllImport(_dfpCommon, EntryPoint:="fn_UpdateRoll", CharSet:=CharSet.Ansi, SetLastError:=True)>
        Public Shared Function fn_UpdateRoll(hWndTarget As IntPtr, ByRef pWndInfo As HsWNDINFO) As Boolean
        End Function


        <DllImport(_dfpCommon, EntryPoint:="fn_ApplyRoll", CharSet:=CharSet.Ansi, SetLastError:=True)>
        Public Shared Function fn_ApplyRoll(hWndTarget As IntPtr, ByRef pWndInfo As HsWNDINFO) As Boolean
        End Function








        '#define MB_OK                       0x00000000L
        '#define MB_OKCANCEL                 0x00000001L
        '#define MB_ABORTRETRYIGNORE         0x00000002L
        '#define MB_YESNOCANCEL              0x00000003L
        '#define MB_YESNO                    0x00000004L
        '#define MB_RETRYCANCEL              0x00000005L









        'Private Const _dfnmUser32 As String = "user32.dll"
        'Private Const _dfnmKernel32 As String = "kernel32.dll"



        '<DllImport(_dfnmUser32, EntryPoint:="GetParent", CharSet:=CharSet.Auto, SetLastError:=True)>
        'Public Shared Function GetParent(hWnd As IntPtr) As IntPtr
        'End Function


        '<DllImport(_dfnmUser32, EntryPoint:="GetWindowRect", CharSet:=CharSet.Auto, SetLastError:=True)>
        'Public Shared Function GetWindowRect(hWnd As IntPtr, ByRef lpRect As SRECT) As Boolean
        'End Function


        '<DllImport(_dfnmUser32, EntryPoint:="SetWindowPos", CharSet:=CharSet.Auto, SetLastError:=True)>
        'Public Shared Function SetWindowPos(hWnd As IntPtr, hWndInsertAfter As IntPtr,
        '    x As Integer, y As Integer, cx As Integer, cy As Integer, uFlags As UInteger) As Boolean
        'End Function

    End Class
End Namespace