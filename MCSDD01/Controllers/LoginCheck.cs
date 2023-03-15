using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using System.Web.Routing;

namespace MCSDD01.Controllers
{
    public class LoginCheck: ActionFilterAttribute  //ActionFilterAttribute:可以寫在[]裡面
    {
        public bool flag = true; //旗標控制:控制正向與負向 true 要登入 false 不用登入

        public short id = 2;

        void MemberLoginState(HttpContext context)
        {
            if (context.Session["member"] == null)
            { 
                context.Response.Redirect("/Home/Login");
            }
        }

        void AdminLoginState(HttpContext context)
        {
            if (context.Session["user"] == null)
            {
                context.Response.Redirect("/HomeManager/Login");
            }
        }
        //OnActionExecuting:執行LoninCheck之前先呼叫這個
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (flag)
            {
                HttpContext context = HttpContext.Current;
                if (id == 1)
                {
                    MemberLoginState(context);
                }
                else
                    AdminLoginState(context);
            }
        }
    }
}