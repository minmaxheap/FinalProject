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
			this.pgGrid = new System.Windows.Forms.PropertyGrid();
			this.pgSearch = new System.Windows.Forms.PropertyGrid();
			this.panel6.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.panel4.SuspendLayout();
			this.SuspendLayout();
			this.panel3.Controls.SetChildIndex(this.textBox1, 0);
			this.panel3.Controls.SetChildIndex(this.button3, 0);
			// 
			// lblTitle
			// 
			this.lblTitle.Text = "검사항목";
			// 
			// propertyPanel
			// 
			this.propertyPanel.Location = new System.Drawing.Point(3, 47);
			// 
			// splitContainer1
			// 
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.pgGrid);
			this.panel4.Controls.Add(this.pgSearch);
			// 
			// pgGrid
			// 
			this.pgGrid.HelpVisible = false;
			this.pgGrid.Location = new System.Drawing.Point(381, 6);
			this.pgGrid.Name = "pgGrid";
			this.pgGrid.Size = new System.Drawing.Size(358, 562);
			this.pgGrid.TabIndex = 22;
			this.pgGrid.ToolbarVisible = false;
			// 
			// pgSearch
			// 
			this.pgSearch.HelpVisible = false;
			this.pgSearch.Location = new System.Drawing.Point(-17, 10);
			this.pgSearch.Name = "pgSearch";
			this.pgSearch.Size = new System.Drawing.Size(358, 562);
			this.pgSearch.TabIndex = 23;
			this.pgSearch.ToolbarVisible = false;
			this.pgSearch.Click += new System.EventHandler(this.Search_Grid_Click);
			// 
			// frmINSPECT_MST
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.ClientSize = new System.Drawing.Size(1168, 778);
			this.Name = "frmINSPECT_MST";
			this.PropertyPanel = true;
			this.SearchPanel = true;
			this.Load += new System.EventHandler(this.frmINSPECT_MST_Load);
			this.panel6.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid pgGrid;
        private System.Windows.Forms.PropertyGrid pgSearch;
    }
}
