using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tour.Models;

namespace Tour.Controllers
{
    public class HomeManagerController : Controller
    {
        TourContext db = new TourContext();
        // GET: HomeManager
        [LoginCheck]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return Login();
        }

        [HttpPost]
        public ActionResult Login(VMLogin vMLogin)
        {
            string pw = BR.getHashPassword(vMLogin.Password);

            var admin = db.Administrators.Where(x => x.Account == vMLogin.Account && x.Password == pw).FirstOrDefault();

            if (admin == null)
            {
                ViewBag.ErrMsg = "帳號或密碼有誤";
                return View(vMLogin);
            }

            Session["admin"] = admin;
            return RedirectToAction("Index");
        }

        [LoginCheck]
        public ActionResult Logout()
        {
            Session["admin"] = null;
            return RedirectToAction("Login");
        }
    }
}