using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POPprogram
{
    public partial class frmWorkOrderDialog : Form
    {
        public frmWorkOrderDialog()
        {
            InitializeComponent();
        }

        private void frmWorkOrderDialog_Load(object sender, EventArgs e)
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

            WorkOrderServ serv = new WorkOrderServ();
            DataTable dt = serv.GetWorkOrderList();
            csDataGridView1.DataSource = null;
            csDataGridView1.DataSource = dt;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
            //값 전달
        }

        
    }
}
