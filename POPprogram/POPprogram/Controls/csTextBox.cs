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
    public partial class csTextBox : TextBox
    {
        public csTextBox()
        {
            InitializeComponent();
            Font = new System.Drawing.Font("나눔고딕", 8.249999F);
            //Location = new System.Drawing.Point(100, 100);
            Margin = new System.Windows.Forms.Padding(0);
            //Name = "txt8";
            Size = new System.Drawing.Size(183, 20);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
