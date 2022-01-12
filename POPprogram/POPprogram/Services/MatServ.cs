using DAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POPprogram
{
    public class MatServ
    {
		public List<MatProperty> GetStatusList(MatProperty vo)
		{
			MatDAC dac = new MatDAC();
			List<MatProperty> list = dac.GetStatusList(vo);
			dac.Dispose();
			return list;
		}
		public List<MatProperty> GetRMLotList(MatProperty vo)
		{
			MatDAC dac = new MatDAC();
			List<MatProperty> list = dac.GetRMLotList(vo);
			dac.Dispose();
			return list;
		}

		public List<string> GetLotList()
		{
			MatDAC dac = new MatDAC();
			List<string> List = dac.GetLotList();
			dac.Dispose();
			return List;
		}
		public List<MatPropertyUse> GetBomChildList(MatPropertyPrdCode usevo)
		{
			MatDAC dac = new MatDAC();
			List<MatPropertyUse> list = dac.GetBomChildList(usevo);
			dac.Dispose();
			return list;
		}

		public bool SetUseLOT(MatPropertyUpdate lot)
		{
			MatDAC dac = new MatDAC();
			bool bResult = dac.SetUseLOT(lot);
			dac.Dispose();
			return bResult;
		}
	}
}

