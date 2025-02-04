<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MakerForm
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.m_btn31 = New System.Windows.Forms.Button()
        Me.m_nmup31 = New __CustomMaker.CustomControls.HcNumericUpDown()
        Me.m_numInputer = New __CustomMaker.CustomControls.HcNumberInputer()
        Me.m_numBox = New __CustomMaker.CustomControls.HcNumBox()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_nmup31, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(64, 199)
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(86, 23)
        Me.NumericUpDown1.TabIndex = 3
        '
        'm_btn31
        '
        Me.m_btn31.Cursor = System.Windows.Forms.Cursors.Hand
        Me.m_btn31.Location = New System.Drawing.Point(211, 34)
        Me.m_btn31.Name = "m_btn31"
        Me.m_btn31.Size = New System.Drawing.Size(214, 119)
        Me.m_btn31.TabIndex = 1
        Me.m_btn31.Text = "Button1"
        Me.m_btn31.UseVisualStyleBackColor = True
        '
        'm_nmup31
        '
        Me.m_nmup31.Location = New System.Drawing.Point(64, 240)
        Me.m_nmup31.Name = "m_nmup31"
        Me.m_nmup31.Size = New System.Drawing.Size(86, 23)
        Me.m_nmup31.TabIndex = 4
        '
        'm_numInputer
        '
        Me.m_numInputer.Location = New System.Drawing.Point(64, 298)
        Me.m_numInputer.Name = "m_numInputer"
        Me.m_numInputer.Size = New System.Drawing.Size(100, 23)
        Me.m_numInputer.TabIndex = 2
        '
        'm_intIpt1
        '
        Me.m_numBox.Location = New System.Drawing.Point(442, 49)
        Me.m_numBox.Name = "m_intIpt1"
        Me.m_numBox.Size = New System.Drawing.Size(172, 23)
        Me.m_numBox.TabIndex = 0
        '
        'MakerForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(774, 460)
        Me.Controls.Add(Me.m_numBox)
        Me.Controls.Add(Me.m_btn31)
        Me.Controls.Add(Me.m_nmup31)
        Me.Controls.Add(Me.NumericUpDown1)
        Me.Controls.Add(Me.m_numInputer)
        Me.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Location = New System.Drawing.Point(100, 40)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "MakerForm"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Form1"
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_nmup31, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents m_numInputer As CustomControls.HcNumberInputer
    Friend WithEvents m_nmup31 As CustomControls.HcNumericUpDown
    Friend WithEvents m_btn31 As System.Windows.Forms.Button
    Friend WithEvents m_numBox As CustomControls.HcNumBox
End Class
