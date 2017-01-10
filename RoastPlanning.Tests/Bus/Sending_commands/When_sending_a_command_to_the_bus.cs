using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstPopCoffee.Common.Domain.Model;
using FluentAssertions;

namespace FirstPopCoffee.RoastPlanning.Tests.Bus.Sending_commands {

    public class When_sending_a_command_to_the_fakebus_with_a_single_command_handler : CommandSpecification<TestAggregateRoot, TestCommand> {
        private readonly FakeBus _bus;
        private TestCommandHandler _handler;
        private TestCommand _command;
        public When_sending_a_command_to_the_fakebus_with_a_single_command_handler() {
            _bus = new FakeBus();
            _bus.RegisterHandler<TestCommand>(_handler.Handle);
        }

        protected override TestCommand When() {
            _command = new TestCommand();
            return _command;
        }

        protected override ICommandHandler<TestCommand> CommandHandler() {
            _handler = new TestCommandHandler();
            return _handler;
        }

        [Then]
        public void Then_handle_method_is_invoked_on_command_handler() {
            _handler.HandledCommandIds.First().Should().Be(_command.Id);
        }
    }

    public class When_sending_a_command_to_the_fakebus_with_multiple_command_handlers : CommandSpecification<TestAggregateRoot, TestCommand> {
        private readonly FakeBus _bus;
        private TestCommandHandler _handler;
        private TestCommand _command;
        public When_sending_a_command_to_the_fakebus_with_multiple_command_handlers() {
            _bus = new FakeBus();
            _bus.RegisterHandler<TestCommand>(_handler.Handle);
        }

        protected override TestCommand When() {
            _command = new TestCommand();
            return _command;
        }

        protected override ICommandHandler<TestCommand> CommandHandler() {
            _handler = new TestCommandHandler();
            return _handler;
        }

        [Then]
        public void Then_handle_method_is_invoked_on_command_handler() {
            _handler.HandledCommandIds.First().Should().Be(_command.Id);
        }
    }
}
