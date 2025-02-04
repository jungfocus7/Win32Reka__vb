Imports System
Imports System.Diagnostics
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Linq



Namespace CustomControls
    Public NotInheritable Class HcNumberInputer : Inherits TextBox
        Public Sub New()
        End Sub


        Public Const CBT_NORMAL As String = "normal"
        Private m_cbf As Action(Of String, Object)

        Public Sub InitOnce(cbf As Action(Of String, Object))
            m_cbf = cbf
            'm_cbf?.Invoke(CBT_NORMAL, Nothing)
            fn_ApplyNumber(True)
        End Sub


        Private m_charr(4) As Char
        Private m_num As Integer

        Private Sub fn_ApplyNumber(bFirst As Boolean)
            If bFirst Then
                For i As Integer = 0 To m_charr.Length - 1
                    m_charr(i) = "0"c
                Next
            End If

            Try
                Dim nstr As String = Convert.ToString(m_charr)
                m_num = Integer.Parse(nstr)
                Text = Convert.ToString(m_num)
            Catch
                m_num = 0
                Text = Convert.ToString(m_num)
            End Try
        End Sub

        Protected Overrides Sub OnTextChanged(ea As EventArgs)
            MyBase.OnTextChanged(ea)
        End Sub

        Protected Overrides Sub OnKeyPress(ea As KeyPressEventArgs)
            MyBase.OnKeyPress(ea)

            Dim ch As Char = ea.KeyChar
            If (ch >= "0"c) AndAlso (ch <= "9"c) Then
                Debug.WriteLine("~~~~")
                'Dim x0 = SelectionStart
                'Dim x1 = SelectionLength
                Dim i As Integer = SelectionStart
                m_charr(i) = ch
                'Text
                'Dim n0 As Integer = Val(ch)
                'm_num += n0
                'Text = Convert.ToString(m_num)
                'm_num
                'Dim num As Integer = Convert.ToInt32(Text)
                'Dim num As Integer
                'If Integer.TryParse(Text, num) Then
                '    Debug.WriteLine($">>> {num}")
                'End If
                'Char.
            Else
                ea.Handled = True
            End If
        End Sub

        'Protected Overrides Sub OnKeyDown(e As KeyEventArgs)
        '    MyBase.OnKeyDown(e)
        'End Sub
    End Class
End Namespace