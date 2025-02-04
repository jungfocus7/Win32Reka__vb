Imports System.Runtime.CompilerServices



Namespace Extensions
    Public Module HmCharArrayExtension
        Private Const _numChars As String = "-0123456789"


        <Extension()>
        Public Function CheckVal(ch As Char) As Boolean
            Dim fi As Integer = _numChars.IndexOf(ch)
            Return fi > -1
        End Function


        <Extension()>
        Public Function CheckEmpty(charr As Char()) As Boolean
            Dim br As Boolean = (charr Is Nothing) OrElse (charr.Length.Equals(0))
            Return br
        End Function


        <Extension()>
        Public Function FindLen(charr As Char()) As Integer
            If charr.CheckEmpty() Then
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


        <Extension()>
        Public Sub FillInt(charr As Char(), nstr As String)
            If charr.CheckEmpty() Then
                Return
            End If

            Dim len As Integer = charr.Length
            Dim i As Integer = 0
            For i = 0 To len - 1
                If i.Equals(0) Then
                    charr(i) = "0"c
                Else
                    charr(i) = ControlChars.NullChar
                End If
            Next

            i = 0
            Dim bFirst As Boolean = True
            For Each ch As Char In nstr
                If Not i < len Then
                    Exit For
                End If

                If bFirst Then
                    If i.Equals(0) AndAlso ch.Equals("-"c) Then
                        GoTo lb_a
                    ElseIf Not ch.Equals("0"c) Then
                        bFirst = False
                        GoTo lb_a
                    Else
                        Continue For
                    End If
                End If
lb_a:
                If ch.CheckVal() Then
                    charr(i) = ch
                    i += 1
                End If
            Next
        End Sub


        <Extension()>
        Public Sub PushVal(charr As Char(), sl As Integer, si As Integer, ch As Char)
            If charr.CheckEmpty() Then
                Return
            End If

            Dim al As Integer = charr.Length

            If sl > 0 Then

            End If

            If (si >= 0) AndAlso (si < charr.Length) Then
                If ch.CheckVal() Then
                    charr(si) = ch
                End If
            End If
        End Sub
    End Module
End Namespace






-------------------------------------------------------------------------------------
            'ReDim m_charr(len - 1)
            'm_charr.FillInt("-0ab")
            ReDim m_charr(7 - 1)
            'm_charr.FillVals("-0342ae-f4200")
            'm_charr.FillVals("00420.32")
            m_charr.FillVals("--~320-9923.-0234#-23987654321")
            m_charr.FillVals("14---0.056-a+bc+de995")
            Dim str = "14---0.056-a+bc+de995"
            str = New String(str.Reverse().ToArray())
            m_charr.FillVals(str)
            prUpdateText()
            m_cbf = cbf