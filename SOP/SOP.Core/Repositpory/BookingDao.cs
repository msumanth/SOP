using SOP.Core.Data;
using SOP.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web;

namespace SOP.Core.Repositpory
{
    public class BookingDao
    {
        public void CreateBooking(BookingModel model, string constr)
        {
            int nxtid = 0;
            using (var context = new SOPEntities())
            {
                nxtid = context.Bookings.Count() + 1;
                var booking = new Booking
                {
                    Id = nxtid,
                    VehicleOwnerName = model.VehicleOwnerName,
                    VehicleOwnerDOB = DateTime.Now,
                    VehicleNumber = model.VehicleNumber,
                    VehicleLocation = model.VehicleLocation,
                    Address = model.Address,
                    Mobile = decimal.Parse(model.MobileNumber),
                    EmailId = model.EmailId,
                    DelearId = model.DealerId,
                    DateOfService = DateTime.Now,
                    ServiceType = model.ServiceTypeId,
                    DemandedRepairs = model.DemandedRepairs,
                    ManufacturingYear = Convert.ToInt32(model.ManufacturingYear),
                    City_Town = model.Cityortown,
                    VehicleModel = model.VehicleModel,
                    UserId = model.UserId,
                    CreatedBy = model.UserId,
                    CreatedDate = DateTime.Now
                };
                if (model.BookingOnbehalf)
                {
                    booking.BookingOnBehalf = true;
                    booking.SecretQuestion = model.SecretQuestionId;
                    booking.SecretAnswer = model.SecretAnswer;

                }
                context.Bookings.Add(booking);
                context.SaveChanges();
            }
        }


        public void CreateFeedback()
        {
        }

        public Booking Getbooking(int bookingId)
        {
            using (var context = new SOPEntities())
            {
                var booking = context.Bookings.Where(b => b.Id == bookingId).FirstOrDefault();
                return booking;


            }
        }
    }
}
