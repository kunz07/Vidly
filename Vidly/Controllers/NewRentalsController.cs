using System.Web.Mvc;

namespace Vidly.Controllers
{
    [AllowAnonymous]
    public class NewRentalsController : Controller
    {
        public ActionResult New()
        {
            return View();
        }
    }
}