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
    public class ProductServ
    {
        public List<ProductProperty> GetProductsList()
        {
            ProductDAC dac = new ProductDAC();
            List<ProductProperty> list = dac.GetProductsList();
            dac.Dispose();
            return list;
        }

        public bool Insert(ProductProperty pr)
        {
            ProductDAC dac = new ProductDAC();
            bool bResult = dac.Insert(pr);
            dac.Dispose();
            return bResult;
        }

        public bool Delete(ProductProperty pr)
        {
            ProductDAC dac = new ProductDAC();
            bool bResult = dac.Delete(pr);
            dac.Dispose();
            return bResult;
        }


        public bool Update(ProductProperty pr)
        {

            ProductDAC dac = new ProductDAC();
            bool bResult = dac.Update(pr);
            dac.Dispose();
            return bResult;
        }

        public List<ProductProperty> GetProductSearch(ProductProperty pr)
        {
            ProductDAC dac = new ProductDAC();
            List < ProductProperty > list = dac.GetProductSearch(pr);
            dac.Dispose();
            return list;
        }
    }
}
