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
        Public Sub FillVals(charr As Char(), nstr As String)
            If charr.CheckEmpty() Then
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
                If Not ch.CheckVal() Then
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


        <Extension()>
        Public Sub PushVal(charr As Char(), sl As Integer, si As Integer, ch As Char)
            If charr.CheckEmpty() Then
                Return
            End If

            Dim len As Integer = charr.Length
            If (si >= 0) AndAlso (si < len) Then
                If ch.CheckVal() Then
                    charr(si) = ch
                End If
            End If


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
