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

        public DataTable GetBOMList1()
        {
            BomDAC dac = new BomDAC();
            DataTable dt = dac.GetBOMList1();
            dac.Dispose();
            return dt;
        }

        public DataTable GetOperRelation(string prodCode)
        {
            BomDAC dac = new BomDAC();
            DataTable dt = dac.GetOperRelation(prodCode);
            dac.Dispose();
            return dt;
        }

        public bool Insert(BomVO vo)
        {
            BomDAC dac = new BomDAC();
            bool bResult = dac.Insert(vo);
            dac.Dispose();
            return bResult;
        }

    }
}
