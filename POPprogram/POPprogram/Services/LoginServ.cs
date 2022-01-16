using DAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POPprogram
{
    public class LoginServ
	{
		public bool CheckLogin(LoginProperty vo)
		{
			LoginDAC dac = new LoginDAC();
			bool bResult = dac.CheckLogin(vo);
			dac.Dispose();
			return bResult;
		}
	}
}

