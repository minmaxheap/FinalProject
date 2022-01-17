
namespace MES_Team3
{
    partial class frmINSPECT_MST
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pgGrid = new System.Windows.Forms.PropertyGrid();
            this.pgSearch = new System.Windows.Forms.PropertyGrid();
            this.csDataGridView1 = new MES_Team3.csDataGridView();
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
            // pnlTop
            // 
            this.pnlTop.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // lblTitle
            // 
            this.lblTitle.Text = "검사 목록";
            // 
            // pnlProperty
            // 
            this.pnlProperty.Controls.Add(this.pgGrid);
            this.pnlProperty.Location = new System.Drawing.Point(0, 0);
            this.pnlProperty.Size = new System.Drawing.Size(364, 633);
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.pgSearch);
            this.pnlSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlSearch.Size = new System.Drawing.Size(364, 633);
            // 
            // btnPanel
            // 
            this.btnPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(152)))), ((int)(((byte)(216)))));
            this.btnPanel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
            this.btnPanel.FlatAppearance.BorderSize = 0;
            this.btnPanel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(243)))), ((int)(((byte)(251)))));
            this.btnPanel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(243)))), ((int)(((byte)(251)))));
            this.btnPanel.Location = new System.Drawing.Point(309, 2);
            this.btnPanel.Click += new System.EventHandler(this.btnPanel_Click);
            // 
            // spcBase
            // 
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
            this.pnlCrud.Paint += new System.Windows.Forms.PaintEventHandler(this.panel5_Paint);
            // 
            // txtSearch
            // 
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // btnInsert
            // 
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnClose
            // 
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReadBottom
            // 
            this.btnReadBottom.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // btnUpdate
            // 
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
            // pgGrid
            // 
            this.pgGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgGrid.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pgGrid.HelpVisible = false;
            this.pgGrid.Location = new System.Drawing.Point(0, 0);
            this.pgGrid.Name = "pgGrid";
            this.pgGrid.Size = new System.Drawing.Size(362, 631);
            this.pgGrid.TabIndex = 22;
            this.pgGrid.ToolbarVisible = false;
            this.pgGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.pgGrid_PropertyValueChanged);
            // 
            // pgSearch
            // 
            this.pgSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgSearch.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pgSearch.HelpVisible = false;
            this.pgSearch.Location = new System.Drawing.Point(0, 0);
            this.pgSearch.Name = "pgSearch";
            this.pgSearch.Size = new System.Drawing.Size(362, 631);
            this.pgSearch.TabIndex = 23;
            this.pgSearch.ToolbarVisible = false;
            this.pgSearch.Click += new System.EventHandler(this.Search_Grid_Click);
            // 
            // csDataGridView1
            // 
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(239)))), ((int)(((byte)(247)))));
            this.csDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle17;
            this.csDataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.csDataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(243)))), ((int)(((byte)(251)))));
            this.csDataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
            dataGridViewCellStyle18.Font = new System.Drawing.Font("나눔고딕", 10F);
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.csDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.csDataGridView1.ColumnHeadersHeight = 45;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("나눔고딕", 10F);
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(195)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.csDataGridView1.DefaultCellStyle = dataGridViewCellStyle19;
            this.csDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.csDataGridView1.EnableHeadersVisualStyles = false;
            this.csDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.csDataGridView1.Name = "csDataGridView1";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.csDataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.csDataGridView1.RowHeadersWidth = 30;
            this.csDataGridView1.Size = new System.Drawing.Size(794, 578);
            this.csDataGridView1.TabIndex = 0;
            this.csDataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.csDataGridView1_CellClick);
            this.csDataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.csDataGridView1_CellContentClick);
            // 
            // frmINSPECT_MST
            // 
            this.BIsSearchPanel = true;
            this.BPropertyPanel = true;
            this.BSearchPanel = true;
            this.ClientSize = new System.Drawing.Size(1168, 778);
            this.Name = "frmINSPECT_MST";
            this.Load += new System.EventHandler(this.frmINSPECT_MST_Load);
            this.Shown += new System.EventHandler(this.frmINSPECT_MST_Shown);
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

        private System.Windows.Forms.PropertyGrid pgGrid;
        private System.Windows.Forms.PropertyGrid pgSearch;
		private csDataGridView csDataGridView1;
	}
}
