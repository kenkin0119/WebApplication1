﻿using MCSDD01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MCSDD01.Controllers
{
    public class HomeController : Controller
    {
        MCSDD01Context db = new MCSDD01Context();
        public ActionResult Index()
        {

            var products = db.Products.Where(p => p.Discontinued == false).ToList();

            return View(products);
        }

        public ActionResult Display(string id)
        {
            if(id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var product = db.Products.Find(id);

            if(product == null)
                return HttpNotFound();

            return View(product);
        }

        public ActionResult MyCart()
        {
            return View();
        }
    }
}
