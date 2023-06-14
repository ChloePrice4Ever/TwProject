using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eUseControl.Web.Models;
using eUseControl.BusinessLogic;
using eUseControl.Domain.Entities.User.Register;
using eUseControl.BusinessLogic.Interfaces;

namespace eUseControl.Web.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ISession _session;
        public RegisterController()
        {
            var bl = new MyBusinessLogic();
            _session = bl.getSessionBL();
        }
        // GET: Register
        public ActionResult Index()
        {
            return View("Register");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserRegister register)
        {
            if (ModelState.IsValid)
            {
                URegisterData data = new URegisterData
                {
                    Name = register.Name,
                    Surname = register.Surname,
                    Email = register.Email,
                    Password = register.Password
                };
                var userRegister = _session.UserRegister(data);
                if (userRegister.Status)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", userRegister.StatusMsg);
                    return View("Register");
                }
            }
            return View("Register");
        }
    }
}