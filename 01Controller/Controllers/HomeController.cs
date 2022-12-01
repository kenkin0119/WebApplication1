//Name Space(命名空間)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _01Controller.Controllers
{
    //     類別    名稱        繼承   
    public class HomeController : Controller
    {
        //修飾詞
        //public (指大家都能存取)因為瀏覽器不是家人也不是親戚
        //protected(指我的家人才能存取,或跟我有關係的親戚)
        //private(指我的家人才能存取)

        //這種函數是Controller裡的專用函數,稱作Action
        //         資料型態
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public string ShowAry()
        {
            int[] score = { 58, 95, 48, 15, 35, 100 };
            int sum = 0;
            string show = "";

            foreach (int i in score)
            {
                sum += i;
                show += i + ", ";
            }

            show += "<hr>總成績為" + sum;
            return show;
        }

        public string ShowaImage()
        {
            string show = "";
            for (int i = 1; i <= 6; i++)
            {
                show += "<a href='ShowImageIndex?index="+i+"'><img src='../image/" + i + ".jpg' width='300' /></a>";
            }
            return show;
        }

        public string ShowImageIndex(int index)
        {
            string show = "";
            string[] name = { "a","b", "c", "d", "e", "f" };
            //1.字串串接模式
            show = "<p style='text-align:center'><img src='../image/" + index + ".jpg' width='500' /></p><h3 style='text-align:center'>" + name[index-1] +"</h3>";
            show += "</br><div style='text-align:right'><a href='ShowaImage'>回上一頁</a></div>";

            //2.字串格式函數                                                    第一個參數                                             第二個參數
            //show = string.Format("<p style='text-align:center'><img src='../image/{0}.jpg' width='500' /></p><h3 style='text-align:center'>{1}</h3>", index, name[index - 1]);
            return show;
        }
    }
}