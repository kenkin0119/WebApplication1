using PagedList;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Tour.Models;

namespace Tour.Controllers
{
    public class HomeController : Controller
    {
        TourContext db = new TourContext();
        GetData gd = new GetData();
        int pageSize = 30;

        public ActionResult Index(int page = 1)
        {
            //pagedlist
            int currentPage = page < 1 ? 1 : page;
            var Attration = db.Attrations.ToList();

            var result = Attration.ToPagedList(currentPage, pageSize);

            return View(result);
        }

        public ActionResult Display(string id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var attration = db.Attrations.Find(id);

            if (attration == null)
                return HttpNotFound();

            return View(attration);
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(VMLogin vMLogin)
        {
            string sql = "select * from Members where Account=@id and Password=@pw";

            List<SqlParameter> list = new List<SqlParameter>
            {
                new SqlParameter("@id",vMLogin.Account),
                new SqlParameter("@pw",vMLogin.Password)
            };

            var rd = gd.LoginQuery(sql, list);
            if (rd != null && rd.HasRows)
            {
                Session["user"] = rd;
                rd.Close();
                return RedirectToAction("Index");
            }

            ViewBag.ErrMsg = "帳號或密碼有誤";
            rd.Close();
            return View();
        }

        public ActionResult Logout()
        {
            Session["user"] = null;
            return RedirectToAction("Login");
        }
    }
}