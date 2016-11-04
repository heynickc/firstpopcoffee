using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.Model;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace RoastPlanning.Tests {
    public abstract class Specification<TAggregateRoot, TCommand>
            where TAggregateRoot : AggregateRoot, new()
            where TCommand : Command {

        protected virtual IEnumerable<Event> Given() {
            return new List<Event>();
        }
        protected abstract TCommand When();
        protected abstract ICommandHandler<TCommand> CommandHandler();
        protected TAggregateRoot AggregateRoot;
        protected Mock<IRepository<TAggregateRoot>> MockRepository;

        // collects published events for assertion
        protected IEnumerable<Event> PublishedEvents;
        protected Exception CaughtException;

        protected Specification() {

            AggregateRoot = new TAggregateRoot();
            AggregateRoot.LoadFromHistory(Given());

            MockRepository = new Mock<IRepository<TAggregateRoot>>();
            MockRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(AggregateRoot);
            MockRepository.Setup(x => x.Save(It.IsAny<TAggregateRoot>(), It.IsAny<int>()))
                .Callback<TAggregateRoot, int>((x, _) => AggregateRoot = x);

            try {
                CommandHandler().Handle(When());
                PublishedEvents = new List<Event>(AggregateRoot.GetUncommittedChanges());
            }
            catch (Exception exception) {
                CaughtException = exception;
            }

        }
    }

    public class ThenAttribute : FactAttribute { }

    public class PrepareEvent {

        public static EventVersionSetter Set(Event domainEvent) {
            return new EventVersionSetter(domainEvent);
        }
    }

    public class EventVersionSetter {

        private readonly Event _event;

        public EventVersionSetter(Event @event) {
            _event = @event;
        }

        public Event ToVersion(int version) {
            _event.Version = version;
            return _event;
        }
    }
}

