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
using MessageBox_CenterOpenner.Helpers;


namespace MessageBox_CenterOpenner
{
    public sealed partial class HcTester31Form : Form
    {
        public HcTester31Form()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs ea)
        {
            base.OnLoad(ea);

            Text = "Normal31";

            m_btn31.Click += delegate
            {
                Normal32();
            };
        }


        private void Normal32()
        {
            HcMessageBoxHelper.Show(this,
                "Notify (알림)",
                @"개발자 그룹이 상위계층으로 연결되어 있지 않습니다.
해당 사항을 개발그룹 관리자에게 문의 바랍니다.
해당 사항을 개발그룹 관리자에게 문의 바랍니다.
해당 사항을 개발그룹 관리자에게 문의 바랍니다.
해당 사항을 개발그룹 관리자에게 문의 바랍니다.
해당 사항을 개발그룹 관리자에게 문의 바랍니다.
해당 사항을 개발그룹 관리자에게 문의 바랍니다.
해당 사항을 개발그룹 관리자에게 문의 바랍니다.
해당 사항을 개발그룹 관리자에게 문의 바랍니다.
해당 사항을 개발그룹 관리자에게 문의 바랍니다.".Trim(), MessageBoxButtons.YesNoCancel);
        }

    }
}
