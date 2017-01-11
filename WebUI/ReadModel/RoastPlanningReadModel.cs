using System.Data.Entity;
using System.Linq;
using FirstPopCoffee.RoastPlanning.Domain.Model;
using WebUI.Infrastructure;
using WebUI.Models;

namespace WebUI.ReadModel
{
    public interface IRoastPlanningReadModel
    {
        IQueryable<RoastScheduleViewModel> RoastSchedules { get; }
    }

    public class FakeRoastPlanningReadModel : IRoastPlanningReadModel
    {
        private readonly DbSet<RoastScheduleViewModel> _roastSchedules;
        public FakeRoastPlanningReadModel(FakeDbSet<RoastScheduleViewModel> roastSchedules)
        {
            _roastSchedules = roastSchedules;
        }
        public IQueryable<RoastScheduleViewModel> RoastSchedules => this._roastSchedules;
    }
}