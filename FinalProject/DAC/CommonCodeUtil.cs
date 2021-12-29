using DAC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAC
{
    public class ProductType
    {
        public List<string> GetProductType()
        {
            //dac에서 list 받아오기 //앗 근데 DAC을 참조할 수가 없구나(순환 종속성 때문에) => 그래서 여기로 vo를 옮겼다.

            ProductDAC dac = new ProductDAC();
            List<string> productType = dac.GetProductType();
            return productType; //한번에 다 가져올까 말까 
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
            return new StandardValuesCollection(new ProductType().GetProductType());
        }
    }

    public class CustomerCode
    {
        public List<string> GetCustomerCode()
        {
            ProductDAC dac = new ProductDAC();
            List<string> customerCode = dac.GetCustomerCode();
            return customerCode;
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
            return new StandardValuesCollection(new CustomerCode().GetCustomerCode());
        }
    }

    public class VendorCode
    {
        public List<string> GetVendorCode()
        {
            //dac에서 list 받아오기
            ProductDAC dac = new ProductDAC();
            List<string> vendorCode = dac.GetVendorCode();
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
            return new StandardValuesCollection(new VendorCode().GetVendorCode());
        }
    }

    public class User_Group_Type
    {
        public List<string> GetSourceList()
        {
            //dac에서 list 받아오기
            List<string> Type = new List<string>();
            Type.Add("ADMIN");
            Type.Add("OPERATOR");
            //valueType.Add("Employee");

            return Type;
        }
    }
    public class UserGroupTypeConverter : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }


        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            // ProductVO refMyObject = context.Instance as ProductVO;
            return new StandardValuesCollection(new User_Group_Type().GetSourceList());
        }
    }

    public class Check_Value
    {
        public List<string> GetSourceList()
        {
            //dac에서 list 받아오기
            List<string> check_value = new List<string>();
            check_value.Add("Y");
            check_value.Add("");
            return check_value;
        }
    }
    public class Check_Value_Converter : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }


        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            // ProductVO refMyObject = context.Instance as ProductVO;
            return new StandardValuesCollection(new Check_Value().GetSourceList());
        }
    }
    public class User_Mst
    {
        public List<string> GetSourceList()
        {
            //dac에서 list 받아오기
            List<string> check_value = new List<string>();
            check_value.Add("Y");
            check_value.Add("");
            return check_value;
        }
    }

    public class UserMstTypeConverter : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }


        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            // ProductVO refMyObject = context.Instance as ProductVO;
            return new StandardValuesCollection(new User_Mst().GetSourceList());
        }
    }

    public class DepartMent
    {
        public List<string> GetSourceList()
        {
            //dac에서 list 받아오기
            List<string> Type = new List<string>();
            Type.Add("임원");
            Type.Add("Press 라인");
            Type.Add("사출 라인");
            Type.Add("SMT 라인");
            Type.Add("조합 라인");




            //valueType.Add("Employee");

            return Type;
        }
    }
    public class DepartmentTypeConverter : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }


        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            // ProductVO refMyObject = context.Instance as ProductVO;
            return new StandardValuesCollection(new DepartMent().GetSourceList());
        }
    }

    public class User_Mst_Group
    {
        public List<string> GetSourceList()
        {
            //dac에서 list 받아오기
            List<string> Type = new List<string>();
            Type.Add("ADMINGROUP");
            Type.Add("Press 라인");
            Type.Add("사출 라인");
            Type.Add("SMT 라인");
            Type.Add("조합 라인");

            return Type;
        }
    }
    public class UserMstGroupTypeConverter : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }


        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            // ProductVO refMyObject = context.Instance as ProductVO;
            return new StandardValuesCollection(new User_Mst_Group().GetSourceList());
        }
    }




    public class Store_Type
    {
        public List<string> GetSourceList()
        {
            //dac에서 list 받아오기
            List<string> Type = new List<string>();
            Type.Add("RS");
            Type.Add("HS");
            Type.Add("FS");

            return Type;
        }
    }
    public class StoreTypeConverter : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }


        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(new Store_Type().GetSourceList());
        }
    }
    public class FIFO_FLAG
    {
        public List<string> GetSourceList()
        {
            //dac에서 list 받아오기
            List<string> Type = new List<string>();
            Type.Add("Y");
            Type.Add("N");

            return Type;
        }
    }
    public class FifoFlagConverter : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }


        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(new FIFO_FLAG().GetSourceList());
        }
    }
}
