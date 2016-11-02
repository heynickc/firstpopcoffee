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
    public class When_starting_a_new_roast_schedule : Specification<RoastSchedule, StartCreatingRoastScheduleCommand> {

        private readonly Guid Id;

        public When_starting_a_new_roast_schedule() {
            Id = new Guid();
        }

        protected override ICommandHandler<StartCreatingRoastScheduleCommand> CommandHandler() {
            return new StartCreatingRoastScheduleCommandHandler(MockRepository.Object);
        }

        protected override StartCreatingRoastScheduleCommand When() {
            return new StartCreatingRoastScheduleCommand(Id);
        }

        [Then]
        public void The_roast_schedule_is_created() {
            PublishedEvents.Should().NotBeNullOrEmpty();
        }
    }
}
