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

    public class FakeRoastPlanningReadModel : DbContext, IRoastPlanningReadModel
    {
        private readonly FakeDbSet<RoastScheduleViewModel> _roastSchedules;

        //public FakeRoastPlanningReadModel() : base("RoastScheduleDb")
        //{
        //    _roastSchedules = base.Set<RoastSchedules>();
        //}

        public FakeRoastPlanningReadModel(FakeDbSet<RoastScheduleViewModel> roastSchedules) 
        {
            _roastSchedules = roastSchedules;
        }
        public IQueryable<RoastScheduleViewModel> RoastSchedules => this._roastSchedules;
    }
}