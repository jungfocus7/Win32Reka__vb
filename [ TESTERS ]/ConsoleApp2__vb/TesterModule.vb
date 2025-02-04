Public NotInheritable Class HcCharArrayHelper

End Class


Public Module TesterModule
    Private Sub prTester31()
    End Sub


    Private Const _numChars As String = "0123456789"
    Private Function prCheckVal(ch As Char) As Boolean
        Dim fi As Integer = _numChars.IndexOf(ch)
        Return fi > -1
    End Function


    'Private Function prCheckArrEmpty(charr As Char()) As Boolean
    '    Dim br As Boolean = (charr Is Nothing) OrElse (charr.Length.Equals(0))
    '    Return br
    'End Function


    Private Function prGetJotIndex(charr() As Char, j As Integer) As Integer
        Dim ri As Integer = -1

        Dim al As Integer = charr.Length
        Dim i As Integer = If(j < 0, 0, j)

        While i < al
            If Not prCheckVal(charr(i)) Then
                ri = i
                Exit While
            End If

            i += 1
        End While

        Return ri
    End Function


    Private Sub prCleanUpArr(charr() As Char)
        Dim cc As Char
        Dim j As Integer = -1

        For i As Integer = 0 To charr.Length - 1
            cc = charr(i)
            If prCheckVal(cc) Then
                j = prGetJotIndex(charr, j)
                If (j > -1) AndAlso (j < i) Then
                    charr(j) = cc
                    charr(i) = Char.MinValue
                End If
            Else
                charr(i) = Char.MinValue
            End If
        Next
    End Sub


    Private Sub prAssignValue(ji As Integer, ch As Char)

    End Sub


    Public Sub Main(args As String())
        'Dim nstr As String = "##32031#"
        'Dim nstr As String = "##33##99-##32#031#123####123##2##########877"
        'Dim nstr As String = "987654"
        Dim nstr As String = "987654##"
        Dim charr() As Char = nstr.ToCharArray()
        prCleanUpArr(charr)
        prAssignValue(2, "1"c)
    End Sub
End Module
