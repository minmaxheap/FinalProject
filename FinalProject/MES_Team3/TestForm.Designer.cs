
namespace MES_Team3
{
    partial class TestForm
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
            this.csTableLayout1 = new MES_Team3.csTableLayout();
            this.csTextBox1 = new MES_Team3.csTextBox();
            this.csLabel1 = new MES_Team3.csLabel();
            this.csTableLayout1.SuspendLayout();
            this.SuspendLayout();
            // 
            // csTableLayout1
            // 
            this.csTableLayout1.ColumnCount = 2;
            this.csTableLayout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.68904F));
            this.csTableLayout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.31095F));
            this.csTableLayout1.Controls.Add(this.csTextBox1, 1, 0);
            this.csTableLayout1.Controls.Add(this.csLabel1, 1, 1);
            this.csTableLayout1.Location = new System.Drawing.Point(328, 208);
            this.csTableLayout1.Name = "csTableLayout1";
            this.csTableLayout1.RowCount = 2;
            this.csTableLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.csTableLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.csTableLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.csTableLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.csTableLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.csTableLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.csTableLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.csTableLayout1.Size = new System.Drawing.Size(283, 143);
            this.csTableLayout1.TabIndex = 0;
            // 
            // csTextBox1
            // 
            this.csTextBox1.Font = new System.Drawing.Font("나눔고딕", 8.249999F);
            this.csTextBox1.Location = new System.Drawing.Point(100, 0);
            this.csTextBox1.Margin = new System.Windows.Forms.Padding(0);
            this.csTextBox1.Name = "csTextBox1";
            this.csTextBox1.Size = new System.Drawing.Size(183, 20);
            this.csTextBox1.TabIndex = 53;
            // 
            // csLabel1
            // 
            this.csLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.csLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.csLabel1.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.csLabel1.Location = new System.Drawing.Point(100, 21);
            this.csLabel1.Margin = new System.Windows.Forms.Padding(0);
            this.csLabel1.Name = "csLabel1";
            this.csLabel1.Size = new System.Drawing.Size(183, 20);
            this.csLabel1.TabIndex = 54;
            this.csLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.csTableLayout1);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.Load += new System.EventHandler(this.TestForm_Load);
            this.csTableLayout1.ResumeLayout(false);
            this.csTableLayout1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private csTableLayout csTableLayout1;
        private csTextBox csTextBox1;
        private csLabel csLabel1;
    }
}