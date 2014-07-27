using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SOP.Core.Models
{
    public class BookingModel
    {
        public int UserId { get; set; }
        public int BookingId { get; set; }
        public string VehicleOwnerName { get; set; }
        public string VehicleNumber { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public string EmailId { get; set; }
        public string VehicleModel { get; set; }
        public string ManufacturingYear { get; set; }
        public string VehicleLocation { get; set; }
        public IEnumerable<SelectListItem> Dealers { get; set; }
        public int DealerId { get; set; }
        public string DealerNumber { get; set; }
        public string DealerEmail { get; set; }
        public IEnumerable<SelectListItem> ServiceTypes { get; set; }
        public int ServiceTypeId { get; set; }
        public DateTime DateofService { get; set; }
        public string DemandedRepairs { get; set; }
        public DateTime VehicleownerDOB { get; set; }
        public bool BookingOnbehalf { get; set; }
        public bool BookingByownder { get; set; }
        public IEnumerable<SelectListItem> SecretQuestions { get; set; }
        public int SecretQuestionId { get; set; }
        public string SecretAnswer { get; set; }
        public string Cityortown { get; set; }
        public string WorkshopCoordinates { get; set; }

    }
}
