Imports System
Imports System.Diagnostics
Imports System.Linq
Imports System.Windows.Forms
Imports __CustomMaker.Extensions



Namespace CustomControls
    Public NotInheritable Class HcNumberInputer : Inherits TextBox
        Public Sub New()
        End Sub



        Private m_charr As Char()
        Private m_num As Integer

        Public Const CBT_NORMAL As String = "normal"
        Private m_cbf As Action(Of String, Object)


        Public Sub InitOnce(len As Integer, cbf As Action(Of String, Object))
            ReDim m_charr(len - 1)
            m_charr.FillVals("0")
            prUpdateText()
            m_cbf = cbf
        End Sub


        Private Sub prUpdateText()
            Try
                Dim len As Integer = m_charr.FindLen()
                Dim nstr As String = New String(m_charr, 0, len)
                m_num = Integer.Parse(nstr)
                Text = Convert.ToString(m_num)
            Catch
                m_num = 0
                Text = Convert.ToString(m_num)
            End Try
        End Sub


        'Protected Overrides Sub WndProc(ByRef m As Message)
        '    Select Case m.Msg
        '        Case &H100
        '            Debug.WriteLine("~~~")
        '            Exit Sub
        '    End Select

        '    MyBase.WndProc(m)
        'End Sub


        'Protected Overrides Sub OnPreviewKeyDown(ea As PreviewKeyDownEventArgs)
        '    MyBase.OnPreviewKeyDown(ea)
        '    'ea.IsInputKey = True
        'End Sub


        Protected Overrides Sub OnKeyDown(ea As KeyEventArgs)
            MyBase.OnKeyDown(ea)
            ea.Handled = True
            ea.SuppressKeyPress = True
            'If ea.KeyCode = Keys.Up Then
            '    ea.Handled = True
            'ElseIf ea.KeyCode = Keys.Down Then
            '    ea.Handled = True
            'End If
        End Sub


        Private Const _kcUp As Char = ChrW(Keys.Up)
        Private Const _kcDown As Char = ChrW(Keys.Down)
        Private Const _kcBack As Char = ChrW(Keys.Back)
        Private Const _kcDelete As Char = ChrW(Keys.Delete)
        Protected Overrides Sub OnKeyPress(ea As KeyPressEventArgs)
            Dim ch As Char = ea.KeyChar
            If ch.Equals(_kcUp) Then
                ea.Handled = True
            ElseIf ch.Equals(_kcDown) Then
                ea.Handled = True
            ElseIf ch.Equals(_kcBack) Then
                ea.Handled = True
            ElseIf ch.Equals(_kcDelete) Then
                ea.Handled = True
            ElseIf ch.CheckVal() Then
                ea.Handled = True
                Dim sl As Integer = SelectionLength
                Dim si As Integer = SelectionStart
                m_charr.PushVal(sl, si, ch)
                prUpdateText()
                SelectionStart = si + 1
            Else
                ea.Handled = True
            End If

            MyBase.OnKeyPress(ea)

            'If ch.Equals(ControlChars.Back) Then
            '    ea.Handled = True
            'ElseIf ch.Equals(Keys.Back) Then
            '    ea.Handled = True
            'ElseIf ch.CheckVal() Then
            '    ea.Handled = True
            '    Dim sl As Integer = SelectionLength
            '    Dim si As Integer = SelectionStart
            '    m_charr.PushVal(sl, si, ch)
            '    prUpdateText()
            '    SelectionStart = si + 1

            '    'If sl > 0 Then
            '    'Else
            '    '    m_charr.PushVal(sl, si, ch)
            '    '    prUpdateText()
            '    '    'SelectionLength = 9999
            '    '    'SelectionStart = 999
            '    'End If
            'Else
            '    ea.Handled = True
            'End If

        End Sub
    End Class
End Namespace