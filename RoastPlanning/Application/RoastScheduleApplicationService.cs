using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.Model;
using RoastPlanning.Domain.Model;

namespace RoastPlanning.Application {
    public class RoastScheduleApplicationService {
        private readonly IRepository<RoastSchedule> _repository;

        public RoastScheduleApplicationService(IRepository<RoastSchedule> repository) {
            _repository = repository;
        }

        public RoastSchedule CreateRoastSchedule() {
            var roastSchedule = new RoastSchedule(Guid.NewGuid());
            // 0 is only there because that's required by 'Event Sourced' Repository
            _repository.Save(roastSchedule, 0);
            return roastSchedule;
        }
    }
}
