using System.Web.Mvc;

namespace Bookstore_System.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}