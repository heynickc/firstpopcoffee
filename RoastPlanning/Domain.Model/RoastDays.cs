using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.Model;

namespace RoastPlanning.Domain.Model {
    public class RoastDays : ValueObject<RoastDays> {
        public HashSet<DayOfWeek> DaysOfTheWeek { get; private set; }
        public RoastDays(HashSet<DayOfWeek> daysOfTheWeek) {
            DaysOfTheWeek = daysOfTheWeek;
        }
        protected override IEnumerable<object> GetAllAttributesToBeUsedForEquality() {
            return new List<object>() { new SetByValue<DayOfWeek>(this.DaysOfTheWeek) };
        }
    }
}
