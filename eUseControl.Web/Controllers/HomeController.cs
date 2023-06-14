using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eUseControl.Web.Models;
using eUseControl.Web.Extensions;
using eUseControl.Domain.Enums;
using eUseControl.Web.App_Start;

namespace eUseControl.Web.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            SessionStatus();
            if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] == "login")
            {
                var user = System.Web.HttpContext.Current.GetMySessionObject();
                UserProfile up = new UserProfile
                {
                    Id = user.Id,
                    Name = user.Name,
                    Surname = user.Surname,
                    Email = user.Email,
                    ProfileUrl = user.Level == URole.Admin ? "/Admin" : "/profile"
                };
                return View(up);
            }
            else
            {
                return View();
            }
        }

        [UserMod]
        public ActionResult UserProfile()
        {
            return View("Profile");
        }
        public ActionResult Logout()
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
            return View();
        }
    }
}