using System;
using System.Linq;
using FirstPopCoffee.Common.Domain.Model;
using FirstPopCoffee.RoastPlanning.Application;
using FirstPopCoffee.RoastPlanning.Domain.Model;
using FluentAssertions;

namespace FirstPopCoffee.RoastPlanning.Tests.Scenarios.Adding_a_new_roast_schedule {   
    public class When_starting_to_create_a_new_roast_schedule : CommandSpecification<RoastSchedule, StartCreatingRoastScheduleCommand> {

        private readonly Guid _roastScheduleId = Guid.NewGuid();

        protected override StartCreatingRoastScheduleCommand When() {
            return new StartCreatingRoastScheduleCommand(Guid.NewGuid(), _roastScheduleId);
        }

        protected override ICommandHandler<StartCreatingRoastScheduleCommand> CommandHandler() {
            return new StartCreatingRoastScheduleCommandHandler(MockRepository.Object);
        }

        [Then]
        public void Then_a_roast_schedule_is_created() {
            PublishedEvents.Should().NotBeNullOrEmpty();
            PublishedEvents.Last().Should().BeOfType<RoastScheduleCreatedEvent>();
            PublishedEvents.Last().As<RoastScheduleCreatedEvent>().RoastScheduleId.Should().Be(_roastScheduleId);
        }
    }
}
