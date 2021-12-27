using DAC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using VO;

namespace MES_Team3
{
    public partial class frmProcess : MES_Team3.BaseForms.Base1_1
    {
        public frmProcess()
        {
            InitializeComponent();
        }

        private void pgSearch_Click(object sender, EventArgs e)
        {

        }

        private void pgProperty_Click(object sender, EventArgs e)
        {

        }

        private void frmProcess_Load(object sender, EventArgs e)
        {
            LoadData();

            ProcessProperty vo = new ProcessProperty();

            pgProperty.SelectedObject = vo;

            pgProperty.PropertySort = PropertySort.NoSort;
        }
        public void LoadData()
        {
            ProductServ serv = new ProductServ();
           List<ProductProperty> list = serv.GetProductsList();
            csDataGridView1.DataSource = null;
            csDataGridView1.DataSource = list;
            SearchPanel = false;
        }
    }
}
