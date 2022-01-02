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
        public DataGridViewRow SelectedRow { get { if (dgvWorkOrder.SelectedRows.Count > 0) return dgvWorkOrder.SelectedRows[0]; else return null; } set { } }
        public frmWorkOrderDialog()
        {
            InitializeComponent();
        }

        private void frmWorkOrderDialog_Load(object sender, EventArgs e)
        {
            DataGridViewUtil.SetInitGridView(dgvWorkOrder);
            DataGridViewUtil.AddGridTextColumn(dgvWorkOrder, "작업일자", "ORDER_DATE");
            DataGridViewUtil.AddGridTextColumn(dgvWorkOrder, "작업지시", "WORK_ORDER_ID");
            DataGridViewUtil.AddGridTextColumn(dgvWorkOrder, "고객사", "CUSTOMER_CODE");
            DataGridViewUtil.AddGridTextColumn(dgvWorkOrder, "고객사명", "CUSTOMER_NAME");
            DataGridViewUtil.AddGridTextColumn(dgvWorkOrder, "품번", "PRODUCT_CODE");
            DataGridViewUtil.AddGridTextColumn(dgvWorkOrder, "품명", "PRODUCT_NAME");
            DataGridViewUtil.AddGridTextColumn(dgvWorkOrder, "공정코드", "OPERATION_CODE");
            DataGridViewUtil.AddGridTextColumn(dgvWorkOrder, "공정명", "OPERATION_NAME");
            DataGridViewUtil.AddGridTextColumn(dgvWorkOrder, "지시수량", "ORDER_QTY");
            DataGridViewUtil.AddGridTextColumn(dgvWorkOrder, "상태", "ORDER_STATUS");
            DataGridViewUtil.AddGridTextColumn(dgvWorkOrder, "생산수량", "PRODUCT_QTY");
            DataGridViewUtil.AddGridTextColumn(dgvWorkOrder, "불량수량", "DEFECT_QTY");
            DataGridViewUtil.AddGridTextColumn(dgvWorkOrder, "작업 시작시간", "WORK_START_TIME");
            DataGridViewUtil.AddGridTextColumn(dgvWorkOrder, "마감 처리자", "WORK_CLOSE_USER_ID");
            DataGridViewUtil.AddGridTextColumn(dgvWorkOrder, "마감 시간", "WORK_CLOSE_TIME");


            LOTServ serv = new LOTServ();
            DataTable dt = serv.GetWorkOrderList();
            dgvWorkOrder.DataSource = null;
            dgvWorkOrder.DataSource = dt;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (true) //작업일자 등 유효성 검사 통과했을 때만. 아직 안 함
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("다른 작업지시를 선택해주시길 바랍니다.");
            }
        }

        
    }
}
