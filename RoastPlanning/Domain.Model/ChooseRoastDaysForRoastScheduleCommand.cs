using System;
using Common.Domain.Model;

namespace RoastPlanning.Domain.Model {

    public class ChooseRoastDaysForRoastSchedule : Command {
        public readonly Guid Id;
        public readonly DayOfWeek[] RoastDays;
        public readonly int OriginalVersion;
        public ChooseRoastDaysForRoastSchedule(Guid id, DayOfWeek[] roastDays, int originalVersion) {
            Id = id;
            RoastDays = roastDays;
            OriginalVersion = originalVersion;
        }
    }
}