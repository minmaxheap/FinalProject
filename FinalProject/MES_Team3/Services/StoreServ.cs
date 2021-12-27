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
    public class StoreServ
    {
        public List<StoreVO> GetStoreList()
        {
            StoreDAC dac = new StoreDAC();
            List<StoreVO> list = dac.GetStoreList();
            dac.Dispose();
            return list;
        }
    }
}
