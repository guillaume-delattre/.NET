using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Configuration;
using System.Web.Http;
using WebApp.Models;
using WebApp.Infrastructure;

namespace WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            App_Start.WebAppConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Application intialisation
            Application["infoApp"] = ConfigurationManager.AppSettings["infoApp"];

            // intialisation application - case 2
            ApplicationModel data = new ApplicationModel();
            data.InfoApp = ConfigurationManager.AppSettings["infoApp"];
            Application["data"] = data;

            // Models binders
            ModelBinders.Binders.Add(typeof(ApplicationModel), new ApplicationModelBinder());
            ModelBinders.Binders.Add(typeof(SessionModel), new SessionModelBinder());

        }

        protected void Session_Start()
        {
            // initialisation compteur
            Session["counter"] = 0;

            Session["data"] = new SessionModel();
        }
    }
}
