namespace FirstPopCoffee.Common.Domain.Model {
    public interface ICommandHandler<TCommand> where TCommand : Message {
        void Handle(TCommand message);
    }
}
