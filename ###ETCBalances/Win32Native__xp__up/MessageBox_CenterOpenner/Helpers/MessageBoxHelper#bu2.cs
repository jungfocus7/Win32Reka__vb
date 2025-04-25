using System;
using System.Drawing;
using System.Windows.Forms;


namespace Winform31.Helpers
{
    public static class MessageBoxHelper
    {
        private static bool EnumThreadProc(IntPtr hWnd, IntPtr lParam)
        {
            //Debug.WriteLine($": {cid}, {hp}, {hWnd}, {lParam}");

            IntPtr ht = Win32Helper.GetParent(hWnd);
            if (ht == _hp)
            {
                if (Win32Helper.GetWindowRect(hWnd, out RECT raw))
                {
                    double fx = _rct.Left + (_rct.Width / 2.0) - (raw.Width / 2.0);
                    double fy = _rct.Top + (_rct.Height / 2.0) - (raw.Height / 2.0);

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
            {
                return true;
            }
        }

        private static void EnterThreadModalHandler(object sd, EventArgs ea)
        {
            if (_target == null) return;

            //_target.BeginInvoke((MethodInvoker)delegate
            //{
            //    Win32Helper.EnumThreadWindows((uint)_cid, EnumThreadProc, _hp);
            //});
        }

        static MessageBoxHelper()
        {
            Application.EnterThreadModal += EnterThreadModalHandler;
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

            _target.BeginInvoke((MethodInvoker)delegate
            {
                Win32Helper.EnumThreadWindows((uint)_cid, EnumThreadProc, _hp);
            });
            DialogResult rdr = MessageBox.Show(_target, content, title);
            _target = null;
            _cid = default;
            _hp = default;
            _rct = default;

            return rdr;
        }

    }
}
