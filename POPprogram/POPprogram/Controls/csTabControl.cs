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
    public partial class csTabControl : TabControl
    {
        //닫기 이미지를 사용자가 그리기 위해서는 DrawMode 속성을 변경하고, DrawItem 이벤트를 구현해야 한다.

        public csTabControl()
        {
            InitializeComponent();

            this.DrawMode = TabDrawMode.OwnerDrawFixed;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);

            try
            {
                Rectangle r = e.Bounds;
                r = this.GetTabRect(e.Index);
                r.Offset(2, 2);

                if (this.SelectedIndex == e.Index)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.White), e.Bounds);
                }

                SolidBrush titleBrush = new SolidBrush(Color.Black);
                string title = this.TabPages[e.Index].Text;
                Font f = this.Font;
                e.Graphics.DrawString(title, f, titleBrush, new Point(r.X, r.Y));


                Image img;
                if (this.SelectedIndex == e.Index)
                    img = Properties.Resources.close;
                else
                    img = Properties.Resources.close_white;

                Point imgLocation = new Point(18, 2);

                e.Graphics.DrawImage(img, new Point(r.X + this.GetTabRect(e.Index).Width - imgLocation.X, imgLocation.Y));

                img.Dispose();
                img = null;
            }
            catch
            {

            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
