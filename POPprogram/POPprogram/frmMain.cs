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
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            mServ = new FunctionServ();
            mdtFunc = mServ.GetUserFunctionList(this.msUserID);

            DrawMenuStrip();

            //tabMenu.Visible = false;
      
      

        }
        private void MenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menu = (ToolStripMenuItem)sender;

            OpenCreateForm(menu.Tag.ToString(), menu.Text.ToString() );

        }

        private void DrawMenuStrip()
        {
            DataView dv1 = new DataView(mdtFunc);
            dv1.RowFilter = "FUNCTION_LEVEL = 1";
            for (int i = 0; i < dv1.Count; i++)
            {
                ToolStripMenuItem p_menu = new ToolStripMenuItem();
                p_menu.Name = $"p_menu{dv1[i]["FUNCTION_CODE"].ToString()}";
                p_menu.Text = dv1[i]["FUNCTION_NAME"].ToString();
                p_menu.Size = new Size(187, 41);
                p_menu.Tag = dv1[i]["PROGRAM_NAME"].ToString();
                p_menu.Font = new System.Drawing.Font("여기어때 잘난체 OTF", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                p_menu.Click += Menu_Click;
                this.mnuMain.Items.Add(p_menu);
            }


        }

        private void Menu_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menu = (ToolStripMenuItem)sender;
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
                frm.WindowState = FormWindowState.Maximized;
                frm.ControlBox = false;
                frm.FormBorderStyle = FormBorderStyle.None;
      
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
            //if (this.ActiveMdiChild == null)
            //{
            //    tabMenu.Visible = false;
            //}
            //else
            //{
               this.ActiveMdiChild.WindowState = FormWindowState.Maximized;

            //    if (this.ActiveMdiChild.Tag == null)
            //    {
            //        TabPage tp = new TabPage(this.ActiveMdiChild.Text + "    ");
            //        tp.Parent = tabMenu;
            //        tp.Tag = this.ActiveMdiChild;
            //        tabMenu.SelectedTab = tp;

            //        this.ActiveMdiChild.FormClosed += ActiveMdiChild_FormClosed;

            //        this.ActiveMdiChild.Tag = tp;
            //    }

            //    if (!tabMenu.Visible)
            //        tabMenu.Visible = true;
            //}
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
            //if (tabMenu.SelectedTab != null)
            //{
            //    Form frm = (Form)tabMenu.SelectedTab.Tag;
            //    frm.Select();
            //}
        }

        private void tabMenu_MouseDown(object sender, MouseEventArgs e)
        {
        //    for (int i = 0; i < tabMenu.TabPages.Count; i++)
        //    {
        //        var r = tabMenu.GetTabRect(i);
        //        var closeImage = Properties.Resources.close;
        //        var closeRect = new Rectangle((r.Right - closeImage.Width), r.Top + (r.Height - closeImage.Height) / 2, closeImage.Width, closeImage.Height);
        //        if (closeRect.Contains(e.Location))
        //        {
        //            this.ActiveMdiChild.Close();
        //            break;
        //        }
        //    }
        }

     
    }
}
