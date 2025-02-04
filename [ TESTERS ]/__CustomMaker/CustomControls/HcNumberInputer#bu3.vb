Imports System
Imports System.Windows.Forms



Namespace CustomControls
    Public NotInheritable Class HcNumberInputer : Inherits TextBox
#Region "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ 1"
        Private Const _numChars As String = "-0123456789"


        Private Shared Function prCheckVal(ch As Char) As Boolean
            Dim fi As Integer = _numChars.IndexOf(ch)
            Return fi > -1
        End Function


        Private Shared Function prCheckEmpty(charr As Char()) As Boolean
            Dim br As Boolean = (charr Is Nothing) OrElse (charr.Length.Equals(0))
            Return br
        End Function


        Private Shared Function prFindLen(charr As Char()) As Integer
            If prCheckEmpty(charr) Then
                Return 0
            End If

            Dim ri As Integer = 0
            For Each ch As Char In charr
                Dim fi As Integer = _numChars.IndexOf(ch)
                If fi > -1 Then
                    ri += 1
                Else
                    Exit For
                End If
            Next

            Return ri
        End Function


        Private Shared Sub prFillVals(charr As Char(), nstr As String)
            If prCheckEmpty(charr) Then
                Return
            End If

            Dim len As Integer = charr.Length
            Dim i As Integer

            For i = 0 To len - 1
                If i.Equals(0) Then
                    charr(i) = "0"c
                Else
                    charr(i) = Char.MinValue
                End If
            Next

            i = 0
            Dim pc As Char
            For Each ch As Char In nstr
                If Not prCheckVal(ch) Then
                    Continue For
                End If

                If i < len Then
                    If i.Equals(0) Then
                        If Not ch.Equals("0"c) Then
                            charr(i) = ch
                            pc = ch
                            i += 1
                        End If
                    ElseIf i.Equals(1) Then
                        If pc.Equals("-"c) Then
                            If (Not ch.Equals("0"c)) AndAlso (Not ch.Equals("-"c)) Then
                                charr(i) = ch
                                pc = ch
                                i += 1
                            End If
                        Else
                            charr(i) = ch
                            pc = ch
                            i += 1
                        End If
                    ElseIf i > 1 Then
                        If Not ch.Equals("-"c) Then
                            charr(i) = ch
                            pc = ch
                            i += 1
                        End If
                    End If
                Else
                    Exit For
                End If
            Next

            If pc.Equals("-"c) Then
                charr(0) = "0"c
            End If
        End Sub


        Private Shared Function prConvertInt(charr() As Char) As Integer
            If (charr Is Nothing) OrElse (charr.Length = 0) Then
                Return 0
            End If

            Dim num As Integer = 0
            Dim i As Integer = charr.Length - 1
            Dim sq As Integer = 1
            Dim ch As Char
            While i >= 0
                ch = charr(i)
                If Char.IsDigit(ch) Then
                    num += Val(ch) * sq
                    sq *= 10
                ElseIf i.Equals(0) AndAlso ch.Equals("-"c) Then
                    num *= -1
                End If
                i -= 1
            End While

            Return num
        End Function
#End Region



#Region "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ 2"
        Public Sub New()
        End Sub



        Private ReadOnly m_charr(5 - 1) As Char
        Private m_num As Integer

        Public Const CBT_NORMAL As String = "normal"
        Private m_cbf As Action(Of String, Object)


        Public Sub InitOnce(cbf As Action(Of String, Object))
            prFillVals(m_charr, "654321")
            prUpdateText()
            m_cbf = cbf
        End Sub
#End Region



#Region "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ 3"
        Private Sub prUpdateText()
            If prCheckEmpty(m_charr) Then
                Return
            End If

            m_num = prConvertInt(m_charr)
            Text = Convert.ToString(m_num)
        End Sub


        Private Sub prPushVal(ch As Char)
            If prCheckEmpty(m_charr) Then
                Return
            End If

            'Dim len As Integer = charr.Length
            'If (si >= 0) AndAlso (si < len) Then
            '    If prCheckVal(ch) Then
            '        charr(si) = ch
            '    End If
            'End If


            'If sl > 0 Then

            'End If

            'If (si >= 0) AndAlso (si < charr.Length) Then
            '    If prCheckVal(ch) Then
            '        charr(si) = ch
            '    End If
            'End If

            'prUpdateText()
            'SelectionStart = si + 1
        End Sub


        Protected Overrides Sub OnPreviewKeyDown(ea As PreviewKeyDownEventArgs)
            'MyBase.OnPreviewKeyDown(ea)
            'Debug.WriteLine("#OnPreviewKeyDown")
        End Sub


        Protected Overrides Sub OnKeyDown(ea As KeyEventArgs)
            'MyBase.OnKeyDown(ea)
            'Debug.WriteLine("#OnKeyDown", ea.KeyData.ToString())

            ea.SuppressKeyPress = True
            If (ea.KeyCode = Keys.Left) OrElse (ea.KeyCode = Keys.Right) OrElse
                (ea.KeyCode = Keys.Home) OrElse (ea.KeyCode = Keys.End) Then
                ea.SuppressKeyPress = False
            Else
                Dim ch As Char = ChrW(ea.KeyCode)
                If prCheckVal(ch) Then
                    prPushVal(ch)
                End If
            End If

            'If (ea.KeyCode = Keys.Up) OrElse (ea.KeyCode = Keys.Down) Then
            '    ea.SuppressKeyPress = True
            'ElseIf ea.KeyCode = Keys.Space Then
            '    ea.SuppressKeyPress = True
            'ElseIf ea.KeyCode = Keys.Delete Then
            '    ea.SuppressKeyPress = True
            'ElseIf ea.KeyCode = Keys.Back Then
            '    ea.SuppressKeyPress = True
            'Else
            '    Dim ch As Char = ChrW(ea.KeyCode)
            '    If prCheckVal(ch) Then
            '        ea.SuppressKeyPress = True
            '        prPushVal(ch)
            '    Else
            '        ea.SuppressKeyPress = True
            '    End If
            'End If
        End Sub


        Protected Overrides Sub OnKeyPress(ea As KeyPressEventArgs)
            'MyBase.OnKeyPress(ea)
            'Debug.WriteLine("#OnKeyPress")

            'ea.Handled = True
            'Dim ch As Char = ea.KeyChar
            'If prCheckVal(ch) Then
            '    prPushVal(ch)
            'End If
        End Sub
#End Region
    End Class
End Namespace