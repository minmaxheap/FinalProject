using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace DAC
{
    public class BomVO
    {
        private bool isSearchPanel;

        public bool IsSearchl;



        private string product_code;
        private string child_product_code;
        private string require_qty;
        //private string alter_product_code;
        private DateTime create_time;
        private string create_user_id;
        private DateTime update_time;
        private string update_user_id;

		[DisplayName("제품 코드")]
		[Browsable(true)]
		public string PRODUCT_CODE { get { return product_code; } set { product_code = value; } }

		[DisplayName("자품번")]
		[Browsable(true)]
		public string CHILD_PRODUCT_CODE { get { return child_product_code; } set { child_product_code = value; } }

		//[DisplayName("자 품명")]
		//[Browsable(true)]

		//public string STORE_NAME
		//{
		//	get { return store_name; }
		//	set { store_name = value; }
		//}
		[DisplayName("단위 수량")]
		[Browsable(true)]

		[TypeConverter(typeof(StoreTypeConverter))]
		public string REQUIRE_QTY { get { return require_qty; } set { require_qty = value; } }

		//[DisplayName("대체 품번")]
		//[Browsable(true)]
		//public string ALTER_PRODUCT_CODE { get { return alter_product_code; } set { alter_product_code = value; } }


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
	}
}
