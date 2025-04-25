namespace MessageBox_CenterOpenner
{
    partial class HcTester31Form
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HcTester31Form));
            this.m_txb31 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_btn31 = new System.Windows.Forms.Button();
            this.webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).BeginInit();
            this.SuspendLayout();
            // 
            // m_txb31
            // 
            this.m_txb31.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txb31.Location = new System.Drawing.Point(12, 12);
            this.m_txb31.Multiline = true;
            this.m_txb31.Name = "m_txb31";
            this.m_txb31.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.m_txb31.Size = new System.Drawing.Size(700, 320);
            this.m_txb31.TabIndex = 1;
            this.m_txb31.Text = resources.GetString("m_txb31.Text");
            this.m_txb31.WordWrap = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Brown;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(636, 703);
            this.panel1.TabIndex = 2;
            // 
            // m_btn31
            // 
            this.m_btn31.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btn31.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btn31.Location = new System.Drawing.Point(515, 348);
            this.m_btn31.Name = "m_btn31";
            this.m_btn31.Size = new System.Drawing.Size(273, 140);
            this.m_btn31.TabIndex = 4;
            this.m_btn31.Text = "TEST31";
            this.m_btn31.UseVisualStyleBackColor = true;
            // 
            // webView21
            // 
            this.webView21.AllowExternalDrop = true;
            this.webView21.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webView21.CreationProperties = null;
            this.webView21.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView21.Location = new System.Drawing.Point(62, 45);
            this.webView21.Name = "webView21";
            this.webView21.Size = new System.Drawing.Size(715, 426);
            this.webView21.Source = new System.Uri("https://www.youtube.com/watch?v=bzSnDxqOvz0", System.UriKind.Absolute);
            this.webView21.TabIndex = 6;
            this.webView21.ZoomFactor = 1D;
            // 
            // Tester31Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.m_btn31);
            this.Controls.Add(this.webView21);
            this.Controls.Add(this.m_txb31);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Location = new System.Drawing.Point(100, 40);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Tester31Form";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox m_txb31;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button m_btn31;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
    }
}

