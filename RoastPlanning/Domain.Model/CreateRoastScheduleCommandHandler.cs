using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.Model;

namespace RoastPlanning.Domain.Model {
    public class CreateRoastScheduleCommandHandler : ICommandHandler<CreateRoastSchedule> {
        private readonly IRepository<RoastSchedule> _repository;

        public CreateRoastScheduleCommandHandler(IRepository<RoastSchedule> repository) {
            _repository = repository;
        }

        public void Handle(CreateRoastSchedule message) {
            var roastSchedule = new RoastSchedule(Guid.NewGuid());
            _repository.Save(roastSchedule);
        }
    }
}
