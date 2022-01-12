using DAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POPprogram
{
    public class EndServ
	{
		public List<EndProperty> GetStatusList(EndProperty vo)
		{
			EndDAC dac = new EndDAC();
			List<EndProperty> list = dac.GetStatusList(vo);
			dac.Dispose();
			return list;
		}
		public List<EndProperty> GetRMLotList(EndProperty vo)
		{
			EndDAC dac = new EndDAC();
			List<EndProperty> list = dac.GetRMLotList(vo);
			dac.Dispose();
			return list;
		}

		public List<string> GetLotList()
		{
			EndDAC dac = new EndDAC();
			List<string> List = dac.GetLotList();
			dac.Dispose();
			return List;
		}
		public List<EndPropertyUse> GetBomChildList(EndPropertyPrdCode usevo)
		{
			EndDAC dac = new EndDAC();
			List<EndPropertyUse> list = dac.GetBomChildList(usevo);
			dac.Dispose();
			return list;
		}

		public List<EndPropertyLOTHis> GetOperCheckList(EndPropertyLOTHis vo)
		{
			EndDAC dac = new EndDAC();
			List<EndPropertyLOTHis> list = dac.GetOperCheckList(vo);
			dac.Dispose();
			return list;
		}
		public DataTable GetEQList()
		{
			EndDAC dac = new EndDAC();
			DataTable  dt = dac.GetEQList();
			dac.Dispose();
			return dt;
		}
		public bool EndLOT_Update(EndPropertyUpdate updateVO)
		{
			EndDAC dac = new EndDAC();
			bool bResult = dac.EndLOT_Update(updateVO);
			dac.Dispose();
			return bResult;
		}

	}
}

