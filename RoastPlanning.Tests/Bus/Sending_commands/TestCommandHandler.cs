using System;
using System.Collections.Generic;
using FirstPopCoffee.Common.Domain.Model;

namespace FirstPopCoffee.RoastPlanning.Tests.Bus.Sending_commands {

    public class TestCommandHandler : ICommandHandler<TestCommand> {
        public List<Guid> CommandIds { get; }
        public TestCommandHandler() {
            CommandIds = new List<Guid>();
        }
        public void Handle(TestCommand command) {
            CommandIds.Add(command.Id);
        }
    }

}