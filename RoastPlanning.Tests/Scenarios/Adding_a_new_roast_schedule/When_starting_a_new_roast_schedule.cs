using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.Model;
using FluentAssertions;
using Moq;
using RoastPlanning.Application;
using RoastPlanning.Domain.Model;
using Xunit;

namespace RoastPlanning.Tests.Scenarios.Adding_a_new_roast_schedule {   
    public class When_starting_to_create_a_new_roast_schedule : Specification<RoastSchedule, StartCreatingRoastScheduleCommand> {

        private Guid Id = Guid.NewGuid();

        protected override StartCreatingRoastScheduleCommand When() {
            return new StartCreatingRoastScheduleCommand(Id);
        }

        protected override ICommandHandler<StartCreatingRoastScheduleCommand> CommandHandler() {
            return new StartCreatingRoastScheduleCommandHandler(MockRepository.Object);
        }

        [Then]
        public void Then_a_roast_schedule_created_event_will_be_published() {
            PublishedEvents.Should().NotBeNullOrEmpty();
            PublishedEvents.Last().Should().BeOfType<RoastScheduleCreatedEvent>();
            PublishedEvents.Last().As<RoastScheduleCreatedEvent>().RoastScheduleId.Should().Be(Id);
            PublishedEvents.Last().Version.Should().Be(0);
        }
    }
}
