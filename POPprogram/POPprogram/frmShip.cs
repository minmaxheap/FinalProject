using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DAC;

namespace POPprogram
{
    public partial class frmShip : POPprogram.Base2
    {
        public frmShip()
        {
            InitializeComponent();
        }

        private void btnTxtSearch_Click(object sender, EventArgs e)
        {
            frmShipSearch frm = new frmShipSearch();
            if (frm.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            txtSearch.Text = frmShipSearch.vo.SALES_ORDER_ID;
            txtCode1.Text = frmShipSearch.vo.PRODUCT_CODE;
            txtCode2.Text = frmShipSearch.vo.CUSTOMER_CODE;
            txtCode3.Text = frmShipSearch.vo.ORDER_QTY.ToString();
            txtName1.Text = frmShipSearch.vo.PRODUCT_NAME;
            txtName2.Text = frmShipSearch.vo.CUSTOMER_NAME;
        }

        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }

        private void btnReadTop_Click(object sender, EventArgs e)
        {

        }
    }
}
