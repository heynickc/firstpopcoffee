using System;

namespace FirstPopCoffee.Common.Domain.Model {
    public class Command : Message {
        public Guid Id { get; }
        public Command(Guid id) {
            Id = id;
        }
    }
}
