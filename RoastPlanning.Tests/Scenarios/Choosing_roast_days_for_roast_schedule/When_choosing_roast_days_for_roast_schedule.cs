using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.Model;
using FluentAssertions;
using RoastPlanning.Application;
using RoastPlanning.Domain.Model;

namespace RoastPlanning.Tests.Scenarios.Choosing_roast_days_for_roast_schedule {
    public class When_choosing_roast_days_for_roast_schedule : Specification<RoastSchedule, ChooseRoastDaysForRoastSchedule> {

        private readonly Guid Id = Guid.NewGuid();

        protected override IEnumerable<Event> Given() {
            yield return PrepareEvent.Set(new RoastScheduleCreatedEvent(Id)).ToVersion(1);
        }

        protected override ChooseRoastDaysForRoastSchedule When() {
            var roastDays = new[] {
                DayOfWeek.Monday,
                DayOfWeek.Tuesday,
                DayOfWeek.Thursday,
                DayOfWeek.Friday,
                DayOfWeek.Saturday
            };
            return new ChooseRoastDaysForRoastSchedule(Id, roastDays, 0);
        }

        protected override ICommandHandler<ChooseRoastDaysForRoastSchedule> CommandHandler() {
            return new ChooseRoastDaysForRoastScheduleCommandHandler(MockRepository.Object);
        }

        [Then]
        public void Then_days_for_roast_schedule_are_chosen() {
            PublishedEvents.Last().Should().BeOfType<RoastScheduleRoastDaysChosenEvent>();
        }
        
    }
}
