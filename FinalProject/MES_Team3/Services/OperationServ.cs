using DAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace MES_Team3
{
    public class OperationServ
    {
        public DataTable GetOperationList()
        {
            OperationDAC dac = new OperationDAC();
            DataTable dt = dac.GetOperationList();
            dac.Dispose();
            return dt;
        }

        public bool Insert(OperationProperty vo)
        {
            OperationDAC dac = new OperationDAC();
            bool bResult = dac.Insert(vo);
            dac.Dispose();
            return bResult;
        }

        public bool Delete(OperationProperty vo)
        {
            OperationDAC dac = new OperationDAC();
            bool bResult = dac.Delete(vo);
            dac.Dispose();
            return bResult;
        }


        public bool Update(OperationProperty vo)
        {

            OperationDAC dac = new OperationDAC();
            bool bResult = dac.Update(vo);
            dac.Dispose();
            return bResult;
        }

        public List<OperationProperty> GetOperationSearch(OperationPropertySch pr)
        {
            OperationDAC dac = new OperationDAC();
            List <OperationProperty> list = dac.GetOperationSearch(pr);
            dac.Dispose();
            return list;
        }
    }
}
