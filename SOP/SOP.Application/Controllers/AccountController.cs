using SOP.Application.ActionFilters;
using SOP.Application.Models;
using SOP.Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SOP.Application.Controllers
{
    public class AccountController : Controller
    {
        // GET: /Account/
        public ActionResult Login()
        {
            var model = new LoginModel();
            return View(model);
        }

        [HttpPost]
        [ClearCache]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model)
        {
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            var model = new RegisterModel();
            return View(model);
        }

        [HttpPost]
        [ClearCache]
        [AllowAnonymous]
        public ActionResult Register(RegisterModel model)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
