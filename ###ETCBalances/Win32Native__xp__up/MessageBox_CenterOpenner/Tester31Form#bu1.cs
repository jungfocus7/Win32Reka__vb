using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Winform31.Helpers;


namespace Winform31
{
    public sealed partial class Tester31Form : Form
    {
        public Tester31Form()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs ea)
        {
            base.OnLoad(ea);

            //IntPtr hWnd = Handle;
            ////int nIndex = Win32Helper.GWL_EXSTYLE;
            ////int nIndex = Win32Helper.GWL_STYLE;
            //int nIndex = Win32Helper.GWL_ID;
            //IntPtr pr = Win32Helper.GetWindowLongPtr32(hWnd, nIndex);
            //var x1 = pr.ToInt32();
            //var x2 = CreateParams.Style;
            //var x3 = CreateParams.ExStyle;
            //var x4 = CreateParams.ClassStyle;
            ////Marshal.ReadInt64
            ////Int64 xx;

            Text = "Normal31";

            m_btn31.Click += delegate
            {
                Normal31();
            };



            //ControlStyles[] css = (ControlStyles[])Enum.GetValues(typeof(ControlStyles));
            //foreach (ControlStyles cs in css)
            //{
            //    SetStyle(cs, false);
            //    string txt = $"{cs.ToString()}: {GetStyle(cs)}";
            //    Debug.WriteLine(txt);
            //}
            //SetStyle(ControlStyles.UserPaint, true);            
            //UpdateStyles();


            Application.ApplicationExit += delegate { };

            //Application.
            //Action act = delegate
            //{
            //    //while (true)
            //    //{
            //    //    //Task.Delay(1000);
            //    //    //IntPtr pr = Win32Helper.GetActiveWindow();
            //    //}
            //    //Thread.Sleep(3000);
            //    //IntPtr pr = Win32Helper.GetActiveWindow();
            //    //Debug.WriteLine($">>> {pr}");

            //    Thread.Sleep(3000);
            //    BeginInvoke((MethodInvoker)delegate
            //    {
            //        IntPtr pr = Win32Helper.FindWindowEx(Handle, IntPtr.Zero, "#32770", null);
            //        pr = Win32Helper.FindWindow("#32770", "zzz");
            //    });                
            //};
            //act.BeginInvoke(null, null);


            Application.EnterThreadModal += delegate
            {
                Action<int, IntPtr> fntrd = delegate (int cid, IntPtr hParentWnd)
                {
                    //Thread.Sleep(3000);

                    //IntPtr pr = Win32Helper.FindWindow("#32770", "zzz");
                    //Debug.WriteLine($">>> {pr}");

                    //pr = Win32Helper.GetParent(pr);
                    //Debug.WriteLine($">>> {pr}");

                    //Debug.WriteLine($">>> {hParentWnd}");

                    //IntPtr pr = Win32Helper.FindWindowEx(hParentWnd, 1, "#32770", "zzz");
                    //IntPtr hChildWnd = Win32Helper.GetWindow(hParentWnd,0);
                    //Debug.WriteLine($">>> {hChildWnd}");
                    //if (hChildWnd != IntPtr.Zero)
                    //{

                    //}

                    //int tid = AppDomain.GetCurrentThreadId();
                    //var x2 = Win32Helper.GetCurrentThreadId();
                    ////int tid = Thread.CurrentThread.ManagedThreadId;
                    //var x1 = Win32Helper.EnumThreadWindows((uint)cid, Callback, hParentWnd);

                    bool br = Win32Helper.EnumThreadWindows((uint)cid,
                        delegate (IntPtr hWnd, IntPtr lParam)
                        {
                            //Debug.WriteLine($"{cid}, {hParentWnd}, {hWnd}, {lParam}");
                            Debug.WriteLine($"{hWnd}, {lParam}");

                            IntPtr hTemp = Win32Helper.GetParent(hWnd);
                            if (hTemp == hParentWnd)
                            {
                                //IntPtr pr = Win32Helper.GetWindowLong(hWnd, Win32Helper.GWL_STYLE);
                                //uint nStyle = (uint)pr;
                                //nStyle |= Win32Helper.WS_MAXIMIZEBOX;
                                //Win32Helper.SetWindowLong(hWnd, Win32Helper.GWL_STYLE, new IntPtr((int)unchecked(nStyle)));
                                prGetXX(hWnd);

                                return false;
                            }
                            else return true;
                        }, hParentWnd);
                };

                fntrd.BeginInvoke(Win32Helper.GetCurrentThreadId(), Handle, null, null);
                
            };

            MessageBox.Show(this, "zzz", "zzz");

        }

