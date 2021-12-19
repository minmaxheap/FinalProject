
namespace MES_Team3
{
    partial class frmEquipment
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
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Text = "설비 목록";
            // 
            // splitContainer1
            // 
            this.panel3.Controls.SetChildIndex(this.textBox1, 0);
            this.panel3.Controls.SetChildIndex(this.button3, 0);
            // 
            // label12
            // 
            this.label12.Text = "변경 사용자";
            // 
            // label11
            // 
            this.label11.Text = "변경 시간";
            // 
            // label10
            // 
            this.label10.Text = "생성 사용자";
            // 
            // label9
            // 
            this.label9.Text = "생성 시간";
            // 
            // label8
            // 
            this.label8.Text = "최근 다운 시간";
            // 
            // label7
            // 
            this.label7.Text = "상태";
            // 
            // label3
            // 
            this.label3.Text = "설비 유형";
            // 
            // label2
            // 
            this.label2.Text = "설비명";
            // 
            // label4
            // 
            this.label4.Text = "설비";
            // 
            // frmEquipment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(1184, 706);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmEquipment";
            this.Load += new System.EventHandler(this.frmEquipment_Load);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
