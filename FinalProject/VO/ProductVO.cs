using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VO
{
    public class ProductVO
    {
        List<string> cboList;
        //public Bar mybar;
        public enum CustomEnum { TEST1, TEST2, TEST3 } //콤보 박스로 하고 싶으면 enum 이용하기! enum을 생성하는 쿼리문을 짜야하지 않을까 싶다.

        private string product_code;
        private string product_name;
        private string product_type;
        private string customer_code;
        private string vendor_code;
        private DateTime create_time;
        private string create_user_id;
        private DateTime update_time;
        private string update_user_id;

        [DisplayName("품번")]
        public string PRODUCT_CODE   { get { return product_code; } set { product_code = value; } }
        
        [DisplayName("품명")]
        public string PRODUCT_NAME { get { return product_name; } set { product_name = value; } }
        [DisplayName("품번 유형")] //콤보박스
        //[TypeConverter(typeof(BarConverter))]
        public string PRODUCT_TYPE { get { return product_type; } set { product_type = value; } }
        [DisplayName("고객 코드")] //콤보박스
        //[TypeConverter(typeof(BarConverter))]
        public string CUSTOMER_CODE { get { return customer_code; } set { customer_code = value; } }
        [DisplayName("업체 코드")] //콤보박스
        //[TypeConverter(typeof(BarConverter))]
        public string VENDOR_CODE { get { return vendor_code; } set { vendor_code = value; } }


        [DisplayName("생성 시간")]
        public DateTime CREATE_TIME { get { return create_time; } set { create_time = value; } } 
        [DisplayName("생성 사용자")]
        public string CREATE_USER_ID { get { return create_user_id; } set { create_user_id = value; } }
        [DisplayName("변경 시간")]  
        public DateTime UPDATE_TIME { get { return update_time; } set { update_time = value; } }
        [DisplayName("변경 사용자")]
        public string UPDATE_USER_ID { get { return update_user_id; } set { update_user_id = value; } }

        public ProductVO()
        {

        }
        public ProductVO(DataGridViewRow row)
        {
            cboList = new List<string>();
            product_code  = row.Cells["PRODUCT_CODE"].Value.ToString();
            product_name = row.Cells["PRODUCT_NAME"].Value.ToString();
            product_type =  row.Cells["PRODUCT_TYPE"].Value.ToString();
            customer_code = row.Cells["CUSTOMER_CODE"].Value.ToString();
            vendor_code = row.Cells["VENDOR_CODE"].Value.ToString();
            if(row.Cells["CREATE_TIME"].Value!=null && row.Cells["CREATE_TIME"].Value !=DBNull.Value)
            create_time = Convert.ToDateTime(row.Cells["CREATE_TIME"].Value);
            create_user_id = row.Cells["CREATE_USER_ID"].Value.ToString();
            if (row.Cells["UPDATE_TIME"].Value != null && row.Cells["UPDATE_TIME"].Value != DBNull.Value)
                update_time = Convert.ToDateTime(row.Cells["UPDATE_TIME"].Value);
            update_user_id = row.Cells["UPDATE_USER_ID"].Value.ToString();
        }

     
 
        //public void SetDatagridview(DataGridViewRow row)
        //{
        //     row.Cells["PRODUCT_CODE"].Value = product_code;
        //     row.Cells["PRODUCT_NAME"].Value  = product_name;
        //     row.Cells["PRODUCT_TYPE"].Value=  product_type;
        //    row.Cells["CUSTOMER_CODE"].Value= customer_code;
        //    row.Cells["VENDOR_CODE"].Value= vendor_code;
        //    row.Cells["CREATE_TIME"].Value=   create_time;
        //     row.Cells[" CREATE_USER_ID"].Value   = create_user_id;
        //    row.Cells["UPDATE_TIME"].Value  =update_time;
        //      row.Cells["UPDATE_USER_ID"].Value    = update_user_id;
        //}

    }

    //public class Bar
    //{
    //    public string barvalue;
    //    public override string ToString()
    //    {
    //        return barvalue;
    //    }
    //}
    //public class MyConverter : TypeConverter
    //{
    //    public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
    //    {
    //        return true;
    //    }

    //    public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
    //    {
    //        // you need to get the list of values from somewhere
    //        // in this sample, I get it from the MyClass itself
    //        var myClass = context.Instance as ProductVO;
    //        if (myClass != null)
    //            return new StandardValuesCollection(myClass.PRODUCT_TYPE);

    //        return base.GetStandardValues(context);
    //    }

    //    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
    //    {
    //        if (sourceType == typeof(string))
    //        {
    //            return true;
    //        }
    //        return base.CanConvertFrom(context, sourceType);
    //    }

    //    public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
    //    {
    //        if (value is string)
    //        {
    //            foreach (Bar b in barlist)
    //            {
    //                if (b.barvalue == (string)value)
    //                {
    //                    return b;
    //                }
    //            }
    //        }
    //        return base.ConvertFrom(context, culture, value);
    //    }
    //}
}
