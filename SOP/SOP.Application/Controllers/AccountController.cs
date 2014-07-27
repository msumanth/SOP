using SOP.Application.ActionFilters;
using SOP.Application.Models;
using SOP.Core.Data;
using SOP.Core.Repositpory;
using SOP.Core.Services;
using SOP.Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SOP.Application.Controllers
{
    public class AccountController : Controller
    {
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            int userId = 0;
            var isauthenticated = AuthenticationService.Authenticate(model.UserName, model.Password, model.RememberMe, ref userId);
            if (isauthenticated)
            {
                var userdao = new UserDao();
                var role = userdao.GetUserRole(userId);
                if (role == 1)
                    return RedirectToAction("Index", "Admin");
                else if (role == 2)
                    return RedirectToAction("Index", "SubAdmin");
                else if (role == 3)
                    return RedirectToAction("Index", "Dealer");
                else
                    return RedirectToAction("Index", "Customer");
            }
            else
            {
                return RedirectToAction("Index", "Home", new { msg = "Authentication failed!!!" });
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [ClearCache]
        [AllowAnonymous]
        public ActionResult Register()
        {
            var userdao = new UserDao();
            var model = new RegisterModel();
            model.SecretQuestions = userdao.GetAllSecretQuestions();
            model.Roles = userdao.GetAllUserRoles(false);
            var gndrs = new List<SelectListItem>
            {
              new SelectListItem{ Text = "Unknown", Value = "0" },
              new SelectListItem{ Text = "Male", Value = "1" },
              new SelectListItem{ Text = "Female", Value = "2" } 
            };
            model.Genders = gndrs;
            return View(model);
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            var sopuser = new SopUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                Password = SymmetricEncryption.EncryptString(model.Password),
                RoleId = model.Role,
                EmailId = model.EmailId,
                Mobile = model.Mobile,
                DOB = model.DOB,
                Gender=model.Gender,
                SecretQuestionId = model.SecretQuestionId,
                SecretAnswer = model.SecretAnswer,
            };
            var userId = 0;
            var userdao = new UserDao();
            var user = userdao.SaveNewUser(sopuser);
            var isauthenticated = AuthenticationService.Authenticate(user.UserName,SymmetricEncryption.DecryptString(user.Password), false, ref userId);
            var role = user.RoleId;
            if (role == 1)
                return RedirectToAction("Index", "Admin");
            else if (role == 2)
                return RedirectToAction("Index", "SubAdmin");
            else if (role == 3)
                return RedirectToAction("NewDealer", "Dealer");
            else
                return RedirectToAction("Index", "Customer");
        }
    }
}
