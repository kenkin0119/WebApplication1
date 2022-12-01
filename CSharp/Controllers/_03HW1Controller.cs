using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace CSharp.Controllers
{
    public class _03HW1Controller : Controller
    {
        //第一題,判斷質數
        public string No1(int n)
        {
            //寫一個程式判斷n是不是質數  
            if (n == 2)
            {
                return (n + "是質數");
            }
            else if (n > 0 & n % 2 == 0)
            {
                return (n + "不是質數");
            }
            else if (n > 2)
            {
                for (int i = 3; i <= Math.Sqrt(n); i += 2)
                {
                    if (n % i == 0)
                    {
                        return (n + "不是質數");
                    }
                }
                return (n + "是質數");
            }
            else 
            {
                return (n+ "不是質數");
            }
        }

        //第二題,找任意兩數之最大公因數
        public void No2(int n, int m)
        {
            string gcd = "";
            //寫一個程式找出n與m的最大公因數
            for (int i = 1; i <= m & i <= n; i++)
            {
                if (n % i == 0 & m % i == 0)   //找到公因數就存到gcd 存到最後一個就是最大公因數
                {
                    gcd = i.ToString();
                }
            }
            Response.Write(gcd + "是"+n+"與"+m+"的最大公因數");
        }


        //第三題,迴文判斷
        public void No3(int n)
        {
            //n=12321
            //n=1221
            //n=12333321
            //寫一個程式判斷n是不是迴文
            string m = "";

            for (int i = n.ToString().Length - 1; i >= 0; i--)  //索引值所以長度-1
            {
                m += n.ToString()[i];
            }

            if (m == n.ToString())
            {
                Response.Write(n+"是回文");
            }
            else
            {
                Response.Write(n + "不是回文");
            }
        }


        //第四題,發牌程式
        public void No4()
        {
            //for (int i = 1; i <= 52; i++)
            //{
            //    Response.Write("<img src='../poker_img/" + i + ".gif' />");
            //}
            //類別  物件    建構子(製作方法)  new:鑄造物件
            //食譜.食材 菜名      方法    new:煮
            //Random r = new Random();
            //Response.Write(r.Next(1, 53));   //1~52
            //P1[0] = r.Next(1, 53).ToString();
            //https://itsakura.com/csharp-linq#s9

            List<int> P1 = new List<int>();
            List<int> P2 = new List<int>();
            List<int> P3 = new List<int>();
            List<int> P4 = new List<int>();

            Random rnd = new Random(); 
            List<int> randomList = Enumerable.Range(1, 52)    //生成一張只有1~52的表(非list)
                .OrderBy(x => rnd.Next()).Take(52).ToList();  //.OrderBy按照rnd.Next()排序 (x:參數)
                                                              //.Take(52)將排完的全部取出.ToList()再轉成List傳給randomList

            //foreach (var i in randomList){
            //    Response.Write(i + "</br>");
            //}

            for (int i = 0; i < 52; i++)    //索引值0~51
            {
                switch (i % 4)
                {
                    case 0:
                        P4.Add(randomList[i]);
                        break;
                    case 1:
                        P1.Add(randomList[i]);
                        break;
                    case 2:
                        P2.Add(randomList[i]);
                        break;
                    case 3:
                        P3.Add(randomList[i]);
                        break;
                }
            }

            foreach (var st1 in P1)
            {
                Response.Write("<img src='../poker_img/" + st1 + ".gif' />");
            }
            Response.Write( "<hr>");

            foreach (var st2 in P2)
            {
                Response.Write("<img src='../poker_img/" + st2 + ".gif' />");
            }
            Response.Write("<hr>");

            foreach (var st3 in P3)
            {
                Response.Write("<img src='../poker_img/" + st3 + ".gif' />");
            }
            Response.Write("<hr>");

            foreach (var st4 in P4)
            {
                Response.Write("<img src='../poker_img/" + st4 + ".gif' />");
            }
        }
    }
}


    