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
        FlowLayoutPanel mPnlMenu;
        TreeView mTrvMenu;
        FunctionServ mServ;

        public string SUserID { get { return msUserID; } set { } }
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
                Button btnMenu = new Button();

                DefaultButton(btnMenu, dv1, i);

                flpMenu.Controls.Add(btnMenu);

                if (i == 0)
                {
                    Button btn = btnMenu;
                }
            }

            mPnlMenu = new FlowLayoutPanel();
            mPnlMenu.BackColor = Color.White;
            mPnlMenu.Dock = DockStyle.Bottom;
            mPnlMenu.Location = new Point(3, (dv1.Count * 40));
            mPnlMenu.Margin = new Padding(0,0,0,0);
            mPnlMenu.Name = "panel1";
            mPnlMenu.Size = new Size(190, 300);
            flpMenu.Controls.Add(this.mPnlMenu);

            //mTrvMenu = new TreeView();
            //mTrvMenu.Dock = DockStyle.Fill;
            //mTrvMenu.Location = new Point(0, 0);
            //mTrvMenu.Name = "treeView1";
            //mTrvMenu.Size = new Size(180, 300);
            //mTrvMenu.AfterSelect += TreeView1_AfterSelect;
            //mPnlMenu.Controls.Add(this.mTrvMenu);

        }

        //private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        //{
        //    OpenCreateForm(e.Node.Tag.ToString(), e.Node.Text);
        //}

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
                frm.FormBorderStyle = FormBorderStyle.FixedSingle;
                frm.Dock = DockStyle.Fill;
                //frm.WindowState = FormWindowState.Maximized;
              
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
                //this.ActiveMdiChild.WindowState = FormWindowState.Maximized;

                if (this.ActiveMdiChild.Tag == null)
                {
                    TabPage tp = new TabPage(this.ActiveMdiChild.Text + "    ");
                    tp.Parent = tabMenu;
                    tp.Tag = this.ActiveMdiChild;
                    tabMenu.SelectedTab = tp;

                    this.ActiveMdiChild.FormClosed += ActiveMdiChild_FormClosed;

                    this.ActiveMdiChild.Tag = tp;
                }
                else
                {
                    tabControl1.SelectedTab = (TabPage)this.ActiveMdiChild.Tag;
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
           // Label btnMenu = (Label)sender;
            flpMenu.Controls.SetChildIndex(mPnlMenu, Convert.ToInt32(btnMenu.Tag) + 1);
            flpMenu.Invalidate();
            mPnlMenu.Controls.Clear();
            
            //mTrvMenu.Nodes.Clear();

            DataView dv2 = new DataView(mdtFunc);
            dv2.RowFilter = $"FUNCTION_LEVEL=2 and PNT_FUNCTION_CODE = '{btnMenu.Name.Replace("p_btn", "")}'";
            for (int k = 0; k < dv2.Count; k++)
            {
                Button btnChild = new Button();
                DefaultChildButton(btnChild, dv2, k);
                mPnlMenu.Controls.Add(btnChild);


                if (k == 0)
                {
                    Button btn = btnChild;
                }

               

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

        private void DefaultButton(Button btn, DataView dv1, int i)
        {
            btn.BackColor = Color.FromArgb(250, 250, 250);
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.Font = new System.Drawing.Font("나눔고딕", 10.5F, System.Drawing.FontStyle.Bold);
            btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            btn.Tag = i.ToString();
            btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btn.ImageIndex = i;
            btn.ImageList = this.menuImageList;
            btn.Margin = new System.Windows.Forms.Padding(0);
            btn.Name = $"p_btn{dv1[i]["FUNCTION_CODE"].ToString()}";
            btn.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            btn.Size = new System.Drawing.Size(200, 40);
            btn.TabIndex = 0;
            btn.Text = dv1[i]["FUNCTION_NAME"].ToString();
            btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            btn.UseVisualStyleBackColor = true;
            btn.Click += btnMenu_Click;

            //Label lblMenu = new Label();
            //lblMenu.Name = $"p_btn{dv1[i]["FUNCTION_CODE"].ToString()}";
            //lblMenu.Text = dv1[i]["FUNCTION_NAME"].ToString();
            //lblMenu.TextAlign = ContentAlignment.MiddleCenter;
            //lblMenu.ForeColor = Color.FromArgb(176, 182, 190);
            //lblMenu.AutoSize = false;
            //lblMenu.Dock = DockStyle.Top;
            //lblMenu.Location = new Point(0);
            ////lblMenu.Margin = new Padding(3,4,3,4);
            //lblMenu.Size = new Size(155, 41);
            //lblMenu.Tag = i.ToString();
            //lblMenu.FlatStyle = FlatStyle.Flat;
            //lblMenu.Image = global::MES_Team3.Properties.Resources.Blank_13;
            //lblMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            //lblMenu.Click += btnMenu_Click;
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
        private void DefaultChildButton(Button btn, DataView dv2, int k)
        {
            btn.BackColor = Color.FromArgb(250, 250, 250);
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.Font = new System.Drawing.Font("나눔고딕", 10.5F, System.Drawing.FontStyle.Bold);
            btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            btn.Tag = dv2[k]["PROGRAM_NAME"].ToString();
            btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btn.ImageIndex = k;
            btn.ImageList = this.menuImageList;
            btn.Margin = new System.Windows.Forms.Padding(0);
            btn.Name = dv2[k]["FUNCTION_CODE"].ToString();
            btn.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            btn.Size = new System.Drawing.Size(200, 40);
            btn.TabIndex = 0;
            btn.Text = dv2[k]["FUNCTION_NAME"].ToString();
            btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            btn.UseVisualStyleBackColor = true;
            btn.Click += ChildBtn_Click;
            //TreeNode c_node = new TreeNode(dv2[k]["FUNCTION_NAME"].ToString());
            //c_node.Tag = dv2[k]["PROGRAM_NAME"].ToString();
            //mTrvMenu.Nodes.Add(btnChild);

        }

        private void ChildBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < mPnlMenu.Controls.Count; i++)
            {
                DefaultButton((Button)mPnlMenu.Controls[i], i);
            }

            Button menu = (Button)sender;
            SelectedButton(menu);
            OpenCreateForm(menu.Tag.ToString(), menu.Text);
        }
    }
}
