using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAC;
using System.Data;
namespace POPprogram
{
	public class INSPECT_OPServ
	{
		public DataTable Op_GetTable()
		{
			INSPECT_OPERATIONDAC dac = new INSPECT_OPERATIONDAC();
			DataTable dt = dac.Op_GetTable();
			return dt;
		}

		public DataTable GetSearch(INSPECT_OPERATIONProperty pr)
		{
			INSPECT_OPERATIONDAC dac = new INSPECT_OPERATIONDAC();
			DataTable dt  = dac.GetSearch(pr);
			dac.Dispose();
			return dt;
		}
	}
}
