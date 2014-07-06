using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOP.Application.Models
{
    public class SubAdminModel
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public decimal PhoneNumber { get; set; }
    }
}