using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eUseControl.BusinessLogic;
using eUseControl.Web.Extensions;
using eUseControl.BusinessLogic.Interfaces;

namespace eUseControl.Web.Controllers
{
    public class BaseController : Controller
    {
        private readonly ISession _session;
        // GET: Base
        public BaseController()
        {
            var bl = new MyBusinessLogic();
            _session = bl.getSessionBL();
        }
        public void SessionStatus()
        {
            var apiCookie = Request.Cookies["tsud"];
            if (apiCookie != null)
            {
                var uProfile = _session.GetUserByCookie(apiCookie.Value);
                if (uProfile != null)
                {
                    System.Web.HttpContext.Current.SetMySessionObject(uProfile);
                    System.Web.HttpContext.Current.Session["LoginStatus"] = "login";
                }
                else
                {
                    System.Web.HttpContext.Current.Session.Clear();
                    if (ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("tsud"))
                    {
                        var cookie = ControllerContext.HttpContext.Request.Cookies["tsud"];
                        if (cookie != null)
                        {
                            cookie.Expires = DateTime.Now.AddDays(-1);
                            ControllerContext.HttpContext.Response.Cookies.Add(cookie);
                        }
                    }
                    System.Web.HttpContext.Current.Session["LoginStatus"] = "logout";
                }
            }
            else
            {
                System.Web.HttpContext.Current.Session["LoginStatus"] = "logout";
            }
        }
    }
}