using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace POPprogram
{
    public partial class frmNewLOT : POPprogram.Base5
    {
        public frmNewLOT()
        {
            InitializeComponent();
        }

        private void frmNewLot1_Load(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Maximized;

            // Button btnSearch = new Button();
            // btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(194)))), ((int)(((byte)(229)))));
            // btnSearch.BackgroundImage = (Image)POPprogram.Properties.Resources.Search_Find1;
            // btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            // btnSearch.Text = "";
            // btnSearch.TextAlign = ContentAlignment.MiddleCenter;
            // btnSearch.Dock = DockStyle.None;
            // btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            //// btnSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            // btnSearch.Location = new System.Drawing.Point(482, 65);
            // btnSearch.Margin = new System.Windows.Forms.Padding(0);
            // btnSearch.Name = "btnSearch";
            // btnSearch.Size = new System.Drawing.Size(32, 26);
            // btnSearch.UseVisualStyleBackColor = false;
            // btnSearch.Click += BtnSearch_Click;

            // panel8.Controls.Add(btnSearch);

        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmWorkOrderDialog dlg = new frmWorkOrderDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                //선택한 작업저시 정보 텍스트박스에 보여주기
            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            //생산 LOT 생성 
        }
    }
}
