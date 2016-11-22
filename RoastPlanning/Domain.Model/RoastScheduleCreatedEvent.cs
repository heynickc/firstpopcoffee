using System;
using FirstPopCoffee.Common.Domain.Model;

namespace FirstPopCoffee.RoastPlanning.Domain.Model {
    public class RoastScheduleCreatedEvent : Event {
        public readonly Guid RoastScheduleId;
        public RoastScheduleCreatedEvent(Guid roastScheduleId) {

            RoastScheduleId = roastScheduleId;
        }
    }
}
