using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAC;
using System.Data;

namespace POPprogram
{
    public class DownServ
    {
		public List<DownProperty> GetDownList()
		{
			DownDAC dac = new DownDAC();
			List<DownProperty> List = dac.GetDownList();
			dac.Dispose();
			return List;
		}

		public bool Insert(DateTime DT_DATE, DateTime DT_START_TIME, DateTime DT_END_TIME, int DT_TIME, string DT_CODE, string DT_COMMENT, string DT_USER_ID, string ACTION_COMMENT)
		{
			DownDAC db = new DownDAC();
			bool bresult = db.Insert(DT_DATE, DT_START_TIME, DT_END_TIME, DT_TIME, DT_CODE, DT_COMMENT, DT_USER_ID, ACTION_COMMENT);
			db.Dispose();

			return bresult;
		}
	}
}
