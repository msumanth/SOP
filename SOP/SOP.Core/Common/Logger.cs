using log4net;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;

namespace SOP.Core.Common
{
    public class Logger
    {
        public Logger()
        {
            var filename = DateTime.Today.ToString("dd-MMM-yyyy");
            var path = Path.Combine(HttpContext.Current.Request.MapPath("~"), "LogFiles\\" + filename + ".log");
            GlobalContext.Properties["LogFile"] = path;
            var logconfigpath = Path.Combine(HttpContext.Current.Request.MapPath("~"), WebConfigurationManager.AppSettings["Log4netConfig"]);
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(logconfigpath));
            _logger = LogManager.GetLogger(typeof(Logger).FullName.ToString(CultureInfo.InvariantCulture));
        }


        private static ILog _logger;



        public void WriteException(string emsg)
        {
            _logger.Error(emsg);
        }

        public void WriteInfo(string msg)
        {
            _logger.Info(msg);
        }
    }
}
