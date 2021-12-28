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
        public bool IsSearchPanel 
        { 
            get { return searchPanel.Visible; } 
            set 
            { 
                searchPanel.Visible = value; 
                propertyPanel.Visible = true;
                searchPanel.Visible = false;
                lblPanel.Text = "▶ 속성";
                lblPanel.BackColor = Color.FromArgb(82, 152, 216);
                btnPanel.BackColor = lblPanel.BackColor;
            } 
        }
        public bool PropertyPanel { get { return propertyPanel.Visible; } set { propertyPanel.Visible = value; } }
        public bool SearchPanel { get { return searchPanel.Visible; } set { searchPanel.Visible = value; } }
        public Base1_1()
        {
            InitializeComponent();
        }


        private void button3_Click(object sender, EventArgs e) 
        {
            PanelVisible();
        }

        private void btnPanel_Click(object sender, EventArgs e)
        {
            PanelVisible();
        }

        private void PanelVisible()
        {
            if (propertyPanel.Visible)
            {
                propertyPanel.Visible = false;
                searchPanel.Visible = true;
                lblPanel.Text = "▶ 검색 조건";
                lblPanel.BackColor = Color.FromArgb(164, 194, 229);
                btnPanel.BackColor = lblPanel.BackColor;

            }
            else
            {
                propertyPanel.Visible = true;
                searchPanel.Visible = false;
                lblPanel.Text = "▶ 속성";
                lblPanel.BackColor = Color.FromArgb(82, 152, 216);
                btnPanel.BackColor = lblPanel.BackColor;

            }
        }
    }
}
