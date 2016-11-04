using System;
using Common.Domain.Model;

namespace RoastPlanning.Domain.Model {

    public class ChooseRoastDaysForRoastSchedule : Command {
        public readonly Guid Id;
        public readonly DayOfWeek[] RoastDays;
        public ChooseRoastDaysForRoastSchedule(Guid id, DayOfWeek[] roastDays) {
            Id = id;
            RoastDays = roastDays;
        }
    }
}