using DAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace MES_Team3
{
	public class InspecServ
	{
		public DataTable GetInsMst()
		{
			InspectDAC db = new InspectDAC();
			DataTable dt = db.GetInsMst();
			db.Dispose();
			return dt;
		}

		public DataTable GetTable()
		{
			InspectDAC db = new InspectDAC();
			DataTable dt = db.GetInsMst();
			db.Dispose();
			return dt;
		}

		public bool insert(INSPECT_MSTVO vo)
		{
			InspectDAC db = new InspectDAC();
			bool result = db.insert(vo);
			db.Dispose();
			return result;
		}

		public bool Delete(INSPECT_MSTVO vo)
		{
			InspectDAC db = new InspectDAC();
			bool result = db.Delete(vo);
			db.Dispose();
			return result;
		}
	}
}
