using SOP.Application.ActionFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SOP.Application.Controllers
{
    [CustomAuthorizeAttribute]
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            TempData["Role"] = 1;
            return View();
        }

        public ActionResult DealerCreation()
        {
            TempData["Role"] = 1;
            return View();
        }

    }
}
