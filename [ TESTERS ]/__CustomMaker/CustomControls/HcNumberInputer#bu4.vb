Imports System
Imports System.Diagnostics
Imports System.Windows.Forms



Namespace CustomControls
    Public NotInheritable Class HcNumberInputer : Inherits TextBox
#Region "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ 1"
        Private Const _numChars As String = "-0123456789"


        Private Shared Function prCheckVal(ch As Char) As Boolean
            Dim fi As Integer = _numChars.IndexOf(ch)
            Return fi > -1
        End Function


        'Private Shared Function prCheckArrEmpty(charr As Char()) As Boolean
        '    Dim br As Boolean = (charr Is Nothing) OrElse (charr.Length.Equals(0))
        '    Return br
        'End Function


        Private Shared Function prFindLen(charr As Char()) As Integer
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


        Private Shared Sub prMoveLeft(charr() As Char, ji As Integer, zl As Integer)
            Dim len As Integer = charr.Length
            If (ji > 0) AndAlso (ji < len) AndAlso (zl > 0) Then
                If zl > ji Then
                    zl = ji
                End If

                Dim di As Integer = 0
                Dim ci As Integer = ji
                Dim na As Integer = ji - zl
                For i As Integer = 0 To len - 1
                    If ci < len Then
                        di = ci - zl
                        charr(di) = charr(ci)
                    Else
                        di = i + na
                        If di < len Then
                            charr(di) = Char.MinValue
                        Else
                            Exit For
                        End If
                    End If
                    ci += 1
                Next
            End If
        End Sub


        Private Shared Sub prMoveRight(charr() As Char, ji As Integer, zl As Integer)
            Dim len As Integer = charr.Length
            If (ji > -1) AndAlso (ji < len) AndAlso (zl > 0) Then
                Dim di As Integer, ci As Integer
                Dim i As Integer = len - 1
                While i >= ji
                    di = i
                    ci = i - zl
                    'Debug.WriteLine($"di={di}, ci={ci}")

                    If ci >= ji Then
                        charr(di) = charr(ci)
                    Else
                        charr(di) = Char.MinValue
                    End If

                    i -= 1
                End While
            End If
        End Sub
#End Region



#Region "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ 2"
        Public Sub New()
        End Sub



        Private ReadOnly m_charr(5 - 1) As Char
        Private m_num As Integer

        Public Const CBT_NORMAL As String = "normal"
        Private m_cbf As Action(Of String, Object)


        Public Sub InitOnce(cbf As Action(Of String, Object))
            prFillVals(m_charr, "65432")
            prUpdateText()
            m_cbf = cbf
        End Sub


        Public Overrides Property Text As String
            Get
                Return MyBase.Text
            End Get
            Set(value As String)
                prFillVals(m_charr, value)
                prUpdateText()
            End Set
        End Property
#End Region



#Region "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ 3"
        Private Shared ReadOnly _checkKeys() As Keys = {
            Keys.OemMinus, Keys.D0, Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5, Keys.D6, Keys.D7, Keys.D8, Keys.D9}


        Private Sub prUpdateText()
            m_num = prConvertInt(m_charr)
            MyBase.Text = Convert.ToString(m_num)
        End Sub


        Private Sub prPushVal(ch As Char)
            'If Not prCheckVal(ch) Then
            '    Return
            'End If

            Dim len As Integer = m_charr.Length
            Dim sl As Integer = SelectionLength
            Dim si As Integer = SelectionStart
            If sl > 0 Then
                If (si >= 0) AndAlso (si < len) Then
                    Dim ji As Integer = si + (sl - 1)
                    Dim zl As Integer = ji - si
                    prMoveLeft(m_charr, ji, zl)
                    m_charr(si) = ch
                    prUpdateText()
                    SelectionLength = 0
                    SelectionStart = si + 1
                End If
            Else
                If (si >= 0) AndAlso (si < len) Then
                    'm_charr(si) = ch
                    'prUpdateText()
                    'SelectionStart = si + 1

                    If ch.Equals("-"c) Then
                        If (si.Equals(0)) AndAlso (Not m_charr(0).Equals("-"c)) Then
                            prMoveRight(m_charr, 0, 1)
                            m_charr(si) = ch
                            prUpdateText()
                            SelectionStart = si + 1
                        End If
                    Else
                        m_charr(si) = ch
                        prUpdateText()
                        SelectionStart = si + 1
                    End If
                End If
            End If
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
                If Array.IndexOf(_checkKeys, ea.KeyCode) > -1 Then
                    ea.SuppressKeyPress = False
                End If
                'Dim ch As Char = ChrW(ea.KeyCode)
                ''Dim ch As Char = Convert.ToChar(ea.KeyValue)
                'If prCheckVal(ch) Then
                '    prPushVal(ch)
                '    'ea.SuppressKeyPress = False
                'End If
            End If
        End Sub


        Protected Overrides Sub OnKeyPress(ea As KeyPressEventArgs)
            'MyBase.OnKeyPress(ea)
            'Debug.WriteLine("#OnKeyPress")

            Dim ch As Char = ea.KeyChar
            If prCheckVal(ch) Then
                ea.Handled = True
                prPushVal(ch)
            End If
        End Sub
#End Region
    End Class
End Namespace