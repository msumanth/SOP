using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SOP.Application.Controllers
{
    public class BaseController : Controller
    {

        /// <summary>
        /// Write Exception to Log files
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnException(ExceptionContext filterContext)
        {
            //Exceptions.LogException(filterContext);
            Response.Redirect("~/Home/Error");
        }

        /// <summary>
        /// Check The Request is Ajax or Not
        /// </summary>
        public bool IsAjaxRequest
        {
            get
            {
                if (Request == null)
                    // ReSharper disable NotResolvedInText
                    throw new ArgumentNullException(paramName: "request");
                // ReSharper restore NotResolvedInText
                return (Request["X-Requested-With"] == "XMLHttpRequest") || ((Request.Headers != null) && (Request.Headers["X-Requested-With"] == "XMLHttpRequest"));
            }
        }

    }
}
