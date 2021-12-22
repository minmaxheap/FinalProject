using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MES_Team3
{
    class TableLayoutUtil
    {
        public static void SetInTableLayout(TableLayoutPanel tbl)
        {
            tbl.ColumnCount = 2;
            tbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.68904F));
            tbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.31096F));
            
            tbl.RowCount = 7;
            tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tbl.Size = new System.Drawing.Size(283, 143);
            //근데 문제는 이렇게 해서 custom control로 만들었을 때는 row가 여러 개가 안 만들어지더라 
        }

        public static void AddTableLabel(TableLayoutPanel tbl,
         Label lbl)
        {
            
            lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lbl.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            lbl.Location = new System.Drawing.Point(0, 0);
            lbl.Margin = new System.Windows.Forms.Padding(0);
            lbl.Name = "lbl1";
            lbl.Size = new System.Drawing.Size(100, 20);
            lbl.TabIndex = 42;
            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        }
        public static void AddTableText(TableLayoutPanel tbl
           )
        {
            
        }

        public static void AddTableCombo(TableLayoutPanel tbl
           )
        {

        }

        public static void AddTableDateTime(TableLayoutPanel tbl
           )
        {

        }

    }
}
