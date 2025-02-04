Imports System
Imports System.Diagnostics
Imports System.Drawing
Imports System.Windows.Forms



Namespace CustomControls
    Public NotInheritable Class HcNumberInputer : Inherits TextBox
        Public Sub New()
            'Dim ch0 As Char = "9"c
            'Dim ch1 As Char = "0"c
            'Dim ch2 As Char = "9"c
            'Dim x0 = AscW(ch0)
            'Dim x1 = AscW(ch1)
            'If (Val(ch0) >= Val(ch1)) AndAlso (Val(ch0) <= Val(ch2)) Then
            '    Dim x3 = "a"c
            'End If


            'Dim ch1 As Integer = 100
            'Dim x1 = ch1 - 20
            'Dim ch2 As Char = "a"c
            'Dim x2 = Convert.ToByte(ch2) - "2"c
            'Dim x3 = CType(ch2, Byte)
            'Dim x4 = CInt("2")
            'Dim ch As Char = "0"c
            'Dim x0 = ch - "1"c
            'Dim x0 = CType(ch, Integer)
            'Dim x1 = ch - CType("1"c, Char)
            'ch = "3"c - "2"c
            'Dim nx As Integer = ---231
            'Dim nx As Short
        End Sub



        Public Const CBT_NORMAL As String = "normal"
        Private m_cbf As Action(Of String, Object)

        Public Sub InitOnce(cbf As Action)
            'm_cbf?.Invoke(CBT_NORMAL, Nothing)
        End Sub



        Private m_num As Integer
        Private m_charr(4) As Char


        Private Sub fn_ApplyValue()

        End Sub

        'Protected Overrides Sub OnPreviewKeyDown(ea As PreviewKeyDownEventArgs)
        '    MyBase.OnPreviewKeyDown(ea)
        'End Sub

        'Protected Overrides Sub OnKeyDown(ea As KeyEventArgs)
        '    MyBase.OnKeyDown(ea)
        'End Sub

        'Protected Overrides Sub OnKeyPress(ea As KeyPressEventArgs)
        '    ea.Handled = True
        '    MyBase.OnKeyPress(ea)
        'End Sub

        Protected Overrides Sub OnKeyPress(ea As KeyPressEventArgs)
            MyBase.OnKeyPress(ea)
            ea.Handled = True
            Dim ch As Char = ea.KeyChar
            If (ch >= "0"c) AndAlso (ch <= "9"c) Then

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
            End If
        End Sub
    End Class
End Namespace