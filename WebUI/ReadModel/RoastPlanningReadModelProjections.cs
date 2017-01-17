using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FirstPopCoffee.Common.Domain.Model;
using FirstPopCoffee.RoastPlanning.Domain.Model;
using WebUI.Models;

namespace WebUI.ReadModel
{
    public class RoastScheduleView : IEventHandler<RoastScheduleCreatedEvent>
    {
        private readonly IRoastPlanningContext _roastPlanningContext;

        public RoastScheduleView(IRoastPlanningContext roastPlanningContext)
        {
            _roastPlanningContext = roastPlanningContext;
        }
        public void Handle(RoastScheduleCreatedEvent message)
        {
            var newRoastSchedule = new RoastScheduleViewModel(message.RoastScheduleId, message.RoastWeekStartsOn);
            _roastPlanningContext.RoastSchedules.Add(newRoastSchedule);
            _roastPlanningContext.SaveChanges();
        }
    }
}