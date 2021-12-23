using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
  
    public class ProductType
    {
        public List<string> GetSourceList()
        {
            //dac에서 list 받아오기
            List<string> productType = new List<string>();
            productType.Add("Student");
            productType.Add("Lecture");
            productType.Add("Employee");

            return productType;
        }
    }
    public class ProductTypeConverter : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            //ProductVO refMyObject = context.Instance as ProductVO;
            return new StandardValuesCollection(new ProductType().GetSourceList());
        }
    }

    class CustomerCode
    {
        public List<string> GetSourceList()
        {
            //dac에서 list 받아오기
            List<string> CustomerCode = new List<string>();
            CustomerCode.Add("Student");
            CustomerCode.Add("Lecture");
            CustomerCode.Add("Employee");

            return CustomerCode;
        }
    }


    public class CustomerCodeConverter : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            //ProductVO refMyObject = context.Instance as ProductVO;
            return new StandardValuesCollection(new CustomerCode().GetSourceList());
        }
    }

    public class VendorCode
    {
        public List<string> GetSourceList()
        {
            //dac에서 list 받아오기
            List<string> vendorCode = new List<string>();
            vendorCode.Add("Student");
            vendorCode.Add("Lecture");
            vendorCode.Add("Employee");

            return vendorCode;
        }
    }
    public class VendorCodeConverter : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }


        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
           // ProductVO refMyObject = context.Instance as ProductVO;
            return new StandardValuesCollection(new VendorCode().GetSourceList());
        }
    }

    public class ValueTypeConverter : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }


        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            // ProductVO refMyObject = context.Instance as ProductVO;
            return new StandardValuesCollection(new VendorCode().GetSourceList());
        }
    }
}
