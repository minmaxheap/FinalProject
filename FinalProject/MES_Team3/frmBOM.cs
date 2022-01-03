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

namespace MES_Team3
{
    public partial class frmBOM : Base4_1
    {
        DataTable mdtAll;
        string prodCode;
        DataTable mdtAdd;
        string msUserID = frmLogin.userID;
        string prod_code;
        List<int> iSearchedList;
        List<int> iSelectedRow;
        //string msUserID;
        //List<int> iSearchedList;
        //List<int> iSelectedRow;

        public frmBOM()
        {
            InitializeComponent();
        }

        private void frmBOM_Load(object sender, EventArgs e)
        {

            DataGridViewUtil.SetInitGridView(dgvProduct);
            DataGridViewUtil.AddGridTextColumn(dgvProduct, "품번", "PRODUCT_CODE");
            DataGridViewUtil.AddGridTextColumn(dgvProduct, "품명", "PRODUCT_NAME");
            DataGridViewUtil.AddGridTextColumn(dgvProduct, "품번 유형", "PRODUCT_TYPE");
            DataGridViewUtil.AddGridTextColumn(dgvProduct, "고객 코드", "CUSTOMER_CODE");
            DataGridViewUtil.AddGridTextColumn(dgvProduct, "업체 코드", "VENDOR_CODE");
            DataGridViewUtil.AddGridTextColumn(dgvProduct, "생성 시간", "CREATE_TIME", width: 150);
            DataGridViewUtil.AddGridTextColumn(dgvProduct, "생성 사용자", "CREATE_USER_ID");
            DataGridViewUtil.AddGridTextColumn(dgvProduct, "변경 시간", "UPDATE_TIME", width: 150);
            DataGridViewUtil.AddGridTextColumn(dgvProduct, "변경 사용자", "UPDATE_USER_ID");
            //iSearchedList = new List<int>();
            //iSelectedRow = new List<int>();


            DataGridViewUtil.SetInitGridView(dgvBOM);
            DataGridViewUtil.AddGridTextColumn(dgvBOM, "자 품번", "CHILD_PRODUCT_CODE");
            DataGridViewUtil.AddGridTextColumn(dgvBOM, "자 품명", "PRODUCT_NAME");
            DataGridViewUtil.AddGridTextColumn(dgvBOM, "단위 수량", "REQUIRE_QTY");
            //DataGridViewUtil.AddGridTextColumn(csDataGridView2, "대체 품번", "CUSTOMER_CODE");
            DataGridViewUtil.AddGridTextColumn(dgvBOM, "생성 시간", "CREATE_TIME", width: 150);
            DataGridViewUtil.AddGridTextColumn(dgvBOM, "생성 사용자", "CREATE_USER_ID");
            DataGridViewUtil.AddGridTextColumn(dgvBOM, "변경 시간", "UPDATE_TIME", width: 150);
            DataGridViewUtil.AddGridTextColumn(dgvBOM, "변경 사용자", "UPDATE_USER_ID");

            LoadData();

            ProductProperty vo = new ProductProperty();
            vo.IsSearchPanel = false;

            BomVO bvo = new BomVO();
            pgProperty.SelectedObject = bvo;
            pgProperty.PropertySort = PropertySort.NoSort;
            //pgProperty.SelectedObject = vo;

            //pgProperty.PropertySort = PropertySort.NoSort;
        }

        private void LoadData()
        {
            ProductServ serv = new ProductServ();
            mdtAll = serv.GetProductsList();
            dgvProduct.DataSource = null;
            dgvProduct.DataSource = mdtAll;
            dgvProduct.Focus();


            ProductProperty search = new ProductProperty();
            search.IsSearchPanel = true;
            pgSearch.SelectedObject = search;
            pgSearch.PropertySort = PropertySort.NoSort;
            //csDataGridView1.Rows[0].Selected = true;
        }

