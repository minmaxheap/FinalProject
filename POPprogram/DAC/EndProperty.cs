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
}

