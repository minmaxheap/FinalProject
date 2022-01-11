
namespace POPprogram
{
    partial class frmPrurchaseDialog
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvPurchase = new POPprogram.csDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchase)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(12, 419);
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(902, 419);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(12, 53);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // lblPanel
            // 
            this.lblPanel.Font = new System.Drawing.Font("나눔고딕", 18F);
            this.lblPanel.Text = "납품서 선택";
            // 
            // btnTxtSearch
            // 
            this.btnTxtSearch.Location = new System.Drawing.Point(363, 52);
            this.btnTxtSearch.Click += new System.EventHandler(this.btnTxtSearch_Click);
            // 
            // dgvPurchase
            // 
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.dgvPurchase.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvPurchase.BackgroundColor = System.Drawing.Color.White;
            this.dgvPurchase.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("나눔고딕", 14.25F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPurchase.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvPurchase.ColumnHeadersHeight = 35;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("나눔고딕", 14.25F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(195)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPurchase.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvPurchase.EnableHeadersVisualStyles = false;
            this.dgvPurchase.Location = new System.Drawing.Point(0, 94);
            this.dgvPurchase.Name = "dgvPurchase";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("나눔고딕", 14.25F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPurchase.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvPurchase.RowHeadersWidth = 30;
            this.dgvPurchase.Size = new System.Drawing.Size(1024, 308);
            this.dgvPurchase.TabIndex = 97;
            // 
            // frmPrurchaseDialog
            // 
            this.ClientSize = new System.Drawing.Size(1024, 513);
            this.Controls.Add(this.dgvPurchase);
            this.Name = "frmPrurchaseDialog";
            this.Load += new System.EventHandler(this.frmPrurchaseDialog_Load);
            this.Controls.SetChildIndex(this.btnTxtSearch, 0);
            this.Controls.SetChildIndex(this.lblPanel, 0);
            this.Controls.SetChildIndex(this.txtSearch, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.btnSelect, 0);
            this.Controls.SetChildIndex(this.dgvPurchase, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchase)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private csDataGridView dgvPurchase;
    }
}
