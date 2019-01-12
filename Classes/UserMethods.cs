using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AmbucsProject.Classes
{
    public class UserMethods
    {
        public class VerifyLoginAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                if (UserSession.User == null)
                {
                    var url = HttpUtility.UrlEncode(filterContext.HttpContext.Request.Url.AbsolutePath + filterContext.HttpContext.Request.Url.Query);
                    filterContext.Result = new RedirectResult(string.Format("/", url));
                }
            }
        }
        public class VerifyAdminAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                if(UserSession.User == null)
                {
                    var url = HttpUtility.UrlEncode(filterContext.HttpContext.Request.Url.AbsolutePath + filterContext.HttpContext.Request.Url.Query);
                    filterContext.Result = new RedirectResult(string.Format("/", url));
                }
                else
                {
                    if (UserSession.User.user_role != 1)
                    {
                        var url = HttpUtility.UrlEncode(filterContext.HttpContext.Request.Url.AbsolutePath + filterContext.HttpContext.Request.Url.Query);
                        filterContext.Result = new RedirectResult(string.Format("/home", url));
                    }
                }
                
            }
        }
        public class VerifyLoggedInAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                if (UserSession.User != null)
                {
                    var url = HttpUtility.UrlEncode(filterContext.HttpContext.Request.Url.AbsolutePath + filterContext.HttpContext.Request.Url.Query);
                    filterContext.Result = new RedirectResult(string.Format("/Home/", url));
                }
                

            }
        }
    }
}