using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.Model;
using RoastPlanning.Domain.Model;

namespace RoastPlanning.Application {
    public class ChooseRoastDaysForRoastScheduleCommandHandler : ICommandHandler<ChooseRoastDaysForRoastScheduleCommand> {
        private readonly IRepository<RoastSchedule> _repository;
        public ChooseRoastDaysForRoastScheduleCommandHandler(IRepository<RoastSchedule> repository) {
            _repository = repository;
        }
        public void Handle(ChooseRoastDaysForRoastScheduleCommand message) {
            var roastSchedule = _repository.GetById(message.Id);
            roastSchedule.SetRoastDays(new RoastDays(message.RoastDays));
            _repository.Save(roastSchedule, message.OriginalVersion);
        }
    }
}
