﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POPprogram
{
    public partial class csDataGridView : DataGridView
    {
        public csDataGridView()
        {
            InitializeComponent();
            this.RowHeadersWidth = 30;
            this.EnableHeadersVisualStyles = false;
            //this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.ColumnHeadersHeight = 50;
            
           

            this.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(214, 220, 229);
            this.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
           this.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(214, 220, 229);
            this.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
            //this.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BackgroundColor = Color.FromArgb(237, 243, 251);


            this.DefaultCellStyle.BackColor = Color.White;
            this.DefaultCellStyle.ForeColor = Color.FromArgb(52, 52, 52);
            this.DefaultCellStyle.SelectionBackColor = Color.FromArgb(157, 195, 230);
            this.DefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;
            //his.DefaultCellStyle.Font = this.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BackgroundColor = Color.FromArgb(237, 243, 251);


            this.RowHeadersDefaultCellStyle.SelectionBackColor = SystemColors.ControlDark;
            this.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(233, 239, 247);
            this.BorderStyle = BorderStyle.None;
            
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
