using System.Web.Mvc;

namespace Magazin.Areas.Manager.Controllers
{
    [Authorize(Roles = "Manager")]
    public class DashboardController : Controller
    {
        // GET: Manager/Dashboard
        public ActionResult Index()
        {
            return View();
        }

    }
}