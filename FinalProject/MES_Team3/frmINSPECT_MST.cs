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
    public partial class frmINSPECT_MST : MES_Team3.BaseForms.Base1_1
    {
        public frmINSPECT_MST()
        {
            InitializeComponent();
        }

		private void frmINSPECT_MST_Load(object sender, EventArgs e)
		{
            SearchPanel = false;
            INSPECT_MSTVO vo = new INSPECT_MSTVO();

            pgGrid.SelectedObject = vo;

            pgGrid.PropertySort = PropertySort.NoSort;
        }

		private void Search_Grid_Click(object sender, EventArgs e)
		{

		}
	}
}
