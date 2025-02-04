Imports System
Imports System.Diagnostics
Imports System.Windows.Forms



Namespace CustomControls
    Public NotInheritable Class HcIntegerInputer1 : Inherits TextBox
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
            Dim val As Integer
            If Integer.TryParse(MyBase.Text, val) Then
                prSetNum(val)
            End If
        End Sub
        Private Sub prDelayUpdate()
            m_timer.Stop()
            m_timer.Start()
        End Sub

        Private Const _min As Integer = -9999
        Private Const _max As Integer = 9999
        Private m_num As Integer = 0
        Private Sub prSetNum(val As Integer)
            m_num = val
            If m_num < _min Then
                m_num = _min
            ElseIf m_num > _max Then
                m_num = _max
            End If

            Dim nstr As String = m_num.ToString()
            Dim si As Integer = SelectionStart

            MyBase.Text = nstr
            Debug.WriteLine($"~~~~{MyBase.Text}")
            SelectionStart = si
        End Sub
        Public Function GetNum() As Integer
            Return m_num
        End Function
        Public Property Value As Integer
            Get
                Return m_num
            End Get
            Set(val As Integer)
                prSetNum(val)
            End Set
        End Property


        Public Overrides Property Text As String
            Get
                Return MyBase.Text
            End Get
            Set(value As String)
                'MyBase.Text = value
                Throw New Exception("Error")
            End Set
        End Property

        Private Const _ad1 As Integer = 1
        Private Const _ad2 As Integer = 10
        Private Sub prNumberUpDown(ad As Integer)
            Dim val As Integer
            If Integer.TryParse(MyBase.Text, val) Then
                prSetNum(val + ad)
            End If
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

            Dim ch As Char = ea.KeyChar
            If prCheckInput(ch) Then
                prDelayUpdate()
            Else
                ea.Handled = True
            End If
        End Sub
    End Class
End Namespace