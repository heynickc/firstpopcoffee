using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.Model;
using Xunit;

namespace RoastPlanning.Tests {
    public abstract class Specification<T, TCommand> where T : AggregateRoot {
        public abstract T Given();
        public abstract TCommand When();
        public T sut;
        public List<Event> produced;
        public Exception caught;

        public Specification() {
            try {
                sut = Given();
                When();
                produced = new List<Event>(sut.GetUncommittedChanges());
            }
            catch (Exception ex) {
                caught = ex;
            }
        }
    }
}

public class ThenAttribute : FactAttribute { }