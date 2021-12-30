using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAC
{
    public class StoreVO
    {
		private bool isSearchPanel;

		public bool IsSearchl;



		private string store_code;
        private string store_name;
        private string store_type;
        private string fifo_flag;
        private DateTime create_time;
        private string create_user_id;
        private DateTime update_time;
        private string update_user_id;


		[DisplayName("창고")]
		[Browsable(true)]
		public string STORE_CODE { get { return store_code; } set { store_code = value; } }

		[DisplayName("창고명")]
		[Browsable(true)]

		public string STORE_NAME
		{
			get { return store_name; }
			set { store_name = value; }
		}
		[DisplayName("창고 유형")]
		[Browsable(true)]

		[TypeConverter(typeof(StoreTypeConverter))]
		public string STORE_TYPE { get { return store_type; } set { store_type = value; } }

		[DisplayName("선입선출 여부")]
		[Browsable(true)]
		[TypeConverter(typeof(FifoFlagConverter))]
		public string FIFO_FLAG { get { return fifo_flag; } set { fifo_flag = value; } }

		//[DisplayName("생성시간")]
		//[Browsable(true)]

		//public DateTime CREATE_TIME
		//{
		//	get { return create_time; }
		//	set { create_time = value; }
		//}

		//[DisplayName("생성 사용자")]
		//[Browsable(true)]

		//public string CREATE_USER_ID
		//{
		//	get { return create_user_id; }
		//	set { create_user_id = value; }
		//}
		//[DisplayName("변경시간")]
		//[Browsable(true)]

		//public DateTime UPDATE_TIME
		//{
		//	get { return update_time; }
		//	set { update_time = value; }
		//}
		//[DisplayName("변경사용자")]
		//[Browsable(true)]

		//public string UPDATE_USER_ID
		//{
		//	get { return update_user_id; }
		//	set { update_user_id = value; }
		//}

		[DisplayName("생성 시간")]
		[Browsable(true)]
		[ReadOnly(true)]
		public DateTime CREATE_TIME { get { return create_time; } set { create_time = value; } }
		[DisplayName("생성 사용자")]
		[Browsable(true)]
		[ReadOnly(true)]
		public string CREATE_USER_ID { get { return create_user_id; } set { create_user_id = value; } }
		[DisplayName("변경 시간")]
		[Browsable(true)]
		[ReadOnly(true)]
		public DateTime UPDATE_TIME { get { return update_time; } set { update_time = value; } }

		[DisplayName("변경 사용자")]
		[Browsable(true)]
		[ReadOnly(true)]
		public string UPDATE_USER_ID
		{
			get { return update_user_id; }
			set
			{
				update_user_id = value;

			}
		}

		[Browsable(false)]
		public bool IsSearchPanel
		{
			get { return isSearchPanel; }
			set
			{
				isSearchPanel = value;

				PropertyDescriptorCollection propCollection = TypeDescriptor.GetProperties(this.GetType());

				PropertyDescriptor descriptor = propCollection["CREATE_TIME"];
				PropertyDescriptor descriptor1 = propCollection["CREATE_USER_ID"];
				PropertyDescriptor descriptor2 = propCollection["UPDATE_TIME"];
				PropertyDescriptor descriptor3 = propCollection["UPDATE_USER_ID"];


				BrowsableAttribute attrib = (BrowsableAttribute)descriptor.Attributes[typeof(BrowsableAttribute)];
				FieldInfo isBrow = attrib.GetType().GetField("browsable", BindingFlags.NonPublic | BindingFlags.Instance);

				BrowsableAttribute attrib1 = (BrowsableAttribute)descriptor1.Attributes[typeof(BrowsableAttribute)];
				FieldInfo isBrow1 = attrib1.GetType().GetField("browsable", BindingFlags.NonPublic | BindingFlags.Instance);

				BrowsableAttribute attrib2 = (BrowsableAttribute)descriptor2.Attributes[typeof(BrowsableAttribute)];
				FieldInfo isBrow2 = attrib2.GetType().GetField("browsable", BindingFlags.NonPublic | BindingFlags.Instance);

				BrowsableAttribute attrib3 = (BrowsableAttribute)descriptor2.Attributes[typeof(BrowsableAttribute)];
				FieldInfo isBrow3 = attrib3.GetType().GetField("browsable", BindingFlags.NonPublic | BindingFlags.Instance);

				if (IsSearchPanel)
				{
					isBrow.SetValue(attrib, false);
					isBrow1.SetValue(attrib1, false);
					isBrow2.SetValue(attrib2, false);
					isBrow3.SetValue(attrib3, false);

				}
				else
				{
					isBrow.SetValue(attrib, true);
					isBrow1.SetValue(attrib1, true);
					isBrow2.SetValue(attrib2, true);
					isBrow3.SetValue(attrib3, true);

				}
			}

		}
	}
}
