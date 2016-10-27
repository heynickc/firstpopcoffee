using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.Model;

namespace RoastPlanning.Domain.Model {
    public class RoastScheduleCreatedEvent : Event {
        public readonly Guid Id;
        public RoastScheduleCreatedEvent(Guid id) {
            Id = id;
        }
    }
}
