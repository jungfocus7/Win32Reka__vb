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
                Normal32();
            };
        }

        private EventHandler m_etmeh;
        private void Normal32()
        {
            if (m_etmeh == null)
            {
                m_etmeh = delegate
                {
                    Action<int, IntPtr, Rectangle> hmf = delegate (int cid, IntPtr hp, Rectangle rct)
                    {
                        BeginInvoke((MethodInvoker)delegate
                        {
                            bool br = Win32Helper.EnumThreadWindows((uint)cid,
                                delegate (IntPtr hWnd, IntPtr lParam)
                                {
                                    //Debug.WriteLine($": {cid}, {hp}, {hWnd}, {lParam}");

                                    IntPtr ht = Win32Helper.GetParent(hWnd);
                                    if (ht == hp)
                                    {
                                        if (Win32Helper.GetWindowRect(hWnd, out RECT raw))
                                        {
                                            double fx = rct.Left + (rct.Width / 2.0) - (raw.Width / 2.0);
                                            double fy = rct.Top + (rct.Height / 2.0) - (raw.Height / 2.0);

                                            int tx = (int)Math.Round(fx, MidpointRounding.AwayFromZero);
                                            int ty = (int)Math.Round(fy, MidpointRounding.AwayFromZero);

                                            Win32Helper.SetWindowPos(
                                                hWnd, IntPtr.Zero,
                                                tx, ty, 0, 0,
                                                Win32Helper.SWP_NOSIZE);
                                        }

                                        return false;
                                    }
                                    else
                                        return true;
                                }, hp);

                            Debug.WriteLine($": {br}");
                        });
                    };

                    hmf.BeginInvoke(
                        Win32Helper.GetCurrentThreadId(), Handle, Bounds,
                        null, null);
                };

                Application.EnterThreadModal += m_etmeh;
            }


            MessageBox.Show(this, @"개발자 그룹이 상위계층으로 연결되어 있지 않습니다.
해당 사항을 개발그룹 관리자에게 문의 바랍니다.", "Notify (알림)");
        }

    }
}
