using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MES_Team3
{
    public partial class frmFunction : Base1
    {
        public frmFunction()
        {
            InitializeComponent();
        }

        private void frmFunction_Load(object sender, EventArgs e)
        {
            label2.Text = "기능코드";

            //ControlHide((Control)textBox2);
            //ControlHide((Control)button8);

            ComboBox cbo = new ComboBox();
            cbo.FormattingEnabled = true;
            cbo.Location = textBox2.Location;
            cbo.Name = "combobox1";
            cbo.Size = textBox2.Size;

            panel7.Controls.Add(cbo);
            panel7.Controls.Remove(textBox2);
            panel6.Controls.Remove(button8);
            panel4.Controls.Remove(csDataGridView1);


        }

    
    }
}
