using log4net;
using System.Web.Mvc;

namespace CNPC.SISDUC.WEB.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(HomeController));
        public ActionResult Index()
        {
            //Log.Info("Inicio de Aplicación SISDUC - Web");
            //try
            //{
            //    throw new Exception("Error Personalizado");
            //}
            //catch (Exception ex)
            //{
            //    Log.ErrorFormat(LogMensajes.ErrorGenericoFormat, ex.Message, ex.StackTrace);
            //}
            var proxy = new ServicioClient();
            var listado = proxy.ObtenerInventario();
            Session.Add("Inventarios", listado.List);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}