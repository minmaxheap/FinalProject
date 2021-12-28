
namespace MES_Team3.BaseForms
{
    partial class Base4
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
            System.Windows.Forms.Button button2;
            System.Windows.Forms.Button button1;
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.lblPanel = new System.Windows.Forms.Label();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlCrud = new System.Windows.Forms.Panel();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnReadBottom = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.pnlCrud.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(194)))), ((int)(((byte)(229)))));
            button2.BackgroundImage = global::MES_Team3.Properties.Resources.pngegg;
            button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            button2.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            button2.ForeColor = System.Drawing.SystemColors.ControlText;
            button2.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            button2.Location = new System.Drawing.Point(298, 3);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(32, 25);
            button2.TabIndex = 33;
            button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(194)))), ((int)(((byte)(229)))));
            button1.BackgroundImage = global::MES_Team3.Properties.Resources._refresh_90271;
            button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            button1.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            button1.ForeColor = System.Drawing.SystemColors.ControlText;
            button1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            button1.Location = new System.Drawing.Point(9, 4);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(32, 25);
            button1.TabIndex = 16;
            button1.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(194)))), ((int)(((byte)(229)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(805, 31);
            this.label1.TabIndex = 17;
            this.label1.Text = "공정 목록";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(152)))), ((int)(((byte)(216)))));
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(1168, 31);
            this.label9.TabIndex = 40;
            this.label9.Text = "할당 공정 목록";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.splitContainer1.Panel2.Controls.Add(this.pnlCrud);
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Panel2.Controls.Add(this.label9);
            this.splitContainer1.Size = new System.Drawing.Size(1168, 667);
            this.splitContainer1.SplitterDistance = 293;
            this.splitContainer1.TabIndex = 1;
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
            this.splitContainer2.Panel1.Controls.Add(this.panel3);
            this.splitContainer2.Panel1.Controls.Add(this.panel4);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(243)))), ((int)(((byte)(251)))));
            this.splitContainer2.Panel2.Controls.Add(this.searchPanel);
            this.splitContainer2.Panel2.Controls.Add(this.panel9);
            this.splitContainer2.Size = new System.Drawing.Size(1168, 293);
            this.splitContainer2.SplitterDistance = 805;
            this.splitContainer2.TabIndex = 35;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.textBox1);
            this.panel3.Controls.Add(button2);
            this.panel3.Controls.Add(button1);
            this.panel3.Location = new System.Drawing.Point(392, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(410, 40);
            this.panel3.TabIndex = 36;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(194)))), ((int)(((byte)(229)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button3.Location = new System.Drawing.Point(336, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(73, 25);
            this.button3.TabIndex = 19;
            this.button3.Text = "검색 조건";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("나눔고딕", 11.25F);
            this.textBox1.Location = new System.Drawing.Point(47, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(245, 25);
            this.textBox1.TabIndex = 15;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 66);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(805, 227);
            this.panel4.TabIndex = 36;
            // 
            // searchPanel
            // 
            this.searchPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
            this.searchPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchPanel.Location = new System.Drawing.Point(0, 36);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(359, 257);
            this.searchPanel.TabIndex = 35;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(194)))), ((int)(((byte)(229)))));
            this.panel9.Controls.Add(this.lblPanel);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(359, 36);
            this.panel9.TabIndex = 34;
            // 
            // lblPanel
            // 
            this.lblPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(194)))), ((int)(((byte)(229)))));
            this.lblPanel.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPanel.Location = new System.Drawing.Point(0, 0);
            this.lblPanel.Name = "lblPanel";
            this.lblPanel.Size = new System.Drawing.Size(276, 36);
            this.lblPanel.TabIndex = 29;
            this.lblPanel.Text = "▶ 검색 조건";
            this.lblPanel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer3.Location = new System.Drawing.Point(0, 31);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.panel5);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.panel2);
            this.splitContainer3.Panel2.Controls.Add(this.panel7);
            this.splitContainer3.Size = new System.Drawing.Size(1168, 254);
            this.splitContainer3.SplitterDistance = 660;
            this.splitContainer3.TabIndex = 41;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(660, 254);
            this.panel5.TabIndex = 37;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(194)))), ((int)(((byte)(229)))));
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(660, 31);
            this.label6.TabIndex = 17;
            this.label6.Text = "할당 공정 목록";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(504, 218);
            this.panel2.TabIndex = 35;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(194)))), ((int)(((byte)(229)))));
            this.panel7.Controls.Add(this.label2);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(504, 36);
            this.panel7.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(194)))), ((int)(((byte)(229)))));
            this.label2.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(421, 36);
            this.label2.TabIndex = 29;
            this.label2.Text = "▶ 속성";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.pnlCrud.Location = new System.Drawing.Point(625, 295);
            this.pnlCrud.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCrud.Name = "pnlCrud";
            this.pnlCrud.Size = new System.Drawing.Size(543, 66);
            this.pnlCrud.TabIndex = 42;
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
            // Base4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(243)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1168, 667);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Base4";
            this.Text = "Base4";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.pnlCrud.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.SplitContainer splitContainer2;
        public System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.SplitContainer splitContainer3;
        public System.Windows.Forms.Panel panel5;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Button button3;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.Panel searchPanel;
        public System.Windows.Forms.Label lblPanel;
        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Panel panel9;
        public System.Windows.Forms.Panel panel7;
        public System.Windows.Forms.Panel pnlCrud;
        public System.Windows.Forms.Button btnInsert;
        public System.Windows.Forms.Button btnDelete;
        public System.Windows.Forms.Button btnClear;
        public System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.Button btnReadBottom;
        public System.Windows.Forms.Button btnUpdate;
    }
}