using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MES_Team3
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            TextBox txt8 = new TextBox();
            txt8.Font = new System.Drawing.Font("나눔고딕", 8.249999F);
            txt8.Location = new System.Drawing.Point(100, 100);
            txt8.Margin = new System.Windows.Forms.Padding(0);
            txt8.Name = "txt8";
            txt8.Size = new System.Drawing.Size(183, 20);

            //위 코드처럼 라벨, 콤보박스, 데이트타임피커, 텍스트박스를 모듈화해서 테이블레이아웃패널에 넣을 수 있다.
            //근데 custom control로 해서 끌어놓기만 하면 더 편한 거 아닐까?
            //util로 만들면 코드가 더 길어질 텐데 선생님한테 물어봐야겠다.
            
            //csTableLayout1.Controls.Add(txt8, 1, 7);
            //csTableLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
           // this.csTableLayout1.Size = new System.Drawing.Size(283, 180);
            

        }

        private void csTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
