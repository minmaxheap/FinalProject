
namespace POPprogram
{
    partial class frmShipSearch
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
            //System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            //System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            //System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            //System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.csDataGridView1 = new POPprogram.csDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.csDataGridView1)).BeginInit();
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
            this.lblPanel.Text = "납품서 선택";
            // 
            // btnTxtSearch
            // 
            this.btnTxtSearch.Location = new System.Drawing.Point(363, 52);
            this.btnTxtSearch.Click += new System.EventHandler(this.btnTxtSearch_Click);
            // 
            // csDataGridView1
            // 
            //dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(239)))), ((int)(((byte)(247)))));
            //this.csDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            //this.csDataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(243)))), ((int)(((byte)(251)))));
            //this.csDataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            //dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            //dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
            //dataGridViewCellStyle2.Font = new System.Drawing.Font("나눔고딕", 14.25F);
            //dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            //dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
            //dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            //dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            //this.csDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            //this.csDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            //dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            //dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            //dataGridViewCellStyle3.Font = new System.Drawing.Font("나눔고딕", 14.25F);
            //dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            //dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(195)))), ((int)(((byte)(230)))));
            //dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            //dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            //this.csDataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            //this.csDataGridView1.EnableHeadersVisualStyles = false;
            this.csDataGridView1.Location = new System.Drawing.Point(0, 94);
            this.csDataGridView1.Name = "csDataGridView1";
            //dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            //dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            //dataGridViewCellStyle4.Font = new System.Drawing.Font("나눔고딕", 14.25F);
            //dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            //dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            //dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            //dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            //this.csDataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            //this.csDataGridView1.RowHeadersWidth = 30;
            //this.csDataGridView1.RowTemplate.Height = 23;
            this.csDataGridView1.Size = new System.Drawing.Size(1024, 308);
            this.csDataGridView1.TabIndex = 97;
            this.csDataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.csDataGridView1_CellClick);
            this.csDataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.csDataGridView1_CellDoubleClick);
            // 
            // frmShipSearch
            // 
            this.ClientSize = new System.Drawing.Size(1024, 478);
            this.Controls.Add(this.csDataGridView1);
            this.Name = "frmShipSearch";
            this.Load += new System.EventHandler(this.frmPrurchaseDialog_Load);
            this.Controls.SetChildIndex(this.btnTxtSearch, 0);
            this.Controls.SetChildIndex(this.lblPanel, 0);
            this.Controls.SetChildIndex(this.txtSearch, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.btnSelect, 0);
            this.Controls.SetChildIndex(this.csDataGridView1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.csDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private csDataGridView csDataGridView1;
    }
}
