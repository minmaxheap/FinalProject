using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POPprogram
{
    public partial class Base1 : Form
    {
        public Base1()
        {
            InitializeComponent();
        }

        public void NewTextBox(TextBox name, Size size, Point point)
        {
            TextBox txtUpdateID = new TextBox();
            txtUpdateID.Text = "";
            txtUpdateID.Name = "txtUpdateID";
            txtUpdateID.Font = new System.Drawing.Font("나눔고딕", 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(129)));
            txtUpdateID.Location = new System.Drawing.Point(textBox10.Location.X, textBox10.Location.Y + label12.Height);
            txtUpdateID.Margin = new System.Windows.Forms.Padding(0);
            txtUpdateID.Size = new System.Drawing.Size(216, 22);
            

        }

        private void Base1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
