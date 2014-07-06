using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOP.Application.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public string VehicleNumber { get; set; }
        public string CustomerName { get; set; }
        public string CustomerMobileNumber { get; set; }
        public string VehicleModel { get; set; }
        public string RequestId { get; set; }
        public string Servicetyperequested { get; set; }
        public string Servicedaterequested { get; set; }
        public int Yearofmanufacture { get; set; }
        public int CustomerId { get; set; }
        public string CustomerEmailId { get; set; } 
    }
}