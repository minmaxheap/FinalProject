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
    public partial class frmProductOperRelation : MES_Team3.BaseForms.Base1_1
    {
        public frmProductOperRelation()
        {
            InitializeComponent();
        }

        private void frmProductOperRelation_Load(object sender, EventArgs e)
        {

            SearchPanel = false;
            ProductVO vo = new ProductVO();

            pgProperty.SelectedObject = vo;

            pgProperty.PropertySort = PropertySort.NoSort;
        }
    }
}
