Imports System
Imports System.Diagnostics
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports Win32Reka__vb.Helper



Public NotInheritable Class HcMainForm
#Region "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ 0"
    Public Shared ReadOnly Title As String = $"{GetType(HcMainForm).Namespace}  v1.50"


    Private Shared m_frmMain As HcMainForm
    ''' <summary>
    ''' 메인폼 참조하기
    ''' </summary>
    ''' <returns></returns>
    Public Shared ReadOnly Property MainForm As HcMainForm
        Get
            If m_frmMain Is Nothing Then
                m_frmMain = TryCast(Application.OpenForms("HcMainForm"), HcMainForm)
            End If
            Return m_frmMain
        End Get
    End Property


    ''' <summary>
    ''' GC 콜
    ''' </summary>
    Public Shared Sub GCCall()
        GC.Collect()
        GC.WaitForPendingFinalizers()
    End Sub
#End Region



    Public Sub New()
        ' 디자이너에서 이 호출이 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하세요.

    End Sub


    Protected Overrides Sub OnLoad(ea As EventArgs)
        MyBase.OnLoad(ea)

        Text = Title

        m_targetBox.InitOnce()

        AddHandler m_btn70.Click, AddressOf fn_Btn70_Click
        AddHandler m_btn71.Click, AddressOf fn_Btn71_Click
        AddHandler m_btn72.Click, AddressOf fn_Btn72_Click

        fn_Btn72_Click(Nothing, Nothing)
    End Sub


    Private Sub fn_GetWndInfo()
        Dim wndInfo As New HsWNDINFO()
        HcWin32Helper.fn_WorkRoll(New IntPtr(&H15037E), wndInfo)
        'Dim cb As Integer = Marshal.SizeOf(wndInfo)
        'Dim pWndInfo As IntPtr = Marshal.AllocHGlobal(cb)
        'If pWndInfo <> IntPtr.Zero Then
        '    HcWin32Helper.fn_WorkRoll(Handle, wndInfo)
        '    Marshal.FreeHGlobal(pWndInfo)
        '    pWndInfo = IntPtr.Zero
        'End If
        m_txb21.Text = String.Format("0x{0}", wndInfo.hWnd.ToString("x8"))
        m_txb22.Text = wndInfo.lpszClassName
        m_txb23.Text = wndInfo.lpszProcessName
        m_txb31.Text = wndInfo.dwStyle.ToString()
        m_txb32.Text = wndInfo.dwExStyle.ToString()
        m_txb41.Text = wndInfo.lpszCaption
        m_txb42.Text = wndInfo.uOpacity.ToString()
        m_txb5Left.Text = wndInfo.nLeft.ToString()
        m_txb5Top.Text = wndInfo.nTop.ToString()
        m_txb5Width.Text = wndInfo.nWidth.ToString()
        m_txb5Height.Text = wndInfo.nHeight.ToString()
        m_ckb61.Checked = wndInfo.bMinimizeBox
        m_ckb62.Checked = wndInfo.bMaximizeBox
        m_ckb63.Checked = wndInfo.bResizable
        m_ckb64.Checked = wndInfo.bTopMost
    End Sub


    ''' <summary>
    ''' FUNC 버튼
    ''' </summary>
    ''' <param name="sd"></param>
    ''' <param name="ea"></param>
    Private Sub fn_Btn70_Click(sd As Object, ea As EventArgs)
        HcMsgBoxHelper.Show_a(Handle, "기능준비")
    End Sub


    ''' <summary>
    ''' APPLY 버튼
    ''' </summary>
    ''' <param name="sd"></param>
    ''' <param name="ea"></param>
    Private Sub fn_Btn71_Click(sd As Object, ea As EventArgs)
    End Sub


    ''' <summary>
    ''' CLEAR 버튼
    ''' </summary>
    ''' <param name="sd"></param>
    ''' <param name="ea"></param>
    Private Sub fn_Btn72_Click(sd As Object, ea As EventArgs)
        m_lbl21.Enabled = False
        m_lbl22.Enabled = False
        m_lbl23.Enabled = False
        m_txb21.Enabled = False
        m_txb22.Enabled = False
        m_txb23.Enabled = False
        m_txb21.Clear()
        m_txb22.Clear()
        m_txb23.Clear()

        m_lbl31.Enabled = False
        m_lbl32.Enabled = False
        m_txb31.Enabled = False
        m_txb32.Enabled = False
        m_txb31.Clear()
        m_txb32.Clear()
        m_btn31.Enabled = False
        m_btn32.Enabled = False

        m_lbl41.Enabled = False
        m_lbl42.Enabled = False
        m_txb41.Enabled = False
        m_txb42.Enabled = False
        m_txb41.Clear()
        m_txb42.Clear()

        m_lbl51.Enabled = False
        m_lbl52.Enabled = False
        m_lbl53.Enabled = False
        m_lbl54.Enabled = False
        m_txb5Left.Enabled = False
        m_txb5Top.Enabled = False
        m_txb5Width.Enabled = False
        m_txb5Height.Enabled = False
        m_txb5Left.Clear()
        m_txb5Top.Clear()
        m_txb5Width.Clear()
        m_txb5Height.Clear()

        m_ckb61.Enabled = False
        m_ckb62.Enabled = False
        m_ckb63.Enabled = False
        m_ckb64.Enabled = False
        m_ckb61.Checked = False
        m_ckb62.Checked = False
        m_ckb63.Checked = False
        m_ckb64.Checked = False

        m_ckb73.Enabled = False
        m_ckb73.Checked = False
        m_btn71.Enabled = False
        m_btn72.Enabled = False
    End Sub

End Class
