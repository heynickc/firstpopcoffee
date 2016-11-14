using System;
using FirstPopCoffee.Common.Domain.Model;

namespace FirstPopCoffee.RoastPlanning.Domain.Model {

    public class ChooseRoastDaysForRoastScheduleCommand : Command {
        public readonly Guid Id;
        public readonly DayOfWeek[] RoastDays;
        public readonly int OriginalVersion;
        public ChooseRoastDaysForRoastScheduleCommand(Guid id, DayOfWeek[] roastDays, int originalVersion) {
            Id = id;
            RoastDays = roastDays;
            OriginalVersion = originalVersion;
        }
    }
}