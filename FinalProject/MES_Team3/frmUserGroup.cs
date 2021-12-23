using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MES_Team3
{
	public partial class frmUserGroup : MES_Team3.BaseForms.Base1_1
	{
		public frmUserGroup()
		{
			InitializeComponent();
		}

		private void frmUserGroup_Load(object sender, EventArgs e)
		{
			searchPanel.Visible = false;
			DataGridViewUtil.SetInitGridView(csDataGridView1);


		}
	}
}
