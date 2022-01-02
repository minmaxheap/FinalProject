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

    public class Check_Value  //frmOperation
    {
        public List<string> GetSourceList()
        {
            //dac에서 list 받아오기
            List<string> check_value = new List<string>();
            check_value.Add("Y");
            check_value.Add(null);
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
    }//frmOperation
    public class Check_Status  //frmWorkOrder
    {
        public List<string> GetSourceList()
        {
            //dac에서 list 받아오기
            List<string> check_value = new List<string>();
            check_value.Add("OPEN");
            check_value.Add("PROC");
            check_value.Add("CLOSE");
            return check_value;
        }
    }
    public class Check_Status_Converter : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }


        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            // ProductVO refMyObject = context.Instance as ProductVO;
            return new StandardValuesCollection(new Check_Status().GetSourceList());
        }
    }  //frmWorkOrder
    public class Get_Product_CodeList
    {
        public List<string> GetProductCodeList()
        {
            //dac에서 list 받아오기 //앗 근데 DAC을 참조할 수가 없구나(순환 종속성 때문에) => 그래서 여기로 vo를 옮겼다.

            WorkOrderDAC dac = new WorkOrderDAC();
            List<string> productCodeList = dac.GetProductCodeList();
            return productCodeList; //한번에 다 가져올까 말까 
        }
    }
    public class Get_Product_CodeList_Converter : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            //ProductVO refMyObject = context.Instance as ProductVO;
            return new StandardValuesCollection(new Get_Product_CodeList().GetProductCodeList());
        }
    }
    public class Check_Confirm  //frmWorkOrder
    {
        public List<string> GetSourceList()
        {
            //dac에서 list 받아오기
            List<string> check_value = new List<string>();
            check_value.Add("ALL");
            check_value.Add("Y");
            check_value.Add("N");
            return check_value;
        }
    }
    public class Check_Confirm_Converter : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }


        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            // ProductVO refMyObject = context.Instance as ProductVO;
            return new StandardValuesCollection(new Check_Confirm().GetSourceList());
        }
    }  //frmWorkOrder
    public class Check_Confirm_YN  //frmWorkOrder
    {
        public List<string> GetSourceList()
        {
            //dac에서 list 받아오기
            List<string> check_value = new List<string>();
            check_value.Add("Y");
            check_value.Add("N");
            check_value.Add(null);
            return check_value;
        }
    }
    public class Check_Confirm_YN_Converter : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }


        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            // ProductVO refMyObject = context.Instance as ProductVO;
            return new StandardValuesCollection(new Check_Confirm_YN().GetSourceList());
        }
    }  //frmWorkOrder

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
            Type.Add(null);

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
