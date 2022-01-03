
namespace POPprogram
{
    partial class frmStartWorkOrder
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
			this.textBox10 = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.panel7.SuspendLayout();
			this.panel8.SuspendLayout();
			this.panel4.SuspendLayout();
			this.pnlCrud.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel8
			// 
			this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			// 
			// panel4
			// 
			this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel4.Controls.Add(this.comboBox1);
			this.panel4.Controls.Add(this.textBox10);
			this.panel4.Controls.Add(this.label12);
			this.panel4.Controls.SetChildIndex(this.label12, 0);
			this.panel4.Controls.SetChildIndex(this.textBox10, 0);
			this.panel4.Controls.SetChildIndex(this.comboBox1, 0);
			this.panel4.Controls.SetChildIndex(this.txtComment, 0);
			this.panel4.Controls.SetChildIndex(this.label13, 0);
			this.panel4.Controls.SetChildIndex(this.label1, 0);
			// 
			// label1
			// 
			this.label1.Text = "작업 시작 정보";
			// 
			// textBox10
			// 
			this.textBox10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox10.Font = new System.Drawing.Font("나눔고딕", 14.25F, System.Drawing.FontStyle.Bold);
			this.textBox10.Location = new System.Drawing.Point(521, 71);
			this.textBox10.Name = "textBox10";
			this.textBox10.Size = new System.Drawing.Size(581, 29);
			this.textBox10.TabIndex = 58;
			// 
			// label12
			// 
			this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("나눔고딕", 14.25F, System.Drawing.FontStyle.Bold);
			this.label12.Location = new System.Drawing.Point(102, 75);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(46, 21);
			this.label12.TabIndex = 57;
			this.label12.Text = "설비";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// comboBox1
			// 
			this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.comboBox1.Font = new System.Drawing.Font("나눔고딕", 14.25F, System.Drawing.FontStyle.Bold);
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(166, 71);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(335, 29);
			this.comboBox1.TabIndex = 59;
			// 
			// frmStartWorkOrder
			// 
			this.ClientSize = new System.Drawing.Size(1194, 634);
			this.Name = "frmStartWorkOrder";
			this.Load += new System.EventHandler(this.frmStartWorkOrder_Load);
			this.panel7.ResumeLayout(false);
			this.panel7.PerformLayout();
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.pnlCrud.ResumeLayout(false);
			this.pnlCrud.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TextBox textBox10;
        public System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}
