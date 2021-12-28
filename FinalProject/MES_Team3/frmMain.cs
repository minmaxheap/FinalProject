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

namespace MES_Team3
{
    public partial class frmMain : Form
    {
        string msUserID;
        DataTable mdtFunc;
        Panel mPnlMenu;
        TreeView mTrvMenu;
        FunctionServ mServ;

        public string SUserID { get { return msUserID; } set { msUserID = value; } }
        public frmMain(string ID)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            msUserID = ID;
            lblID.Text = msUserID + " 님";
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            tabMenu.Visible = false;
            mServ = new FunctionServ();
            mdtFunc = mServ.GetUserFunctionList(this.msUserID);
            DrawMenuPanel();


        }

        private void DrawMenuPanel()
        {
            DataView dv1 = new DataView(mdtFunc);
            dv1.RowFilter = "FUNCTION_LEVEL = 1";
            for (int i = 0; i < dv1.Count; i++)
            {
                Button btnP_Menu = new Button();
                btnP_Menu.Name = $"p_btn{dv1[i]["FUNCTION_CODE"].ToString()}";
                btnP_Menu.Text = dv1[i]["FUNCTION_NAME"].ToString();
                btnP_Menu.TextAlign = ContentAlignment.MiddleCenter;
                btnP_Menu.Dock = DockStyle.Top;
                btnP_Menu.Location = new Point(0);
                btnP_Menu.Margin = new Padding(3,4,3,4);
                btnP_Menu.Size = new Size(155, 41);
                btnP_Menu.Tag = i.ToString();
               // p_menu.Font = new Font("나눔스퀘어OTF Bold", 11F, FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                btnP_Menu.BackColor = Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(194)))), ((int)(((byte)(229)))));
                btnP_Menu.FlatStyle = FlatStyle.Flat;
                btnP_Menu.UseVisualStyleBackColor = false;
                btnP_Menu.Click += btnMenu_Click;

    
                flpMenu.Controls.Add(btnP_Menu);

                if (i == 0)
                {
                    Button btn = btnP_Menu;
                }
            }

            mPnlMenu = new Panel();
            mPnlMenu.Dock = DockStyle.Bottom;
            mPnlMenu.Location = new Point(3, (dv1.Count * 40));
            mPnlMenu.Margin = new Padding(3, 4, 3, 4);
            mPnlMenu.Name = "panel1";
            mPnlMenu.Size = new Size(155, 300);
            flpMenu.Controls.Add(this.mPnlMenu);

            mTrvMenu = new TreeView();
            mTrvMenu.Dock = DockStyle.Fill;
            mTrvMenu.Location = new Point(0, 0);
            mTrvMenu.Name = "treeView1";
            mTrvMenu.Size = new Size(120, 300);
            mTrvMenu.AfterSelect += TreeView1_AfterSelect;
            mPnlMenu.Controls.Add(this.mTrvMenu);
       
        }

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            OpenCreateForm(e.Node.Tag.ToString(), e.Node.Text);
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
             
                //frm.ControlBox = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.WindowState = FormWindowState.Maximized;
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
                    TabPage tp = new TabPage(this.ActiveMdiChild.Text + "    ");
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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabMenu.SelectedTab != null)
            {
                Form frm = (Form)tabMenu.SelectedTab.Tag;
                frm.Select();
            }
        }

        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
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

        private void btnMenu_Click(object sender, EventArgs e)
        {
            Button btnMenu = (Button)sender;
            flpMenu.Controls.SetChildIndex(mPnlMenu, Convert.ToInt32(btnMenu.Tag) + 1);
            flpMenu.Invalidate();

            mTrvMenu.Nodes.Clear();

            DataView dv2 = new DataView(mdtFunc);
            dv2.RowFilter = $"FUNCTION_LEVEL=2 and PNT_FUNCTION_CODE = '{btnMenu.Name.Replace("p_btn", "")}'";
            for (int k = 0; k < dv2.Count; k++)
            {
                TreeNode c_node = new TreeNode(dv2[k]["FUNCTION_NAME"].ToString());
                c_node.Tag = dv2[k]["PROGRAM_NAME"].ToString();
                mTrvMenu.Nodes.Add(c_node);
            }
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

     
    }
}
