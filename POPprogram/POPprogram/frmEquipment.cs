using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace POPprogram
{
    public partial class frmEquipment : Base1
    {
        public frmEquipment()
        {
            InitializeComponent();
        }

        private void frmEquipment_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            ComboBox cbo = new ComboBox();
            cbo.FormattingEnabled = true;
            cbo.Location = textBox4.Location;
            cbo.Name = "combobox1";
            cbo.Size = textBox4.Size;

            panel7.Controls.Remove(textBox4);
            panel7.Controls.Add(cbo);
        
            
        }
    }
}
