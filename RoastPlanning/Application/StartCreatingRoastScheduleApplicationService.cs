using System;
using FirstPopCoffee.Common.Domain.Model;
using FirstPopCoffee.RoastPlanning.Domain.Model;

namespace FirstPopCoffee.RoastPlanning.Application {
    public class StartCreatingRoastScheduleApplicationService {
        private readonly IRepository<RoastSchedule> _repository;

        public StartCreatingRoastScheduleApplicationService(IRepository<RoastSchedule> repository) {
            _repository = repository;
        }

        public RoastSchedule CreateRoastSchedule() {
            var roastSchedule = new RoastSchedule(Guid.NewGuid());
            // 0 is only there because that's required by 'Event Sourced' Repository
            _repository.Save(roastSchedule, 0);
            return roastSchedule;
        }
    }

    //public class UpdateRoastScheduleRoastDaysApplicationService {
    //    private readonly IRepository<RoastSchedule> _repository;

    //    public UpdateRoastScheduleRoastDaysApplicationService(IRepository<RoastSchedule> repository) {
    //        _repository = repository;
    //    }

    //    public RoastSchedule UpdateRoastScheduleRoastDays(Guid roastScheduleId, List<RoastDay> newRoastDays) {
    //        var roastDay = _repository.GetById(roastScheduleId.ToString());
    //        roastDay.RoastDays = newRoastDays;
    //        _repository.Save(roastDay);
    //    }
    //}

    //public class UpdateRoastScheduleRoastDaysApplicationService {
    //    private readonly IRepository<RoastSchedule> _repository;

    //    public UpdateRoastScheduleRoastDaysApplicationService(IRepository<RoastSchedule> repository) {
    //        _repository = repository;
    //    }

    //    public RoastSchedule UpdateRoastScheduleRoastDays(UpdateRoastScheduleRoastDays u) {
    //        var roastSchedule = _repository.GetById(u.RoastDayId.ToString());
    //        roastSchedule.UpdateRoastScheduleRoastDays(u.NewRoastDays);
    //        _repository.Save(roastSchedule);
    //        return roastSchedule;
    //    }

    //    public class UpdateRoastScheduleRoastDays {
    //        private readonly Guid RoastDayId;
    //        private readonly List<RoastDay> NewRoastDays;
    //        public UpdateRoastScheduleRoastDays(Guid roastDayId, List<RoastDay> newRoastDays) {
    //            RoastDayId = roastDayId;
    //            NewRoastDays = newRoastDays;
    //        }
    //    }
    //}
}
