﻿
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
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
			this.lblTitle.Text = "검사항목";
			// 
			// pnlProperty
			// 
			this.pnlProperty.Controls.Add(this.pgGrid);
			this.pnlProperty.Location = new System.Drawing.Point(3, 47);
			// 
			// pnlSearch
			// 
			this.pnlSearch.Controls.Add(this.pgSearch);
			// 
			// btnPanel
			// 
			this.btnPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(152)))), ((int)(((byte)(216)))));
			this.btnPanel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
			this.btnPanel.FlatAppearance.BorderSize = 0;
			this.btnPanel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(243)))), ((int)(((byte)(251)))));
			this.btnPanel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(243)))), ((int)(((byte)(251)))));
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
			// btnReadBottom
			// 
			this.btnReadBottom.Click += new System.EventHandler(this.btnRead_Click);
			// 
			// btnUpdate
			// 
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			// 
			// btnTxtSearch
			// 
			this.btnTxtSearch.Click += new System.EventHandler(this.btnTxtSearch_Click);
			// 
			// pgGrid
			// 
			this.pgGrid.HelpVisible = false;
			this.pgGrid.Location = new System.Drawing.Point(4, 2);
			this.pgGrid.Name = "pgGrid";
			this.pgGrid.Size = new System.Drawing.Size(358, 562);
			this.pgGrid.TabIndex = 22;
			this.pgGrid.ToolbarVisible = false;
			this.pgGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.pgGrid_PropertyValueChanged);
			// 
			// pgSearch
			// 
			this.pgSearch.HelpVisible = false;
			this.pgSearch.Location = new System.Drawing.Point(4, 2);
			this.pgSearch.Name = "pgSearch";
			this.pgSearch.Size = new System.Drawing.Size(358, 562);
			this.pgSearch.TabIndex = 23;
			this.pgSearch.ToolbarVisible = false;
			this.pgSearch.Click += new System.EventHandler(this.Search_Grid_Click);
			// 
			// csDataGridView1
			// 
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(239)))), ((int)(((byte)(247)))));
			this.csDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.csDataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(243)))), ((int)(((byte)(251)))));
			this.csDataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
			dataGridViewCellStyle2.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.csDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.csDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
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
			this.csDataGridView1.RowTemplate.Height = 23;
			this.csDataGridView1.Size = new System.Drawing.Size(797, 622);
			this.csDataGridView1.TabIndex = 0;
			this.csDataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.csDataGridView1_CellDoubleClick);
			// 
			// frmINSPECT_MST
			// 
			this.BIsSearchPanel = true;
			this.BPropertyPanel = true;
			this.BSearchPanel = true;
			this.ClientSize = new System.Drawing.Size(1168, 778);
			this.Name = "frmINSPECT_MST";
			this.Load += new System.EventHandler(this.frmINSPECT_MST_Load);
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
