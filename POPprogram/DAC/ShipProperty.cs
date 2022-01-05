using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAC
{
	public class ShipProperty
	{
		public DateTime ORDER_DATE { get; set; } 
		public string SALES_ORDER_ID { get; set; } 
		public string CUSTOMER_CODE { get; set; } 
		public string CUSTOMER_NAME { get; set; }
		public string PRODUCT_CODE { get; set; } 
		public string PRODUCT_NAME { get; set; } 
		public int ORDER_QTY { get; set; } 
		public string CONFIRM_FLAG { get; set; } 
		public string SHIP_FLAG { get; set; } 
		public DateTime CREATE_TIME { get; set; } 
		public string CREATE_USER_ID { get; set; } 
		public DateTime UPDATE_TIME { get; set; } 
		public string UPDATE_USER_ID { get; set; } 
	}
}

