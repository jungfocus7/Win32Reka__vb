using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace WinformContextMenu
{
    public sealed partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }


        private ContextMenuStrip m_cms;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            ContextMenuStrip cms = new ContextMenuStrip();
            ToolStripItem tsi;
            cms.Items.Add("출력 비우기");
            cms.Items.Add("쿼리 비우기");
            tsi = cms.Items.Add("파라미터 비우기");
            tsi.MouseUp += delegate {
            };
            tsi.MouseDown += pr_tsi__MouseDown;
            tsi.Click += pr_tsi__Click;
            m_cms = cms;

            //m_btnAll.MouseHover += delegate
            //{
            //    m_cms.Show(m_btnAll.Location);
            //};
            //m_btnAll.MouseEnter += delegate
            //{
            //    m_cms.Show(this, m_btnAll.Location);
            //};
            //m_btnAll.MouseDown += delegate
            //{
            //    m_cms.Show(this, m_btnAll.Location);
            //};
            //ContextMenuStrip = m_cms;

            
            m_btnAll.MouseDown += pr_btnAll__MouseDown;
            m_btnAll.MouseUp += pr_btnAll__MouseUp;
            m_btnAll.Click += pr_btnAll__Click;
        }


        private void pr_btnAll__MouseDown(object sender, MouseEventArgs e)
        {
            //m_cms.Show(this, m_btnAll.Location);
            Debug.WriteLine("pr_btnAll__MouseDown");
        }

        private void pr_btnAll__MouseUp(object sender, MouseEventArgs e)
        {
            Debug.WriteLine("pr_btnAll__MouseUp");
        }

        private void pr_btnAll__Click(object sender, EventArgs e)
        {
            //MessageBox.Show("pr_btnAll__Click~~~~");
            //m_cms.Show(this, m_btnAll.Location);
            Debug.WriteLine("pr_btnAll__Click");
        }


        private bool m_bx = false;

        private void pr_tsi__MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                m_bx = true;
            }
        }

        private void pr_tsi__Click(object sender, EventArgs e)
        {
            if (m_bx)
            {
                MessageBox.Show("pr_tsi__Click~~~~");
                m_bx = false;
            }
        }






    }
}
