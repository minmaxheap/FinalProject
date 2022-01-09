using DevExpress.XtraReports.UI;
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
    public partial class frmReportPreview : Form
    {
        public frmReportPreview(XtraReport1 rpt)
        {
            InitializeComponent();
            using (ReportPrintTool tool = new ReportPrintTool(rpt))
            {
                tool.ShowPreviewDialog();
            }
        }
    }
}
