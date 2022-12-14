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

        public string ShowCustomersByAddress(string keyword)
        {
            //SQL
            //select * from 客戶 where 地址 like '%中正%'

            //Linq
            //var result = from c in db.客戶
            //             where c.地址.Contains(keyword)
            //             select c;
            string show = "";
            
            //Linq擴充
            var result=db.客戶.Where(c=>c.地址.Contains(keyword));

            //select * from 客戶 where 地址 like '中正%'
            var result2 = db.客戶.Where(c => c.地址.StartsWith(keyword));

            //select * from 客戶 where 地址 like '%中正'
            var result3 = db.客戶.Where(c => c.地址.EndsWith(keyword));

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


        public string ShowProduct()
        {
            //SQL
            //select * from 產品 where 單價>30
            //order by 單價,庫存量 desc

            //Linq
            var result = from p in db.產品資料
                         where p.單價>30
                         orderby p.單價,p.庫存量 descending
                         select p;



            //擴充                                              先依照單價排序                有相同的再按照庫存量排序
            var result2 = db.產品資料.Where(p => p.單價 > 30).OrderByDescending(p => p.單價).ThenByDescending(p => p.庫存量);

            string show = "";
            foreach (var item in result)
            {
                show += "產品編號 :" + item.產品編號 + ", ";
                show += "產品名稱 :" + item.產品 + ", ";
                show += "供應商編號 :" + item.供應商編號 + ", ";
                show += "單價 :" + item.單價 + ", ";
                show += "庫存量 :" + item.庫存量 + ", ";
                show += "單位數量 :" + item.單位數量 + "<hr>";
            }

            return show;
        }

        public string ShowProductInfo()
        {
            //SQL
            //select count(*),sum(單價),avg(單價),max(單價),min(單價) from 產品

            //擴充
            var result = db.產品資料;
            

            string show = "";
            
                show += "產品數量 :" + result.Count() + ", ";
                show += "單價總和 :" + result.Sum(a=>a.單價) + ", ";
                show += "平均單價 :" + result.Average(b=>b.單價) + ", ";
                show += "最高單價 :" + result.Max(p=>p.單價) + ", ";
                show += "最低單價 :" + result.Min(p=>p.單價) + "<hr>";

            return show;
        }


    }
}