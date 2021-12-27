using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MES_Team3
{
    public partial class frmLogin : Form
    {
      
    
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //ID와 Pwd 유효성 체크

            //main 창 띄우기
            
            frmMain frm = new frmMain(txtID.Text);
            frm.Show();
            this.Hide();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtID.Text = "0324234";

        }

        private void frmLogin_Shown(object sender, EventArgs e)
        {
            frmMain frm = new frmMain(txtID.Text);
            frm.Show();
            this.Hide();
        }
    }
}
