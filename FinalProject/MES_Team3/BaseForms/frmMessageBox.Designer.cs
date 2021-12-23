
namespace MES_Team3
{
    partial class frmMessageBox
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
            this.btnYes = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.lblContent = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnYes
            // 
            this.btnYes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(194)))), ((int)(((byte)(229)))));
            this.btnYes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnYes.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnYes.Location = new System.Drawing.Point(57, 84);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(70, 31);
            this.btnYes.TabIndex = 25;
            this.btnYes.Text = "예";
            this.btnYes.UseVisualStyleBackColor = false;
            // 
            // btnNo
            // 
            this.btnNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(194)))), ((int)(((byte)(229)))));
            this.btnNo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNo.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnNo.Location = new System.Drawing.Point(182, 84);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(70, 31);
            this.btnNo.TabIndex = 26;
            this.btnNo.Text = "아니오";
            this.btnNo.UseVisualStyleBackColor = false;
            // 
            // lblContent
            // 
            this.lblContent.Location = new System.Drawing.Point(38, 35);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(237, 46);
            this.lblContent.TabIndex = 27;
            this.lblContent.Text = "메시지 어투도 정의하는 게 좋다셨는데..";
            // 
            // frmMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(243)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(312, 129);
            this.Controls.Add(this.lblContent);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnYes);
            this.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMessageBox";
            this.Text = "caption";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button btnYes;
        public System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.Label lblContent;
    }
}