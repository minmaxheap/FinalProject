using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
  
   
    public class ValueType
    {
        public List<string> GetSourceList()
        {
            //dac에서 list 받아오기
            List<string> valueType = new List<string>();
            valueType.Add("N");
            valueType.Add("C");
            //valueType.Add("Employee");

            return valueType;
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
