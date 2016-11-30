using System;
using System.Collections.Generic;
using FirstPopCoffee.Common.Events;

namespace FirstPopCoffee.Common.Domain.Model {
    public interface IEventStore {
        void SaveEvents(Guid aggregateId, IEnumerable<Event> events, int expectedVersion);
        List<Event> GetEventsForAggregate(Guid aggregateId);
    }
}
