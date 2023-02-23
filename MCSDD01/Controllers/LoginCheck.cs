using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace MCSDD01.Controllers
{
    public class LoginCheck:ActionFilterAttribute
    {
        void LoginState(HttpContext context)
        {
            if (context.Session["user"] == null)
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