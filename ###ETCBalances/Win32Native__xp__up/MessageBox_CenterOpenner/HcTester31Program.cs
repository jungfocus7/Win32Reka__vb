using System;
using System.Windows.Forms;


namespace MessageBox_CenterOpenner
{
    public static class HcTester31Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new HcTester31Form());
        }
    }
}
