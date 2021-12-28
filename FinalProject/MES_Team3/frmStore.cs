using DAC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using VO;

namespace MES_Team3
{
    public partial class frmStore : MES_Team3.BaseForms.Base1_1
    {
        List<StoreVO> allList;
        public frmStore()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            StoreServ serv = new StoreServ();
            allList = serv.GetStoreList();
            csDataGridView1.DataSource = null;
            csDataGridView1.DataSource = allList;
            SearchPanel = false;
        }

        private void frmStore_Load(object sender, EventArgs e)
        {
            DataGridViewUtil.SetInitGridView(csDataGridView1);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "창고", "STORE_CODE");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "창고명", "STORE_NAME");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "창고 유형", "STORE_TYPE");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "선입선출 여부", "FIFO_FLAG");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "생성 시간", "CREATE_TIME");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "생성 사용자", "CREATE_USER_ID");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "변경 시간", "UPDATE_TIME");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "변경 사용자", "UPDATE_USER_ID");
            List<StoreVO> list = new List<StoreVO>();

            LoadData();

            StoreVO vo = new StoreVO();

            pgProperty.SelectedObject = vo;

            pgProperty.PropertySort = PropertySort.NoSort;

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            StoreVO save = (StoreVO)pgProperty.SelectedObject;
            StoreServ serv = new StoreServ();
            bool bResult = serv.Insert(save);
            if (bResult)
            {
                MessageBox.Show("등록되었습니다.");
                LoadData();
                return;
            }
            else
            {
                MessageBox.Show("등록 중 실패하였습니다.");
                return;
            }
        }
    }
}