        private void btnReadBottom_Click(object sender, EventArgs e)
        {
            if (pgSearch.SelectedObject != null)
            {
                ProductProperty search = (ProductProperty)pgSearch.SelectedObject;
                ProductServ serv = new ProductServ();
                List<ProductProperty> list = serv.GetProductSearch(search);
                search.IsSearchPanel = false;

                dgvProduct.DataSource = null;
                dgvProduct.DataSource = list;


            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            BomVO save = (BomVO)pgProperty.SelectedObject;
            BOMServ serv = new BOMServ();
            bool bResult = serv.Delete(save);
            if (bResult)
            {
                MessageBox.Show("삭제되었습니다.");
                GetDgvAddData();
            }
            else
            {
                MessageBox.Show("삭제 중 실패하였습니다.");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (pgProperty.SelectedGridItem != null)
            {
                PropertyDescriptor pd = pgProperty.SelectedGridItem.PropertyDescriptor;
                pd.ResetValue(pgProperty.SelectedObject);

                BomVO sv = new BomVO();
                pgProperty.SelectedObject = sv;
                pgProperty.PropertySort = PropertySort.NoSort;
            }
        }

        private void csDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow dr = dgvProduct.Rows[e.RowIndex];
            BomVO vo = new BomVO();

            if (dr.Cells["PRODUCT_CODE"].Value != null && dr.Cells["PRODUCT_CODE"].Value != DBNull.Value)
                vo.PRODUCT_CODE = dr.Cells["PRODUCT_CODE"].Value.ToString();


            prod_code = vo.PRODUCT_CODE; 
            pgProperty.SelectedObject = vo;

            pgProperty.PropertySort = PropertySort.NoSort;

            prodCode = dgvProduct["PRODUCT_CODE", e.RowIndex].Value.ToString();

            BOMServ bomServ = new BOMServ();
            DataTable dtAll = bomServ.GetBOMList1();
            dgvBOM.DataSource = null;
            dgvBOM.DataSource = dtAll;

            GetDgvAddData();
        }
        private void GetDgvAddData()
        {
            BOMServ bomServ = new BOMServ();
            mdtAdd = bomServ.GetOperRelation(prodCode);
            dgvBOM.DataSource = null;
            dgvBOM.DataSource = mdtAdd;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            BomVO save = (BomVO)pgProperty.SelectedObject;
            save.CREATE_USER_ID = msUserID;
            BOMServ serv = new BOMServ();
            bool bResult = serv.Insert(save);
            if (bResult)
            {
                MessageBox.Show("등록되었습니다.");
                GetDgvAddData();
                return;
            }
            else
            {
                MessageBox.Show("등록 중 실패하였습니다.");
                return;
            }
        }

        private void dgvBOM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow dr = dgvBOM.Rows[e.RowIndex];
            BomVO vo = new BomVO();


            if (dr.Cells["CHILD_PRODUCT_CODE"].Value != null && dr.Cells["CHILD_PRODUCT_CODE"].Value != DBNull.Value)
                vo.CHILD_PRODUCT_CODE = dr.Cells["CHILD_PRODUCT_CODE"].Value.ToString();
            if (dr.Cells["REQUIRE_QTY"].Value != null && dr.Cells["REQUIRE_QTY"].Value != DBNull.Value)
                vo.REQUIRE_QTY = dr.Cells["REQUIRE_QTY"].Value.ToString();
            if (dr.Cells["CREATE_TIME"].Value != null && dr.Cells["CREATE_TIME"].Value != DBNull.Value)
                vo.CREATE_TIME = Convert.ToDateTime(dr.Cells["CREATE_TIME"].Value);
            if (dr.Cells["CREATE_USER_ID"].Value != null && dr.Cells["CREATE_USER_ID"].Value != DBNull.Value)
                vo.CREATE_USER_ID = dgvBOM.Rows[e.RowIndex].Cells["CREATE_USER_ID"].Value.ToString();
            if (dr.Cells["UPDATE_TIME"].Value != null && dr.Cells["UPDATE_TIME"].Value != DBNull.Value)
                vo.UPDATE_TIME = Convert.ToDateTime(dr.Cells["UPDATE_TIME"].Value);
            if (dr.Cells["UPDATE_USER_ID"].Value != null && dr.Cells["UPDATE_USER_ID"].Value != DBNull.Value)
                vo.UPDATE_USER_ID = dr.Cells["UPDATE_USER_ID"].Value.ToString();

            vo.PRODUCT_CODE = prod_code; 
            pgProperty.SelectedObject = vo;

            pgProperty.PropertySort = PropertySort.NoSort;

            pgProperty.Visible = true;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            BomVO save = (BomVO)pgProperty.SelectedObject;
            save.UPDATE_USER_ID = msUserID;
            BOMServ serv = new BOMServ();
            bool bResult = serv.Update(save);
            if (bResult)
            {
                MessageBox.Show("수정되었습니다.");
                LoadData();
            }
            else
            {
                MessageBox.Show("수정 중 실패하였습니다.");
            }
        }

        private void pnlTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTxtSearch_Click(object sender, EventArgs e)
        {
            if (iSearchedList.Count == 0)
            {
                DataTable copy_dt = GetDataGridViewAsDataTable(dgvProduct);
                IEnumerable<DataRow> linq_row = null;
                if (txtSearch.Text == "")
                {
                    dgvProduct.DataSource = copy_dt;
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
                        dgvProduct.CurrentCell = dgvProduct.Rows[iSearchedList[i]].Cells[0];
                        iSelectedRow[i] = -1;
                        break;
                    }
                }
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnReadTop_Click(object sender, EventArgs e)
        {

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
    }
}
