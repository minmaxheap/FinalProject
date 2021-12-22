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
            Label lblUpdateID = new Label();
            lblUpdateID.Text = "변경 사용자";
            lblUpdateID.Name = "lblUpdateID";
             lblUpdateID.BackColor = Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
             lblUpdateID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
             lblUpdateID.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point,      ((byte)   (129)));
            lblUpdateID.Location = new System.Drawing.Point(label12.Location.X, label12.Location.Y + label12.Height);
             lblUpdateID.Margin = new System.Windows.Forms.Padding(0);
             lblUpdateID.Size = new System.Drawing.Size(100, 22);
            lblUpdateID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            TextBox txtUpdateID = new TextBox();
            txtUpdateID.Text = "";
            txtUpdateID.Name = "txtUpdateID";
            txtUpdateID.Font = new System.Drawing.Font("나눔고딕", 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(129)));
            txtUpdateID.Location = new System.Drawing.Point(textBox10.Location.X, textBox10.Location.Y + label12.Height);
            txtUpdateID.Margin = new System.Windows.Forms.Padding(0);
            txtUpdateID.Size = new System.Drawing.Size(216, 22);

            panel7.Controls.Add(lblUpdateID);
            panel7.Controls.Add(txtUpdateID);

            this.WindowState = FormWindowState.Maximized; //이상하다 왜 이 코드가 빠지면 맨 처음에 최대화로 안 열리지?

            FunctionServ serv = new FunctionServ();
            DataTable dtfunc = serv.GetFuncList();


           // base.NewTextBox(txtUpdateID, new Size(216, 22), new Point(textBox10.Location.X, textBox10.Location.Y + label12.Height));
           //이렇게 메소드 만들어놓고 하면 되겠다! 


            //FUNCTION_CODE, FUNCTION_NAME, SHORT_CUT_KEY, ICON_INDEX, PNT_FUNCTION_CODE, FUNCTION_LEVEL, PROGRAM_NAME, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID
            //DataGridViewUtil.SetInitGridView(csDataGridView1);
            //DataGridViewUtil.AddGridTextColumn(csDataGridView1,"기능 코드", "FUNCTION_CODE");
            //DataGridViewUtil.AddGridTextColumn(csDataGridView1, "기능명", "FUNCTION_NAME");
            //DataGridViewUtil.AddGridTextColumn(csDataGridView1, "단축키", "SHORT_CUT_KEY");
            //DataGridViewUtil.AddGridTextColumn(csDataGridView1, "아이콘 인덱스", "ICON_INDEX",width:110);
            //DataGridViewUtil.AddGridTextColumn(csDataGridView1, "상위 코드", "PNT_FUNCTION_CODE");
            //DataGridViewUtil.AddGridTextColumn(csDataGridView1, "기능 레벨", "FUNCTION_LEVEL");
            //DataGridViewUtil.AddGridTextColumn(csDataGridView1, "생성 시간", "CREATE_TIME");
            //DataGridViewUtil.AddGridTextColumn(csDataGridView1, "생성 사용자", "CREATE_USER_ID");
            //DataGridViewUtil.AddGridTextColumn(csDataGridView1, "변경 시간", "UPDATE_TIME");
            //DataGridViewUtil.AddGridTextColumn(csDataGridView1, "변경 사용자", "UPDATE_USER_ID");

            //csDataGridView1.DataSource = dtfunc;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmSearch frm = new frmSearch();
            
            frm.StartPosition = FormStartPosition.CenterParent;
            //frm.lbl1.Text = "기능 코드";
            //frm.lbl2.Text = "기능명";
           
            frm.ShowDialog();

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
