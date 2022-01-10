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
        List<string> list;
        bool searchflag = false;
        public frmLOTMaterial()
        {
            InitializeComponent();
            csDataGridView1.CellValueChanged += new DataGridViewCellEventHandler(csDataGridView1_CellValueChanged);
            csDataGridView1.CurrentCellDirtyStateChanged += new EventHandler(csDataGridView1_CurrentCellDirtyStateChanged);
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
            DataGridViewUtilCombo.AddGridTextColumn(csDataGridView1, "자재 LOT ID", "CHILD_LOT_ID", DataGridViewContentAlignment.MiddleCenter, 150);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "자재 LOT 수량", "CHILD_LOT_QTY", DataGridViewContentAlignment.MiddleCenter, 150);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "자 품번 재고", "SUM_QTY", DataGridViewContentAlignment.MiddleCenter, 100);
            csDataGridView1.Columns["CHILD_LOT_ID"].ReadOnly = false;
            csDataGridView1.Columns["CHILD_LOT_QTY"].ReadOnly = false;
            csDataGridView1.RowTemplate.Height = 20;
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
            dt.Columns.Add("RowNum").SetOrdinal(0);
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["RowNum"].ToString() == "")
                {
                    dr["RowNum"] = dt.Rows.IndexOf(dr) + 1;
                }
            }


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

        private void csDataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // My combobox column is the second one so I hard coded a 1, flavor to taste

            DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)csDataGridView1.Rows[e.RowIndex].Cells[4];
            if (cb.Value != null)
            {
                // do stuff

                csDataGridView1.Invalidate();
            }
        }

        private void csDataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (csDataGridView1.IsCurrentCellDirty)
            {
                // This fires the cell value changed handler below
                csDataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void csDataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //MatServ serv = new MatServ();
            //MatProperty vo = new MatProperty();
            //vo.PRODUCT_CODE = csDataGridView1[""]
            //vo.LOT_ID = cboLOTID.Text;
            //List<MatProperty> list2 = serv.GetRMLotList(vo);
        }
    }
}
