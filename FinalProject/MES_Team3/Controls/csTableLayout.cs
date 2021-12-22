using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MES_Team3
{
    public partial class csTableLayout : TableLayoutPanel
    {
        public csTableLayout()
        {
            InitializeComponent();

         
            Label lbl1 = new System.Windows.Forms.Label();
         
            Label lbl2 = new System.Windows.Forms.Label();

            Label lbl4 = new System.Windows.Forms.Label();
            Label lbl3 = new System.Windows.Forms.Label();
   
            Label lbl5 = new System.Windows.Forms.Label();

            Label lbl6 = new System.Windows.Forms.Label();

            Label lbl7 = new System.Windows.Forms.Label();

            this.ColumnCount = 2;
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.68904F));
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.31096F));

            this.Controls.Add(lbl7, 0, 6);
            this.Controls.Add(lbl6, 0, 5);

            this.Controls.Add(lbl2, 0, 1);
            this.Controls.Add(lbl1, 0, 0);

            this.Controls.Add(lbl3, 0, 2);
            this.Controls.Add(lbl4, 0, 3);

            this.Controls.Add(lbl5, 0, 4);

            this.RowCount = 7;
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Size = new System.Drawing.Size(283, 143);
            this.TabIndex = 0;
       
            // 
            // txt2
            // 

            // 
            // lbl1
            // 
            lbl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            lbl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lbl1.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            lbl1.Location = new System.Drawing.Point(0, 0);
            lbl1.Margin = new System.Windows.Forms.Padding(0);
            lbl1.Name = "lbl1";
            lbl1.Size = new System.Drawing.Size(100, 20);
            lbl1.TabIndex = 42;
            lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt1
            // 

            // 
            // lbl2
            // 
            lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            lbl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lbl2.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            lbl2.Location = new System.Drawing.Point(0, 20);
            lbl2.Margin = new System.Windows.Forms.Padding(0);
            lbl2.Name = "lbl2";
            lbl2.Size = new System.Drawing.Size(100, 20);
            lbl2.TabIndex = 40;
            lbl2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt3
            // 

            // 
            // lbl4
            // 
            lbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            lbl4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lbl4.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            lbl4.Location = new System.Drawing.Point(0, 60);
            lbl4.Margin = new System.Windows.Forms.Padding(0);
            lbl4.Name = "lbl4";
            lbl4.Size = new System.Drawing.Size(100, 20);
            lbl4.TabIndex = 44;
            lbl4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            

            
            lbl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            lbl3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lbl3.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            lbl3.Location = new System.Drawing.Point(0, 40);
            lbl3.Margin = new System.Windows.Forms.Padding(0);
            lbl3.Name = "lbl3";
            lbl3.Size = new System.Drawing.Size(100, 20);
            lbl3.TabIndex = 46;
            lbl3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            

            

            

            
            lbl5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            lbl5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lbl5.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            lbl5.Location = new System.Drawing.Point(0, 80);
            lbl5.Margin = new System.Windows.Forms.Padding(0);
            lbl5.Name = "lbl5";
            lbl5.Size = new System.Drawing.Size(100, 20);
            lbl5.TabIndex = 48;
            lbl5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            


            

            
            lbl6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            lbl6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lbl6.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            lbl6.Location = new System.Drawing.Point(0, 100);
            lbl6.Margin = new System.Windows.Forms.Padding(0);
            lbl6.Name = "lbl6";
            lbl6.Size = new System.Drawing.Size(100, 20);
            lbl6.TabIndex = 50;
            lbl6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            



            
            lbl7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            lbl7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lbl7.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            lbl7.Location = new System.Drawing.Point(0, 120);
            lbl7.Margin = new System.Windows.Forms.Padding(0);
            lbl7.Name = "lbl7";
            lbl7.Size = new System.Drawing.Size(100, 20);
            lbl7.TabIndex = 52;
            lbl7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            




        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
