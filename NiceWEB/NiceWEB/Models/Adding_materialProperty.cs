using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NiceWEB.Models
{
	public class Adding_materialProperty
	{
	  public string LOT_ID { get; set; }
	  public decimal HIST_SEQ { get; set; }
      public string MATERIAL_LOT_ID { get; set; }
	  public decimal MATERIAL_LOT_HIST_SEQ { get; set; }
	  public string INPUT_QTY { get; set; }
	 public string CHILD_PRODUCT_CODE { get; set; }
	public string MATERIAL_STORE_CODE { get; set; }
	public DateTime TRAN_TIME { get; set; } //string으로 바꿔서 보여줘야할지 고민이다.
	public string TRAN_CODE { get; set; }
	public string PRODUCT_CODE { get; set; }
    public string OPERATION_CODE { get; set; }
	public string EQUIPMENT_CODE { get; set; }
	 public string TRAN_USER_ID { get; set; }

	public string TRAN_COMMENT { get; set; }

	}
}