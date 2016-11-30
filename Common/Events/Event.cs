using System;
using FirstPopCoffee.Common.Domain.Model;

namespace FirstPopCoffee.Common.Events {
    public class Event : Message {
        public Guid Id;
        public int Version;
        public Event() {
            Id = Guid.NewGuid();
        }
    }
}
