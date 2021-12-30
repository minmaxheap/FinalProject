
namespace MES_Team3
{
    partial class Base3_1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Base3_1));



            this.pnlTop = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.spcBase = new System.Windows.Forms.SplitContainer();
            this.pnlDgv = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblPanel = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblAddList = new System.Windows.Forms.Label();
            this.pnlAll = new System.Windows.Forms.Panel();
            this.lblAll = new System.Windows.Forms.Label();
            this.pnlCrud = new System.Windows.Forms.Panel();
            this.btnReadBottom = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlAdd = new System.Windows.Forms.Panel();
            this.lblAdd = new System.Windows.Forms.Label();
            btnTxtSearch = new System.Windows.Forms.Button();
            btnReadTop = new System.Windows.Forms.Button();
            btnSubtract = new System.Windows.Forms.Button();
            btnAdd = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcBase)).BeginInit();
            this.spcBase.Panel1.SuspendLayout();
            this.spcBase.Panel2.SuspendLayout();
            this.spcBase.SuspendLayout();
            this.pnlDgv.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlAll.SuspendLayout();
            this.pnlCrud.SuspendLayout();
            this.pnlAdd.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.txtSearch);
            this.pnlTop.Controls.Add(btnTxtSearch);
            this.pnlTop.Controls.Add(btnReadTop);
            this.pnlTop.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pnlTop.Location = new System.Drawing.Point(0, 17);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1152, 30);
            this.pnlTop.TabIndex = 41;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("나눔고딕", 12F);
            this.txtSearch.Location = new System.Drawing.Point(42, 1);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(0);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(244, 26);
            this.txtSearch.TabIndex = 50;
            // 
            // btnTxtSearch
            // 
            btnTxtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(194)))), ((int)(((byte)(229)))));
            btnTxtSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTxtSearch.BackgroundImage")));
            btnTxtSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            btnTxtSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            btnTxtSearch.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 9.75F);
            btnTxtSearch.ForeColor = System.Drawing.SystemColors.ControlText;
            btnTxtSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            btnTxtSearch.Location = new System.Drawing.Point(293, 1);
            btnTxtSearch.Margin = new System.Windows.Forms.Padding(0);
            btnTxtSearch.Name = "btnTxtSearch";
            btnTxtSearch.Size = new System.Drawing.Size(32, 26);
            btnTxtSearch.TabIndex = 49;
            btnTxtSearch.UseVisualStyleBackColor = false;
            // 
            // btnReadTop
            // 
            btnReadTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(194)))), ((int)(((byte)(229)))));
            btnReadTop.BackgroundImage = global::MES_Team3.Properties.Resources.Data_Find12;
            btnReadTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            btnReadTop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            btnReadTop.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 9.75F);
            btnReadTop.ForeColor = System.Drawing.SystemColors.ControlText;
            btnReadTop.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            btnReadTop.Location = new System.Drawing.Point(2, 1);
            btnReadTop.Name = "btnReadTop";
            btnReadTop.Size = new System.Drawing.Size(33, 26);
            btnReadTop.TabIndex = 47;
            btnReadTop.UseVisualStyleBackColor = false;
            // 
            // spcBase
            // 
            this.spcBase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spcBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spcBase.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.spcBase.Location = new System.Drawing.Point(0, 63);
            this.spcBase.Margin = new System.Windows.Forms.Padding(0);
            this.spcBase.Name = "spcBase";
            // 
            // spcBase.Panel1
            // 
            this.spcBase.Panel1.Controls.Add(this.pnlDgv);
            // 
            // spcBase.Panel2
            // 
            this.spcBase.Panel2.Controls.Add(this.lblPanel);
            this.spcBase.Panel2.Controls.Add(this.pnlSearch);
            this.spcBase.Size = new System.Drawing.Size(1152, 269);
            this.spcBase.SplitterDistance = 726;
            this.spcBase.SplitterWidth = 6;
            this.spcBase.TabIndex = 42;
            // 
            // pnlDgv
            // 
            this.pnlDgv.Controls.Add(this.lblTitle);
            this.pnlDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDgv.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pnlDgv.Location = new System.Drawing.Point(0, 0);
            this.pnlDgv.Margin = new System.Windows.Forms.Padding(0);
            this.pnlDgv.Name = "pnlDgv";
            this.pnlDgv.Size = new System.Drawing.Size(724, 267);
            this.pnlDgv.TabIndex = 18;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(194)))), ((int)(((byte)(229)))));
            this.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(724, 36);
            this.lblTitle.TabIndex = 17;
            this.lblTitle.Text = "title";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPanel
            // 
            this.lblPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(194)))), ((int)(((byte)(229)))));
            this.lblPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPanel.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblPanel.Location = new System.Drawing.Point(0, 0);
            this.lblPanel.Margin = new System.Windows.Forms.Padding(0);
            this.lblPanel.Name = "lblPanel";
            this.lblPanel.Size = new System.Drawing.Size(418, 36);
            this.lblPanel.TabIndex = 32;
            this.lblPanel.Text = "▶ 검색 조건";
            this.lblPanel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlSearch
            // 
            this.pnlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
            this.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSearch.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pnlSearch.Location = new System.Drawing.Point(0, 36);
            this.pnlSearch.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(418, 231);
            this.pnlSearch.TabIndex = 31;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(btnSubtract);
            this.panel1.Controls.Add(btnAdd);
            this.panel1.Controls.Add(this.lblAddList);
            this.panel1.Controls.Add(this.pnlAll);
            this.panel1.Controls.Add(this.pnlCrud);
            this.panel1.Controls.Add(this.pnlAdd);
            this.panel1.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panel1.Location = new System.Drawing.Point(0, 332);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1152, 409);
            this.panel1.TabIndex = 43;
            // 
            // btnSubtract
            // 
            btnSubtract.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            btnSubtract.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(194)))), ((int)(((byte)(229)))));
            btnSubtract.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            btnSubtract.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            btnSubtract.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            btnSubtract.ForeColor = System.Drawing.SystemColors.ControlText;
            btnSubtract.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            btnSubtract.Location = new System.Drawing.Point(560, 193);
            btnSubtract.Margin = new System.Windows.Forms.Padding(0);
            btnSubtract.Name = "btnSubtract";
            btnSubtract.Size = new System.Drawing.Size(54, 31);
            btnSubtract.TabIndex = 44;
            btnSubtract.Text = "▶";
            btnSubtract.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(194)))), ((int)(((byte)(229)))));
            btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            btnAdd.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            btnAdd.ForeColor = System.Drawing.SystemColors.ControlText;
            btnAdd.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            btnAdd.Location = new System.Drawing.Point(560, 138);
            btnAdd.Margin = new System.Windows.Forms.Padding(0);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(54, 31);
            btnAdd.TabIndex = 41;
            btnAdd.Text = "◀";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // lblAddList
            // 
            this.lblAddList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(152)))), ((int)(((byte)(216)))));
            this.lblAddList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAddList.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAddList.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblAddList.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblAddList.Location = new System.Drawing.Point(0, 0);
            this.lblAddList.Margin = new System.Windows.Forms.Padding(0);
            this.lblAddList.Name = "lblAddList";
            this.lblAddList.Size = new System.Drawing.Size(1152, 31);
            this.lblAddList.TabIndex = 45;
            this.lblAddList.Text = "할당 공정 목록";
            this.lblAddList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlAll
            // 
            this.pnlAll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAll.Controls.Add(this.lblAll);
            this.pnlAll.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pnlAll.Location = new System.Drawing.Point(649, 30);
            this.pnlAll.Margin = new System.Windows.Forms.Padding(0);
            this.pnlAll.Name = "pnlAll";
            this.pnlAll.Size = new System.Drawing.Size(503, 317);
            this.pnlAll.TabIndex = 43;
            // 
            // lblAll
            // 
            this.lblAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(194)))), ((int)(((byte)(229)))));
            this.lblAll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAll.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAll.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblAll.Location = new System.Drawing.Point(0, 0);
            this.lblAll.Margin = new System.Windows.Forms.Padding(0);
            this.lblAll.Name = "lblAll";
            this.lblAll.Size = new System.Drawing.Size(501, 31);
            this.lblAll.TabIndex = 17;
            this.lblAll.Text = "전체 공정 목록";
            this.lblAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlCrud
            // 
            this.pnlCrud.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCrud.Controls.Add(this.btnReadBottom);
            this.pnlCrud.Controls.Add(this.btnClose);
            this.pnlCrud.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pnlCrud.Location = new System.Drawing.Point(649, 357);
            this.pnlCrud.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCrud.Name = "pnlCrud";
            this.pnlCrud.Size = new System.Drawing.Size(503, 49);
            this.pnlCrud.TabIndex = 40;
            // 
            // btnReadBottom
            // 
            this.btnReadBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReadBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(194)))), ((int)(((byte)(229)))));
            this.btnReadBottom.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReadBottom.Font = new System.Drawing.Font("나눔고딕", 9.75F);
            this.btnReadBottom.Image = global::MES_Team3.Properties.Resources.Data_Find12;
            this.btnReadBottom.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnReadBottom.Location = new System.Drawing.Point(288, 1);
            this.btnReadBottom.Margin = new System.Windows.Forms.Padding(0);
            this.btnReadBottom.Name = "btnReadBottom";
            this.btnReadBottom.Size = new System.Drawing.Size(84, 48);
            this.btnReadBottom.TabIndex = 85;
            this.btnReadBottom.Text = "조회";
            this.btnReadBottom.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReadBottom.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(194)))), ((int)(((byte)(229)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("나눔고딕", 9.75F);
            this.btnClose.Image = global::MES_Team3.Properties.Resources.Delete;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClose.Location = new System.Drawing.Point(419, 1);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 48);
            this.btnClose.TabIndex = 86;
            this.btnClose.Text = "닫기";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // pnlAdd
            // 
            this.pnlAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlAdd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAdd.Controls.Add(this.lblAdd);
            this.pnlAdd.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pnlAdd.Location = new System.Drawing.Point(0, 30);
            this.pnlAdd.Margin = new System.Windows.Forms.Padding(0);
            this.pnlAdd.Name = "pnlAdd";
            this.pnlAdd.Size = new System.Drawing.Size(516, 317);
            this.pnlAdd.TabIndex = 42;
            // 
            // lblAdd
            // 
            this.lblAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(194)))), ((int)(((byte)(229)))));
            this.lblAdd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAdd.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAdd.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblAdd.Location = new System.Drawing.Point(0, 0);
            this.lblAdd.Margin = new System.Windows.Forms.Padding(0);
            this.lblAdd.Name = "lblAdd";
            this.lblAdd.Size = new System.Drawing.Size(514, 31);
            this.lblAdd.TabIndex = 17;
            this.lblAdd.Text = "할당 공정 목록";
            this.lblAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Base3_1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(243)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1152, 739);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.spcBase);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Base3_1";
            this.Text = "Base3_1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.spcBase.Panel1.ResumeLayout(false);
            this.spcBase.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcBase)).EndInit();
            this.spcBase.ResumeLayout(false);
            this.pnlDgv.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlAll.ResumeLayout(false);
            this.pnlCrud.ResumeLayout(false);
            this.pnlAdd.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel pnlTop;
        public System.Windows.Forms.TextBox txtSearch;
        public System.Windows.Forms.SplitContainer spcBase;
        public System.Windows.Forms.Panel pnlDgv;
        public System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.Panel pnlSearch;
        public System.Windows.Forms.Label lblPanel;
        public System.Windows.Forms.Panel pnlAll;
        public System.Windows.Forms.Label lblAll;
        public System.Windows.Forms.Panel pnlCrud;
        public System.Windows.Forms.Button btnReadBottom;
        public System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.Panel pnlAdd;
        public System.Windows.Forms.Label lblAdd;
        public System.Windows.Forms.Label lblAddList;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button btnTxtSearch;
        public System.Windows.Forms.Button btnReadTop;
        public System.Windows.Forms.Button btnSubtract;
        public System.Windows.Forms.Button btnAdd;
    }
}