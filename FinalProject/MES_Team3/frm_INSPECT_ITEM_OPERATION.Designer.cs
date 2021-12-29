
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
			this.csDataGridView1 = new MES_Team3.csDataGridView();
			this.csDataGridView2 = new MES_Team3.csDataGridView();
			this.csDataGridView3 = new MES_Team3.csDataGridView();
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
			this.pnlTop.Controls.SetChildIndex(this.btnSearchPnl, 0);
			this.pnlTop.Controls.SetChildIndex(this.txtSearch, 0);
			// 
			// pnlAdd
			// 
			this.pnlAdd.Controls.Add(this.csDataGridView2);
			this.pnlAdd.Controls.SetChildIndex(this.lblAdd, 0);
			this.pnlAdd.Controls.SetChildIndex(this.csDataGridView2, 0);
			// 
			// csDataGridView1
			// 
			dataGridViewCellStyle25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(239)))), ((int)(((byte)(247)))));
			this.csDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle25;
			this.csDataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(243)))), ((int)(((byte)(251)))));
			this.csDataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
			dataGridViewCellStyle26.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			dataGridViewCellStyle26.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle26.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
			dataGridViewCellStyle26.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.csDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle26;
			this.csDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle27.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle27.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			dataGridViewCellStyle27.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
			dataGridViewCellStyle27.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(195)))), ((int)(((byte)(230)))));
			dataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.csDataGridView1.DefaultCellStyle = dataGridViewCellStyle27;
			this.csDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.csDataGridView1.EnableHeadersVisualStyles = false;
			this.csDataGridView1.Location = new System.Drawing.Point(0, 31);
			this.csDataGridView1.Name = "csDataGridView1";
			dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle28.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle28.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			dataGridViewCellStyle28.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle28.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
			dataGridViewCellStyle28.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.csDataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle28;
			this.csDataGridView1.RowHeadersWidth = 30;
			this.csDataGridView1.RowTemplate.Height = 23;
			this.csDataGridView1.Size = new System.Drawing.Size(754, 230);
			this.csDataGridView1.TabIndex = 18;
			this.csDataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.csDataGridView1_CellContentClick);
			// 
			// csDataGridView2
			// 
			dataGridViewCellStyle33.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(239)))), ((int)(((byte)(247)))));
			this.csDataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle33;
			this.csDataGridView2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(243)))), ((int)(((byte)(251)))));
			this.csDataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			dataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
			dataGridViewCellStyle34.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			dataGridViewCellStyle34.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle34.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
			dataGridViewCellStyle34.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle34.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.csDataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle34;
			this.csDataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle35.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle35.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			dataGridViewCellStyle35.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
			dataGridViewCellStyle35.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(195)))), ((int)(((byte)(230)))));
			dataGridViewCellStyle35.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle35.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.csDataGridView2.DefaultCellStyle = dataGridViewCellStyle35;
			this.csDataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.csDataGridView2.EnableHeadersVisualStyles = false;
			this.csDataGridView2.Location = new System.Drawing.Point(0, 31);
			this.csDataGridView2.Name = "csDataGridView2";
			dataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle36.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle36.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			dataGridViewCellStyle36.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle36.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
			dataGridViewCellStyle36.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle36.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.csDataGridView2.RowHeadersDefaultCellStyle = dataGridViewCellStyle36;
			this.csDataGridView2.RowHeadersWidth = 30;
			this.csDataGridView2.RowTemplate.Height = 23;
			this.csDataGridView2.Size = new System.Drawing.Size(325, 220);
			this.csDataGridView2.TabIndex = 18;
			// 
			// csDataGridView3
			// 
			dataGridViewCellStyle29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(239)))), ((int)(((byte)(247)))));
			this.csDataGridView3.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle29;
			this.csDataGridView3.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(243)))), ((int)(((byte)(251)))));
			this.csDataGridView3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
			dataGridViewCellStyle30.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			dataGridViewCellStyle30.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle30.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
			dataGridViewCellStyle30.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle30.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.csDataGridView3.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle30;
			this.csDataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle31.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle31.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			dataGridViewCellStyle31.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
			dataGridViewCellStyle31.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(195)))), ((int)(((byte)(230)))));
			dataGridViewCellStyle31.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle31.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.csDataGridView3.DefaultCellStyle = dataGridViewCellStyle31;
			this.csDataGridView3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.csDataGridView3.EnableHeadersVisualStyles = false;
			this.csDataGridView3.Location = new System.Drawing.Point(0, 31);
			this.csDataGridView3.Name = "csDataGridView3";
			dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle32.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle32.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			dataGridViewCellStyle32.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle32.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
			dataGridViewCellStyle32.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle32.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.csDataGridView3.RowHeadersDefaultCellStyle = dataGridViewCellStyle32;
			this.csDataGridView3.RowHeadersWidth = 30;
			this.csDataGridView3.RowTemplate.Height = 23;
			this.csDataGridView3.Size = new System.Drawing.Size(420, 209);
			this.csDataGridView3.TabIndex = 19;
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
	}
}
