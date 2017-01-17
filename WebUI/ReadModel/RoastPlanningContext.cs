using System.Data.Entity;
using FirstPopCoffee.RoastPlanning.Domain.Model;
using WebUI.Infrastructure;
using WebUI.Models;

namespace WebUI.ReadModel
{
    public interface IRoastPlanningContext
    {
        DbSet<RoastScheduleViewModel> RoastSchedules { get; }
        int SaveChanges();
    }

    public class RoastPlanningContext : IRoastPlanningContext
    {
        public DbSet<RoastScheduleViewModel> RoastSchedules { get; set; }

        public RoastPlanningContext(FakeDbSet<RoastScheduleViewModel> roastSchedules)
        {
            this.RoastSchedules = roastSchedules;
        }

        public int SaveChangesCount { get; private set; }
        public int SaveChanges()
        {
            this.SaveChangesCount++;
            return 1;
        }
    }
}