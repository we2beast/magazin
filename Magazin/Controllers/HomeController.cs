using System.Web.Mvc;

namespace Magazin.Controllers
{
    [Authorize(Roles = "Customer")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    
    }
}