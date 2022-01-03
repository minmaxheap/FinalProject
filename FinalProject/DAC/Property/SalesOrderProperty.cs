using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace DAC
{
    public class SalesOrderProperty
    {
        private DateTime order_date;
        private string sales_order_id;
        private string customer_code;
        private string product_code;
        private int order_qty;
        private string confirm_flag;
        private string ship_flag;

        private string customer_name;
        private string product_name;

        private DateTime create_time;
        private string create_user_id;
        private DateTime update_time;
        private string update_user_id;

        [System.ComponentModel.RefreshProperties(RefreshProperties.All)]
        [DisplayName("작업일자")]
        public DateTime ORDER_DATE { get { return order_date; } set { order_date = value; } }

        [DisplayName("주문서코드")]
        public string SALES_ORDER_ID { get { return sales_order_id; } set { sales_order_id = value; } }

        [DisplayName("고객사")]
        [TypeConverter(typeof(CustomerCodeConverter))]
        public string CUSTOMER_CODE { get { return customer_code; }set { customer_code = value; }}

        [DisplayName("고객사명")]
        public string CUSTOMER_NAME { get { return customer_name; } set { customer_name = value; } }

        [DisplayName("품번")]
        [TypeConverter(typeof(Get_Product_CodeList_Converter))]
        public string PRODUCT_CODE { get { return product_code; } set { product_code = value; } }

        [DisplayName("품명")]
        public string PRODUCT_NAME { get { return product_name; } set { product_name = value; } }

        [DisplayName("주문수량")]
        public int ORDER_QTY { get { return order_qty; } set { order_qty = value; } }

        [DisplayName("확정여부")]
        [TypeConverter(typeof(Check_Confirm_YN_Converter))]
        public string CONFIRM_FLAG { get { return confirm_flag; } set { confirm_flag = value; } }

        [DisplayName("출하여부")]
        [TypeConverter(typeof(Check_Confirm_YN_Converter))]
        public string SHIP_FLAG { get { return ship_flag; } set { ship_flag = value; } }


        [ReadOnly(true)]
        [DisplayName("생성 시간")]
        public DateTime CREATE_TIME { get { return create_time; } set { create_time = value; } }

        [ReadOnly(true)]
        [DisplayName("생성 사용자")]
        public string CREATE_USER_ID { get { return create_user_id; } set { create_user_id = value; } }

        [ReadOnly(true)]
        [DisplayName("변경 시간")]
        public DateTime UPDATE_TIME { get { return update_time; } set { update_time = value; } }

        [ReadOnly(true)]
        [DisplayName("변경 사용자")]
        public string UPDATE_USER_ID { get { return update_user_id; } set  {update_user_id = value;} }

        public SalesOrderProperty()
        {

         }

    }
    public class SalesOrderPropertySch
    {
        private DateTime search_start_date;
        private DateTime search_end_date;
        private string sales_order_id;
        private string customer_code;
        private string product_code;
        private string confirm_check;

        [System.ComponentModel.RefreshProperties(RefreshProperties.All)]
        [DisplayName("조회 시작 일자")]
        public DateTime SEARCH_START_DATE { get { return search_start_date; } set { search_start_date = value; } }

        [DisplayName("조회 종료 일자")]
        public DateTime SEARCH_END_DATE { get { return search_end_date; } set { search_end_date = value; } }

        [DisplayName("주문서코드")]
        public string SALES_ORDER_ID { get { return sales_order_id; } set { sales_order_id = value; } }

        [DisplayName("고객사")]
        [TypeConverter(typeof(CustomerCodeConverter))]
        public string CUSTOMER_CODE { get { return customer_code; } set { customer_code = value; } }

        [DisplayName("품번")]
        [TypeConverter(typeof(Get_Product_CodeList_Converter))]
        public string PRODUCT_CODE { get { return product_code; } set { product_code = value; } }

        [DisplayName("확정여부")]
        [TypeConverter(typeof(Check_Confirm_Converter))]
        public string CONFIRM_CHECK { get { return confirm_check; } set { confirm_check = value; } }




        public SalesOrderPropertySch()
        {

        }

    }
}
