using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAC
{
	public class StarWorkProperty
	{
		public string PRODUCT_CODE { get; set; } // 제품코드

		public string OPERATION_CODE { get; set; } // 공정코드

		public string PRODUCT_NAME { get; set; } //제품명

		public string OPERATION_NAME { get; set; } // 공정명

		public  string CUSTOMER_CODE { get; set; } // 고객 코드

		public string ORDER_STATUS { get; set; } // 지시상태

		public string WORK_ORDER_ID { get; set; } // 작업시작
												  		
		public int ORDER_QTY { get; set; } // 지시수량

		public int PRODUCT_QTY { get; set; } // 생산수량

		public int DEFECT_QTY { get; set; } // 불량수량

	}
}
