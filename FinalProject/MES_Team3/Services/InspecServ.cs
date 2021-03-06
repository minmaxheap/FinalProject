using DAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

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

		public bool Update(INSPECT_MSTVO vo)
		{
			InspectDAC db = new InspectDAC();
			bool result = db.Update(vo);
			db.Dispose();
			return result;
		}

		//조회조건
		public List<INSPECT_MSTVO> GetINSPECT_MST_Search(INSPECT_MSTVO vo)
		{
			InspectDAC dac = new InspectDAC();
			List<INSPECT_MSTVO> list = dac.GetINSPECT_MST_Search(vo);
			dac.Dispose();
			return list;
		}

		//combobox 바인딩
		public List<string> GetINSPECT_Code()
		{
			InspectDAC dac = new InspectDAC();
			List<string> List = dac.GetINSPECT_Code();
			dac.Dispose();
			return List;
		}
	}
}
