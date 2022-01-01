
namespace POPprogram
{
    partial class frmNewLOT
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
            this.panel4.SuspendLayout();
            this.panel8.SuspendLayout();
            this.pnlCrud.SuspendLayout();
            this.SuspendLayout();
            this.panel8.Controls.SetChildIndex(this.label6, 0);
            this.panel8.Controls.SetChildIndex(this.textBox2, 0);
            this.panel8.Controls.SetChildIndex(this.textBox4, 0);
            this.panel8.Controls.SetChildIndex(this.textBox5, 0);
            this.panel8.Controls.SetChildIndex(this.label3, 0);
            this.panel8.Controls.SetChildIndex(this.label2, 0);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(85, 121);
            this.label10.Size = new System.Drawing.Size(46, 21);
            this.label10.Text = "공장";
            // 
            // label9
            // 
            this.label9.Text = "품번";
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(22, 51);
            this.label22.Size = new System.Drawing.Size(109, 21);
            this.label22.Text = "생산 LOT ID";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(49, 60);
            this.label3.Size = new System.Drawing.Size(82, 21);
            this.label3.Text = "작업지시";
            // 
            // frmNewLOT
            // 
            this.ClientSize = new System.Drawing.Size(1194, 634);
            this.Name = "frmNewLOT";
            this.Load += new System.EventHandler(this.frmNewLot1_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.pnlCrud.ResumeLayout(false);
            this.pnlCrud.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
