using System;
using System.Linq;
using System.Web.Mvc;
using FirstPopCoffee.Common.Domain.Model;
using FirstPopCoffee.RoastPlanning.Domain.Model;
using WebUI.ReadModel;

namespace WebUI.Features.RoastPlanning
{
    public class RoastPlanningController : Controller
    {
        private readonly FakeBus _bus;
        private readonly IRoastPlanningReadModel _readModel;

        public RoastPlanningController(FakeBus bus, IRoastPlanningReadModel readModel)
        {
            _bus = bus;
            _readModel = readModel;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            var viewModel = _readModel.RoastSchedules.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(string create)
        {
            _bus.Send(new CreateNewRoastScheduleCommand(Guid.NewGuid()));
            return this.RedirectToAction(nameof(Index));
        }
    }
}