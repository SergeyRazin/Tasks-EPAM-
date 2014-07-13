using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Epam.ScrumPocker.WebApplication
{
    public class CustomAuthenticationAttribute : FilterAttribute, IAuthorizationFilter
    {
        void IAuthorizationFilter.OnAuthorization(AuthorizationContext filterContext)
        {
            var session = filterContext.HttpContext.Session;
            if (session[SessionTags.User] == null)
            {
                session[SessionTags.RedirectUrl] = filterContext.HttpContext.Request.Url.AbsoluteUri;
                filterContext.Result = new RedirectResult("/Authenticate/Index");
            }
        }
    }
}