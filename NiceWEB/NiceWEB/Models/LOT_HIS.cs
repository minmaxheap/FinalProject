using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NiceWEB.Models
{
	public class LOT_HIS
	{
		//VO단처럼 

		public string LOT_ID { get; set; }
		public decimal HIST_SEQ { get; set; }
		public string TRAN_TIME { get; set; }
		public string TRAN_CODE { get; set; }
		public string LOT_DESC { get; set; }
		public string PRODUCT_CODE { get; set; }
		public string OPERATION_CODE { get; set; }

		public string OPERATION_NAME { get; set; }
		public string STORE_CODE { get; set; }
		public decimal LOT_QTY { get; set; }
		public decimal CREATE_QTY { get; set; }
		public decimal OPER_IN_QTY { get; set; }
		public string START_FLAG { get; set; }
		public decimal START_QTY { get; set; }
		public string START_TIME { get; set; }
		public string START_EQUIPMENT_CODE { get; set; }
		public string END_FLAG { get; set; }
		public DateTime END_TIME{ get; set; }
		public string END_EQUIPMENT_CODE { get; set; }
		public string SHIP_FLAG { get; set; }
		public string SHIP_CODE { get; set; }
		public DateTime SHIP_TIME { get; set; }
		public DateTime PRODUCTION_TIME { get; set; }
		public DateTime CREATE_TIME { get; set; }
		public DateTime OPER_IN_TIME { get; set; }
		public string WORK_ORDER_ID { get; set; }
		public string LOT_DELETE_FLAG { get; set; }
		public string LOT_DELETE_CODE { get; set; }
		public DateTime LOT_DELETE_TIME { get; set; }
		public string TRAN_USER_ID { get; set; }
		public string TRAN_COMMENT { get; set; }
		public string OLD_PRODUCT_CODE { get; set; }
		public string OLD_OPERATION_CODE { get; set; }
		public string OLD_STORE_CODE { get; set; }
		public decimal OLD_LOT_QTY { get; set; }

	}
}