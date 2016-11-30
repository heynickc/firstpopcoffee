using System;
using FirstPopCoffee.Common.Domain.Model;

namespace FirstPopCoffee.Common.Events {
    public class EventSourcedRepository<T> : IRepository<T> where T : EventSourcedAggregateRoot, new() {

        private readonly IEventStore _storage;
        public EventSourcedRepository(IEventStore storage) {
            _storage = storage;
        }

        public void Save(T aggregate, int expectedVersion) {
            _storage.SaveEvents(aggregate.Id, aggregate.GetUncommittedChanges(), expectedVersion);
        }

        public T GetById(Guid id) {
            var obj = new T();//lots of ways to do this
            var e = _storage.GetEventsForAggregate(id);
            obj.LoadFromHistory(e);
            return obj;
        }
    }
}
