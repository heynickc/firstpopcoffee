using System;
using System.Collections.Generic;
using FirstPopCoffee.Common.Domain.Model;

namespace FirstPopCoffee.RoastPlanning.Domain.Model {
    public class RoastDays : ValueObject<RoastDays> {
        public HashSet<RoastDay> Days { get; private set; }
        public RoastDays(HashSet<RoastDay> days) {
            Days = days;
        }
        public RoastDays(DayOfWeek[] days) {
            Days = new HashSet<RoastDay>();
            foreach (var day in days) {
                Days.Add(new RoastDay(day));
            }
        }
        protected override IEnumerable<object> GetAllAttributesToBeUsedForEquality() {
            return new List<object>() { new SetByValue<RoastDay>(this.Days) };
        }
    }

    public class RoastDay : ValueObject<RoastDay> {
        public DayOfWeek Day { get; private set; }
        public RoastDay(DayOfWeek day) {
            Day = day;
        }
        protected override IEnumerable<object> GetAllAttributesToBeUsedForEquality() {
            return new List<object>() { this.Day };
        }
    }
}
