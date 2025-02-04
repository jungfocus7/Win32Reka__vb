Imports System
Imports System.Diagnostics
Imports System.Windows.Forms



Namespace CustomControls
    Public NotInheritable Class HcNumBox : Inherits TextBox
        Public Const CBT_NORMAL As String = "normal"
        Private m_cbf As Action(Of String, Object)


        Public Sub InitOnce(cbf As Action(Of String, Object))
            m_cbf = cbf
        End Sub


        Public Sub New()
            MaxLength = 5
            m_timer.Interval = 2000
            AddHandler m_timer.Tick, AddressOf prTimerTick
        End Sub

        Private ReadOnly m_timer As New Timer()
        Private Sub prTimerTick(sd As Object, ea As EventArgs)
            m_timer.Stop()
            prUpdateNum()
            prApplyNum()
        End Sub
        Private Sub prDelayUpdate()
            m_timer.Stop()
            m_timer.Start()
        End Sub


        Public Overrides Property Text As String
            Get
                Return "Empty"
            End Get
            Set(value As String)
                Throw New Exception("Error")
            End Set
        End Property


        Private Const _signMinus As Char = "-"c
        Private Shared Function prCheckMinus(ch As Char) As Boolean
            Return ch.Equals(_signMinus)
        End Function
        Private Shared Function prConvertNum(nst As String) As Integer
            Dim num As Integer = 0

            Dim i As Integer = nst.Length - 1
            Dim sq As Integer = 1
            Dim ch As Char
            While i >= 0
                ch = nst(i)
                If Char.IsDigit(ch) Then
                    num += Val(ch) * sq
                    sq *= 10
                ElseIf i.Equals(0) AndAlso prCheckMinus(ch) Then
                    num *= -1
                End If
                i -= 1
            End While

            Return num
        End Function

        Private Const _min As Integer = -9999
        Private Const _max As Integer = 9999
        Private m_num As Integer = 0
        'Private Sub prUpdateNum()
        '    Dim val As Integer
        '    If Integer.TryParse(MyBase.Text, val) Then
        '        If val < _min Then
        '            val = _min
        '        ElseIf val > _max Then
        '            val = _max
        '        End If
        '        m_num = val
        '    Else
        '        m_num = 0
        '    End If
        'End Sub
        Private Sub prUpdateNum()
            Dim nst As String = MyBase.Text
            Dim val As Integer = prConvertNum(nst)
            If val < _min Then
                val = _min
            ElseIf val > _max Then
                val = _max
            End If
            m_num = val
        End Sub
        Private Sub prApplyNum()
            Dim pst As String = MyBase.Text
            Dim nst As String = m_num.ToString()
            Dim dl As Integer = nst.Length - pst.Length
            Dim si As Integer = SelectionStart
            If dl < 0 Then
                si += dl
            End If
            MyBase.Text = nst
            SelectionStart = si
        End Sub
        Public Function GetNum(Optional br As Boolean = False) As Integer
            If br Then
                prUpdateNum()
            End If
            Return m_num
        End Function
        Public Sub SetNum(val As Integer)
            If val < _min Then
                val = _min
            ElseIf val > _max Then
                val = _max
            End If
            m_num = val
            prApplyNum()
        End Sub

        Private Const _ad1 As Integer = 1
        Private Const _ad2 As Integer = 10
        Private Sub prNumberUpDown(ad As Integer)
            SetNum(m_num + ad)
        End Sub

        Protected Overrides Sub OnKeyDown(ea As KeyEventArgs)
            'MyBase.OnKeyDown(ea)
            'Debug.WriteLine("#OnKeyDown")

            Select Case ea.KeyCode
                Case Keys.Up
                    ea.SuppressKeyPress = True
                    prNumberUpDown(_ad1)

                Case Keys.Down
                    ea.SuppressKeyPress = True
                    prNumberUpDown(-_ad1)

                Case Keys.PageUp
                    ea.SuppressKeyPress = True
                    prNumberUpDown(_ad2)

                Case Keys.PageDown
                    ea.SuppressKeyPress = True
                    prNumberUpDown(-_ad2)

            End Select
        End Sub

        Private Const _inputChars As String = "+-0123456789"
        Private Function prCheckInput(ch As Char) As Boolean
            Return (_inputChars.IndexOf(ch) > -1) OrElse (ch = ControlChars.Back)
        End Function
        Protected Overrides Sub OnKeyPress(ea As KeyPressEventArgs)
            'MyBase.OnKeyPress(ea)
            'Debug.WriteLine("#OnKeyPress")

            'Dim ch As Char = ea.KeyChar
            'If prCheckInput(ch) Then
            '    prDelayUpdate()
            'Else
            '    ea.Handled = True
            'End If

            prDelayUpdate()
        End Sub
    End Class
End Namespace