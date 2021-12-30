
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
            System.Windows.Forms.Button btnSearch;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewLOT));
            btnSearch = new System.Windows.Forms.Button();
            this.panel4.SuspendLayout();
            this.panel8.SuspendLayout();
            this.pnlCrud.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel8
            // 
            this.panel8.Controls.Add(btnSearch);
            this.panel8.Controls.SetChildIndex(this.label6, 0);
            this.panel8.Controls.SetChildIndex(this.textBox2, 0);
            this.panel8.Controls.SetChildIndex(this.textBox3, 0);
            this.panel8.Controls.SetChildIndex(this.textBox4, 0);
            this.panel8.Controls.SetChildIndex(this.textBox5, 0);
            this.panel8.Controls.SetChildIndex(this.label2, 0);
            this.panel8.Controls.SetChildIndex(this.label3, 0);
            this.panel8.Controls.SetChildIndex(btnSearch, 0);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(97, 116);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(122, 69);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(122, 299);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(122, 244);
            this.label11.Size = new System.Drawing.Size(64, 31);
            this.label11.Text = "수량";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(122, 189);
            this.label12.Text = "공정";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(122, 134);
            this.label9.Size = new System.Drawing.Size(64, 31);
            this.label9.Text = "품번";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(30, 79);
            this.label10.Size = new System.Drawing.Size(156, 31);
            this.label10.Text = "생산 LOT ID";
            // 
            // btnClose
            // 
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label17
            // 
            this.label17.Text = "100";
            // 
            // btnSearch
            // 
            btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            btnSearch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(194)))), ((int)(((byte)(229)))));
            btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            btnSearch.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            btnSearch.ForeColor = System.Drawing.SystemColors.ControlText;
            btnSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            btnSearch.Location = new System.Drawing.Point(482, 65);
            btnSearch.Margin = new System.Windows.Forms.Padding(0);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(39, 32);
            btnSearch.TabIndex = 50;
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // frmNewLOT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(1373, 807);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmNewLOT";
            this.Load += new System.EventHandler(this.frmNewLOT_Load);
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
