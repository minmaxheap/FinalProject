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
        public bool PropertyPanel { get { return propertyPanel.Visible; } set { propertyPanel.Visible = value; } }
        public bool SearchPanel { get { return searchPanel.Visible; } set { searchPanel.Visible = value; } }
        public Base1_1()
        {
            InitializeComponent();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            propertyPanel.Visible = true;
            searchPanel.Visible = false;
        }

        private void btnPanel_Click(object sender, EventArgs e)
        {
            if (propertyPanel.Visible) 
            { 
                propertyPanel.Visible = false;
                searchPanel.Visible = true;
                lblPanel.Text = "▶ 조회 조건";

            }
            else
            {
                propertyPanel.Visible = true;
                searchPanel.Visible = false;
                lblPanel.Text = "▶ 속성";

            }
        }
    }
}
