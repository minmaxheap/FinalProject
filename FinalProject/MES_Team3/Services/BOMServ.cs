using DAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MES_Team3
{
    public class BOMServ
    {
        public List<BomVO> GetBOMList()
        {
            BomDAC dac = new BomDAC();
            List<BomVO> list = dac.GetBOMList();
            dac.Dispose();
            return list;
        }

        public DataTable GetOperationList()
        {
            OperationDAC dac = new OperationDAC();
            DataTable dt = dac.GetOperationList();
            dac.Dispose();
            return dt;
        }
    }
}
