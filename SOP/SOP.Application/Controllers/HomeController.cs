using SOP.Application.Models;
using SOP.Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SOP.Application.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var sx = SymmetricEncryption.EncryptString("Welcome1!");
            return View();
        }

        public ActionResult SubAdminCreation()
        {
            var model = new List<SubAdminModel>();
            for (int i = 0; i < 5; i++)
            {
                model.Add(new SubAdminModel
                {
                    Name = "Sub Admin 1",
                    PhoneNumber = 7795553335 + i,
                    EmailId = "subadmin" + (i + 1) + "@serviceit.in",
                    UserId = "subadmin" + (i + 1) + "@serviceit.in",
                    Password = "TEst" + i
                });
            }
            return View(model);
        }


        public ActionResult DealerCreation()
        {
            return View();
        }

        public ActionResult CouponCreation()
        {
            return View();
        }

        public ActionResult Booking()
        {
            return View();
        }

        public ActionResult BookingHistory()
        {
            var model = new List<Booking>();
            for (int i = 0; i < 5; i++)
            {
                model.Add(new Booking
                {
                    BookingId = i + 1,
                    VehicleNumber = "BG-DF" + i,
                    CustomerName = "Customer " + i,
                    CustomerMobileNumber = (874 + i).ToString(),
                    CustomerEmailId = "customer" + i + "@somemail.com",
                    CustomerId = i + 1,
                    RequestId = (i + 1).ToString(),
                    Servicedaterequested = DateTime.Now.ToString(),
                    Servicetyperequested = "Type" + i,
                    VehicleModel = "Model" + i,
                    Yearofmanufacture = 1998 + i,
                });
            }
            return View(model);
        }
    }
}
