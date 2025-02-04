Public Module TesterModule
    Private Sub prTester31()
    End Sub


    Private Function prConvertInt(charr() As Char) As Integer
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


    Private Sub prMoveLeft(charr() As Char, ji As Integer, zl As Integer)
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


    Private Sub prMoveRight(charr() As Char, ji As Integer, zl As Integer)
        Dim len As Integer = charr.Length
        If (ji > -1) AndAlso (ji < len) AndAlso (zl > 0) Then
            Dim di As Integer, ci As Integer
            Dim i As Integer = len - 1
            While i >= ji
                di = i
                ci = i - zl
                Debug.WriteLine($"di={di}, ci={ci}")

                If ci >= ji Then
                    charr(di) = charr(ci)
                Else
                    charr(di) = Char.MinValue
                End If
                i -= 1
            End While
        End If
    End Sub


    Private Sub prAssignValue(ji As Integer, ch As Char)
        '##32031#
        Dim al As Integer = m_charr.Length
        If (ji > -1) AndAlso (ji < al) Then
            m_charr(ji) = ch

            Dim xx As Char = ChrW(0)

            Dim pc As Char, cc As Char
            For i As Integer = 0 To al - 1
                cc = m_charr(i)
                If prCheckVal(cc) Then
                    If Not prCheckVal(pc) Then
                        m_charr(i - 1) = cc
                        m_charr(i) = Char.MinValue
                    End If
                End If

                pc = cc
            Next
        End If
    End Sub


    Public Sub Main(args As String())
        'Dim nstr As String = "-9876!@#%asdvf887a.e34"
        'If Not String.IsNullOrWhiteSpace(nstr) Then
        '    Dim charr() As Char = nstr.ToCharArray()
        '    Dim num As Integer = prConvertInt(charr)

        '    Debug.WriteLine("~~~~~~~~~~")
        'End If

        Dim nstr As String = "00000987654321"
        Dim charr() As Char

        charr = nstr.ToCharArray()
        prMoveLeft(charr, 5, 2)

        charr = nstr.ToCharArray()
        prMoveLeft(charr, 5, 5)

        charr = nstr.ToCharArray()
        prMoveLeft(charr, 5, 10)

        charr = nstr.ToCharArray()
        prMoveLeft(charr, 5, -20)

        charr = nstr.ToCharArray()
        prMoveRight(charr, 5, 1)
    End Sub
End Module
