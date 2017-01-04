using System.Web.Mvc;
using FirstPopCoffee.Common.Domain.Model;

namespace WebUI.Features.RoastPlanning
{
    public class RoastPlanningController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}