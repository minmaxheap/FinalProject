using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using NiceWEB.Models;
using System.Web.Script.Serialization;
using System.Web.Configuration;
using NiceWEB.Models.DAC;

namespace NiceWEB.Controllers
{
    public class StockController : Controller
    {
        public ActionResult Index(string opCode, string productCode,int page =1)
        {
            
            int pagesize = Convert.ToInt32(WebConfigurationManager.AppSettings["pagesize"]);

            StockDAC dac = new StockDAC();
            List<Product> list = dac.GetData(opCode, productCode, page, pagesize);

            //콤보박스 구현 2개 
            List<ComboItem> categories = dac.GetProduct();
            List<ComboItem> categories2 = dac.GetOperation();

            //페이징 갯수를 정하는거 => 전체데이터의 갯수 가져오기 
            int totalCount = dac.GetProductTotalCount(opCode, productCode);

            dac.Dispose();

            PagingInfo pageInfo = new PagingInfo
            {
                TotalItems = totalCount,
                ItemsPerPage = pagesize,
                CurrentPage = page
            };

            //콤보박스 view에 보여주기
            categories.Insert(0, new ComboItem { Code = "" });
            categories2.Insert(0, new ComboItem { Code = "" });

            ViewBag.Categories = new SelectList(categories, "Code", "Code");
            ViewBag.Categories2 = new SelectList(categories2, "Code", "Code");

            ViewBag.opCode = opCode;
            ViewBag.productCode = productCode;
            ViewBag.PagingInfo = pageInfo;

            return View(list);
        }
    }
}