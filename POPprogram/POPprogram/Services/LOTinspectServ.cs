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
		public DataTable GetInspec(string Code)
		{
			LOTInspecDAC dac = new LOTInspecDAC();
			DataTable dt = dac.GetInspec(Code);
			dac.Dispose();
			return dt;
				 
		}
		public List<string> GetCode()
		{
			LOTInspecDAC dac = new LOTInspecDAC();
			List<string> list = dac.GetCode();
			dac.Dispose();
			return list;
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
