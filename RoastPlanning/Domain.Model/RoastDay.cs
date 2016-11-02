using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.Model;

namespace RoastPlanning.Domain.Model {
    public class RoastDay : ValueObject<RoastDay> {
        public DayOfWeek DayOfWeek { get; set; }
        protected override IEnumerable<object> GetAllAttributesToBeUsedForEquality() {
            yield return this.DayOfWeek;
        }
    }
}
