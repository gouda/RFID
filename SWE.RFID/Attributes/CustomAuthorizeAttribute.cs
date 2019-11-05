using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWE.RFID.Attributes
{
    public class CustomAuthorizeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var user = filterContext.HttpContext.Session["accessToken"];
            if (user == null || user.ToString() == "")
                filterContext.Result = new RedirectResult("/Account/Login");
        }
    }
     
}