using System;
using FirstPopCoffee.Common.Domain.Model;
using FirstPopCoffee.Common.Events;

namespace FirstPopCoffee.RoastPlanning.Domain.Model {
    public class RoastScheduleCreatedEvent : Event {
        public readonly Guid RoastScheduleId;
        public RoastScheduleCreatedEvent(Guid roastScheduleId) {
            RoastScheduleId = roastScheduleId;
        }
    }
}
