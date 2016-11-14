using System;

namespace FirstPopCoffee.Common.Domain.Model {
    public interface IRepository<TAggregateRoot> where TAggregateRoot : AggregateRoot, new() {
        void Save(TAggregateRoot aggregate, int exptectedVersion);
        TAggregateRoot GetById(Guid id);
    }
}
