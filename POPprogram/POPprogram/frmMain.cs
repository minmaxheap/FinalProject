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
    public partial class frmMain : Form
    {
        string msUserID;


        public frmMain(string ID)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            msUserID = ID;
        }
    }
}
