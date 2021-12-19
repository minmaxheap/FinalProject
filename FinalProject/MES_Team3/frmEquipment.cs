using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MES_Team3
{
    public partial class frmEquipment : Base1
    {
        public frmEquipment()
        {
            InitializeComponent();
        }

        private void frmEquipment_Load(object sender, EventArgs e)
        {
            ComboBox cbo = new ComboBox();
            cbo.FormattingEnabled = true;
            cbo.Location = textBox4.Location;
            cbo.Name = "combobox1";
            cbo.Size = textBox4.Size;

            panel7.Controls.Remove(textBox4);
            panel7.Controls.Add(cbo);
        
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
