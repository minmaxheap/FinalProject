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
        public DataGridViewRow SelectedRow { get { if (csDataGridView1.SelectedRows.Count > 0) return csDataGridView1.SelectedRows[0]; else return null; } set { } }
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
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "고객사명", "CUSTOMER_NAME");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "품번", "PRODUCT_CODE");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "품명", "PRODUCT_NAME");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "공정코드", "OPERATION_CODE");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "공정명", "OPERATION_NAME");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "지시수량", "ORDER_QTY");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "상태", "ORDER_STATUS");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "생산수량", "PRODUCT_QTY");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "불량수량", "DEFECT_QTY");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "작업 시작시간", "WORK_START_TIME");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "마감 처리자", "WORK_CLOSE_USER_ID");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "마감 시간", "WORK_CLOSE_TIME");


            LOTServ serv = new LOTServ();
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
