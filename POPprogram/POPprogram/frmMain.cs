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
        static string titleName;
        DataTable mdtFunc;
        FunctionServ mServ;
        public static string TitleName { get { return titleName; } }
        public frmMain(string ID)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            msUserID = ID;
       


        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            mServ = new FunctionServ();
            mdtFunc = mServ.GetUserFunctionList(this.msUserID);

            //DrawMenuStrip();
            DrawMenuPanel();
            tabMenu.Visible = false;
            lblID.Text = mdtFunc.Rows[0]["USER_NAME"].ToString() + "님";



        }
        private void MenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menu = (ToolStripMenuItem)sender;

            OpenCreateForm(menu.Tag.ToString(), menu.Text.ToString());

        }



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
                titleName = frm.Text;
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
                else
                {
                    tabMenu.SelectedTab = (TabPage)this.ActiveMdiChild.Tag;
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
            btn.BackColor = Color.FromArgb(250, 250, 250);
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

      


    }
}
