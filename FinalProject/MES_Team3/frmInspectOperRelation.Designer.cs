
namespace MES_Team3
{
    partial class frmInspectOperRelation
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
			this.csDataGridView1 = new MES_Team3.csDataGridView();
			this.csDataGridView2 = new MES_Team3.csDataGridView();
			this.label1 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.csDataGridView3 = new MES_Team3.csDataGridView();
			this.pgSearch = new System.Windows.Forms.PropertyGrid();
			this.pnlTop.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.spcBase)).BeginInit();
			this.spcBase.Panel1.SuspendLayout();
			this.spcBase.Panel2.SuspendLayout();
			this.spcBase.SuspendLayout();
			this.pnlDgv.SuspendLayout();
			this.pnlSearch.SuspendLayout();
			this.pnlAll.SuspendLayout();
			this.pnlCrud.SuspendLayout();
			this.pnlAdd.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.csDataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.csDataGridView2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.csDataGridView3)).BeginInit();
			this.SuspendLayout();
			// 
			// spcBase
			// 
			// 
			// pnlDgv
			// 
			this.pnlDgv.Controls.Add(this.csDataGridView1);
			this.pnlDgv.Controls.SetChildIndex(this.lblTitle, 0);
			this.pnlDgv.Controls.SetChildIndex(this.csDataGridView1, 0);
			// 
			// lblTitle
			// 
			this.lblTitle.Text = "공정 목록";
			// 
			// pnlSearch
			// 
			this.pnlSearch.Controls.Add(this.pgSearch);
			// 
			// pnlAll
			// 
			this.pnlAll.Controls.Add(this.csDataGridView3);
			this.pnlAll.Controls.Add(this.comboBox1);
			this.pnlAll.Controls.Add(this.label1);
			this.pnlAll.Controls.SetChildIndex(this.lblAll, 0);
			this.pnlAll.Controls.SetChildIndex(this.label1, 0);
			this.pnlAll.Controls.SetChildIndex(this.comboBox1, 0);
			this.pnlAll.Controls.SetChildIndex(this.csDataGridView3, 0);
			// 
			// btnReadBottom
			// 
			this.btnReadBottom.Click += new System.EventHandler(this.btnReadBottom_Click_1);
			// 
			// pnlAdd
			// 
			this.pnlAdd.Controls.Add(this.csDataGridView2);
			this.pnlAdd.Controls.SetChildIndex(this.csDataGridView2, 0);
			this.pnlAdd.Controls.SetChildIndex(this.lblAdd, 0);
			// 
			// btnReadTop
			// 
			this.btnReadTop.Click += new System.EventHandler(this.btnReadTop_Click);
			// 
			// btnSubtract
			// 
			this.btnSubtract.Click += new System.EventHandler(this.btnSubtract_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// csDataGridView1
			// 
			dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(239)))), ((int)(((byte)(247)))));
			this.csDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
			this.csDataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(243)))), ((int)(((byte)(251)))));
			this.csDataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
			dataGridViewCellStyle14.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			dataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
			dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.csDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
			this.csDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle15.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			dataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
			dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(195)))), ((int)(((byte)(230)))));
			dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.csDataGridView1.DefaultCellStyle = dataGridViewCellStyle15;
			this.csDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.csDataGridView1.EnableHeadersVisualStyles = false;
			this.csDataGridView1.Location = new System.Drawing.Point(0, 36);
			this.csDataGridView1.Name = "csDataGridView1";
			dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle16.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
			dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.csDataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle16;
			this.csDataGridView1.RowHeadersWidth = 30;
			this.csDataGridView1.RowTemplate.Height = 23;
			this.csDataGridView1.Size = new System.Drawing.Size(724, 231);
			this.csDataGridView1.TabIndex = 19;
			this.csDataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.csDataGridView1_CellContentClick);
			this.csDataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.csDataGridView1_CellDoubleClick);
			// 
			// csDataGridView2
			// 
			dataGridViewCellStyle21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(239)))), ((int)(((byte)(247)))));
			this.csDataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle21;
			this.csDataGridView2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(243)))), ((int)(((byte)(251)))));
			this.csDataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
			dataGridViewCellStyle22.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			dataGridViewCellStyle22.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle22.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
			dataGridViewCellStyle22.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.csDataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
			this.csDataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle23.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle23.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			dataGridViewCellStyle23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
			dataGridViewCellStyle23.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(195)))), ((int)(((byte)(230)))));
			dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.csDataGridView2.DefaultCellStyle = dataGridViewCellStyle23;
			this.csDataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.csDataGridView2.EnableHeadersVisualStyles = false;
			this.csDataGridView2.Location = new System.Drawing.Point(0, 0);
			this.csDataGridView2.Name = "csDataGridView2";
			dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle24.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
			dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.csDataGridView2.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
			this.csDataGridView2.RowHeadersWidth = 30;
			this.csDataGridView2.RowTemplate.Height = 23;
			this.csDataGridView2.Size = new System.Drawing.Size(514, 315);
			this.csDataGridView2.TabIndex = 20;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label1.Location = new System.Drawing.Point(82, 43);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 19);
			this.label1.TabIndex = 18;
			this.label1.Text = "값 유형";
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(159, 44);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(235, 22);
			this.comboBox1.TabIndex = 19;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
			// 
			// csDataGridView3
			// 
			dataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(239)))), ((int)(((byte)(247)))));
			this.csDataGridView3.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle17;
			this.csDataGridView3.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(243)))), ((int)(((byte)(251)))));
			this.csDataGridView3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
			dataGridViewCellStyle18.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			dataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
			dataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.csDataGridView3.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle18;
			this.csDataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle19.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle19.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			dataGridViewCellStyle19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
			dataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(195)))), ((int)(((byte)(230)))));
			dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.csDataGridView3.DefaultCellStyle = dataGridViewCellStyle19;
			this.csDataGridView3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.csDataGridView3.EnableHeadersVisualStyles = false;
			this.csDataGridView3.Location = new System.Drawing.Point(0, 75);
			this.csDataGridView3.Name = "csDataGridView3";
			dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle20.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
			dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.csDataGridView3.RowHeadersDefaultCellStyle = dataGridViewCellStyle20;
			this.csDataGridView3.RowHeadersWidth = 30;
			this.csDataGridView3.RowTemplate.Height = 23;
			this.csDataGridView3.Size = new System.Drawing.Size(501, 240);
			this.csDataGridView3.TabIndex = 20;
			// 
			// pgSearch
			// 
			this.pgSearch.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pgSearch.HelpVisible = false;
			this.pgSearch.Location = new System.Drawing.Point(0, 0);
			this.pgSearch.Name = "pgSearch";
			this.pgSearch.Size = new System.Drawing.Size(416, 265);
			this.pgSearch.TabIndex = 27;
			this.pgSearch.ToolbarVisible = false;
			// 
			// frmInspectOperRelation
			// 
			this.ClientSize = new System.Drawing.Size(1152, 739);
			this.Name = "frmInspectOperRelation";
			this.Load += new System.EventHandler(this.frmInspectOperRelation_Load);
			this.pnlTop.ResumeLayout(false);
			this.pnlTop.PerformLayout();
			this.spcBase.Panel1.ResumeLayout(false);
			this.spcBase.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.spcBase)).EndInit();
			this.spcBase.ResumeLayout(false);
			this.pnlDgv.ResumeLayout(false);
			this.pnlSearch.ResumeLayout(false);
			this.pnlAll.ResumeLayout(false);
			this.pnlAll.PerformLayout();
			this.pnlCrud.ResumeLayout(false);
			this.pnlAdd.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.csDataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.csDataGridView2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.csDataGridView3)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion
        private csDataGridView csDataGridView1;
		private csDataGridView csDataGridView3;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label1;
		private csDataGridView csDataGridView2;
		private System.Windows.Forms.PropertyGrid pgSearch;
	}
}
