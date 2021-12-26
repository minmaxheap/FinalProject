﻿using DAC;
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
        public DataTable GetProductsList()
        {
            ProductDAC dac = new ProductDAC();
            DataTable dt = dac.GetProductsList();
            dac.Dispose();
            return dt;
        }

        public bool Insert(ProductProperty vo)
        {
            ProductDAC dac = new ProductDAC();
            bool bResult = dac.Insert(vo);
            dac.Dispose();
            return bResult;
        }

        public bool Delete(ProductProperty vo)
        {
            ProductDAC dac = new ProductDAC();
            bool bResult = dac.Delete(vo);
            dac.Dispose();
            return bResult;
        }


        public bool Update(ProductProperty vo)
        {

            ProductDAC dac = new ProductDAC();
            bool bResult = dac.Update(vo);
            dac.Dispose();
            return bResult;
        }
    }
}
