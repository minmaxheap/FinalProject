﻿using DAC;
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
            List<string> productType = dac.GetSourceList();
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
}