using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using NiceWEB.Models;
using System.Web.Script.Serialization;
using System.Web.Configuration;

namespace NiceWEB.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        //public ActionResult Index(string storeCode, string ProductCode)
        //{
        //    StoreDAC dac = new StoreDAC();
        //    List<StoreProperty> list = dac.GetSearch(storeCode, ProductCode);
        //    List<ComboItem> categories = dac.GetCode();
        //    List<ComboItem> categories2 = dac.GetProductCode();

        //    dac.Dispose();
        //    categories.Insert(0, new ComboItem {Code = ""});
        //    categories2.Insert(0, new ComboItem {Code = "" });

        //    ViewBag.Categories = new SelectList(categories,"Code","Code");
        //    ViewBag.Categories2 = new SelectList(categories2, "Code", "Code");



        //    return View(list);
        //}

        public ActionResult Index (string storeCode, string ProductCode, int page=1)
        {
            if (Session["UserID"] == null || Session["UserID"].ToString().Length < 1)
            {
                Session["ReturlUrl"] = "Store/Index";

                return RedirectToAction("Login", "Home");
            }

            //if (string.IsNullOrWhiteSpace(ProductCode) && string.IsNullOrWhiteSpace(storeCode))
            //{
            //    StoreDAC dac = new StoreDAC();
            //    List<StoreProperty> list = null;
            //    List<ComboItem> categories = dac.GetCode();
            //    List<ComboItem> categories2 = dac.GetProductCode();

            //    PagingInfo pageInfo = new PagingInfo
            //    {
            //        TotalItems = 0,
            //        ItemsPerPage = 10,
            //        CurrentPage = page
            //    };
            //    ViewBag.PagingInfo = pageInfo;

            //    categories2.Insert(0, new ComboItem { Code = "" });

            //    ViewBag.Categories = new SelectList(categories, "Code", "Code");
            //    ViewBag.Categories2 = new SelectList(categories2, "Code", "Code");

            //    //storeCode = "FS_STORE";
            //    ViewBag.ProductCode = ProductCode;
            //    ViewBag.storeCode = storeCode;


            //    return View(list);
            //}
            
            if (storeCode == null)
            {
                storeCode = "FS_STORE";
                int pagesize = Convert.ToInt32(WebConfigurationManager.AppSettings["pagesize"]);
                StoreDAC dac = new StoreDAC();
                List<StoreProperty> list = dac.GetPageList(storeCode, ProductCode, page, pagesize);
                List<ComboItem> categories = dac.GetCode();
                List<ComboItem> categories2 = dac.GetProductCode();
                int totalCount = dac.GetProductTotalCount(storeCode, ProductCode);

                dac.Dispose();

                PagingInfo pageInfo = new PagingInfo
                {
                    TotalItems = totalCount,
                    ItemsPerPage = pagesize,
                    CurrentPage = page
                };
                //categories.Insert();
                categories2.Insert(0, new ComboItem { Code = "" });

                ViewBag.Categories = new SelectList(categories, "Code", "Code");
                ViewBag.Categories2 = new SelectList(categories2, "Code", "Code");

                ViewBag.storeCode = storeCode;
                ViewBag.productCode = ProductCode;
                ViewBag.PagingInfo = pageInfo;


                ViewBag.menu1 = "";
                ViewBag.menu2 = "";
                ViewBag.menu3 = "";
                ViewBag.menu4 = "";
                ViewBag.menu5 = "";
                ViewBag.menu6 = "active";
                ViewBag.menu7 = "";
                ViewBag.menu8 = "";

                return View(list);
            }

            else
            {
                int pagesize = Convert.ToInt32(WebConfigurationManager.AppSettings["pagesize"]);
                StoreDAC dac = new StoreDAC();
                List<StoreProperty> list = dac.GetPageList(storeCode, ProductCode, page, pagesize);
                List<ComboItem> categories = dac.GetCode();
                List<ComboItem> categories2 = dac.GetProductCode();
                int totalCount = dac.GetProductTotalCount(storeCode, ProductCode);

                dac.Dispose();

                PagingInfo pageInfo = new PagingInfo
                {
                    TotalItems = totalCount,
                    ItemsPerPage = pagesize,
                    CurrentPage = page
                };
                //categories.Insert();
                categories2.Insert(0, new ComboItem { Code = "" });

                ViewBag.Categories = new SelectList(categories, "Code", "Code");
                ViewBag.Categories2 = new SelectList(categories2, "Code", "Code");

                ViewBag.storeCode = storeCode;
                ViewBag.productCode = ProductCode;
                ViewBag.PagingInfo = pageInfo;



                ViewBag.menu1 = "";
                ViewBag.menu2 = "";
                ViewBag.menu3 = "";
                ViewBag.menu4 = "";
                ViewBag.menu5 = "";
                ViewBag.menu6 = "active";
                ViewBag.menu7 = "";
                ViewBag.menu8 = "";

                return View(list);
            }
            
        }
    }
}