using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.Model;

namespace RoastPlanning.Tests {
    public class FakeRepository<T> : IRepository<T> where T : AggregateRoot, new() {

        private readonly HashSet<T> _data;

        public FakeRepository(HashSet<T> data) {
            _data = data;
        }

        public T GetById(Guid id) {
            return _data.FirstOrDefault(x => x.Id == id);
        }

        public void Save(AggregateRoot aggregate, int exptectedVersion) { }
    }
}
