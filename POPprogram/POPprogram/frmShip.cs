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

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ShipProperty vo = new ShipProperty();
                vo.SALES_ORDER_ID = txtSearch.Text;

                ShipServ serv = new ShipServ();
                List<ShipProperty> list = serv.GetSalesOrderSearch(vo);
                if (list !=null)
                {

                }
            }

        }
    }
}
