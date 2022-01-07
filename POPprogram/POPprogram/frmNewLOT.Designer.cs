
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
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(30, 411);
            this.panel4.Size = new System.Drawing.Size(1234, 243);
            // 
            // panel8
            // 
            this.panel8.Size = new System.Drawing.Size(1234, 350);
            // 
            // txtCustName
            // 
            this.txtCustName.ReadOnly = true;
            // 
            // txtCustID
            // 
            this.txtCustID.ReadOnly = true;
            // 
            // txtWorkOrderID
            // 
            this.txtWorkOrderID.ReadOnly = true;
            // 
            // label6
            // 
            this.label6.Size = new System.Drawing.Size(1232, 55);
            // 
            // label8
            // 
            this.label8.Size = new System.Drawing.Size(253, 41);
            // 
            // label7
            // 
            this.label7.Size = new System.Drawing.Size(250, 41);
            // 
            // label5
            // 
            this.label5.Size = new System.Drawing.Size(250, 41);
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(0, 41);
            this.lblStatus.Size = new System.Drawing.Size(250, 55);
            // 
            // lblDefectQty
            // 
            this.lblDefectQty.Location = new System.Drawing.Point(0, 41);
            this.lblDefectQty.Size = new System.Drawing.Size(253, 55);
            // 
            // lblProdQty
            // 
            this.lblProdQty.Location = new System.Drawing.Point(0, 41);
            this.lblProdQty.Size = new System.Drawing.Size(250, 55);
            // 
            // lblOrderQty
            // 
            this.lblOrderQty.Location = new System.Drawing.Point(0, 41);
            this.lblOrderQty.Size = new System.Drawing.Size(250, 55);
            // 
            // label4
            // 
            this.label4.Size = new System.Drawing.Size(250, 41);
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
            this.txtOperCode.ReadOnly = true;
            // 
            // lblQty
            // 
            this.lblQty.ForeColor = System.Drawing.Color.Tomato;
            // 
            // txtProdName
            // 
            this.txtProdName.ReadOnly = true;
            // 
            // txtProdCode
            // 
            this.txtProdCode.ReadOnly = true;
            // 
            // lblLOT
            // 
            this.lblLOT.ForeColor = System.Drawing.Color.Tomato;
            // 
            // txtOperName
            // 
            this.txtOperName.ReadOnly = true;
            // 
            // btnTxtSearch
            // 
            this.btnTxtSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // frmNewLOT
            // 
           // this.ClientSize = new System.Drawing.Size(1292, 757);
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
