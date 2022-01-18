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
    public partial class frmLOTDefect : POPprogram.Base6
    {
        StarWorkServ serv;
        StarWorkServ ser;
        List<string> list;
        List<string> list1;
        List<string> list2;
        List<string> list3;
        List<StarWorkProperty> swlist;
        List<string> CodeList;
        LOTinspectServ lotserv;
        deffectServ deserv;
        string titleName;
        public string TitleName { get { return titleName; } set { } }

        decimal lot_qty = 0;
        public frmLOTDefect()
        {
            InitializeComponent();
        }

        private void cboLOTID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLOTID.SelectedIndex < 1) return;

            LoadData();

        }

        private void LoadData()
        {
            string Value = cboLOTID.SelectedValue.ToString();



            Value = (cboLOTID.SelectedValue == null) ? "" : cboLOTID.SelectedValue.ToString();

            swlist = serv.GetData(Value);

            txtLOTDescription.Text = swlist[0].LOT_DESC;
            txtQty.Text = swlist[0].LOT_QTY.ToString();
            txtProdCode.Text = swlist[0].PRODUCT_CODE;
            txtCustID.Text = swlist[0].CUSTOMER_CODE;
            txtOperCode.Text = swlist[0].OPERATION_CODE;
            txtOperName.Text = swlist[0].OPERATION_NAME;
            txtProdName.Text = swlist[0].PRODUCT_NAME;
            txtWorkOrder.Text = swlist[0].WORK_ORDER_ID;
            lblOrderQty.Text = swlist[0].ORDER_QTY.ToString();
            lblDefectQty.Text = swlist[0].DEFECT_QTY.ToString();
            lblProdQty.Text = swlist[0].PRODUCT_QTY.ToString();
            txtCustName.Text = swlist[0].DATA_1;
            lblStatus.Text = swlist[0].ORDER_STATUS;
        }

        private void frmLOTDefect_Load(object sender, EventArgs e)
        {
            titleName = frmMain.TitleName;
            lblUpTitle.Text = "   " + titleName;
            serv = new StarWorkServ();
            list = serv.GetDeffectCode();
            list.Insert(0, "");
            //cboLOTID.Items.Insert(0, " ");
            //cboLOTID.ValueMember = "LOT_ID";
            cboLOTID.DisplayMember = "LOT_ID";
            cboLOTID.DataSource = list;

            ser = new StarWorkServ();
            list1 = serv.GetDefect_Code();
            list1.Insert(0, "");
            list2 = serv.GetDefect_Code();
            list2.Insert(0, "");
            list3 = serv.GetDefect_Code();
            list3.Insert(0, "");

            comboBox1.DisplayMember = "KEY_1";
            comboBox1.DataSource = list1;
            comboBox2.DisplayMember = "KEY_1";
            comboBox2.DataSource = list2;
            comboBox3.DisplayMember = "KEY_1";
            comboBox3.DataSource = list3;
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
           
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("DEFECT_CODE", typeof(string));
            dt.Columns.Add("DEFECT_QTY", typeof(string));

            //리플렉션 사용할 수 없나? type으로 변환해서 
            //행을 추가 
            for (int i = 1; i < 4; i++)
            {
                DataRow dr = dt.NewRow();

                //여기서는 코드이름을 넣어야할까 아니면 그 부분을 넣어야할까?
                switch (i)
                {
                    case 1:
                        {
                            if (string.IsNullOrWhiteSpace(numTextBox1.Text) || string.IsNullOrWhiteSpace(comboBox1.SelectedValue.ToString())) break;
                            else
                            {
                                dr["ID"] = dt.Rows.Count + 1;
                                dr["DEFECT_CODE"] = comboBox1.Text;

                                dr["DEFECT_QTY"] = Convert.ToDecimal(numTextBox1.Text);

                                dt.Rows.Add(dr);
                            }
                            break;
                        }
                    case 2:
                        {
                            if (string.IsNullOrWhiteSpace(numTextBox2.Text) || string.IsNullOrWhiteSpace(comboBox2.SelectedValue.ToString())) break;
                            else
                            {
                                dr["ID"] = dt.Rows.Count + 1;
                                dr["DEFECT_CODE"] = comboBox2.Text;

                                dr["DEFECT_QTY"] = Convert.ToDecimal(numTextBox2.Text);

                                dt.Rows.Add(dr);
                            }
                            break;
                        }
                    case 3:
                        {
                            if (string.IsNullOrWhiteSpace(numTextBox3.Text) || string.IsNullOrWhiteSpace(comboBox3.SelectedValue.ToString()))  break;
                            else
                            {
                                dr["ID"] = dt.Rows.Count + 1;
                                if (!string.IsNullOrWhiteSpace(comboBox3.SelectedValue.ToString()))
                                {
                                    dr["DEFECT_CODE"] = comboBox3.Text;
                                }
                                if (!string.IsNullOrWhiteSpace(numTextBox3.Text) && !string.IsNullOrWhiteSpace(comboBox3.SelectedValue.ToString()))
                                    dr["DEFECT_QTY"] = Convert.ToDecimal(numTextBox3.Text);

                                dt.Rows.Add(dr);
                            }
                            break;
                        }

                }
            }
            dt.AcceptChanges();

            if (cboLOTID.SelectedValue.ToString() == "")
            {
                MessageBox.Show("lot 상태가 없습니다.");
                return;
            }
            
         

            //if(String.IsNullOrWhiteSpace(
            
            decimal a1 = string.IsNullOrWhiteSpace(numTextBox1.Text) ? 0 : Convert.ToDecimal(numTextBox1.Text);
            decimal a2 = string.IsNullOrWhiteSpace(numTextBox2.Text) ? 0 : Convert.ToDecimal(numTextBox2.Text);
            decimal a3 = string.IsNullOrWhiteSpace(numTextBox3.Text) ? 0 : Convert.ToDecimal(numTextBox3.Text);
      
            lot_qty = string.IsNullOrWhiteSpace(numTextBox5.Text) ? 0: Convert.ToDecimal(numTextBox5.Text);

            if (dt.Rows.Count < 1)
            {
                MessageBox.Show("입력값을 다시 입력해주세요");
                return;
            }
            deserv = new deffectServ();
            bool result = deserv.insert(lot_qty, txtComment.Text, frmLogin.userID, cboLOTID.SelectedValue.ToString(), dt);
            if (result)
            {
                MessageBox.Show("불량 처리가 정상적으로 완료되었습니다.");
                LoadData();
                return;
            }
            else
            {
                MessageBox.Show("불량 처리 중 문제가 발생했습니다.");
                return;
            }
            //string msuerID = 
           

        }

		private void panel4_Paint(object sender, PaintEventArgs e)
		{

		}
        private void numtxt_keydown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                decimal a1 = string.IsNullOrWhiteSpace(numTextBox1.Text) ? 0 : Convert.ToDecimal(numTextBox1.Text);
                decimal a2 = string.IsNullOrWhiteSpace(numTextBox2.Text) ? 0 : Convert.ToDecimal(numTextBox2.Text);
                decimal a3 = string.IsNullOrWhiteSpace(numTextBox3.Text) ? 0 : Convert.ToDecimal(numTextBox3.Text);


                decimal a4 = a1 + a2 + a3;
                numTextBox4.Text = a4.ToString();

                decimal a5 = Convert.ToDecimal(txtQty.Text) - a4;

                numTextBox5.Text = a5.ToString();

                

            }
        }

		private void numTextBox2_TextChanged(object sender, EventArgs e)
		{

		}

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
