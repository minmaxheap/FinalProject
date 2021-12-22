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
        private static void AddRowToPanel(TableLayoutPanel panel, string[] rowElements)
        {
            if (panel.ColumnCount != rowElements.Length)
                throw new Exception("Elements number doesn't match!");
            //get a reference to the previous existent row
            RowStyle temp = panel.RowStyles[panel.RowCount - 1];
            //increase panel rows count by one
            panel.RowCount++;
            //add a new RowStyle as a copy of the previous one
            panel.RowStyles.Add(new RowStyle(temp.SizeType, temp.Height));
            //add the control
            for (int i = 0; i < rowElements.Length; i++)
            {
                panel.Controls.Add(new Label() { Text = rowElements[i] }, i, panel.RowCount - 1);
            }
        }
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
            lbl.Name = $"{lbl}";
            lbl.Size = new System.Drawing.Size(100, 20);
            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        }
        public static void AddTableText(TableLayoutPanel tbl, TextBox txt
           )
        {

            txt.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            txt.Location = new System.Drawing.Point(0, 0);
            txt.Margin = new System.Windows.Forms.Padding(0);
            txt.Name = $"{txt}";
            txt.Size = new System.Drawing.Size(100, 20);

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
