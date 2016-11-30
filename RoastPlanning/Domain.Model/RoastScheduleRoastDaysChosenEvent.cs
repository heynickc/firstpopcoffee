using System;
using FirstPopCoffee.Common.Domain.Model;
using FirstPopCoffee.Common.Events;

namespace FirstPopCoffee.RoastPlanning.Domain.Model {
    public class RoastScheduleRoastDaysChosenEvent : Event {
        public Guid RoastScheduleId { get; private set; }
        public DayOfWeek[] Days { get; private set; }
        public RoastScheduleRoastDaysChosenEvent(Guid roastScheduleId, DayOfWeek[] days) {
            RoastScheduleId = roastScheduleId;
            Days = days;
        }
    }
}
