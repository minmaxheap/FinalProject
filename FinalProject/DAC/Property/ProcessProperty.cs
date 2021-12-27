using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace DAC
{
    public class ProcessProperty
    {
        private string product_code;
        private string product_name;
        private string product_type;
        private string customer_code;
        private string vendor_code;
        private DateTime create_time;
        private string create_user_id;
        private DateTime update_time;
        private string update_user_id;

        [System.ComponentModel.RefreshProperties(RefreshProperties.All)]
        [DisplayName("품번")]
        public string PRODUCT_CODE { get { return product_code; } set { product_code = value; } }

        [ReadOnly(false)]
        [DisplayName("품명")]
        public string PRODUCT_NAME { get { return product_name; } set { product_name = value; } }

        [DisplayName("품번 유형")]
        [TypeConverter(typeof(ProductTypeConverter))]
        public string PRODUCT_TYPE
        {
            get { return product_type; }
            set
            {
                product_type = value;
                if (product_type == "FART")
                {
                    bool newValue = true;
                    PropertyDescriptor descriptor = TypeDescriptor.GetProperties(this.GetType())["PRODUCT_NAME"];
                    ReadOnlyAttribute attrib = (ReadOnlyAttribute)descriptor.Attributes[typeof(ReadOnlyAttribute)];
                    FieldInfo isReadOnly = attrib.GetType().GetField("isReadOnly", BindingFlags.NonPublic | BindingFlags.Instance);
                    isReadOnly.SetValue(attrib, newValue);
                }
                else
                {
                    bool newValue = false;
                    PropertyDescriptor descriptor = TypeDescriptor.GetProperties(this.GetType())["PRODUCT_NAME"];
                    ReadOnlyAttribute attrib = (ReadOnlyAttribute)descriptor.Attributes[typeof(ReadOnlyAttribute)];
                    FieldInfo isReadOnly = attrib.GetType().GetField("isReadOnly", BindingFlags.NonPublic | BindingFlags.Instance);
                    isReadOnly.SetValue(attrib, newValue);
                }
            }
        }

        [DisplayName("고객 코드")]
        [TypeConverter(typeof(CustomerCodeConverter))]
        public string CUSTOMER_CODE { get { return customer_code; } set { customer_code = value; } }

        [DisplayName("업체 코드")]
        [TypeConverter(typeof(VendorCodeConverter))]
        public string VENDOR_CODE { get { return vendor_code; } set { vendor_code = value; } }

        [DisplayName("생성 시간")]
        public DateTime CREATE_TIME { get { return create_time; } set { create_time = value; } }

        [DisplayName("생성 사용자")]
        public string CREATE_USER_ID { get { return create_user_id; } set { create_user_id = value; } }

        [DisplayName("변경 시간")]
        public DateTime UPDATE_TIME { get { return update_time; } set { update_time = value; } }

        [DisplayName("변경 사용자")]
        public string UPDATE_USER_ID 
        { get { return update_user_id; } set  {update_user_id = value;} }

        public ProcessProperty()
        {

         }

    }
}
