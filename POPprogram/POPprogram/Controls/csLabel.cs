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
    public partial class csLabel : Label
    {
        public csLabel()
        {
            InitializeComponent();
            BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            Margin = new System.Windows.Forms.Padding(0);
            Size = new System.Drawing.Size(100, 20);
            TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
