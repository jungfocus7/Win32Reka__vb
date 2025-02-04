Imports System
Imports System.Windows.Forms
Imports Win32Reka__vb.CustomControls


Namespace Helper
    Public NotInheritable Class HcValueHelper
        Private Sub New()
        End Sub


        Public Shared Function ToText(txb As TextBox) As String
            Dim val As String = txb.Text
            If String.IsNullOrWhiteSpace(val) Then
                Return String.Empty
            Else
                Return val
            End If
        End Function


        Public Shared Function ToOpacity(nbb As HcNumBox) As Byte
            Const MinVal As Byte = 30

            Dim val As Byte
            Try
                val = CByte(nbb.GetNum(True))
                If val < MinVal Then
                    val = MinVal
                    nbb.Text = val.ToString()
                End If
                Return val
            Catch
                val = MinVal
                nbb.Text = val.ToString()
                Return val
            End Try
        End Function


        Public Shared Function ToInteger(nbb As HcNumBox) As Integer
            Dim val As Integer
            Try
                val = nbb.GetNum(True)
                Return val
            Catch
                val = 0
                Return val
            End Try
        End Function

    End Class
End Namespace
