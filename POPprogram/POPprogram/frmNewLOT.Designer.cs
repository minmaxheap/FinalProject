
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
            // 
            // txtCustName
            // 
            this.txtCustName.BackColor = System.Drawing.SystemColors.Window;
            this.txtCustName.ReadOnly = true;
            // 
            // txtCustID
            // 
            this.txtCustID.BackColor = System.Drawing.SystemColors.Window;
            this.txtCustID.ReadOnly = true;
            // 
            // txtWorkOrderID
            // 
            this.txtWorkOrderID.BackColor = System.Drawing.SystemColors.Window;
            this.txtWorkOrderID.ReadOnly = true;
            // 
            // btnExecute
            // 
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // btnClose
            // 
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtOperCode
            // 
            this.txtOperCode.BackColor = System.Drawing.SystemColors.Window;
            this.txtOperCode.ReadOnly = true;
            // 
            // lblQty
            // 
            this.lblQty.ForeColor = System.Drawing.Color.Tomato;
            // 
            // txtProdName
            // 
            this.txtProdName.BackColor = System.Drawing.SystemColors.Window;
            this.txtProdName.ReadOnly = true;
            // 
            // txtProdCode
            // 
            this.txtProdCode.BackColor = System.Drawing.SystemColors.Window;
            this.txtProdCode.ReadOnly = true;
            // 
            // txtLOTID
            // 
            this.txtLOTID.Click += new System.EventHandler(this.txtLOTID_Click);
            this.txtLOTID.TextChanged += new System.EventHandler(this.txtLOTID_TextChanged);
            // 
            // lblLOT
            // 
            this.lblLOT.ForeColor = System.Drawing.Color.Tomato;
            // 
            // txtOperName
            // 
            this.txtOperName.BackColor = System.Drawing.SystemColors.Window;
            this.txtOperName.ReadOnly = true;
            // 
            // btnTxtSearch
            // 
            this.btnTxtSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // frmNewLOT
            // 
            this.ClientSize = new System.Drawing.Size(1194, 823);
            this.Name = "frmNewLOT";
            this.Load += new System.EventHandler(this.frmNewLOT_Load);
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
