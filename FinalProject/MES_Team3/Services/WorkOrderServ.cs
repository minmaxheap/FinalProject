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
    public class WorkOrderServ
    {
        public DataTable GetWorkOrderList()
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            DataTable dt = dac.GetWorkOrderList();
            dac.Dispose();
            return dt;
        }

        public bool Insert(WorkOrderProperty vo)
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            bool bResult = dac.Insert(vo);
            dac.Dispose();
            return bResult;
        }

        public bool Delete(WorkOrderProperty vo)
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            bool bResult = dac.Delete(vo);
            dac.Dispose();
            return bResult;
        }


        public bool Update(WorkOrderProperty vo)
        {

            WorkOrderDAC dac = new WorkOrderDAC();
            bool bResult = dac.Update(vo);
            dac.Dispose();
            return bResult;
        }

        public List<WorkOrderProperty> GetWorkOrderSearch(WorkOrderPropertySch pr)
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            List <WorkOrderProperty> list = dac.GetWorkOrderSearch(pr);
            dac.Dispose();
            return list;
        }
    }
}
