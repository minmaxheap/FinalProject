﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace POPprogram
{
    public partial class frmStockIN : POPprogram.Base2
    {
        StockServ serv;

        List<string> MstList = null;
        public frmStockIN()
        {
            InitializeComponent();
        }

		public string name { get; set;}

		private void btnReadTop_Click(object sender, EventArgs e)
        {
            serv = new StockServ();
            DataTable dt = serv.Purchase_warehousing(txtSearch.Text);
            csDataGridView1.DataSource = null;
            csDataGridView1.DataSource = dt;
        }

        private void btnTxtSearch_Click(object sender, EventArgs e)
        {
            frmPrurchaseDialog dlg = new frmPrurchaseDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                DataGridViewRow dr = dlg.SelectedRow;
                txtSearch.Text = dr.Cells["PURCHASE_ORDER_ID"].Value.ToString();
                txtCode1.Text = dr.Cells["MATERIAL_CODE"].Value.ToString();
                txtName1.Text = dr.Cells["PRODUCT_NAME"].Value.ToString();
                txtCode2.Text = dr.Cells["VENDOR_CODE"].Value.ToString();
                txtName2.Text = dr.Cells["VENDOR_NAME"].Value.ToString();
                txtCode3.Text = dr.Cells["ORDER_QTY"].Value.ToString();

            }
        }

        private void frmStockIN_Load(object sender, EventArgs e)
        {

            DataGridViewUtil.SetInitGridView(csDataGridView1);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "순번", "RowNum");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "자재 품번", "CHILD_PRODUCT_CODE");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "자재 품명", "PRODUCT_NAME");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "단위 수량", "REQUIRE_QTY");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "수량", "수량");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "자재LOTID", "STOCK_IN_LOT_ID");


            LoadData();
        }

        private void LoadData()
        { 
            serv = new StockServ();
            MstList = serv.GetStore_Code();
            MstList.Insert(0, "");
            comboBox1.ValueMember = "STORE_CODE";
            comboBox1.DisplayMember = "STORE_CODE";
            comboBox1.DataSource = MstList;

        }

        private void csDataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex == -1)
            {
                e.PaintBackground(e.ClipBounds, false);

                Point pt = e.CellBounds.Location;  // where you want the bitmap in the cell

                int nChkBoxWidth = 15;
                int nChkBoxHeight = 15;
                int offsetx = (e.CellBounds.Width - nChkBoxWidth) / 2;
                int offsety = (e.CellBounds.Height - nChkBoxHeight) / 2;

                pt.X += offsetx;
                pt.Y += offsety;

                CheckBox cb = new CheckBox();
                cb.Size = new Size(nChkBoxWidth, nChkBoxHeight);
                cb.Location = pt;
                cb.CheckedChanged += new EventHandler(csDataGridView1CheckBox_CheckedChanged);

                ((DataGridView)sender).Controls.Add(cb);

                e.Handled = true;
            }

        }
        private void csDataGridView1CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in csDataGridView1.Rows)
            {
                r.Cells["Column1"].Value = ((CheckBox)sender).Checked;
            }
        }

        //private void DgvChk(DataGridView dgv)
        //{
        //    dgv.EndEdit();
        //    dgvChk = new DataGridViewCheckBoxColumn();
        //    dgvChk.HeaderText = " ";
        //    dgvChk.Name = "chk";
        //    dgvChk.Width = 40;

        //    dgv.Columns.Add(dgvChk);
        //}
    }
}
