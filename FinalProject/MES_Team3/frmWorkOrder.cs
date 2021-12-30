using DAC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using VO;

namespace MES_Team3
{
    public partial class frmWorkOrder : MES_Team3.BaseForms.Base1_1
    {
        //public List<Bar> barlist;
        string sUserID;

        List<int> iSearchedList = new List<int>();
        List<int> iSelectedRow = new List<int>();
        DataTable dt;
        public frmWorkOrder()
        {
            InitializeComponent();
            sUserID = frmLogin.userID;
        }

        private void frmProduct1_Load(object sender, EventArgs e)
        {
            DataGridViewUtil.SetInitGridView(csDataGridView1);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "작업일자", "ORDER_DATE");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "작업지시", "WORK_ORDER_ID");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "고객사", "CUSTOMER_CODE");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "고객사명", "CUSTOMER_NAME_JOIN");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "품번", "PRODUCT_CODE");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "품명", "PRODUCT_CODE_JOIN");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "지시수량", "ORDER_QTY");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "상태", "ORDER_STATUS");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "생산수량", "PRODUCT_QTY");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "불량수량", "DEFECT_QTY");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "작업 시작시간", "WORK_START_TIME");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "마감 처리자", "WORK_CLOSE_USER_ID");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "마감 시간", "WORK_CLOSE_TIME");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "생성 시간", "CREATE_TIME");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "생성 사용자", "CREATE_USER_ID");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "변경 시간", "UPDATE_TIME");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "변경 사용자", "UPDATE_USER_ID");

            LoadData();

            WorkOrderProperty vo = new WorkOrderProperty();
            WorkOrderPropertySch svo = new WorkOrderPropertySch();

            pgProperty.SelectedObject = vo;
            pgSearch.SelectedObject = svo;

            pgProperty.PropertySort = PropertySort.NoSort;
            pgSearch.PropertySort = PropertySort.NoSort;

        }
        public void LoadData()
        {
            WorkOrderServ serv = new WorkOrderServ();
            dt = serv.GetWorkOrderList();
            csDataGridView1.DataSource = null;
            csDataGridView1.DataSource = dt;
            BSearchPanel = false;
        }


        private void btnInsert_Click(object sender, EventArgs e)
        {
            WorkOrderProperty save = (WorkOrderProperty)pgProperty.SelectedObject;
            save.CREATE_USER_ID = sUserID;
            WorkOrderServ serv = new WorkOrderServ();
            bool bResult = serv.Insert(save);
            if (bResult)
            {
                LoadData();
            }
            else
            {

            }
        }


        private void csDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = csDataGridView1.Rows[e.RowIndex];
            WorkOrderProperty vo = new WorkOrderProperty();
            //vo.OPERATION_CODE = dr.Cells["OPERATION_CODE"].Value.ToString();
            //vo.OPERATION_NAME = dr.Cells["OPERATION_NAME"].Value.ToString();
            //vo.CHECK_DEFECT_FLAG = dr.Cells["CHECK_DEFECT_FLAG"].Value.ToString();
            //vo.CHECK_INSPECT_FLAG = dr.Cells["CHECK_INSPECT_FLAG"].Value.ToString();
            //vo.CHECK_MATERIAL_FLAG = dr.Cells["CHECK_MATERIAL_FLAG"].Value.ToString();
            //if (csDataGridView1.Rows[e.RowIndex].Cells["CREATE_TIME"].Value != null && dr.Cells["CREATE_TIME"].Value != DBNull.Value)
            //    vo.CREATE_TIME = Convert.ToDateTime(dr.Cells["CREATE_TIME"].Value);
            //vo.CREATE_USER_ID = csDataGridView1.Rows[e.RowIndex].Cells["CREATE_USER_ID"].Value.ToString();
            //if (dr.Cells["UPDATE_TIME"].Value != null && dr.Cells["UPDATE_TIME"].Value != DBNull.Value)
            //    vo.UPDATE_TIME = Convert.ToDateTime(dr.Cells["UPDATE_TIME"].Value);
            //vo.UPDATE_USER_ID = dr.Cells["UPDATE_USER_ID"].Value.ToString();

            if (dr.Cells["ORDER_DATE"].Value != null && dr.Cells["ORDER_DATE"].Value != DBNull.Value)
                vo.ORDER_DATE = Convert.ToDateTime(dr.Cells["ORDER_DATE"].Value);
            if (dr.Cells["WORK_ORDER_ID"].Value != null && dr.Cells["WORK_ORDER_ID"].Value != DBNull.Value)
                vo.WORK_ORDER_ID = dr.Cells["WORK_ORDER_ID"].Value.ToString();
            if (dr.Cells["CUSTOMER_CODE"].Value != null && dr.Cells["CUSTOMER_CODE"].Value != DBNull.Value)
                vo.CUSTOMER_CODE = dr.Cells["CUSTOMER_CODE"].Value.ToString();
            if (dr.Cells["PRODUCT_CODE"].Value != null && dr.Cells["PRODUCT_CODE"].Value != DBNull.Value)
                vo.PRODUCT_CODE = dr.Cells["PRODUCT_CODE"].Value.ToString();

            if (dr.Cells["ORDER_QTY"].Value != null && dr.Cells["ORDER_QTY"].Value != DBNull.Value)
                vo.ORDER_QTY = Convert.ToInt32(dr.Cells["ORDER_QTY"].Value);
            if (dr.Cells["ORDER_STATUS"].Value != null && dr.Cells["ORDER_STATUS"].Value != DBNull.Value)
                vo.ORDER_STATUS = dr.Cells["ORDER_STATUS"].Value.ToString();
            if (dr.Cells["PRODUCT_QTY"].Value != null && dr.Cells["PRODUCT_QTY"].Value != DBNull.Value)
                vo.PRODUCT_QTY = Convert.ToInt32(dr.Cells["PRODUCT_QTY"].Value);

            if (dr.Cells["DEFECT_QTY"].Value != null && dr.Cells["DEFECT_QTY"].Value != DBNull.Value)
                vo.DEFECT_QTY = Convert.ToInt32(dr.Cells["DEFECT_QTY"].Value);
            if (dr.Cells["WORK_START_TIME"].Value != null && dr.Cells["WORK_START_TIME"].Value != DBNull.Value)
                vo.WORK_START_TIME = Convert.ToDateTime(dr.Cells["WORK_START_TIME"].Value);
            if (dr.Cells["WORK_CLOSE_USER_ID"].Value != null && dr.Cells["WORK_CLOSE_USER_ID"].Value != DBNull.Value)
                vo.WORK_CLOSE_USER_ID = dr.Cells["WORK_CLOSE_USER_ID"].Value.ToString();
            if (dr.Cells["WORK_CLOSE_TIME"].Value != null && dr.Cells["WORK_CLOSE_TIME"].Value != DBNull.Value)
                vo.WORK_CLOSE_TIME = Convert.ToDateTime(dr.Cells["WORK_CLOSE_TIME"].Value);

            if (dr.Cells["CREATE_TIME"].Value != null && dr.Cells["CREATE_TIME"].Value != DBNull.Value)
                vo.CREATE_TIME = Convert.ToDateTime(dr.Cells["CREATE_TIME"].Value);
            if (dr.Cells["CREATE_USER_ID"].Value != null && dr.Cells["CREATE_USER_ID"].Value != DBNull.Value)
                vo.CREATE_USER_ID = csDataGridView1.Rows[e.RowIndex].Cells["CREATE_USER_ID"].Value.ToString();
            if (dr.Cells["UPDATE_TIME"].Value != null && dr.Cells["UPDATE_TIME"].Value != DBNull.Value)
                vo.UPDATE_TIME = Convert.ToDateTime(dr.Cells["UPDATE_TIME"].Value);
            if (dr.Cells["UPDATE_USER_ID"].Value != null && dr.Cells["UPDATE_USER_ID"].Value != DBNull.Value)
                vo.UPDATE_USER_ID = dr.Cells["UPDATE_USER_ID"].Value.ToString();

            pgProperty.SelectedObject = vo;

            pgProperty.PropertySort = PropertySort.NoSort;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //pk를 받아서 delete 하기 //이거 유틸로 할 수 있지 않을까? 

            WorkOrderProperty save = (WorkOrderProperty)pgProperty.SelectedObject;
            WorkOrderServ serv = new WorkOrderServ();
            bool bResult = serv.Delete(save);
            LoadData();

        }


        private void button3_Click(object sender, EventArgs e)
        {
            WorkOrderProperty vo = new WorkOrderProperty();
            WorkOrderPropertySch svo = new WorkOrderPropertySch();

            pgProperty.SelectedObject = vo;
            pgSearch.SelectedObject = svo;

            pgProperty.PropertySort = PropertySort.NoSort;
            pgSearch.PropertySort = PropertySort.NoSort;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            WorkOrderProperty save = (WorkOrderProperty)pgProperty.SelectedObject;
            save.UPDATE_USER_ID = sUserID;
            save.ORDER_QTY = Convert.ToInt32(save.ORDER_QTY);
            WorkOrderServ serv = new WorkOrderServ();
            bool bResult = serv.Update(save);
            if (bResult)
            {
                LoadData();
            }
            else
            {

            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            WorkOrderPropertySch search = (WorkOrderPropertySch)pgSearch.SelectedObject;
            WorkOrderServ serv = new WorkOrderServ();
            List<WorkOrderProperty> list = serv.GetWorkOrderSearch(search);

            csDataGridView1.DataSource = null;
            csDataGridView1.DataSource = list;
        }

        private void btnReadTop_Click(object sender, EventArgs e)
        {
            WorkOrderPropertySch search = (WorkOrderPropertySch)pgSearch.SelectedObject;
            WorkOrderServ serv = new WorkOrderServ();
            List<WorkOrderProperty> list = serv.GetWorkOrderSearch(search);

            csDataGridView1.DataSource = null;
            csDataGridView1.DataSource = list;
        }

        private void btnTxtSearch_Click(object sender, EventArgs e)
        {
            if (iSearchedList.Count == 0)
            {
                DataTable copy_dt = dt;
                IEnumerable<DataRow> linq_row = null;
                if (txtSearch.Text == "")
                {
                    csDataGridView1.DataSource = copy_dt;
                }
                else
                {
                    foreach (DataRow row in copy_dt.Rows)
                    {
                        linq_row = from item in row.ItemArray
                                   where item.ToString().ToLower().Contains(txtSearch.Text.ToLower())
                                   select row;
                        foreach (DataRow dt in linq_row)
                        {
                            int iCntSearch = copy_dt.Rows.IndexOf(row);
                            iSearchedList.Add(iCntSearch);
                            break;
                        }
                    }
                    iSelectedRow = iSearchedList.ToList();
                }
            }
            if (iSearchedList.Count > 0)
            {
                int iTestNum = iSelectedRow.Count(n => n == -1);
                if (iTestNum == iSearchedList.Count)
                    iSelectedRow = iSearchedList.ToList();
                for (int i = 0; i < iSearchedList.Count; i++)
                {
                    if (iSelectedRow[i] == iSearchedList[i])
                    {
                        csDataGridView1.CurrentCell = csDataGridView1.Rows[iSearchedList[i]].Cells[0];
                        iSelectedRow[i] = -1;
                        break;
                    }
                }
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTxtSearch.PerformClick();
            }
            else
            {
                iSearchedList.Clear();
                iSelectedRow.Clear();
            }
        }

        private void btnPanel_Click(object sender, EventArgs e)
        {
            WorkOrderProperty vo = new WorkOrderProperty();
            WorkOrderPropertySch svo = new WorkOrderPropertySch();

            pgProperty.SelectedObject = vo;
            pgSearch.SelectedObject = svo;

            pgProperty.PropertySort = PropertySort.NoSort;
            pgSearch.PropertySort = PropertySort.NoSort;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            WorkOrderProperty vo = new WorkOrderProperty();
            WorkOrderPropertySch svo = new WorkOrderPropertySch();

            pgProperty.SelectedObject = vo;
            pgSearch.SelectedObject = svo;

            pgProperty.PropertySort = PropertySort.NoSort;
            pgSearch.PropertySort = PropertySort.NoSort;
        }
        //private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        if (iSearchedList.Count == 0)
        //        {
        //            DataTable copy_dt = dt;
        //            IEnumerable<DataRow> linq_row = null;
        //            if (txtSearch.Text == "")
        //            {
        //                csDataGridView1.DataSource = copy_dt;
        //            }
        //            else
        //            {
        //                foreach (DataRow row in copy_dt.Rows)
        //                {
        //                    linq_row = from item in row.ItemArray
        //                               where item.ToString().ToLower().Contains(txtSearch.Text.ToLower())
        //                               select row;
        //                    foreach (DataRow dt in linq_row)
        //                    {
        //                        int iCntSearch = copy_dt.Rows.IndexOf(row);
        //                        iSearchedList.Add(iCntSearch);
        //                        DataRow dr = dtSearchedList.NewRow();
        //                        dr["Count"] = iCntSearch;
        //                        dtSearchedList.Rows.Add(dr);
        //                        break;
        //                    }
        //                }
        //                iSelectedRow = iSearchedList.ToList();
        //                dtSearchedList.AsEnumerable().CopyToDataTable(dtSelectedRow, LoadOption.Upsert);

        //            }
        //        }
        //        if (iSearchedList.Count > 0)
        //        {
        //            int iTestNum = iSelectedRow.Count(n => n == -1);
        //            if (iTestNum == iSearchedList.Count)
        //                iSelectedRow = iSearchedList.ToList();
        //            for (int i = 0; i < iSearchedList.Count; i++)
        //            {
        //                if (iSelectedRow[i] == iSearchedList[i])
        //                {
        //                    csDataGridView1.CurrentCell = csDataGridView1.Rows[iSearchedList[i]].Cells[0];
        //                    iSelectedRow[i] = -1;
        //                    break;
        //                }
        //            }
        //        }
        //    }
        //    else
        //    {
        //        iSearchedList.Clear();
        //        iSelectedRow.Clear();
        //    }
        //}
    }
}

