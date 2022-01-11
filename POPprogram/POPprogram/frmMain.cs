using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POPprogram
{
    public partial class frmMain : Form
    {
        string msUserID;
        DataTable mdtFunc;
        FunctionServ mServ;

        public frmMain(string ID)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            msUserID = ID;
            lblID.Text = msUserID + " 님";


        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            mServ = new FunctionServ();
            mdtFunc = mServ.GetUserFunctionList(this.msUserID);

            //DrawMenuStrip();
            DrawMenuPanel();
            tabMenu.Visible = false;



        }
        private void MenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menu = (ToolStripMenuItem)sender;

            OpenCreateForm(menu.Tag.ToString(), menu.Text.ToString());

        }

        //private void DrawMenuStrip()
        //{
        //    DataView dv1 = new DataView(mdtFunc);
        //    dv1.RowFilter = "FUNCTION_LEVEL = 1";
        //    for (int i = 0; i < dv1.Count; i++)
        //    {
        //        ToolStripMenuItem p_menu = new ToolStripMenuItem();
        //        p_menu.Name = $"p_menu{dv1[i]["FUNCTION_CODE"].ToString()}";
        //        p_menu.Text = dv1[i]["FUNCTION_NAME"].ToString();
        //        p_menu.TextAlign = ContentAlignment.MiddleCenter;
        //        p_menu.AutoSize = false;
        //        p_menu.Size = new Size(205, 90);
        //        p_menu.Tag = dv1[i]["PROGRAM_NAME"].ToString();
        //        p_menu.BackColor = Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(194)))), ((int)(((byte)(229)))));
        //        p_menu.ForeColor = Color.White;
        //        //p_menu.Font = new System.Drawing.Font("여기어때 잘난체 OTF", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
        //        p_menu.Click += Menu_Click;
        //        this.mnuMain.Items.Add(p_menu);
        //    }


        //}

        private void Menu_Click(object sender, EventArgs e)
        {
            // ToolStripMenuItem menu = (ToolStripMenuItem)sender;
            //Label menu = (Label)sender;
            for (int i = 0; i < flpMenu.Controls.Count; i++)
            { 
                DefaultButton((Button)flpMenu.Controls[i], i); 
            }

            Button menu = (Button)sender;
            SelectedButton(menu);
            OpenCreateForm(menu.Tag.ToString(), menu.Text);
        }

        private void OpenCreateForm(string pgmName, string formText)
        {
            string sappName = Assembly.GetEntryAssembly().GetName().Name;
            Type frmType = Type.GetType($"{sappName}.{pgmName}");

            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == frmType)
                {
                    frm.Activate();
                    frm.BringToFront();

                    return;
                }
            }

            try
            {
                Form frm = (Form)Activator.CreateInstance(frmType);
                frm.MdiParent = this;
                frm.ControlBox = false;
                //frm.WindowState = FormWindowState.Maximized;
                frm.FormBorderStyle = FormBorderStyle.FixedSingle;
                frm.Dock = DockStyle.Fill;

                frm.Text = formText;
                frm.Show();

            }
            catch
            {
                MessageBox.Show("선택한 기능이 존재하지 않습니다.");

            }


        }

        private void frmMain_MdiChildActivate(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null)
            {
                tabMenu.Visible = false;
            }
            else
            {
                this.ActiveMdiChild.WindowState = FormWindowState.Maximized;

                if (this.ActiveMdiChild.Tag == null)
                {
                    TabPage tp = new TabPage("  "+this.ActiveMdiChild.Text + "      ");
                    tp.Parent = tabMenu;
                    tp.Tag = this.ActiveMdiChild;
                    tabMenu.SelectedTab = tp;

                    this.ActiveMdiChild.FormClosed += ActiveMdiChild_FormClosed;

                    this.ActiveMdiChild.Tag = tp;
                }

                if (!tabMenu.Visible)
                    tabMenu.Visible = true;
            }
        }

        private void ActiveMdiChild_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form frm = (Form)sender;
            ((TabPage)frm.Tag).Dispose();

        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("프로그램을 종료하시겠습니까?", "종료확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                this.Dispose(true);
                Application.Exit();

            }
            else
            {
                e.Cancel = true;
                return;
            }
        }

        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabMenu.SelectedTab != null)
            {
                Form frm = (Form)tabMenu.SelectedTab.Tag;
                frm.Select();
            }
        }

        private void tabMenu_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < tabMenu.TabPages.Count; i++)
            {
                var r = tabMenu.GetTabRect(i);
                var closeImage = Properties.Resources.close;
                var closeRect = new Rectangle((r.Right - closeImage.Width), r.Top + (r.Height - closeImage.Height) / 2, closeImage.Width, closeImage.Height);
                if (closeRect.Contains(e.Location))
                {
                    this.ActiveMdiChild.Close();
                    break;
                }
            }
        }

        private void DrawMenuPanel()
        {
            DataView dv1 = new DataView(mdtFunc);
            dv1.RowFilter = "FUNCTION_LEVEL = 1";
            for (int i = 0; i < dv1.Count; i++)
            {
                Button btnMenu = new Button();
                DefaultButton(btnMenu, dv1, i);


                flpMenu.Controls.Add(btnMenu);

                if (i == 0)
                {
                    Button btn = btnMenu;
                }
            }



        }

        private void DefaultButton(Button btn, DataView dv1, int i)
        {
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.Font = new System.Drawing.Font("나눔고딕", 10.5F, System.Drawing.FontStyle.Bold);
            btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            btn.Tag = dv1[i]["PROGRAM_NAME"].ToString();
            btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btn.ImageIndex = i;
            btn.ImageList = this.menuImageList;
            btn.Margin = new System.Windows.Forms.Padding(0);
            btn.Name = $"p_menu{dv1[i]["FUNCTION_CODE"].ToString()}";
            btn.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            btn.Size = new System.Drawing.Size(200, 40);
            btn.TabIndex = 0;
            btn.Text = dv1[i]["FUNCTION_NAME"].ToString();
            btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            btn.UseVisualStyleBackColor = true;
            btn.Click += Menu_Click;
        }

        private void DefaultButton(Button btn, int i)
        {
            btn.BackColor = Color.FromArgb(250, 250, 250);
            btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            btn.ImageList = this.menuImageList;
            btn.UseVisualStyleBackColor = true;
        }
        private void SelectedButton(Button btn)
        {
            btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            btn.ForeColor = System.Drawing.Color.White;
            btn.ImageList = this.selmenuImageList;
        }

        //private void DrawMenuPanel()
        //{
        //    DataView dv1 = new DataView(mdtFunc);
        //    dv1.RowFilter = "FUNCTION_LEVEL = 1";
        //    for (int i = 0; i < dv1.Count; i++)
        //    {
        //        Button btnP_Menu = new Button();
        //        btnP_Menu.Name = $"p_menu{dv1[i]["FUNCTION_CODE"].ToString()}";
        //        btnP_Menu.Text = dv1[i]["FUNCTION_NAME"].ToString();
        //        btnP_Menu.TextAlign = ContentAlignment.MiddleCenter;
        //        btnP_Menu.AutoSize = false;
        //        btnP_Menu.Margin = new Padding(3, 4, 3, 4);
        //        btnP_Menu.Size = new Size(155, 41);
        //        btnP_Menu.Tag = dv1[i]["PROGRAM_NAME"].ToString();
        //        btnP_Menu.BackColor = Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(194)))), ((int)(((byte)(229)))));
        //        btnP_Menu.ForeColor = Color.Black;
        //        //p_menu.Font = new System.Drawing.Font("여기어때 잘난체 OTF", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
        //        btnP_Menu.FlatStyle = FlatStyle.Flat;
        //        btnP_Menu.UseVisualStyleBackColor = false;
        //        btnP_Menu.Click += Menu_Click;


        //        flpMenu.Controls.Add(btnP_Menu);

        //        if (i == 0)
        //        {
        //            Button btn = btnP_Menu;
        //        }
        //    }



        //}

        //private void DrawMenuPanel()
        //{
        //    DataView dv1 = new DataView(mdtFunc);
        //    dv1.RowFilter = "FUNCTION_LEVEL = 1";
        //    for (int i = 0; i < dv1.Count; i++)
        //    {

        //        Label lblMenu = new Label();
        //        lblMenu.Name = $"p_menu{dv1[i]["FUNCTION_CODE"].ToString()}";
        //        lblMenu.Text = dv1[i]["FUNCTION_NAME"].ToString();
        //        lblMenu.TextAlign = ContentAlignment.MiddleCenter;
        //        lblMenu.ForeColor = Color.FromArgb(176, 182, 190);
        //        lblMenu.AutoSize = false;
        //        lblMenu.Size = new Size(153, 58);
        //        lblMenu.Tag = dv1[i]["PROGRAM_NAME"].ToString();              
        //        lblMenu.FlatStyle = FlatStyle.Flat;
        //        lblMenu.Image = global::POPprogram.Properties.Resources.Blank_13;
        //        lblMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
        //        lblMenu.Click += Menu_Click;


        //        flpMenu.Controls.Add(lblMenu);

        //        if (i == 0)
        //        {
        //            Label lbl = lblMenu;
        //        }
        //    }



        //}


    }
}
