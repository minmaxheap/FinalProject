
namespace MES_Team3
{
    partial class frmWorkOrder
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
            this.pgProperty = new System.Windows.Forms.PropertyGrid();
            this.pgSearch = new System.Windows.Forms.PropertyGrid();
            this.csDataGridView1 = new MES_Team3.csDataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.pnlProperty.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcBase)).BeginInit();
            this.spcBase.Panel1.SuspendLayout();
            this.spcBase.Panel2.SuspendLayout();
            this.spcBase.SuspendLayout();
            this.pnlDgv.SuspendLayout();
            this.pnlCrud.SuspendLayout();
            this.pnlTopLbl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.csDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(777, 55);
            this.lblTitle.Text = "작업지시 목록";
            // 
            // pnlProperty
            // 
            this.pnlProperty.Controls.Add(this.pgProperty);
            this.pnlProperty.Size = new System.Drawing.Size(359, 542);
            // 
            // lblPanel
            // 
            this.lblPanel.Size = new System.Drawing.Size(359, 55);
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.pgSearch);
            this.pnlSearch.Size = new System.Drawing.Size(359, 542);
            // 
            // btnPanel
            // 
            this.btnPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(152)))), ((int)(((byte)(216)))));
            this.btnPanel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
            this.btnPanel.FlatAppearance.BorderSize = 0;
            this.btnPanel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(243)))), ((int)(((byte)(251)))));
            this.btnPanel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(243)))), ((int)(((byte)(251)))));
            this.btnPanel.Location = new System.Drawing.Point(305, 10);
            this.btnPanel.Click += new System.EventHandler(this.btnPanel_Click);
            // 
            // spcBase
            // 
            this.spcBase.SplitterDistance = 779;
            // 
            // pnlDgv
            // 
            this.pnlDgv.Controls.Add(this.csDataGridView1);
            // 
            // btnSearchPnl
            // 
            this.btnSearchPnl.Click += new System.EventHandler(this.button3_Click);
            // 
            // pnlCrud
            // 
            this.pnlCrud.Controls.Add(this.button1);
            this.pnlCrud.Controls.SetChildIndex(this.btnUpdate, 0);
            this.pnlCrud.Controls.SetChildIndex(this.btnReadBottom, 0);
            this.pnlCrud.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlCrud.Controls.SetChildIndex(this.btnClear, 0);
            this.pnlCrud.Controls.SetChildIndex(this.btnDelete, 0);
            this.pnlCrud.Controls.SetChildIndex(this.btnInsert, 0);
            this.pnlCrud.Controls.SetChildIndex(this.button1, 0);
            // 
            // txtSearch
            // 
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // btnInsert
            // 
            this.btnInsert.Size = new System.Drawing.Size(63, 48);
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Size = new System.Drawing.Size(63, 48);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Size = new System.Drawing.Size(63, 48);
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnClose
            // 
            this.btnClose.Size = new System.Drawing.Size(63, 48);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReadBottom
            // 
            this.btnReadBottom.Size = new System.Drawing.Size(63, 48);
            this.btnReadBottom.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Size = new System.Drawing.Size(63, 48);
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnReadTop
            // 
            this.btnReadTop.Click += new System.EventHandler(this.btnReadTop_Click);
            // 
            // btnTxtSearch
            // 
            this.btnTxtSearch.Click += new System.EventHandler(this.btnTxtSearch_Click);
            // 
            // pgProperty
            // 
            this.pgProperty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgProperty.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pgProperty.HelpVisible = false;
            this.pgProperty.Location = new System.Drawing.Point(0, 0);
            this.pgProperty.Name = "pgProperty";
            this.pgProperty.Size = new System.Drawing.Size(357, 540);
            this.pgProperty.TabIndex = 4;
            this.pgProperty.ToolbarVisible = false;
            // 
            // pgSearch
            // 
            this.pgSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgSearch.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pgSearch.HelpVisible = false;
            this.pgSearch.Location = new System.Drawing.Point(0, 0);
            this.pgSearch.Name = "pgSearch";
            this.pgSearch.Size = new System.Drawing.Size(357, 540);
            this.pgSearch.TabIndex = 3;
            this.pgSearch.ToolbarVisible = false;
            // 
            // csDataGridView1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(239)))), ((int)(((byte)(247)))));
            this.csDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.csDataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(243)))), ((int)(((byte)(251)))));
            this.csDataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("나눔고딕", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.csDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.csDataGridView1.ColumnHeadersHeight = 45;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("나눔고딕", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(195)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.csDataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.csDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.csDataGridView1.EnableHeadersVisualStyles = false;
            this.csDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.csDataGridView1.Name = "csDataGridView1";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.csDataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.csDataGridView1.RowHeadersWidth = 30;
            this.csDataGridView1.Size = new System.Drawing.Size(777, 542);
            this.csDataGridView1.TabIndex = 0;
            this.csDataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.csDataGridView1_CellClick);
            this.csDataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.csDataGridView1_CellFormatting);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(194)))), ((int)(((byte)(229)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.Image = global::MES_Team3.Properties.Resources.Check_01;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(225, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 48);
            this.button1.TabIndex = 86;
            this.button1.Text = "마감";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmWorkOrder
            // 
            this.BIsSearchPanel = true;
            this.BPropertyPanel = true;
            this.BSearchPanel = true;
            this.ClientSize = new System.Drawing.Size(1168, 778);
            this.Name = "frmWorkOrder";
            this.Text = "품번 설정";
            this.Load += new System.EventHandler(this.frmProduct1_Load);
            this.Shown += new System.EventHandler(this.frmWorkOrder_Shown);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlProperty.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.spcBase.Panel1.ResumeLayout(false);
            this.spcBase.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcBase)).EndInit();
            this.spcBase.ResumeLayout(false);
            this.pnlDgv.ResumeLayout(false);
            this.pnlCrud.ResumeLayout(false);
            this.pnlTopLbl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.csDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid pgProperty;
        private System.Windows.Forms.PropertyGrid pgSearch;
        private csDataGridView csDataGridView1;
        public System.Windows.Forms.Button button1;
    }
}
