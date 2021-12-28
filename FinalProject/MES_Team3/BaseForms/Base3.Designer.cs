
namespace MES_Team3.BaseForms
{
    partial class Base3
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
            System.Windows.Forms.Button btnTxtSearch;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Base3));
            System.Windows.Forms.Button btnReadTop;
            System.Windows.Forms.Button btnSubtract;
            System.Windows.Forms.Button btnAdd;
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearchPnl = new System.Windows.Forms.Button();
            this.pnlDgv = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.pnlTopLbl = new System.Windows.Forms.Panel();
            this.lblPanel = new System.Windows.Forms.Label();
            this.lblAddList = new System.Windows.Forms.Label();
            this.pnlAll = new System.Windows.Forms.Panel();
            this.lblAll = new System.Windows.Forms.Label();
            this.pnlAdd = new System.Windows.Forms.Panel();
            this.lblAdd = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnReadBottom = new System.Windows.Forms.Button();
            btnTxtSearch = new System.Windows.Forms.Button();
            btnReadTop = new System.Windows.Forms.Button();
            btnSubtract = new System.Windows.Forms.Button();
            btnAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlDgv.SuspendLayout();
            this.pnlTopLbl.SuspendLayout();
            this.pnlAll.SuspendLayout();
            this.pnlAdd.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(243)))), ((int)(((byte)(251)))));
            this.splitContainer1.Panel2.Controls.Add(this.lblAddList);
            this.splitContainer1.Panel2.Controls.Add(btnSubtract);
            this.splitContainer1.Panel2.Controls.Add(btnAdd);
            this.splitContainer1.Panel2.Controls.Add(this.pnlAll);
            this.splitContainer1.Panel2.Controls.Add(this.pnlAdd);
            this.splitContainer1.Panel2.Controls.Add(this.panel6);
            this.splitContainer1.Size = new System.Drawing.Size(1168, 667);
            this.splitContainer1.SplitterDistance = 300;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(243)))), ((int)(((byte)(251)))));
            this.splitContainer2.Panel1.Controls.Add(this.pnlTop);
            this.splitContainer2.Panel1.Controls.Add(this.pnlDgv);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(243)))), ((int)(((byte)(251)))));
            this.splitContainer2.Panel2.Controls.Add(this.pnlSearch);
            this.splitContainer2.Panel2.Controls.Add(this.pnlTopLbl);
            this.splitContainer2.Size = new System.Drawing.Size(1168, 300);
            this.splitContainer2.SplitterDistance = 816;
            this.splitContainer2.TabIndex = 35;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.txtSearch);
            this.pnlTop.Controls.Add(this.btnSearchPnl);
            this.pnlTop.Controls.Add(btnTxtSearch);
            this.pnlTop.Controls.Add(btnReadTop);
            this.pnlTop.Location = new System.Drawing.Point(393, 3);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(410, 30);
            this.pnlTop.TabIndex = 40;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtSearch.Location = new System.Drawing.Point(44, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(244, 26);
            this.txtSearch.TabIndex = 50;
            // 
            // btnSearchPnl
            // 
            this.btnSearchPnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(194)))), ((int)(((byte)(229)))));
            this.btnSearchPnl.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearchPnl.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSearchPnl.Location = new System.Drawing.Point(332, 2);
            this.btnSearchPnl.Name = "btnSearchPnl";
            this.btnSearchPnl.Size = new System.Drawing.Size(73, 26);
            this.btnSearchPnl.TabIndex = 48;
            this.btnSearchPnl.Text = "검색 조건";
            this.btnSearchPnl.UseVisualStyleBackColor = false;
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
            btnTxtSearch.Location = new System.Drawing.Point(294, 2);
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
            btnReadTop.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            btnReadTop.ForeColor = System.Drawing.SystemColors.ControlText;
            btnReadTop.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            btnReadTop.Location = new System.Drawing.Point(5, 2);
            btnReadTop.Name = "btnReadTop";
            btnReadTop.Size = new System.Drawing.Size(33, 26);
            btnReadTop.TabIndex = 47;
            btnReadTop.UseVisualStyleBackColor = false;
            // 
            // pnlDgv
            // 
            this.pnlDgv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDgv.Controls.Add(this.lblTitle);
            this.pnlDgv.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDgv.Location = new System.Drawing.Point(0, 73);
            this.pnlDgv.Name = "pnlDgv";
            this.pnlDgv.Size = new System.Drawing.Size(816, 227);
            this.pnlDgv.TabIndex = 36;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(194)))), ((int)(((byte)(229)))));
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(814, 31);
            this.lblTitle.TabIndex = 17;
            this.lblTitle.Text = "공정 목록";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlSearch
            // 
            this.pnlSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
            this.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSearch.Location = new System.Drawing.Point(0, 36);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(359, 264);
            this.pnlSearch.TabIndex = 33;
            // 
            // pnlTopLbl
            // 
            this.pnlTopLbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(194)))), ((int)(((byte)(229)))));
            this.pnlTopLbl.Controls.Add(this.lblPanel);
            this.pnlTopLbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopLbl.Location = new System.Drawing.Point(0, 0);
            this.pnlTopLbl.Name = "pnlTopLbl";
            this.pnlTopLbl.Size = new System.Drawing.Size(348, 36);
            this.pnlTopLbl.TabIndex = 1;
            // 
            // lblPanel
            // 
            this.lblPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(194)))), ((int)(((byte)(229)))));
            this.lblPanel.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPanel.Location = new System.Drawing.Point(0, 0);
            this.lblPanel.Name = "lblPanel";
            this.lblPanel.Size = new System.Drawing.Size(359, 36);
            this.lblPanel.TabIndex = 29;
            this.lblPanel.Text = "▶ 검색 조건";
            this.lblPanel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAddList
            // 
            this.lblAddList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(152)))), ((int)(((byte)(216)))));
            this.lblAddList.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAddList.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAddList.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblAddList.Location = new System.Drawing.Point(0, 0);
            this.lblAddList.Name = "lblAddList";
            this.lblAddList.Size = new System.Drawing.Size(1168, 31);
            this.lblAddList.TabIndex = 40;
            this.lblAddList.Text = "할당 공정 목록";
            this.lblAddList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSubtract
            // 
            btnSubtract.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(194)))), ((int)(((byte)(229)))));
            btnSubtract.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            btnSubtract.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            btnSubtract.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            btnSubtract.ForeColor = System.Drawing.SystemColors.ControlText;
            btnSubtract.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            btnSubtract.Location = new System.Drawing.Point(569, 180);
            btnSubtract.Name = "btnSubtract";
            btnSubtract.Size = new System.Drawing.Size(32, 31);
            btnSubtract.TabIndex = 39;
            btnSubtract.Text = "▶";
            btnSubtract.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(194)))), ((int)(((byte)(229)))));
            btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            btnAdd.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            btnAdd.ForeColor = System.Drawing.SystemColors.ControlText;
            btnAdd.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            btnAdd.Location = new System.Drawing.Point(570, 90);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(32, 31);
            btnAdd.TabIndex = 34;
            btnAdd.Text = "◀";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // pnlAll
            // 
            this.pnlAll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAll.Controls.Add(this.lblAll);
            this.pnlAll.Location = new System.Drawing.Point(688, 59);
            this.pnlAll.Name = "pnlAll";
            this.pnlAll.Size = new System.Drawing.Size(448, 228);
            this.pnlAll.TabIndex = 38;
            // 
            // lblAll
            // 
            this.lblAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(194)))), ((int)(((byte)(229)))));
            this.lblAll.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAll.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAll.Location = new System.Drawing.Point(0, 0);
            this.lblAll.Name = "lblAll";
            this.lblAll.Size = new System.Drawing.Size(446, 31);
            this.lblAll.TabIndex = 17;
            this.lblAll.Text = "전체 공정 목록";
            this.lblAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlAdd
            // 
            this.pnlAdd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAdd.Controls.Add(this.lblAdd);
            this.pnlAdd.Location = new System.Drawing.Point(30, 59);
            this.pnlAdd.Name = "pnlAdd";
            this.pnlAdd.Size = new System.Drawing.Size(448, 228);
            this.pnlAdd.TabIndex = 37;
            // 
            // lblAdd
            // 
            this.lblAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(194)))), ((int)(((byte)(229)))));
            this.lblAdd.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAdd.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAdd.Location = new System.Drawing.Point(0, 0);
            this.lblAdd.Name = "lblAdd";
            this.lblAdd.Size = new System.Drawing.Size(446, 31);
            this.lblAdd.TabIndex = 17;
            this.lblAdd.Text = "할당 공정 목록";
            this.lblAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnClose);
            this.panel6.Controls.Add(this.btnReadBottom);
            this.panel6.Location = new System.Drawing.Point(793, 293);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(343, 66);
            this.panel6.TabIndex = 29;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(194)))), ((int)(((byte)(229)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.Image = global::MES_Team3.Properties.Resources.Delete;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClose.Location = new System.Drawing.Point(276, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(67, 48);
            this.btnClose.TabIndex = 84;
            this.btnClose.Text = "닫기";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // btnReadBottom
            // 
            this.btnReadBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReadBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(194)))), ((int)(((byte)(229)))));
            this.btnReadBottom.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReadBottom.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnReadBottom.Image = global::MES_Team3.Properties.Resources.Data_Find12;
            this.btnReadBottom.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnReadBottom.Location = new System.Drawing.Point(203, 10);
            this.btnReadBottom.Name = "btnReadBottom";
            this.btnReadBottom.Size = new System.Drawing.Size(67, 48);
            this.btnReadBottom.TabIndex = 80;
            this.btnReadBottom.Text = "조회";
            this.btnReadBottom.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReadBottom.UseVisualStyleBackColor = false;
            // 
            // Base3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(243)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1168, 667);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Base3";
            this.Text = "Base3";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlDgv.ResumeLayout(false);
            this.pnlTopLbl.ResumeLayout(false);
            this.pnlAll.ResumeLayout(false);
            this.pnlAdd.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.SplitContainer splitContainer2;
        public System.Windows.Forms.Panel pnlDgv;
        public System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.Panel pnlAll;
        public System.Windows.Forms.Label lblAll;
        public System.Windows.Forms.Panel pnlAdd;
        public System.Windows.Forms.Label lblAdd;
        public System.Windows.Forms.Panel panel6;
        public System.Windows.Forms.Label lblAddList;
        public System.Windows.Forms.Label lblPanel;
        public System.Windows.Forms.Panel pnlSearch;
        public System.Windows.Forms.Panel pnlTopLbl;
        public System.Windows.Forms.Panel pnlTop;
        public System.Windows.Forms.TextBox txtSearch;
        public System.Windows.Forms.Button btnSearchPnl;
        public System.Windows.Forms.Button btnReadBottom;
        public System.Windows.Forms.Button btnClose;
    }
}