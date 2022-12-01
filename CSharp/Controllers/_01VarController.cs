using System.Web.Mvc;

namespace CSharp.Controllers
{
    public class _01VarController : Controller
    {
        public string MyFirstCS()
        {
            string w = "Hellow World";

            return w;
        }


        public int MyFirstCS2()
        {
            int w = 45564;  //32位元帶正負號整數

            return w;
        }


        public string checkGender(bool gender)
        {
            bool w = gender;

            if (w)
                return "男生";

            return "女生";
        }


        public string checkGender2(string name, bool gender)
        {
            bool w = gender;
            string n = name; ;

            string r = "";

            r = w ? "男生" : "女生";



            return "<h1>" + n + "您好!您的性別是" + r + "</h1>";
        }


        public void number()    //void不需回傳值
        {
            //數值Data Type

            byte a = 123; //8位元正整數(0~2^8-1=255)
            sbyte b = 123;//8位元整數(-128~127 -2^7~2^7-1)

            short c = 123;//16位元整數(-2^15~2^15-1)
            int d = 123;  //32位元整數(-2^31~2^31-1)
            long e = 123; //64位元整數(-2^63~2^63-1)

            ushort f = 123;//16位元正整數(0~2^16)
            uint g = 123;  //32位元正整數(0~2^32)
            ulong h = 123; //64位元正整數(0~2^64)

            //////////////////////////////////////////////////////////
            float i = 123.345f;      //單精準度浮點數
            double j = 123.345345345;//倍(雙)精準度浮點數


        }

        public string getGoogleMap(string place)
        {
            return "<a href='https://www.google.com.tw/maps/search/" + place +"'>點我產生地圖</a>";
        }
    }
}