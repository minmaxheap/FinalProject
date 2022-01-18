using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAC
{
	public class EndProperty
	{
		public string CUSTOMER_CODE { get; set; } 
		public string CUSTOMER_NAME { get; set; }
		public string PRODUCT_CODE { get; set; } 
		public string PRODUCT_NAME { get; set; }
		public string OPERATION_CODE { get; set; }
		public string OPERATION_NAME { get; set; }
		public string WORK_ORDER_ID { get; set; }
		public decimal LOT_QTY { get; set; }
		public string LOT_ID { get; set; }
		public string LOT_DESC { get; set; }
		public string ORDER_STATUS { get; set; }
		public decimal ORDER_QTY { get; set; }
		public decimal PRODUCT_QTY { get; set; }
		public decimal DEFECT_QTY { get; set; }

		public string CHECK_DEFECT_FLAG { get; set; }
		public string CHECK_INSPECT_FLAG { get; set; }
		public string CHECK_MATERIAL_FLAG { get; set; }

	}
	public class EndPropertyUse
	{
		public string CHILD_PRODUCT_CODE { get; set; }
		public string CHILD_PRODUCT_NAME { get; set; }
		public decimal REQUIRE_QTY { get; set; }
		public decimal SUM_QTY { get; set; }
	}
	public class EndPropertyPrdCode
	{
		public string PRODUCT_CODE { get; set; }
	}
	public class EndPropertyEQ
	{
		public string EQ_CODE { get; set; }
		public string EQ_NAME { get; set; }
	}
		public class EndPropertyLOTHis
	{
		public string LOT_ID { get; set; }
		public string OPERATION_CODE { get; set; }
		public string CHECK_DEFECT_FLAG { get; set; }
		public string CHECK_INSPECT_FLAG { get; set; }
		public string CHECK_MATERIAL_FLAG { get; set; }
		public string TRAN_CODE { get; set; }
		public string PRODUCT_CODE { get; set; }
	}

	public class EndPropertyUpdate
	{

		public decimal LOT_QTY { get; set; }
		public decimal OPER_IN_QTY { get; set; }
		public string END_EQUIPMENT_CODE { get; set; }
		public string LAST_TRAN_USER_ID { get; set; }
		public string LOT_ID { get; set; }
		public string OPERATION_CODE { get; set; }
		public string OLD_OPERATION_CODE { get; set; }
		public string WORK_ORDER_ID { get; set; }
	}
}

