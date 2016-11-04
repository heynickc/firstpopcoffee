using System;
using System.Collections.Generic;
using Common.Domain.Model;
using Moq;

namespace RoastPlanning.Tests {

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

            AggregateRoot = new TAggregateRoot();
            AggregateRoot.LoadFromHistory(Given());

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