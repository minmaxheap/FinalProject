
namespace POPprogram
{
    partial class frmStockIN
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.textBox7);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.comboBox1);
            this.panel4.Controls.SetChildIndex(this.label1, 0);
            this.panel4.Controls.SetChildIndex(this.textBox1, 0);
            this.panel4.Controls.SetChildIndex(this.label3, 0);
            this.panel4.Controls.SetChildIndex(this.textBox2, 0);
            this.panel4.Controls.SetChildIndex(this.label4, 0);
            this.panel4.Controls.SetChildIndex(this.comboBox1, 0);
            this.panel4.Controls.SetChildIndex(this.label7, 0);
            this.panel4.Controls.SetChildIndex(this.textBox7, 0);
            this.panel4.Controls.SetChildIndex(this.label5, 0);
            // 
            // label1
            // 
            this.label1.Text = "구매 입고 자재 목록";
            this.panel7.Controls.SetChildIndex(this.label9, 0);
            this.panel7.Controls.SetChildIndex(this.textBox9, 0);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(84, 5);
            this.label9.Size = new System.Drawing.Size(64, 21);
            this.label9.Text = "납품서";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(61, 123);
            this.label10.Size = new System.Drawing.Size(87, 21);
            this.label10.Text = "주문 수량";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(84, 88);
            this.label2.Size = new System.Drawing.Size(64, 21);
            this.label2.Text = "납품처";
            // 
            // label6
            // 
            this.label6.Text = "구매 납품서 정보";
            // 
            // btnExport
            // 
            this.btnExport.Image = global::POPprogram.Properties.Resources.Data_Import;
            this.btnExport.Location = new System.Drawing.Point(453, 0);
            this.btnExport.Text = "입고";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(885, 249);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(974, 245);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(869, 207);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(974, 203);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.Font = new System.Drawing.Font("나눔고딕", 14.25F, System.Drawing.FontStyle.Bold);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(863, 159);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(240, 29);
            this.comboBox1.TabIndex = 61;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("나눔고딕", 14.25F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(863, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 21);
            this.label5.TabIndex = 64;
            this.label5.Text = "입고 창고";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox7
            // 
            this.textBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox7.Font = new System.Drawing.Font("나눔고딕", 14.25F, System.Drawing.FontStyle.Bold);
            this.textBox7.Location = new System.Drawing.Point(863, 73);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(240, 29);
            this.textBox7.TabIndex = 63;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("나눔고딕", 14.25F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(863, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(141, 21);
            this.label7.TabIndex = 62;
            this.label7.Text = "자재 LOT SCAN";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmStockIN
            // 
            this.ClientSize = new System.Drawing.Size(1194, 634);
            this.Name = "frmStockIN";
            this.panel6.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox textBox7;
        public System.Windows.Forms.Label label7;
    }
}
