
namespace POPprogram
{
    partial class frmLOTDefect
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.numTextBox1 = new POPprogram.NumTextBox();
            this.numTextBox2 = new POPprogram.NumTextBox();
            this.numTextBox3 = new POPprogram.NumTextBox();
            this.numTextBox4 = new POPprogram.NumTextBox();
            this.numTextBox5 = new POPprogram.NumTextBox();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnlCrud.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.numTextBox5);
            this.panel4.Controls.Add(this.numTextBox4);
            this.panel4.Controls.Add(this.numTextBox3);
            this.panel4.Controls.Add(this.numTextBox2);
            this.panel4.Controls.Add(this.numTextBox1);
            this.panel4.Controls.Add(this.label25);
            this.panel4.Controls.Add(this.label20);
            this.panel4.Controls.Add(this.label19);
            this.panel4.Controls.Add(this.label24);
            this.panel4.Controls.Add(this.comboBox3);
            this.panel4.Controls.Add(this.label23);
            this.panel4.Controls.Add(this.comboBox2);
            this.panel4.Controls.Add(this.label21);
            this.panel4.Controls.Add(this.label18);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.comboBox1);
            this.panel4.Size = new System.Drawing.Size(1136, 262);
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            this.panel4.Controls.SetChildIndex(this.comboBox1, 0);
            this.panel4.Controls.SetChildIndex(this.txtComment, 0);
            this.panel4.Controls.SetChildIndex(this.label13, 0);
            this.panel4.Controls.SetChildIndex(this.label1, 0);
            this.panel4.Controls.SetChildIndex(this.label12, 0);
            this.panel4.Controls.SetChildIndex(this.label18, 0);
            this.panel4.Controls.SetChildIndex(this.label21, 0);
            this.panel4.Controls.SetChildIndex(this.comboBox2, 0);
            this.panel4.Controls.SetChildIndex(this.label23, 0);
            this.panel4.Controls.SetChildIndex(this.comboBox3, 0);
            this.panel4.Controls.SetChildIndex(this.label24, 0);
            this.panel4.Controls.SetChildIndex(this.label19, 0);
            this.panel4.Controls.SetChildIndex(this.label20, 0);
            this.panel4.Controls.SetChildIndex(this.label25, 0);
            this.panel4.Controls.SetChildIndex(this.numTextBox1, 0);
            this.panel4.Controls.SetChildIndex(this.numTextBox2, 0);
            this.panel4.Controls.SetChildIndex(this.numTextBox3, 0);
            this.panel4.Controls.SetChildIndex(this.numTextBox4, 0);
            this.panel4.Controls.SetChildIndex(this.numTextBox5, 0);
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label13.Location = new System.Drawing.Point(102, 205);
            // 
            // txtComment
            // 
            this.txtComment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment.Location = new System.Drawing.Point(165, 207);
            // 
            // pnlCrud
            // 
            this.pnlCrud.Location = new System.Drawing.Point(499, 788);
            // 
            // btnClose
            // 
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(370, 0);
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // cboLOTID
            // 
            this.cboLOTID.SelectedIndexChanged += new System.EventHandler(this.cboLOTID_SelectedIndexChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.comboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(166, 62);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(334, 26);
            this.comboBox1.TabIndex = 62;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("나눔고딕", 12F);
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label12.Location = new System.Drawing.Point(57, 66);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(87, 19);
            this.label12.TabIndex = 63;
            this.label12.Text = "불량 코드 1";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("나눔고딕", 12F);
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label18.Location = new System.Drawing.Point(576, 65);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(87, 19);
            this.label18.TabIndex = 64;
            this.label18.Text = "불량 수량 1";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("나눔고딕", 12F);
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label21.Location = new System.Drawing.Point(867, 65);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(92, 19);
            this.label21.TabIndex = 70;
            this.label21.Text = "총 불량 수량";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("나눔고딕", 12F);
            this.label23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label23.Location = new System.Drawing.Point(57, 114);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(87, 19);
            this.label23.TabIndex = 73;
            this.label23.Text = "불량 코드 2";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.comboBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(165, 110);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(334, 26);
            this.comboBox2.TabIndex = 72;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("나눔고딕", 12F);
            this.label24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label24.Location = new System.Drawing.Point(57, 167);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(87, 19);
            this.label24.TabIndex = 75;
            this.label24.Text = "불량 코드 3";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox3
            // 
            this.comboBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.comboBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(165, 163);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(334, 26);
            this.comboBox3.TabIndex = 74;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("나눔고딕", 12F);
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label19.Location = new System.Drawing.Point(576, 114);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(87, 19);
            this.label19.TabIndex = 76;
            this.label19.Text = "불량 수량 2";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("나눔고딕", 12F);
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label20.Location = new System.Drawing.Point(576, 167);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(87, 19);
            this.label20.TabIndex = 77;
            this.label20.Text = "불량 수량 3";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label25
            // 
            this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("나눔고딕", 12F);
            this.label25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label25.Location = new System.Drawing.Point(836, 114);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(126, 19);
            this.label25.TabIndex = 78;
            this.label25.Text = "불량 후 LOT 수량";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numTextBox1
            // 
            this.numTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.numTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.numTextBox1.Location = new System.Drawing.Point(686, 61);
            this.numTextBox1.Name = "numTextBox1";
            this.numTextBox1.Size = new System.Drawing.Size(119, 24);
            this.numTextBox1.TabIndex = 81;
            this.numTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numtxt_keydown);
            // 
            // numTextBox2
            // 
            this.numTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.numTextBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.numTextBox2.Location = new System.Drawing.Point(686, 110);
            this.numTextBox2.Name = "numTextBox2";
            this.numTextBox2.Size = new System.Drawing.Size(119, 24);
            this.numTextBox2.TabIndex = 82;
            this.numTextBox2.TextChanged += new System.EventHandler(this.numTextBox2_TextChanged);
            this.numTextBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numtxt_keydown);
            // 
            // numTextBox3
            // 
            this.numTextBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.numTextBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.numTextBox3.Location = new System.Drawing.Point(686, 163);
            this.numTextBox3.Name = "numTextBox3";
            this.numTextBox3.Size = new System.Drawing.Size(119, 24);
            this.numTextBox3.TabIndex = 83;
            this.numTextBox3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numtxt_keydown);
            // 
            // numTextBox4
            // 
            this.numTextBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numTextBox4.BackColor = System.Drawing.SystemColors.Window;
            this.numTextBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.numTextBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.numTextBox4.Location = new System.Drawing.Point(984, 61);
            this.numTextBox4.Name = "numTextBox4";
            this.numTextBox4.ReadOnly = true;
            this.numTextBox4.Size = new System.Drawing.Size(119, 24);
            this.numTextBox4.TabIndex = 84;
            // 
            // numTextBox5
            // 
            this.numTextBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numTextBox5.BackColor = System.Drawing.SystemColors.Window;
            this.numTextBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.numTextBox5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.numTextBox5.Location = new System.Drawing.Point(984, 110);
            this.numTextBox5.Name = "numTextBox5";
            this.numTextBox5.ReadOnly = true;
            this.numTextBox5.Size = new System.Drawing.Size(119, 24);
            this.numTextBox5.TabIndex = 85;
            // 
            // frmLOTDefect
            // 
            this.ClientSize = new System.Drawing.Size(1194, 850);
            this.Name = "frmLOTDefect";
            this.Activated += new System.EventHandler(this.frmLOTDefect_Activated);
            this.Load += new System.EventHandler(this.frmLOTDefect_Load);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.pnlCrud.ResumeLayout(false);
            this.pnlCrud.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.Label label18;
        public System.Windows.Forms.Label label12;
        public System.Windows.Forms.Label label20;
        public System.Windows.Forms.Label label19;
        public System.Windows.Forms.Label label24;
        private System.Windows.Forms.ComboBox comboBox3;
        public System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox comboBox2;
        public System.Windows.Forms.Label label21;
        public System.Windows.Forms.Label label25;
        private NumTextBox numTextBox5;
        private NumTextBox numTextBox4;
        private NumTextBox numTextBox3;
        private NumTextBox numTextBox2;
        private NumTextBox numTextBox1;
    }
}
