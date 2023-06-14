using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.BusinessLogic;
using eUseControl.Web.Extensions;
using System.Web.Routing;
using eUseControl.Domain.Enums;

namespace eUseControl.Web.App_Start
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class NoDirectAccessCustomAccesFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.Url != null &&
                (filterContext.HttpContext.Request.UrlReferrer == null ||
                filterContext.HttpContext.Request.Url.Host != filterContext.HttpContext.Request.UrlReferrer.Host))
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { controller = "Error", action = "Error500" }));
            }
        }
    }
    public class AdminModAttribute : ActionFilterAttribute
    {
        private readonly ISession _session;
        public AdminModAttribute()
        {
            var bl = new MyBusinessLogic();
            _session = bl.getSessionBL();
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var adminSession = HttpContext.Current.GetMySessionObject();
            if (adminSession == null)
            {
                var cookie = HttpContext.Current.Request.Cookies["tsud"];
                if (cookie != null)
                {
                    var profile = _session.GetUserByCookie(cookie.Value);
                    if (profile != null && profile.Level == URole.Admin)
                    {
                        HttpContext.Current.SetMySessionObject(profile);
                    }
                    else
                    {
                        filterContext.Result = new RedirectToRouteResult(
                            new RouteValueDictionary(new { controller = "Error", action = "Error404" }));
                    }
                }
                else
                {
                    //if (adminSession.Level != URole.Admin)
                    //{
                    filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary(new { controller = "Error", action = "Error404" }));
                    //}
                }
            }
        }
    }
    public class UserModAttribute : ActionFilterAttribute
    {
        private readonly ISession _session;
        public UserModAttribute()
        {
            var bl = new MyBusinessLogic();
            _session = bl.getSessionBL();
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var adminSession = HttpContext.Current.GetMySessionObject();
            if (adminSession == null)
            {
                var cookie = HttpContext.Current.Request.Cookies["tsud"];
                if (cookie != null)
                {
                    var profile = _session.GetUserByCookie(cookie.Value);
                    if (profile != null && profile.Level == URole.Subscriber)
                    {
                        HttpContext.Current.SetMySessionObject(profile);
                    }
                    else
                    {
                        filterContext.Result = new RedirectToRouteResult(
                            new RouteValueDictionary(new { controller = "Error", action = "Error404" }));
                    }
                }
                else
                {
                    //if (adminSession.Level != URole.Subscriber)
                    //{
                    filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary(new { controller = "Error", action = "Error404" }));
                    //}
                }
            }
        }
    }
}