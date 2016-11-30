using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstPopCoffee.Common.Domain.Model;

namespace FirstPopCoffee.RoastPlanning.Tests.Bus.Publishing_events {
    public class TestEventHandler : IEventHandler<TestEvent> {
        public List<Guid> HandledEventIds { get; }

        public TestEventHandler() {
            HandledEventIds = new List<Guid>();
        }

        public void Handle(TestEvent @event) {
            HandledEventIds.Add(@event.Id);
        }
    }
}
