using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Model {
    public interface IRepository<T> where T : AggregateRoot, new() {
        void Save(AggregateRoot aggregate, int exptectedVersion);
        T GetById(Guid id);
    }
}
