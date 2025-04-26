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
                    Text = "(1) 개발자~~~1"
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
                new ToolStripSeparator(),
                new ToolStripMenuItem()
                {
                    Name = "tsi_7",
                    Text = "개발자~~~7"
                },
                new ToolStripMenuItem()
                {
                    Name = "tsi_8",
                    Text = "개발자~~~8"
                },
                new ToolStripMenuItem()
                {
                    Name = "tsi_9",
                    Text = "개발자~~~9"
                },
                new ToolStripMenuItem()
                {
                    Name = "tsi_0",
                    Text = "개발자~~~0"
                }
            };
            m_cms.Items.AddRange(tsia);
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
                //if (ti > 0) ti = ti - 1;
                //if (m_cms.Items[ti] is ToolStripMenuItem tsmi)
                //{
                //    pr_cms_TargetPerform(tsmi);
                //    m_cms.Close();
                //}
                foreach (ToolStripItem tsi in m_cms.Items)
                {
                    if (tsi.Name == $"tsi_{ti}")
                    {
                        pr_cms_TargetPerform(tsi);                        
                        break;
                    }
                }

                m_cms.Close();
            }
        }

    }

}
