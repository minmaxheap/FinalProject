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

		public DateTime CREATE_TIME
		{
			get { return createTime; }
			set { createTime = value; }
		}
		[DisplayName("생성 사용자")]
		[Browsable(true)]

		public string CREATE_USER_ID
		{
			get { return create_UserID; }
			set { create_UserID = value; }
		}
		[DisplayName("변경시간")]
		[Browsable(true)]

		public DateTime UPDATE_TIME
		{
			get { return Update_Time; }
			set { Update_Time = value; }
		}
		[DisplayName("변경사용자")]
		[Browsable(true)]

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
				if (IsSearchPanel)
				{
					PropertyDescriptorCollection propCollection = TypeDescriptor.GetProperties(this.GetType());
					//propCollection.Remove(propCollection["PRODUCT_NAME"]);
					//propCollection.Remove(propCollection["CREATE_TIME"]);
					//propCollection.Remove(propCollection["CREATE_USER_ID"]);
					//propCollection.Remove(propCollection["UPDATE_TIME"]);
					//propCollection.Remove(propCollection["UPDATE_USER_ID"]);

					//모듈화하고 싶다..

					PropertyDescriptor descriptor = propCollection["USER_GROUP_CODE"];
					PropertyDescriptor descriptor1 = propCollection["USER_GROUP_TYPE"];
				

					BrowsableAttribute attrib = (BrowsableAttribute)descriptor.Attributes[typeof(BrowsableAttribute)];
					FieldInfo isBrow = attrib.GetType().GetField("browsable", BindingFlags.NonPublic | BindingFlags.Instance);

					isBrow.SetValue(attrib, false);

					BrowsableAttribute attrib1 = (BrowsableAttribute)descriptor1.Attributes[typeof(BrowsableAttribute)];
					FieldInfo isBrow1 = attrib1.GetType().GetField("browsable", BindingFlags.NonPublic | BindingFlags.Instance);

					isBrow1.SetValue(attrib1, false);


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
