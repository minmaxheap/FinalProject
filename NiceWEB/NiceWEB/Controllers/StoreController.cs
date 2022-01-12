using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using NiceWEB.Models;
using System.Web.Script.Serialization;
namespace NiceWEB.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        public ActionResult Index(string storeCode, string ProductCode)
        {
            StoreDAC dac = new StoreDAC();
            List<StoreProperty> list = dac.GetSearch(storeCode, ProductCode);
            List<ComboItem> categories = dac.GetCode();
            List<ComboItem> categories2 = dac.GetProductCode();

            dac.Dispose();
            categories.Insert(0, new ComboItem { Code = ""});
            categories2.Insert(0, new ComboItem { Code = "" });

            ViewBag.Categories = new SelectList(categories,"Code","Code");
            ViewBag.Categories2 = new SelectList(categories2, "Code", "Code");



            return View(list);
        }
    }
}