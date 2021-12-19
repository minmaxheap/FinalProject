using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MES_Team3
{
    public partial class frmFunction : Base1
    {
        public frmFunction()
        {
            InitializeComponent();
        }

        private void frmFunction_Load(object sender, EventArgs e)
        {
            
            this.WindowState = FormWindowState.Maximized; //이상하다 왜 이 코드가 빠지면 맨 처음에 최대화로 안 열리지?

            FunctionServ serv = new FunctionServ();
            DataTable dtfunc = serv.GetFuncList();
         

            //FUNCTION_CODE, FUNCTION_NAME, SHORT_CUT_KEY, ICON_INDEX, PNT_FUNCTION_CODE, FUNCTION_LEVEL, PROGRAM_NAME, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID
            DataGridViewUtil.SetInitGridView(csDataGridView1);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1,"기능 코드", "FUNCTION_CODE");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "기능명", "FUNCTION_NAME");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "단축키", "SHORT_CUT_KEY");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "아이콘 인덱스", "ICON_INDEX",width:110);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "상위 코드", "PNT_FUNCTION_CODE");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "기능 레벨", "FUNCTION_LEVEL");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "생성 시간", "CREATE_TIME");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "생성 사용자", "CREATE_USER_ID");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "변경 시간", "UPDATE_TIME");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "변경 사용자", "UPDATE_USER_ID");

            csDataGridView1.DataSource = dtfunc;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmSearch frm = new frmSearch();
            
            frm.ShowDialog();

        }
    }
}
