using System;
using FirstPopCoffee.Common.Domain.Model;

namespace FirstPopCoffee.RoastPlanning.Domain.Model {
    public class StartCreatingRoastScheduleCommand : Command {
        public readonly Guid RoastScheduleId;
        public StartCreatingRoastScheduleCommand(Guid id, Guid roastScheduleId) : base(id) {
            RoastScheduleId = roastScheduleId;
        }
    }
}
