using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAC;

namespace POPprogram
{
    public partial class frmLOTMaterial : POPprogram.Base6
    {
        string msUserID;
        List<string> list;
        bool searchflag = false;
        AutoCompleteStringCollection auto;
        bool flag = false;
        public frmLOTMaterial()
        {
            InitializeComponent();
            msUserID = frmLogin.userID;
        }

        private void frmLOTMaterial_Load(object sender, EventArgs e)
        {
            searchflag = true;
            MatServ serv = new MatServ();
            list = serv.GetLotList();

            cboLOTID.DisplayMember = "LOT_ID";
            cboLOTID.DataSource = list;
            cboLOTID.Text = null;

            DataGridViewUtil.SetInitGridView(csDataGridView1);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "순번", "RowNum", DataGridViewContentAlignment.MiddleCenter, 100);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "자 품번", "CHILD_PRODUCT_CODE", DataGridViewContentAlignment.MiddleCenter, 150);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "자 품명", "CHILD_PRODUCT_NAME", DataGridViewContentAlignment.MiddleCenter, 100);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "단위 수량", "REQUIRE_QTY", DataGridViewContentAlignment.MiddleCenter, 100);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "자재 LOT ID", "CHILD_LOT_ID", DataGridViewContentAlignment.MiddleCenter, 150);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "자재 LOT 수량", "CHILD_LOT_QTY", DataGridViewContentAlignment.MiddleCenter, 150);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "자 품번 재고", "SUM_QTY", DataGridViewContentAlignment.MiddleCenter, 100);
            csDataGridView1.Columns["CHILD_LOT_ID"].ReadOnly = false;
            csDataGridView1.Columns["CHILD_LOT_QTY"].ReadOnly = false;
            csDataGridView1.RowTemplate.Height = 40;
            csDataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void cboLOTID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLOTID.SelectedIndex < 0 || cboLOTID.Text == "" || searchflag)
            {
                searchflag = false;
                return; 
            }
            MatProperty vo = new MatProperty();
            MatServ serv = new MatServ();
            vo.LOT_ID = cboLOTID.Text;
            if (vo.LOT_ID == "") return;
            List<MatProperty> list = serv.GetStatusList(vo);
            txtLOTDescription.Text = list[0].LOT_DESC;
            txtQty.Text = list[0].LOT_QTY.ToString();
            txtProdCode.Text = list[0].PRODUCT_CODE;
            txtCustID.Text = list[0].CUSTOMER_CODE;
            txtOperCode.Text = list[0].OPERATION_CODE;
            txtOperName.Text = list[0].OPERATION_NAME;
            txtProdName.Text = list[0].PRODUCT_NAME;
            txtWorkOrder.Text = list[0].WORK_ORDER_ID;
            lblOrderQty.Text = list[0].ORDER_QTY.ToString();
            lblDefectQty.Text = list[0].DEFECT_QTY.ToString();
            lblProdQty.Text = list[0].PRODUCT_QTY.ToString();
            txtCustName.Text = list[0].CUSTOMER_NAME;
            lblStatus.Text = list[0].ORDER_STATUS;

            MatPropertyPrdCode usevo = new MatPropertyPrdCode();
            usevo.PRODUCT_CODE = txtProdCode.Text;
            List<MatPropertyUse> uselist = serv.GetBomChildList(usevo);
            DataTable dt= ConvertToDataTable(uselist);

            if (txtOperCode.Text == "1000") //염지
            {
                foreach (DataRow dr in dt.Select())
                {
                    if (dr["CHILD_PRODUCT_CODE"].ToString() == "RM_Can" || dr["CHILD_PRODUCT_CODE"].ToString() == "RM_Condiment"
                         || dr["CHILD_PRODUCT_CODE"].ToString() == "RM_Cover" || dr["CHILD_PRODUCT_CODE"].ToString() == "RM_Label"
                          || dr["CHILD_PRODUCT_CODE"].ToString() == "HB_Mixed340") 
                        dr.Delete();
                }
                dt.AcceptChanges();
            }
            if (txtOperCode.Text == "1100") //배합
            {
                foreach (DataRow dr in dt.Select())
                {
                    if (dr["CHILD_PRODUCT_CODE"].ToString() == "RM_Can" || dr["CHILD_PRODUCT_CODE"].ToString() == "HB_Mixed340"
                         || dr["CHILD_PRODUCT_CODE"].ToString() == "RM_Cover" || dr["CHILD_PRODUCT_CODE"].ToString() == "RM_Label"
                         || dr["CHILD_PRODUCT_CODE"].ToString() == "RM_Meat")
                        dr.Delete();
                }
                dt.AcceptChanges();
            }
            if (txtOperCode.Text == "1200") //충전
            {
                foreach (DataRow dr in dt.Select())
                {
                    if (dr["CHILD_PRODUCT_CODE"].ToString() == "RM_Condiment" || dr["CHILD_PRODUCT_CODE"].ToString() == "RM_Meat"
                         || dr["CHILD_PRODUCT_CODE"].ToString() == "RM_Cover" || dr["CHILD_PRODUCT_CODE"].ToString() == "RM_Label")
                        dr.Delete();
                }
                dt.AcceptChanges();
            }
            if (txtOperCode.Text == "1300") //레토르트
            {
                foreach (DataRow dr in dt.Select())
                {
                    if (dr["CHILD_PRODUCT_CODE"].ToString() == "RM_Can" || dr["CHILD_PRODUCT_CODE"].ToString() == "RM_Condiment"
                         || dr["CHILD_PRODUCT_CODE"].ToString() == "RM_Cover" || dr["CHILD_PRODUCT_CODE"].ToString() == "RM_Label"
                        || dr["CHILD_PRODUCT_CODE"].ToString() == "HB_Mixed340" || dr["CHILD_PRODUCT_CODE"].ToString() == "RM_Meat")
                        dr.Delete();
                }
                dt.AcceptChanges();
            }
            if (txtOperCode.Text == "1400") //레이저마킹
            {
                foreach (DataRow dr in dt.Select())
                {
                    if (dr["CHILD_PRODUCT_CODE"].ToString() == "RM_Can" || dr["CHILD_PRODUCT_CODE"].ToString() == "RM_Condiment"
                         || dr["CHILD_PRODUCT_CODE"].ToString() == "RM_Cover" || dr["CHILD_PRODUCT_CODE"].ToString() == "RM_Label"
                         || dr["CHILD_PRODUCT_CODE"].ToString() == "HB_Mixed340" || dr["CHILD_PRODUCT_CODE"].ToString() == "RM_Meat")
                        dr.Delete();
                }
                dt.AcceptChanges();
            }
            if (txtOperCode.Text == "1500") //라벨링
            {
                foreach (DataRow dr in dt.Select())
                {
                    if (dr["CHILD_PRODUCT_CODE"].ToString() == "RM_Can" || dr["CHILD_PRODUCT_CODE"].ToString() == "RM_Condiment"
                         || dr["CHILD_PRODUCT_CODE"].ToString() == "RM_Cover" || dr["CHILD_PRODUCT_CODE"].ToString() == "RM_Meat"
                         || dr["CHILD_PRODUCT_CODE"].ToString() == "HB_Mixed340")
                        dr.Delete();
                }
                dt.AcceptChanges();
            }
            if (txtOperCode.Text == "1600") //커버결합
            {
                foreach (DataRow dr in dt.Select())
                {
                    if (dr["CHILD_PRODUCT_CODE"].ToString() == "RM_Can" || dr["CHILD_PRODUCT_CODE"].ToString() == "RM_Condiment"
                         || dr["CHILD_PRODUCT_CODE"].ToString() == "RM_Label" || dr["CHILD_PRODUCT_CODE"].ToString() == "RM_Meat"
                         || dr["CHILD_PRODUCT_CODE"].ToString() == "HB_Mixed340")
                        dr.Delete();
                }
                dt.AcceptChanges();
            }

            dt.Columns.Add("RowNum").SetOrdinal(0);
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["RowNum"].ToString() == "")
                {
                    dr["RowNum"] = dt.Rows.IndexOf(dr) + 1;
                }
            }
            dt.Columns.Add("CHILD_LOT_ID", typeof(string)).SetOrdinal(4);
            dt.Columns.Add("CHILD_LOT_QTY", typeof(decimal)).SetOrdinal(5);

            csDataGridView1.DataSource = dt;
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void csDataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (csDataGridView1.CurrentCell.ColumnIndex == 4)
            {
                TextBox autoText = e.Control as TextBox;

                MatProperty vo = new MatProperty();
                MatServ serv = new MatServ();
                vo.PRODUCT_CODE = csDataGridView1.CurrentRow.Cells["CHILD_PRODUCT_CODE"].Value.ToString();
                List<MatProperty> list2 = serv.GetRMLotList(vo);
                string[] the_array = list2.Select(i => i.LOT_ID).ToArray();
                if (autoText != null)
                {
                    AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();

                    for (int i = 0; i < the_array.Length; i++)
                    {
                        DataCollection.Add(the_array[i]);
                    }

                    //autoText.AutoCompleteCustomSource = DataCollection;
                    //autoText.AutoCompleteMode = AutoCompleteMode.Suggest;
                    //autoText.AutoCompleteSource = AutoCompleteSource.CustomSource;

                    autoText.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    autoText.AutoCompleteCustomSource = DataCollection;
                    autoText.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
            }
            else
            {
                TextBox prodCode = e.Control as TextBox;
                if (prodCode != null)
                {
                    prodCode.AutoCompleteMode = AutoCompleteMode.None;
                }
            }

        }
        public void addItems(AutoCompleteStringCollection col, string[] the_array)
        {
            foreach (string a in the_array)
            {
                col.Add(a);
            }

        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            
            foreach (DataGridViewRow rw in this.csDataGridView1.Rows)
            {
                for (int i = 0; i < rw.Cells.Count; i++)
                {
                    if (rw.Cells[i].Value == null || rw.Cells[i].Value == DBNull.Value || String.IsNullOrWhiteSpace(rw.Cells[i].Value.ToString()))
                    {
                        MessageBox.Show("사용 자재의 정보를 모두 입력하세요.");
                        return;
                    }
                }
            }
            MatPropertyUpdate vo = new MatPropertyUpdate();
            List<MatPropertyExport> export = new List<MatPropertyExport>();
            MatPropertyExport item2 = new MatPropertyExport();

            foreach (DataGridViewRow rw in this.csDataGridView1.Rows)
            {
                item2.BOM_CHILD_ID = (string)rw.Cells[1].Value;
                item2.BOM_LOT_ID=(string)rw.Cells[4].Value;
                item2.BOM_LOT_QTY=(decimal)rw.Cells[5].Value;
                item2.BOM_SUM_QTY = (decimal)rw.Cells[6].Value;
                export.Add(item2);
                if(rw.Index==0)
                {
                    vo.BOM_CHILD_ID_1 = export[rw.Index].BOM_CHILD_ID;
                    vo.BOM_LOT_ID_1 = export[rw.Index].BOM_LOT_ID;
                    vo.BOM_LOT_QTY_1 = export[rw.Index].BOM_LOT_QTY;
                    vo.BOM_SUM_QTY_1 = export[rw.Index].BOM_SUM_QTY;
                }
                if (rw.Index == 1)
                {
                    vo.BOM_CHILD_ID_2 = export[rw.Index].BOM_CHILD_ID;
                    vo.BOM_LOT_ID_2 = export[rw.Index].BOM_LOT_ID;
                    vo.BOM_LOT_QTY_2 = export[rw.Index].BOM_LOT_QTY;
                    vo.BOM_SUM_QTY_2 = export[rw.Index].BOM_SUM_QTY;
                }
            }
            if ((vo.BOM_LOT_ID_1!=null && vo.BOM_LOT_QTY_1==0) || (vo.BOM_LOT_ID_2 != null && vo.BOM_LOT_QTY_2 == 0))
            {
                MessageBox.Show("0이 아닌 숫자를 입력하세요.");
                return;
            }
            if ((vo.BOM_LOT_ID_1 != null &&vo.BOM_LOT_QTY_1 > vo.BOM_SUM_QTY_1) || (vo.BOM_LOT_ID_2 != null && vo.BOM_LOT_QTY_2 == vo.BOM_SUM_QTY_2))
            {
                MessageBox.Show("재고보다 낮은 숫자를 입력하세요.");
                return;
            }

            MatServ serv = new MatServ();
            vo.LOT_ID = cboLOTID.Text;
            vo.LOT_DESC = txtLOTDescription.Text;
            vo.PRODUCT_CODE = txtProdCode.Text;
            vo.OPERATION_CODE = txtOperCode.Text;
            vo.LAST_TRAN_COMMENT = txtComment.Text;
            vo.LAST_TRAN_USER_ID = msUserID;
            vo.LOT_QTY = Convert.ToDecimal(txtQty.Text);
            vo.OPERATION_CODE = txtOperCode.Text;
            vo.PRODUCT_NAME = txtProdName.Text;

            vo.BOM_LOT_QTY_1 = vo.BOM_LOT_QTY_1 - vo.BOM_LOT_QTY_1;
            vo.BOM_LOT_QTY_2 = vo.BOM_LOT_QTY_2 - vo.BOM_LOT_QTY_2;

            //vo.BOM_LOT_QTY_1 = export[rw.Index].BOM_LOT_QTY - export[rw.Index].BOM_LOT_QTY;
            //vo.BOM_LOT_QTY_2 = export[rw.Index].BOM_LOT_QTY - export[rw.Index].BOM_LOT_QTY;

            bool bResult = serv.SetUseLOT(vo);
            if (bResult)
            {
                MessageBox.Show("성공적으로 생산 LOT를 생성했습니다.");
            }
            else
            {
                MessageBox.Show("LOT 생성 중 오류가 발생했습니다.");
            }
            //LOTProperty mLOT = new LOTProperty()
            //{
            //    LOT_ID = txtLOTID.Text,
            //    LOT_DESC = txtLOTDescription.Text,
            //    PRODUCT_CODE = txtProdCode.Text,
            //    OPERATION_CODE = txtOperCode.Text,
            //    WORK_ORDER_ID = txtWorkOrderID.Text,
            //    LOT_QTY = Convert.ToInt32(txtQty.Text),
            //    LAST_TRAN_COMMENT = txtComment.Text,
            //    LAST_TRAN_USER_ID = msUserID

            //};
            ////입력한 정보로 status & history에 insert
            //LOTServ serv = new LOTServ();
            //bool bResult = serv.SetNewLOT(mLOT);
            //if (bResult)
            //{
            //    MessageBox.Show("성공적으로 생산 LOT를 생성했습니다.");
            //}
            //else
            //{
            //    MessageBox.Show("LOT 생성 중 오류가 발생했습니다.");
            //}
        }

        private void csDataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {


            if (e.RowIndex < 0) return;

            if (csDataGridView1.CurrentRow.Cells["CHILD_LOT_QTY"].Value == null || csDataGridView1.CurrentRow.Cells["CHILD_LOT_QTY"].Value == DBNull.Value)
            {
                return;
            }
            if (Convert.ToDecimal(csDataGridView1.CurrentRow.Cells["CHILD_LOT_QTY"].Value) ==0)
            {
                return;
            }
            if (!flag)
            {
                flag = true;
                decimal totalQTY = Convert.ToDecimal(csDataGridView1.CurrentRow.Cells["CHILD_LOT_QTY"].Value) * Convert.ToDecimal(csDataGridView1.CurrentRow.Cells["REQUIRE_QTY"].Value);
                csDataGridView1.CurrentRow.Cells["CHILD_LOT_QTY"].Value = totalQTY;
            }
            flag = false;
        }


    }
    }

