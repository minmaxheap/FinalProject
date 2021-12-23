using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VO;

namespace MES_Team3
{
    public partial class frmProduct : MES_Team3.BaseForms.Base1_1
    {
        //public List<Bar> barlist;
        
        public frmProduct()
        {
            InitializeComponent();
        }

        private void frmProduct1_Load(object sender, EventArgs e)
        {
            DataGridViewUtil.SetInitGridView(csDataGridView1);
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "품번", "PRODUCT_CODE");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "품명", "PRODUCT_NAME");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "품번 유형", "PRODUCT_TYPE");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "고객 코드", "CUSTOMER_CODE");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "업체 코드", "VENDOR_CODE");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "생성 시간", "CREATE_TIME");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "생성 사용자", "CREATE_USER_ID");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "변경 시간", "UPDATE_TIME");
            DataGridViewUtil.AddGridTextColumn(csDataGridView1, "변경 사용자", "UPDATE_USER_ID");

            GetInfo();


            //barlist = new List<Bar>();
            //for (int i = 1; i < 10; i++)
            //{
            //    Bar bar = new Bar();
            //    bar.barvalue = "BarObject " + i;
            //    barlist.Add(bar);
            //    //comboBox1.Items.Add(bar);
            //}
            //ProductVO vo = new ProductVO();
            //vo.PRODUCT_TYPE = new Bar();
            //vo.CUSTOMER_CODE = new Bar();
            //vo.VENDOR_CODE = new Bar();
        }

        
        private void btnInsert_Click(object sender, EventArgs e)
        {
            //ProductVO save = new ProductVO();
            //GridItem gi = pgProperty.SelectedGridItem;
            //while (gi.Parent != null)
            //{
            //    gi = gi.Parent;
            //}
            //foreach (GridItem item in gi.GridItems)
            //{
            //    ParseGridItems(item, save);
            //}

            ProductVO save = (ProductVO)pgProperty.SelectedObject;
            ProductServ serv = new ProductServ();
            bool bResult = serv.Insert(save);
            if (bResult)
            {
                GetInfo();
            }
            else
            {
                
            }
        }

        private void ParseGridItems(GridItem gi, ProductVO save)
        {

            if (gi.GridItemType == GridItemType.Category)
            {
                foreach (GridItem item in gi.GridItems)
                {
                    ParseGridItems(item, save);
                }
            }
            switch (gi.Label)
            {
                case "품번": if (gi.Value != null && gi.Value != DBNull.Value) save.PRODUCT_CODE = gi.Value.ToString(); break;
                case "품명": if (gi.Value != null && gi.Value != DBNull.Value) save.PRODUCT_NAME = gi.Value.ToString(); break;
                case "품번 유형":
                    if (gi.Value != null && gi.Value != DBNull.Value)
                        save.PRODUCT_TYPE = gi.Value.ToString(); break;
                case "고객 코드":
                    if (gi.Value != null && gi.Value != DBNull.Value)
                        save.CUSTOMER_CODE = gi.Value.ToString(); break;
                case "업체 코드":
                    if (gi.Value != null && gi.Value != DBNull.Value)
                        save.VENDOR_CODE = gi.Value.ToString(); break;
                case "생성 시간":
                    if (gi.Value != null && gi.Value != DBNull.Value)
                        save.CREATE_TIME = Convert.ToDateTime(gi.Value); break;
                case "생성 사용자":
                    if (gi.Value != null && gi.Value != DBNull.Value)
                        save.CREATE_USER_ID = gi.Value.ToString(); break;
                case "변경 시간":
                    if (gi.Value != null && gi.Value != DBNull.Value)
                        save.UPDATE_TIME = Convert.ToDateTime(gi.Value); break;
                case "변경 사용자":
                    if (gi.Value != null && gi.Value != DBNull.Value)
                        save.UPDATE_USER_ID = gi.Value.ToString(); break;
                default:
                    break;
            }





        }

        private void csDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ProductVO vo = new ProductVO(csDataGridView1.Rows[e.RowIndex]); //데이터그리드뷰 row를 한 개만 선택되는 경우로 상정함

            pgProperty.SelectedObject = vo;

            pgProperty.PropertySort = PropertySort.NoSort;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //pk를 받아서 delete 하기 //이거 유틸로 할 수 있지 않을까? 
            ProductVO save = new ProductVO();
            GridItem gi = pgProperty.SelectedGridItem;
            while (gi.Parent != null)
            {
                gi = gi.Parent;
            }
            foreach (GridItem item in gi.GridItems)
            {
                ParseGridItems(item, save);
            }

            ProductServ serv = new ProductServ();
            bool bResult = serv.Delete(save);
            GetInfo();

        }

        public void GetInfo()
        {
            ProductServ serv = new ProductServ();
            DataTable dt = serv.GetProductsList();
            csDataGridView1.DataSource = null;
            csDataGridView1.DataSource = dt;
            SearchPanel = false;
        }
    }


}
