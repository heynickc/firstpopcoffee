using FirstPopCoffee.Common.Domain.Model;
using FirstPopCoffee.RoastPlanning.Domain.Model;

namespace FirstPopCoffee.RoastPlanning.Application {
    public class StartCreatingRoastScheduleCommandHandler : ICommandHandler<CreateNewRoastScheduleCommand> {
        private readonly IRepository<RoastSchedule> _repository;

        public StartCreatingRoastScheduleCommandHandler(IRepository<RoastSchedule> repository) {
            _repository = repository;
        }

        public void Handle(CreateNewRoastScheduleCommand message) {
            var roastSchedule = new RoastSchedule(message.RoastScheduleId);
            _repository.Save(roastSchedule, -1);
        }
    }
}
