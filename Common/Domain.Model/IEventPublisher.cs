using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Model {
    public interface IEventPublisher {
        void Publish<T>(T @event) where T : Event;
    }
}
