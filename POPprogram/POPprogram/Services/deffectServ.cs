using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAC;
using System.Data;
namespace POPprogram
{
	public class deffectServ
	{
		public bool insert(decimal qty, string comment, string userid, string lotID, DataTable dt)
		{
			DefectDAC dac = new DefectDAC();
			bool b = dac.insert(qty, comment, userid, lotID, dt);
			dac.Dispose();
			return b;
		}
	}
}
