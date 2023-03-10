using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tour.Controllers
{
    public class ManagerLoginCheck : ActionFilterAttribute
    {
        void LoginState(HttpContext context)
        {
            if (context.Session["admin"] == null)
            {
                context.Response.Redirect("/HomeManager/Login");
            }
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext context = HttpContext.Current;
            LoginState(context);
        }
    }
}