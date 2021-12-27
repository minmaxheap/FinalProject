
namespace MES_Team3
{
    partial class frmProcessTest1
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
            this.pgProperty = new System.Windows.Forms.PropertyGrid();
            this.pgSearch = new System.Windows.Forms.PropertyGrid();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
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
            // panel4
            // 
            this.panel4.Size = new System.Drawing.Size(880, 655);
            // 
            // label1
            // 
            //this.label1.Size = new System.Drawing.Size(878, 39);
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
            this.splitContainer1.SplitterDistance = 880;
            // 
            // pgProperty
            // 
            this.pgProperty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgProperty.HelpVisible = false;
            this.pgProperty.Location = new System.Drawing.Point(0, 0);
            this.pgProperty.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pgProperty.Name = "pgProperty";
            this.pgProperty.Size = new System.Drawing.Size(409, 602);
            this.pgProperty.TabIndex = 18;
            this.pgProperty.ToolbarVisible = false;
            // 
            // pgSearch
            // 
            this.pgSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgSearch.HelpVisible = false;
            this.pgSearch.Location = new System.Drawing.Point(0, 0);
            this.pgSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pgSearch.Name = "pgSearch";
            this.pgSearch.Size = new System.Drawing.Size(409, 602);
            this.pgSearch.TabIndex = 19;
            this.pgSearch.ToolbarVisible = false;
            // 
            // frmProcessTest1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.ClientSize = new System.Drawing.Size(1335, 834);
            this.Name = "frmProcessTest1";
            this.PropertyPanel = true;
            this.SearchPanel = true;
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.propertyPanel.ResumeLayout(false);
            this.searchPanel.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid pgProperty;
        private System.Windows.Forms.PropertyGrid pgSearch;
    }
}
