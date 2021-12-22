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
        
        public frmProduct()
        {
            InitializeComponent();
        }

        private void test_Load(object sender, EventArgs e)
        {
            ProductServ serv = new ProductServ();
            DataTable dt = serv.GetProductsList();
            csDataGridView1.DataSource = dt;
            SearchPanel = false;
          
            
         
        }

        private void csDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ProductVO vo = new ProductVO(csDataGridView1.Rows[ e.RowIndex]); //데이터그리드뷰 row를 한 개만 선택되는 경우로 상정함

            propertyGrid1.SelectedObject = vo;

            propertyGrid1.PropertySort = PropertySort.NoSort;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ProductVO save = new ProductVO();
            GridItem gi = propertyGrid1.SelectedGridItem;
            while (gi.Parent != null)
            {
                gi = gi.Parent;
            }
            foreach (GridItem item in gi.GridItems)
            {
                ParseGridItems(item, save); 
            }

            ProductServ serv = new ProductServ();
            bool bResult = serv.Insert(save);
        }

        private void ParseGridItems(GridItem gi, ProductVO save)
        {
             
            if (gi.GridItemType == GridItemType.Category)
            {
                foreach (GridItem item in gi.GridItems)
                {
                    ParseGridItems(item,save);
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
                        save.CUSTOMER_CODE= gi.Value.ToString(); break;
                case "업체 코드":
                    if (gi.Value != null && gi.Value != DBNull.Value)
                        save.VENDOR_CODE = gi.Value.ToString(); break;
                case "생성 시간":
                    if (gi.Value != null && gi.Value != DBNull.Value)
                        save.CREATE_TIME = Convert.ToDateTime( gi.Value); break;
                case "생성 사용자":
                    if (gi.Value != null && gi.Value != DBNull.Value)
                        save.CREATE_USER_ID = gi.Value.ToString(); break;
                case "변경 시간":
                    if (gi.Value != null && gi.Value != DBNull.Value)
                        save.UPDATE_TIME =Convert.ToDateTime(gi.Value); break;
                case "변경 사용자":
                     if (gi.Value != null && gi.Value != DBNull.Value)
                        save.UPDATE_USER_ID = gi.Value.ToString(); break;
                default:
                    break;
            }



           
           
        }
    }
}
