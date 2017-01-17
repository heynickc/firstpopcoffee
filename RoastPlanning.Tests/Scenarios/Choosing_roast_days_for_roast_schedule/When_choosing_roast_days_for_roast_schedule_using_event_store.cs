using System;
using System.Collections.Generic;
using System.Linq;
using FirstPopCoffee.Common.Domain.Model;
using FirstPopCoffee.Common.Events;
using FirstPopCoffee.RoastPlanning.Application;
using FirstPopCoffee.RoastPlanning.Domain.Model;
using FluentAssertions;

namespace FirstPopCoffee.RoastPlanning.Tests.Scenarios.Choosing_roast_days_for_roast_schedule {

    //public class When_choosing_roast_days_for_roast_schedule_using_event_store : SpecificationNoMocks<RoastSchedule, ChooseRoastDaysForRoastScheduleCommand> {

    //    private readonly Guid Id = Guid.NewGuid();

    //    protected override IEnumerable<Event> Given() {
    //        yield return PrepareEvent.Set(
    //            new RoastScheduleCreatedEvent(Id, DateTime.Now.StartOfWeek(DayOfWeek.Sunday))).ToVersion(1);
    //    }

    //    protected override ChooseRoastDaysForRoastScheduleCommand When() {
    //        var roastDays = new[] {
    //            DayOfWeek.Monday,
    //            DayOfWeek.Tuesday,
    //            DayOfWeek.Thursday,
    //            DayOfWeek.Friday,
    //            DayOfWeek.Saturday
    //        };
    //        return new ChooseRoastDaysForRoastScheduleCommand(Id, roastDays, 1);
    //    }

    //    protected override ICommandHandler<ChooseRoastDaysForRoastScheduleCommand> CommandHandler() {
    //        return new ChooseRoastDaysForRoastScheduleCommandHandler(Repository);
    //    }

    //    [Then(Skip = "Not working yet")]
    //    public void Then_days_for_roast_schedule_are_chosen() {
    //        PublishedEvents.Last().Should().BeOfType<RoastScheduleRoastDaysChosenEvent>();
    //    }
    //}
}