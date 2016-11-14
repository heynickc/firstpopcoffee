using System;
using System.Collections.Generic;
using FirstPopCoffee.Common.Domain.Model;
using ReflectionMagic;

namespace FirstPopCoffee.RoastPlanning.Tests {

    public abstract class SpecificationNoMocks<TAggregateRoot, TCommand>
        where TAggregateRoot : AggregateRoot, new()
        where TCommand : Command {

        protected virtual IEnumerable<Event> Given() {
            return new List<Event>();
        }
        protected abstract TCommand When();
        protected abstract ICommandHandler<TCommand> CommandHandler();
        protected TAggregateRoot AggregateRoot;
        protected IRepository<TAggregateRoot> Repository;

        // collects published events for assertion
        protected IEnumerable<Event> PublishedEvents;
        protected Exception CaughtException;

        protected SpecificationNoMocks() {
             
            Repository = new EventSourcedRepository<TAggregateRoot>(
                new EventStore(
                    new FakeBus()));

            AggregateRoot = new TAggregateRoot();
            foreach (var @event in Given()) {
                AggregateRoot.AsDynamic().Apply(@event);
                
            }

            Repository.Save(AggregateRoot, 1);

            try {
                CommandHandler().Handle(When());
                PublishedEvents = new List<Event>(AggregateRoot.GetUncommittedChanges());
            }
            catch (Exception exception) {
                CaughtException = exception;
            }
        }
    }
}