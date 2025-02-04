Imports System
Imports System.Diagnostics
Imports System.Drawing
Imports System.Windows.Forms



Namespace CustomControls
    Public NotInheritable Class HcNumericUpDown : Inherits NumericUpDown
#Region "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ 1"
        Public Sub New()
        End Sub


        Public Const CBT_NORMAL As String = "normal"
        Private m_cbf As Action(Of String, Object)

        Public Sub InitOnce(cbf As Action(Of String, Object))
            m_cbf = cbf
            'm_cbf?.Invoke(CBT_NORMAL, Nothing)
        End Sub
#End Region


        Protected Overrides Sub OnMouseWheel(ea As MouseEventArgs)
            Dim hmea As HandledMouseEventArgs = TryCast(ea, HandledMouseEventArgs)
            If hmea.Delta > 0 Then
                UpButton()
                hmea.Handled = True
            ElseIf hmea.Delta < 0 Then
                DownButton()
                hmea.Handled = True
            End If
            MyBase.OnMouseWheel(ea)
        End Sub
    End Class
End Namespace