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
    public partial class frmEndWorkOrder : POPprogram.Base6
    {
        string userID;
        List<string> list;
        bool searchflag = false;
        List<EndPropertyEQ> listEQ;
        bool defectCompleate = false;
        bool inspectCompleate = false;
        bool inputCompleate = false;

        public frmEndWorkOrder()
        {
            InitializeComponent();
            userID = frmLogin.userID;
        }

        private void frmEndWorkOrder_Load(object sender, EventArgs e)
        {
            searchflag = true;
            EndDAC serv = new EndDAC();
            list = serv.GetLotList();

            cboLOTID.DisplayMember = "LOT_ID";
            cboLOTID.DataSource = list;
            cboLOTID.Text = null;

            //EndDAC serv = new EndDAC();
            DataTable dt = serv.GetEQList();

            listEQ= Helper.DataTableMapToList<EndPropertyEQ>(dt);
            cboEQList.DisplayMember = "EQ_CODE";
            cboEQList.DataSource = listEQ;
            cboEQList.Text = null;
        }

        private void cboLOTID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLOTID.SelectedIndex < 0 || cboLOTID.Text == "" || searchflag)
            {
                searchflag = false;
                return;
            }
            bool defectCompleate = false;
            bool inspectCompleate = false;
            bool inputCompleate = false;

            EndProperty vo = new EndProperty();
            EndServ serv = new EndServ();
            vo.LOT_ID = cboLOTID.Text;
            if (vo.LOT_ID == "") return;
            List<EndProperty> list = serv.GetStatusList(vo);
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

            lblDefect.Text = list[0].CHECK_DEFECT_FLAG;
            lblInspect.Text = list[0].CHECK_INSPECT_FLAG;
            lblMaterial.Text = list[0].CHECK_MATERIAL_FLAG;

            EndPropertyLOTHis vo2 = new EndPropertyLOTHis();
            vo2.LOT_ID = cboLOTID.Text;
            vo2.OPERATION_CODE = txtOperCode.Text;
            List<EndPropertyLOTHis> list2 =  serv.GetOperCheckList(vo2);
            DataTable dt = ConvertToDataTable(list2);

            string defect = "DEFECT";
            string inspect = "INSPECT";
            string input = "INPUT";
            bool defectFlag = false;
            bool inspectFlag = false;
            bool inputFlag = false;
            foreach (DataRow rw in dt.Rows)
            {
                if (rw["TRAN_CODE"].ToString().ToUpper()==defect)
                {
                    defectFlag = true;
                }
                if (rw["TRAN_CODE"].ToString().ToUpper() == inspect)
                {
                    inspectFlag = true;
                }
                if (rw["TRAN_CODE"].ToString().ToUpper() == input)
                {
                    inputFlag = true;
                }
            }

            if (defectFlag && lblDefect.Text == "Y")
            {
                lblDefectColor.BackColor = Color.MediumAquamarine;
                lblDefectColor.Text = "입력 완료";
                defectCompleate = true;
            }
            else if (!defectFlag && lblDefect.Text == "Y")
            {
                lblDefectColor.BackColor = Color.Tomato;
                lblDefectColor.Text = "입력 안 됨";
            }
            else if (!defectFlag && lblDefect.Text == "")
            {
                lblDefectColor.BackColor = Color.LemonChiffon;
                lblDefectColor.Text = "입력 없음";
                defectCompleate = true;
            }
            else
            {
                lblDefectColor.BackColor = Color.SkyBlue;
                lblDefectColor.Text = "예외 상황";
            }


            if (inspectFlag && lblInspect.Text == "Y")
            {
                lblInspectColor.BackColor = Color.MediumAquamarine;
                lblInspectColor.Text = "입력 완료";
                inspectCompleate = true;
            }
            else if (!inspectFlag && lblInspect.Text == "Y")
            {
                lblInspectColor.BackColor = Color.Tomato;
                lblInspectColor.Text = "입력 안 됨";
            }
            else if (!inspectFlag && lblInspect.Text == "")
            {
                lblInspectColor.BackColor = Color.LemonChiffon;
                lblInspectColor.Text = "입력 없음";
                inspectCompleate = true;
            }
            else
            {
                lblInspectColor.BackColor = Color.SkyBlue;
                lblInspectColor.Text = "예외 상황";
            }

            if (inputFlag && lblMaterial.Text == "Y")
            {
                lblMaterialColor.BackColor = Color.MediumAquamarine;
                lblMaterialColor.Text = "입력 완료";
                inputCompleate = true;
            }
            else if (!inputFlag && lblMaterial.Text == "Y")
            {
                lblMaterialColor.BackColor = Color.Tomato;
                lblMaterialColor.Text = "입력 안 됨";
            }
            else if (!inputFlag && lblMaterial.Text == "")
            {
                lblMaterialColor.BackColor = Color.LemonChiffon;
                lblMaterialColor.Text = "입력 없음";
                inputCompleate = true;
            }
            else
            {
                lblMaterialColor.BackColor = Color.SkyBlue;
                lblMaterialColor.Text = "예외 상황";
            }

        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            EndServ serv = new EndServ();
            EndPropertyUpdate updateVO = new EndPropertyUpdate();
            
            decimal operConvert = Convert.ToDecimal(txtOperCode.Text);
            if (operConvert < 1600) operConvert = operConvert + 100;

            updateVO.OPERATION_CODE = Convert.ToString(operConvert);
            updateVO.LOT_ID = cboLOTID.Text;
            updateVO.OPER_IN_QTY= Convert.ToDecimal(txtQty.Text);
            updateVO.LAST_TRAN_USER_ID = userID;
            updateVO.END_EQUIPMENT_CODE = cboEQList.Text;
            updateVO.OLD_OPERATION_CODE = Convert.ToString(operConvert-100);

            bool bResult = serv.EndLOT_Update(updateVO);
            if (bResult)
            {
                MessageBox.Show("성공적으로 제품을 출하했습니다.");
            }
            else
            {
                MessageBox.Show("제품 출하 중 오류가 발생했습니다.");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void frmEndWorkOrder_Activated(object sender, EventArgs e)
        {
            if (cboLOTID.SelectedIndex < 0 || cboLOTID.Text == "" || searchflag)
            {
                searchflag = false;
                return;
            }
            EndProperty vo = new EndProperty();
            EndServ serv = new EndServ();
            vo.LOT_ID = cboLOTID.Text;
            if (vo.LOT_ID == "") return;
            List<EndProperty> list = serv.GetStatusList(vo);
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

            lblDefect.Text = list[0].CHECK_DEFECT_FLAG;
            lblInspect.Text = list[0].CHECK_INSPECT_FLAG;
            lblMaterial.Text = list[0].CHECK_MATERIAL_FLAG;

            EndPropertyLOTHis vo2 = new EndPropertyLOTHis();
            vo2.LOT_ID = cboLOTID.Text;
            vo2.OPERATION_CODE = txtOperCode.Text;
            List<EndPropertyLOTHis> list2 = serv.GetOperCheckList(vo2);
            DataTable dt = ConvertToDataTable(list2);

            string defect = "DEFECT";
            string inspect = "INSPECT";
            string input = "INPUT";
            bool defectFlag = false;
            bool inspectFlag = false;
            bool inputFlag = false;
            foreach (DataRow rw in dt.Rows)
            {
                if (rw["TRAN_CODE"].ToString().ToUpper() == defect)
                {
                    defectFlag = true;
                }
                if (rw["TRAN_CODE"].ToString().ToUpper() == inspect)
                {
                    inspectFlag = true;
                }
                if (rw["TRAN_CODE"].ToString().ToUpper() == input)
                {
                    inputFlag = true;
                }
            }

            if (defectFlag && lblDefect.Text == "Y")
            {
                lblDefectColor.BackColor = Color.MediumAquamarine;
                lblDefectColor.Text = "입력 완료";
                defectCompleate = true;
            }
            else if (!defectFlag && lblDefect.Text == "Y")
            {
                lblDefectColor.BackColor = Color.Tomato;
                lblDefectColor.Text = "입력 안 됨";
            }
            else if (!defectFlag && lblDefect.Text == "")
            {
                lblDefectColor.BackColor = Color.LemonChiffon;
                lblDefectColor.Text = "입력 없음";
                defectCompleate = true;
            }
            else
            {
                lblDefectColor.BackColor = Color.SkyBlue;
                lblDefectColor.Text = "예외 상황";
            }


            if (inspectFlag && lblInspect.Text == "Y")
            {
                lblInspectColor.BackColor = Color.MediumAquamarine;
                lblInspectColor.Text = "입력 완료";
                inspectCompleate = true;
            }
            else if (!inspectFlag && lblInspect.Text == "Y")
            {
                lblInspectColor.BackColor = Color.Tomato;
                lblInspectColor.Text = "입력 안 됨";
            }
            else if (!inspectFlag && lblInspect.Text == "")
            {
                lblInspectColor.BackColor = Color.LemonChiffon;
                lblInspectColor.Text = "입력 없음";
                inspectCompleate = true;
            }
            else
            {
                lblInspectColor.BackColor = Color.SkyBlue;
                lblInspectColor.Text = "예외 상황";
            }

            if (inputFlag && lblMaterial.Text == "Y")
            {
                lblMaterialColor.BackColor = Color.MediumAquamarine;
                lblMaterialColor.Text = "입력 완료";
                inputCompleate = true;
            }
            else if (!inputFlag && lblMaterial.Text == "Y")
            {
                lblMaterialColor.BackColor = Color.Tomato;
                lblMaterialColor.Text = "입력 안 됨";
            }
            else if (!inputFlag && lblMaterial.Text == "")
            {
                lblMaterialColor.BackColor = Color.LemonChiffon;
                lblMaterialColor.Text = "입력 없음";
                inputCompleate = true;
            }
            else
            {
                lblMaterialColor.BackColor = Color.SkyBlue;
                lblMaterialColor.Text = "예외 상황";
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboEQList.SelectedIndex < 0 || cboEQList.Text == "" || searchflag)
            {
                searchflag = false;
                return;
            }
            txtEQ_NAME.Text = listEQ[cboEQList.SelectedIndex].EQ_NAME;
        }
    }
}
