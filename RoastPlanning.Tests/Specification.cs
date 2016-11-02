using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.Model;
using Moq;
using Xunit;

namespace RoastPlanning.Tests {
    public abstract class Specification<TAggregateRoot, TCommand>
            where TAggregateRoot : AggregateRoot, new()
            where TCommand : Command {

        protected virtual IEnumerable<Event> Given() {
            return new List<Event>();
        }
        protected abstract TCommand When();

        protected Mock<IRepository<TAggregateRoot>> MockRepository;
        protected abstract ICommandHandler<TCommand> CommandHandler();
        protected TAggregateRoot AggregateRoot;
        protected IEnumerable<Event> PublishedEvents;
        protected Exception Caught;

        protected Specification() {
            AggregateRoot = new TAggregateRoot();
            AggregateRoot.LoadFromHistory(Given());

            MockRepository = new Mock<IRepository<TAggregateRoot>>();
            MockRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(AggregateRoot);
            MockRepository.Setup(x => x.Save(It.IsAny<TAggregateRoot>(), It.IsAny<int>()))
                .Callback<TAggregateRoot, int>((x, _) => AggregateRoot = x);

            CommandHandler().Handle(When());

            PublishedEvents = new List<Event>(AggregateRoot.GetUncommittedChanges());
        }
    }
}

public class ThenAttribute : FactAttribute { }