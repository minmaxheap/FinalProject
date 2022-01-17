using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace POPprogram
{
    class DataGridViewUtil
    {
        public static void SetInitGridView(DataGridView dgv)
        {
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AllowUserToAddRows = false;
            dgv.AutoGenerateColumns = false;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.RowHeadersVisible = false;
        }

        public static void AddGridTextColumn(DataGridView dgv,
            string headerText,
            string propertyName,
             DataGridViewContentAlignment align = DataGridViewContentAlignment.MiddleLeft,
            int width = 100,
            bool visibility = true,
            bool frozen = false)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.HeaderText = headerText;
            col.Name = propertyName;
            //dgv.Columns[propertyName].DefaultCellStyle.Format = "#,###";
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col.DataPropertyName = propertyName;
            col.DefaultCellStyle.Alignment = align;
            col.Width = width;
            col.Visible = visibility;
            col.Frozen = frozen;
            col.ReadOnly = true;
            dgv.Columns.Add(col);
        }
    }
}
