using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ProjetoBase.Helpers;

namespace ProjetoBase
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        
        /// <summary>
        /// Durante o evento de fim de http request, o context do entity é jogado fora.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_PostRequestHandlerExecute(object sender, EventArgs e)
        {
            SessionHelper.destroyProjetoBaseContext();
        }

    }
}
