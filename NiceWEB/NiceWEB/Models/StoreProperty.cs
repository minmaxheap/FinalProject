using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NiceWEB.Models
{
	public class StoreProperty
	{

		// OPER_IN_TIME,LOT_ID,PRODUCT_CODE,STORE_CODE,LOT_QTY

		public string OPER_IN_TIME { get; set; }

		public string LOT_ID { get; set; }

		public string PRODUCT_CODE { get; set; }

		public decimal LOT_QTY { get; set; }

		public string STORE_CODE { get; set; }
	}
}