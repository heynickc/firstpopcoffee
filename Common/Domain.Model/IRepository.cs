using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Model {
    public interface IRepository<TAggregateRoot> where TAggregateRoot : AggregateRoot, new() {
        void Save(TAggregateRoot aggregate, int exptectedVersion);
        TAggregateRoot GetById(Guid id);
    }
}
