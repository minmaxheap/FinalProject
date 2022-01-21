using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAC;
using System.Data;
namespace POPprogram
{
	public class LOTinspectServ
	{
		public DataTable GetInspec(string Code,string txt)
		{
			LOTInspecDAC dac = new LOTInspecDAC();
			DataTable dt = dac.GetInspec(Code, txt);
			dac.Dispose();
			return dt;
				 
		}
		public List<string> GetCode()
		{
			LOTInspecDAC dac = new LOTInspecDAC();
			List<string> List = dac.GetCode();
			dac.Dispose();
			return List;
		}

		public bool insert(string LAST_TRAN_USER_ID, string LAST_TRAN_COMMENT, string LOT_ID, DataTable dt)
		{
			LOTInspecDAC dac = new LOTInspecDAC();
			bool result = dac.insert(LAST_TRAN_USER_ID,LAST_TRAN_COMMENT, LOT_ID, dt);
			dac.Dispose();
			return result;
		}


	}
}
