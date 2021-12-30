using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAC
{
	public class UserGroupVO
	{
		private bool isSearchPanel;

		public bool IsSearchl;

		
		
		public string user_group;
		private string user_name;
		private string user_type;
		private DateTime createTime;
		private string create_UserID;
		private DateTime Update_Time;
		private string Update_UserID;


		
		[DisplayName("사용자그룹")]
		[Browsable(true)]
		public string USER_GROUP_CODE { get { return user_group; } set { user_group = value; } }

		[DisplayName("사용자 그룹 이름")]
		[Browsable(true)]

		public string USER_GROUP_NAME
		{
			get { return user_name; }
			set { user_name = value; }
		}
		[DisplayName("사용자 그룹 유형")]
		[Browsable(true)]
		[TypeConverter(typeof(UserGroupTypeConverter))]
		public string USER_GROUP_TYPE { get { return user_type; } set { user_type = value; } }

		[DisplayName("생성시간")]
		[Browsable(true)]
		[ReadOnly(true)]

		public DateTime CREATE_TIME
		{
			get { return createTime; }
			set { createTime = value; }
		}
		[DisplayName("생성 사용자")]
		[Browsable(true)]
		[ReadOnly(true)]

		public string CREATE_USER_ID
		{
			get { return create_UserID; }
			set { create_UserID = value; }
		}
		[DisplayName("변경시간")]
		[Browsable(true)]
		[ReadOnly(true)]

		public DateTime UPDATE_TIME
		{
			get { return Update_Time; }
			set { Update_Time = value; }
		}
		[DisplayName("변경사용자")]
		[Browsable(true)]
		[ReadOnly(true)]

		public string UPDATE_USER_ID
		{
			get { return Update_UserID; }
			set { Update_UserID = value; }
		}

		[Browsable(false)]
		public bool IsSearchPanel
		{
			get { return isSearchPanel; }
			set
			{
				isSearchPanel = value;

				PropertyDescriptorCollection propCollection = TypeDescriptor.GetProperties(this.GetType());

				PropertyDescriptor descriptor = propCollection["USER_GROUP_NAME"];
				PropertyDescriptor descriptor1 = propCollection["CREATE_TIME"];
				PropertyDescriptor descriptor2 = propCollection["CREATE_USER_ID"];
				PropertyDescriptor descriptor3 = propCollection["UPDATE_TIME"];
				PropertyDescriptor descriptor4 = propCollection["UPDATE_USER_ID"];

				BrowsableAttribute attrib = (BrowsableAttribute)descriptor.Attributes[typeof(BrowsableAttribute)];
				FieldInfo isBrow = attrib.GetType().GetField("browsable", BindingFlags.NonPublic | BindingFlags.Instance);

				BrowsableAttribute attrib1 = (BrowsableAttribute)descriptor1.Attributes[typeof(BrowsableAttribute)];
				FieldInfo isBrow1 = attrib1.GetType().GetField("browsable", BindingFlags.NonPublic | BindingFlags.Instance);

				BrowsableAttribute attrib2 = (BrowsableAttribute)descriptor2.Attributes[typeof(BrowsableAttribute)];
				FieldInfo isBrow2 = attrib2.GetType().GetField("browsable", BindingFlags.NonPublic | BindingFlags.Instance);

				BrowsableAttribute attrib3 = (BrowsableAttribute)descriptor3.Attributes[typeof(BrowsableAttribute)];
				FieldInfo isBrow3 = attrib3.GetType().GetField("browsable", BindingFlags.NonPublic | BindingFlags.Instance);

				BrowsableAttribute attrib4 = (BrowsableAttribute)descriptor4.Attributes[typeof(BrowsableAttribute)];
				FieldInfo isBrow4 = attrib4.GetType().GetField("browsable", BindingFlags.NonPublic | BindingFlags.Instance);

				if (IsSearchPanel)
				{
					isBrow.SetValue(attrib, false);
					isBrow1.SetValue(attrib1, false);
					isBrow2.SetValue(attrib2, false);
					isBrow3.SetValue(attrib3, false);
					isBrow4.SetValue(attrib4, false);
				}
				else
				{
					isBrow.SetValue(attrib, true);
					isBrow1.SetValue(attrib1, true);
					isBrow2.SetValue(attrib2, true);
					isBrow3.SetValue(attrib3, true);
					isBrow4.SetValue(attrib4, true);
				}
			}
			
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
