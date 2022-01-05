using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAC
{
	public class LotINSPECTProperty
	{
		public string LOT_ID { get; set; }
		public decimal HIST_SEQ { get; set; }
		public string INSPECT_ITEM_CODE { get; set; }
		public string INSPECT_ITEM_NAME { get; set; }
		public string VALUE_TYPE { get; set; }
		public string SPEC_LSL { get; set; }
		public string SPEC_TARGET { get; set; }
		public string SPEC_USL { get; set; }
		public string INSPECT_VALUE { get; set; }
		public string INSPECT_RESULT { get; set; }
		public DateTime TRAN_TIME { get; set; }
		public string TRAN_CODE { get; set; }
		public string PRODUCT_CODE { get; set; }
		public string OPERATION_CODE{ get; set; }
		public string STORE_CODE { get; set; }
		public string EQUIPMENT_CODE { get; set; }
		public string TRAN_USER_ID { get; set; }
		public string TRAN_COMMENT{ get; set; }

	}
}
