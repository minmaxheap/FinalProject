using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace VO
{
	public class Search_INSPEC_MSEVO
	{
		private string ItemCode;
		private string ValueType;


		[DisplayName("검사항목")]
		public string INSPECT_ITEM_CODE { get { return ItemCode; } set { ItemCode = value; } }

		[DisplayName("값 유형")]
		[TypeConverter(typeof(ValueTypeConverter))]
		public string VALUE_TYPE { get { return ValueType; } set { ValueType = value; } }

		public Search_INSPEC_MSEVO()
		{

		}

		public Search_INSPEC_MSEVO(DataGridViewRow row)
		{
			ItemCode = row.Cells["INSPECT_ITEM_CODE"].Value.ToString();
			ValueType = row.Cells["VALUE_TYPE"].ToString();
		}
	}
}
