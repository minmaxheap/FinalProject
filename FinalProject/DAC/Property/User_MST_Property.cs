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
	public class User_MST_Property
	{
		private string ID;
		private string Name;
		private string Group_Code;
		private string Password;
		private string Department;
		private DateTime CreateTime;
		private string CreateUserID;
		private DateTime UpdateTime;
		private string UpdateUserID;

		private bool IsSearchPannel;

		[DisplayName("사용자 아이디")]
		[Browsable(true)]

		public string USER_ID { get { return ID; } set { ID = value; } }

		[DisplayName("사용자 이름")]
		[Browsable(true)]

		public string USER_NAME { get { return Name; } set { Name = value; } }

		[DisplayName("사용자 그룹")]
		[Browsable(true)]
		[TypeConverter(typeof(UserMstTypeConverter))]


		public string USER_GROUP_CODE { get { return Group_Code; } set { Group_Code = value; } }

		[DisplayName("비밀번호")]
		[Browsable(true)]

		public string USER_PASSWORD { get { return Password; } set { Password = value; } }

		[DisplayName("부서")]
		[Browsable(true)]
		[TypeConverter(typeof(DepartmentTypeConverter))]



		public string USER_DEPARTMENT { get { return Department; } set { Department = value; } }

		[DisplayName("생성시간")]
		[Browsable(true)]

		public DateTime CREATE_TIME { get { return CreateTime; } set { CreateTime = value; } }

		[DisplayName("생성사용자")]
		[Browsable(true)]

		public string CREATE_USER_ID { get { return CreateUserID; } set { CreateUserID = value; } }

		[DisplayName("변경시간")]
		[Browsable(true)]

		public DateTime UPDATE_TIME { get { return UpdateTime; } set { UpdateTime = value; } }

		[DisplayName("변경사용자")]
		[Browsable(true)]

		public string UPDATE_USER_ID { get { return UpdateUserID; } set { UpdateUserID = value; } }

		[Browsable(false)]
		public bool IsSearchPanel
		{
			get { return IsSearchPannel; }
			set
			{
				IsSearchPannel = value;

				PropertyDescriptorCollection propCollection = TypeDescriptor.GetProperties(this.GetType());

				PropertyDescriptor descriptor = propCollection["USER_NAME"];
				PropertyDescriptor descriptor1 = propCollection["USER_PASSWORD"];
				PropertyDescriptor descriptor2 = propCollection["CREATE_TIME"];
				PropertyDescriptor descriptor3 = propCollection["CREATE_USER_ID"];
				PropertyDescriptor descriptor4 = propCollection["UPDATE_TIME"];
				PropertyDescriptor descriptor5 = propCollection["UPDATE_USER_ID"];

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

				BrowsableAttribute attrib5 = (BrowsableAttribute)descriptor5.Attributes[typeof(BrowsableAttribute)];
				FieldInfo isBrow5 = attrib5.GetType().GetField("browsable", BindingFlags.NonPublic | BindingFlags.Instance);



				if (IsSearchPanel)
				{
					//propCollection.Remove(propCollection["PRODUCT_NAME"]);
					//propCollection.Remove(propCollection["CREATE_TIME"]);
					//propCollection.Remove(propCollection["CREATE_USER_ID"]);
					//propCollection.Remove(propCollection["UPDATE_TIME"]);
					//propCollection.Remove(propCollection["UPDATE_USER_ID"]);

					//모듈화하고 싶다..

					isBrow.SetValue(attrib, false);
					isBrow1.SetValue(attrib1, false);
					isBrow2.SetValue(attrib2, false);
					isBrow3.SetValue(attrib3, false);
					isBrow4.SetValue(attrib4, false);
					isBrow5.SetValue(attrib5, false);

				}
				else
				{

					isBrow.SetValue(attrib, true);
					isBrow1.SetValue(attrib1, true);
					isBrow2.SetValue(attrib2, true);
					isBrow3.SetValue(attrib3, true);
					isBrow4.SetValue(attrib4, true);
					isBrow5.SetValue(attrib5, true);

				}
			}

		}

		public User_MST_Property()
		{
			
		}
	}
}
