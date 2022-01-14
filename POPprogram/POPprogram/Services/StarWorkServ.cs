using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAC;
using System.Data;

namespace POPprogram
{
	public class StarWorkServ
	{
		public List<StarWorkProperty> GetData(string Code)
		{
			StartWorkDAC dac = new StartWorkDAC();
			List<StarWorkProperty> List = dac.GetData(Code);
			dac.Dispose();
			return List;
		}
		public DataTable GetCode()
		{
			StartWorkDAC dac = new StartWorkDAC();
			DataTable dt = dac.GetCode();
			dac.Dispose();
			return dt;
		}

		public List<string> GetLotCode()
		{
			StartWorkDAC dac = new StartWorkDAC();
			List<string> List = dac.GetLotCode();
			dac.Dispose();
			return List;
		}
		public List<LOTProperty> GetLotProperty(string Code)
		{
			StartWorkDAC dac = new StartWorkDAC();
			List<LOTProperty> List = dac.GetLotProperty(Code);
			dac.Dispose();
			return List;
		}

		public bool Insert(LOTProperty pr)
		{
			StartWorkDAC dac = new StartWorkDAC();
			bool result = dac.Insert(pr);
			dac.Dispose();
			return result;
		}

		//내꺼(홍직)
		public List<StarWorkProperty> GetOpData(string Code)
		{
			StartWorkDAC dac = new StartWorkDAC();
			List<StarWorkProperty> List = dac.GetOpData(Code);
			dac.Dispose();
			return List;
		}

		public List<string> GetLotOpCode()
		{
			StartWorkDAC dac = new StartWorkDAC();
			List<string> List = dac.GetLotOpCode();
			dac.Dispose();
			return List;
		}
		public List<string> GetDeffectCode()
		{
			StartWorkDAC dac = new StartWorkDAC();
			List<string> List = dac.GetDeffectCode();
			dac.Dispose();
			return List;
		}

		public List<string> GetDefect_Code()
		{
			DefectDAC dac = new DefectDAC();
			List<string> List = dac.GetDefect_Code();
			dac.Dispose();
			return List;
		}

		public List<EndPropertyEQ> GetEqList(string eqCode)
		{
			StartWorkDAC dac = new StartWorkDAC();
			List<EndPropertyEQ> List = dac.GetEqList(eqCode);
			dac.Dispose();
			return List;
		}

		public List<string> GetDown_Code()
		{
			DownDAC dac = new DownDAC();
			List<string> List = dac.GetDown_Code();
			dac.Dispose();
			return List;
		}

	}
}
