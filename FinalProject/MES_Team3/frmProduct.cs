using DAC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
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

            LoadData();

            ProductProperty vo = new ProductProperty();

            pgProperty.SelectedObject = vo;

            pgProperty.PropertySort = PropertySort.NoSort;


            //m_dctd = ProviderInstaller.Install(this);
            //m_dctd.PropertySortOrder = CustomSortOrder.AscendingByName;
            //m_dctd.CategorySortOrder = CustomSortOrder.DescendingByName;

            //// now lets modify some attribute of PropA
            //CustomPropertyDescriptor cpd = m_pdm.GetProperty("PropA");
            //cpd.SetDisplayName("New display name of PropA");
            //cpd.SetDescription("New description of PropA");
            //cpd.SetCategory("New Category of PropA");
            //cpd.SetIsReadOnly(true); // disables the property
            //cpd.SetIsBrowsable(true);  // hides the property
            //cpd.CategoryID = 4;

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

            ProductProperty save = (ProductProperty)pgProperty.SelectedObject;
            ProductServ serv = new ProductServ();
            bool bResult = serv.Insert(save);
            if (bResult)
            {
                LoadData();
            }
            else
            {
                
            }
        }

        //private void ParseGridItems(GridItem gi, ProductVO save)
        //{

        //    if (gi.GridItemType == GridItemType.Category)
        //    {
        //        foreach (GridItem item in gi.GridItems)
        //        {
        //            ParseGridItems(item, save);
        //        }
        //    }
        //    switch (gi.Label)
        //    {
        //        case "품번": if (gi.Value != null && gi.Value != DBNull.Value) save.PRODUCT_CODE = gi.Value.ToString(); break;
        //        case "품명": if (gi.Value != null && gi.Value != DBNull.Value) save.PRODUCT_NAME = gi.Value.ToString(); break;
        //        case "품번 유형":
        //            if (gi.Value != null && gi.Value != DBNull.Value)
        //                save.PRODUCT_TYPE = gi.Value.ToString(); break;
        //        case "고객 코드":
        //            if (gi.Value != null && gi.Value != DBNull.Value)
        //                save.CUSTOMER_CODE = gi.Value.ToString(); break;
        //        case "업체 코드":
        //            if (gi.Value != null && gi.Value != DBNull.Value)
        //                save.VENDOR_CODE = gi.Value.ToString(); break;
        //        case "생성 시간":
        //            if (gi.Value != null && gi.Value != DBNull.Value)
        //                save.CREATE_TIME = Convert.ToDateTime(gi.Value); break;
        //        case "생성 사용자":
        //            if (gi.Value != null && gi.Value != DBNull.Value)
        //                save.CREATE_USER_ID = gi.Value.ToString(); break;
        //        case "변경 시간":
        //            if (gi.Value != null && gi.Value != DBNull.Value)
        //                save.UPDATE_TIME = Convert.ToDateTime(gi.Value); break;
        //        case "변경 사용자":
        //            if (gi.Value != null && gi.Value != DBNull.Value)
        //                save.UPDATE_USER_ID = gi.Value.ToString(); break;
        //        default:
        //            break;
        //    }





        //}

        private void csDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = csDataGridView1.Rows[e.RowIndex];
            ProductProperty vo = new ProductProperty();
            vo.PRODUCT_CODE = dr.Cells["PRODUCT_CODE"].Value.ToString();
            vo.PRODUCT_NAME = dr.Cells["PRODUCT_NAME"].Value.ToString();
            vo.PRODUCT_TYPE = dr.Cells["PRODUCT_TYPE"].Value.ToString();
            vo.CUSTOMER_CODE = dr.Cells["CUSTOMER_CODE"].Value.ToString();
            vo.VENDOR_CODE = dr.Cells["VENDOR_CODE"].Value.ToString();
            if (csDataGridView1.Rows[e.RowIndex].Cells["CREATE_TIME"].Value != null && dr.Cells["CREATE_TIME"].Value != DBNull.Value)
                vo.CREATE_TIME = Convert.ToDateTime(dr.Cells["CREATE_TIME"].Value);
            vo.CREATE_USER_ID = csDataGridView1.Rows[e.RowIndex].Cells["CREATE_USER_ID"].Value.ToString();
            if (dr.Cells["UPDATE_TIME"].Value != null && dr.Cells["UPDATE_TIME"].Value != DBNull.Value)
                vo.UPDATE_TIME = Convert.ToDateTime(dr.Cells["UPDATE_TIME"].Value);
            vo.UPDATE_USER_ID = dr.Cells["UPDATE_USER_ID"].Value.ToString();
            //ProductVO vo = new ProductVO(csDataGridView1.Rows[e.RowIndex]); //데이터그리드뷰 row를 한 개만 선택되는 경우로 상정함

            pgProperty.SelectedObject = vo;

            pgProperty.PropertySort = PropertySort.NoSort;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //pk를 받아서 delete 하기 //이거 유틸로 할 수 있지 않을까? 

            ProductProperty save = (ProductProperty)pgProperty.SelectedObject;
            ProductServ serv = new ProductServ();
            bool bResult = serv.Delete(save);
            LoadData();

        }

        public void LoadData()
        {
            ProductServ serv = new ProductServ();
            DataTable dt = serv.GetProductsList();
            csDataGridView1.DataSource = null;
            csDataGridView1.DataSource = dt;
            SearchPanel = false;
        }

		private void button3_Click(object sender, EventArgs e)
		{

            ProductProperty search = new ProductProperty();
            search.IsSearchPanel = true;
            //PropertyDescriptorCollection propCollection = TypeDescriptor.GetProperties(search.GetType()); 
            //PropertyDescriptor descriptor = propCollection["UPDATE_USER_ID"];
            //BrowsableAttribute attrib = (BrowsableAttribute)descriptor.Attributes[typeof(BrowsableAttribute)]; 
            //FieldInfo isBrow = attrib.GetType().GetField("browsable", BindingFlags.NonPublic | BindingFlags.Instance); 
            ////Condition to Show or Hide set here:
            //isBrow.SetValue(attrib, false);

            //pgSearch.Refresh(); //Remember to refresh
          
            pgSearch.SelectedObject = search;
            pgSearch.PropertySort = PropertySort.NoSort;
            // propertyPanel.Visible = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ProductProperty save = (ProductProperty)pgProperty.SelectedObject;
            ProductServ serv = new ProductServ();
            bool bResult = serv.Update(save);
            LoadData();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            ProductProperty search = (ProductProperty)pgSearch.SelectedObject;
            ProductServ serv = new ProductServ();
            List<ProductProperty> list = serv.GetProductSearch(search);
            csDataGridView1.DataSource = list;

        }
    }


}
