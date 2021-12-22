
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
			this.Property_Grid = new System.Windows.Forms.PropertyGrid();
			this.Search_Grid = new System.Windows.Forms.PropertyGrid();
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
			this.panel3.Controls.SetChildIndex(this.textBox1, 0);
			this.panel3.Controls.SetChildIndex(this.button3, 0);
			// 
			// propertyPanel
			// 
			this.propertyPanel.Controls.Add(this.Property_Grid);
			// 
			// searchPanel
			// 
			this.searchPanel.Controls.Add(this.Search_Grid);
			// 
			// splitContainer1
			// 
			// 
			// Property_Grid
			// 
			this.Property_Grid.HelpVisible = false;
			this.Property_Grid.Location = new System.Drawing.Point(0, 2);
			this.Property_Grid.Name = "Property_Grid";
			this.Property_Grid.Size = new System.Drawing.Size(358, 482);
			this.Property_Grid.TabIndex = 20;
			this.Property_Grid.ToolbarVisible = false;
			// 
			// Search_Grid
			// 
			this.Search_Grid.HelpVisible = false;
			this.Search_Grid.Location = new System.Drawing.Point(0, -3);
			this.Search_Grid.Name = "Search_Grid";
			this.Search_Grid.Size = new System.Drawing.Size(358, 482);
			this.Search_Grid.TabIndex = 21;
			this.Search_Grid.ToolbarVisible = false;
			// 
			// frmINSPECT_MST
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.ClientSize = new System.Drawing.Size(1168, 667);
			this.Name = "frmINSPECT_MST";
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

		private System.Windows.Forms.PropertyGrid Property_Grid;
		private System.Windows.Forms.PropertyGrid Search_Grid;
	}
}
