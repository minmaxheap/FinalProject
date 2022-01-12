using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAC
{
	public class MatProperty
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
	public class MatPropertyUse
	{
		public string CHILD_PRODUCT_CODE { get; set; }
		public string CHILD_PRODUCT_NAME { get; set; }
		public decimal REQUIRE_QTY { get; set; }
		public decimal SUM_QTY { get; set; }
	}
	public class MatPropertyPrdCode
	{
		public string PRODUCT_CODE { get; set; }
	}
    public class MatPropertyUpdate
    {
		public string LOT_ID { get; set; }
		public string LOT_DESC { get; set; }
		public string PRODUCT_CODE { get; set; }
		public string OPERATION_CODE { get; set; }
		public string STORE_CODE { get; set; }
		public decimal LOT_QTY { get; set; }
		public decimal CREATE_QTY { get; set; }
		public decimal OPER_IN_QTY { get; set; }
		public string START_FLAG { get; set; }
		public decimal START_QTY { get; set; }
		public DateTime START_TIME { get; set; }
		public string START_EQUIPMENT_CODE { get; set; }
		public string END_FLAG { get; set; }
		public DateTime END_TIME { get; set; }
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
		public string LAST_TRAN_CODE { get; set; }
		public DateTime LAST_TRAN_TIME { get; set; }
		public string LAST_TRAN_USER_ID { get; set; }
		public string LAST_TRAN_COMMENT { get; set; }
		public string LAST_HIST_SEQ { get; set; }


		public string HIST_SEQ { get; set; }
		public DateTime TRAN_TIME { get; set; }
		public string TRAN_CODE { get; set; }
		public string TRAN_USER_ID { get; set; }
		public string TRAN_COMMENT { get; set; }

		public string OLD_PRODUCT_CODE { get; set; }
		public string OLD_OPERATION_CODE { get; set; }
		public string OLD_STORE_CODE { get; set; }
		public decimal OLD_LOT_QTY { get; set; }

		public string SALES_ORDER_ID { get; set; }
		public string PRODUCT_NAME { get; set; }
		public string BOM_LOT_ID_1 { get; set; }
		public decimal BOM_LOT_QTY_1 { get; set; }
		public string BOM_LOT_ID_2 { get; set; }
		public decimal BOM_LOT_QTY_2 { get; set; }
		public string BOM_CHILD_ID_1 { get; set; }
		public string BOM_CHILD_ID_2 { get; set; }
	}
	public class MatPropertyExport
	{
		public string BOM_LOT_ID { get; set; }
		public decimal BOM_LOT_QTY { get; set; }
		public string BOM_CHILD_ID { get; set; }
	}
	public class MatPropertyHist
	{
		public string LOT_ID { get; set; }
		public decimal HIST_SEQ { get; set; }
		public string MATERIAL_LOT_ID { get; set; }
		public decimal MATERIAL_LOT_HIST_SEQ { get; set; }
		public decimal INPUT_QTY { get; set; }
		public string CHILD_PRODUCT_CODE { get; set; }
		public string MATERIAL_STORE_CODE { get; set; }
		public DateTime TRAN_TIME { get; set; }
		public string TRAN_CODE { get; set; }
		public string PRODUCT_CODE { get; set; }
		public string OPERATION_CODE { get; set; }
		public string EQUIPMENT_CODE { get; set; }
		public string TRAN_USER_ID { get; set; }
		public string TRAN_COMMENT { get; set; }
	}
}

