
namespace POPprogram
{
    partial class frmEndWorkOrder
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
            this.cboEQList = new System.Windows.Forms.ComboBox();
            this.txtEQ_NAME = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblDefectColor = new System.Windows.Forms.Label();
            this.lblInspectColor = new System.Windows.Forms.Label();
            this.lblMaterialColor = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblDefect = new System.Windows.Forms.Label();
            this.lblInspect = new System.Windows.Forms.Label();
            this.lblMaterial = new System.Windows.Forms.Label();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnlCrud.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel8.Controls.Add(this.tableLayoutPanel1);
            this.panel8.Size = new System.Drawing.Size(1136, 530);
            this.panel8.Controls.SetChildIndex(this.label6, 0);
            this.panel8.Controls.SetChildIndex(this.label22, 0);
            this.panel8.Controls.SetChildIndex(this.txtProdCode, 0);
            this.panel8.Controls.SetChildIndex(this.txtProdName, 0);
            this.panel8.Controls.SetChildIndex(this.label2, 0);
            this.panel8.Controls.SetChildIndex(this.txtOperCode, 0);
            this.panel8.Controls.SetChildIndex(this.txtOperName, 0);
            this.panel8.Controls.SetChildIndex(this.label3, 0);
            this.panel8.Controls.SetChildIndex(this.txtQty, 0);
            this.panel8.Controls.SetChildIndex(this.label10, 0);
            this.panel8.Controls.SetChildIndex(this.label11, 0);
            this.panel8.Controls.SetChildIndex(this.txtCustID, 0);
            this.panel8.Controls.SetChildIndex(this.txtWorkOrder, 0);
            this.panel8.Controls.SetChildIndex(this.txtCustName, 0);
            this.panel8.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.cboEQList);
            this.panel4.Controls.Add(this.txtEQ_NAME);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Location = new System.Drawing.Point(30, 633);
            this.panel4.Size = new System.Drawing.Size(1136, 195);
            this.panel4.Controls.SetChildIndex(this.txtComment, 0);
            this.panel4.Controls.SetChildIndex(this.label13, 0);
            this.panel4.Controls.SetChildIndex(this.label1, 0);
            this.panel4.Controls.SetChildIndex(this.label12, 0);
            this.panel4.Controls.SetChildIndex(this.txtEQ_NAME, 0);
            this.panel4.Controls.SetChildIndex(this.cboEQList, 0);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(102, 136);
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(165, 136);
            // 
            // pnlCrud
            // 
            this.pnlCrud.Location = new System.Drawing.Point(499, 845);
            // 
            // btnClose
            // 
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnExecute
            // 
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // cboLOTID
            // 
            this.cboLOTID.SelectedIndexChanged += new System.EventHandler(this.cboLOTID_SelectedIndexChanged);
            // 
            // cboEQList
            // 
            this.cboEQList.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.cboEQList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cboEQList.FormattingEnabled = true;
            this.cboEQList.Location = new System.Drawing.Point(165, 62);
            this.cboEQList.Name = "cboEQList";
            this.cboEQList.Size = new System.Drawing.Size(335, 26);
            this.cboEQList.TabIndex = 62;
            this.cboEQList.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // txtEQ_NAME
            // 
            this.txtEQ_NAME.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEQ_NAME.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtEQ_NAME.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtEQ_NAME.Location = new System.Drawing.Point(520, 62);
            this.txtEQ_NAME.Name = "txtEQ_NAME";
            this.txtEQ_NAME.Size = new System.Drawing.Size(581, 24);
            this.txtEQ_NAME.TabIndex = 61;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("나눔고딕", 12F);
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label12.Location = new System.Drawing.Point(102, 66);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 19);
            this.label12.TabIndex = 60;
            this.label12.Text = "설비";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.Gainsboro;
            this.label20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label20.Font = new System.Drawing.Font("나눔고딕", 14.25F, System.Drawing.FontStyle.Bold);
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(325, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(317, 24);
            this.label20.TabIndex = 20;
            this.label20.Text = "불량 입력 체크";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.Gainsboro;
            this.label21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label21.Font = new System.Drawing.Font("나눔고딕", 14.25F, System.Drawing.FontStyle.Bold);
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(648, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(318, 24);
            this.label21.TabIndex = 21;
            this.label21.Text = "불량 입력 체크";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33444F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33445F));
            this.tableLayoutPanel1.Controls.Add(this.lblDefectColor, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblInspectColor, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblMaterialColor, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label7, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label8, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblDefect, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblInspect, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblMaterial, 2, 1);
            this.tableLayoutPanel1.Font = new System.Drawing.Font("나눔고딕", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(167, 364);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(936, 157);
            this.tableLayoutPanel1.TabIndex = 71;
            // 
            // lblDefectColor
            // 
            this.lblDefectColor.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblDefectColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDefectColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDefectColor.Font = new System.Drawing.Font("나눔고딕", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDefectColor.Location = new System.Drawing.Point(1, 103);
            this.lblDefectColor.Margin = new System.Windows.Forms.Padding(0);
            this.lblDefectColor.Name = "lblDefectColor";
            this.lblDefectColor.Size = new System.Drawing.Size(310, 53);
            this.lblDefectColor.TabIndex = 27;
            this.lblDefectColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInspectColor
            // 
            this.lblInspectColor.BackColor = System.Drawing.Color.Tomato;
            this.lblInspectColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblInspectColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInspectColor.Font = new System.Drawing.Font("나눔고딕", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblInspectColor.Location = new System.Drawing.Point(312, 103);
            this.lblInspectColor.Margin = new System.Windows.Forms.Padding(0);
            this.lblInspectColor.Name = "lblInspectColor";
            this.lblInspectColor.Size = new System.Drawing.Size(310, 53);
            this.lblInspectColor.TabIndex = 26;
            this.lblInspectColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMaterialColor
            // 
            this.lblMaterialColor.BackColor = System.Drawing.Color.MediumAquamarine;
            this.lblMaterialColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMaterialColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaterialColor.Font = new System.Drawing.Font("나눔고딕", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMaterialColor.Location = new System.Drawing.Point(623, 103);
            this.lblMaterialColor.Margin = new System.Windows.Forms.Padding(0);
            this.lblMaterialColor.Name = "lblMaterialColor";
            this.lblMaterialColor.Size = new System.Drawing.Size(312, 53);
            this.lblMaterialColor.TabIndex = 25;
            this.lblMaterialColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Gainsboro;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("나눔고딕", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(1, 1);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(310, 50);
            this.label5.TabIndex = 19;
            this.label5.Text = "불량 입력 체크";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Gainsboro;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("나눔고딕", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(312, 1);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(310, 50);
            this.label7.TabIndex = 20;
            this.label7.Text = "검사 데이터 체크";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Gainsboro;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("나눔고딕", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(623, 1);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(312, 50);
            this.label8.TabIndex = 21;
            this.label8.Text = "자재 사용 체크";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDefect
            // 
            this.lblDefect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDefect.Font = new System.Drawing.Font("나눔고딕", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDefect.Location = new System.Drawing.Point(1, 52);
            this.lblDefect.Margin = new System.Windows.Forms.Padding(0);
            this.lblDefect.Name = "lblDefect";
            this.lblDefect.Size = new System.Drawing.Size(310, 50);
            this.lblDefect.TabIndex = 22;
            this.lblDefect.Text = "V";
            this.lblDefect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInspect
            // 
            this.lblInspect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInspect.Font = new System.Drawing.Font("나눔고딕", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblInspect.Location = new System.Drawing.Point(312, 52);
            this.lblInspect.Margin = new System.Windows.Forms.Padding(0);
            this.lblInspect.Name = "lblInspect";
            this.lblInspect.Size = new System.Drawing.Size(310, 50);
            this.lblInspect.TabIndex = 23;
            this.lblInspect.Text = "V";
            this.lblInspect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMaterial
            // 
            this.lblMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaterial.Font = new System.Drawing.Font("나눔고딕", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMaterial.Location = new System.Drawing.Point(623, 52);
            this.lblMaterial.Margin = new System.Windows.Forms.Padding(0);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(312, 50);
            this.lblMaterial.TabIndex = 24;
            this.lblMaterial.Text = "V";
            this.lblMaterial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmEndWorkOrder
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1194, 911);
            this.Name = "frmEndWorkOrder";
            this.Activated += new System.EventHandler(this.frmEndWorkOrder_Activated);
            this.Load += new System.EventHandler(this.frmEndWorkOrder_Load);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.pnlCrud.ResumeLayout(false);
            this.pnlCrud.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboEQList;
        public System.Windows.Forms.TextBox txtEQ_NAME;
        public System.Windows.Forms.Label label12;
        public System.Windows.Forms.Label label20;
        public System.Windows.Forms.Label label21;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Label lblDefectColor;
        public System.Windows.Forms.Label lblInspectColor;
        public System.Windows.Forms.Label lblMaterialColor;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label lblDefect;
        public System.Windows.Forms.Label lblInspect;
        public System.Windows.Forms.Label lblMaterial;
    }
}
