using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOP.Core.Models
{
    public class CustomerModel
    {
        public List<BookingModel> Bookings { get; set; }
        public List<FeedbackModel> Feedbacks { get; set; }
    }
}
