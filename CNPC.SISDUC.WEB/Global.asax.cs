using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using log4net;
using CNPC.SISDUC.WEB.Recursos;

namespace CNPC.SISDUC.WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(MvcApplication));

        void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            log4net.Config.XmlConfigurator.Configure();
            Log.Info("Inicio de Aplicación SISDUC - Web");
        }

        [HandleError]
        protected void Application_Error(object sender, EventArgs e)
        {
            var ex = Server.GetLastError();
            Log.FatalFormat(LogMensajes.ErrorGenericoFormat, ex.Message, ex.StackTrace);
            Server.ClearError();
        }
    }
}
