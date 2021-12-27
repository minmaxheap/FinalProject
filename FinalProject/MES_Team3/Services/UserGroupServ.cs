using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAC;

using System.Windows.Forms;
using System.Data;
namespace MES_Team3
{
	public class UserGroupServ
	{
		public bool Insert(UserGroupVO vo)
		{
			UserGroupDAC dac = new UserGroupDAC();
			bool result = dac.Insert(vo);
			dac.Dispose();
			return result;

		}

		public bool Delete(string Code)
		{
			UserGroupDAC dac = new UserGroupDAC();
			bool result = dac.Delete(Code);
			dac.Dispose();
			return result;
		}

		public bool Update(UserGroupVO vo)
		{
			UserGroupDAC dac = new UserGroupDAC();
			bool result = dac.Update(vo);
			dac.Dispose();
			return result;
		}

		public DataTable GetTable()
		{
			UserGroupDAC dac = new UserGroupDAC();
			DataTable dt = dac.GetTable();
			dac.Dispose();
			return dt;
		}
	}
}
