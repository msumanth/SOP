using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SOP.Application.ActionFilters
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private string _returnURL;

        private string _loginURL = FormsAuthentication.LoginUrl;

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var authorized = base.AuthorizeCore(httpContext);
            if (!authorized)
            {
                _returnURL = httpContext.Request.RawUrl;
                if (httpContext.Request.RequestType == "POST")
                {
                    _returnURL = httpContext.Request.UrlReferrer.PathAndQuery;

                }

            }
            return authorized;

        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext context)
        {
            if (context.HttpContext.Request.IsAjaxRequest())
            {
                var urlHelper = new UrlHelper(context.RequestContext);
                context.HttpContext.Response.StatusCode = 403;
                context.Result = new JsonResult
                {
                    Data = new
                    {
                        Error = "NotAuthorized",
                        LogOnUrl = urlHelper.Action("Login", "Account")
                    },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            else
            {
                base.HandleUnauthorizedRequest(context);
                context.Result = new RedirectResult(String.Concat(_loginURL, "?ReturnUrl=", HttpUtility.UrlEncode(_returnURL)));
            }
        }
    }
}