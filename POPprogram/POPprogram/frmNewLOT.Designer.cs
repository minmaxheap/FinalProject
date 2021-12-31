
namespace POPprogram
{
    partial class frmNewLOT
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
            System.Windows.Forms.Button btnTxtSearch;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewLOT));
            btnTxtSearch = new System.Windows.Forms.Button();
            this.panel4.SuspendLayout();
            this.panel8.SuspendLayout();
            this.pnlCrud.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel8
            // 
            this.panel8.Controls.Add(btnTxtSearch);
            this.panel8.Controls.SetChildIndex(this.label6, 0);
            this.panel8.Controls.SetChildIndex(this.textBox2, 0);
            this.panel8.Controls.SetChildIndex(this.textBox3, 0);
            this.panel8.Controls.SetChildIndex(this.textBox4, 0);
            this.panel8.Controls.SetChildIndex(this.textBox5, 0);
            this.panel8.Controls.SetChildIndex(this.label2, 0);
            this.panel8.Controls.SetChildIndex(this.label3, 0);
            this.panel8.Controls.SetChildIndex(btnTxtSearch, 0);
            // 
            // btnTxtSearch
            // 
            btnTxtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(194)))), ((int)(((byte)(229)))));
            btnTxtSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTxtSearch.BackgroundImage")));
            btnTxtSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            btnTxtSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            btnTxtSearch.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            btnTxtSearch.ForeColor = System.Drawing.SystemColors.ControlText;
            btnTxtSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            btnTxtSearch.Location = new System.Drawing.Point(482, 54);
            btnTxtSearch.Margin = new System.Windows.Forms.Padding(0);
            btnTxtSearch.Name = "btnTxtSearch";
            btnTxtSearch.Size = new System.Drawing.Size(32, 26);
            btnTxtSearch.TabIndex = 50;
            btnTxtSearch.UseVisualStyleBackColor = false;
            // 
            // frmNewLOT
            // 
            this.ClientSize = new System.Drawing.Size(1194, 634);
            this.Name = "frmNewLOT";
            this.Load += new System.EventHandler(this.frmNewLot1_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.pnlCrud.ResumeLayout(false);
            this.pnlCrud.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
