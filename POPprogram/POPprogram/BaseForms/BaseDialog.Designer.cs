
namespace POPprogram
{
    partial class BaseDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseDialog));
            this.btnSelect = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblPanel = new System.Windows.Forms.Label();
            this.btnTxtSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSelect.AutoSize = true;
            this.btnSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
            this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelect.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelect.ImageIndex = 8;
            this.btnSelect.ImageList = this.imageList1;
            this.btnSelect.Location = new System.Drawing.Point(12, 456);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(0);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnSelect.Size = new System.Drawing.Size(140, 45);
            this.btnSelect.TabIndex = 94;
            this.btnSelect.Text = "선택  ";
            this.btnSelect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelect.UseVisualStyleBackColor = false;
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
            this.imageList1.Images.SetKeyName(8, "Addition .png");
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
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnClose.AutoSize = true;
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.ImageIndex = 9;
            this.btnClose.ImageList = this.imageList1;
            this.btnClose.Location = new System.Drawing.Point(875, 456);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnClose.Size = new System.Drawing.Size(140, 45);
            this.btnClose.TabIndex = 95;
            this.btnClose.Text = "닫기  ";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("나눔고딕", 14.25F);
            this.txtSearch.Location = new System.Drawing.Point(12, 57);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(335, 29);
            this.txtSearch.TabIndex = 92;
            // 
            // lblPanel
            // 
            this.lblPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lblPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPanel.Font = new System.Drawing.Font("나눔고딕", 15.75F);
            this.lblPanel.ForeColor = System.Drawing.Color.White;
            this.lblPanel.Location = new System.Drawing.Point(0, 0);
            this.lblPanel.Name = "lblPanel";
            this.lblPanel.Size = new System.Drawing.Size(1024, 43);
            this.lblPanel.TabIndex = 90;
            this.lblPanel.Text = "작업지시 선택";
            this.lblPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnTxtSearch
            // 
            this.btnTxtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
            this.btnTxtSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTxtSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTxtSearch.Font = new System.Drawing.Font("나눔고딕", 14.25F);
            this.btnTxtSearch.ImageIndex = 15;
            this.btnTxtSearch.ImageList = this.imageList1;
            this.btnTxtSearch.Location = new System.Drawing.Point(363, 58);
            this.btnTxtSearch.Name = "btnTxtSearch";
            this.btnTxtSearch.Size = new System.Drawing.Size(26, 26);
            this.btnTxtSearch.TabIndex = 96;
            this.btnTxtSearch.UseVisualStyleBackColor = false;
            // 
            // BaseDialog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(1024, 513);
            this.Controls.Add(this.btnTxtSearch);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblPanel);
            this.Font = new System.Drawing.Font("나눔고딕", 14.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "BaseDialog";
            this.Text = "BaseDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnSelect;
        public System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.TextBox txtSearch;
        public System.Windows.Forms.Label lblPanel;
        public System.Windows.Forms.Button btnTxtSearch;
        private System.Windows.Forms.ImageList imageList1;
    }
}