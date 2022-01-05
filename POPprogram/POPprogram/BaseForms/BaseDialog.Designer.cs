
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
            this.btnSelect = new System.Windows.Forms.Button();
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
            this.btnSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(194)))), ((int)(((byte)(229)))));
            this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelect.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnSelect.Image = global::POPprogram.Properties.Resources.Add_New;
            this.btnSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelect.Location = new System.Drawing.Point(12, 456);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(110, 45);
            this.btnSelect.TabIndex = 94;
            this.btnSelect.Text = "선택";
            this.btnSelect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelect.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnClose.AutoSize = true;
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(194)))), ((int)(((byte)(229)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnClose.Image = global::POPprogram.Properties.Resources.Delete;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(902, 456);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 45);
            this.btnClose.TabIndex = 95;
            this.btnClose.Text = "닫기";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtSearch.Location = new System.Drawing.Point(12, 59);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(335, 25);
            this.txtSearch.TabIndex = 92;
            // 
            // lblPanel
            // 
            this.lblPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(152)))), ((int)(((byte)(216)))));
            this.lblPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPanel.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblPanel.Location = new System.Drawing.Point(0, 0);
            this.lblPanel.Name = "lblPanel";
            this.lblPanel.Size = new System.Drawing.Size(1024, 43);
            this.lblPanel.TabIndex = 90;
            this.lblPanel.Text = "작업지시 선택";
            this.lblPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnTxtSearch
            // 
            this.btnTxtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(194)))), ((int)(((byte)(229)))));
            this.btnTxtSearch.BackgroundImage = global::POPprogram.Properties.Resources.Search_Find;
            this.btnTxtSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTxtSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTxtSearch.Location = new System.Drawing.Point(363, 58);
            this.btnTxtSearch.Name = "btnTxtSearch";
            this.btnTxtSearch.Size = new System.Drawing.Size(26, 26);
            this.btnTxtSearch.TabIndex = 96;
            this.btnTxtSearch.UseVisualStyleBackColor = false;
            // 
            // BaseDialog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1024, 513);
            this.Controls.Add(this.btnTxtSearch);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblPanel);
            this.Font = new System.Drawing.Font("나눔고딕", 14.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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
    }
}