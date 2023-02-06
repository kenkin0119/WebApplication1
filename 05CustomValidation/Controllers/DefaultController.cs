using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _05CustomValidation.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public bool Index(string value)
        {
            string idNumber = value.ToString();
            bool a;
            Response.Write(idNumber);
            Response.Write("<hr>");

            List<string> list = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "J", "K", "L", "M", "N", "P", "Q", "R", "S", "T", "U", "V", "X", "Y", "W", "Z", "I", "O" };
            int eng = list.IndexOf(idNumber[0].ToString()) + 10;

            int n1 = eng / 10;
            int n2 = eng % 10;

            int sum = n1 * 1 + n2 * 9;

            for (int i = 1; i < 9; i++)
            {
                sum += (Convert.ToInt32(idNumber[i]) - 48) * (9 - i);
                Response.Write(idNumber[i]);
                Response.Write("<br>");
                Response.Write(Convert.ToInt32(idNumber[i]));
                Response.Write("<hr>");
            }

            a = 10 - (sum % 10) == Convert.ToInt32(idNumber[9]) - 48;

            return a;
        }
    }
}