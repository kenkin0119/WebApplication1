using _03Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _03Model.Controllers
{
    public class HomeController : Controller
    {
        
        public string ShowAryDesc()
        {
            int[] score = { 58, 95, 48, 15, 35, 100 };
            string show="";

            //Linq查詢運算式寫法
            //var result = from s in score
            //             orderby s descending
            //             select s;

            //Linq擴充方法寫法
            var result = score.OrderByDescending(s => s);

            
            show += "排序前";
            foreach(var item in score)
            {
                show += item + ", ";
            }


            show += "<br>排序後";
            foreach (var item in result)
            {
                show += item + ", ";
            }

            return show;
        }

        public string ShowAryAsc()
        {
            int[] score = { 58, 95, 48, 15, 35, 100 };
            string show = "";

            //Linq查詢運算式寫法
            var result = from s in score
                         orderby s ascending
                         select s;

            //Linq擴充方法寫法
            var result2 = score.OrderBy(s => s);


            show += "排序前 :";
            foreach (var item in score)
            {
                show += item + ", ";
            }


            show += "<br>排序後 :";
            foreach (var item in result)
            {
                show += item + ", ";
            }
            show += "<hr>";
            show += "總分" + result.Sum();
            show += "<br>";
            show += "平均" + result.Average();
            
            return show;
        }

        public string LoginMember(string uid,string pwd)
        {
            //Member member1 = new Member(); //鑄造物件
            //member1.UId = "tom";
            //member1.Pwd = "123";
            //member1.Name = "湯姆";

            //Member member2 = new Member();
            //member2.UId = "jsper";
            //member2.Pwd = "456";
            //member2.Name = "賈斯柏";

            //Member member3 = new Member();
            //member3.UId = "mary";
            //member3.Pwd = "789";
            //member3.Name = "瑪莉";

            Member[] members = new Member[]
            {
                new Member{UId="tom",Pwd="123",Name="湯姆"},
                new Member{UId="jsper",Pwd="456",Name="賈斯柏"},
                new Member{UId="mary",Pwd="789",Name="瑪莉"}
            };

            //SQL
            //select * from member
            //where UId=uid and Pwd=pwd

            //Linq查詢運算式寫法
            var result = (from m in members
                         where m.UId == uid && m.Pwd == pwd
                         select m).FirstOrDefault();
            //若條件為Pk為避免傳回陣列必須使用FirstOrDefault()

            //Linq擴充方法寫法
            var result2 = members.Where(m => m.UId == uid && m.Pwd == pwd).FirstOrDefault();

            string show="";

            if (result == null)
            {
                show = "帳號或密碼錯誤";
            }
            else
            {
                show = "歡迎" + result.Name + "登入本系統!";
            }

            return show;
        }

        

    }
}