using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOP.Core.Models
{
    public class DealerModel
    {
        public int UserId { get; set; }
        public int DealerId { get; set; }
        public string DealerName { get; set; }
        public string DealerLocation { get; set; }
        public string Address { get; set; }
        public string PrimaryContactPerson { get; set; }
        public string PrimaryContactNumber { get; set; }
        public string SecondaryContactPerson { get; set; }
        public string SecondaryContactNumber { get; set; }
        public int WorkshopId { get; set; }
        public string WorkShopNumber { get; set; }
        public string WorkshopCoordinates { get; set; }
        public string WorkShopGeneralManager { get; set; }
        public string WorkShopGeneralManagerNumber { get; set; }

       
    }

    public class ServiceCenterModel
    {
        public string MobileNumber { get; set; }
        public string EmailId { get; set; }
        public string MapLt { get; set; }
        public string MapLg { get; set; }
    }
}
