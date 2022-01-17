using DAC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace MES_Team3
{
    public partial class frmProductOperRelation : MES_Team3.Base3_1
    {
        DataTable mdtProducts;
        List<int> iSearchedList;
        List<int> iSelectedRow;
        string msprodCode;
        string msUserID;
        DataTable mdtAdd;
        public frmProductOperRelation()
        {
            InitializeComponent();
            msUserID = frmLogin.userID;
        }

        private void frmProductOperRelation_Load(object sender, EventArgs e)
        {
            DataGridViewUtil.SetInitGridView(dgvProducts);
            DataGridViewUtil.AddGridTextColumn(dgvProducts, "품번", "PRODUCT_CODE", DataGridViewContentAlignment.MiddleLeft, 140);
            DataGridViewUtil.AddGridTextColumn(dgvProducts, "품명", "PRODUCT_NAME");
            DataGridViewUtil.AddGridTextColumn(dgvProducts, "품번 유형", "PRODUCT_TYPE");
            DataGridViewUtil.AddGridTextColumn(dgvProducts, "고객 코드", "CUSTOMER_CODE");
            DataGridViewUtil.AddGridTextColumn(dgvProducts, "업체 코드", "VENDOR_CODE");
            DataGridViewUtil.AddGridTextColumn(dgvProducts, "생성 시간", "CREATE_TIME", width: 150);
            DataGridViewUtil.AddGridTextColumn(dgvProducts, "생성 사용자", "CREATE_USER_ID");
            DataGridViewUtil.AddGridTextColumn(dgvProducts, "변경 시간", "UPDATE_TIME", width: 150);
            DataGridViewUtil.AddGridTextColumn(dgvProducts, "변경 사용자", "UPDATE_USER_ID");
            dgvProducts.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvProducts.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            DataGridViewUtil.SetInitGridView(dgvAdd);
            DataGridViewUtil.AddGridTextColumn(dgvAdd, "순번", "FLOW_SEQ", width: 80);
            DataGridViewUtil.AddGridTextColumn(dgvAdd, "공정", "OPERATION_CODE");
            DataGridViewUtil.AddGridTextColumn(dgvAdd, "공정명", "OPERATION_NAME", width: 300);

            DataGridViewUtil.SetInitGridView(dgvAll);
            DataGridViewUtil.AddGridTextColumn(dgvAll, "공정",  "OPERATION_CODE");
            DataGridViewUtil.AddGridTextColumn(dgvAll, "공정명","OPERATION_NAME",width: 300);


            iSearchedList = new List<int>();
            iSelectedRow = new List<int>();
            LoadData();

            ProductProperty vo = new ProductProperty();
            vo.IsSearchPanel = true;
            //BIsSearchPanel = false;
            pgdSearch.SelectedObject = vo;
          
           pgdSearch.PropertySort = PropertySort.NoSort;
        }
        private void LoadData()
        {
            ProductServ serv = new ProductServ();
            mdtProducts = serv.GetProductsList();
            dgvProducts.DataSource = null;
            dgvProducts.DataSource = mdtProducts;

        }


        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            msprodCode = dgvProducts["PRODUCT_CODE", e.RowIndex].Value.ToString();

            OperationServ operServ = new OperationServ();
            DataTable dtAll = operServ.GetOperationList();
            dgvAll.DataSource = null;
            dgvAll.DataSource = dtAll;

            GetDgvAddData();
            //dgvAdd.Columns["FLOW_SEQ"].ReadOnly = false;
     

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReadBottom_Click(object sender, EventArgs e)
        {
            if (pgdSearch.SelectedObject != null)
            {
                ProductProperty search = (ProductProperty)pgdSearch.SelectedObject;
                ProductServ serv = new ProductServ();
                List<ProductProperty> list = serv.GetProductSearch(search);
                search.IsSearchPanel = false;

                dgvProducts.DataSource = null;
                dgvProducts.DataSource = list;
                ResetCount();
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            bool bResult = false;

            foreach (DataGridViewRow dr in dgvAll.SelectedRows)
            {
                DataRow[] drArray = mdtAdd.Select($"OPERATION_CODE='{dr.Cells["OPERATION_CODE"].Value.ToString()}'");
                if(!(drArray.Length>0))
                list.Add(dr.Cells["OPERATION_CODE"].Value.ToString());

            }
            if (list.Count > 0)
            {
                ProductServ serv = new ProductServ();
                bResult = serv.SetOpertation(msprodCode, msUserID, list);
                if (bResult)
                {
                    //dgvadd 재로딩

                }
                else
                {
                    //메시지 박스
                    MessageBox.Show("할당 중 실패하였습니다.");
                }
                GetDgvAddData();
            }
            else
            {
                MessageBox.Show("이미 들어간 공정은 넣을 수 없습니다.");
            }
            //이미 들어갔던 공정 못 들어가게 막기(성공) & 한 번에 여러개 넣도록 수정하기(?) 한 개씩 넣어도 되나? 그럼 양쪽 그리드 모두 multiselection = false; (이부분은 같이 이야기해보기)
       
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();

            foreach (DataGridViewRow dr in dgvAdd.SelectedRows)
            {
                list.Add(dr.Cells["OPERATION_CODE"].Value.ToString());

            }
            ProductServ serv = new ProductServ();
            bool bResult = serv.GetLOTOperate(msprodCode, list);
            if (!bResult)
            {
                bResult = serv.DeleteOperation(msprodCode, list);
                if (bResult)
                {
                    //dgvadd 재로딩

                }
                else
                {
                    //메시지 박스
                    MessageBox.Show("할당 제거 중 실패하였습니다.");
                }
                GetDgvAddData();
            }
            else
            {
                MessageBox.Show("선택한 품번의 공정에 생산 LOT ID가 존재합니다.");
            }
           
        }

        private void GetDgvAddData()
        {
            ProductServ prodServ = new ProductServ();
             mdtAdd = prodServ.GetOperRelation(msprodCode);
            dgvAdd.DataSource = null;
            dgvAdd.DataSource = mdtAdd;
        }

        private void btnReadTop_Click(object sender, EventArgs e)
        {
            btnReadBottom.PerformClick();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTxtSearch.PerformClick();
            }
            else
            {
                ResetCount();
            }
        }

        private void btnTxtSearch_Click(object sender, EventArgs e)
        {
            if (iSearchedList.Count == 0)
            {
                DataTable copy_dt = GetDataGridViewAsDataTable(dgvProducts);
                IEnumerable<DataRow> linq_row = null;
                if (txtSearch.Text == "")
                {
                    dgvProducts.DataSource = copy_dt;
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
                        dgvProducts.CurrentCell = dgvProducts.Rows[iSearchedList[i]].Cells[0];
                        iSelectedRow[i] = -1;
                        break;
                    }
                }
            }
        }


        private void ResetCount()
        {
            iSearchedList.Clear();
            iSelectedRow.Clear();
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
