using System;
using System.Drawing;
using System.Windows.Forms;


namespace MessageBox_CenterOpenner.Helpers
{
    public static class HcMessageBoxHelper
    {
        private static bool _EnumThreadProc(IntPtr hWnd, IntPtr lParam)
        {
            IntPtr ht = HcWin32Helper.GetParent(hWnd);
            if (ht == _hp)
            {
                if (HcWin32Helper.GetWindowRect(hWnd, out HsRect raw))
                {
                    int tx = _rct.Left + (_rct.Width / 2) - (raw.Width / 2);
                    int ty = _rct.Top + (_rct.Height / 2) - (raw.Height / 2);

                    HcWin32Helper.SetWindowPos(
                        hWnd, IntPtr.Zero,
                        tx, ty, 0, 0,
                        HcWin32Helper.SWP_NOSIZE);
                }
                return false;
            }
            else
            {
                return true;
            }
        }


        private static void _InvokeProc()
        {
            HcWin32Helper.EnumThreadWindows((uint)_cid, _EnumThreadProc, _hp);
        }



        private static Control _target;
        private static int _cid;
        private static IntPtr _hp;
        private static Rectangle _rct;

        private static void _ClearUsings()
        {
            if (_target == null) return;
            _target = null;
            _cid = default;
            _hp = default;
            _rct = default;
        }


        public static DialogResult Show(Control owner, string title, string content, MessageBoxButtons buttons)
        {
            _target = owner;
            _cid = HcWin32Helper.GetCurrentThreadId();
            _hp = _target.Handle;
            _rct = _target.Bounds;

            _target.BeginInvoke((MethodInvoker)_InvokeProc);

            DialogResult rdr = MessageBox.Show(_target, content, title, buttons);
            _ClearUsings();

            return rdr;
        }

        public static string Title = "알림(Notify)";
        public static DialogResult Show(Control owner, string content, MessageBoxButtons buttons)
        {
            return Show(owner, Title, content, buttons);
        }

    }
}
