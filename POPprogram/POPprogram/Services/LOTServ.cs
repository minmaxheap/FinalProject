using DAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POPprogram
{
    public class LOTServ
    {
       
        public DataTable GetWorkOrderList()
        {
            LOTDAC dac = new LOTDAC();
            DataTable dt = dac.GetWorkOrderList();
            dac.Dispose();
            return dt;
        }

        public DataTable GetLOTAllList()
        {
            LOTDAC dac = new LOTDAC();
            DataTable dt = dac.GetLOTAllList();
            dac.Dispose();
            return dt;
        }

        public DataTable GetLOTHistory(string lotID)
        {
            LOTDAC dac = new LOTDAC();
            DataTable dt = dac.GetLOTHistory(lotID);
            dac.Dispose();
            return dt;
        }

        public List<LOTProperty> GetLOTStatus(string lotID)
        {
            LOTDAC dac = new LOTDAC();
            List < LOTProperty > list = dac.GetLOTStatus(lotID);
            dac.Dispose();
            return list;
        }

        //public DataTable GetLOTStatus(string lotID)
        //{
        //    LOTDAC dac = new LOTDAC();
        //    DataTable dt = dac.GetLOTStatus(lotID);
        //    dac.Dispose();
        //    return dt;
        //}

        public bool SetNewLOT(LOTProperty lot)
        {
            LOTDAC dac = new LOTDAC();
            bool bResult = dac.SetNewLOT(lot);
            dac.Dispose();
            return bResult;
        }

        public DataTable GetLOTSearch(LOTSearchProperty pr)
        {
            LOTDAC dac = new LOTDAC();
            DataTable dt = dac.GetLOTSearch(pr);
            dac.Dispose();
            return dt;

        }


    }
}
