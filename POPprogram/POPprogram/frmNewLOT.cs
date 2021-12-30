using POPprogram.Properties;
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

        private void frmNewLOT_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            panel8.Controls.Remove(textBox3);
            Button btnSearch = new Button();
            btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(194)))), ((int)(((byte)(229)))));
            //btnSearch.BackgroundImage = (Image)POPprogram.Properties.Resources.Search_Find1;
            //btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            btnSearch.Text = "";
            btnSearch.TextAlign = ContentAlignment.MiddleCenter;
            btnSearch.Dock = DockStyle.None;
            btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            btnSearch.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 9.75F);
            btnSearch.ForeColor = System.Drawing.SystemColors.ControlText;
            btnSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            btnSearch.Location = new System.Drawing.Point(293, 1);
            btnSearch.Margin = new System.Windows.Forms.Padding(0);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(32, 26);
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += BtnSearch_Click;

            panel8.Controls.Add(btnSearch);

        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
