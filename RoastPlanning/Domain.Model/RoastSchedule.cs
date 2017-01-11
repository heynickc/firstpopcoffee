using System;
using System.Collections.Generic;
using System.Linq;
using FirstPopCoffee.Common.Domain.Model;

namespace FirstPopCoffee.RoastPlanning.Domain.Model {
    public class RoastSchedule : EventSourcedAggregateRoot {

        public DateTime RoastWeekStartsOn { get; private set; }
        public RoastDays RoastDays { get; private set; }

        public void Apply(RoastScheduleCreatedEvent e)
        {
            RoastWeekStartsOn = e.RoastWeekStartsOn;
            Id = e.RoastScheduleId;
        }

        public void Apply(RoastScheduleRoastDaysChosenEvent e) {
            RoastDays = new RoastDays(e.Days);
        }

        public RoastSchedule(Guid id, DateTime roastWeekStartsOn) {
            RoastDays = new RoastDays(new HashSet<RoastDay>());
            ApplyChange(new RoastScheduleCreatedEvent(id, roastWeekStartsOn));
        }

        public void SetRoastDays(RoastDays roastDays) {
            if (roastDays.Days.Count == 0) throw new ArgumentException("roastDays count must be greater than 0");
            var newDays = roastDays.Days.Select(x => x.Day).ToArray();
            ApplyChange(new RoastScheduleRoastDaysChosenEvent(Id, newDays));
        } 

        public RoastSchedule() {
            // used to create in repository ... many ways to avoid this, eg making private constructor
        }
    }
}
