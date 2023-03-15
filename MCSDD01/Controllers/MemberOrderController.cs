using MCSDD01.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.Http.ModelBinding;
using System.Web.Mvc;

namespace MCSDD01.Controllers
{
    [LoginCheck(id = 1)]
    public class MemberOrderController : Controller
    {
        MCSDD01Context db = new MCSDD01Context();
        SetData sd = new SetData();

        public ActionResult Order()
        {
            //var employees = db.Orders.Include(e => e.Employees).Include(e => e.PayTypes).Include(e => e.Shippers);

            //ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "EmployeeName");
            ViewBag.ShipID = new SelectList(db.Shippers, "ShipID", "ShipVia");
            ViewBag.PayTypeID = new SelectList(db.PayTypes, "PayTypeID", "PayTypeName");
            ViewBag.OrderDate = DateTime.Today.ToShortDateString();

            //隨機取一位處理訂單的員工
            int endNum = db.Employees.Count();
            
            Random r = new Random();
            ViewBag.EmployeeID = db.Employees.OrderBy(m => m.EmployeeID).Skip(r.Next(endNum)).Take(1).FirstOrDefault(); 
                                                //skip(索引值) 必須先OrderBy進行排序才能用
                                                //Random 類別 r物件的Next方法(傳入int Maxvalue)回傳小於Max的非負隨機整數(含0)
                                                //Take(i)取i個



            return View();
        }


        [HttpPost]
        public ActionResult Order(Orders orders,string cartData)
        {

            List<SqlParameter> list = new List<SqlParameter>
            {
                new SqlParameter("@ShipName",orders.ShipName),
                new SqlParameter("@ShipAddress",orders.ShipAddress),
                new SqlParameter("@ShipID",orders.ShipID),
                new SqlParameter("@MemberID",((Members)Session["member"]).MemberID),
                new SqlParameter("@EmployeeID",orders.EmployeeID),
                new SqlParameter("@PayTypeID",orders.PayTypeID),
                new SqlParameter("@cart",cartData)
            };

            sd.executeSqlBySP("addOrders", list);

            TempData["cartFlag"] = "OK";


            return RedirectToAction("MyOrderList");
        }

        public ActionResult MyOrderList()
        {
            var memID = ((Members)Session["member"]).MemberID;
            var orders = db.Orders.Where(m => m.MemberID == memID).ToList();
            return View(orders);
        }
    }
}