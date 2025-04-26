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


            Screen tcs = Screen.FromPoint(Cursor.Position);
            Rectangle tsb = tcs.WorkingArea;
            Point tlp = new Point(tsb.Right, tsb.Bottom);
            Size tws = Size;
            tlp.Offset(-(tws.Width + 40), -(tws.Height + 40));
            Location = tlp;


            m_cms = new ContextMenuStrip();
            m_cms.MouseClick += pr_cms__MouseClick;
            m_cms.PreviewKeyDown += pr_cms__PreviewKeyDown;


            ToolStripItem[] tsia =
            {
                new ToolStripMenuItem()
                {
                    Name = "tsi_1",
                    Text = "개발자~~~1"
                },
                new ToolStripMenuItem()
                {
                    Name = "tsi_2",
                    Text = "개발자~~~2"
                },
                new ToolStripMenuItem()
                {
                    Name = "tsi_3",
                    Text = "개발자~~~3"
                },
                new ToolStripSeparator(),
                new ToolStripMenuItem()
                {
                    Name = "tsi_4",
                    Text = "개발자~~~4"
                },
                new ToolStripMenuItem()
                {
                    Name = "tsi_5",
                    Text = "개발자~~~5"
                },
                new ToolStripMenuItem()
                {
                    Name = "tsi_6",
                    Text = "개발자~~~6"
                },
                new ToolStripMenuItem()
                {
                    Name = "tsi_7",
                    Text = "개발자~~~7"
                },
                new ToolStripMenuItem()
                {
                    Name = "tsi_8",
                    Text = "개발자~~~8"
                }
            };

            ToolStripMenuItem tsmi;
            tsmi = new ToolStripMenuItem()
            {
                Name = "tsi_1",
                Text = "개발자~~~1"
            };
            m_cms.Items.Add(tsmi);
            tsmi = new ToolStripMenuItem()
            {
                Name = "tsi_2",
                Text = "개발자~~~2"
            };
            m_cms.Items.Add(tsmi);
            tsmi = new ToolStripMenuItem()
            {
                Name = "tsi_3",
                Text = "개발자~~~3"
            };
            m_cms.Items.Add(tsmi);
            m_cms.Items.Add(new ToolStripSeparator());
            tsmi = new ToolStripMenuItem()
            {
                Name = "tsi_4",
                Text = "개발자~~~4"
            };
            m_cms.Items.Add(tsmi);
            tsmi = new ToolStripMenuItem()
            {
                Name = "tsi_5",
                Text = "개발자~~~5"
            };
            m_cms.Items.Add(tsmi);
            tsmi = new ToolStripMenuItem()
            {
                Name = "tsi_6",
                Text = "개발자~~~6"
            };
            m_cms.Items.Add(tsmi);
            tsmi = new ToolStripMenuItem()
            {
                Name = "tsi_7",
                Text = "개발자~~~7"
            };
            m_cms.Items.Add(tsmi);
            tsmi = new ToolStripMenuItem()
            {
                Name = "tsi_8",
                Text = "개발자~~~8"
            };
            m_cms.Items.Add(tsmi);
            m_btnAll.ContextMenuStrip = m_cms;            
        }


        private void pr_cms_TargetPerform(ToolStripItem tsi)
        {
            m_btnAll.Text = tsi.Text;
            m_btnAll.Tag = tsi;
            //switch (tsi.Name)
            //{
            //    case "tsi_1":
            //    {
            //        //MessageBox.Show("개발자~~~1");
            //        m_btnAll.Text = tsi.Text;
            //        m_btnAll.Tag = tsi;
            //        break;
            //    }
            //    case "tsi_2":
            //    {
            //        //MessageBox.Show("개발자~~~2");
            //        m_btnAll.Text = tsi.Text;
            //        m_btnAll.Tag = tsi;
            //        break;
            //    }

            //    default:
            //        break;
            //}
        }


        private void pr_cms__MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (m_cms.GetItemAt(e.Location) is ToolStripItem tsi)
                {
                    pr_cms_TargetPerform(tsi);
                }                
            }
        }


        private void pr_cms__PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (m_cms.Visible)
            {
                char tcw = e.KeyData.ToString()[1];                
                int ti = (int)char.GetNumericValue(tcw);
                if (ti > 0) ti = ti - 1;
                if (m_cms.Items[ti] is ToolStripMenuItem tsmi)
                {
                    pr_cms_TargetPerform(tsmi);
                    m_cms.Close();
                }
            }
        }

    }

}
