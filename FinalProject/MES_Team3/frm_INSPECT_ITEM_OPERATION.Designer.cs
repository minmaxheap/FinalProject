
namespace MES_Team3
{
	partial class frm_INSPECT_ITEM_OPERATION
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			this.csDataGridView1 = new MES_Team3.csDataGridView();
			this.csDataGridView2 = new MES_Team3.csDataGridView();
			this.csDataGridView3 = new MES_Team3.csDataGridView();
			this.pgdSearch = new System.Windows.Forms.PropertyGrid();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.pnlDgv.SuspendLayout();
			this.pnlAll.SuspendLayout();
			this.pnlSearch.SuspendLayout();
			this.pnlTopLbl.SuspendLayout();
			this.pnlTop.SuspendLayout();
			this.pnlCrud.SuspendLayout();
			this.pnlAdd.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.csDataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.csDataGridView2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.csDataGridView3)).BeginInit();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			// 
			// splitContainer2
			// 
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer2_Panel1_Paint);
			// 
			// pnlDgv
			// 
			this.pnlDgv.Controls.Add(this.csDataGridView1);
			this.pnlDgv.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlDgv_Paint);
			this.pnlDgv.Controls.SetChildIndex(this.lblTitle, 0);
			this.pnlDgv.Controls.SetChildIndex(this.csDataGridView1, 0);
			// 
			// pnlAll
			// 
			this.pnlAll.Controls.Add(this.csDataGridView3);
			this.pnlAll.Controls.SetChildIndex(this.lblAll, 0);
			this.pnlAll.Controls.SetChildIndex(this.csDataGridView3, 0);
			// 
			// pnlSearch
			// 
			this.pnlSearch.Controls.Add(this.pgdSearch);
			this.pnlTop.Controls.SetChildIndex(this.btnSearchPnl, 0);
			this.pnlTop.Controls.SetChildIndex(this.txtSearch, 0);
			// 
			// btnReadBottom
			// 
			this.btnReadBottom.Click += new System.EventHandler(this.btnReadBottom_Click);
			// 
			// pnlAdd
			// 
			this.pnlAdd.Controls.Add(this.csDataGridView2);
			this.pnlAdd.Controls.SetChildIndex(this.lblAdd, 0);
			this.pnlAdd.Controls.SetChildIndex(this.csDataGridView2, 0);
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
			this.csDataGridView1.Location = new System.Drawing.Point(0, 31);
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
			this.csDataGridView1.Size = new System.Drawing.Size(754, 230);
			this.csDataGridView1.TabIndex = 18;
			this.csDataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.csDataGridView1_CellContentClick);
			// 
			// csDataGridView2
			// 
			dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(239)))), ((int)(((byte)(247)))));
			this.csDataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
			this.csDataGridView2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(243)))), ((int)(((byte)(251)))));
			this.csDataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
			dataGridViewCellStyle10.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
			dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.csDataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
			this.csDataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle11.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			dataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
			dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(195)))), ((int)(((byte)(230)))));
			dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.csDataGridView2.DefaultCellStyle = dataGridViewCellStyle11;
			this.csDataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.csDataGridView2.EnableHeadersVisualStyles = false;
			this.csDataGridView2.Location = new System.Drawing.Point(0, 31);
			this.csDataGridView2.Name = "csDataGridView2";
			dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle12.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
			dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.csDataGridView2.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
			this.csDataGridView2.RowHeadersWidth = 30;
			this.csDataGridView2.RowTemplate.Height = 23;
			this.csDataGridView2.Size = new System.Drawing.Size(325, 220);
			this.csDataGridView2.TabIndex = 18;
			// 
			// csDataGridView3
			// 
			dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(239)))), ((int)(((byte)(247)))));
			this.csDataGridView3.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
			this.csDataGridView3.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(243)))), ((int)(((byte)(251)))));
			this.csDataGridView3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
			dataGridViewCellStyle6.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
			dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.csDataGridView3.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
			this.csDataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle7.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
			dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(195)))), ((int)(((byte)(230)))));
			dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.csDataGridView3.DefaultCellStyle = dataGridViewCellStyle7;
			this.csDataGridView3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.csDataGridView3.EnableHeadersVisualStyles = false;
			this.csDataGridView3.Location = new System.Drawing.Point(0, 31);
			this.csDataGridView3.Name = "csDataGridView3";
			dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle8.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
			dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.csDataGridView3.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
			this.csDataGridView3.RowHeadersWidth = 30;
			this.csDataGridView3.RowTemplate.Height = 23;
			this.csDataGridView3.Size = new System.Drawing.Size(420, 209);
			this.csDataGridView3.TabIndex = 19;
			// 
			// pgdSearch
			// 
			this.pgdSearch.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pgdSearch.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.pgdSearch.HelpVisible = false;
			this.pgdSearch.Location = new System.Drawing.Point(0, 0);
			this.pgdSearch.Name = "pgdSearch";
			this.pgdSearch.Size = new System.Drawing.Size(403, 302);
			this.pgdSearch.TabIndex = 1;
			this.pgdSearch.ToolbarVisible = false;
			// 
			// frm_INSPECT_ITEM_OPERATION
			// 
			this.ClientSize = new System.Drawing.Size(1168, 667);
			this.Name = "frm_INSPECT_ITEM_OPERATION";
			this.Load += new System.EventHandler(this.frm_INSPECT_ITEM_OPERATION_Load);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			this.pnlDgv.ResumeLayout(false);
			this.pnlAll.ResumeLayout(false);
			this.pnlSearch.ResumeLayout(false);
			this.pnlTopLbl.ResumeLayout(false);
			this.pnlTop.ResumeLayout(false);
			this.pnlTop.PerformLayout();
			this.pnlCrud.ResumeLayout(false);
			this.pnlAdd.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.csDataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.csDataGridView2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.csDataGridView3)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private csDataGridView csDataGridView1;
		private csDataGridView csDataGridView3;
		private csDataGridView csDataGridView2;
		private System.Windows.Forms.PropertyGrid pgdSearch;
	}
}
