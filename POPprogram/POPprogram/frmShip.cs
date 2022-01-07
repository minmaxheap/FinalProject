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
        int cnt=0;
        int qty = 0;
        object dummy;
        public frmShip()
        {
            InitializeComponent();
        }
        private void frmShip_Load(object sender, EventArgs e)
        {
            DataGridViewUtil.SetInitGridView(csDataGridView1);
            DataGridViewCheckBoxColumn checkbox1 = new DataGridViewCheckBoxColumn();
            checkbox1.Name = "CheckBox";
            csDataGridView1.Columns.Add(checkbox1);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "순번", "RowNum", DataGridViewContentAlignment.MiddleCenter, 100);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "LOT_ID", "LOT_ID", DataGridViewContentAlignment.MiddleCenter, 150);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "수량", "LOT_QTY", DataGridViewContentAlignment.MiddleCenter, 100);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "창고 입고시간", "OPER_IN_TIME",DataGridViewContentAlignment.MiddleCenter, 150);

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
            if (txtSearch.Text=="")
            {
                MessageBox.Show("주문서를 선택해 주세요.");
                return;
            }
            ShipProperty vo = new ShipProperty();
            vo.PRODUCT_CODE = txtCode1.Text;
            ShipServ serv = new ShipServ();
            List<ShipPropertySch> list =  serv.GetFSStoreList(vo);
            DataTable dt = ConvertToDataTable(list);
            dt.Columns.Add("RowNum").SetOrdinal(0);
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["RowNum"].ToString() == "")
                {
                    dr["RowNum"] =dt.Rows.IndexOf(dr)+1; 
                }
            }
            csDataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            csDataGridView1.DataSource = null;
            csDataGridView1.DataSource = dt;
            csDataGridView1.CurrentCell = null;
        }

        private void csDataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToBoolean(csDataGridView1.CurrentRow.Cells["CheckBox"].Value) == true)
            {
                cnt += 1;
                dummy=csDataGridView1.CurrentRow.Cells["LOT_QTY"].Value;
                int convertedInt = Convert.ToInt32(dummy);
                qty = qty + convertedInt;
                textBox1.Text = Convert.ToString(cnt);
                textBox2.Text = Convert.ToString(qty);
            }
            else
            {
                cnt -= 1;
                dummy = csDataGridView1.CurrentRow.Cells["LOT_QTY"].Value;
                int convertedInt = Convert.ToInt32(dummy);
                qty = qty - convertedInt;
                textBox1.Text = Convert.ToString(cnt);
                textBox2.Text = Convert.ToString(qty);
            }
        }

        private void csDataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (csDataGridView1.IsCurrentCellDirty)
                csDataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
    }
}
