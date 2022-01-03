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
    public class SalesOrderServ
    {
        public DataTable GetSalesOrderList()
        {
            SalesOrderDAC dac = new SalesOrderDAC();
            DataTable dt = dac.GetSalesOrderList();
            dac.Dispose();
            return dt;
        }

        public bool Insert(SalesOrderProperty vo)
        {
            SalesOrderDAC dac = new SalesOrderDAC();
            bool bResult = dac.Insert(vo);
            dac.Dispose();
            return bResult;
        }

        public bool Delete(SalesOrderProperty vo)
        {
            SalesOrderDAC dac = new SalesOrderDAC();
            bool bResult = dac.Delete(vo);
            dac.Dispose();
            return bResult;
        }


        public bool Update(SalesOrderProperty vo)
        {

            SalesOrderDAC dac = new SalesOrderDAC();
            bool bResult = dac.Update(vo);
            dac.Dispose();
            return bResult;
        }

        public List<SalesOrderProperty> GetSalesOrderSearch(SalesOrderPropertySch pr)
        {
            SalesOrderDAC dac = new SalesOrderDAC();
            List <SalesOrderProperty> list = dac.GetSalesOrderSearch(pr);
            dac.Dispose();
            return list;
        }

        public DataTable GetProductCodeName()
        {
            SalesOrderDAC dac = new SalesOrderDAC();
            DataTable dt = dac.GetProductCodeName();
            dac.Dispose();
            return dt;
        }
        public DataTable GetSalesOrderList_Test()
        {
            SalesOrderDAC dac = new SalesOrderDAC();
            DataTable dt = dac.GetSalesOrderList_Test();
            dac.Dispose();
            return dt;
        }
        public DataTable CustomerCodeName()
        {
            SalesOrderDAC dac = new SalesOrderDAC();
            DataTable dt = dac.CustomerCodeName();
            dac.Dispose();
            return dt;
        }

    }
}
