using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace DAC
{
    public class ProductProperty
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

        private bool isSearchPanel;

        [DisplayName("품번")]
        [Browsable(true)]
        public string PRODUCT_CODE { get { return product_code; } set { product_code = value; } }

        [DisplayName("품명")]
        [Browsable(true)]
        public string PRODUCT_NAME { get { return product_name; } set { product_name = value; } }
        [DisplayName("품번 유형")]
        [Browsable(true)]
        [TypeConverter(typeof(ProductTypeConverter))]
        public string PRODUCT_TYPE { get { return product_type; } set { product_type = value; } }
        [DisplayName("고객 코드")]
        [Browsable(true)]
        [TypeConverter(typeof(CustomerCodeConverter))]
        public string CUSTOMER_CODE { get { return customer_code; } set { customer_code = value; } }
        [DisplayName("업체 코드")]
        [Browsable(true)]
        [TypeConverter(typeof(VendorCodeConverter))]
        public string VENDOR_CODE { get { return vendor_code; } set { vendor_code = value; } }
        [DisplayName("생성 시간")]
        [Browsable(true)]
        public DateTime CREATE_TIME { get { return create_time; } set { create_time = value; } }
        [DisplayName("생성 사용자")]
        [Browsable(true)]
        public string CREATE_USER_ID { get { return create_user_id; } set { create_user_id = value; } }
        [DisplayName("변경 시간")]
        [Browsable(true)]
        public DateTime UPDATE_TIME { get { return update_time; } set { update_time = value; } }

        [DisplayName("변경 사용자")]
        [Browsable(true)]
        public string UPDATE_USER_ID 
        { 
            get { return update_user_id; } 
            set 
            {
                update_user_id = value;

            } 
        }

        [Browsable(false)]
        public bool IsSearchPanel 
        {
            get { return isSearchPanel; } 
            set 
            { 
                isSearchPanel = value; 
                if (IsSearchPanel)
                {
                    PropertyDescriptorCollection propCollection = TypeDescriptor.GetProperties(this.GetType());
                    //propCollection.Remove(propCollection["PRODUCT_NAME"]);
                    //propCollection.Remove(propCollection["CREATE_TIME"]);
                    //propCollection.Remove(propCollection["CREATE_USER_ID"]);
                    //propCollection.Remove(propCollection["UPDATE_TIME"]);
                    //propCollection.Remove(propCollection["UPDATE_USER_ID"]);

                    //모듈화하고 싶다..

                    PropertyDescriptor descriptor = propCollection["PRODUCT_NAME"];
                    PropertyDescriptor descriptor1 = propCollection["CREATE_TIME"];
                    PropertyDescriptor descriptor2 = propCollection["CREATE_USER_ID"];
                    PropertyDescriptor descriptor3 = propCollection["UPDATE_TIME"];
                    PropertyDescriptor descriptor4 = propCollection["UPDATE_USER_ID"];
              
                    BrowsableAttribute attrib = (BrowsableAttribute)descriptor.Attributes[typeof(BrowsableAttribute)];
                    FieldInfo isBrow = attrib.GetType().GetField("browsable", BindingFlags.NonPublic | BindingFlags.Instance);

                    isBrow.SetValue(attrib, false);

                    BrowsableAttribute attrib1 = (BrowsableAttribute)descriptor1.Attributes[typeof(BrowsableAttribute)];
                    FieldInfo isBrow1 = attrib1.GetType().GetField("browsable", BindingFlags.NonPublic | BindingFlags.Instance);

                    isBrow1.SetValue(attrib1, false);

                    BrowsableAttribute attrib2 = (BrowsableAttribute)descriptor2.Attributes[typeof(BrowsableAttribute)];
                    FieldInfo isBrow2 = attrib2.GetType().GetField("browsable", BindingFlags.NonPublic | BindingFlags.Instance);

                    isBrow2.SetValue(attrib2, false);

                    BrowsableAttribute attrib3 = (BrowsableAttribute)descriptor3.Attributes[typeof(BrowsableAttribute)];
                    FieldInfo isBrow3 = attrib3.GetType().GetField("browsable", BindingFlags.NonPublic | BindingFlags.Instance);

                    isBrow3.SetValue(attrib3, false);

                    BrowsableAttribute attrib4 = (BrowsableAttribute)descriptor4.Attributes[typeof(BrowsableAttribute)];
                    FieldInfo isBrow4 = attrib4.GetType().GetField("browsable", BindingFlags.NonPublic | BindingFlags.Instance);

                    isBrow4.SetValue(attrib4, false);

                }
            }
        }

        public ProductProperty()
        {

         }

    }
}
