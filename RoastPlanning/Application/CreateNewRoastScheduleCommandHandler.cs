using System;
using FirstPopCoffee.Common.Domain.Model;
using FirstPopCoffee.RoastPlanning.Domain.Model;

namespace FirstPopCoffee.RoastPlanning.Application {
    public class CreateNewRoastScheduleCommandHandler  {
        private readonly IRepository<RoastSchedule> _repository;

        public CreateNewRoastScheduleCommandHandler(IRepository<RoastSchedule> repository) {
            _repository = repository;
        }

        public void Handle(CreateNewRoastScheduleCommand message) {
            var roastWeekStartsOn = DateTime.Now.StartOfWeek(DayOfWeek.Sunday);
            var roastSchedule = new RoastSchedule(message.RoastScheduleId, roastWeekStartsOn);
            _repository.Save(roastSchedule, -1);
        }
    }
}
