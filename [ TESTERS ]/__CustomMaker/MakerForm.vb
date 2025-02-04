Imports System
Imports System.Diagnostics
Imports System.Runtime.InteropServices



Public NotInheritable Class MakerForm
    Public Sub New()
        ' 디자이너에서 이 호출이 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하세요.

    End Sub


    Protected Overrides Sub OnLoad(ea As EventArgs)
        MyBase.OnLoad(ea)

        ''~~
        'm_numInputer.InitOnce(Nothing)

        ''~~
        'm_nmup31.Minimum = -5000
        'm_nmup31.Maximum = 5000
        'm_nmup31.Value = 0
        'AddHandler m_nmup31.ValueChanged, AddressOf fn_Nmup31__ValueChanged

        m_numBox.SetNum(9800)
    End Sub


    Private Sub fn_Nmup31__ValueChanged(sd As Object, ea As EventArgs)
        Debug.WriteLine($"::: {m_nmup31.Value}")
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles m_btn31.Click
        m_numInputer.Text = "12345"
    End Sub
End Class
