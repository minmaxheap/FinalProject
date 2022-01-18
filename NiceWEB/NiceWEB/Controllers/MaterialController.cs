﻿using System;
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
        public ActionResult Index(string startDate, string endDate, string productCode,string op_code,string childCode,int page=1)
        {
            if (Session["UserID"] == null || Session["UserID"].ToString().Length < 1)
            {
                return RedirectToAction("Login", "Home");
            }

            int pagesize = Convert.ToInt32(WebConfigurationManager.AppSettings["pagesize"]);
            Adding_materialDAC dac = new Adding_materialDAC();
            List<Adding_materialProperty> list = dac.GetData(startDate, endDate, productCode, op_code, childCode, page, pagesize);
            int totalCount = dac.GetProductTotalCount(startDate, endDate, productCode,  op_code, childCode);
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

            if (startDate == null) ViewBag.startDate = DateTime.Now.AddDays(-15).ToString();
            else { ViewBag.startDate = startDate; }

            if (endDate == null) ViewBag.endDate = DateTime.Now.ToString();
            else { ViewBag.endDate = endDate; }


            ViewBag.PagingInfo = pageInfo;
            return View(list);
        }

       
    }
}