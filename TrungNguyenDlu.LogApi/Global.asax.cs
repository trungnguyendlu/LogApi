using System.Web.Http;
using System.Web.Mvc;
using TrungNguyenDlu.LogApi.Infrastructure.Log;

namespace TrungNguyenDlu.LogApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.MessageHandlers.Add(new ApiRequestLogHandler());
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            log4net.Config.XmlConfigurator.Configure();
        }
    }
}
