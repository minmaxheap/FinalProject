using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAC;
namespace DAC
{
	public class INSPECT_OPERATIONProperty
	{
		//OPERATION_CODE, OPERATION_NAME, CHECK_DEFECT_FLAG, CHECK_INSPECT_FLAG, CHECK_MATERIAL_FLAG, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID
		private string operation_code;
		private string Check_Defect;
		private string Check_Inspect;
		private string Check_Materal;


	

		[DisplayName("공정")]
		[Browsable(true)]
		public string OPERATION_CODE { get { return operation_code; } set { operation_code = value; } }

		[DisplayName("불량체크")]
		[Browsable(true)]
		[TypeConverter(typeof(Check_Value_Converter))]
		public string CHECK_DEFECT_FLAG { get { return Check_Defect; } set { Check_Defect = value; } }

		[DisplayName("데이터 체크")]
		[TypeConverter(typeof(Check_Value_Converter))]
		[Browsable(true)]
		public string CHECK_INSPECT_FLAG { get { return Check_Inspect; } set { Check_Inspect = value; } }

		[DisplayName("자재사용 체크")]
		[TypeConverter(typeof(Check_Value_Converter))]
		[Browsable(true)]
		public string CHECK_MATERIAL_FLAG { get { return Check_Materal; } set { Check_Materal = value; } }

		//[Browsable(false)]
		//public int RowNum { get; set; }

		//[Browsable(false)]

		//public string OPERATION_NAME { get; set; }

		//[Browsable(false)]

		//public DateTime CREATE_TIME { get; set; }

		//[Browsable(false)]

		//public string CREATE_USER_ID { get; set; }

		//[Browsable(false)]

		//public DateTime UPDATE_TIME { get; set; }

		//[Browsable(false)]
		//public string UPDATE_USER_ID { get; set; }




		public INSPECT_OPERATIONProperty()
		{
			
		}
	}
}
