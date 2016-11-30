using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPopCoffee.Common.Domain.Model {
    public interface IEventHandler<TEvent> where TEvent : Message {
        void Handle(TEvent message);
    }
}
