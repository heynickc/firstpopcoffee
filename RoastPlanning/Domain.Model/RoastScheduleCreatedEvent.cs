using System;
using FirstPopCoffee.Common.Domain.Model;
using FirstPopCoffee.Common.Events;

namespace FirstPopCoffee.RoastPlanning.Domain.Model {
    public class RoastScheduleCreatedEvent : Event {
        public readonly Guid RoastScheduleId;
        public readonly DateTime RoastWeekStartsOn;
        public RoastScheduleCreatedEvent(Guid roastScheduleId,DateTime roastWeekStartsOn) {
            RoastScheduleId = roastScheduleId;
            RoastWeekStartsOn = roastWeekStartsOn;
        }
    }
}
