using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPopCoffee.Common.Domain.Model {
    public interface IRouteMessages {
        void Route(object message);
    }

    public class MessageRouter : IRouteMessages {
        private readonly IDictionary<Type, ICollection<Action<object>>> _routes;

        public MessageRouter() {
            _routes = new Dictionary<Type, ICollection<Action<object>>>();
        }

        public void Register<TMessage>(Action<TMessage> route) where TMessage : class {
            var routingKey = typeof(TMessage);
            ICollection<Action<object>> routes;

            if (!_routes.TryGetValue(routingKey, out routes))
                _routes[routingKey] = routes = new LinkedList<Action<object>>();

            routes.Add(message => route(message as TMessage));
        }

        public void Route(object message) {
            ICollection<Action<object>> routes;

            if (!_routes.TryGetValue(message.GetType(), out routes))
                throw new RouteNotRegisteredException(message.GetType());

            foreach (var route in routes)
                route(message);
        }
    }

    public class RouteNotRegisteredException : Exception {
        public RouteNotRegisteredException(Type messageType) : base(string.Format("No route specified for message '{0}'", messageType.FullName)) {
        }
    }
}
