using SOP.Core.Data;
using SOP.Core.Models;
using SOP.Core.Repositpory;
using SOP.Core.Util;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace SOP.Core.Services
{
    public class AuthenticationService
    {
        public static bool IsAuthenticated
        {
            get
            {
                return HttpContext.Current.User.Identity.IsAuthenticated;
            }
        }

        public static int UserId
        {
            get
            {
                if (HttpContext.Current.User.Identity != null && IsAuthenticated)
                    return Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                return 0;
            }
        }

        public static bool Authenticate(string username, string password, bool isPersistantCookie, ref int userId)
        {
            var userdao = new UserDao();

            var expirytime = DateTime.Now.AddMinutes(30);

            if (isPersistantCookie)
                expirytime = DateTime.Now.AddYears(1);

            if (!userdao.CheckCredentials(username, SymmetricEncryption.EncryptString(password), ref userId))
                return false;

            var authTicket = new FormsAuthenticationTicket(1, userId.ToString(CultureInfo.InvariantCulture), DateTime.Now, expirytime, true, "");

            string cookieContents = FormsAuthentication.Encrypt(authTicket);

            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieContents)
            {
                Expires = authTicket.Expiration,
                Path = FormsAuthentication.FormsCookiePath
            };

            if (HttpContext.Current != null)
            {
                HttpContext.Current.Response.Cookies.Add(cookie);
                CreateCustomPrincipal();
            }

            return true;
        }



        public static void CreateCustomPrincipal()
        {
            HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                var identity = new GenericIdentity(authTicket.Name, "Forms");
                var principal = new CustomPrincipal(identity);
                HttpContext.Current.User = principal;
            }
        }
    }
}
