using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VO;

namespace MES_Team3
{
    public partial class frmProduct : MES_Team3.BaseForms.Base1_1
    {
        public frmProduct()
        {
            InitializeComponent();
        }

        private void test_Load(object sender, EventArgs e)
        {
            ProductVO vo = new ProductVO();

            propertyGrid1.SelectedObject = vo;
   
            propertyGrid1.PropertySort = PropertySort.NoSort;
        }
    }
}
