using System;
using System.Drawing;
using System.Windows.Forms;


namespace Winform31.Helpers
{
    public static class MessageBoxHelper
    {
        private static bool EnumThreadProc(IntPtr hWnd, IntPtr lParam)
        {
            IntPtr ht = Win32Helper.GetParent(hWnd);
            if (ht == _hp)
            {
                if (Win32Helper.GetWindowRect(hWnd, out RECT raw))
                {
                    //double fx = _rct.Left + (_rct.Width / 2.0) - (raw.Width / 2.0);
                    //double fy = _rct.Top + (_rct.Height / 2.0) - (raw.Height / 2.0);

                    //int tx = (int)Math.Round(fx, MidpointRounding.AwayFromZero);
                    //int ty = (int)Math.Round(fy, MidpointRounding.AwayFromZero);


                    int tx = _rct.Left + (_rct.Width / 2) - (raw.Width / 2);
                    int ty = _rct.Top + (_rct.Height / 2) - (raw.Height / 2);

                    Win32Helper.SetWindowPos(
                        hWnd, IntPtr.Zero,
                        tx, ty, 0, 0,
                        Win32Helper.SWP_NOSIZE);
                }
                return false;
            }
            else
            {
                return true;
            }
        }

        private static void InvokeProc()
        {
            Win32Helper.EnumThreadWindows((uint)_cid, EnumThreadProc, _hp);
        }


        private static Control _target;
        private static int _cid;
        private static IntPtr _hp;
        private static Rectangle _rct;

        public static DialogResult Show(Control owner, string title, string content)
        {
            _target = owner;
            _cid = Win32Helper.GetCurrentThreadId();
            _hp = _target.Handle;
            _rct = _target.Bounds;

            _target.BeginInvoke((MethodInvoker)InvokeProc);

            DialogResult rdr = MessageBox.Show(_target, content, title);
            _target = null;
            _cid = default;
            _hp = default;
            _rct = default;

            return rdr;
        }

    }
}
