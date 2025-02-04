Imports System
Imports System.Diagnostics
Imports System.Drawing
Imports System.Windows.Forms


Namespace CustomControls
    Public NotInheritable Class HcTargetBox : Inherits Control
        Public Sub New()
            Dim pad As New Padding(0, 0, 0, 0)
            Margin = pad
            Padding = pad
            BackColor = Color.DimGray
            Cursor = Cursors.Hand
            DoubleBuffered = True
        End Sub



        Private m_frmMain As HcMainForm
        Private m_cold As Color
        Private m_callback As Action

        Private m_bmd As Boolean
        Private m_txt As String


        Public Sub InitOnce(cbf As Action)
            If m_frmMain Is Nothing Then
                m_frmMain = HcMainForm.MainForm
                m_cold = BackColor
                m_callback = cbf
                AddHandler m_frmMain.Deactivate, AddressOf fn_Deactivate
            End If
        End Sub


        Protected Overrides Sub OnPaint(ea As PaintEventArgs)
            MyBase.OnPaint(ea)
            If Not String.IsNullOrWhiteSpace(m_txt) Then
                Using ft As New Font(Font.FontFamily, 8, FontStyle.Bold)
                    Using sfm As New StringFormat()
                        sfm.Alignment = StringAlignment.Center
                        sfm.LineAlignment = StringAlignment.Center
                        Dim rt As Rectangle = ea.ClipRectangle
                        ea.Graphics.DrawString(m_txt, ft, Brushes.WhiteSmoke, rt, sfm)
                    End Using
                End Using
            End If
        End Sub


        Private Sub fn_Deactivate(sd As Object, ea As EventArgs)
            If m_bmd Then
                'Debug.WriteLine("fn_Deactivate")
                BackColor = m_cold
                m_frmMain.Cursor = Cursors.Default
                m_txt = String.Empty
                m_bmd = False
            End If
        End Sub


        Protected Overrides Sub OnMouseUp(ea As MouseEventArgs)
            'MyBase.OnMouseUp(ea)
            If m_bmd Then
                Debug.WriteLine("fn_MouseUp")
                fn_Deactivate(Nothing, Nothing)
                m_callback?.Invoke()
            End If
        End Sub


        Protected Overrides Sub OnMouseDown(ea As MouseEventArgs)
            'MyBase.OnMouseDown(ea)
            If ea.Button = MouseButtons.Left Then
                'Debug.WriteLine("fn_MouseDown")
                BackColor = Color.Black
                m_frmMain.Cursor = Cursors.Cross
                m_bmd = True
                OnMouseMove(Nothing)
            End If
        End Sub


        Protected Overrides Sub OnMouseMove(ea As MouseEventArgs)
            'MyBase.OnMouseMove(ea)
            If m_bmd Then
                'Debug.WriteLine($"fn_MouseMove")
                Dim mpt As Point = MousePosition
                m_txt = $"{mpt.X.ToString("D4")}, {mpt.Y.ToString("D4")}"
                Invalidate()
            End If
        End Sub






        'Protected Overrides Sub OnMouseCaptureChanged(ea As EventArgs)
        '    'MyBase.OnMouseCaptureChanged(ea)
        '    Debug.WriteLine("OnMouseCaptureChanged")
        '    Cursor = Cursors.Hand
        'End Sub


        'Protected Overrides Sub OnMouseUp(ea As MouseEventArgs)
        '    MyBase.OnMouseUp(ea)
        '    Debug.WriteLine("OnMouseUp")
        '    'Cursor = Cursors.Hand
        '    HcMainForm.MainForm.Cursor = Cursors.Default
        'End Sub


        'Protected Overrides Sub OnMouseDown(ea As MouseEventArgs)
        '    MyBase.OnMouseDown(ea)
        '    If ea.Button = MouseButtons.Left Then
        '        Debug.WriteLine("OnMouseDown")
        '        HcMainForm.MainForm.Cursor = Cursors.Cross
        '        'Capture = True
        '    End If
        'End Sub


        'Protected Overrides Sub OnMouseMove(ea As MouseEventArgs)
        '    MyBase.OnMouseMove(ea)
        'End Sub


        'Public Sub Deactivate()
        '    'OnMouseUp(Nothing)
        'End Sub

    End Class
End Namespace
