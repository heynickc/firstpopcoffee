using System;
using FirstPopCoffee.Common.Domain.Model;

namespace FirstPopCoffee.RoastPlanning.Domain.Model {
    public class CreateNewRoastScheduleCommand : Command {
        public readonly Guid RoastScheduleId;
        public CreateNewRoastScheduleCommand(Guid roastScheduleId) {
            RoastScheduleId = roastScheduleId;
        }
    }
}
