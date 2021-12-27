using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAC.Property
{
	public class UserGroupVO
	{

		public string user_group;
		private string user_name;
		private string user_type;
		private DateTime createTime;
		private string create_UserID;
		private DateTime Update_Time;
		private string Update_UserID;

		[DisplayName("사용자그룹")]
		public string USER_GROUP_CODE { get { return user_group; } set { user_group = value; } }

		[DisplayName("사용자 그룹 이름")]
		public string USER_GROUP_NAME
		{
			get { return user_name; }
			set { user_name = value; }
		}
		[DisplayName("사용자 그룹 유형")]
		[TypeConverter(typeof(UserGroupTypeConverter))]
		public string USER_GROUP_TYPE { get { return user_type; } set { user_type = value; } }

		[DisplayName("생성시간")]
		public DateTime CREATE_TIME
		{
			get { return createTime; }
			set { createTime = value; }
		}
		[DisplayName("생성 사용자")]
		public string CREATE_USER_ID
		{
			get { return create_UserID; }
			set { create_UserID = value; }
		}
		[DisplayName("변경시간")]
		public DateTime UPDATE_TIME
		{
			get { return Update_Time; }
			set { Update_Time = value; }
		}
		[DisplayName("변경사용자")]
		public string UPDATE_USER_ID
		{
			get { return Update_UserID; }
			set { Update_UserID = value; }
		}

		public UserGroupVO()
		{
				
		}
		public UserGroupVO(DataGridViewRow row)
		{
			user_group = row.Cells["USER_GROUP_CODE"].Value.ToString();
			user_name = row.Cells["USER_GROUP_NAME"].Value.ToString();
			user_type = row.Cells["USER_GROUP_TYPE"].Value.ToString();
			if (row.Cells["CREATE_TIME"].Value != null && row.Cells["CREATE_TIME"].Value != DBNull.Value)
				createTime = Convert.ToDateTime(row.Cells["CREATE_TIME"].Value);

			create_UserID = row.Cells["CREATE_USER_ID"].Value.ToString();


			if (row.Cells["UPDATE_TIME"].Value != null && row.Cells["UPDATE_TIME"].Value != DBNull.Value)
				UPDATE_TIME = Convert.ToDateTime(row.Cells["UPDATE_TIME"].Value);

			Update_UserID = row.Cells["UPDATE_USER_ID"].Value.ToString();

		}

		//USER_GROUP_NAME
		//USER_GROUP_TYPE
		//CREATE_TIME
		//CREATE_USER_ID
		//UPDATE_TIME
		//UPDATE_USER_ID

	
	}
}
