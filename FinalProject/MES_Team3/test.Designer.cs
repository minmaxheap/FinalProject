﻿
namespace MES_Team3
{
    partial class test
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(test));
            System.Windows.Forms.Button btnTxtSearch;
            System.Windows.Forms.Button btnReadTop;
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.pnlCrud = new System.Windows.Forms.Panel();
            this.btnReadBottom = new System.Windows.Forms.Button();
            this.btnPanel = new System.Windows.Forms.Button();
            this.lblPanel = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.pnlProperty = new System.Windows.Forms.Panel();
            this.pnlTopLbl = new System.Windows.Forms.Panel();
            this.pnlDgv = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.spcBase = new System.Windows.Forms.SplitContainer();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearchPnl = new System.Windows.Forms.Button();
            this.pnlTop = new System.Windows.Forms.Panel();
            btnTxtSearch = new System.Windows.Forms.Button();
            btnReadTop = new System.Windows.Forms.Button();
            this.pnlCrud.SuspendLayout();
            this.pnlTopLbl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcBase)).BeginInit();
            this.spcBase.Panel1.SuspendLayout();
            this.spcBase.Panel2.SuspendLayout();
            this.spcBase.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInsert
            // 
            this.btnInsert.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInsert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(194)))), ((int)(((byte)(229)))));
            this.btnInsert.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnInsert.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnInsert.Image = global::MES_Team3.Properties.Resources.Add_New;
            this.btnInsert.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnInsert.Location = new System.Drawing.Point(106, 8);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(67, 48);
            this.btnInsert.TabIndex = 80;
            this.btnInsert.Text = "생성";
            this.btnInsert.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnInsert.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(194)))), ((int)(((byte)(229)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDelete.Image = global::MES_Team3.Properties.Resources.Trash_Can_02;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDelete.Location = new System.Drawing.Point(382, 8);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(67, 48);
            this.btnDelete.TabIndex = 78;
            this.btnDelete.Text = "삭제";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(194)))), ((int)(((byte)(229)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClear.Image = global::MES_Team3.Properties.Resources.Command_Refresh_01;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClear.Location = new System.Drawing.Point(290, 8);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(67, 48);
            this.btnClear.TabIndex = 82;
            this.btnClear.Text = "초기화";
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClear.UseVisualStyleBackColor = false;
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
            this.btnClose.Location = new System.Drawing.Point(474, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(67, 48);
            this.btnClose.TabIndex = 83;
            this.btnClose.Text = "닫기";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(194)))), ((int)(((byte)(229)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdate.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUpdate.Image = global::MES_Team3.Properties.Resources.Save_02;
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnUpdate.Location = new System.Drawing.Point(198, 8);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(67, 48);
            this.btnUpdate.TabIndex = 81;
            this.btnUpdate.Text = "변경";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUpdate.UseVisualStyleBackColor = false;
            // 
            // pnlCrud
            // 
            this.pnlCrud.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCrud.Controls.Add(this.btnInsert);
            this.pnlCrud.Controls.Add(this.btnDelete);
            this.pnlCrud.Controls.Add(this.btnClear);
            this.pnlCrud.Controls.Add(this.btnClose);
            this.pnlCrud.Controls.Add(this.btnReadBottom);
            this.pnlCrud.Controls.Add(this.btnUpdate);
            this.pnlCrud.Location = new System.Drawing.Point(714, 716);
            this.pnlCrud.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCrud.Name = "pnlCrud";
            this.pnlCrud.Size = new System.Drawing.Size(543, 66);
            this.pnlCrud.TabIndex = 43;
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
            this.btnReadBottom.Location = new System.Drawing.Point(14, 8);
            this.btnReadBottom.Name = "btnReadBottom";
            this.btnReadBottom.Size = new System.Drawing.Size(67, 48);
            this.btnReadBottom.TabIndex = 79;
            this.btnReadBottom.Text = "조회";
            this.btnReadBottom.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReadBottom.UseVisualStyleBackColor = false;
            // 
            // btnPanel
            // 
            this.btnPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPanel.BackColor = System.Drawing.Color.Transparent;
            this.btnPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPanel.BackgroundImage")));
            this.btnPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPanel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
            this.btnPanel.FlatAppearance.BorderSize = 0;
            this.btnPanel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(243)))), ((int)(((byte)(251)))));
            this.btnPanel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(243)))), ((int)(((byte)(251)))));
            this.btnPanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPanel.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPanel.ForeColor = System.Drawing.Color.Transparent;
            this.btnPanel.Location = new System.Drawing.Point(303, 0);
            this.btnPanel.Margin = new System.Windows.Forms.Padding(0);
            this.btnPanel.Name = "btnPanel";
            this.btnPanel.Size = new System.Drawing.Size(47, 36);
            this.btnPanel.TabIndex = 42;
            this.btnPanel.UseVisualStyleBackColor = false;
            // 
            // lblPanel
            // 
            this.lblPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(152)))), ((int)(((byte)(216)))));
            this.lblPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPanel.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPanel.Location = new System.Drawing.Point(0, 0);
            this.lblPanel.Name = "lblPanel";
            this.lblPanel.Size = new System.Drawing.Size(348, 36);
            this.lblPanel.TabIndex = 29;
            this.lblPanel.Text = "▶ 속성";
            this.lblPanel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlSearch
            // 
            this.pnlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
            this.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSearch.Location = new System.Drawing.Point(0, 37);
            this.pnlSearch.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(350, 596);
            this.pnlSearch.TabIndex = 31;
            // 
            // pnlProperty
            // 
            this.pnlProperty.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlProperty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
            this.pnlProperty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlProperty.Location = new System.Drawing.Point(0, 37);
            this.pnlProperty.Margin = new System.Windows.Forms.Padding(0);
            this.pnlProperty.Name = "pnlProperty";
            this.pnlProperty.Size = new System.Drawing.Size(336, 595);
            this.pnlProperty.TabIndex = 29;
            // 
            // pnlTopLbl
            // 
            this.pnlTopLbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(152)))), ((int)(((byte)(216)))));
            this.pnlTopLbl.Controls.Add(this.btnPanel);
            this.pnlTopLbl.Controls.Add(this.lblPanel);
            this.pnlTopLbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopLbl.Location = new System.Drawing.Point(0, 0);
            this.pnlTopLbl.Name = "pnlTopLbl";
            this.pnlTopLbl.Size = new System.Drawing.Size(357, 40);
            this.pnlTopLbl.TabIndex = 0;
            // 
            // pnlDgv
            // 
            this.pnlDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDgv.Location = new System.Drawing.Point(0, 36);
            this.pnlDgv.Margin = new System.Windows.Forms.Padding(0);
            this.pnlDgv.Name = "pnlDgv";
            this.pnlDgv.Size = new System.Drawing.Size(780, 597);
            this.pnlDgv.TabIndex = 18;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(194)))), ((int)(((byte)(229)))));
            this.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(780, 36);
            this.lblTitle.TabIndex = 17;
            this.lblTitle.Text = "title";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // spcBase
            // 
            this.spcBase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spcBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spcBase.Location = new System.Drawing.Point(110, 71);
            this.spcBase.Margin = new System.Windows.Forms.Padding(0);
            this.spcBase.Name = "spcBase";
            // 
            // spcBase.Panel1
            // 
            this.spcBase.Panel1.Controls.Add(this.pnlDgv);
            this.spcBase.Panel1.Controls.Add(this.lblTitle);
            // 
            // spcBase.Panel2
            // 
            this.spcBase.Panel2.Controls.Add(this.pnlSearch);
            this.spcBase.Panel2.Controls.Add(this.pnlProperty);
            this.spcBase.Panel2.Controls.Add(this.pnlTopLbl);
            this.spcBase.Size = new System.Drawing.Size(1147, 635);
            this.spcBase.SplitterDistance = 782;
            this.spcBase.SplitterWidth = 6;
            this.spcBase.TabIndex = 44;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtSearch.Location = new System.Drawing.Point(56, 1);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(244, 26);
            this.txtSearch.TabIndex = 50;
            // 
            // btnSearchPnl
            // 
            this.btnSearchPnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(194)))), ((int)(((byte)(229)))));
            this.btnSearchPnl.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearchPnl.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSearchPnl.Location = new System.Drawing.Point(344, 1);
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
            btnTxtSearch.Location = new System.Drawing.Point(306, 1);
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
            btnReadTop.Location = new System.Drawing.Point(12, 1);
            btnReadTop.Name = "btnReadTop";
            btnReadTop.Size = new System.Drawing.Size(33, 26);
            btnReadTop.TabIndex = 47;
            btnReadTop.UseVisualStyleBackColor = false;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.txtSearch);
            this.pnlTop.Controls.Add(this.btnSearchPnl);
            this.pnlTop.Controls.Add(btnTxtSearch);
            this.pnlTop.Controls.Add(btnReadTop);
            this.pnlTop.Location = new System.Drawing.Point(98, 30);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1168, 30);
            this.pnlTop.TabIndex = 42;
            // 
            // test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1365, 812);
            this.Controls.Add(this.spcBase);
            this.Controls.Add(this.pnlCrud);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "test";
            this.Text = "test";
            this.pnlCrud.ResumeLayout(false);
            this.pnlTopLbl.ResumeLayout(false);
            this.spcBase.Panel1.ResumeLayout(false);
            this.spcBase.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcBase)).EndInit();
            this.spcBase.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button btnInsert;
        public System.Windows.Forms.Button btnDelete;
        public System.Windows.Forms.Button btnClear;
        public System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.Button btnUpdate;
        public System.Windows.Forms.Panel pnlCrud;
        public System.Windows.Forms.Button btnReadBottom;
        public System.Windows.Forms.Button btnPanel;
        public System.Windows.Forms.Label lblPanel;
        public System.Windows.Forms.Panel pnlSearch;
        public System.Windows.Forms.Panel pnlProperty;
        public System.Windows.Forms.Panel pnlTopLbl;
        public System.Windows.Forms.Panel pnlDgv;
        public System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.SplitContainer spcBase;
        public System.Windows.Forms.TextBox txtSearch;
        public System.Windows.Forms.Button btnSearchPnl;
        public System.Windows.Forms.Panel pnlTop;
    }
}