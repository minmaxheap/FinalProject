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
    public class MaterialController : Controller
    {
        // GET: Material
        public ActionResult Index(string productCode,string op_code,string childCode,int page=1)
        {
            DateTime from = Convert.ToDateTime("2021-10-10");
            DateTime to = Convert.ToDateTime("2022-10-10");

            int pagesize = Convert.ToInt32(WebConfigurationManager.AppSettings["pagesize"]);
            Adding_materialDAC dac = new Adding_materialDAC();
            List<Adding_materialProperty> list = dac.GetData(from, to, productCode, op_code, childCode, page, pagesize);
            int totalCount = dac.GetProductTotalCount(from, to, productCode,  op_code, childCode);
            List<ComboItem> categories = dac.GetProduct();
            List<ComboItem> categories2 = dac.GetOperation();
            List<ComboItem> categories3 = dac.GetChildCode();

            PagingInfo pageInfo = new PagingInfo
            {
                TotalItems = totalCount,
                ItemsPerPage = pagesize,
                CurrentPage = page
            };

            categories.Insert(0, new ComboItem { Code = "" });

            categories2.Insert(0, new ComboItem { Code = "" });

            categories3.Insert(0, new ComboItem { Code = "" });


            ViewBag.Categories = new SelectList(categories, "Code", "Code");
            ViewBag.Categories2 = new SelectList(categories2, "Code", "Code");
            ViewBag.Categories3 = new SelectList(categories3, "Code", "Code");


            ViewBag.productCode = productCode;
            ViewBag.op_code = op_code;
            ViewBag.childCode = childCode;

            ViewBag.PagingInfo = pageInfo;
            return View(list);
        }

       
    }
}