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
	}
}

