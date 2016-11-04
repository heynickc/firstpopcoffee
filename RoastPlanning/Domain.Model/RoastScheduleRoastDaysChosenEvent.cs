using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.Model;

namespace RoastPlanning.Domain.Model {
    public class RoastScheduleRoastDaysChosenEvent : Event {
        public Guid RoastScheduleId { get; private set; }
        public DayOfWeek[] Days { get; private set; }
        public RoastScheduleRoastDaysChosenEvent(Guid roastScheduleId, DayOfWeek[] days) {
            RoastScheduleId = roastScheduleId;
            Days = days;
        }
    }
}
