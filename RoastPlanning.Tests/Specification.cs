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
        public T SUT;
        public List<Event> Produced;
        public Exception Caught;

        public Specification() {
            try {
                SUT = Given();
                When();
                Produced = new List<Event>(SUT.GetUncommittedChanges());
            }
            catch (Exception ex) {
                Caught = ex;
            }
        }
    }
}

public class ThenAttribute : FactAttribute { }