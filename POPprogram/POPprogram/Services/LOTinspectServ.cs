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
	}
}
