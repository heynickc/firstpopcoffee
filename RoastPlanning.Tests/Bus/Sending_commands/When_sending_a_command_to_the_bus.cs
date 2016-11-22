using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstPopCoffee.Common.Domain.Model;
using FluentAssertions;

namespace FirstPopCoffee.RoastPlanning.Tests.Bus.Sending_commands {

    public class TestCommand : Command {
        public TestCommand(Guid id) : base(id) {

        }
    }

    public class TestCommandHandler : ICommandHandler<TestCommand> {
        public List<Guid> CommandIds { get; }
        public TestCommandHandler() {
            CommandIds = new List<Guid>();
        }
        public void Handle(TestCommand command) {
            CommandIds.Add(command.Id);
        }
    }

    public class TestAggregateRoot : EventSourcedAggregateRoot {

    }

    public class When_sending_a_command_to_the_bus : Specification<TestAggregateRoot, TestCommand> {
        private readonly FakeBus _bus;
        private readonly TestCommandHandler _handler;
        private readonly TestCommand _command;
        public When_sending_a_command_to_the_bus() {
            _bus = new FakeBus();
            _handler = new TestCommandHandler();
            _command = new TestCommand(Guid.NewGuid());
            _bus.RegisterHandler<TestCommand>(_handler.Handle);
        }

        protected override TestCommand When() {
            return _command;
        }

        protected override ICommandHandler<TestCommand> CommandHandler() {
            return _handler;
        }

        [Then]
        public void Then_handle_method_is_invoked_on_command_handler() {
            _handler.CommandIds.First().Should().Be(_command.Id);
        }
    }
}
