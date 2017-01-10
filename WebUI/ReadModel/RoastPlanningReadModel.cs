using System.Data.Entity;
using System.Linq;
using FirstPopCoffee.RoastPlanning.Domain.Model;
using WebUI.Infrastructure;

namespace WebUI.ReadModel
{
    public interface IRoastPlanningReadModel
    {
        IQueryable<RoastSchedule> RoastSchedules { get; }
    }
    public class FakeRoastPlanningReadModel : IRoastPlanningReadModel
    {
        private readonly DbSet<RoastSchedule> _roastSchedules;
        public FakeRoastPlanningReadModel(FakeDbSet<RoastSchedule> roastSchedules)
        {
            _roastSchedules = roastSchedules;
        }
        public IQueryable<RoastSchedule> RoastSchedules => this._roastSchedules;
    }

    public interface IRoastPlanningContext
    {
        DbSet<RoastSchedule> RoastSchedules { get; }
        int SaveChanges();
    }
    public class RoastPlanningContext : IRoastPlanningContext
    {
        public DbSet<RoastSchedule> RoastSchedules { get; set; }

        public RoastPlanningContext()
        {
            this.RoastSchedules = new FakeDbSet<RoastSchedule>();
        }

        public int SaveChangesCount { get; private set; }
        public int SaveChanges()
        {
            this.SaveChangesCount++;
            return 1;
        }
    }
}