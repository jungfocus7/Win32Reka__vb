Imports System


Namespace Models
    Public NotInheritable Class HotkeyInfo
        Public hwnd As IntPtr
        Public id As Integer
        Public fsModifiers As Integer
        Public vk As Integer
        Public cbf As Action
    End Class
End Namespace