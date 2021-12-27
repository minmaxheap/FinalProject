
namespace MES_Team3
{
    partial class frmProductOperRelation
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
            this.SuspendLayout();
            this.panel3.Controls.SetChildIndex(this.txtSearch, 0);
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
            // pgSearch
            // 
            this.pgSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgSearch.HelpVisible = false;
            this.pgSearch.Location = new System.Drawing.Point(-3, 4);
            this.pgSearch.Name = "pgSearch";
            this.pgSearch.Size = new System.Drawing.Size(358, 552);
            this.pgSearch.TabIndex = 4;
            this.pgSearch.ToolbarVisible = false;
            // 
            // pgProperty
            // 
            this.pgProperty.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgProperty.HelpVisible = false;
            this.pgProperty.Location = new System.Drawing.Point(0, -1);
            this.pgProperty.Name = "pgProperty";
            this.pgProperty.Size = new System.Drawing.Size(358, 552);
            this.pgProperty.TabIndex = 5;
            this.pgProperty.ToolbarVisible = false;
            // 
            // frmProductOperRelation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(1168, 778);
            this.Name = "frmProductOperRelation";
            this.PropertyPanel = true;
            this.SearchPanel = true;
            this.Load += new System.EventHandler(this.frmProductOperRelation_Load);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid pgSearch;
        private System.Windows.Forms.PropertyGrid pgProperty;
    }
}
