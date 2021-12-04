using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace WebPdfOdev.Filters
{
    public class AdminAuthorizationFilter: FilterAttribute,IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Session["yoneticiid"] == null)
            {
                filterContext.Result = new RedirectResult("~/PublicUl/Hata");

            }

           
        }
    }
}