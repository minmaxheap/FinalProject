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
		//private int rownum;
		private bool isSearchPanel;


		//INSPECT_ITEM_CODE
		//,[INSPECT_ITEM_NAME]
		//    ,[VALUE_TYPE]
		//    ,[SPEC_LSL]
		//    ,[SPEC_TARGET]
		//    ,[SPEC_USL]
		//    ,[CREATE_TIME]
		//    ,[CREATE_USER_ID]
		//    ,[UPDATE_TIME]
		//    ,[UPDATE_USER_ID]



	
		
		[DisplayName("검사항목")]
		[Browsable(true)]

		public string INSPECT_ITEM_CODE { get { return inspect_itemcode; } set { inspect_itemcode = value; } }

		[DisplayName("검사항목명")]
		[Browsable(true)]
		
		public string INSPECT_ITEM_NAME { get { return inspect_itemname; } set { inspect_itemname = value; } }

		[DisplayName("값 유형")]
		[Browsable(true)]
		[TypeConverter(typeof(ValueTypeConverter))]
		//[ReadOnly(false)]
		public string VALUE_TYPE
		{
			get { return value_type; }
			set
			{
				value_type = value;
				if (value_type == "N")
				{
					//PropertyDescriptorCollection propCollection = TypeDescriptor.GetProperties(this.GetType());
					PropertyDescriptor descriptor = TypeDescriptor.GetProperties(this.GetType())["SPEC_LSL"];
					PropertyDescriptor descriptor1 = TypeDescriptor.GetProperties(this.GetType())["SPEC_USL"];

					//PropertyDescriptor descriptor1 = propCollection["SPEC_USL"];
					ReadOnlyAttribute attrib = (ReadOnlyAttribute)descriptor.Attributes[typeof(ReadOnlyAttribute)];
					FieldInfo isReadOnly = attrib.GetType().GetField("isReadOnly", BindingFlags.NonPublic | BindingFlags.Instance);

					ReadOnlyAttribute attrib1 = (ReadOnlyAttribute)descriptor1.Attributes[typeof(ReadOnlyAttribute)];
					FieldInfo isReadOnly1 = attrib1.GetType().GetField("isReadOnly", BindingFlags.NonPublic | BindingFlags.Instance);

					isReadOnly.SetValue(attrib, false);
					isReadOnly1.SetValue(attrib1, false);
				}
				else
				{

					PropertyDescriptor descriptor = TypeDescriptor.GetProperties(this.GetType())["SPEC_LSL"];
					PropertyDescriptor descriptor1 = TypeDescriptor.GetProperties(this.GetType())["SPEC_USL"];

					ReadOnlyAttribute attrib = (ReadOnlyAttribute)descriptor.Attributes[typeof(ReadOnlyAttribute)];
					FieldInfo isReadOnly = attrib.GetType().GetField("isReadOnly", BindingFlags.NonPublic | BindingFlags.Instance);

					ReadOnlyAttribute attrib1 = (ReadOnlyAttribute)descriptor1.Attributes[typeof(ReadOnlyAttribute)];
					FieldInfo isReadOnly1 = attrib1.GetType().GetField("isReadOnly", BindingFlags.NonPublic | BindingFlags.Instance);

					isReadOnly.SetValue(attrib, true);
					isReadOnly1.SetValue(attrib1, true);
				}
			}
		}
		[ReadOnly(false)]
		[DisplayName("LSL")]
		[Browsable(true)]

		public string SPEC_LSL { get { if (value_type == "C") return null; else return spec_lsl; } set { spec_lsl = value; } }

		[DisplayName("Target")]
		[Browsable(true)]

		public string SPEC_TARGET {  get { if (value_type == "N") return null; else return spec_target; } set { spec_target = value; } }

		[DisplayName("USL")]
		[Browsable(true)]
		[ReadOnly(false)]
		public string SPEC_USL { get { if (value_type == "C") return null; else return spec_usl; } set { spec_usl = value; } }

		[DisplayName("생성시간")]
		[Browsable(true)]
		[ReadOnly(true)]
		public DateTime CREATE_TIME { get { return create_time; } set { create_time = value; } }

		[DisplayName("생성사용자")]
		[Browsable(true)]

		public string CREATE_USER_ID { get { return create_userid; } set { create_userid = value; } }

		[DisplayName("변경시간")]
		[Browsable(true)]
		[ReadOnly(true)]

		public DateTime UPDATE_TIME { get { return updatetime; } set { updatetime = value; } }

		[DisplayName("변경사용자")]
		[Browsable(true)]
		[ReadOnly(true)]

		public string UPDATE_USER_ID { get { return update_userid; } set { update_userid = value; } }



		[Browsable(false)]
		public bool IsSearchPanel
		{
			get { return isSearchPanel; }
			set
			{
				isSearchPanel = value;

				PropertyDescriptorCollection propCollection = TypeDescriptor.GetProperties(this.GetType());

				PropertyDescriptor descriptorNum = propCollection["RowNum"];
				PropertyDescriptor descriptor = propCollection["INSPECT_ITEM_NAME"];
				PropertyDescriptor descriptor1 = propCollection["SPEC_LSL"];
				PropertyDescriptor descriptor2 = propCollection["SPEC_USL"];
				PropertyDescriptor descriptor3 = propCollection["CREATE_TIME"];
				PropertyDescriptor descriptor4 = propCollection["CREATE_USER_ID"];
				PropertyDescriptor descriptor5 = propCollection["UPDATE_TIME"];
				PropertyDescriptor descriptor6 = propCollection["UPDATE_USER_ID"];
				PropertyDescriptor descriptor7 = propCollection["SPEC_TARGET"];

				
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

				BrowsableAttribute attrib6 = (BrowsableAttribute)descriptor6.Attributes[typeof(BrowsableAttribute)];
				FieldInfo isBrow6 = attrib6.GetType().GetField("browsable", BindingFlags.NonPublic | BindingFlags.Instance);

				BrowsableAttribute attrib7 = (BrowsableAttribute)descriptor7.Attributes[typeof(BrowsableAttribute)];
				FieldInfo isBrow7 = attrib7.GetType().GetField("browsable", BindingFlags.NonPublic | BindingFlags.Instance);

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
					isBrow6.SetValue(attrib6, false);
					isBrow7.SetValue(attrib7, false);
				}
				else
				{
					isBrow.SetValue(attrib, true);
					isBrow1.SetValue(attrib1, true);
					isBrow2.SetValue(attrib2, true);
					isBrow3.SetValue(attrib3, true);
					isBrow4.SetValue(attrib4, true);
					isBrow5.SetValue(attrib5, true);
					isBrow6.SetValue(attrib6, true);
					isBrow7.SetValue(attrib7, true);
				}
			}
		}

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
