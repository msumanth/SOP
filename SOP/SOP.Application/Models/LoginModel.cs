using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SOP.Application.Models
{
    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string Errormsg { get; set; }
    }

    public class RegisterModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public IEnumerable<SelectListItem> Genders { get; set; }
        public int Gender { get; set; }
        public string EmailId { get; set; }
        public decimal Mobile { get; set; }
        public IEnumerable<SelectListItem> SecretQuestions { get; set; }
        public int SecretQuestionId { get; set; }
        public string SecretAnswer { get; set; }
        public IEnumerable<SelectListItem> Roles { get; set; }
        public int Role { get; set; }
    }
}