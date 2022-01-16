using System;
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
            this.ColumnHeadersHeight = 35;
            
           

            this.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(214, 220, 229);
            this.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
           this.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(214, 220, 229);
            this.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
            this.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("나눔고딕", 10F);
            this.BackgroundColor = Color.FromArgb(237, 243, 251);
            this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.DefaultCellStyle.BackColor = Color.White;
            this.DefaultCellStyle.ForeColor = Color.Black;
            this.DefaultCellStyle.SelectionBackColor = Color.FromArgb(244, 246, 249);
            this.DefaultCellStyle.SelectionForeColor = Color.Black;
            this.DefaultCellStyle.Font =  new System.Drawing.Font("나눔고딕", 9F);
            this.BackgroundColor = Color.White;
            this.RowTemplate.Height = 30;


            this.RowHeadersDefaultCellStyle.SelectionBackColor = SystemColors.ControlDark;
            this.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(244, 246, 249);
            this.BorderStyle = BorderStyle.None;
            
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
