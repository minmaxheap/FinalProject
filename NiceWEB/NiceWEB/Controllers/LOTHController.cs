using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NiceWEB.Models.DAC;
using NiceWEB.Models;
using System.Web.Configuration;

namespace NiceWEB.Controllers
{
    public class LOTHController : Controller
    {
        // GET: LOTH
        public ActionResult Index(string LotID, int page = 1)
        {
            if (LotID == null)
            {
                return View();

            }
            else
            {
                int pagesize = Convert.ToInt32(WebConfigurationManager.AppSettings["pagesize"]);

                LOT_HISDAC dac = new LOT_HISDAC();
                List<LOT_HIS> List = dac.GetData(LotID, page, pagesize);
                int totalCount = dac.GetProductTotalCount(LotID);
                dac.Dispose();

                PagingInfo pageInfo = new PagingInfo
                {
                    TotalItems = totalCount,
                    ItemsPerPage = pagesize,
                    CurrentPage = page
                };

                ViewBag.LotID = LotID;
                ViewBag.PagingInfo = pageInfo;

                return View(List);
            }
        }
    }
}