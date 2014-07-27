using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SOP.Core.Models
{
    public class FeedbackModel
    {
        public int FeedbackId { get; set; }
        public int UserId { get; set; }
        public string VehicleOwnerName { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public string EmailId { get; set; }
        public string VehicleNumber { get; set; }
        public string VehicleLocation { get; set; }
        public IEnumerable<SelectListItem> Dealers { get; set; }
        public string DealerName { get; set; }
        public int DealerId { get; set; }
        public string ServiceCenterPhone { get; set; }
        public string ServiceCenterEmail { get; set; }
        public string VehicleModel { get; set; }
        public string Feedback { get; set; }
    }
}
