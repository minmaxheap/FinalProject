
namespace POPprogram
{
    partial class Base6
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Base6));
            this.panel7 = new System.Windows.Forms.Panel();
            this.cboLOTID = new System.Windows.Forms.ComboBox();
            this.txtLOTDescription = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtProdCode = new System.Windows.Forms.TextBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.txtQty = new POPprogram.NumTextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDefectQty = new System.Windows.Forms.Label();
            this.lblProdQty = new System.Windows.Forms.Label();
            this.lblOrderQty = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtCustName = new System.Windows.Forms.TextBox();
            this.txtWorkOrder = new System.Windows.Forms.TextBox();
            this.txtCustID = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOperName = new System.Windows.Forms.TextBox();
            this.txtOperCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProdName = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.pnlCrud = new System.Windows.Forms.Panel();
            this.btnExecute = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnlCrud.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.cboLOTID);
            this.panel7.Controls.Add(this.txtLOTDescription);
            this.panel7.Controls.Add(this.label9);
            this.panel7.Location = new System.Drawing.Point(31, 26);
            this.panel7.Margin = new System.Windows.Forms.Padding(0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1136, 49);
            this.panel7.TabIndex = 50;
            // 
            // cboLOTID
            // 
            this.cboLOTID.Font = new System.Drawing.Font("나눔고딕", 14.25F);
            this.cboLOTID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cboLOTID.FormattingEnabled = true;
            this.cboLOTID.Location = new System.Drawing.Point(166, 8);
            this.cboLOTID.Name = "cboLOTID";
            this.cboLOTID.Size = new System.Drawing.Size(335, 29);
            this.cboLOTID.TabIndex = 61;
            // 
            // txtLOTDescription
            // 
            this.txtLOTDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLOTDescription.BackColor = System.Drawing.Color.White;
            this.txtLOTDescription.Font = new System.Drawing.Font("나눔고딕", 14.25F);
            this.txtLOTDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtLOTDescription.Location = new System.Drawing.Point(522, 8);
            this.txtLOTDescription.Name = "txtLOTDescription";
            this.txtLOTDescription.ReadOnly = true;
            this.txtLOTDescription.Size = new System.Drawing.Size(579, 29);
            this.txtLOTDescription.TabIndex = 57;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("나눔고딕", 14.25F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(39, 13);
            this.label9.Margin = new System.Windows.Forms.Padding(0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 21);
            this.label9.TabIndex = 26;
            this.label9.Text = "생산 LOT ID";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("나눔고딕", 15.75F);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(1134, 45);
            this.label6.TabIndex = 17;
            this.label6.Text = "생산 LOT 정보";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtProdCode
            // 
            this.txtProdCode.BackColor = System.Drawing.Color.White;
            this.txtProdCode.Font = new System.Drawing.Font("나눔고딕", 12F);
            this.txtProdCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtProdCode.Location = new System.Drawing.Point(166, 61);
            this.txtProdCode.Name = "txtProdCode";
            this.txtProdCode.ReadOnly = true;
            this.txtProdCode.Size = new System.Drawing.Size(335, 26);
            this.txtProdCode.TabIndex = 49;
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.txtQty);
            this.panel8.Controls.Add(this.tableLayoutPanel2);
            this.panel8.Controls.Add(this.txtCustName);
            this.panel8.Controls.Add(this.txtWorkOrder);
            this.panel8.Controls.Add(this.txtCustID);
            this.panel8.Controls.Add(this.label11);
            this.panel8.Controls.Add(this.label10);
            this.panel8.Controls.Add(this.label3);
            this.panel8.Controls.Add(this.txtOperName);
            this.panel8.Controls.Add(this.txtOperCode);
            this.panel8.Controls.Add(this.label2);
            this.panel8.Controls.Add(this.txtProdName);
            this.panel8.Controls.Add(this.txtProdCode);
            this.panel8.Controls.Add(this.label22);
            this.panel8.Controls.Add(this.label6);
            this.panel8.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panel8.Location = new System.Drawing.Point(31, 100);
            this.panel8.Margin = new System.Windows.Forms.Padding(0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1136, 362);
            this.panel8.TabIndex = 49;
            // 
            // txtQty
            // 
            this.txtQty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQty.BackColor = System.Drawing.Color.White;
            this.txtQty.Font = new System.Drawing.Font("나눔고딕", 12F);
            this.txtQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtQty.Location = new System.Drawing.Point(802, 154);
            this.txtQty.Name = "txtQty";
            this.txtQty.ReadOnly = true;
            this.txtQty.Size = new System.Drawing.Size(301, 26);
            this.txtQty.TabIndex = 90;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblDefectQty, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblProdQty, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblOrderQty, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label21, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label20, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label19, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblStatus, 0, 1);
            this.tableLayoutPanel2.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tableLayoutPanel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tableLayoutPanel2.Location = new System.Drawing.Point(167, 243);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(936, 107);
            this.tableLayoutPanel2.TabIndex = 49;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("나눔고딕", 13F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(1, 1);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(232, 50);
            this.label4.TabIndex = 53;
            this.label4.Text = "지시 상태";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDefectQty
            // 
            this.lblDefectQty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDefectQty.Font = new System.Drawing.Font("나눔고딕", 13F);
            this.lblDefectQty.Location = new System.Drawing.Point(700, 52);
            this.lblDefectQty.Margin = new System.Windows.Forms.Padding(0);
            this.lblDefectQty.Name = "lblDefectQty";
            this.lblDefectQty.Size = new System.Drawing.Size(235, 54);
            this.lblDefectQty.TabIndex = 52;
            this.lblDefectQty.Text = "1000";
            this.lblDefectQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProdQty
            // 
            this.lblProdQty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProdQty.Font = new System.Drawing.Font("나눔고딕", 13F);
            this.lblProdQty.Location = new System.Drawing.Point(467, 52);
            this.lblProdQty.Margin = new System.Windows.Forms.Padding(0);
            this.lblProdQty.Name = "lblProdQty";
            this.lblProdQty.Size = new System.Drawing.Size(232, 54);
            this.lblProdQty.TabIndex = 51;
            this.lblProdQty.Text = "1000";
            this.lblProdQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOrderQty
            // 
            this.lblOrderQty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOrderQty.Font = new System.Drawing.Font("나눔고딕", 13F);
            this.lblOrderQty.Location = new System.Drawing.Point(234, 52);
            this.lblOrderQty.Margin = new System.Windows.Forms.Padding(0);
            this.lblOrderQty.Name = "lblOrderQty";
            this.lblOrderQty.Size = new System.Drawing.Size(232, 54);
            this.lblOrderQty.TabIndex = 50;
            this.lblOrderQty.Text = "1000";
            this.lblOrderQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.Tomato;
            this.label21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label21.Font = new System.Drawing.Font("나눔고딕", 13F);
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(700, 1);
            this.label21.Margin = new System.Windows.Forms.Padding(0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(235, 50);
            this.label21.TabIndex = 49;
            this.label21.Text = "불량 수량";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.MediumAquamarine;
            this.label20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label20.Font = new System.Drawing.Font("나눔고딕", 13F);
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(467, 1);
            this.label20.Margin = new System.Windows.Forms.Padding(0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(232, 50);
            this.label20.TabIndex = 48;
            this.label20.Text = "생산 수량";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.label19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label19.Font = new System.Drawing.Font("나눔고딕", 13F);
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(234, 1);
            this.label19.Margin = new System.Windows.Forms.Padding(0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(232, 50);
            this.label19.TabIndex = 47;
            this.label19.Text = "지시 수량";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStatus
            // 
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.Font = new System.Drawing.Font("나눔고딕", 13F);
            this.lblStatus.Location = new System.Drawing.Point(1, 52);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(232, 54);
            this.lblStatus.TabIndex = 18;
            this.lblStatus.Text = "Closed";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCustName
            // 
            this.txtCustName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustName.BackColor = System.Drawing.Color.White;
            this.txtCustName.Font = new System.Drawing.Font("나눔고딕", 12F);
            this.txtCustName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtCustName.Location = new System.Drawing.Point(522, 198);
            this.txtCustName.Name = "txtCustName";
            this.txtCustName.ReadOnly = true;
            this.txtCustName.Size = new System.Drawing.Size(581, 26);
            this.txtCustName.TabIndex = 69;
            // 
            // txtWorkOrder
            // 
            this.txtWorkOrder.BackColor = System.Drawing.Color.White;
            this.txtWorkOrder.Font = new System.Drawing.Font("나눔고딕", 12F);
            this.txtWorkOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtWorkOrder.Location = new System.Drawing.Point(166, 154);
            this.txtWorkOrder.Name = "txtWorkOrder";
            this.txtWorkOrder.ReadOnly = true;
            this.txtWorkOrder.Size = new System.Drawing.Size(335, 26);
            this.txtWorkOrder.TabIndex = 69;
            // 
            // txtCustID
            // 
            this.txtCustID.BackColor = System.Drawing.Color.White;
            this.txtCustID.Font = new System.Drawing.Font("나눔고딕", 12F);
            this.txtCustID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtCustID.Location = new System.Drawing.Point(166, 198);
            this.txtCustID.Name = "txtCustID";
            this.txtCustID.ReadOnly = true;
            this.txtCustID.Size = new System.Drawing.Size(335, 26);
            this.txtCustID.TabIndex = 67;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label11.Location = new System.Drawing.Point(88, 201);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 19);
            this.label11.TabIndex = 68;
            this.label11.Text = "고객사";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label10.Location = new System.Drawing.Point(74, 157);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 19);
            this.label10.TabIndex = 70;
            this.label10.Text = "작업지시";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("나눔고딕", 12F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label3.Location = new System.Drawing.Point(736, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 19);
            this.label3.TabIndex = 68;
            this.label3.Text = "수량";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtOperName
            // 
            this.txtOperName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOperName.BackColor = System.Drawing.Color.White;
            this.txtOperName.Font = new System.Drawing.Font("나눔고딕", 12F);
            this.txtOperName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtOperName.Location = new System.Drawing.Point(522, 107);
            this.txtOperName.Name = "txtOperName";
            this.txtOperName.ReadOnly = true;
            this.txtOperName.Size = new System.Drawing.Size(581, 26);
            this.txtOperName.TabIndex = 66;
            // 
            // txtOperCode
            // 
            this.txtOperCode.BackColor = System.Drawing.Color.White;
            this.txtOperCode.Font = new System.Drawing.Font("나눔고딕", 12F);
            this.txtOperCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtOperCode.Location = new System.Drawing.Point(166, 107);
            this.txtOperCode.Name = "txtOperCode";
            this.txtOperCode.ReadOnly = true;
            this.txtOperCode.Size = new System.Drawing.Size(335, 26);
            this.txtOperCode.TabIndex = 64;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label2.Location = new System.Drawing.Point(102, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 19);
            this.label2.TabIndex = 65;
            this.label2.Text = "공정";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtProdName
            // 
            this.txtProdName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProdName.BackColor = System.Drawing.Color.White;
            this.txtProdName.Font = new System.Drawing.Font("나눔고딕", 12F);
            this.txtProdName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtProdName.Location = new System.Drawing.Point(522, 61);
            this.txtProdName.Name = "txtProdName";
            this.txtProdName.ReadOnly = true;
            this.txtProdName.Size = new System.Drawing.Size(581, 26);
            this.txtProdName.TabIndex = 55;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label22.Location = new System.Drawing.Point(102, 64);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(39, 19);
            this.label22.TabIndex = 54;
            this.label22.Text = "품번";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.txtComment);
            this.panel4.Location = new System.Drawing.Point(31, 488);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1136, 199);
            this.panel4.TabIndex = 51;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("나눔고딕", 15.75F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1134, 45);
            this.label1.TabIndex = 39;
            this.label1.Text = "작업 완료 정보";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("나눔고딕", 12F);
            this.label13.Location = new System.Drawing.Point(102, 133);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(39, 19);
            this.label13.TabIndex = 38;
            this.label13.Text = "주석";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtComment
            // 
            this.txtComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment.Font = new System.Drawing.Font("나눔고딕", 12F);
            this.txtComment.Location = new System.Drawing.Point(165, 132);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(937, 46);
            this.txtComment.TabIndex = 37;
            // 
            // pnlCrud
            // 
            this.pnlCrud.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCrud.Controls.Add(this.btnExecute);
            this.pnlCrud.Controls.Add(this.btnClose);
            this.pnlCrud.Location = new System.Drawing.Point(499, 707);
            this.pnlCrud.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCrud.Name = "pnlCrud";
            this.pnlCrud.Size = new System.Drawing.Size(668, 45);
            this.pnlCrud.TabIndex = 52;
            // 
            // btnExecute
            // 
            this.btnExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExecute.AutoSize = true;
            this.btnExecute.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.btnExecute.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExecute.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnExecute.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExecute.ImageKey = "Touch-Screen.png";
            this.btnExecute.ImageList = this.imageList1;
            this.btnExecute.Location = new System.Drawing.Point(368, 0);
            this.btnExecute.Margin = new System.Windows.Forms.Padding(0);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnExecute.Size = new System.Drawing.Size(140, 45);
            this.btnExecute.TabIndex = 84;
            this.btnExecute.Text = "실행  ";
            this.btnExecute.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExecute.UseVisualStyleBackColor = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Blank-13.png");
            this.imageList1.Images.SetKeyName(1, "Data-Import.png");
            this.imageList1.Images.SetKeyName(2, "Check-01.png");
            this.imageList1.Images.SetKeyName(3, "Minus.png");
            this.imageList1.Images.SetKeyName(4, "Export.png");
            this.imageList1.Images.SetKeyName(5, "Print - 01.png");
            this.imageList1.Images.SetKeyName(6, "Trash Can_02.png");
            this.imageList1.Images.SetKeyName(7, "Command-Refresh-01.png");
            this.imageList1.Images.SetKeyName(8, "Add-New.png");
            this.imageList1.Images.SetKeyName(9, "Close.png");
            this.imageList1.Images.SetKeyName(10, "Delete_03.png");
            this.imageList1.Images.SetKeyName(11, "Save_02.png");
            this.imageList1.Images.SetKeyName(12, "Data-Find.png");
            this.imageList1.Images.SetKeyName(13, "Black List.png");
            this.imageList1.Images.SetKeyName(14, "Arrowhead-Right-01.png");
            this.imageList1.Images.SetKeyName(15, "Search-Find.png");
            this.imageList1.Images.SetKeyName(16, "Touch-Screen.png");
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClose.AutoSize = true;
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.ImageKey = "Close.png";
            this.btnClose.ImageList = this.imageList1;
            this.btnClose.Location = new System.Drawing.Point(528, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnClose.Size = new System.Drawing.Size(140, 45);
            this.btnClose.TabIndex = 83;
            this.btnClose.Text = "닫기  ";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // Base6
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1194, 773);
            this.Controls.Add(this.pnlCrud);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel8);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Base6";
            this.Text = "Base6";
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.pnlCrud.ResumeLayout(false);
            this.pnlCrud.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Panel panel7;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtProdCode;
        public System.Windows.Forms.Panel panel8;
        public System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.Label label13;
        public System.Windows.Forms.TextBox txtComment;
        public System.Windows.Forms.TextBox txtProdName;
        public System.Windows.Forms.Label label22;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtCustName;
        public System.Windows.Forms.TextBox txtWorkOrder;
        public System.Windows.Forms.TextBox txtCustID;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtOperName;
        public System.Windows.Forms.TextBox txtOperCode;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Panel pnlCrud;
        public System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.TextBox txtLOTDescription;
        public System.Windows.Forms.Button btnExecute;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label lblDefectQty;
        public System.Windows.Forms.Label lblProdQty;
        public System.Windows.Forms.Label lblOrderQty;
        public System.Windows.Forms.Label label21;
        public System.Windows.Forms.Label label20;
        public System.Windows.Forms.Label label19;
        public System.Windows.Forms.Label lblStatus;
        public NumTextBox txtQty;
        public System.Windows.Forms.ComboBox cboLOTID;
        private System.Windows.Forms.ImageList imageList1;
    }
}