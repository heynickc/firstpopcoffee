namespace FirstPopCoffee.Common.Domain.Model {
    public interface IEventPublisher {
        void Publish<T>(T @event) where T : Event;
    }
}
