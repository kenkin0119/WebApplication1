using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace CSharp.Controllers
{
    public class _02StatementController : Controller
    {
       public void Statement()
        {
            int a = 10;
            a = 20;

            a = a + 10;   //a=30
            a += 10;      //a=40
            a -= 15;      //a=25
            a *= 10;      //a=250
            a /= 25;      //a=10

            a = a + 1;
            a += 1;
            a++;         //a=13

            Response.Write(a);
            Response.Write("<hr>");

            ///////////////////////////////////////
            ///
            int x = 123;
            float y = 12.12345567f;
            float z = 12.1234f;
            float result = 0;

            result = x + z;
            Response.Write("y=" + y);
            Response.Write("<br>");
            Response.Write("result="+result);
            Response.Write("<hr>");


            float xx = 10000.9f;
            float yy = 9999.3f;
            Response.Write("xx-yy=" + (xx - yy));

            Response.Write("<hr>");

            Response.Write("xx-yy=" + ((decimal)xx - (decimal)yy));  //轉換資料型態 decimal 用十進制算
           }


        //if敘述
        public string IfStatement(int score)
        {
            if (score >= 90)
                return("優等");
            else if (score >= 80)
                return("甲等");
            else if (score >= 70)
                return("乙等");
            else if (score >= 60)
                return("丙等");
            else
                return("丁等");
        }
        

        

            //Switch敘述
            public void SwitchStatement(string strColor)
            {
                switch (strColor)
                {
                    case "y":
                        Response.Write("黃色");
                        break;
                    case "g":
                        Response.Write("綠色");
                        break;
                    case "r":
                        Response.Write("紅色");
                        break;
                    default:
                        Response.Write("這不是黃綠紅");
                        break;
                }
            }

        //For敘述
        public string ForStatement()
        {
            string[] Ranbow = {"紅", "橙", "黃", "綠", "藍", "靛", "紫"};
            string[] RanbowColor ={ "Red", "Orange", "Yellow", "Green", "Blue", "Indigo", "Violet" };

            string result = "";

            for(int i=0;i< RanbowColor.Length; i++)
            {
                result += "<h2 style=color:" + RanbowColor[i] + ">" + Ranbow[i] + "</h2>";
            }

            return result;
        }

        //Foreach敘述:全部拜訪 不管資料有多長
        public void ForeachStatement()
        {
            string[] Ranbow = { "紅", "橙", "黃", "綠", "藍", "靛", "紫" };

            foreach (string item in Ranbow)
            {
                Response.Write("<h2>" + item + "</h2>");
            }

        }

        //While敘述
        public void WhileStatement()
        {
            int sum = 0;
            int x = 1;
            while ( x <= 100)
            {
                 sum += x;
                 x++;
                
            }
            Response.Write(sum);
        }

        //DO...While敘述
        public void DoWhileStatement()
        {
            int z = 1;
            do
            {
                Response.Write(z+".Hello!!");
                z++;
            } while (z <= 10);
        }

    }
}