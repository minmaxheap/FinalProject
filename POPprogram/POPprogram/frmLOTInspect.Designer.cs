
namespace POPprogram
{
    partial class frmLOTInspect
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.csDataGridView1 = new POPprogram.csDataGridView();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnlCrud.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.csDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.csDataGridView1);
            this.panel4.Controls.SetChildIndex(this.txtComment, 0);
            this.panel4.Controls.SetChildIndex(this.label13, 0);
            this.panel4.Controls.SetChildIndex(this.label1, 0);
            this.panel4.Controls.SetChildIndex(this.csDataGridView1, 0);
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
            // csDataGridView1
            // 
            //dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            //this.csDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.csDataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            //this.csDataGridView1.BackgroundColor = System.Drawing.Color.White;
            //this.csDataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            //dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            //dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
            //dataGridViewCellStyle2.Font = new System.Drawing.Font("나눔고딕", 10F);
            //dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            //dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
            //dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            //dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            //this.csDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            //this.csDataGridView1.ColumnHeadersHeight = 35;
            //dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            //dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            //dataGridViewCellStyle3.Font = new System.Drawing.Font("나눔고딕", 9F);
            //dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            //dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            //dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            //dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            //this.csDataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            //this.csDataGridView1.EnableHeadersVisualStyles = false;
            this.csDataGridView1.Location = new System.Drawing.Point(0, 43);
            this.csDataGridView1.Name = "csDataGridView1";
            //dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            //dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            //dataGridViewCellStyle4.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            //dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            //dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            //dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            //dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            //this.csDataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            //this.csDataGridView1.RowHeadersWidth = 30;
            this.csDataGridView1.Size = new System.Drawing.Size(1134, 65);
            this.csDataGridView1.TabIndex = 40;
            this.csDataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.csDataGridView1_CellClick);
            this.csDataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.csDataGridView1_CellValueChanged);
            this.csDataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.csDataGridView1_KeyDown);
            // 
            // frmLOTInspect
            // 
            this.ClientSize = new System.Drawing.Size(1194, 788);
            this.Name = "frmLOTInspect";
            this.Load += new System.EventHandler(this.frmLOTInspect_Load);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.pnlCrud.ResumeLayout(false);
            this.pnlCrud.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.csDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private csDataGridView csDataGridView1;
	}
}
