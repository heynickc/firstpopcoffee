using System;
using Common.Domain.Model;
using RoastPlanning.Domain.Model;

namespace RoastPlanning.Application {
    public class CreateRoastScheduleCommandHandler : ICommandHandler<CreateRoastSchedule> {
        private readonly IRepository<RoastSchedule> _repository;

        public CreateRoastScheduleCommandHandler(IRepository<RoastSchedule> repository) {
            _repository = repository;
        }

        public void Handle(CreateRoastSchedule message) {
            var roastSchedule = new RoastSchedule(Guid.NewGuid());
            _repository.Save(roastSchedule, -1);
        }
    }
}
