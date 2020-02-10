using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DocumentFinder.Models;

namespace DocumentFinder.Controllers
{
    public class HomeController : Controller
    {
        DBModel db = new DBModel();
        public ActionResult Index()
        {
            AModel result = new AModel
            {
                IE_DOC = db.Set<DOCUMENT>().ToList(),
            };
            return View(result);
        }

        [HttpGet]
        public PartialViewResult IndexGrid(String search)
        {
            if (String.IsNullOrEmpty(search))
            {
                return PartialView("_IndexGrid", db.DOCUMENTs.ToList());
            }
            else
            {
                return PartialView("_IndexGrid", Repository(search));
            }
        }
        public IEnumerable<DOCUMENT> Repository(String search)
        {
            return db.Set<DOCUMENT>().Where(x => x.DocID.ToString().Contains(search) ||
                                                 x.DocType.ToString().Contains(search) ||
                                                 x.DocName.ToString().Contains(search) ||
                                                 x.DocManuf.ToString().Contains(search) ||
                                                 x.DocCatg.ToString().Contains(search) ||
                                                 x.DocWONum.ToString().Equals(search) ||
                                                 x.DocPONum.ToString().Equals(search) ||
                                                 x.DocProjMgr.ToString().Contains(search) ||
                                                 x.DocEqpAmt.ToString().Equals(search) ||
                                                 x.DocDescr.ToString().Contains(search));
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}