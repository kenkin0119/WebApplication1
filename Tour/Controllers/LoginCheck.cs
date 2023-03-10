using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tour.Controllers
{
    public class LoginCheck:ActionFilterAttribute
    {
        public bool flag = true;
        public short i = 2;

        void UserLoginState(HttpContext context)
        {
            if (context.Session["user"] == null)
            {
                context.Response.Redirect("/Home/Login");
            }
        }

        void AdminLoginState(HttpContext context)
        {
            if (context.Session["admin"] == null)
            {
                context.Response.Redirect("/HomeManager/Login");
            }
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (flag)
            {
                HttpContext context = HttpContext.Current;
                if (i == 1) //因為i預設為2 需要user權限要加上i=1
                {
                    UserLoginState(context);
                }
                else
                {
                    AdminLoginState(context);
                }
            }
        }
    }
}