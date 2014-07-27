using SOP.Application.ActionFilters;
using SOP.Core.Models;
using SOP.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SOP.Application.Controllers
{
    [CustomAuthorizeAttribute]
    public class DealerController : BaseController
    {
        //
        // GET: /Dealer/

        public ActionResult Index()
        {
            TempData["Role"] = 3;
            return View();
        }

        public ActionResult DealerDetails(int dealerId = 0)
        {
            TempData["Role"] = 3;
            DealerModel model;

            model = (dealerId == 0)
                ? new DealerModel()
                : DbRepository.DealerDao.GetDealerDetails(dealerId);

            model.UserId = AuthenticationService.UserId;
            return View(model);
        }

        [HttpPost]
        public ActionResult DealerDetails(DealerModel model)
        {
            var dealer = DbRepository.DealerDao.CreateNewDealer(model);
            return RedirectToAction("Index");
        }
    }
}
