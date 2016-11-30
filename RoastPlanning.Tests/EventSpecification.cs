using System;
using System.Collections.Generic;
using FirstPopCoffee.Common.Domain.Model;
using FirstPopCoffee.Common.Events;
using Moq;

namespace FirstPopCoffee.RoastPlanning.Tests {

    public abstract class EventSpecification<TAggregateRoot, TEvent>
        where TAggregateRoot : EventSourcedAggregateRoot, new()
        where TEvent : Event {

        protected virtual IEnumerable<Event> Given() {
            return new List<Event>();
        }
        protected abstract TEvent When();
        protected abstract IEventHandler<TEvent> EventHandler();
        protected TAggregateRoot AggregateRoot;
        protected Mock<IRepository<TAggregateRoot>> MockRepository;

        // collects published events for assertion
        protected IEnumerable<Event> PublishedEvents;
        protected Exception CaughtException;

        protected EventSpecification() {

            AggregateRoot = new TAggregateRoot();
            AggregateRoot.LoadFromHistory(Given());

            MockRepository = new Mock<IRepository<TAggregateRoot>>();
            MockRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(AggregateRoot);
            MockRepository.Setup(x => x.Save(It.IsAny<TAggregateRoot>(), It.IsAny<int>()))
                .Callback<TAggregateRoot, int>((x, _) => AggregateRoot = x);

            try {
                EventHandler().Handle(When());
                PublishedEvents = new List<Event>(AggregateRoot.GetUncommittedChanges());
            }
            catch (Exception exception) {
                CaughtException = exception;
            }

        }
    }

}