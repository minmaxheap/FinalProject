using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MES_Team3.BaseForms
{
    public partial class Base1_1 : Form
    {
        public bool BIsSearchPanel 
        { 
            get { return pnlSearch.Visible; } 
            set 
            { 
                pnlSearch.Visible = value; 
                pnlProperty.Visible = true;
                pnlSearch.Visible = false;
                lblPanel.Text = "▶ 속성";
                lblPanel.BackColor = Color.FromArgb(82, 152, 216);
                btnPanel.BackColor = lblPanel.BackColor;
            } 
        }
        public bool BPropertyPanel { get { return pnlProperty.Visible; } set { pnlProperty.Visible = value; } }
        public bool BSearchPanel { get { return pnlSearch.Visible; } set { pnlSearch.Visible = value; } }
        public Base1_1()
        {
            InitializeComponent();
        }

        private void btnSearchPnl_Click(object sender, EventArgs e)
        {
            PanelVisible();
        }

        private void btnPanel_Click(object sender, EventArgs e)
        {
            PanelVisible();
        }

        private void PanelVisible()
        {
            if (pnlProperty.Visible)
            {
                pnlProperty.Visible = false;
                pnlSearch.Visible = true;
                lblPanel.Text = "▶ 검색 조건";
                lblPanel.BackColor = Color.FromArgb(164, 194, 229);
                btnPanel.BackColor = lblPanel.BackColor;

            }
            else
            {
                pnlProperty.Visible = true;
                pnlSearch.Visible = false;
                lblPanel.Text = "▶ 속성";
                lblPanel.BackColor = Color.FromArgb(82, 152, 216);
                btnPanel.BackColor = lblPanel.BackColor;

            }
        }

        
    }
}
