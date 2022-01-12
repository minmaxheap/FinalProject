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
    public partial class frmDown : Form
    {
        List<DownProperty> allList;
        string msUserID;
        DownServ downSer;


        public frmDown()
        {
            InitializeComponent();
            msUserID = frmLogin.userID;
        }

        public void LoadData()
        {
            downSer = new DownServ();
            allList = downSer.GetDownList();
            csDataGridView1.DataSource = null;
            csDataGridView1.DataSource = allList;

            DateTime EndDate = dateTimePicker2.Value;
            DateTime StartDate = dateTimePicker1.Value;
            TimeSpan dateDiff = EndDate - StartDate;
            int diffMinute = (int)(Math.Round(dateDiff.TotalMinutes, 0));

            textBox4.Text = diffMinute.ToString();
        }

        private void frmDown_Load(object sender, EventArgs e)
        {
            DataGridViewUtil.SetInitGridView(csDataGridView1);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "비가동 일자", "DT_DATE",width:150);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "비가동 시작", "DT_START_TIME", width: 150);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "비가동 종료", "DT_END_TIME", width: 150);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "시간(분)", "DT_TIME");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "비가동 코드", "DT_CODE", width: 150);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "비가동 주석", "DT_COMMENT", width: 150);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "등록자", "DT_USER_ID");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "조치 내역", "ACTION_COMMENT", width: 150);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "확인자", "CONFIRM_USER_ID");
            List<DownProperty> list = new List<DownProperty>();

            //DateTime EndDate = dateTimePicker2.Value;
            //DateTime StartDate = dateTimePicker1.Value;
            //TimeSpan dateDiff = EndDate - StartDate;
            //int diffMinute = dateDiff.Minutes;

            //textBox4.Text = diffMinute.ToString();

            textBox3.Text = "10";
            LoadData();

            DownProperty vo = new DownProperty();
            

        }

        private void btnExecute_Click(object sender, EventArgs e)
        {

            string dt_date = dateTimePicker1.Value.ToString("yyyy/MM/dd");
            DateTime dt_start_time = dateTimePicker1.Value;
            DateTime dt_end_time = dateTimePicker2.Value;
            //int dt_time = int.Parse(textBox4.Text);
            int dt_time = int.Parse(textBox4.Text);
            string dt_code = comboBox2.Text;
            string dt_comment = textBox2.Text;
            string dt_user_id = msUserID;
            string action_comment = textBox13.Text;


            bool bresult = downSer.Insert(dt_date, dt_start_time, dt_end_time, dt_time, dt_code, dt_comment, dt_user_id, action_comment);
            if (bresult)
            {
                LoadData();
                MessageBox.Show("등록이 되었습니다.");
                return;

            }
            else
            {
                MessageBox.Show("등록 중 실패했습니다");
                return;
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int interval = Convert.ToInt32(textBox3.Text);
            dateTimePicker2.Value = dateTimePicker2.Value.AddMinutes(interval);

            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int interval = -1 * Convert.ToInt32(textBox3.Text);
            if (dateTimePicker2.Value.AddMinutes(interval) < dateTimePicker1.Value)
                return;

            dateTimePicker2.Value = dateTimePicker2.Value.AddMinutes(interval);

            LoadData();
        }
    }
}
