
namespace MES_Team3
{
    partial class Sales_Order
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.csDataGridView1 = new MES_Team3.csDataGridView();
            this.pgSearch = new System.Windows.Forms.PropertyGrid();
            this.pgProperty = new System.Windows.Forms.PropertyGrid();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.propertyPanel.SuspendLayout();
            this.searchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.csDataGridView1)).BeginInit();
            this.SuspendLayout();
            this.panel3.Controls.SetChildIndex(this.textBox1, 0);
            this.panel3.Controls.SetChildIndex(this.button3, 0);
            // 
            // propertyPanel
            // 
            this.propertyPanel.Controls.Add(this.pgProperty);
            // 
            // searchPanel
            // 
            this.searchPanel.Controls.Add(this.pgSearch);
            // 
            // splitContainer1
            // 
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.csDataGridView1);
            // 
            // csDataGridView1
            // 
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(239)))), ((int)(((byte)(247)))));
            this.csDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle21;
            this.csDataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(243)))), ((int)(((byte)(251)))));
            this.csDataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.csDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.csDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(195)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.csDataGridView1.DefaultCellStyle = dataGridViewCellStyle23;
            this.csDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.csDataGridView1.EnableHeadersVisualStyles = false;
            this.csDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.csDataGridView1.Name = "csDataGridView1";
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.csDataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.csDataGridView1.RowHeadersWidth = 30;
            this.csDataGridView1.Size = new System.Drawing.Size(771, 575);
            this.csDataGridView1.TabIndex = 0;
            // 
            // pgSearch
            // 
            this.pgSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgSearch.HelpVisible = false;
            this.pgSearch.Location = new System.Drawing.Point(0, 5);
            this.pgSearch.Name = "pgSearch";
            this.pgSearch.Size = new System.Drawing.Size(358, 548);
            this.pgSearch.TabIndex = 4;
            this.pgSearch.ToolbarVisible = false;
            // 
            // pgProperty
            // 
            this.pgProperty.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgProperty.HelpVisible = false;
            this.pgProperty.Location = new System.Drawing.Point(0, 2);
            this.pgProperty.Name = "pgProperty";
            this.pgProperty.Size = new System.Drawing.Size(358, 559);
            this.pgProperty.TabIndex = 5;
            this.pgProperty.ToolbarVisible = false;
            // 
            // 상
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(1168, 778);
            this.Name = "상";
            this.PropertyPanel = true;
            this.SearchPanel = true;
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.propertyPanel.ResumeLayout(false);
            this.searchPanel.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.csDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private csDataGridView csDataGridView1;
        private System.Windows.Forms.PropertyGrid pgSearch;
        private System.Windows.Forms.PropertyGrid pgProperty;
    }
}
