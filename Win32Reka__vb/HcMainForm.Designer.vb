<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class HcMainForm
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기에서는 수정하지 마세요.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.m_lbl21 = New System.Windows.Forms.Label()
        Me.m_lbl22 = New System.Windows.Forms.Label()
        Me.m_lbl23 = New System.Windows.Forms.Label()
        Me.m_txb21 = New System.Windows.Forms.TextBox()
        Me.m_txb22 = New System.Windows.Forms.TextBox()
        Me.m_txb23 = New System.Windows.Forms.TextBox()
        Me.m_lbl31 = New System.Windows.Forms.Label()
        Me.m_lbl32 = New System.Windows.Forms.Label()
        Me.m_txb31 = New System.Windows.Forms.TextBox()
        Me.m_txb32 = New System.Windows.Forms.TextBox()
        Me.m_btn31 = New System.Windows.Forms.Button()
        Me.m_btn32 = New System.Windows.Forms.Button()
        Me.m_lbl41 = New System.Windows.Forms.Label()
        Me.m_lbl42 = New System.Windows.Forms.Label()
        Me.m_txb41 = New System.Windows.Forms.TextBox()
        Me.m_lbl51 = New System.Windows.Forms.Label()
        Me.m_lbl52 = New System.Windows.Forms.Label()
        Me.m_lbl53 = New System.Windows.Forms.Label()
        Me.m_lbl54 = New System.Windows.Forms.Label()
        Me.m_ckb61 = New System.Windows.Forms.CheckBox()
        Me.m_ckb62 = New System.Windows.Forms.CheckBox()
        Me.m_ckb63 = New System.Windows.Forms.CheckBox()
        Me.m_ckb64 = New System.Windows.Forms.CheckBox()
        Me.m_btn70 = New System.Windows.Forms.Button()
        Me.m_btn71 = New System.Windows.Forms.Button()
        Me.m_btn72 = New System.Windows.Forms.Button()
        Me.m_btn91 = New System.Windows.Forms.Button()
        Me.m_txb5Height = New Win32Reka__vb.CustomControls.HcNumBox()
        Me.m_txb5Width = New Win32Reka__vb.CustomControls.HcNumBox()
        Me.m_txb5Top = New Win32Reka__vb.CustomControls.HcNumBox()
        Me.m_txb5Left = New Win32Reka__vb.CustomControls.HcNumBox()
        Me.m_txb42 = New Win32Reka__vb.CustomControls.HcNumBox()
        Me.m_targetBox = New Win32Reka__vb.CustomControls.HcTargetBox()
        Me.SuspendLayout()
        '
        'm_lbl21
        '
        Me.m_lbl21.AutoSize = True
        Me.m_lbl21.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.m_lbl21.Location = New System.Drawing.Point(98, 15)
        Me.m_lbl21.Name = "m_lbl21"
        Me.m_lbl21.Size = New System.Drawing.Size(52, 15)
        Me.m_lbl21.TabIndex = 5
        Me.m_lbl21.Text = "Handle: "
        '
        'm_lbl22
        '
        Me.m_lbl22.AutoSize = True
        Me.m_lbl22.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.m_lbl22.Location = New System.Drawing.Point(98, 44)
        Me.m_lbl22.Name = "m_lbl22"
        Me.m_lbl22.Size = New System.Drawing.Size(73, 15)
        Me.m_lbl22.TabIndex = 9
        Me.m_lbl22.Text = "ClassName: "
        '
        'm_lbl23
        '
        Me.m_lbl23.AutoSize = True
        Me.m_lbl23.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.m_lbl23.Location = New System.Drawing.Point(98, 73)
        Me.m_lbl23.Name = "m_lbl23"
        Me.m_lbl23.Size = New System.Drawing.Size(86, 15)
        Me.m_lbl23.TabIndex = 10
        Me.m_lbl23.Text = "ProcessName: "
        '
        'm_txb21
        '
        Me.m_txb21.Location = New System.Drawing.Point(190, 12)
        Me.m_txb21.Name = "m_txb21"
        Me.m_txb21.ReadOnly = True
        Me.m_txb21.Size = New System.Drawing.Size(190, 23)
        Me.m_txb21.TabIndex = 0
        '
        'm_txb22
        '
        Me.m_txb22.Location = New System.Drawing.Point(190, 41)
        Me.m_txb22.Name = "m_txb22"
        Me.m_txb22.ReadOnly = True
        Me.m_txb22.Size = New System.Drawing.Size(190, 23)
        Me.m_txb22.TabIndex = 1
        '
        'm_txb23
        '
        Me.m_txb23.Location = New System.Drawing.Point(190, 70)
        Me.m_txb23.Name = "m_txb23"
        Me.m_txb23.ReadOnly = True
        Me.m_txb23.Size = New System.Drawing.Size(190, 23)
        Me.m_txb23.TabIndex = 2
        '
        'm_lbl31
        '
        Me.m_lbl31.AutoSize = True
        Me.m_lbl31.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.m_lbl31.Location = New System.Drawing.Point(12, 109)
        Me.m_lbl31.Name = "m_lbl31"
        Me.m_lbl31.Size = New System.Drawing.Size(40, 15)
        Me.m_lbl31.TabIndex = 25
        Me.m_lbl31.Text = "Style: "
        '
        'm_lbl32
        '
        Me.m_lbl32.AutoSize = True
        Me.m_lbl32.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.m_lbl32.Location = New System.Drawing.Point(12, 138)
        Me.m_lbl32.Name = "m_lbl32"
        Me.m_lbl32.Size = New System.Drawing.Size(52, 15)
        Me.m_lbl32.TabIndex = 26
        Me.m_lbl32.Text = "StyleEx: "
        '
        'm_txb31
        '
        Me.m_txb31.Location = New System.Drawing.Point(74, 106)
        Me.m_txb31.Name = "m_txb31"
        Me.m_txb31.ReadOnly = True
        Me.m_txb31.Size = New System.Drawing.Size(200, 23)
        Me.m_txb31.TabIndex = 3
        '
        'm_txb32
        '
        Me.m_txb32.Location = New System.Drawing.Point(74, 135)
        Me.m_txb32.Name = "m_txb32"
        Me.m_txb32.ReadOnly = True
        Me.m_txb32.Size = New System.Drawing.Size(200, 23)
        Me.m_txb32.TabIndex = 5
        '
        'm_btn31
        '
        Me.m_btn31.Cursor = System.Windows.Forms.Cursors.Hand
        Me.m_btn31.Font = New System.Drawing.Font("맑은 고딕", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.m_btn31.Location = New System.Drawing.Point(280, 106)
        Me.m_btn31.Name = "m_btn31"
        Me.m_btn31.Size = New System.Drawing.Size(50, 24)
        Me.m_btn31.TabIndex = 4
        Me.m_btn31.Text = "EDIT"
        Me.m_btn31.UseVisualStyleBackColor = True
        '
        'm_btn32
        '
        Me.m_btn32.Cursor = System.Windows.Forms.Cursors.Hand
        Me.m_btn32.Font = New System.Drawing.Font("맑은 고딕", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.m_btn32.Location = New System.Drawing.Point(280, 135)
        Me.m_btn32.Name = "m_btn32"
        Me.m_btn32.Size = New System.Drawing.Size(50, 24)
        Me.m_btn32.TabIndex = 6
        Me.m_btn32.Text = "EDIT"
        Me.m_btn32.UseVisualStyleBackColor = True
        '
        'm_lbl41
        '
        Me.m_lbl41.AutoSize = True
        Me.m_lbl41.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.m_lbl41.Location = New System.Drawing.Point(12, 176)
        Me.m_lbl41.Name = "m_lbl41"
        Me.m_lbl41.Size = New System.Drawing.Size(56, 15)
        Me.m_lbl41.TabIndex = 4
        Me.m_lbl41.Text = "Caption: "
        '
        'm_lbl42
        '
        Me.m_lbl42.AutoSize = True
        Me.m_lbl42.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.m_lbl42.Location = New System.Drawing.Point(12, 205)
        Me.m_lbl42.Name = "m_lbl42"
        Me.m_lbl42.Size = New System.Drawing.Size(55, 15)
        Me.m_lbl42.TabIndex = 12
        Me.m_lbl42.Text = "Opacity: "
        '
        'm_txb41
        '
        Me.m_txb41.Location = New System.Drawing.Point(74, 173)
        Me.m_txb41.Name = "m_txb41"
        Me.m_txb41.Size = New System.Drawing.Size(300, 23)
        Me.m_txb41.TabIndex = 7
        '
        'm_lbl51
        '
        Me.m_lbl51.AutoSize = True
        Me.m_lbl51.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.m_lbl51.Location = New System.Drawing.Point(12, 236)
        Me.m_lbl51.Name = "m_lbl51"
        Me.m_lbl51.Size = New System.Drawing.Size(34, 15)
        Me.m_lbl51.TabIndex = 14
        Me.m_lbl51.Text = "Left: "
        '
        'm_lbl52
        '
        Me.m_lbl52.AutoSize = True
        Me.m_lbl52.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.m_lbl52.Location = New System.Drawing.Point(128, 236)
        Me.m_lbl52.Name = "m_lbl52"
        Me.m_lbl52.Size = New System.Drawing.Size(34, 15)
        Me.m_lbl52.TabIndex = 17
        Me.m_lbl52.Text = "Top: "
        '
        'm_lbl53
        '
        Me.m_lbl53.AutoSize = True
        Me.m_lbl53.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.m_lbl53.Location = New System.Drawing.Point(12, 265)
        Me.m_lbl53.Name = "m_lbl53"
        Me.m_lbl53.Size = New System.Drawing.Size(46, 15)
        Me.m_lbl53.TabIndex = 20
        Me.m_lbl53.Text = "Width: "
        '
        'm_lbl54
        '
        Me.m_lbl54.AutoSize = True
        Me.m_lbl54.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.m_lbl54.Location = New System.Drawing.Point(128, 265)
        Me.m_lbl54.Name = "m_lbl54"
        Me.m_lbl54.Size = New System.Drawing.Size(50, 15)
        Me.m_lbl54.TabIndex = 21
        Me.m_lbl54.Text = "Height: "
        '
        'm_ckb61
        '
        Me.m_ckb61.AutoSize = True
        Me.m_ckb61.Cursor = System.Windows.Forms.Cursors.Hand
        Me.m_ckb61.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.m_ckb61.Location = New System.Drawing.Point(15, 301)
        Me.m_ckb61.Name = "m_ckb61"
        Me.m_ckb61.Size = New System.Drawing.Size(96, 19)
        Me.m_ckb61.TabIndex = 13
        Me.m_ckb61.Text = "MinimizeBox"
        Me.m_ckb61.UseVisualStyleBackColor = True
        '
        'm_ckb62
        '
        Me.m_ckb62.AutoSize = True
        Me.m_ckb62.Cursor = System.Windows.Forms.Cursors.Hand
        Me.m_ckb62.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.m_ckb62.Location = New System.Drawing.Point(123, 301)
        Me.m_ckb62.Name = "m_ckb62"
        Me.m_ckb62.Size = New System.Drawing.Size(98, 19)
        Me.m_ckb62.TabIndex = 14
        Me.m_ckb62.Text = "MaximizeBox"
        Me.m_ckb62.UseVisualStyleBackColor = True
        '
        'm_ckb63
        '
        Me.m_ckb63.AutoSize = True
        Me.m_ckb63.Cursor = System.Windows.Forms.Cursors.Hand
        Me.m_ckb63.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.m_ckb63.Location = New System.Drawing.Point(233, 301)
        Me.m_ckb63.Name = "m_ckb63"
        Me.m_ckb63.Size = New System.Drawing.Size(75, 19)
        Me.m_ckb63.TabIndex = 15
        Me.m_ckb63.Text = "Resizable"
        Me.m_ckb63.UseVisualStyleBackColor = True
        '
        'm_ckb64
        '
        Me.m_ckb64.AutoSize = True
        Me.m_ckb64.Cursor = System.Windows.Forms.Cursors.Hand
        Me.m_ckb64.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.m_ckb64.Location = New System.Drawing.Point(15, 326)
        Me.m_ckb64.Name = "m_ckb64"
        Me.m_ckb64.Size = New System.Drawing.Size(73, 19)
        Me.m_ckb64.TabIndex = 16
        Me.m_ckb64.Text = "TopMost"
        Me.m_ckb64.UseVisualStyleBackColor = True
        '
        'm_btn70
        '
        Me.m_btn70.BackColor = System.Drawing.Color.WhiteSmoke
        Me.m_btn70.Cursor = System.Windows.Forms.Cursors.Hand
        Me.m_btn70.Font = New System.Drawing.Font("맑은 고딕", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.m_btn70.Location = New System.Drawing.Point(12, 364)
        Me.m_btn70.Name = "m_btn70"
        Me.m_btn70.Size = New System.Drawing.Size(70, 24)
        Me.m_btn70.TabIndex = 17
        Me.m_btn70.Text = "FUNC"
        Me.m_btn70.UseVisualStyleBackColor = False
        '
        'm_btn71
        '
        Me.m_btn71.BackColor = System.Drawing.Color.Gainsboro
        Me.m_btn71.Cursor = System.Windows.Forms.Cursors.Hand
        Me.m_btn71.Font = New System.Drawing.Font("맑은 고딕", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.m_btn71.Location = New System.Drawing.Point(222, 357)
        Me.m_btn71.Name = "m_btn71"
        Me.m_btn71.Size = New System.Drawing.Size(90, 38)
        Me.m_btn71.TabIndex = 19
        Me.m_btn71.Text = "APPLY (F6)"
        Me.m_btn71.UseVisualStyleBackColor = False
        '
        'm_btn72
        '
        Me.m_btn72.BackColor = System.Drawing.Color.Gainsboro
        Me.m_btn72.Cursor = System.Windows.Forms.Cursors.Hand
        Me.m_btn72.Font = New System.Drawing.Font("맑은 고딕", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.m_btn72.Location = New System.Drawing.Point(318, 364)
        Me.m_btn72.Name = "m_btn72"
        Me.m_btn72.Size = New System.Drawing.Size(70, 24)
        Me.m_btn72.TabIndex = 20
        Me.m_btn72.Text = "CLEAR"
        Me.m_btn72.UseVisualStyleBackColor = False
        '
        'm_btn91
        '
        Me.m_btn91.BackColor = System.Drawing.Color.Gainsboro
        Me.m_btn91.Cursor = System.Windows.Forms.Cursors.Hand
        Me.m_btn91.Font = New System.Drawing.Font("맑은 고딕", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.m_btn91.Location = New System.Drawing.Point(121, 357)
        Me.m_btn91.Name = "m_btn91"
        Me.m_btn91.Size = New System.Drawing.Size(95, 38)
        Me.m_btn91.TabIndex = 27
        Me.m_btn91.Text = "UPDATE (F5)"
        Me.m_btn91.UseVisualStyleBackColor = False
        '
        'm_txb5Height
        '
        Me.m_txb5Height.Location = New System.Drawing.Point(184, 262)
        Me.m_txb5Height.MaxLength = 7
        Me.m_txb5Height.Name = "m_txb5Height"
        Me.m_txb5Height.Size = New System.Drawing.Size(54, 23)
        Me.m_txb5Height.TabIndex = 12
        '
        'm_txb5Width
        '
        Me.m_txb5Width.Location = New System.Drawing.Point(64, 262)
        Me.m_txb5Width.MaxLength = 7
        Me.m_txb5Width.Name = "m_txb5Width"
        Me.m_txb5Width.Size = New System.Drawing.Size(54, 23)
        Me.m_txb5Width.TabIndex = 11
        '
        'm_txb5Top
        '
        Me.m_txb5Top.Location = New System.Drawing.Point(184, 233)
        Me.m_txb5Top.MaxLength = 7
        Me.m_txb5Top.Name = "m_txb5Top"
        Me.m_txb5Top.Size = New System.Drawing.Size(54, 23)
        Me.m_txb5Top.TabIndex = 10
        '
        'm_txb5Left
        '
        Me.m_txb5Left.Location = New System.Drawing.Point(64, 233)
        Me.m_txb5Left.MaxLength = 7
        Me.m_txb5Left.Name = "m_txb5Left"
        Me.m_txb5Left.Size = New System.Drawing.Size(54, 23)
        Me.m_txb5Left.TabIndex = 9
        '
        'm_txb42
        '
        Me.m_txb42.Location = New System.Drawing.Point(74, 202)
        Me.m_txb42.MaxLength = 7
        Me.m_txb42.Name = "m_txb42"
        Me.m_txb42.Size = New System.Drawing.Size(54, 23)
        Me.m_txb42.TabIndex = 8
        '
        'm_targetBox
        '
        Me.m_targetBox.BackColor = System.Drawing.Color.DimGray
        Me.m_targetBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.m_targetBox.Location = New System.Drawing.Point(12, 12)
        Me.m_targetBox.Margin = New System.Windows.Forms.Padding(0)
        Me.m_targetBox.Name = "m_targetBox"
        Me.m_targetBox.Size = New System.Drawing.Size(80, 80)
        Me.m_targetBox.TabIndex = 3
        Me.m_targetBox.TabStop = False
        '
        'HcMainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(400, 400)
        Me.Controls.Add(Me.m_btn91)
        Me.Controls.Add(Me.m_btn32)
        Me.Controls.Add(Me.m_btn31)
        Me.Controls.Add(Me.m_ckb64)
        Me.Controls.Add(Me.m_ckb63)
        Me.Controls.Add(Me.m_ckb62)
        Me.Controls.Add(Me.m_ckb61)
        Me.Controls.Add(Me.m_lbl32)
        Me.Controls.Add(Me.m_lbl31)
        Me.Controls.Add(Me.m_txb32)
        Me.Controls.Add(Me.m_txb31)
        Me.Controls.Add(Me.m_txb5Height)
        Me.Controls.Add(Me.m_lbl54)
        Me.Controls.Add(Me.m_lbl53)
        Me.Controls.Add(Me.m_txb5Width)
        Me.Controls.Add(Me.m_txb5Top)
        Me.Controls.Add(Me.m_lbl52)
        Me.Controls.Add(Me.m_txb5Left)
        Me.Controls.Add(Me.m_lbl51)
        Me.Controls.Add(Me.m_txb42)
        Me.Controls.Add(Me.m_lbl42)
        Me.Controls.Add(Me.m_txb41)
        Me.Controls.Add(Me.m_lbl23)
        Me.Controls.Add(Me.m_lbl22)
        Me.Controls.Add(Me.m_txb23)
        Me.Controls.Add(Me.m_txb22)
        Me.Controls.Add(Me.m_txb21)
        Me.Controls.Add(Me.m_lbl21)
        Me.Controls.Add(Me.m_lbl41)
        Me.Controls.Add(Me.m_targetBox)
        Me.Controls.Add(Me.m_btn70)
        Me.Controls.Add(Me.m_btn71)
        Me.Controls.Add(Me.m_btn72)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(100, 40)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "HcMainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Form1"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents m_targetBox As CustomControls.HcTargetBox
    Friend WithEvents m_lbl21 As System.Windows.Forms.Label
    Friend WithEvents m_lbl22 As System.Windows.Forms.Label
    Friend WithEvents m_lbl23 As System.Windows.Forms.Label
    Friend WithEvents m_txb21 As System.Windows.Forms.TextBox
    Friend WithEvents m_txb22 As System.Windows.Forms.TextBox
    Friend WithEvents m_txb23 As System.Windows.Forms.TextBox
    Friend WithEvents m_lbl31 As System.Windows.Forms.Label
    Friend WithEvents m_lbl32 As System.Windows.Forms.Label
    Friend WithEvents m_txb31 As System.Windows.Forms.TextBox
    Friend WithEvents m_txb32 As System.Windows.Forms.TextBox
    Friend WithEvents m_btn31 As System.Windows.Forms.Button
    Friend WithEvents m_btn32 As System.Windows.Forms.Button
    Friend WithEvents m_lbl41 As System.Windows.Forms.Label
    Friend WithEvents m_lbl42 As System.Windows.Forms.Label
    Friend WithEvents m_txb41 As System.Windows.Forms.TextBox
    Friend WithEvents m_txb42 As CustomControls.HcNumBox
    Friend WithEvents m_lbl51 As System.Windows.Forms.Label
    Friend WithEvents m_lbl52 As System.Windows.Forms.Label
    Friend WithEvents m_lbl53 As System.Windows.Forms.Label
    Friend WithEvents m_lbl54 As System.Windows.Forms.Label
    Friend WithEvents m_txb5Left As CustomControls.HcNumBox
    Friend WithEvents m_txb5Top As CustomControls.HcNumBox
    Friend WithEvents m_txb5Width As CustomControls.HcNumBox
    Friend WithEvents m_txb5Height As CustomControls.HcNumBox
    Friend WithEvents m_ckb61 As System.Windows.Forms.CheckBox
    Friend WithEvents m_ckb62 As System.Windows.Forms.CheckBox
    Friend WithEvents m_ckb63 As System.Windows.Forms.CheckBox
    Friend WithEvents m_ckb64 As System.Windows.Forms.CheckBox
    Friend WithEvents m_btn70 As System.Windows.Forms.Button
    Friend WithEvents m_btn71 As System.Windows.Forms.Button
    Friend WithEvents m_btn72 As System.Windows.Forms.Button
    Friend WithEvents m_btn91 As System.Windows.Forms.Button
End Class
