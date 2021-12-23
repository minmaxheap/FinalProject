using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace VO
{
	public class INSPECT_MSTVO
	{
		private string inspect_itemcode;
		private string inspect_itemname;
		private string value_type;
		private string spec_lsl;
		private string spec_target;
		private string spec_usl;
		private DateTime create_time;
		private string create_userid;
		private DateTime updatetime;
		private string update_userid;

		[DisplayName("검사항목")]
		public string INSPECT_ITEM_CODE { get { return inspect_itemcode; } set { inspect_itemcode = value; } }

		[DisplayName("검사항목명")]
		public string INSPECT_ITEM_NAME { get { return inspect_itemname; } set { inspect_itemname = value; } }

		[DisplayName("값 유형")]

		public string VALUE_TYPE { get { return value_type; } set { value_type = value; } }

		[DisplayName("LSL")]
		public string SPEC_LSL { get { return spec_lsl; } set { spec_lsl = value; } }

		[DisplayName("Target")]
		public string SPEC_TARGET { get { return spec_target; } set { spec_target = value; } }

		[DisplayName("USL")]
		public string SPEC_USL { get { return spec_target; } set { spec_target = value; } }

		[DisplayName("생성시간")]
		public DateTime CREATE_TIME { get { return create_time; } set { create_time = value; } }

		[DisplayName("생성사용자")]
		public string CREATE_USER_ID { get { return create_userid; } set { create_userid = value; } }

		[DisplayName("변경시간")]
		public DateTime UPDATE_TIME { get { return updatetime; } set { updatetime = value; } }

		[DisplayName("변경사용자")]
		public string UPDATE_USER_ID { get { return update_userid; } set { update_userid = value; } }

		public INSPECT_MSTVO()
		{

		}

		public INSPECT_MSTVO(DataGridViewRow row)
		{
			inspect_itemcode = row.Cells["INSPECT_ITEM_CODE"].Value.ToString();
			inspect_itemname = row.Cells["INSPECT_ITEM_NAME"].Value.ToString();
			value_type = row.Cells["VALUE_TYPE"].ToString();
			spec_lsl = row.Cells["SPEC_LSL"].ToString();
			spec_usl = row.Cells["SPEC_USL"].ToString();

			if (row.Cells["CREATE_TIME"].Value != null && row.Cells["CREATE_TIME"].Value != DBNull.Value)
				create_time = Convert.ToDateTime(row.Cells["CREATE_TIME"].Value);

			create_userid = row.Cells["CREATE_USER_ID"].Value.ToString();

			if (row.Cells["UPDATE_TIME"].Value != null && row.Cells["UPDATE_TIME"].Value != DBNull.Value)
				updatetime = Convert.ToDateTime(row.Cells["UPDATE_TIME"].Value);
			update_userid = row.Cells["UPDATE_USER_ID"].Value.ToString();

		}
	}
}
