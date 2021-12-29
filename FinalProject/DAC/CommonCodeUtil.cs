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
        public List<string> GetSourceList()
        {
            //dac에서 list 받아오기 //앗 근데 DAC을 참조할 수가 없구나(순환 종속성 때문에) => 그래서 여기로 vo를 옮겼다.

            ProductDAC dac = new ProductDAC();
            List<string> productType = dac.GetProductType();
            return productType; //한번에 다 가져오는 게 나을 것 같은데? 쿼리 수정해야겠다. 
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

    public class CustomerCode
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

    public class User_Group_Type
    {
        public List<string> GetSourceList()
        {
            //dac에서 list 받아오기

            UserGroupDAC dac = new UserGroupDAC();
            List<string> Type = dac.GetCode();

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

    //홍직(부서)
    public class DepartMent
    {
        public List<string> GetSourceList()
        {
            //dac에서 list 받아오기
            UserMstDAC dac = new UserMstDAC();
            List<string> Type = dac.GetCode();
            return Type;
            




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

    //홍직(
    public class User_Mst_Group
    {
        public List<string> GetSourceList()
        {
            UserMstDAC dac =  new UserMstDAC();
            List<string> Type = dac.GetGroupCode();

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

    //홍직 값
    public class ValueType
    {
        public List<string> GetSourceList()
        {
           InspectDAC dac = new InspectDAC();
            List<string> productType = dac.GetCode();
            return productType;
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
            return new StandardValuesCollection(new ValueType().GetSourceList());
        }
    }
}
