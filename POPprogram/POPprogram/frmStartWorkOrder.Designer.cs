
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
            this.txtEQ_NAME = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cboEQList = new System.Windows.Forms.ComboBox();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnlCrud.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.cboEQList);
            this.panel4.Controls.Add(this.txtEQ_NAME);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Location = new System.Drawing.Point(31, 518);
            this.panel4.Size = new System.Drawing.Size(1136, 262);
            this.panel4.Controls.SetChildIndex(this.label12, 0);
            this.panel4.Controls.SetChildIndex(this.txtEQ_NAME, 0);
            this.panel4.Controls.SetChildIndex(this.cboEQList, 0);
            this.panel4.Controls.SetChildIndex(this.txtComment, 0);
            this.panel4.Controls.SetChildIndex(this.label13, 0);
            this.panel4.Controls.SetChildIndex(this.label1, 0);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(102, 155);
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(165, 152);
            // 
            // label1
            // 
            this.label1.Text = "작업 시작 정보";
            // 
            // pnlCrud
            // 
            this.pnlCrud.Location = new System.Drawing.Point(499, 788);
            // 
            // btnClose
            // 
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnExecute
            // 
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // cboLOTID
            // 
            this.cboLOTID.SelectedIndexChanged += new System.EventHandler(this.cboLOTID_SelectedIndexChanged);
            // 
            // txtEQ_NAME
            // 
            this.txtEQ_NAME.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEQ_NAME.BackColor = System.Drawing.SystemColors.Window;
            this.txtEQ_NAME.Font = new System.Drawing.Font("나눔고딕", 12F);
            this.txtEQ_NAME.Location = new System.Drawing.Point(521, 93);
            this.txtEQ_NAME.Name = "txtEQ_NAME";
            this.txtEQ_NAME.ReadOnly = true;
            this.txtEQ_NAME.Size = new System.Drawing.Size(581, 26);
            this.txtEQ_NAME.TabIndex = 58;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("나눔고딕", 12F);
            this.label12.Location = new System.Drawing.Point(102, 96);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 19);
            this.label12.TabIndex = 57;
            this.label12.Text = "설비";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboEQList
            // 
            this.cboEQList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboEQList.Font = new System.Drawing.Font("나눔고딕", 12F);
            this.cboEQList.FormattingEnabled = true;
            this.cboEQList.Location = new System.Drawing.Point(165, 93);
            this.cboEQList.Name = "cboEQList";
            this.cboEQList.Size = new System.Drawing.Size(335, 27);
            this.cboEQList.TabIndex = 59;
            this.cboEQList.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.cboEQList.RightToLeftChanged += new System.EventHandler(this.comboBox1_RightToLeftChanged);
            // 
            // frmStartWorkOrder
            // 
            this.ClientSize = new System.Drawing.Size(1194, 850);
            this.Name = "frmStartWorkOrder";
            this.Activated += new System.EventHandler(this.frmStartWorkOrder_Activated);
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

        public System.Windows.Forms.TextBox txtEQ_NAME;
        public System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboEQList;
    }
}
