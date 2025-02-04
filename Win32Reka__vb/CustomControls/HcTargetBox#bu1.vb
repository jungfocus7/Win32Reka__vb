Imports System
Imports System.Diagnostics
Imports System.Drawing
Imports System.Windows.Forms



Public NotInheritable Class HcTargetBox : Inherits Control
    Public Sub New()
        Dim pad As New Padding(0, 0, 0, 0)
        Margin = pad
        Padding = pad
        BackColor = Color.DimGray
        Dim x0 = BackColor
        Cursor = Cursors.Hand
        DoubleBuffered = True
    End Sub


    Private m_frmMain As HcMainForm
    Private m_bmd As Boolean = False
    Private m_cold As Color
    Private m_txt As String

    Public Sub InitOnce()
        m_frmMain = HcMainForm.MainForm
        m_cold = BackColor
        AddHandler m_frmMain.Deactivate, AddressOf fn_Deactivate
        'AddHandler MouseUp, AddressOf fn_MouseUp
        'AddHandler MouseDown, AddressOf fn_MouseDown
        'AddHandler MouseMove, AddressOf fn_MouseMove
    End Sub


    Protected Overrides Sub OnPaint(ea As PaintEventArgs)
        MyBase.OnPaint(ea)

        'ea.Graphics.DrawString(Font, Brushes.WhiteSmoke, )
        Dim mpt As Point = MousePosition
        Dim txt As String = $"{mpt.X.ToString("D4")}, {mpt.Y.ToString("D4")}"
        Using ft As New Font(Font.FontFamily, 8, FontStyle.Bold)
            Using sfm As New StringFormat()
                sfm.Alignment = StringAlignment.Center
                sfm.LineAlignment = StringAlignment.Center
                Dim rt As Rectangle = ea.ClipRectangle
                ea.Graphics.DrawString(txt, ft, Brushes.WhiteSmoke, rt, sfm)
            End Using
        End Using

        'Using (Font tft = New Font(Font.FontFamily, Font.Size, FontStyle.Bold))
        '            //using (Font tft = New Font(Font.FontFamily, 12, FontStyle.Bold))
        '            {
        '                Object tval = tci.Value;
        '                If (tval Is String) Then
        '                                {
        '                    Rectangle tr2 = trct;
        '                    tr2.Inflate(-10, -10);
        '                    tg.DrawString(tval.ToString(), tft, Brushes.Black, tr2, tsf);
        '                }
        '                ElseIf (tval Is Image) Then
        '                                {
        '                    Image timg = (Image)tval;
        '                    Rectangle tr3 = trct;
        '                    //tr3.Inflate(-2, -2);
        '                    tg.DrawImage(timg, tr3);
        '                }
        '            }

    End Sub


    'Protected Overrides Sub OnPaintBackground(ea As PaintEventArgs)
    '    MyBase.OnPaintBackground(ea)
    '    ea.Graphics.Clear(Color.Aqua)
    'End Sub



    Private Sub fn_Deactivate(sd As Object, ea As EventArgs)
        Debug.WriteLine("fn_Deactivate " + MouseButtons.ToString())
        If m_frmMain.Cursor <> Cursors.Default Then
            m_frmMain.Cursor = Cursors.Default
            BackColor = m_cold
        End If
    End Sub


    Protected Overrides Sub OnMouseUp(ea As MouseEventArgs)
        'MyBase.OnMouseUp(ea)
        If ea.Button = MouseButtons.Left Then
            Debug.WriteLine("fn_MouseUp " + MouseButtons.ToString())
            fn_Deactivate(Nothing, Nothing)
        End If
    End Sub


    Protected Overrides Sub OnMouseDown(ea As MouseEventArgs)
        'MyBase.OnMouseDown(ea)
        If ea.Button = MouseButtons.Left Then
            Debug.WriteLine("fn_MouseDown " + MouseButtons.ToString())
            BackColor = Color.Black
            m_frmMain.Cursor = Cursors.Cross
        End If
    End Sub


    Protected Overrides Sub OnMouseMove(ea As MouseEventArgs)
        'MyBase.OnMouseMove(ea)
        If ea.Button = MouseButtons.Left Then
            Debug.WriteLine($"fn_MouseMove " + MouseButtons.ToString())
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
