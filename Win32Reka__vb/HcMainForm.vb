Imports System
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports Win32Reka__vb.Helper
Imports Win32Reka__vb.Helpers
Imports Win32Reka__vb.Models



Public NotInheritable Class HcMainForm
#Region "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ 0"
    Public Shared ReadOnly Title As String = $"WinReka  v1.52"


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

        m_jcs = {m_targetBox, m_btn70}
        m_timer = New Timer()
        AddHandler m_timer.Tick, AddressOf fn_Timer_Tick
        m_timer.Interval = 100
        'm_timer.Start()

        m_targetBox.InitOnce(AddressOf fn_LoadWndInfo)

        fn_SetEnabledControls(False)

        AddHandler m_btn70.Click, AddressOf fn_Btn70_Click
        AddHandler m_btn91.Click, AddressOf fn_Btn91_Click
        AddHandler m_btn71.Click, AddressOf fn_Btn71_Click
        AddHandler m_btn72.Click, AddressOf fn_Btn72_Click

        m_txb42.SetMinMax(0, 255)


        prAfterInit()
    End Sub


    Protected Overrides Sub WndProc(ByRef m As Message)
        If HcHotkeyHelper.CheckWndProc(Me, m) Then
            Return
        End If

        MyBase.WndProc(m)
    End Sub

    Private Sub prAfterInit()
        HcHotkeyHelper.AddHotkey(New HotkeyInfo() With {
            .hwnd = Handle,
            .fsModifiers = HcHotkeyHelper.Kmf_None,
            .vk = Keys.F5,
            .cbf =
                Sub()
                    'HcMsgBoxHelper.Show_a(Handle, "Keys.F5")
                    If m_bLoaded Then
                        fn_Btn91_Click(Nothing, Nothing)
                    End If
                End Sub
        })
        HcHotkeyHelper.AddHotkey(New HotkeyInfo() With {
            .hwnd = Handle,
            .fsModifiers = HcHotkeyHelper.Kmf_None,
            .vk = Keys.F6,
            .cbf =
                Sub()
                    'HcMsgBoxHelper.Show_a(Handle, "Keys.F6")
                    If m_bLoaded Then
                        fn_Btn71_Click(Nothing, Nothing)
                    End If
                End Sub
        })


        AddHandler FormClosing,
            Sub(sd As Object, ea As FormClosingEventArgs)
                HcHotkeyHelper.ClearAllHotkey()
            End Sub

        AddHandler Deactivate,
            Sub(sd As Object, ea As EventArgs)
                'Debug.WriteLine("~~~Deactivate")
                HcHotkeyHelper.SetEnabled(False)
                'Enabled = False
            End Sub

        AddHandler Activated,
            Sub(sd As Object, ea As EventArgs)
                'Debug.WriteLine("~~~Activated")
                HcHotkeyHelper.SetEnabled(True)
                'Enabled = True
            End Sub
    End Sub


    Private m_jcs() As Control
    Private m_timer As Timer

    Private m_bLoaded As Boolean = False
    Private m_wndInfo As HsWNDINFO



    ''' <summary>
    ''' ???
    ''' </summary>
    Private Sub fn_ClearControls()
        For Each ctr As Control In Controls
            If Array.IndexOf(m_jcs, ctr) > -1 Then
                Continue For
            Else
                Dim txb As TextBox = TryCast(ctr, TextBox)
                If Not txb Is Nothing Then
                    txb.Clear()
                End If

                Dim ckb As CheckBox = TryCast(ctr, CheckBox)
                If Not ckb Is Nothing Then
                    ckb.Checked = False
                End If
            End If
        Next
    End Sub


    ''' <summary>
    ''' ???
    ''' </summary>
    ''' <param name="bEnabled"></param>
    Private Sub fn_SetEnabledControls(bEnabled As Boolean)
        For Each ctr As Control In Controls
            If Array.IndexOf(m_jcs, ctr) > -1 Then
                Continue For
            Else
                ctr.Enabled = bEnabled
            End If
        Next
    End Sub


    ''' <summary>
    ''' ???
    ''' </summary>
    ''' <param name="bdc"></param>
    Private Sub fn_ClearWndInfo(bdc As Boolean)
        If m_bLoaded Then
            fn_ClearControls()
            If bdc Then
                fn_SetEnabledControls(False)
            End If
            m_bLoaded = False
        End If
    End Sub


    ''' <summary>
    ''' ???
    ''' </summary>
    Private Sub fn_DisplayControls()
        m_txb21.Text = String.Format("0x{0}", m_wndInfo.hWnd.ToString("x8"))
        m_txb22.Text = m_wndInfo.lpszClassName
        m_txb23.Text = m_wndInfo.lpszProcessName
        m_txb31.Text = m_wndInfo.dwStyle.ToString()
        m_txb32.Text = m_wndInfo.dwExStyle.ToString()
        m_txb41.Text = m_wndInfo.lpszCaption
        m_txb42.Text = m_wndInfo.uOpacity.ToString()
        m_txb5Left.Text = m_wndInfo.nLeft.ToString()
        m_txb5Top.Text = m_wndInfo.nTop.ToString()
        m_txb5Width.Text = m_wndInfo.nWidth.ToString()
        m_txb5Height.Text = m_wndInfo.nHeight.ToString()
        m_ckb61.Checked = m_wndInfo.bMinimizeBox
        m_ckb62.Checked = m_wndInfo.bMaximizeBox
        m_ckb63.Checked = m_wndInfo.bResizable
        m_ckb64.Checked = m_wndInfo.bTopMost
    End Sub


    ''' <summary>
    ''' ???
    ''' </summary>
    Private Sub fn_LoadWndInfo()
        fn_ClearWndInfo(False)

        Dim mpt As Point = Cursor.Position
        HcWin32Helper.fn_WorkRoll(mpt.X, mpt.Y, m_wndInfo)
        fn_DisplayControls()

        fn_SetEnabledControls(True)
        m_bLoaded = True
    End Sub


    ''' <summary>
    ''' ???
    ''' </summary>
    Private Sub fn_UpdateWndInfo()
        If Not m_bLoaded Then
            Return
        End If

        Dim hWndTarget As IntPtr = m_wndInfo.hWnd
        If hWndTarget <> IntPtr.Zero Then
            HcWin32Helper.fn_UpdateRoll(hWndTarget, m_wndInfo)
            fn_DisplayControls()
        End If
    End Sub


    ''' <summary>
    ''' ???
    ''' </summary>
    ''' <param name="sd"></param>
    ''' <param name="ea"></param>
    Private Sub fn_Timer_Tick(sd As Object, ea As EventArgs)
        fn_UpdateWndInfo()
        'fn_Btn71_Click(Nothing, Nothing)
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
    ''' UPDATE 버튼
    ''' </summary>
    ''' <param name="sd"></param>
    ''' <param name="ea"></param>
    Private Sub fn_Btn91_Click(sd As Object, ea As EventArgs)
        fn_UpdateWndInfo()
    End Sub


    ''' <summary>
    ''' APPLY 버튼
    ''' </summary>
    ''' <param name="sd"></param>
    ''' <param name="ea"></param>
    Private Sub fn_Btn71_Click(sd As Object, ea As EventArgs)
        Dim hWndTarget As IntPtr = m_wndInfo.hWnd
        If hWndTarget <> IntPtr.Zero Then
            m_wndInfo.lpszCaption = HcValueHelper.ToText(m_txb41)
            m_wndInfo.uOpacity = HcValueHelper.ToOpacity(m_txb42)
            m_wndInfo.nLeft = HcValueHelper.ToInteger(m_txb5Left)
            m_wndInfo.nTop = HcValueHelper.ToInteger(m_txb5Top)
            m_wndInfo.nWidth = HcValueHelper.ToInteger(m_txb5Width)
            m_wndInfo.nHeight = HcValueHelper.ToInteger(m_txb5Height)
            m_wndInfo.bMinimizeBox = m_ckb61.Checked
            m_wndInfo.bMaximizeBox = m_ckb62.Checked
            m_wndInfo.bResizable = m_ckb63.Checked
            m_wndInfo.bTopMost = m_ckb64.Checked
            HcWin32Helper.fn_ApplyRoll(hWndTarget, m_wndInfo)
        End If
    End Sub


    ''' <summary>
    ''' CLEAR 버튼
    ''' </summary>
    ''' <param name="sd"></param>
    ''' <param name="ea"></param>
    Private Sub fn_Btn72_Click(sd As Object, ea As EventArgs)
        fn_ClearWndInfo(True)
    End Sub

End Class
