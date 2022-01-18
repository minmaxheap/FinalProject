
namespace POPprogram
{
    partial class Base5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Base5));
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtQty = new POPprogram.NumTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtOperName = new System.Windows.Forms.TextBox();
            this.lblComment = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.txtOperCode = new System.Windows.Forms.TextBox();
            this.lblOperation = new System.Windows.Forms.Label();
            this.lblQty = new System.Windows.Forms.Label();
            this.txtProdName = new System.Windows.Forms.TextBox();
            this.txtProdCode = new System.Windows.Forms.TextBox();
            this.lblProduct = new System.Windows.Forms.Label();
            this.txtLOTDescription = new System.Windows.Forms.TextBox();
            this.txtLOTID = new System.Windows.Forms.TextBox();
            this.lblLOT = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDefectQty = new System.Windows.Forms.Label();
            this.lblProdQty = new System.Windows.Forms.Label();
            this.lblOrderQty = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnTxtSearch = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblWorkOrder = new System.Windows.Forms.Label();
            this.txtCustName = new System.Windows.Forms.TextBox();
            this.txtCustID = new System.Windows.Forms.TextBox();
            this.txtWorkOrderID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlCrud = new System.Windows.Forms.Panel();
            this.btnExecute = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblUpTitle = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            this.panel8.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlCrud.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.txtQty);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.txtOperName);
            this.panel4.Controls.Add(this.lblComment);
            this.panel4.Controls.Add(this.txtComment);
            this.panel4.Controls.Add(this.txtOperCode);
            this.panel4.Controls.Add(this.lblOperation);
            this.panel4.Controls.Add(this.lblQty);
            this.panel4.Controls.Add(this.txtProdName);
            this.panel4.Controls.Add(this.txtProdCode);
            this.panel4.Controls.Add(this.lblProduct);
            this.panel4.Controls.Add(this.txtLOTDescription);
            this.panel4.Controls.Add(this.txtLOTID);
            this.panel4.Controls.Add(this.lblLOT);
            this.panel4.Location = new System.Drawing.Point(30, 409);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1136, 345);
            this.panel4.TabIndex = 45;
            // 
            // txtQty
            // 
            this.txtQty.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtQty.Location = new System.Drawing.Point(149, 215);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(335, 26);
            this.txtQty.TabIndex = 89;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(179)))), ((int)(((byte)(224)))));
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Dock = System.Windows.Forms.DockStyle.Top;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(0, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(1134, 45);
            this.label11.TabIndex = 88;
            this.label11.Text = "생산 LOT 정보";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtOperName
            // 
            this.txtOperName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOperName.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtOperName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtOperName.Location = new System.Drawing.Point(505, 164);
            this.txtOperName.Name = "txtOperName";
            this.txtOperName.Size = new System.Drawing.Size(581, 26);
            this.txtOperName.TabIndex = 87;
            // 
            // lblComment
            // 
            this.lblComment.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblComment.AutoSize = true;
            this.lblComment.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblComment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblComment.Location = new System.Drawing.Point(104, 278);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(39, 19);
            this.lblComment.TabIndex = 86;
            this.lblComment.Text = "주석";
            this.lblComment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtComment
            // 
            this.txtComment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtComment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtComment.Location = new System.Drawing.Point(149, 278);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(937, 40);
            this.txtComment.TabIndex = 85;
            // 
            // txtOperCode
            // 
            this.txtOperCode.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtOperCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtOperCode.Location = new System.Drawing.Point(149, 166);
            this.txtOperCode.Name = "txtOperCode";
            this.txtOperCode.Size = new System.Drawing.Size(335, 26);
            this.txtOperCode.TabIndex = 83;
            // 
            // lblOperation
            // 
            this.lblOperation.AutoSize = true;
            this.lblOperation.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOperation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblOperation.Location = new System.Drawing.Point(104, 169);
            this.lblOperation.Name = "lblOperation";
            this.lblOperation.Size = new System.Drawing.Size(39, 19);
            this.lblOperation.TabIndex = 84;
            this.lblOperation.Text = "공정";
            this.lblOperation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblQty.Location = new System.Drawing.Point(104, 219);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(39, 19);
            this.lblQty.TabIndex = 81;
            this.lblQty.Text = "수량";
            this.lblQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtProdName
            // 
            this.txtProdName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProdName.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtProdName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtProdName.Location = new System.Drawing.Point(505, 114);
            this.txtProdName.Name = "txtProdName";
            this.txtProdName.Size = new System.Drawing.Size(581, 26);
            this.txtProdName.TabIndex = 77;
            // 
            // txtProdCode
            // 
            this.txtProdCode.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtProdCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtProdCode.Location = new System.Drawing.Point(149, 114);
            this.txtProdCode.Name = "txtProdCode";
            this.txtProdCode.Size = new System.Drawing.Size(335, 26);
            this.txtProdCode.TabIndex = 75;
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblProduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblProduct.Location = new System.Drawing.Point(104, 117);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(39, 19);
            this.lblProduct.TabIndex = 76;
            this.lblProduct.Text = "품번";
            this.lblProduct.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtLOTDescription
            // 
            this.txtLOTDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLOTDescription.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtLOTDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtLOTDescription.Location = new System.Drawing.Point(505, 67);
            this.txtLOTDescription.Name = "txtLOTDescription";
            this.txtLOTDescription.Size = new System.Drawing.Size(581, 26);
            this.txtLOTDescription.TabIndex = 74;
            // 
            // txtLOTID
            // 
            this.txtLOTID.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtLOTID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtLOTID.Location = new System.Drawing.Point(149, 67);
            this.txtLOTID.Name = "txtLOTID";
            this.txtLOTID.Size = new System.Drawing.Size(335, 26);
            this.txtLOTID.TabIndex = 72;
            // 
            // lblLOT
            // 
            this.lblLOT.AutoSize = true;
            this.lblLOT.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLOT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblLOT.Location = new System.Drawing.Point(54, 70);
            this.lblLOT.Name = "lblLOT";
            this.lblLOT.Size = new System.Drawing.Size(93, 19);
            this.lblLOT.TabIndex = 73;
            this.lblLOT.Text = "생산 LOT ID";
            this.lblLOT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel8.BackColor = System.Drawing.Color.White;
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.tableLayoutPanel1);
            this.panel8.Controls.Add(this.btnTxtSearch);
            this.panel8.Controls.Add(this.lblCustomer);
            this.panel8.Controls.Add(this.lblWorkOrder);
            this.panel8.Controls.Add(this.txtCustName);
            this.panel8.Controls.Add(this.txtCustID);
            this.panel8.Controls.Add(this.txtWorkOrderID);
            this.panel8.Controls.Add(this.label6);
            this.panel8.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panel8.Location = new System.Drawing.Point(31, 73);
            this.panel8.Margin = new System.Windows.Forms.Padding(0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1136, 326);
            this.panel8.TabIndex = 46;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblDefectQty, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblProdQty, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblOrderQty, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label21, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label20, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label19, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblStatus, 0, 1);
            this.tableLayoutPanel1.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tableLayoutPanel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(148, 192);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(931, 107);
            this.tableLayoutPanel1.TabIndex = 80;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("나눔고딕", 13F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(1, 1);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(231, 50);
            this.label4.TabIndex = 53;
            this.label4.Text = "지시 상태";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDefectQty
            // 
            this.lblDefectQty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDefectQty.Font = new System.Drawing.Font("나눔고딕", 13F);
            this.lblDefectQty.Location = new System.Drawing.Point(697, 52);
            this.lblDefectQty.Margin = new System.Windows.Forms.Padding(0);
            this.lblDefectQty.Name = "lblDefectQty";
            this.lblDefectQty.Size = new System.Drawing.Size(233, 54);
            this.lblDefectQty.TabIndex = 52;
            this.lblDefectQty.Text = "1000";
            this.lblDefectQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProdQty
            // 
            this.lblProdQty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProdQty.Font = new System.Drawing.Font("나눔고딕", 13F);
            this.lblProdQty.Location = new System.Drawing.Point(465, 52);
            this.lblProdQty.Margin = new System.Windows.Forms.Padding(0);
            this.lblProdQty.Name = "lblProdQty";
            this.lblProdQty.Size = new System.Drawing.Size(231, 54);
            this.lblProdQty.TabIndex = 51;
            this.lblProdQty.Text = "1000";
            this.lblProdQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOrderQty
            // 
            this.lblOrderQty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOrderQty.Font = new System.Drawing.Font("나눔고딕", 13F);
            this.lblOrderQty.Location = new System.Drawing.Point(233, 52);
            this.lblOrderQty.Margin = new System.Windows.Forms.Padding(0);
            this.lblOrderQty.Name = "lblOrderQty";
            this.lblOrderQty.Size = new System.Drawing.Size(231, 54);
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
            this.label21.Location = new System.Drawing.Point(697, 1);
            this.label21.Margin = new System.Windows.Forms.Padding(0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(233, 50);
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
            this.label20.Location = new System.Drawing.Point(465, 1);
            this.label20.Margin = new System.Windows.Forms.Padding(0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(231, 50);
            this.label20.TabIndex = 48;
            this.label20.Text = "생산 수량";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
            this.label19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label19.Font = new System.Drawing.Font("나눔고딕", 13F);
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(233, 1);
            this.label19.Margin = new System.Windows.Forms.Padding(0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(231, 50);
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
            this.lblStatus.Size = new System.Drawing.Size(231, 54);
            this.lblStatus.TabIndex = 18;
            this.lblStatus.Text = "Closed";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnTxtSearch
            // 
            this.btnTxtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
            this.btnTxtSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTxtSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTxtSearch.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnTxtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnTxtSearch.ImageIndex = 15;
            this.btnTxtSearch.ImageList = this.imageList1;
            this.btnTxtSearch.Location = new System.Drawing.Point(504, 75);
            this.btnTxtSearch.Name = "btnTxtSearch";
            this.btnTxtSearch.Size = new System.Drawing.Size(32, 26);
            this.btnTxtSearch.TabIndex = 79;
            this.btnTxtSearch.UseVisualStyleBackColor = false;
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
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblCustomer.Location = new System.Drawing.Point(89, 134);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(54, 19);
            this.lblCustomer.TabIndex = 78;
            this.lblCustomer.Text = "고객사";
            this.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWorkOrder
            // 
            this.lblWorkOrder.AutoSize = true;
            this.lblWorkOrder.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblWorkOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblWorkOrder.Location = new System.Drawing.Point(75, 79);
            this.lblWorkOrder.Name = "lblWorkOrder";
            this.lblWorkOrder.Size = new System.Drawing.Size(69, 19);
            this.lblWorkOrder.TabIndex = 77;
            this.lblWorkOrder.Text = "작업지시";
            this.lblWorkOrder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCustName
            // 
            this.txtCustName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustName.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtCustName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtCustName.Location = new System.Drawing.Point(504, 130);
            this.txtCustName.Name = "txtCustName";
            this.txtCustName.Size = new System.Drawing.Size(575, 26);
            this.txtCustName.TabIndex = 21;
            // 
            // txtCustID
            // 
            this.txtCustID.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtCustID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtCustID.Location = new System.Drawing.Point(148, 130);
            this.txtCustID.Name = "txtCustID";
            this.txtCustID.Size = new System.Drawing.Size(335, 26);
            this.txtCustID.TabIndex = 20;
            // 
            // txtWorkOrderID
            // 
            this.txtWorkOrderID.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtWorkOrderID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtWorkOrderID.Location = new System.Drawing.Point(148, 75);
            this.txtWorkOrderID.Name = "txtWorkOrderID";
            this.txtWorkOrderID.Size = new System.Drawing.Size(335, 26);
            this.txtWorkOrderID.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(183)))), ((int)(((byte)(241)))));
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(1134, 45);
            this.label6.TabIndex = 17;
            this.label6.Text = "작업지시 정보";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlCrud
            // 
            this.pnlCrud.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCrud.Controls.Add(this.btnExecute);
            this.pnlCrud.Controls.Add(this.btnClose);
            this.pnlCrud.Location = new System.Drawing.Point(499, 763);
            this.pnlCrud.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCrud.Name = "pnlCrud";
            this.pnlCrud.Size = new System.Drawing.Size(668, 45);
            this.pnlCrud.TabIndex = 47;
            // 
            // btnExecute
            // 
            this.btnExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExecute.AutoSize = true;
            this.btnExecute.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
            this.btnExecute.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExecute.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnExecute.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnExecute.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExecute.ImageIndex = 16;
            this.btnExecute.ImageList = this.imageList1;
            this.btnExecute.Location = new System.Drawing.Point(330, 0);
            this.btnExecute.Margin = new System.Windows.Forms.Padding(0);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnExecute.Size = new System.Drawing.Size(140, 45);
            this.btnExecute.TabIndex = 79;
            this.btnExecute.Text = "실행  ";
            this.btnExecute.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExecute.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.AutoSize = true;
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.ImageIndex = 9;
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
            // lblUpTitle
            // 
            this.lblUpTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblUpTitle.Font = new System.Drawing.Font("나눔고딕", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblUpTitle.Location = new System.Drawing.Point(0, 0);
            this.lblUpTitle.Name = "lblUpTitle";
            this.lblUpTitle.Size = new System.Drawing.Size(1194, 67);
            this.lblUpTitle.TabIndex = 54;
            this.lblUpTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Base5
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(1194, 823);
            this.Controls.Add(this.lblUpTitle);
            this.Controls.Add(this.pnlCrud);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel8);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Base5";
            this.Text = "Base5";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnlCrud.ResumeLayout(false);
            this.pnlCrud.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.Panel panel8;
        public System.Windows.Forms.TextBox txtCustName;
        public System.Windows.Forms.TextBox txtCustID;
        public System.Windows.Forms.TextBox txtWorkOrderID;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Panel pnlCrud;
        public System.Windows.Forms.Button btnExecute;
        public System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.TextBox txtOperCode;
        public System.Windows.Forms.Label lblOperation;
        public System.Windows.Forms.Label lblQty;
        public System.Windows.Forms.TextBox txtProdName;
        public System.Windows.Forms.TextBox txtProdCode;
        public System.Windows.Forms.Label lblProduct;
        public System.Windows.Forms.TextBox txtLOTDescription;
        public System.Windows.Forms.TextBox txtLOTID;
        public System.Windows.Forms.Label lblLOT;
        public System.Windows.Forms.TextBox txtOperName;
        public System.Windows.Forms.Label lblComment;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.Label lblCustomer;
        public System.Windows.Forms.Label lblWorkOrder;
        public NumTextBox txtQty;
        public System.Windows.Forms.Button btnTxtSearch;
        public System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.ImageList imageList1;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label lblDefectQty;
        public System.Windows.Forms.Label lblProdQty;
        public System.Windows.Forms.Label lblOrderQty;
        public System.Windows.Forms.Label label21;
        public System.Windows.Forms.Label label20;
        public System.Windows.Forms.Label label19;
        public System.Windows.Forms.Label lblStatus;
        public System.Windows.Forms.Label lblUpTitle;
    }
}