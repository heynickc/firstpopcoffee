using FirstPopCoffee.Common.Domain.Model;
using FirstPopCoffee.RoastPlanning.Domain.Model;

namespace FirstPopCoffee.RoastPlanning.Application {
    public class StartCreatingRoastScheduleCommandHandler : ICommandHandler<StartCreatingRoastScheduleCommand> {
        private readonly IRepository<RoastSchedule> _repository;

        public StartCreatingRoastScheduleCommandHandler(IRepository<RoastSchedule> repository) {
            _repository = repository;
        }

        public void Handle(StartCreatingRoastScheduleCommand message) {
            var roastSchedule = new RoastSchedule(message.Id);
            _repository.Save(roastSchedule, -1);
        }
    }
}