        private void EnumThreadWndProc(IntPtr hWnd, IntPtr lParam)
        {
            var x1 = Bounds;

            if (Win32Helper.GetWindowRect(hWnd, out RECT ra1))
            {
                int tw = 500;
                int th = 500;

                RECT ra2 = new RECT(tw, th);

                Win32Helper.SetWindowPos(
                    hWnd, IntPtr.Zero,
                    40, 40, 0, 0, Win32Helper.SWP_NOSIZE);

                //Win32Helper.AdjustWindowRectEx(
                //    ref ra2, CreateParams.Style, false, CreateParams.ExStyle);

                //RECT ra3 = new RECT(ra1.Left, ra1.Top,
                //    ra1.Left + ra2.Width, ra1.Top + ra2.Height);

                //Win32Helper.SetWindowPos(
                //    Handle, IntPtr.Zero,
                //    ra3.Left, ra3.Top, ra3.Width, ra3.Height, 0);
            }

            //var x1 = Bounds;

            //if (Win32Helper.GetWindowRect(hWnd, out RECT ra1))
            //{
            //    int tw = 500;
            //    int th = 500;

            //    RECT ra2 = new RECT(tw, th);

            //    Win32Helper.SetWindowPos(
            //        hWnd, IntPtr.Zero,
            //        40, 40, 0, 0, Win32Helper.SWP_NOSIZE);

            //    //Win32Helper.AdjustWindowRectEx(
            //    //    ref ra2, CreateParams.Style, false, CreateParams.ExStyle);

            //    //RECT ra3 = new RECT(ra1.Left, ra1.Top,
            //    //    ra1.Left + ra2.Width, ra1.Top + ra2.Height);

            //    //Win32Helper.SetWindowPos(
            //    //    Handle, IntPtr.Zero,
            //    //    ra3.Left, ra3.Top, ra3.Width, ra3.Height, 0);
            //}
        }



        //private bool Callback(IntPtr hWnd, IntPtr lparam)
        //{
        //    Debug.WriteLine("씨발꺼");
        //    Application.Exit();
        //    return true;
        //}


        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
        }

        

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0002)
            {

            }

            base.WndProc(ref m);
        }


        private void Normal31()
        {
            try
            {
                Win32Helper.SetWindowLong(Handle, Win32Helper.GWL_STYLE, new IntPtr(0x94C800CC));
            }
            catch { }
            return;



            int nIndex = Win32Helper.GWL_STYLE;
            IntPtr pr = Win32Helper.GetWindowLong(Handle, nIndex);

            int nStyle = pr.ToInt32();

            if ((nStyle & Win32Helper.WS_THICKFRAME) == Win32Helper.WS_THICKFRAME)
            {
                IntPtr pa = new IntPtr(nStyle & ~Win32Helper.WS_THICKFRAME);
                IntPtr pb = Win32Helper.SetWindowLong(Handle, nIndex, pa);
            }
            else
            {
                IntPtr pa = new IntPtr(nStyle | Win32Helper.WS_THICKFRAME);
                IntPtr pb = Win32Helper.SetWindowLong(Handle, nIndex, pa);
            }

            GetStyle(ControlStyles.ResizeRedraw);

            Debug.WriteLine("~~~~");








            //int nIndex = Win32Helper.GWL_EXSTYLE;
            //IntPtr pr = Win32Helper.GetWindowLong(Handle, nIndex);

            //IntPtr pa = new IntPtr(pr.ToInt32() | Win32Helper.WS_EX_TOOLWINDOW);
            //IntPtr pb = Win32Helper.SetWindowLong(Handle, nIndex, pa);


            //Debug.WriteLine("~~~~");






            //int nStyle = pr.ToInt32();
            //IntPtr pr2 = Win32Helper.SetWindowLong_wp(Handle, nIndex,
            //    delegate (IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam)
            //    {
            //        return IntPtr.Zero;
            //    });

            //WindowStyle.dd





            //IntPtr hWnd = Handle;
            //int nIndex = Win32Helper.GWL_EXSTYLE;
            //IntPtr pr = Win32Helper.GetWindowLong(hWnd, nIndex);
            //int nStyle = pr.ToInt32();

            //Win32Helper.SetWindowLongPtr32(hWnd, nIndex, IntPtr.Zero);
            //pr = Win32Helper.GetWindowLong(hWnd, nIndex);

            //if ((nStyle & Win32Helper.WS_CAPTION) == Win32Helper.WS_CAPTION)
            //{

            //}



            //IntPtr hWnd = Handle;
            ////int nIndex = Win32Helper.GWL_EXSTYLE;
            //int nIndex = Win32Helper.GWL_STYLE;
            ////int nIndex = Win32Helper.GWL_ID;
            //IntPtr pr = Win32Helper.GetWindowLongPtr32(hWnd, nIndex);
            //var x1 = pr.ToInt32();
            //var x2 = CreateParams.Style;
            //var x3 = CreateParams.ExStyle;
            //var x4 = CreateParams.ClassStyle;
            //var x5 = CreateParams.Style & CreateParams.ExStyle;
            //var x6 = CreateParams.Style | CreateParams.ExStyle;
            //var x7 = CreateParams.Style * CreateParams.ExStyle;
            //var x8 = CreateParams.Style + CreateParams.ExStyle;
        }

    }
}
