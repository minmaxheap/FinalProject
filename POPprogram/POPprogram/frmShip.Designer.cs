
namespace POPprogram
{
    partial class frmShip
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
            this.btnPrint = new System.Windows.Forms.Button();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnPrint);
            this.panel6.Controls.SetChildIndex(this.btnExport, 0);
            this.panel6.Controls.SetChildIndex(this.btnClose, 0);
            this.panel6.Controls.SetChildIndex(this.btnPrint, 0);
            // 
            // label1
            // 
            this.label1.Text = "완제품 창고 재고 목록";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(84, 5);
            this.label9.Size = new System.Drawing.Size(64, 21);
            this.label9.Text = "주문서";
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
            this.label2.Text = "고객사";
            // 
            // label6
            // 
            this.label6.Text = "제품 주문서 정보";
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(194)))), ((int)(((byte)(229)))));
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrint.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 21.75F, System.Drawing.FontStyle.Bold);
            this.btnPrint.Image = global::POPprogram.Properties.Resources.Print___01;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPrint.Location = new System.Drawing.Point(412, 0);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(139, 70);
            this.btnPrint.TabIndex = 95;
            this.btnPrint.Text = "라벨 발행";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPrint.UseVisualStyleBackColor = false;
            // 
            // frmShip
            // 
            this.ClientSize = new System.Drawing.Size(1194, 634);
            this.Name = "frmShip";
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

        public System.Windows.Forms.Button btnPrint;
    }
}
