using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.Model;

namespace RoastPlanning.Domain.Model {
    public class RoastSchedule : AggregateRoot {
        public RoastSchedule(Guid id) {
            Id = id;
        }
        public RoastSchedule() {
            // used to create in repository ... many ways to avoid this, eg making private constructor
        }
    }
}
