using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SOP.Core.Common
{
    public static class Exceptions
    {
        /// <summary>
        /// To Trace with in the code exceptions
        /// </summary>
        /// <param name="filterContext"></param>
        public static void LogException(ExceptionContext filterContext)
        {
            var stacktrace = filterContext.Exception.StackTrace.ToString(CultureInfo.InvariantCulture);
            var log = new Logger();
            //var controllerName = (string)filterContext.RouteData.Values["controller"];
            //var actionName = (string)filterContext.RouteData.Values["action"];
            var msg = filterContext.Exception.Message;
            var IP = filterContext.HttpContext.Request.UserHostAddress;
            var RequestType = filterContext.HttpContext.Request.HttpMethod;
            var Browser = (filterContext.HttpContext.Request.Browser).Browser;
            var OS = filterContext.HttpContext.Request.Browser.Platform;
            if (((filterContext.HttpContext.Request).Browser).Win32)
                OS += "[Win32]";
            else if (((filterContext.HttpContext.Request).Browser).Win16)
                OS += "[Win16]";
            var browVersion = filterContext.HttpContext.Request.Browser.Version;
            //var BrowType = filterContext.HttpContext.Request.Browser.Type;
            //var QueryString = (filterContext.HttpContext.Request).Url.Query;
            var OriginalURL = (filterContext.HttpContext.Request).Url.OriginalString;
            // var FormsAuthunticatedToken = (filterContext.HttpContext.Request).Cookies[".ASPXFORMSAUTH"].Value;

            var userName = "Anonymous User";
            //if (CurrentUser.IsAuthenticated)
            //    userName = CurrentUser.UserName;

            var emsg = OriginalURL + " - " + RequestType + " - " + userName + " - " + OS + " " + Browser + "(" + browVersion + ")" + " - " + IP + " -  " + msg + "\r\n" + stacktrace;
            log.WriteException(emsg);

            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = 500;
            //filterContext.ExceptionHandled = true;
        }


    }
}
