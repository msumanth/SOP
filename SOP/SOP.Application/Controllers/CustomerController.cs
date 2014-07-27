using SOP.Application.ActionFilters;
using SOP.Core.Data;
using SOP.Core.Models;
using SOP.Core.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SOP.Application.Controllers
{
    [CustomAuthorizeAttribute]
    public class CustomerController : BaseController
    {
        //
        // GET: /Customer/

        public ActionResult Index()
        {
            TempData["Role"] = 4;
            var bookings = new List<BookingModel>();
            var modeldata = DbRepository.DealerDao.GetAllUserBookings(AuthenticationService.UserId).OrderBy(b => b.CreatedDate).ToList();

            bookings = (from b in modeldata
                     select new BookingModel
                     {
                         BookingId = b.Id,
                         VehicleNumber = b.VehicleNumber,
                         VehicleOwnerName = b.VehicleOwnerName,
                         MobileNumber = b.Mobile.ToString(),
                         VehicleModel = b.VehicleModel,
                         ManufacturingYear = b.ManufacturingYear.ToString(),
                         DateofService = b.DateOfService,
                         UserId = b.UserId,
                         EmailId = b.EmailId
                     }).ToList();
            var feedbacks = new List<FeedbackModel>();

            var model = new CustomerModel { Bookings = bookings, Feedbacks = feedbacks };
            return View(model);
        }



        public ActionResult Booking(int bookingId = 0)
        {
            TempData["Role"] = 4;
            var model = new BookingModel();
            var dealers = DbRepository.DealerDao.GetAllDealers();
            dealers.Add(new Dealer { Id = 0, Name = "Select Dealer" });
            var sts = DbRepository.DealerDao.GetAllServiceTypes();
            var sqs = DbRepository.UserDao.GetAllSecretQuestions();
            var dlist = dealers.Select(d => new SelectListItem() { Text = d.Name, Value = d.Id.ToString() });
            var sss = sts.Select(s => new SelectListItem() { Text = s.ServiceType1, Value = s.Id.ToString() });
            Booking bokreq;
            if (bookingId != 0)
            {
                bokreq = DbRepository.BookingDao.Getbooking(bookingId);

                model.VehicleOwnerName = bokreq.VehicleOwnerName;
                model.Address = bokreq.Address;
                model.MobileNumber = bokreq.Mobile.ToString();
                model.EmailId = bokreq.EmailId;
                model.VehicleNumber = bokreq.VehicleNumber;
                model.VehicleModel = bokreq.VehicleModel;
               
            }

           


            model.SecretQuestions = sqs;
            model.Dealers = dlist;
            model.ServiceTypes = sss;
            model.UserId = AuthenticationService.UserId;
            return View(model);
        }

        [HttpPost]
        public ActionResult Booking(BookingModel model)
        {
            TempData["Role"] = 4;
            string constr = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            DbRepository.BookingDao.CreateBooking(model, constr);
            return RedirectToAction("Index");
        }


        public ActionResult Feedback(int bookingId = 0)
        {
            TempData["Role"] = 4;
            var model = new FeedbackModel();
            var dealers = DbRepository.DealerDao.GetAllDealers();
            dealers.Add(new Dealer { Id = 0, Name = "Select Dealer" });
            var dlist = dealers.Select(d => new SelectListItem() { Text = d.Name, Value = d.Id.ToString() });
            model.Dealers = dlist;
            model.UserId = AuthenticationService.UserId;
            return View(model);
        }

        [HttpPost]
        public ActionResult Feedback(FeedbackModel model)
        {
            TempData["Role"] = 4;
            string constr = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            return RedirectToAction("Index");
        }


        public JsonResult ServiceDetails(int dealerId)
        {
            var res = DbRepository.DealerDao.GetDealer(dealerId);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}
