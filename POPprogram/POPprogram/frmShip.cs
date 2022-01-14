using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using DAC;

namespace POPprogram
{
    public partial class frmShip : POPprogram.Base2
    {
        string userID;
        int cnt=0;
        int qty = 0;
        object dummy;
        DataTable lotTable;
        List<ShipPropertySch> shipvolist;
        public frmShip()
        {
            InitializeComponent();
            userID = frmLogin.userID;
        }
        private void frmShip_Load(object sender, EventArgs e)
        {
            DataGridViewUtil.SetInitGridView(csDataGridView1);
            DataGridViewCheckBoxColumn checkbox1 = new DataGridViewCheckBoxColumn();
            checkbox1.Name = "";
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
            DataTable lotdt = serv.GetLOT();
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

            lotTable =lotdt;
            shipvolist = null;
            shipvolist = new List<ShipPropertySch>();
        
        }

        private void csDataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToBoolean(csDataGridView1.CurrentRow.Cells[""].Value) == true)
            {
                cnt += 1;
                dummy=csDataGridView1.CurrentRow.Cells["LOT_QTY"].Value;
                int convertedInt = Convert.ToInt32(dummy);
                qty = qty + convertedInt;
                textBox1.Text = Convert.ToString(cnt);
                textBox2.Text = Convert.ToString(qty);

                DataGridViewRow dr = csDataGridView1.Rows[e.RowIndex];
                //DataTable dt2 = GetDataGridViewAsDataTable(csDataGridView1);

                ShipPropertySch shipvo = new ShipPropertySch();

                if (dr.Cells["LOT_ID"].Value != null && dr.Cells["LOT_ID"].Value != DBNull.Value)
                    shipvo.LOT_ID = dr.Cells["LOT_ID"].Value.ToString();
                if (dr.Cells["LOT_QTY"].Value != null && dr.Cells["LOT_QTY"].Value != DBNull.Value)
                    shipvo.LOT_QTY = Convert.ToInt32(dr.Cells["LOT_QTY"].Value);
                if (dr.Cells["OPER_IN_TIME"].Value != null && dr.Cells["OPER_IN_TIME"].Value != DBNull.Value)
                    shipvo.OPER_IN_TIME = Convert.ToDateTime(dr.Cells["OPER_IN_TIME"].Value);

                shipvolist.Add(shipvo);
            }
            else
            {
                cnt -= 1;
                dummy = csDataGridView1.CurrentRow.Cells["LOT_QTY"].Value;
                int convertedInt = Convert.ToInt32(dummy);
                qty = qty - convertedInt;
                textBox1.Text = Convert.ToString(cnt);
                textBox2.Text = Convert.ToString(qty);

                DataGridViewRow dr = csDataGridView1.Rows[e.RowIndex];
                //DataTable dt2 = GetDataGridViewAsDataTable(csDataGridView1);

                ShipPropertySch shipvo = new ShipPropertySch();

                if (dr.Cells["LOT_ID"].Value != null && dr.Cells["LOT_ID"].Value != DBNull.Value)
                    shipvo.LOT_ID = dr.Cells["LOT_ID"].Value.ToString();
                if (dr.Cells["LOT_QTY"].Value != null && dr.Cells["LOT_QTY"].Value != DBNull.Value)
                    shipvo.LOT_QTY = Convert.ToInt32(dr.Cells["LOT_QTY"].Value);
                if (dr.Cells["OPER_IN_TIME"].Value != null && dr.Cells["OPER_IN_TIME"].Value != DBNull.Value)
                    shipvo.OPER_IN_TIME = Convert.ToDateTime(dr.Cells["OPER_IN_TIME"].Value);

                int result = FindIntListVOIndex(shipvolist, shipvo);
                shipvolist.RemoveAt(result);
            }
        }
        static int FindIntListVOIndex(List<ShipPropertySch> list, ShipPropertySch val)
        {
            if (list == null)
                return -1;
            for (int i = 0; i < list.Count; ++i)
            {
                if (list[i].LOT_ID == val.LOT_ID)
                    return i;
            }
            return -1;
        }
        static int FindIntListIndex(List<ShipPropertyUpdate> list, List<ShipPropertySch> val)
        {
            if (list == null)
                return -1;
            for (int i = 0; i < list.Count; ++i)         
            {
                if (i > val.Count-1)
                {
                    if (list[i].LOT_ID == val[val.Count-1].LOT_ID)
                        return i;
                }
                if (list[i].LOT_ID == val[i].LOT_ID)          
                    return i;   
       }
            

            return -1;
        }
        private void csDataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (csDataGridView1.IsCurrentCellDirty)
                csDataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        public DataTable GetEmptyTable(DataTable Pdt_Data)
        {
            DataTable Ldt_RET = null;

            if (Pdt_Data.Columns.Count > 0)
            {
                Ldt_RET = new DataTable();
                foreach (DataColumn Ldc_Column in Pdt_Data.Columns)
                {
                    Ldt_RET.Columns.Add(Ldc_Column.ColumnName, Ldc_Column.DataType);
                }
            }
            return Ldt_RET;
        }
        public static DataTable GetDataGridViewAsDataTable(DataGridView _DataGridView)
        {
            try
            {
                if (_DataGridView.ColumnCount == 0)
                    return null;
                DataTable dtSource = new DataTable();
                //////create columns
                foreach (DataGridViewColumn col in _DataGridView.Columns)
                {
                    if (col.ValueType == null)
                        dtSource.Columns.Add(col.Name, typeof(string));
                    else
                        dtSource.Columns.Add(col.Name, col.ValueType);
                    dtSource.Columns[col.Name].Caption = col.HeaderText;
                }
                ///////insert row data
                foreach (DataGridViewRow row in _DataGridView.Rows)
                {
                    DataRow drNewRow = dtSource.NewRow();
                    foreach (DataColumn col in dtSource.Columns)
                    {
                        drNewRow[col.ColumnName] = row.Cells[col.ColumnName].Value;
                    }
                    dtSource.Rows.Add(drNewRow);
                }
                return dtSource;
            }
            catch
            {
                return null;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

                List<ShipPropertyUpdate> lotList = Helper.DataTableMapToList<ShipPropertyUpdate>(lotTable);
                int result = FindIntListIndex(lotList, shipvolist);
                ShipPropertyUpdate updateVO = new ShipPropertyUpdate();
                ShipServ serv = new ShipServ();


                updateVO = lotList[result];
                updateVO.LAST_TRAN_USER_ID = userID;
                updateVO.SHIP_FLAG = "Y";
                updateVO.SHIP_CODE = "TO_CUSTOMER";
                updateVO.LOT_DELETE_FLAG = "Y";
                updateVO.LOT_DELETE_CODE = "SHIP";
                updateVO.LAST_TRAN_CODE = "SHIP";
                updateVO.LAST_TRAN_USER_ID = userID;
                updateVO.LAST_TRAN_COMMENT = "최종 출하";

                updateVO.HIST_SEQ = updateVO.LAST_HIST_SEQ;
                updateVO.TRAN_TIME = updateVO.LAST_TRAN_TIME;
                updateVO.TRAN_CODE = updateVO.LAST_TRAN_CODE;
                updateVO.TRAN_USER_ID = updateVO.LAST_TRAN_USER_ID;
                updateVO.TRAN_COMMENT = updateVO.LAST_TRAN_COMMENT;
                updateVO.OLD_PRODUCT_CODE = updateVO.PRODUCT_CODE;
                updateVO.OLD_OPERATION_CODE = updateVO.OPERATION_CODE;
                updateVO.OLD_STORE_CODE = updateVO.STORE_CODE;
                updateVO.OLD_LOT_QTY = updateVO.LOT_QTY;

                updateVO.SALES_ORDER_ID = txtSearch.Text;
                updateVO.PRODUCT_NAME = txtName1.Text;

                int temp = Convert.ToInt32(updateVO.LAST_HIST_SEQ);
                temp = temp + 1;
                updateVO.LAST_HIST_SEQ = Convert.ToString(temp);

                //updateVO.PRODUCT_NAME = 

                bool bResult = serv.ShipLOT_Update(updateVO);
                if (bResult)
                {
                    MessageBox.Show("성공적으로 제품을 출하했습니다.");
                }
                else
                {
                    MessageBox.Show("제품 출하 중 오류가 발생했습니다.");
                }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            frmShipBarcode frm = new frmShipBarcode();
            if (frm.ShowDialog() != DialogResult.OK)
            {
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
