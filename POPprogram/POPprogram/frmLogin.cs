using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAC;

namespace POPprogram
{
    public partial class frmLogin : Form
    {
        public static string userID { get { return sID_Test; } }
        static string sID_Test;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            LoginProperty vo = new LoginProperty();
            LoginServ serv = new LoginServ();
            vo.USER_ID = txtID.Text.ToUpper();
            vo.USER_PASSWORD = txtPwd.Text;

            bool result = serv.CheckLogin(vo);
            if (result)
            {
                sID_Test = txtID.Text;
                frmMain frm = new frmMain(txtID.Text);
                frm.Show();
                this.Hide();
            }
            else
            { 
                MessageBox.Show("입력된 ID 또는 비밀번호를 다시 입력해 주세요.");
                return;
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtID.Text = "NiceMes002";
            txtPwd.Text = "1234";
            sID_Test = txtID.Text;
        }

        private void frmLogin_Shown(object sender, EventArgs e)
        {
            //frmMain frm = new frmMain(txtID.Text);
            //frm.Show();
            //this.Hide();
        }
    }
}
