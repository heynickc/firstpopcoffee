using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstPopCoffee.Common.Domain.Model;
using FirstPopCoffee.RoastPlanning.Tests.Bus.Sending_commands;
using FluentAssertions;

namespace FirstPopCoffee.RoastPlanning.Tests.Bus.Publishing_events {

    public class When_publishing_an_event_to_the_fakebus_with_a_single_event_handler_registered : EventSpecification<TestAggregateRoot, TestEvent> {

        private readonly FakeBus _bus;
        private TestEventHandler _handler;
        private TestEvent _event;
        public When_publishing_an_event_to_the_fakebus_with_a_single_event_handler_registered() {
            _bus = new FakeBus();
            _bus.RegisterHandler<TestEvent>(_handler.Handle);
        }

        protected override TestEvent When() {
            _event = new TestEvent();
            return _event;
        }

        protected override IEventHandler<TestEvent> EventHandler() {
            _handler = new TestEventHandler();
            return _handler;
        }

        [Then]
        public void Then_handle_method_is_invoked_on_command_handler() {
            _handler.HandledEventIds.First().Should().Be(_event.Id);
        }
    }
}
