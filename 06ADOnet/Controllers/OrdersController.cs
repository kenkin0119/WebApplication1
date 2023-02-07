using _06ADOnet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _06ADOnet.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        GetData gd = new GetData();
        NorthwindEntities2 db = new NorthwindEntities2();

        public ActionResult Index()
        {
            string sql = "select o.*,c.CompanyName from Orders as o inner join customers as c on o.CustomerID=c.CustomerID";

            var orders = gd.TableQuery(sql);

            orders.Columns[8].ColumnName = "收件人姓名";

            return View(orders);
        }

        public ActionResult Display(int id)
        {
            string sql = "SELECT Orders.OrderID, Orders.OrderDate, Orders.RequiredDate, Orders.ShippedDate, Orders.Freight, Orders.ShipName, Orders.ShipAddress, Orders.ShipCity, Orders.ShipRegion, Orders.ShipPostalCode, Orders.ShipCountry,Customers.CustomerID, Customers.CompanyName, Customers.ContactName, Customers.ContactTitle,Employees.EmployeeID, Employees.LastName, Employees.FirstName, Shippers.CompanyName AS shipCompany,Shippers.Phone FROM Orders INNER JOIN Customers ON Orders.CustomerID = Customers.CustomerID INNER JOIN Employees ON Orders.EmployeeID = Employees.EmployeeID INNER JOIN Shippers ON Orders.ShipVia = Shippers.ShipperID " +
                         "where orders.OrderID=@id";

            List <SqlParameter> list = new List<SqlParameter>
            {
                new SqlParameter("@id",id)
            };

            var order = gd.TableQuery(sql,list);

            return View(order);
        }

        public ActionResult _DisplayDetail(int id)
        {
            return PartialView(db.OrderDetails.Where(m => m.OrderID == id).ToList());

        }

        public ActionResult _DisplayDetail2(int id)
        {
            string sql = "SELECT Products.ProductName, OrderDetails.UnitPrice, OrderDetails.Quantity, OrderDetails.Discount,(OrderDetails.UnitPrice*OrderDetails.Quantity*(1-OrderDetails.Discount)) as 小計 FROM OrderDetails INNER JOIN Products ON OrderDetails.ProductID = Products.ProductID where OrderDetails.OrderID=@id";

            List<SqlParameter> list = new List<SqlParameter>
            {
                new SqlParameter("@id",id)
            };

            var order = gd.TableQuery(sql, list);

            return PartialView(order);

        }

        public ActionResult _Sum(int id)
        {
            string sql = "SELECT Round(sum((UnitPrice*Quantity)*(1-Discount)),2) FROM OrderDetails group by OrderID having OrderID=@id";

            List<SqlParameter> list = new List<SqlParameter>
            {
                new SqlParameter("@id",id)
            };

            var order = gd.TableQuery(sql, list);

            return PartialView(order);
        }
    }
}