using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.Model;

namespace RoastPlanning.Domain.Model {
    public class StartCreatingRoastScheduleCommand : Command {
        public readonly Guid Id;
        public StartCreatingRoastScheduleCommand(Guid id) {
            Id = id;
        }
    }
}
