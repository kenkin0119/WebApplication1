using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using _03Model.Models;




namespace _03Model.Controllers
{
    public class LinqController : Controller
    {
        //建立DB Context物件 名叫db
        NorthwindEntities db =new NorthwindEntities();
        
        public string ShowEmployee()
        {
            //SQL
            //select * from 員工

            //Linq
            //var result = from s in db.員工
            //             select s;

            //string show = "";
            
            //foreach(var item in result)
            //{
            //    show+= "員工編號 :" + item.員工編號+", ";
            //    show+= "姓名 :"+ item.姓名+", ";
            //    show+= "職稱 :"+ item.職稱 + "<hr>";
            //}

            //擴充
            var result = db.員工;

            string show = "";

            foreach (var item in result)
            {
                show += "員工編號 :" + item.員工編號 + ", ";
                show += "姓名 :" + item.姓名 + ", ";
                show += "職稱 :" + item.職稱 + "<hr>";
            }

            return show;
        }

        public string ShowCustomer()
        {
            //SQL
            //select * from 客戶

            //Linq
            //var result = from s in db.客戶
            //             select s;

            //string show = "";

            //foreach (var item in result)
            //{
            //    show += "客戶編號 :" + item.客戶編號 + ", ";
            //    show += "公司名稱 :" + item.公司名稱 + ", ";
            //    show += "國家地區 :" + item.國家地區 + ", ";
            //    show += "城市 :" + item.城市 + ", ";
            //    show += "地址 :" + item.地址 + "<hr>";
            //}

            //擴充
            var result = db.客戶.Where(客戶=> 客戶.城市=="高雄市");

            string show = "";

            foreach (var item in result)
            {
                show += "客戶編號 :" + item.客戶編號 + ", ";
                show += "公司名稱 :" + item.公司名稱 + ", ";
                show += "所在城市 :" + item.城市 + ", ";
                show += "區域地址 :" + item.地址 + ", ";
                show += "聯絡電話 :" + item.電話 + "<hr>";
            }

            return show;
        }
    }
}