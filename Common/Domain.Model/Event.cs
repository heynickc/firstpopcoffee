using System;

namespace FirstPopCoffee.Common.Domain.Model {
    public class Event : Message {
        public Guid Id;
        public int Version;
        public Event() {
            Id = Guid.NewGuid();
        }
    }
}
