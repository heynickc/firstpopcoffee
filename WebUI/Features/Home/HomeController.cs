using System.Web.Mvc;

namespace WebUI.Features.Home {
    public class HomeController : Controller {
        //private readonly FakeBus _bus;

        //public HomeController(FakeBus bus) {
        //    _bus = bus;
        //}

        public ActionResult Index() {
            return View();
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}