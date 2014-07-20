using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace SOP.Core.Util
{
    public class AuthUtil
    {
        /// <summary>
        /// Create A AUthentication Token
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public static HttpCookie CreateAuthToken(int UserId, bool isPersistantCookie = false)
        {
            var expirytime = DateTime.Now.AddMinutes(60);

            if (isPersistantCookie)
                expirytime = DateTime.Now.AddYears(1);

            FormsAuthentication.Initialize();
            var ticket = new FormsAuthenticationTicket(1, UserId.ToString(CultureInfo.InvariantCulture), DateTime.Now, expirytime, isPersistantCookie, "");


            var authenticationCookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket))
            {
                Expires = ticket.Expiration,
                Secure = false
            };
            return authenticationCookie;

        }
    }
}
