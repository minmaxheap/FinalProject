﻿using NiceWEB.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace NiceWEB.Controllers
{
    public class ComparePlanController : Controller
    {

        // GET: ComparePlan
        public ActionResult Index(string startDate, string endDate, string workID, string prdCode, int page = 1)
        {
            //select box에 전달할 데이터
             CommonDAC comDAC = new CommonDAC();
           
              List<ComboItem> orderList = comDAC.GetWorkOrder();
              List<ComboItem> prodList = comDAC.GetProductCode();

            comDAC.Dispose();
            orderList.Insert(0, new ComboItem { Code = ""});
            prodList.Insert(0, new ComboItem { Code = "" });
            ViewBag.orderList = new SelectList(orderList, "Code", "Code");
            ViewBag.prodList = new SelectList(prodList, "Code", "Code");

            //list 보내기

            ComparePlanDAC dac = new ComparePlanDAC();
    
            int pagesize = Convert.ToInt32(WebConfigurationManager.AppSettings["pagesize"]);
            int totalCount = dac.GetTotalCount(workID, prdCode);
            PagingInfo pageInfo = new PagingInfo
            {
                TotalItems = totalCount,
                ItemsPerPage = pagesize,
                CurrentPage = page
            };
            ViewBag.PagingInfo = pageInfo;

            List<ComparePlan> list = dac.GetPageList( startDate,endDate, workID, prdCode, page, pagesize);
            // GAUGE CHART 데이터 받고 보내기
            List <ComparePlan> gauge = dac.GetChartData("3", "3",workID,prdCode);
            dac.Dispose();
            ViewBag.chart = gauge;
            ViewBag.work = gauge[0].WORK_ORDER_ID;
            ViewBag.ordQty = gauge[0].ORDER_QTY;
            ViewBag.prdQty = gauge[0].PRODUCT_QTY;
            ViewBag.defQty = gauge[0].DEFECT_QTY;

             //산술 오버플로우가 일어나서 DECIMAL 반올림함
            ViewBag.qualityRate = Math.Round( (gauge[0].PRODUCT_QTY / (gauge[0].PRODUCT_QTY + gauge[0].DEFECT_QTY)) * Convert.ToDecimal(100),2);
            ViewBag.defectRate = Math.Round((gauge[0].DEFECT_QTY / (gauge[0].PRODUCT_QTY + gauge[0].DEFECT_QTY))* Convert.ToDecimal(100),2);

            // RedirectToAction("Index", "ComparePlan");
            //if (startDate == null) startDate = DateTime.Now.ToString("YYYY-MM-DD");
            if (startDate == null) ViewBag.startDate = DateTime.Now.AddDays(-6).ToString();
            else { ViewBag.startDate = startDate; }
            //if (endDate == null) endDate = DateTime.Now.ToString("YYYY-MM-DD");
            if (endDate == null) ViewBag.endDate = "2022-01-01";
            else { ViewBag.endDate = endDate; }
   
            return View(list);
        }



    }
}