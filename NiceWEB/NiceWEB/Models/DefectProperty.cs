using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NiceWEB.Models
{
	public class DefectProperty
	{
		//TRAN_DATE,PRODUCT_CODE,OPERATION_CODE, DEFECT_CODE, sum(DEFECT_QTY) as DEFECT_QTY
		public string TRAN_DATE { get; set; }

		public string PRODUCT_CODE { get; set; }

		public string OPERATION_CODE { get; set; }

		public string DEFECT_CODE { get; set; }

		public decimal DEFECT_QTY { get; set; }
	}
}