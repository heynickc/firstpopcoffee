using System;
using FirstPopCoffee.Common.Domain.Model;

namespace FirstPopCoffee.RoastPlanning.Domain.Model {
    public class StartCreatingRoastScheduleCommand : Command {
        public readonly Guid Id;
        public StartCreatingRoastScheduleCommand(Guid id) {
            Id = id;
        }
    }
}
