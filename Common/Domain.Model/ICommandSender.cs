namespace Common.Domain.Model {
    public interface ICommandSender {
        void Send<T>(T command) where T : Command;
    }
}