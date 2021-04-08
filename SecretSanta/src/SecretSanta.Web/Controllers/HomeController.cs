using Microsoft.AspNetCore.Mvc;

namespace UserGroup.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Page()
        {
            return View();
        }
    }
}