using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaberSistemi.Admin.CostumFilter
{
    public class LoginFilter : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)//action method çalıştırıldıktan sonra devreye giriyor
        {
            HttpContextWrapper wrapper = new HttpContextWrapper(HttpContext.Current);

            var SessionControl = context.HttpContext.Session["KullaniciEmail"];

            if (SessionControl==null)
            {
                context.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary { { "controller", "Account" }, { "action", "Login" } });

            }


        }

        public void OnActionExecuting(ActionExecutingContext context)//aciton method tetiklendiğinde devreye firiyor.
        {
           
        }
    }
}