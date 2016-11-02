using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.Model;

namespace RoastPlanning.Domain.Model {
    public class RoastSchedule : AggregateRoot {

        // public Guid Id { get; protected set; }
        // defined in AggregateRoot base class
        // could also be defined as abstract and overridden here

        public void Apply(RoastScheduleCreatedEvent e) {
            Id = e.Id;
        }

        public RoastSchedule(Guid id) {
            ApplyChange(new RoastScheduleCreatedEvent(id));
        }

        public RoastSchedule() {
            // used to create in repository ... many ways to avoid this, eg making private constructor
        }
    }
}
