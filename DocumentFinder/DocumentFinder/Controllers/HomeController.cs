﻿using System;
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
        AModel repo = new AModel();
        public ActionResult Index()
        {
            var result = new AModel
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
                return PartialView("_IndexGrid", repository(search));
            }
        }
        public IEnumerable<DOCUMENT> repository(String search)
        {
            return db.Set<DOCUMENT>().Where(x => x.DocName.Contains(search));
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