Imports System
Imports System.Runtime.InteropServices



Namespace Helper
    Public Enum HeMsgBoxUType As UInteger
        MB_OK = 0UI
        MB_OKCANCEL = 1UI
        MB_ABORTRETRYIGNORE = 2UI
        MB_YESNOCANCEL = 3UI
        MB_YESNO = 4UI
        MB_RETRYCANCEL = 5UI
    End Enum



    Public NotInheritable Class HcMsgBoxHelper
        Private Sub New()
        End Sub



        Public Shared Caption As String = "[Notify]"


        Public Shared Function Show(
            hWnd As IntPtr, lpText As String, lpCaption As String, uType As UInteger) As Integer
            Return HcWin32Helper.fn_MessageBox(hWnd, lpText, lpCaption, uType)
        End Function


        Public Shared Function Show_a(hWnd As IntPtr, lpText As String) As Integer
            Dim lpCaption As String = Caption
            Dim uType As UInteger = HeMsgBoxUType.MB_OK
            Return HcWin32Helper.fn_MessageBox(hWnd, lpText, lpCaption, uType)
        End Function

    End Class
End Namespace