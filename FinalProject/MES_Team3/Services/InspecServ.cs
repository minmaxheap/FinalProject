using DAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace MES_Team3.Services
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
	}
}
