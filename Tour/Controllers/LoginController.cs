﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using Tour.Models;

namespace Tour.Controllers
{
    public class LoginController : Controller
    {
        GetData gd = new GetData();
        TourContext db = new TourContext();

        // GET: Login
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
            var admin = db.Administrators.Where(x => x.Account == vMLogin.Account && x.Password == vMLogin.Password).FirstOrDefault();
            if (rd != null && rd.HasRows)
            {
                Session["user"] = rd;
                rd.Close();
                return RedirectToAction("Index", "Attrations");
            }

            if (admin != null)
            {
                Session["admin"] = admin;
                rd.Close();
                return RedirectToAction("Index", "HomeManager");
            }

            ViewBag.ErrMsg = "帳號或密碼有誤";
            rd.Close();
            return View();
        }

        public ActionResult Logout()
        {
            Session["emp"] = null;
            return RedirectToAction("Login");
        }
    }
}