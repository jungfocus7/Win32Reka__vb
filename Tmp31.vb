    <Extension()>
    Public Sub FillInteger(charr As Char(), str As String)
        If charr.CheckEmpty() Then
            Return
        End If

        Dim l As Integer = charr.Length
        Dim i As Integer = 0
        For i = 0 To l - 1
            charr(i) = Char.MinValue
        Next

        Dim bx As Boolean = False
        i = 0
        For Each ch As Char In str
            If Not bx Then
                If ch <> "0"c Then
                    bx = True
                Else
                    Continue For
                End If
            End If

            If (i < l) AndAlso ch.CheckValue() Then
                charr(i) = ch
                i += 1
            Else
                Exit For
            End If
        Next
    End Sub
	
	
                If (i = 0) AndAlso (ch = "-"c) Then

                End If	
				
				

'```````````````````````````````````````````````````````````````````````````````````````
    <Extension()>
    Public Sub FillInteger(charr As Char(), str As String)
        If charr.CheckEmpty() Then
            Return
        End If

        Dim l As Integer = charr.Length
        Dim i As Integer = 0
        For i = 0 To l - 1
            charr(i) = Char.MinValue
        Next

        Dim bx As Boolean = False
        i = 0
        For Each ch As Char In str
            If (i = 0) AndAlso (ch = "-"c) Then
                charr(i) = ch
                i += 1
                Continue For
            End If

            If (i < l) AndAlso ch.CheckValue() Then
                If Not bx Then
                    If ch <> "0"c Then
                        bx = True
                    Else
                        Continue For
                    End If
                End If


                charr(i) = ch
                i += 1
            End If
        Next
    End Sub
	
	
	
	
	
	
	
	
'```````````````````````````````````````````````````````````````````````````````````````
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

        Public Sub InitOnce(len As Integer, cbf As Action(Of String, Object))
            ReDim m_charr(len - 1)
            m_cbf = cbf
            'm_cbf?.Invoke(CBT_NORMAL, Nothing)
            fn_ApplyNumber(True)
        End Sub


        Private m_charr As Char()
        Private m_num As Integer


        Private Sub fn_ApplyNumber(bFirst As Boolean)
            'Dim arr(4) As Char
            ''arr.GetLength()
            ''Dim obj As Object
            'Dim y1 = arr.GetHashCode()
            ''arr = {"0"c, "1"c, "2"c, "3"c}
            'arr(0) = "0"c
            'arr(1) = "1"c
            'arr(2) = "2"c
            'arr(3) = "3"c
            'Dim y2 = arr.GetHashCode()
            ''arr{0, 1, 2, 3}
            'arr.FillString("경계하세요ㅋㅋㅋ")
            'Dim y3 = arr.GetHashCode()


            '~~~
            If bFirst Then
                m_charr.FillInteger("0100")
                m_charr.FillInteger("090100")
                m_charr.FillInteger("-04321")
                m_charr.FillInteger("931a")
                m_charr.FillInteger("-0098765")
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


        Protected Overrides Sub OnKeyPress(ea As KeyPressEventArgs)
            MyBase.OnKeyPress(ea)
            ea.Handled = True
            Dim ch As Char = ea.KeyChar
            If (ch >= "0"c) AndAlso (ch <= "9"c) Then
                Debug.WriteLine("~~~~")
                'Dim x0 = SelectionStart
                'Dim x1 = SelectionLength
                Dim l As Integer = m_charr.Length
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
            End If
        End Sub
    End Class
End Namespace	



	
	
	
	
	
	
	
	
'```````````````````````````````````````````````````````````````````````````````````````
Imports System
Imports System.Diagnostics
Imports System.Runtime.CompilerServices



Public Module HmCharArrayExtension
    Private Const _numChars As String = "-0123456789"


    Private Function prFindLen(charr As Char()) As Integer
        If (charr Is Nothing) OrElse (charr.Length = 0) Then
            Return 0
        End If

        Dim ri As Integer = 0
        For Each ch As Char In charr
            Dim fi As Integer = _numChars.IndexOf(ch)
            If fi < 0 Then
                Exit For
            Else
                ri += 1
            End If
        Next

        Return 0
    End Function


    <Extension()>
    Public Function CheckEmpty(charr As Char()) As Boolean
        Dim br As Boolean = (charr Is Nothing) OrElse (charr.Length = 0)
        Return br
    End Function


    <Extension()>
    Public Function CheckValue(ch As Char) As Boolean
        Dim fi As Integer = _numChars.IndexOf(ch)
        Return fi > -1
        'Dim br As Boolean = ((ch >= "0"c) AndAlso (ch <= "9"c)) OrElse (ch = "-"c)
        'Return br
    End Function


    <Extension()>
    Public Sub FillInteger(charr As Char(), str As String)
        If charr.CheckEmpty() Then
            Return
        End If

        Dim l As Integer = charr.Length
        Dim i As Integer = 0
        For i = 0 To l - 1
            charr(i) = ControlChars.NullChar
        Next

        Dim bx As Boolean = True
        i = 0
        For Each ch As Char In str
            If Not i < l Then
                Exit For
            End If

            If bx Then
                If (i = 0) AndAlso (ch = "-"c) Then
                    GoTo lb_a
                ElseIf ch <> "0"c Then
                    bx = False
                    GoTo lb_a
                Else
                    Continue For
                End If
            End If
lb_a:
            If ch.CheckValue() Then
                charr(i) = ch
                i += 1
            End If
        Next
    End Sub


    <Extension()>
    Public Sub PushValue(charr As Char(), sl As Integer, si As Integer, ch As Char)
        If charr.CheckEmpty() Then
            Return
        End If

        Dim al As Integer = charr.Length

        If sl > 0 Then

        End If

        If (si >= 0) AndAlso (si < charr.Length) Then
            If ch.CheckValue() Then
                charr(si) = ch
            End If
        End If
    End Sub
End Module



