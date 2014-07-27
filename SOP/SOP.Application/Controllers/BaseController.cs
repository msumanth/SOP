using SOP.Core.Data;
using SOP.Core.Repositpory;
using SOP.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SOP.Application.Controllers
{
    public class BaseController : Controller
    {
        private SopUser _currentUser;
        private DbRepository _dbrepository;

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

        public DbRepository DbRepository
        {
            get
            {
                if (_dbrepository == null)
                    _dbrepository = new DbRepository();
                return _dbrepository;
            }
        }

        public SopUser CurrentUser
        {
            get
            {
                if (_currentUser == null && AuthenticationService.UserId != 0)
                {
                    _currentUser = DbRepository.UserDao.GetUser(AuthenticationService.UserId);
                }

                return _currentUser;
            }
        }

        /// <summary>
        /// Write Exception to Log files
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnException(ExceptionContext filterContext)
        {
            //Exceptions.LogException(filterContext);
            Response.Redirect("~/Home/Error");
        }



    }
}
