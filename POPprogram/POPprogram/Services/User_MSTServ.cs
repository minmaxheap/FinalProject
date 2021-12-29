using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAC;
using System.Data;
namespace POPprogram
{
	public class User_MSTServ
	{
		public bool Insert(User_MST_Property pr)
		{
			UserMstDAC dac = new UserMstDAC();
			bool b = dac.Insert(pr);
			dac.Dispose();
			return b;
		}
		public bool Update(User_MST_Property pr)
		{
			UserMstDAC dac = new UserMstDAC();
			bool b = dac.Update(pr);
			dac.Dispose();
			return b;
		}

		public bool Delete(string Code)
		{
			UserMstDAC dac = new UserMstDAC();
			bool b = dac.Delete(Code);
			dac.Dispose();
			return b;
		}

		public DataTable GetTable()
		{
			UserMstDAC dac = new UserMstDAC();
			DataTable dt = dac.GetTable();
			dac.Dispose();
			return dt;
		}

		public List<User_MST_Property> GetSearch(User_MST_Property pr)
		{
			UserMstDAC dac = new UserMstDAC();
			List<User_MST_Property> list = dac.GetSearch(pr);
			dac.Dispose();
			return list;
		}
	}
}
